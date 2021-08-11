$(document).ready(function () {
    $(".formato").each(function (index, value) {
        var valor = parseFloat($(this).val().replace(',', '.')).toFixed(2);
        $(this).val(valor.replace('.', ','));
    });
});

$(document).ready(function () {
    $(".formato_cero").each(function (index, value) {
        var valor = parseFloat($(this).val());
        $(this).val("$" + valor.toLocaleString('es-CO'));
    });
});

window.onload = function () {
    var labels = ["COSTO COMPRA", "GASTOS ORIGEN", "FLETE", "ARANCEL", "SEGURO INTERNAC", "GASTOS DESTINO", "OTROS GASTOS"];

    var values = [parseFloat($("#PnpCostoCompraPorcF").val()) * 100, $("#PnpGastosOrigenPorcF").val(), $("#PnpGastosFletePorcF").val(), $("#PnpGastosArancelPorcF").val(), $("#PnpGastosSeguroPorcF").val(), $("#PnpGastosDestinoPorcF").val(), $("#PnpGastosOtrosPorcF").val()];

    var aLabels = labels;
    var aDatasets1 = values;
    var dataT = {
        labels: aLabels,
        datasets: [{
            label: "% PARTICIPACION DEL COSTO",
            data: aDatasets1,
            fill: false,
            backgroundColor: ["rgba(54, 162, 235, 0.2)", "rgba(255, 99, 132, 0.2)", "rgba(255, 159, 64, 0.2)", "rgba(255, 205, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(201, 203, 207, 0.2)"],
            borderColor: ["rgb(54, 162, 235)", "rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)", "rgb(75, 192, 192)", "rgb(153, 102, 255)", "rgb(201, 203, 207)"],
            borderWidth: 1
        }]
    };
    var ctx = $("#myChart").get(0).getContext("2d");
    var myNewChart = new Chart(ctx, {
        type: 'pie',
        data: dataT,
        options: {
            responsive: false,
            title: { display: true, text: '% PARTICIPACION DEL COSTO' },
            legend: { position: 'bottom' }
        }
    });

    labels = ["COSTO COMPRA", "GASTOS DESTINO"];
    values = [$("#PnpCostoCompraPorcF").val(), $("#PnpGastosDestinoPorcF").val()];

    aLabels = labels;
    aDatasets1 = values;
    dataT = {
        labels: aLabels,
        datasets: [{
            label: "% PARTICIPACION DEL COSTO",
            data: aDatasets1,
            fill: false,
            backgroundColor: ["rgba(54, 162, 235, 0.2)", "rgba(255, 99, 132, 0.2)", "rgba(255, 159, 64, 0.2)", "rgba(255, 205, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(201, 203, 207, 0.2)"],
            borderColor: ["rgb(54, 162, 235)", "rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)", "rgb(75, 192, 192)", "rgb(153, 102, 255)", "rgb(201, 203, 207)"],
            borderWidth: 1
        }]
    };
    ctx = $("#myChart2").get(0).getContext("2d");
    myNewChart = new Chart(ctx, {
        type: 'pie',
        data: dataT,
        options: {
            responsive: false,
            title: { display: true, text: '% PARTICIPACION DEL COSTO' },
            legend: { position: 'bottom' }
        }
    });
};

$('#Exportar').click(function (e) {
    e.preventDefault();

    $.confirm({
        title: 'Confirmar!',
        content: 'Seleccione la operación a realizar!',
        buttons: {
            PDF: function () {
                var action = "/HojaNoProducido/ExportPDF";
                $("#FrmAcciones").attr("action", action);
                $("#FrmAcciones").submit();
            },
            EXCEL: function () {
                var action = "/HojaNoProducido/ExportExcel";
                $("#FrmAcciones").attr("action", action);
                $("#FrmAcciones").submit();
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
                var action = "/HojaNoProducido/GenerarPdf";
                $("#FrmAcciones").attr("action", action);
                $("#FrmAcciones").submit();
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
                var action = "/HojaNoProducido/CerrarHojas";
                $("#FrmAcciones").attr("action", action);
                $("#FrmAcciones").submit();
            },
            CANCELAR: function () {

            }
        }
    });
});