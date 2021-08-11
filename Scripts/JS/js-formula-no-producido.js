function guardarFormula(formula, codigo) {
    formula = '';
    $("#contenedor span").each(function () {
        if ($(this).attr("name") === "input") {
            formula = formula + "#" + $(this).attr("title") + "|";
        }
        else {
            formula = formula + "~" + $(this).attr("name") + "|";
        }
    });

    var params = { formula: formula, codigo: $("#codigo").val(), nombre: $("#nombre").val(), fecha: $("#fecha").val() };

    $.ajax({
        url: '/FormulaPNP/GuardarFormula',
        method: "post",
        data: params,
        success: function (result) {
            $.confirm({
                columnClass: 'xlarge',
                title: 'Proceso terminado',
                content: 'Proceso terminado la formula generada es: <br> ' + result.formula,
                buttons: {
                    OK: {
                        text: 'OK!',
                        action: function () {
                            document.location = '/FormulaPNP/Index';
                        }
                    }
                }
            });
        },
        error: function (result) {
            OnFailure(result.mensaje);
        },
        async: true
    });
}

function abrirFormula(formula, codigo, nombre, fecha) {
    $("#codigo").val(codigo);
    $("#nombre").val(nombre);
    $("#fecha").val(fecha);
    $("#formula_escrita").empty();
    $("#sortable").empty();
    $("#codigo_titulo").text("Formulador dinamico [" + nombre + "]");
    if (formula !== null && formula.length > 0) {
        var split = formula.split('|');
        $.each(split, function (index, value) {
            if (value.indexOf('~') !== -1) {
                if (value.replace('~', '') === "SI") { $('#sortable').append("<div class='soperaciones si'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
                else if (value.replace('~', '') === "ENTONCES") { $('#sortable').append("<div class='soperaciones si'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
                else if (value.replace('~', '') === "SINO") { $('#sortable').append("<div class='soperaciones si'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
                else if (value.replace('~', '') === "FIN SI") { $('#sortable').append("<div class='soperaciones si'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
                else if (value.replace('~', '') === "COCIENTE") { $('#sortable').append("<div class='soperaciones cociente'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
                else if (value.replace('~', '') === "FIN COCIENTE") { $('#sortable').append("<div class='soperaciones cociente'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
                else if (value.replace('~', '') === "RESIDUO") { $('#sortable').append("<div class='soperaciones residuo'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
                else if (value.replace('~', '') === "FIN RESIDUO") { $('#sortable').append("<div class='soperaciones residuo'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
                else if (value.replace('~', '') === "CONCATENAR") { $('#sortable').append("<div class='soperaciones concatenar'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
                else if (value.replace('~', '') === "FIN CONCATENAR") { $('#sortable').append("<div class='soperaciones concatenar'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
                else if (value.replace('~', '') === ":") { $('#sortable').append("<div class='soperaciones residuo'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
                else if (value.replace('~', '') === ";") { $('#sortable').append("<div class='soperaciones cociente'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
                else { $('#sortable').append("<div class='soperaciones'><span name='" + value.replace('~', '') + "' title='" + value.replace('~', '') + "' class='opt'>&nbsp;" + value.replace('~', '') + "&nbsp;</span></div>"); }
            }
            else {
                $('#sortable').append("<div class='scampos'><span name='input' title='" + value.replace('#', '') + "' class='opt'>&nbsp;" + value.replace('#', '') + "&nbsp;</span></div>");
            }
        });
    }

    agrupar_campos_formula();
    abrir_formulas_dinamicas();
    abrirModal();
}

$(function () {
    var removeIntent = false;
    $("#sortable").sortable({
        revert: false,
        update: function (event, ui) {
            $("#contenedor span").each(function () {
                if ($(this).attr("name") === "input") {
                    $(this).text($(this).attr("title"));
                }
            });
        },
        over: function () {
            removeIntent = false;
        },
        out: function (event, ui) {
            removeIntent = true;
        },
        beforeStop: function (event, ui) {
            if (removeIntent === true) {
                ui.item.remove();
            }
        }
    });
    $("#campos div").draggable({
        connectToSortable: "#sortable",
        helper: "clone",
        revert: "invalid"
    });
    $("#operaciones div").draggable({
        connectToSortable: "#sortable",
        helper: "clone",
        revert: "invalid"
    });
    $("div").disableSelection();
});

function probarFormula() {
    $("#formula_escrita").empty();
    $("#contenedor span").each(function () {
        if ($(this).attr("name") === "input") {
            $("#formula_escrita").append("<input type='text' name='input' class='form-control tamano opt' style='text-align:left' />");
        }
        else {
            $("#formula_escrita").append("<span style='text-align:left' name='" + $(this).attr("name") + "' class='tamano_span opt'>" + $(this).text() + "<span/>");
        }
    });
}

function ejecutarFormula() {
    var formula = '';
    $("#formula_escrita .opt").each(function () {
        if ($(this).attr("name") === "input") {
            formula = formula + "#" + $(this).val() + "|";
        }
        else {
            formula = formula + "~" + $(this).attr("name") + "|";
        }
    });

    var params = { formula: formula };

    $.ajax({
        url: '/FormulaPNP/EjecutarFormula',
        method: "post",
        data: params,
        success: function (result) {
            if (typeof result.error !== "undefined") {
                $.alert({
                    title: 'Error!',
                    content: result.mensaje
                });
            }
            else {
                $.alert({
                    title: 'Resultado!',
                    content: 'El valor obtenido de la formulada creada es: ' + result.mensaje
                });
            }
        },
        error: function (result) {
            $.alert({
                title: 'Error!',
                content: result.mensaje
            });
        },
        async: true
    });
}

function abrirModal() {
    $('#modalFormulas').modal('show');
}

function abrir_formulas_dinamicas() {
    $('#page_tbl_formulas').addClass("hidden_page");
    $('#page_formulas_dinamicas').removeClass("hidden_page");
}

function abrir_tabla_formulas() {
    $('#page_formulas_dinamicas').addClass("hidden_page");
    $('#page_tbl_formulas').removeClass("hidden_page");
}

function agrupar_campos_formula() {

    $(".analisis-precio").appendTo("#seccion_analisis_precio");
    $(".otros").appendTo("#seccion_otros");
    $(".costos-produccion").appendTo("#seccion_costos_produccion");
    $(".resumen-distribucion").appendTo("#seccion_resumen_distribucion");

}

function ver_formulas(id) {

    if (id === "view_analisis_precio") {
        $("#seccion_analisis_precio").toggle("slow");
        $("#menos_uno").toggle();
        $("#mas_uno").toggle();
    }
    else if (id === "view_resumen_distribucion") {
        $("#seccion_resumen_distribucion").toggle("slow");
        $("#menos_dos").toggle();
        $("#mas_dos").toggle();
    }
    else if (id === "view_costos_produccion") {
        $("#seccion_costos_produccion").toggle("slow");
        $("#menos_tres").toggle();
        $("#mas_tres").toggle();
    }
    else if (id === "view_otros") {
        $("#seccion_otros").toggle("slow");
        $("#menos_cuatro").toggle();
        $("#mas_cuatro").toggle();
    }
}