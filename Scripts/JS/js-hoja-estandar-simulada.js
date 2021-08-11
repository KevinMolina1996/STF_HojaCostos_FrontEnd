$('#Exportar').click(function (e) {
    e.preventDefault();

    $.confirm({
        title: 'Confirmar!',
        content: 'Seleccione la operación a realizar!',
        buttons: {
            PDF: function () {
                var action = "/HojaSimulada/ExportPDF";
                $("#FrmHojaSim").attr("action", action);
                $("#FrmHojaSim").submit();
            },
            EXCEL: function () {
                var action = "/HojaSimulada/ExportExcel";
                $("#FrmHojaSim").attr("action", action);
                $("#FrmHojaSim").submit();
            },
            CANCELAR: function () {

            }
        }
    });
});

$('#Imprimir').click(function (e) {
    e.preventDefault();

    $.confirm({
        title: 'Confirmar!',
        content: 'Desea continuar con el proceso?!',
        buttons: {
            CONFIRMAR: function () {
                var action = "/HojaSimulada/GenerarPdf";
                $("#FrmHojaSim").attr("action", action);
                $("#FrmHojaSim").submit();
            },
            CANCELAR: function () {

            }
        }
    });
});

$('#Volver').click(function (e) {
    e.preventDefault();

    $.confirm({
        title: 'Confirmar!',
        content: 'Desea continuar con el proceso?!',
        buttons: {
            CONFIRMAR: function () {
                var action = "/HojaSimulada/Volver";
                $("#FrmHojaSim").attr("action", action);
                $("#FrmHojaSim").submit();
            },
            CANCELAR: function () {

            }
        }
    });
});

//PERMITO SOLO CAMPOS NUMERICOS EN LOS INPUT NECESARIOS

$(".solonumeros").keydown(function (event) {
    if (event.shiftKey === true) {
        event.preventDefault();
    }

    if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode === 8 || event.keyCode === 9 || event.keyCode === 37 || event.keyCode === 39 || event.keyCode === 46 || event.keyCode === 188) {
        console.log("");
    }
    else {
        event.preventDefault();
    }

    if ($(this).val().indexOf('.') !== -1 && event.keyCode === 190)
        event.preventDefault();
});

//FIN

//CALCULO EL TOTAL DE TELAS - NO APLICA FORMULACION DINAMICA

$(".SimCtCtsxMtD, .SimCtConF").change(function () {
    var valor_cts = $(this).parents("tr").find("td input")[2].value;
    var valor_con = $(this).parents("tr").find("td input")[3].value;

    if (valor_cts.length > 0 && valor_con.length > 0) {
        var total = parseFloat(valor_cts.replace(",", ".")) * parseFloat(valor_con.replace(",", "."));
        $(this).parents("tr").find("td input")[4].value = total.toString().replace(".", ",");

        var totalTelas = 0;
        var totalCon = 0;
        $('#tablaTelas > tbody  > tr > td > input').each(function (index, value) {
            if ($(this).closest('tr').attr('style').includes("display: none") === false) {
                if ($(this).attr("data-nombre")) {
                    if ($(this).attr("data-nombre").includes("SimCtConF")) {
                        if ($(this).val().length > 0) {
                            totalCon = totalCon + parseFloat($(this).val().replace(",", "."));
                        }
                    }
                }
                if ($(this).attr("data-nombre")) {
                    if ($(this).attr("data-nombre").includes("SimCtTotalD")) {
                        if ($(this).val().length > 0) {
                            totalTelas = totalTelas + parseFloat($(this).val().replace(",", "."));
                        }
                    }
                }
            }
        });

        $("#SimHcTotalConTelasD").val(totalCon.toString().replace(".", ","));
        $("#SimHcTotalTelasD").val(totalTelas.toString().replace(".", ","));
        $("#SimHcTotalTelasD").trigger("change");
    }
});

//FIN

//CALCULO EL TOTAL DE PROCESOS - NO APLICA FORMULACION DINAMICA

