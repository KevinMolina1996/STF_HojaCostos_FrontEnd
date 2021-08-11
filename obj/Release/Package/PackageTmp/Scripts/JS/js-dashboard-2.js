var tablaProducido;
var tablaPrecosteo;
var tablaNoProducido;

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

    FiltroMarca();
    $("#Marca").combobox({ select: function (event, ui) { FiltroColeccion();/*alert(ui.item.value);*/ } });
    $("#Coleccion").combobox({ select: function (event, ui) { FiltroLinea();/*alert(ui.item.value);*/ } });
    $("#Linea").combobox({ select: function (event, ui) { FiltroSublinea();/*alert(ui.item.value);*/ } });
    $("#Sublinea").combobox({ select: function (event, ui) { /*alert(ui.item.value);*/ } });

    //Precosteo
    FiltroMarcaPrecosteo();
    $("#MarcaPrecosteo").combobox({ select: function (event, ui) { FiltroColeccionPrecosteo();/*alert(ui.item.value);*/ } });
    $("#ColeccionPrecosteo").combobox({ select: function (event, ui) { FiltroLineaPrecosteo();/*alert(ui.item.value);*/ } });
    $("#LineaPrecosteo").combobox({ select: function (event, ui) { FiltroSublineaPrecosteo();/*alert(ui.item.value);*/ } });
    $("#SublineaPrecosteo").combobox({ select: function (event, ui) { /*alert(ui.item.value);*/ } });

    //No producido
    FiltroMarcaNoProducido();
    $("#MarcaNoProducido").combobox({ select: function (event, ui) { FiltroColeccionNoProducido();/*alert(ui.item.value);*/ } });
    $("#ColeccionNoProducido").combobox({ select: function (event, ui) { FiltroLineaNoProducido();/*alert(ui.item.value);*/ } });
    $("#LineaNoProducido").combobox({ select: function (event, ui) { FiltroSublineaNoProducido();/*alert(ui.item.value);*/ } });
    $("#SublineaNoProducido").combobox({ select: function (event, ui) { /*alert(ui.item.value);*/ } });
});

//Producido
function FiltroMarca() {
    $.ajax({
        url: '/DashBoardLvl2/FiltroMarca',
        type: "POST",
        dataType: "JSON",
        data: {},
        success: function (marcas) {
            $("#Marca").html(""); // clear before appending new list
            $.each(marcas, function (i, marcas) {
                $("#Marca").append(
                    $('<option></option>').val(marcas).html(marcas));
            });
        }
    });
}
function FiltroColeccion() {
    var marca = $('#Marca').val();
    $.ajax({
        url: '/DashBoardLvl2/FiltroColeccion',
        type: "POST",
        dataType: "JSON",
        data: { Marca: marca },
        success: function (colecciones) {
            $("#Coleccion").html(""); // clear before appending new list
            $.each(colecciones, function (i, colecciones) {
                $("#Coleccion").append(
                    $('<option></option>').val(colecciones).html(colecciones));
            });
        }
    });
}
function FiltroLinea() {
    var marca = $('#Marca').val();
    var col = $('#Coleccion').val();
    $.ajax({
        url: '/DashBoardLvl2/FiltroLinea',
        type: "POST",
        dataType: "JSON",
        data: { Marca: marca, Coleccion: col },
        success: function (lineas) {
            $("#Linea").html(""); // clear before appending new list
            $.each(lineas, function (i, lineas) {
                $("#Linea").append(
                    $('<option></option>').val(lineas).html(lineas));
            });
        }
    });
}
function FiltroSublinea() {
    var marca = $('#Marca').val();
    var col = $('#Coleccion').val();
    var lin = $('#Linea').val();
    $.ajax({
        url: '/DashBoardLvl2/FiltroSublinea',
        type: "POST",
        dataType: "JSON",
        data: { Marca: marca, Coleccion: col, Linea: lin },
        success: function (sublineas) {
            $("#Sublinea").html(""); // clear before appending new list
            $.each(sublineas, function (i, sublineas) {
                $("#Sublinea").append(
                    $('<option></option>').val(sublineas).html(sublineas));
            });
        }
    });
}

