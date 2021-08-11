$(document).ready(function () {
    $('#Contenedor input').prop("disabled", true);
    $('#btnActualizar').prop("disabled", true);
    //ocultarTabs();
});

$('#btnLimpiar').click(function () {
    document.location = '/ParametrosPnp/Index';
});

$('#btnNuevo').click(function () {
    $('#btnCargar').prop("disabled", false);
    $('#btnActualizar').prop("disabled", true);
    $('#btnCrear').prop("disabled", false);
    $('#Contenedor input').prop("disabled", false);
});

$(function () {
    $.widget("custom.combobox", {
        select: function (event, ui) { alert(ui.item.value); },
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input required>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                //.addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .addClass("form-control")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source")
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {
            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")
                .tooltip()
                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("ui-button ui-widget ui-button-icon-only custom-combobox-toggle ui-corner-right ref")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });

            $(".ref").append("<span class='ui-button-icon ui-icon ui-icon-triangle-1-s'></span>");

        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {
                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;
            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {
                return;
            }

            // Remove invalid value
            this.input
                .val("")
                .attr("title", value + " didn't match any item")
                .tooltip("open");
            this.element.val("");
            this._delay(function () {
                this.input.tooltip("close").attr("title", "");
            }, 2500);
            this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    $("#Marca").combobox({ select: function (event, ui) { FiltroColeccion();/*alert(ui.item.value);*/ } });
    $("#Coleccion").combobox({ select: function (event, ui) { FiltroLinea();/*alert(ui.item.value);*/ } });
    $("#Linea").combobox({ select: function (event, ui) { FiltroSublinea();/*alert(ui.item.value);*/ } });
    $("#Sublinea").combobox({ select: function (event, ui) { /*alert(ui.item.value);*/ } });
});

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

function successsAjax(response) {
    $('#myform').html(response.PartialView);
    var mensaje = response.mensaje;
    var mensaje_warning = response.mensaje_warning;
    if (mensaje !== null && mensaje.length > 0) {
        //ocultarTabs();
        alerta("Información!", mensaje);
    }
    if (mensaje_warning !== null && mensaje_warning.length > 0) {
        //ocultarTabs();
        alerta("Error!", mensaje_warning);
    }

    var input = $('.input-validation-error:first');

    if (input) {
        input.focus();
    }
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
    var data = $('form').serialize(); // or use the id of the form is you have given it one
    $.ajax({
        type: 'POST',
        cache: false,
        url: '/ParametrosPnp/Crear',
        data: data,
        success: function (data, textStatus, jqXHR) {
            successsAjax(data);
        }
    });
}

function FiltroMarca() {
    ocultarTabs();
    var tipo = $('#Tipo').val();
    $.ajax({
        url: '/ParametrosPnp/FiltroMarca',
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
                        url: '/ParametrosPnp/FiltroColeccion',
                        type: "POST",
                        dataType: "JSON",
                        data: { Tipo: tipo, Marca: ui.item.label },
                        success: function (colecciones) {
                            $("#coleccion").autocomplete({
                                source: colecciones,
                                minLength: 0,
                                select: function (event, ui) {
                                    $.ajax({
                                        url: '/ParametrosPnp/FiltroLinea',
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
                                                        url: '/ParametrosPnp/FiltroSublinea',
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
        url: '/ParametrosPnp/FiltroColeccion',
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
        url: '/ParametrosPnp/FiltroLinea',
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
        url: '/ParametrosPnp/FiltroSublinea',
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