var table = $('#table').DataTable({
    buttons: [
        'selectAll',
        'selectNone'
    ],
    'columnDefs': [
        {
            'targets': 0,
            'checkboxes': {
                'selectRow': true
            }
        }
    ],
    language: {
        buttons: {
            selectAll: "Select all items",
            selectNone: "Select none"
        }
    }
});

$('#Exportar').click(function (e) {
    e.preventDefault();

    var rows_selected = table.column(0).checkboxes.selected();
    var ref = "";

    $.each(rows_selected, function (index, rowId) {
        // Create a hidden element 
        ref = ref + rowId + "|";
    });

    $('#Referencias').val(ref);

    $.confirm({
        title: 'Confirmar!',
        content: 'Seleccione la operación a realizar!',
        buttons: {
            PDF: function () {
                var ref = $('#Referencias').val();
                if (ref.length > 0) {
                    var action = "ExportPDF";
                    $("#FrmMasiva").attr("action", action);
                    $("#FrmMasiva").submit();
                }
                else {
                    alerta("Alerta", "Debe seleccionar registros");
                }
            },
            EXCEL: function () {
                var ref = $('#Referencias').val();
                if (ref.length > 0) {
                    var action = "ExportExcel";
                    $("#FrmMasiva").attr("action", action);
                    $("#FrmMasiva").submit();
                }
                else {
                    alerta("Alerta", "Debe seleccionar registros");
                }
            },
            CANCELAR: function () {

            }
        }
    });
});

$('#Imprimir').click(function (e) {
    e.preventDefault();

    var rows_selected = table.column(0).checkboxes.selected();
    var ref = "";

    $.each(rows_selected, function (index, rowId) {
        // Create a hidden element 
        ref = ref + rowId + "|";
    });

    $('#Referencias').val(ref);

    $.confirm({
        title: 'Confirmar!',
        content: 'Desea continuar con el proceso?!',
        buttons: {
            CONFIRMAR: function () {
                var ref = $('#Referencias').val();
                if (ref.length > 0) {
                    var action = "GenerarPdf";
                    $("#FrmMasiva").attr("action", action);
                    $("#FrmMasiva").submit();
                }
                else {
                    alerta("Alerta", "Debe seleccionar registros");
                }
            },
            CANCELAR: function () {

            }
        }
    });
});

$('#Cerrar').click(function (e) {
    e.preventDefault();

    var rows_selected = table.column(0).checkboxes.selected();
    var ref = "";

    $.each(rows_selected, function (index, rowId) {
        // Create a hidden element 
        ref = ref + rowId + "|";
    });

    $('#Referencias').val(ref);

    $.confirm({
        title: 'Confirmar!',
        content: 'Desea continuar con el proceso?!',
        buttons: {
            CONFIRMAR: function () {
                var ref = $('#Referencias').val();
                if (ref.length > 0) {
                    var action = "CerrarHojas";
                    $("#FrmMasiva").attr("action", action);
                    $("#FrmMasiva").submit();
                }
                else {
                    alerta("Alerta", "Debe seleccionar registros");
                }
            },
            CANCELAR: function () {

            }
        }
    });
});

$(document).ready(function () {
    //FiltroRef();
    //FiltroMarca();
    //FiltroColeccion();
    //FiltroLinea();
    //FiltroEstado();
    $("#Exportar").prop('disabled', false);
    $("#Imprimir").prop('disabled', false);
    $("#Cerrar").prop('disabled', false);
});

function FiltroRef() {
    var tipo = $('#TipoCab').val();
    $.ajax({
        url: '/HojaCostoPN/FiltroRef',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo },
        success: function (refs) {

            $("#Referencia").autocomplete({
                source: refs,
                minLength: 3,
                select: function (event, ui) {

                }
            });
        }
    });
}

function FiltroMarca() {
    var tipo = $('#Tipo').val();
    $.ajax({
        url: '/HojaCostoPN/FiltroMarca',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo },
        success: function (marcas) {
            //$("#Marca").html(""); // clear before appending new list
            $("#marca").autocomplete({
                source: marcas,
                minLength: 3,
                select: function (event, ui) {
                    $.ajax({
                        url: '/HojaCostoPN/FiltroColeccion',
                        type: "POST",
                        dataType: "JSON",
                        data: { Tipo: tipo, Marca: ui.item.label },
                        success: function (colecciones) {
                            $("#coleccion").autocomplete({
                                source: colecciones,
                                minLength: 3,
                                select: function (event, ui) {
                                    $.ajax({
                                        url: '/HojaCostoPN/FiltroLinea',
                                        type: "POST",
                                        dataType: "JSON",
                                        data: { Tipo: tipo, Marca: $("#marca").val(), Coleccion: ui.item.label },
                                        success: function (lineas) {
                                            $("#linea").autocomplete({
                                                source: lineas,
                                                minLength: 3,
                                                select: function (event, ui) {
                                                    $.ajax({
                                                        url: '/HojaCostoPN/FiltroEstadoCierre',
                                                        type: "POST",
                                                        dataType: "JSON",
                                                        data: { Tipo: tipo, Marca: $("#marca").val(), Coleccion: $("#coleccion").val(), Linea: ui.item.label },
                                                        success: function (estado) {
                                                            $("#estado").autocomplete({
                                                                source: estado,
                                                                minLength: 3,
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

function FiltroMarca2() {
    var tipo = $('#Tipo').val();
    $.ajax({
        url: '/HojaCostoPN/FiltroMarca',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo },
        success: function (marcas) {
            //$("#Marca").html(""); // clear before appending new list
            $("#marca").autocomplete({
                source: marcas,
                minLength: 3,
                select: function (event, ui) {
                    FiltroColeccion();
                }
            });
        }
    });
}

function FiltroColeccion() {
    var tipo = $('#Tipo').val();
    var marca = $('#marca').val();
    $.ajax({
        url: '/HojaCostoPN/FiltroColeccion',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo, Marca: marca },
        success: function (colecciones) {
            //$("#Coleccion").html(""); // clear before appending new list

            $("#coleccion").autocomplete({
                source: colecciones,
                minLength: 3,
                select: function (event, ui) {
                    FiltroLinea(ui.item.label);
                }
            });
        }
    });
}

function FiltroLinea(col) {
    var tipo = $('#Tipo').val();
    var marca = $('#marca').val();

    if (col === "") {
        col = $('#coleccion').val();
    }

    $.ajax({
        url: '/HojaCostoPN/FiltroLinea',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo, Marca: marca, Coleccion: col },
        success: function (lineas) {
            $("#linea").autocomplete({
                source: lineas,
                minLength: 3,
                select: function (event, ui) {
                    FiltroEstado(ui.item.label);
                }
            });
        }
    });
}

function FiltroEstado(linea) {
    var tipo = $('#Tipo').val();
    var marca = $('#marca').val();
    var col = $('#coleccion').val();

    if (linea === "") {
        linea = $('#linea').val();
    }

    $.ajax({
        url: '/HojaCostoPN/FiltroEstadoCierre',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo, Marca: marca, Coleccion: col, Linea: linea },
        success: function (estado) {
            $("#estado").autocomplete({
                source: estado,
                minLength: 3,
                select: function (event, ui) {

                }
            });
        }
    });
}

$('#btnLimpiar').click(function () {
    document.location = '/HojaCostoPN/Index';
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

$('#ver-todo-estado').click(function () {
    $('#estado').trigger("focus"); //or "click", at least one should work
    $('#estado').autocomplete("search");
});

$('#ver-todo-ref').click(function () {
    $('#Referencia').trigger("focus"); //or "click", at least one should work
    $('#Referencia').autocomplete("search");
});