//Precosteo
function FiltroMarcaPrecosteo() {
    $.ajax({
        url: '/DashBoardLvl2/FiltroMarcaPrecosteo',
        type: "POST",
        dataType: "JSON",
        data: {},
        success: function (marcas) {
            $("#MarcaPrecosteo").html(""); // clear before appending new list
            $.each(marcas, function (i, marcas) {
                $("#MarcaPrecosteo").append(
                    $('<option></option>').val(marcas).html(marcas));
            });
        }
    });
}
function FiltroColeccionPrecosteo() {
    var marca = $('#MarcaPrecosteo').val();
    $.ajax({
        url: '/DashBoardLvl2/FiltroColeccionPrecosteo',
        type: "POST",
        dataType: "JSON",
        data: { Marca: marca },
        success: function (colecciones) {
            $("#ColeccionPrecosteo").html(""); // clear before appending new list
            $.each(colecciones, function (i, colecciones) {
                $("#ColeccionPrecosteo").append(
                    $('<option></option>').val(colecciones).html(colecciones));
            });
        }
    });
}
function FiltroLineaPrecosteo() {
    var marca = $('#MarcaPrecosteo').val();
    var col = $('#ColeccionPrecosteo').val();
    $.ajax({
        url: '/DashBoardLvl2/FiltroLineaPrecosteo',
        type: "POST",
        dataType: "JSON",
        data: { Marca: marca, Coleccion: col },
        success: function (lineas) {
            $("#LineaPrecosteo").html(""); // clear before appending new list
            $.each(lineas, function (i, lineas) {
                $("#LineaPrecosteo").append(
                    $('<option></option>').val(lineas).html(lineas));
            });
        }
    });
}
function FiltroSublineaPrecosteo() {
    var marca = $('#MarcaPrecosteo').val();
    var col = $('#ColeccionPrecosteo').val();
    var lin = $('#LineaPrecosteo').val();
    $.ajax({
        url: '/DashBoardLvl2/FiltroSublineaPrecosteo',
        type: "POST",
        dataType: "JSON",
        data: { Marca: marca, Coleccion: col, Linea: lin },
        success: function (sublineas) {
            $("#SublineaPrecosteo").html(""); // clear before appending new list
            $.each(sublineas, function (i, sublineas) {
                $("#SublineaPrecosteo").append(
                    $('<option></option>').val(sublineas).html(sublineas));
            });
        }
    });
}

function FiltroMarcaNoProducido() {
    $.ajax({
        url: '/DashBoardLvl2/FiltroMarcaNoProducido',
        type: "POST",
        dataType: "JSON",
        data: {},
        success: function (marcas) {
            $("#MarcaNoProducido").html(""); // clear before appending new list
            $.each(marcas, function (i, marcas) {
                $("#MarcaNoProducido").append(
                    $('<option></option>').val(marcas).html(marcas));
            });
        }
    });
}
function FiltroColeccionNoProducido() {
    var marca = $('#MarcaNoProducido').val();
    $.ajax({
        url: '/DashBoardLvl2/FiltroColeccionNoProducido',
        type: "POST",
        dataType: "JSON",
        data: { Marca: marca },
        success: function (colecciones) {
            $("#ColeccionNoProducido").html(""); // clear before appending new list
            $.each(colecciones, function (i, colecciones) {
                $("#ColeccionNoProducido").append(
                    $('<option></option>').val(colecciones).html(colecciones));
            });
        }
    });
}
function FiltroLineaNoProducido() {
    var marca = $('#MarcaNoProducido').val();
    var col = $('#ColeccionNoProducido').val();
    $.ajax({
        url: '/DashBoardLvl2/FiltroLineaNoProducido',
        type: "POST",
        dataType: "JSON",
        data: { Marca: marca, Coleccion: col },
        success: function (lineas) {
            $("#LineaNoProducido").html(""); // clear before appending new list
            $.each(lineas, function (i, lineas) {
                $("#LineaNoProducido").append(
                    $('<option></option>').val(lineas).html(lineas));
            });
        }
    });
}
function FiltroSublineaNoProducido() {
    var marca = $('#MarcaNoProducido').val();
    var col = $('#ColeccionNoProducido').val();
    var lin = $('#LineaNoProducido').val();
    $.ajax({
        url: '/DashBoardLvl2/FiltroSublineaNoProducido',
        type: "POST",
        dataType: "JSON",
        data: { Marca: marca, Coleccion: col, Linea: lin },
        success: function (sublineas) {
            $("#SublineaNoProducido").html(""); // clear before appending new list
            $.each(sublineas, function (i, sublineas) {
                $("#SublineaNoProducido").append(
                    $('<option></option>').val(sublineas).html(sublineas));
            });
        }
    });
}

