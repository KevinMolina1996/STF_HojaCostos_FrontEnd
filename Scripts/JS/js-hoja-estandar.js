$(document).ready(function () {
    $(".formato").each(function (index, value) {
        var valor = parseFloat($(this).val());
        $(this).val("$" + valor.toLocaleString('es-CO'));
    });
});

$('#Exportar').click(function (e) {
    e.preventDefault();

    $.confirm({
        title: 'Confirmar!',
        content: 'Seleccione la operación a realizar!',
        buttons: {
            PDF: function () {
                var action = "/HojaEstandar/ExportPDF";
                $("#FrmMasiva").attr("action", action);
                $("#FrmMasiva").submit();
            },
            EXCEL: function () {
                var action = "/HojaEstandar/ExportExcel";
                $("#FrmMasiva").attr("action", action);
                $("#FrmMasiva").submit();
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
                var action = "/HojaEstandar/GenerarPdf";
                $("#FrmMasiva").attr("action", action);
                $("#FrmMasiva").submit();
            },
            CANCELAR: function () {

            }
        }
    });
});

$('#Cerrar').click(function (e) {
    e.preventDefault();

    $.confirm({
        title: 'Confirmar!',
        content: 'Desea continuar con el proceso?!',
        buttons: {
            CONFIRMAR: function () {
                var action = "/HojaEstandar/CerrarHojas";
                $("#FrmMasiva").attr("action", action);
                $("#FrmMasiva").submit();
            },
            CANCELAR: function () {

            }
        }
    });
});