$(".SimPrCostoM").change(function () {
    var totalProcesos = 0;
    $('#tablaProcesos > tbody  > tr > td > input').each(function (index, value) {
        if ($(this).closest('tr').attr('style').includes("display: none") === false) {
            if ($(this).attr("data-nombre")) {
                if ($(this).attr("data-nombre").includes("SimPrCostoM")) {
                    if ($(this).val().length > 0) {
                        totalProcesos = totalProcesos + parseFloat($(this).val().replace(",", "."));
                    }
                }
            }
        }
    });

    $("#SimHcTotalProcesosD").val(totalProcesos.toString().replace(".", ","));
    $("#SimHcTotalProcesosD").trigger("change");
});

//FIN

//CALCULO EL TOTAL DE INSUMOS Y ACCESORIOS - NO APLICA FORMULACION DINAMICA

$(".SimIaCtsxMtD, .SimIaConF").change(function () {
    var valor_cts = $(this).parents("tr").find("td input")[2].value;
    var valor_con = $(this).parents("tr").find("td input")[3].value;

    if (valor_cts.length > 0 && valor_con.length > 0) {
        var total = parseFloat(valor_cts.replace(",", ".")) * parseFloat(valor_con.replace(",", "."));
        $(this).parents("tr").find("td input")[4].value = total.toString().replace(".", ",");

        var totalInsumos = 0;
        $('#tablaInsumos > tbody  > tr > td > input').each(function (index, value) {
            if ($(this).closest('tr').attr('style').includes("display: none") === false) {
                if ($(this).attr("data-nombre")) {
                    if ($(this).attr("data-nombre").includes("SimIaTotalD")) {
                        if ($(this).val().length > 0) {
                            totalInsumos = totalInsumos + parseFloat($(this).val().replace(",", "."));
                        }
                    }
                }
            }
        });

        $("#SimHcTotalInsumoD").val(totalInsumos.toString().replace(".", ","));
        $("#SimHcTotalInsumoD").trigger("change");
    }
});

//FIN

//CALCULO EL TOTAL DE MARQUILLAS, ETIQUETAS, EMPAQUES - NO APLICA FORMULACION DINAMICA

$(".SimEmeCtsxMtD, .SimEmeConF").change(function () {
    var valor_cts = $(this).parents("tr").find("td input")[1].value;
    var valor_con = $(this).parents("tr").find("td input")[2].value;

    if (valor_cts.length > 0 && valor_con.length > 0) {
        var total = parseFloat(valor_cts.replace(",", ".")) * parseFloat(valor_con.replace(",", "."));
        $(this).parents("tr").find("td input")[3].value = total.toString().replace(".", ",");

        var totalMarquillas = 0;
        $('#tablaMarquillas > tbody  > tr > td > input').each(function (index, value) {
            if ($(this).closest('tr').attr('style').includes("display: none") === false) {
                if ($(this).attr("data-nombre")) {
                    if ($(this).attr("data-nombre").includes("SimEmeTotalD")) {
                        if ($(this).val().length > 0) {
                            totalMarquillas = totalMarquillas + parseFloat($(this).val().replace(",", "."));
                        }
                    }
                }
            }
        });

        $("#SimHcTotalMarquillaD").val(totalMarquillas.toString().replace(".", ","));
        $("#SimHcTotalMarquillaD").trigger("change");
    }
});

//FIN

