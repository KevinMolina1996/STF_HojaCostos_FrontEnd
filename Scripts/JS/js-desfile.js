$(document).ready(function () {
    $('#tablaSegui').DataTable({
        ordering: false,
        responsive: true,
        paging: false,
        info: false,
        searching: false
    });
    $("#Exportar").click(function () {
        data = null;
        var data = [['Referencia', 'Descripcion', 'Precio Minimo', 'Precio Maximo', 'Precio Aprobado', 'Costo', 'Observaciones', 'Margen Bruto', 'Cantidad']];
        $("#tablaSegui tbody tr").each(function () {
            var row = $(this);
            var model = [];
            model = [row.find("td #Referencia").val(), row.find("td #Descripcion").val(), row.find("td #PrecMinimo").val(), row.find("td #PrecMaximo").val(), row.find("td #PrecioAprobado").val(), row.find("td #Costo").val(), row.find("td #Observaciones").val(), row.find("td #MargenBruto").val(), row.find("td #Cantidad").val()];
            data.push(model);
        });
        arrayToTable = function (data, options = {}) {
            var table = $('<table />'),
                thead,
                tfoot,
                rows = [],
                row,
                i, j,
                defaults = {
                    th: true, // should we use th elemenst for the first row
                    thead: false, //should we incldue a thead element with the first row
                    tfoot: false, // should we include a tfoot element with the last row
                    attrs: {} // attributes for the table element, can be used to
                }

            options = $.extend(defaults, options);

            table.attr(options.attrs);

            // loop through all the rows, we will deal with tfoot and thead later
            for (i = 0; i < data.length; i++) {
                row = $('<tr />');
                for (j = 0; j < data[i].length; j++) {
                    if (i === 0 && options.th) {
                        row.append($('<th />').html(data[i][j]));
                    } else {
                        row.append($('<td />').html(data[i][j]));
                    }
                }
                rows.push(row);
            }

            // if we want a thead use shift to get it
            if (options.thead) {
                thead = rows.shift();
                thead = $('<thead />').append(thead);
                table.append(thead);
            }

            // if we want a tfoot then pop it off for later use
            if (options.tfoot) {
                tfoot = rows.pop();
            }

            // add all the rows
            for (i = 0; i < rows.length; i++) {
                table.append(rows[i]);
            }

            // and finally add the footer if needed
            if (options.tfoot) {
                tfoot = $('<tfoot />').append(tfoot);
                table.append(tfoot);
            }
            return table;
        }

        var table = arrayToTable(data, {
            thead: true,
            attrs: { class: 'table' }
        });
        $('#export').append(table);
        window.open('data:application/vnd.ms-excel,' + encodeURIComponent($('#export').html()));
        e.preventDefault();
    });

    $("#adicionar").click(function (e) {
        e.preventDefault();
        var $tableBody = $("#tablaSegui");
        var $trLast = $tableBody.find("tbody>tr:last");
        var $trNew = $trLast.clone(true, true);

        var suffix = $trNew.find(':input:first').attr('name').match(/\d+/);
        $trNew.find("td:last").html('<a href="javascript: void(0)" class="remove">Eliminar</a>');
        $.each($trNew.find(':input'), function (i, val) {
            // Replaced Name
            var oldN = $(this).attr('name');
            var newN = oldN.replace('[' + suffix + ']', '[' + (parseInt(suffix) + 1) + ']');
            $(this).attr('name', newN);
            //Replaced value
            var type = $(this).attr('type');
            if (type.toLowerCase() === "text" || type.toLowerCase() === "hidden") {
                $(this).val("");
            }

            // If you have another Type then replace with default value
            $(this).removeClass("input-validation-error");

        });
        $trLast.after($trNew);
        $trNew.show();
    });

    $(document).on("click", ".remove", function (e) {
        e.preventDefault();
        $(this).parent().parent().remove();
        calcularDetalladoPN();
        calcularDetalladoPNP();
    });

    $("#PrecioAprobado").change(function () {
        var precio = $(this).val();
        var iva = $("#iva").val();

        var total = parseFloat(precio) / parseFloat(iva);

        $(this).closest("tr").find("#PrecioAprobadoSin").val(total.toFixed(0));

    });

    $("#Cantidad").change(function () {
        var unidades = $(this).val();
        var precio = $(this).closest("tr").find("#PrecioAprobadoSin").val();
        var costo = $(this).closest("tr").find("#Costo").val();

        if (precio.length === 0 || costo.length === 0) {
            return;
        }

        var totalIngreso = parseFloat(precio) * parseFloat(unidades);
        var totalCosto = parseFloat(costo) * parseFloat(unidades);

        var margen = (totalIngreso - totalCosto) / totalIngreso;
        margen = margen * 100;

        $(this).closest("tr").find("#Ingreso").val(totalIngreso.toFixed(0));
        $(this).closest("tr").find("#CostoCalculo").val(totalCosto.toFixed(0));
        $(this).closest("tr").find("#Margen").val(margen.toFixed(0));


        if ($(this).closest("tr").find("#TipoInventario").val() === "PN") {
            calcularDetalladoPN();
        } else {
            calcularDetalladoPNP();
        }
    });

    function calcularDetalladoPN() {

        var totalIngresos = 0;
        var totalCostos = 0;
        var totalUnidades = 0;

        $('#tablaSegui > tbody  > tr').each(function (index, tr) {

            if ($(this).find("#TipoInventario").val() === "PN") {
                totalIngresos += parseFloat($(this).find("#Ingreso").val());
                totalCostos += parseFloat($(this).find("#CostoCalculo").val());
                totalUnidades += parseFloat($(this).find("#Cantidad").val());
            }

        });

        if (totalIngresos === 0 || totalCostos === 0) {
            return;
        }

        var margen = (totalIngresos - totalCostos) / totalIngresos;
        margen = margen * 100;

        var precioPromedio = totalIngresos / totalUnidades;
        var costoPromedio = totalCostos / totalUnidades;

        $("#ingresosPN").val(totalIngresos.toFixed(0));
        $("#costosPN").val(totalCostos.toFixed(0));
        $("#margenPN").val(margen.toFixed(0));
        $("#totalUnidadesPN").val(totalUnidades.toFixed(0));
        $("#precioPromedioPN").val(precioPromedio.toFixed(0));
        $("#costoPromedioPN").val(costoPromedio.toFixed(0));
        
    }

    function calcularDetalladoPNP() {

        var totalIngresos = 0;
        var totalCostos = 0;
        var totalUnidades = 0;

        $('#tablaSegui > tbody  > tr').each(function (index, tr) {

            if ($(this).find("#TipoInventario").val() === "PNP") {
                totalIngresos += parseFloat($(this).find("#Ingreso").val());
                totalCostos += parseFloat($(this).find("#CostoCalculo").val());
                totalUnidades += parseFloat($(this).find("#Cantidad").val());
            }

        });

        if (totalIngresos === 0 || totalCostos === 0) {
            return;
        }

        var margen = (totalIngresos - totalCostos) / totalIngresos;
        margen = margen * 100;

        var precioPromedio = totalIngresos / totalUnidades;
        var costoPromedio = totalCostos / totalUnidades;

        $("#ingresosPNP").val(totalIngresos.toFixed(0));
        $("#costosPNP").val(totalCostos.toFixed(0));
        $("#margenPNP").val(margen.toFixed(0));
        $("#totalUnidadesPNP").val(totalUnidades.toFixed(0));
        $("#precioPromedioPNP").val(precioPromedio.toFixed(0));
        $("#costoPromedioPNP").val(costoPromedio.toFixed(0));

    }

    $("#Referencia").change(function () {
        var Referencia = $(this).val();
        var contador = 0;
        $("#tablaSegui").each(function () {
            $(this).find("input").each(function () {
                if ($(this).attr("id") === "Referencia") {
                    if ($(this).val() === Referencia) {
                        contador = contador + 1;
                    }
                }
            });
        });

        if (contador > 1) {
            alerta("Advertencia!", "La referencia ingresada ya existe");
            return;
        }

        var params = { Referencia: Referencia, Codigo: $(this).closest("tr").find(".cod").attr("name") };
        $.ajax({
            url: '/Desfile/ConsultarReferencia',
            method: "post",
            data: params,
            success: function (result) {
                if (result.warning !== undefined) {
                    $("input[name*='" + result.Codigo + "']").closest("tr").find(".borrado").val("");
                    alerta("Advertencia!", result.warning);
                    return;
                }
                if (result.error !== undefined) {
                    alerta("Error!", result.mensaje);
                    return;
                }
                $("input[name*='" + result.Codigo + "']").closest("tr").find("#Descripcion").val(result.Descripcion);
                $("input[name*='" + result.Codigo + "']").closest("tr").find("#TipoInventario").val(result.Tipo);
                $("input[name*='" + result.Codigo + "']").closest("tr").find("#PreMinimo").val(result.PrecMinimo === "" ? "0" : result.PrecMinimo);
                $("input[name*='" + result.Codigo + "']").closest("tr").find("#PreMaximo").val(result.PrecMaximo === "" ? "0" : result.PrecMaximo);
                $("input[name*='" + result.Codigo + "']").closest("tr").find("#Costo").val(result.Costo);
                $("input[name*='" + result.Codigo + "']").closest("tr").find("#MargenBruto").val(result.MargenBruto === "" ? "0" : result.MargenBruto);
            },
            error: function (result) {
                $.alert({
                    title: 'Error!',
                    content: result.mensaje,
                });
            },
            async: true
        });
    });
});