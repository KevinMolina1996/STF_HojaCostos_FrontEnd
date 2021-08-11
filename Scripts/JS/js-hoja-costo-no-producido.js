function SeleccionRef(Checkbox, Referencia) {
    if ($('#Referencias').val().length > 0) {
        var ref = $('#Referencias').val();
        ref = ref.replace(Referencia + "|", "");

        if (Checkbox.checked) {
            ref = ref + Referencia + "|";
        }
        $('#Referencias').val(ref);
    }
    else {
        if (Checkbox.checked) {
            $('#Referencias').val(Referencia + "|");
        }
    }
}

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

$('#btnLimpiar').click(function () {
    document.location = '/HojaCostoPNP/Index';
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
        content: 'Desea continuar con el proceso?!',
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
    $("#Exportar").prop('disabled', false);
    $("#Imprimir").prop('disabled', false);
    $("#Cerrar").prop('disabled', false);
});

function FiltroMarca() {
    var tipo = $('#Tipo').val();
    $.ajax({
        url: '/HojaCostoPNP/FiltroMarca',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo },
        success: function (marcas) {
            //$("#Marca").html(""); // clear before appending new list
            $("#Marca").autocomplete({
                source: marcas,
                minLength: 3,
                select: function (event, ui) {
                    $.ajax({
                        url: '/HojaCostoPNP/FiltroColeccion',
                        type: "POST",
                        dataType: "JSON",
                        data: { Tipo: tipo, Marca: ui.item.label },
                        success: function (colecciones) {
                            $("#Coleccion").autocomplete({
                                source: colecciones,
                                minLength: 3,
                                select: function (event, ui) {
                                    $.ajax({
                                        url: '/HojaCostoPNP/FiltroLinea',
                                        type: "POST",
                                        dataType: "JSON",
                                        data: { Tipo: tipo, Marca: $("#Marca").val(), Coleccion: ui.item.label },
                                        success: function (lineas) {
                                            $("#Linea").autocomplete({
                                                source: lineas,
                                                minLength: 3,
                                                select: function (event, ui) {
                                                    $.ajax({
                                                        url: '/HojaCostoPNP/FiltroEstado',
                                                        type: "POST",
                                                        dataType: "JSON",
                                                        data: { Tipo: tipo, Marca: $("#Marca").val(), Coleccion: $("#Coleccion").val(), Linea: ui.item.label },
                                                        success: function (estado) {
                                                            $("#Estado").autocomplete({
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

$('#ver-todo-marcas').click(function () {
    $('#Marca').trigger("focus"); //or "click", at least one should work
    $('#Marca').autocomplete("search");
});

$('#ver-todo-coleccion').click(function () {
    $('#Coleccion').trigger("focus"); //or "click", at least one should work
    $('#Coleccion').autocomplete("search");
});

$('#ver-todo-linea').click(function () {
    $('#Linea').trigger("focus"); //or "click", at least one should work
    $('#Linea').autocomplete("search");
});

$('#ver-todo-estado').click(function () {
    $('#Estado').trigger("focus"); //or "click", at least one should work
    $('#Estado').autocomplete("search");
});

$('#ver-todo-ref').click(function () {
    $('#Referencia').trigger("focus"); //or "click", at least one should work
    $('#Referencia').autocomplete("search");
});

function FiltroRef() {
    var tipo = $('#TipoCab').val();
    $.ajax({
        url: '/HojaCostoPNP/FiltroRef',
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


function FiltroMarca2() {
    var tipo = $('#Tipo').val();
    $.ajax({
        url: '/HojaCostoPNP/FiltroMarca',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo },
        success: function (marcas) {
            //$("#Marca").html(""); // clear before appending new list
            $("#Marca").autocomplete({
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
    var marca = $('#Marca').val();
    $.ajax({
        url: '/HojaCostoPNP/FiltroColeccion',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo, Marca: marca },
        success: function (colecciones) {
            //$("#Coleccion").html(""); // clear before appending new list

            $("#Coleccion").autocomplete({
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
    var marca = $('#Marca').val();

    if (col === "") {
        col = $('#Coleccion').val();
    }

    $.ajax({
        url: '/HojaCostoPNP/FiltroLinea',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo, Marca: marca, Coleccion: col },
        success: function (lineas) {
            $("#Linea").autocomplete({
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
    var marca = $('#Marca').val();
    var col = $('#Coleccion').val();

    if (linea === "") {
        linea = $('#Linea').val();
    }

    $.ajax({
        url: '/HojaCostoPNP/FiltroEstado',
        type: "POST",
        dataType: "JSON",
        data: { Tipo: tipo, Marca: marca, Coleccion: col, Linea: linea },
        success: function (estado) {
            $("#Estado").autocomplete({
                source: estado,
                minLength: 3,
                select: function (event, ui) {

                }
            });
        }
    });
}