$("input[type='text']").change(function () {
    var id = $(this).attr("id").replace("Sim", "");
    //var formula = $("input[data-name='McCostoManoObraD']").data("formula");
    //if (formula.length > 0) {
    $("input[data-formula]").each(function (index, elemento) {
        //console.log("Indice: " + index);
        //console.log("atributo: " + $(this).attr("data-formula"));
        if ($(this).attr("data-formula").includes(id)) {
            //Abro Modal Loading
            $("#boModal").val("false");
            AbrirModal();

            /* EJECUTO LA FORMULA DEL PRIMER CAMPO DEPENDIENTE */

            var nombre_campo = $(this).attr("data-name");
            var split = $(this).attr("data-formula").split("|");
            var formula = $(this).attr("data-consulta");
            $.each(split, function (index, value) {
                if (value.includes("#")) {
                    var val_campo;
                    if (value.includes("Pp")) {
                        if (nombre_campo.includes("Real")) {
                            if ($(value + "_Real").length) {
                                val_campo = $(value + "_Real").val();
                            }
                            else {
                                val_campo = "0";
                            }
                        }
                        else {
                            if ($(value).length) {
                                val_campo = $(value).val();
                            }
                            else {
                                val_campo = "0";
                            }
                        }
                    }
                    else {
                        if ($(value.replace("#", "#Sim")).length) {
                            val_campo = $(value.replace("#", "#Sim")).val();
                        }
                        else {
                            val_campo = "0";
                        }
                    }
                    val_campo = val_campo.replace(",", ".");
                    formula = formula.replace(value.replace("#", ""), val_campo);
                }
            });

            //Ejecuto formula con los valores
            EjecutarFormula(formula, nombre_campo);

            console.log("dependencia 1");
            /* FIN */

            var id2 = $(this).data("name").replace("Sim", "");
            $("input[data-formula]").each(function (index, elemento) {
                if ($(this).attr("data-formula").includes(id2) && id2 !== "") {

                    /* EJECUTO LA FORMULA DEL SEGUNDO CAMPO DEPENDIENTE */
                    var nombre_campo = $(this).attr("data-name");
                    var split = $(this).attr("data-formula").split("|");
                    var formula = $(this).attr("data-consulta");
                    $.each(split, function (index, value) {
                        if (value.includes("#")) {
                            var val_campo;
                            if (value.includes("Pp")) {
                                if (nombre_campo.includes("Real")) {
                                    if ($(value + "_Real").length) {
                                        val_campo = $(value + "_Real").val();
                                    }
                                    else {
                                        val_campo = "0";
                                    }
                                }
                                else {
                                    if ($(value).length) {
                                        val_campo = $(value).val();
                                    }
                                    else {
                                        val_campo = "0";
                                    }
                                }
                            }
                            else {
                                if ($(value.replace("#", "#Sim")).length) {
                                    val_campo = $(value.replace("#", "#Sim")).val();
                                }
                                else {
                                    val_campo = "0";
                                }
                            }
                            val_campo = val_campo.replace(",", ".");
                            formula = formula.replace(value.replace("#", ""), val_campo);
                        }
                    });

                    //Ejecuto formula con los valores
                    EjecutarFormula(formula, nombre_campo);

                    console.log("dependencia 2");
                    /* FIN */

                    var id3 = $(this).data("name").replace("Sim", "");
                    $("input[data-formula]").each(function (index, elemento) {
                        if ($(this).attr("data-formula").includes(id3) && id3 !== "") {

                            /* EJECUTO LA FORMULA DEL TERCER CAMPO DEPENDIENTE */
                            var nombre_campo = $(this).attr("data-name");
                            var split = $(this).attr("data-formula").split("|");
                            var formula = $(this).attr("data-consulta");
                            $.each(split, function (index, value) {
                                if (value.includes("#")) {
                                    var val_campo;
                                    if (value.includes("Pp")) {
                                        if (nombre_campo.includes("Real")) {
                                            if ($(value + "_Real").length) {
                                                val_campo = $(value + "_Real").val();
                                            }
                                            else {
                                                val_campo = "0";
                                            }
                                        }
                                        else {
                                            if ($(value).length) {
                                                val_campo = $(value).val();
                                            }
                                            else {
                                                val_campo = "0";
                                            }
                                        }
                                    }
                                    else {
                                        if ($(value.replace("#", "#Sim")).length) {
                                            val_campo = $(value.replace("#", "#Sim")).val();
                                        }
                                        else {
                                            val_campo = "0";
                                        }
                                    }
                                    val_campo = val_campo.replace(",", ".");
                                    formula = formula.replace(value.replace("#", ""), val_campo);
                                }
                            });

                            //Ejecuto formula con los valores
                            EjecutarFormula(formula, nombre_campo);

                            console.log("dependencia 3");
                            /* FIN */

                            var id4 = $(this).data("name").replace("Sim", "");
                            $("input[data-formula]").each(function (index, elemento) {
                                if ($(this).attr("data-formula").includes(id4) && id4 !== "") {

                                    /* EJECUTO LA FORMULA DEL CUARTO CAMPO DEPENDIENTE */
                                    var nombre_campo = $(this).attr("data-name");
                                    var split = $(this).attr("data-formula").split("|");
                                    var formula = $(this).attr("data-consulta");
                                    $.each(split, function (index, value) {
                                        if (value.includes("#")) {
                                            var val_campo;
                                            if (value.includes("Pp")) {
                                                if (nombre_campo.includes("Real")) {
                                                    if ($(value + "_Real").length) {
                                                        val_campo = $(value + "_Real").val();
                                                    }
                                                    else {
                                                        val_campo = "0";
                                                    }
                                                }
                                                else {
                                                    if ($(value).length) {
                                                        val_campo = $(value).val();
                                                    }
                                                    else {
                                                        val_campo = "0";
                                                    }
                                                }
                                            }
                                            else {
                                                if ($(value.replace("#", "#Sim")).length) {
                                                    val_campo = $(value.replace("#", "#Sim")).val();
                                                }
                                                else {
                                                    val_campo = "0";
                                                }
                                            }
                                            val_campo = val_campo.replace(",", ".");
                                            formula = formula.replace(value.replace("#", ""), val_campo);
                                        }
                                    });

                                    //Ejecuto formula con los valores
                                    EjecutarFormula(formula, nombre_campo);

                                    console.log("dependencia 4");
                                    /* FIN */

                                    var id5 = $(this).data("name").replace("Sim", "");
                                    $("input[data-formula]").each(function (index, elemento) {
                                        if ($(this).attr("data-formula").includes(id5) && id5 !== "") {

                                            /* EJECUTO LA FORMULA DEL QUINTO CAMPO DEPENDIENTE */
                                            var nombre_campo = $(this).attr("data-name");
                                            var split = $(this).attr("data-formula").split("|");
                                            var formula = $(this).attr("data-consulta");
                                            $.each(split, function (index, value) {
                                                if (value.includes("#")) {
                                                    var val_campo;
                                                    if (value.includes("Pp")) {
                                                        if (nombre_campo.includes("Real")) {
                                                            if ($(value + "_Real").length) {
                                                                val_campo = $(value + "_Real").val();
                                                            }
                                                            else {
                                                                val_campo = "0";
                                                            }
                                                        }
                                                        else {
                                                            if ($(value).length) {
                                                                val_campo = $(value).val();
                                                            }
                                                            else {
                                                                val_campo = "0";
                                                            }
                                                        }
                                                    }
                                                    else {
                                                        if ($(value.replace("#", "#Sim")).length) {
                                                            val_campo = $(value.replace("#", "#Sim")).val();
                                                        }
                                                        else {
                                                            val_campo = "0";
                                                        }
                                                    }
                                                    val_campo = val_campo.replace(",", ".");
                                                    formula = formula.replace(value.replace("#", ""), val_campo);
                                                }
                                            });

                                            //Ejecuto formula con los valores
                                            EjecutarFormula(formula, nombre_campo);

                                            console.log("dependencia 5");
                                            /* FIN */

                                            var id6 = $(this).data("name").replace("Sim", "");
                                            $("input[data-formula]").each(function (index, elemento) {
                                                if ($(this).attr("data-formula").includes(id6) && id6 !== "") {

                                                    /* EJECUTO LA FORMULA DEL QUINTO CAMPO DEPENDIENTE */
                                                    var nombre_campo = $(this).attr("data-name");
                                                    var split = $(this).attr("data-formula").split("|");
                                                    var formula = $(this).attr("data-consulta");
                                                    $.each(split, function (index, value) {
                                                        if (value.includes("#")) {
                                                            var val_campo;
                                                            if (value.includes("Pp")) {
                                                                if (nombre_campo.includes("Real")) {
                                                                    if ($(value + "_Real").length) {
                                                                        val_campo = $(value + "_Real").val();
                                                                    }
                                                                    else {
                                                                        val_campo = "0";
                                                                    }
                                                                }
                                                                else {
                                                                    if ($(value).length) {
                                                                        val_campo = $(value).val();
                                                                    }
                                                                    else {
                                                                        val_campo = "0";
                                                                    }
                                                                }
                                                            }
                                                            else {
                                                                if ($(value.replace("#", "#Sim")).length) {
                                                                    val_campo = $(value.replace("#", "#Sim")).val();
                                                                }
                                                                else {
                                                                    val_campo = "0";
                                                                }
                                                            }
                                                            val_campo = val_campo.replace(",", ".");
                                                            formula = formula.replace(value.replace("#", ""), val_campo);
                                                        }
                                                    });

                                                    //Ejecuto formula con los valores
                                                    EjecutarFormula(formula, nombre_campo);

                                                    console.log("dependencia 6");
                                                    /* FIN */

                                                    var id7 = $(this).data("name").replace("Sim", "");
                                                    $("input[data-formula]").each(function (index, elemento) {
                                                        if ($(this).attr("data-formula").includes(id7) && id7 !== "") {

                                                            /* EJECUTO LA FORMULA DEL QUINTO CAMPO DEPENDIENTE */
                                                            var nombre_campo = $(this).attr("data-name");
                                                            var split = $(this).attr("data-formula").split("|");
                                                            var formula = $(this).attr("data-consulta");
                                                            $.each(split, function (index, value) {
                                                                if (value.includes("#")) {
                                                                    var val_campo;
                                                                    if (value.includes("Pp")) {
                                                                        if (nombre_campo.includes("Real")) {
                                                                            if ($(value + "_Real").length) {
                                                                                val_campo = $(value + "_Real").val();
                                                                            }
                                                                            else {
                                                                                val_campo = "0";
                                                                            }
                                                                        }
                                                                        else {
                                                                            if ($(value).length) {
                                                                                val_campo = $(value).val();
                                                                            }
                                                                            else {
                                                                                val_campo = "0";
                                                                            }
                                                                        }
                                                                    }
                                                                    else {
                                                                        if ($(value.replace("#", "#Sim")).length) {
                                                                            val_campo = $(value.replace("#", "#Sim")).val();
                                                                        }
                                                                        else {
                                                                            val_campo = "0";
                                                                        }
                                                                    }
                                                                    val_campo = val_campo.replace(",", ".");
                                                                    formula = formula.replace(value.replace("#", ""), val_campo);
                                                                }
                                                            });

                                                            //Ejecuto formula con los valores
                                                            EjecutarFormula(formula, nombre_campo);

                                                            console.log("dependencia 7");
                                                            /* FIN */

                                                            var id8 = $(this).data("name").replace("Sim", "");
                                                            $("input[data-formula]").each(function (index, elemento) {
                                                                if ($(this).attr("data-formula").includes(id8) && id8 !== "") {

                                                                    /* EJECUTO LA FORMULA DEL QUINTO CAMPO DEPENDIENTE */
                                                                    var nombre_campo = $(this).attr("data-name");
                                                                    var split = $(this).attr("data-formula").split("|");
                                                                    var formula = $(this).attr("data-consulta");
                                                                    $.each(split, function (index, value) {
                                                                        if (value.includes("#")) {
                                                                            var val_campo;
                                                                            if (value.includes("Pp")) {
                                                                                if (nombre_campo.includes("Real")) {
                                                                                    if ($(value + "_Real").length) {
                                                                                        val_campo = $(value + "_Real").val();
                                                                                    }
                                                                                    else {
                                                                                        val_campo = "0";
                                                                                    }
                                                                                }
                                                                                else {
                                                                                    if ($(value).length) {
                                                                                        val_campo = $(value).val();
                                                                                    }
                                                                                    else {
                                                                                        val_campo = "0";
                                                                                    }
                                                                                }
                                                                            }
                                                                            else {
                                                                                if ($(value.replace("#", "#Sim")).length) {
                                                                                    val_campo = $(value.replace("#", "#Sim")).val();
                                                                                }
                                                                                else {
                                                                                    val_campo = "0";
                                                                                }
                                                                            }
                                                                            val_campo = val_campo.replace(",", ".");
                                                                            formula = formula.replace(value.replace("#", ""), val_campo);
                                                                        }
                                                                    });

                                                                    //Ejecuto formula con los valores
                                                                    EjecutarFormula(formula, nombre_campo);

                                                                    console.log("dependencia 8");
                                                                    /* FIN */

                                                                }
                                                            });
                                                        }
                                                    });

                                                }
                                            });

                                        }
                                    });

                                }
                            });

                        }
                    });
                }
            });
        }
    });
    //Cierro loading
    //$('#modalLoading').modal("show").on('hide', function () {
    //    $('#modalLoading').modal('hide')
    //});
    $("#boModal").val("true");
});