function successProducido(response) {
    var mensaje = response.mensaje;
    if (mensaje !== null && mensaje.length > 0) {
        alerta("Error!", mensaje_warning);
    }
    else {
        $('#producido').html(response.PartialView);
        $("#tablaProducido tr td").each(function () {
            if ($(this).text() === "PENDIENTE") {
                $(this).addClass("pendiente");
            }
        });
        tablaProducido = $('#tablaProducido').DataTable({
            responsive: true,
            paging: true,
            ordering: true,
            info: true,
            searching: true,
            dom: 'frtipB',
            buttons: [
                { 'extend': 'excel', "className": 'btn btn-sm btn-dark' }
            ]
        });
    }
}
function successPrecosteo(response) {
    var mensaje = response.mensaje;
    if (mensaje !== null && mensaje.length > 0) {
        alerta("Error!", mensaje_warning);
    }
    else {
        $('#precosteo').html(response.PartialView);
        $("#tablaPrecosteo tr td").each(function () {
            if ($(this).text() === "PENDIENTE") {
                $(this).addClass("pendiente");
            }
        });
        tablaPrecosteo = $('#tablaPrecosteo').DataTable({
            responsive: true,
            paging: true,
            ordering: true,
            info: true,
            searching: true,
            dom: 'frtipB',
            buttons: [
                { 'extend': 'excel', "className": 'btn btn-sm btn-dark' }
            ]
        });
    }
}
function successNoProducido(response) {
    var mensaje = response.mensaje;
    if (mensaje !== null && mensaje.length > 0) {
        alerta("Error!", mensaje_warning);
    }
    else {
        $('#noproducido').html(response.PartialView);
        $("#tablaNoProducido tr td").each(function () {
            if ($(this).text() === "PENDIENTE") {
                $(this).addClass("pendiente");
            }
        });
        tablaNoProducido = $('#tablaNoProducido').DataTable({
            responsive: true,
            paging: true,
            ordering: true,
            info: true,
            searching: true,
            dom: 'frtipB',
            buttons: [
                { 'extend': 'excel', "className": 'btn btn-sm btn-dark' }
            ]
        });
    }
}

$('#btnLimpiarProducido').click(function () {
    $("#panelProducido input").val("");
    if (tablaProducido !== undefined) {
        tablaProducido.clear().draw();
    }
});

$('#btnLimpiarPrecosteo').click(function () {
    $("#panelPrecosteo input").val("");
    if (tablaPrecosteo !== undefined) {
        tablaPrecosteo.clear().draw();
    }
});

$('#btnLimpiarNoProducido').click(function () {
    $("#panelNoProducido input").val("");
    if (tablaNoProducido !== undefined) {
        tablaNoProducido.clear().draw();
    }
});