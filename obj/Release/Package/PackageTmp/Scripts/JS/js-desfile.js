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
        var $trLast = $tableBody.find("tr:last");
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
    });

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