//$('#modalLoading').on('hidden.bs.modal', function () {
//    alert('hidden event fired!');
//});

$('#modalLoading').on('shown.bs.modal', function () {
    if ($("#boModal").val() === "true") {
        $('#modalLoading').modal('hide');
    }
});

function AbrirModal() {
    $('#modalLoading').modal('show');
}

function EjecutarFormula(formula, nombre_campo) {
    formula = formula.replace("NaN", "0");
    var params = { formula: formula };
    $.ajax({
        url: '/HojaSimulada/EjecutarFormula',
        method: "post",
        data: params,
        success: function (result) {
            if (result.error !== undefined) {
                $.alert({
                    title: 'Error!',
                    content: result.mensaje
                });
            }
            else {
                if (nombre_campo.includes("ApMargenMaxBrutoRealF") || nombre_campo.includes("ApMargenMaxBrutoEstF") || nombre_campo.includes("ApMargenMaxOpeRealF") || nombre_campo.includes("ApMargenMaxOpeEstF")
                    || nombre_campo.includes("ApMargenMinBrutoEstF") || nombre_campo.includes("ApMargenMinBrutoRealF") || nombre_campo.includes("ApMargenMinOpeEstF") || nombre_campo.includes("ApMargenMinOpeRealF")) {
                    $("#Sim" + nombre_campo).val(Math.round(result.mensaje.replace(",", ".") * 100));
                }
                else if (nombre_campo.includes("HcTotalGastosEstD") || nombre_campo.includes("HcTotalGastosRealD") || nombre_campo.includes("HcTotalxCanalEstD") || nombre_campo.includes("HcTotalxCanalRealD")) {
                    $("#Sim" + nombre_campo).val(Math.round(result.mensaje.replace(",", ".")));
                }
                else {
                    var valor = result.mensaje.toString();
                    valor = valor.replace(".", ",");
                    $("#Sim" + nombre_campo).val(valor);
                }
            }
        },
        error: function (result) {
            $.alert({
                title: 'Error!',
                content: result.mensaje
            });
        },
        async: false
    });
}

