$(document).ready(function () {
    $('#Contenedor input').prop("disabled", true);
    $('#btnActualizar').prop("disabled", true);
    $('#btnCrear').prop("disabled", true);
    ocultarTabs();
});

$('#btnLimpiar').click(function () {
    document.location = '/ParametrosPre/Consulta';
});

$('#btnNuevo').click(function () {
    $('#btnCargar').prop("disabled", false);
    $('#btnActualizar').prop("disabled", true);
    $('#btnCrear').prop("disabled", false);
    $('#Contenedor input').prop("disabled", false);
});

function successsAjax(response) {
    $('#myform').html(response.PartialView);
    var mensaje = response.mensaje;
    var mensaje_warning = response.mensaje_warning;
    if (mensaje !== undefined) {
        ocultarTabs();
        alerta("Información!", mensaje);
    }
    if (mensaje_warning !== undefined) {
        ocultarTabs();
        alerta("Error!", mensaje_warning);
    }

    var input = $('.input-validation-error:first');

    if (input) {
        input.focus();
    }
}

function successsAjaxOK(response) {
    $('#myform').html(response.PartialView);
    var mensaje = response.mensaje;
    var mensaje_warning = response.mensaje_warning;
    if (mensaje !== undefined) {
        ocultarTabs();
        alerta_ok("Información!", mensaje);
    }
    if (mensaje_warning !== undefined) {
        ocultarTabs();
        alerta("Error!", mensaje_warning);
    }

    var input = $('.input-validation-error:first');

    if (input) {
        input.focus();
    }
}

function refrescarFrame() {
    $("#btnConsultar").trigger("click");
}

function ocultarTabs() {
    if ($('#Tipo option:selected').val() === "") {
        console.log("");
    }
    if ($('#Tipo option:selected').val() === "FR") {
        $('#generales').hide();
        $('#piramide').hide();
    }
    if ($('#Tipo option:selected').val() === "FE") {
        $('#generales').show();
        $('#piramide').show();
    }
}

function Crear() {
    if ($("#PreFactorTelaF").attr('disabled') === "disabled") {
        $('#Contenedor input').prop("disabled", false);
        return;
    }
    if ($('#Tipo option:selected').val() === "") {
        alerta("Información!", "Debe seleccionar un tipo");
        return;
    }
    var data = $('form').serialize(); // or use the id of the form is you have given it one
    $.ajax({
        type: 'POST',
        cache: false,
        url: '/ParametrosPre/Crear',
        data: data,
        success: function (data, textStatus, jqXHR) {
            successsAjaxOK(data);
        }
    });
}

$('#ver-todo-marcas').click(function () {
    $('#marca').trigger("focus"); //or "click", at least one should work
    $('#marca').autocomplete("search");
});

$('#ver-todo-coleccion').click(function () {
    $('#coleccion').trigger("focus"); //or "click", at least one should work
    $('#coleccion').autocomplete("search");
});

$('#ver-todo-linea').click(function () {
    $('#linea').trigger("focus"); //or "click", at least one should work
    $('#linea').autocomplete("search");
});

$('#ver-todo-sublinea').click(function () {
    $('#sublinea').trigger("focus"); //or "click", at least one should work
    $('#sublinea').autocomplete("search");
});

function FiltroMarca() {
    ocultarTabs();
    var tipo = $('#Tipo').val();
    $.ajax({
        url: '/ParametrosPre/FiltroMarca',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo },
        success: function (marcas) {
            //$("#Marca").html(""); // clear before appending new list
            $("#marca").autocomplete({
                source: marcas,
                minLength: 0,
                select: function (event, ui) {
                    $.ajax({
                        url: '/ParametrosPre/FiltroColeccion',
                        type: "POST",
                        dataType: "JSON",
                        data: { Tipo: tipo, Marca: ui.item.label },
                        success: function (colecciones) {
                            $("#coleccion").autocomplete({
                                source: colecciones,
                                minLength: 0,
                                select: function (event, ui) {
                                    $.ajax({
                                        url: '/ParametrosPre/FiltroLinea',
                                        type: "POST",
                                        dataType: "JSON",
                                        data: { Tipo: tipo, Marca: $("#marca").val(), Coleccion: ui.item.label },
                                        success: function (lineas) {

                                            $("#linea").autocomplete({
                                                source: lineas,
                                                minLength: 0,
                                                select: function (event, ui) {

                                                    $("#sublinea").val("");
                                                    $.ajax({
                                                        url: '/ParametrosPre/FiltroSublinea',
                                                        type: "POST",
                                                        dataType: "JSON",
                                                        data: { Tipo: tipo, Marca: $("#marca").val(), Coleccion: $("#coleccion").val(), Linea: ui.item.label },
                                                        success: function (sublineas) {
                                                            $("#sublinea").autocomplete({
                                                                source: sublineas,
                                                                minLength: 0,
                                                                select: function (event, ui) {

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
}
function FiltroColeccion() {
    var tipo = $('#Tipo').val();
    var marca = $('#marca').val();
    $.ajax({
        url: '/ParametrosPre/FiltroColeccion',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo, Marca: marca },
        success: function (colecciones) {
            //$("#Coleccion").html(""); // clear before appending new list

            $("#coleccion").autocomplete({
                source: colecciones,
                minLength: 0,
                select: function (event, ui) {
                    FiltroLinea();
                }
            });

            //$.each(colecciones, function (i, colecciones) {
            //    $("#Coleccion").append(
            //        $('<option></option>').val(colecciones).html(colecciones));
            //});
        }
    });
}
function FiltroLinea() {
    var tipo = $('#Tipo').val();
    var marca = $('#marca').val();
    var col = $('#coleccion').val();
    $.ajax({
        url: '/ParametrosPre/FiltroLinea',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo, Marca: marca, Coleccion: col },
        success: function (lineas) {
            $("#linea").autocomplete({
                source: lineas,
                minLength: 0,
                select: function (event, ui) {
                    $("#sublinea").val("");
                    FiltroSublinea(ui.item.label);
                }
            });
        }
    });
}
function FiltroSublinea(linea) {
    var tipo = $('#Tipo').val();
    var marca = $('#marca').val();
    var col = $('#coleccion').val();
    var lin = $('#linea').val();
    if (linea !== 'undefined') {
        lin = linea;
    }
    $.ajax({
        url: '/ParametrosPre/FiltroSublinea',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo, Marca: marca, Coleccion: col, Linea: lin },
        success: function (sublineas) {
            $("#sublinea").autocomplete({
                source: sublineas,
                minLength: 0,
                select: function (event, ui) {

                }
            });
        }
    });
}