$(document).ready(function () {
    //1. Add new row
    $("#addTelas").click(function (e) {
        e.preventDefault();
        var $tableBody = $("#tablaTelas");
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

        // Re-assign Validation
        //var form = $("form")
        //    .removeData("validator")
        //    .removeData("unobtrusiveValidation");
        //$.validator.unobtrusive(form);
    });

    $("#addProcesos").click(function (e) {
        e.preventDefault();
        var $tableBody = $("#tablaProcesos");
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

        // Re-assign Validation
        //var form = $("form")
        //    .removeData("validator")
        //    .removeData("unobtrusiveValidation");
        //$.validator.unobtrusive.parse(form);
    });

    $("#addInsumos").click(function (e) {
        e.preventDefault();
        var $tableBody = $("#tablaInsumos");
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

        // Re-assign Validation
        //var form = $("form")
        //    .removeData("validator")
        //    .removeData("unobtrusiveValidation");
        //$.validator.unobtrusive.parse(form);
    });

    $("#addMarquillas").click(function (e) {
        e.preventDefault();
        var $tableBody = $("#tablaMarquillas");
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

        // Re-assign Validation
        //var form = $("form")
        //    .removeData("validator")
        //    .removeData("unobtrusiveValidation");
        //$.validator.unobtrusive.parse(form);
    });

    $(document).on("click", ".remove", function (e) {
        e.preventDefault();
        $(this).parent().parent().children(".Borrado").val("true");
        $(this).parent().parent().hide();

        var id = $(this).closest('table').attr('id');
        if (id === "tablaTelas") {
            var totalTelas = 0;
            var totalCon = 0;
            $('#tablaTelas > tbody  > tr > td > input').each(function (index, value) {
                if ($(this).closest('tr').attr('style').includes("display: none") === false) {
                    if ($(this).attr("data-nombre")) {
                        if ($(this).attr("data-nombre").includes("SimCtConF")) {
                            if ($(this).val().length > 0) {
                                totalCon = totalCon + parseFloat($(this).val().replace(",", "."));
                            }
                        }
                    }
                    if ($(this).attr("data-nombre")) {
                        if ($(this).attr("data-nombre").includes("SimCtTotalD")) {
                            if ($(this).val().length > 0) {
                                totalTelas = totalTelas + parseFloat($(this).val().replace(",", "."));
                            }
                        }
                    }
                }
            });

            $("#SimHcTotalConTelasD").val(totalCon);
            $("#SimHcTotalTelasD").val(totalTelas);
            $("#SimHcTotalTelasD").trigger("change");
        }

        if (id === "tablaProcesos") {
            var totalProcesos = 0;
            $('#tablaProcesos > tbody  > tr > td > input').each(function (index, value) {
                if ($(this).closest('tr').attr('style').includes("display: none") === false) {
                    if ($(this).attr("data-nombre")) {
                        if ($(this).attr("data-nombre").includes("SimPrCostoM")) {
                            if ($(this).val().length > 0) {
                                totalProcesos = totalProcesos + parseFloat($(this).val().replace(",", "."));
                            }
                        }
                    }
                }
            });

            $("#SimHcTotalProcesosD").val(totalProcesos);
            $("#SimHcTotalProcesosD").trigger("change");
        }

        if (id === "tablaMarquillas") {
            var totalMarquillas = 0;
            $('#tablaMarquillas > tbody  > tr > td > input').each(function (index, value) {
                if ($(this).closest('tr').attr('style').includes("display: none") === false) {
                    if ($(this).attr("data-nombre")) {
                        if ($(this).attr("data-nombre").includes("SimEmeTotalD")) {
                            if ($(this).val().length > 0) {
                                totalMarquillas = totalMarquillas + parseFloat($(this).val().replace(",", "."));
                            }
                        }
                    }
                }
            });

            $("#SimHcTotalMarquillaD").val(totalMarquillas);
            $("#SimHcTotalMarquillaD").trigger("change");
        }

        if (id === "tablaInsumos") {
            var totalInsumos = 0;
            $('#tablaInsumos > tbody  > tr > td > input').each(function (index, value) {
                if ($(this).closest('tr').attr('style').includes("display: none") === false) {
                    if ($(this).attr("data-nombre")) {
                        if ($(this).attr("data-nombre").includes("SimIaTotalD")) {
                            if ($(this).val().length > 0) {
                                totalInsumos = totalInsumos + parseFloat($(this).val().replace(",", "."));
                            }
                        }
                    }
                }
            });

            $("#SimHcTotalInsumoD").val(totalInsumos);
            $("#SimHcTotalInsumoD").trigger("change");
        }

        //if ($(this).parent().parent().children(".SimCtCodigoN").val() != "" && $(this).parent().parent().children(".SimCtCodigoN").val() != null) {
        //    $(this).parent().parent().children(".Borrado").val("true");
        //    $(this).parent().parent().hide();
        //}
        //else if ($(this).parent().parent().children(".SimPrCodigoN").val() != "" && $(this).parent().parent().children(".SimPrCodigoN").val() != null) {
        //    $(this).parent().parent().children(".Borrado").val("true");
        //    $(this).parent().parent().hide();
        //}
        //else if ($(this).parent().parent().children(".SimIaCodigoN").val() != "" && $(this).parent().parent().children(".SimIaCodigoN").val() != null) {
        //    $(this).parent().parent().children(".Borrado").val("true");
        //    $(this).parent().parent().hide();
        //}
        //else if ($(this).parent().parent().children(".SimEmeCodigoN").val() != "" && $(this).parent().parent().children(".SimEmeCodigoN").val() != null) {
        //    $(this).parent().parent().children(".Borrado").val("true");
        //    $(this).parent().parent().hide();
        //}
        //else {
        //    $(this).parent().parent().remove();
        //}
    });
});