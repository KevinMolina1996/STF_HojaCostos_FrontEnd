var PARAMETROS;

$(document).ready(function () {
    //$(".formato_cero").each(function (index, value) {
    //    var valor = parseFloat($(this).val().replace(",", "."));
    //    $(this).val("$" + valor.toLocaleString('es-CO').replace(".", ","));
    //});
    //$("#SimPnpTotalCostoBodegaF").trigger("change");

    //$(".dos_decimales").each(function (index, value) {
    //    var valor = parseFloat($(this).val().replace(",", ".")).toFixed(2);
    //    $(this).val(valor.toLocaleString('es-CO').replace(".", ","));
    //});

    //$(".sin_decimales").each(function (index, value) {
    //    var valor = parseFloat($(this).val().replace(",", ".")).toFixed(0);
    //    $(this).val(valor.toLocaleString('es-CO').replace(".", ","));
    //});

    //cambioDecimales();
    cargarMascaraDinero();
});

function cargarMascaraDinero() {
    $('.dinero').mask("000.000.000.000.000,00", { reverse: true });
    $('.dinero').trigger('input');
}

function cambioDecimales() {
    $(".cuatro_decimales").each(function (index, value) {
        var valor = parseFloat($(this).val().replace(",", ".")).toFixed(4);
        $(this).val(valor.toLocaleString('es-CO').replace(".", ","));
    });
}

function formato(campo) {
    //var valor = parseFloat($(campo).val());
    //$(campo).val("$" + valor.toLocaleString('es-CO'));
}

window.onload = function () {
    var labels = ["COSTO COMPRA", "GASTOS ORIGEN", "FLETE", "ARANCEL", "SEGURO INTERNAC", "GASTOS DESTINO", "OTROS GASTOS"];
    var values = [$("#SimPnpCostoCompraPorcF").val(), $("#SimPnpGastosOrigenPorcF").val(), $("#SimPnpGastosFletePorcF").val(), $("#SimPnpGastosArancelPorcF").val(), $("#SimPnpGastosSeguroPorcF").val(), $("#SimPnpGastosDestinoPorcF").val(), $("#SimPnpGastosOtrosPorcF").val()];

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
    values = [$("#SimPnpCostoCompraPorcF").val(), $("#SimPnpGastosDestinoPorcF").val()];

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

function ActualizarGrafico() {
    $("#contenedor_chart1").empty();
    $("#contenedor_chart2").empty();
    $("#contenedor_chart1").append("<canvas id='myChart' style='padding: 0; margin: auto; display: block; height:350px; width:100%; '> </canvas><div id='chart'></div>");
    $("#contenedor_chart2").append("<canvas id='myChart2' style='padding: 0; margin: auto; display: block; height:350px; width:100%; '> </canvas><div id='chart'></div>");

    var labels = ["COSTO COMPRA", "GASTOS ORIGEN", "FLETE", "ARANCEL", "SEGURO INTERNAC", "GASTOS DESTINO", "OTROS GASTOS"];
    var values = [$("#SimPnpCostoCompraPorcF").val(), $("#SimPnpGastosOrigenPorcF").val(), $("#SimPnpGastosFletePorcF").val(), $("#SimPnpGastosArancelPorcF").val(), $("#SimPnpGastosSeguroPorcF").val(), $("#SimPnpGastosDestinoPorcF").val(), $("#SimPnpGastosOtrosPorcF").val()];

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
    values = [$("#SimPnpCostoCompraPorcF").val(), $("#SimPnpGastosDestinoPorcF").val()];

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
}

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

$("#SimPnpCostoCompraUsdF").change(function () {
    var valor = $(this).val();
    var trm = $("#SimPnpTrmM").val();

    if (valor.length > 0 && valor !== null && trm.length > 0 && trm !== null) {
        total_por = parseFloat(valor.replace(",", ".")) * parseFloat(trm.replace(",", "."));
        total_por = total_por.toFixed(0);
        $("#SimPnpCostoCompraPesosM").val(total_por.toString().replace(".", ","));
        cargarMascaraDinero();
        formato($("#SimPnpCostoCompraPesosM"));

        var total = 0;
        $(".trm").each(function (index, value) {
            if ($(this).val() !== null && $(this).val().length > 0) {
                total = total + parseFloat($(this).val().replace(",", "."));
            }
        });

        total = total.toFixed(4);
        total = total.toString().replace(",", ".");

        $("#SimPnpTotalCostoBodegaF").val(total.replace(".", ","));

        trm = trm.replace(",", ".");
        var total_bodega = parseFloat(total) * parseFloat(trm);
        $("#SimPnpTotalCostoBodegaM").val("$" + total_bodega.toString().replace(".", ","));

        $("#SimPnpTotalCostoBodegaF").trigger("change");
        ActualizarGrafico();
        cambioDecimales();
    }
});

$("#SimPnpPinSeguridadUsdF").change(function () {
    var valor = $(this).val();
    var trm = $("#SimPnpTrmM").val();

    if (valor.length > 0 && valor !== null && trm.length > 0 && trm !== null) {
        total_por = parseFloat(valor.replace(",", ".")) * parseFloat(trm.replace(",", "."));
        total_por = total_por.toFixed(0);
        $("#SimPnpPinSeguridadPesosM").val(total_por.toString().replace(".", ","));
        formato($("#SimPnpPinSeguridadPesosM"));

        var total = 0;
        $(".trm").each(function (index, value) {
            if ($(this).val() !== null && $(this).val().length > 0) {
                total = total + parseFloat($(this).val().replace(",", "."));
            }
        });

        total = total.toFixed(4);
        total = total.toString().replace(",", ".");

        $("#SimPnpTotalCostoBodegaF").val(total.replace(".", ","));

        trm = trm.replace(",", ".");
        var total_bodega = parseFloat(total) * parseFloat(trm);
        $("#SimPnpTotalCostoBodegaM").val(total_bodega.toString().replace(".", ","));

        $("#SimPnpTotalCostoBodegaF").trigger("change");
        ActualizarGrafico();
        cambioDecimales();
    }
});

$("#SimPnpGastosOrigenUsdF").change(function () {
    var valor = $(this).val();
    var trm = $("#SimPnpTrmM").val();

    if (valor.length > 0 && valor !== null && trm.length > 0 && trm !== null) {
        total_por = parseFloat(valor.replace(",", ".")) * parseFloat(trm.replace(",", "."));
        total_por = total_por.toFixed(0);
        $("#SimPnpGastosOrigenPesosM").val(total_por.toString().replace(".", ","));
        formato($("#SimPnpGastosOrigenPesosM"));

        var total = 0;
        $(".trm").each(function (index, value) {
            if ($(this).val !== null && $(this).val.length > 0) {
                total = total + parseFloat($(this).val().replace(",", "."));
            }
        });

        total = total.toFixed(4);
        total = total.toString().replace(",", ".");

        $("#SimPnpTotalCostoBodegaF").val(total.replace(".", ","));

        trm = trm.replace(",", ".");
        var total_bodega = parseFloat(total) * parseFloat(trm);
        $("#SimPnpTotalCostoBodegaM").val(total_bodega.toString().replace(".", ","));

        $("#SimPnpTotalCostoBodegaF").trigger("change");
        ActualizarGrafico();
        cambioDecimales();
    }
});

function cambioTipoTransporte() {

    var costo = $("#SimPnpCostoCompraUSDD").val().replace(",", ".");
    var parametro = 0;

    if ($("#tipoTransporte").val() === "M") {
        parametro = parseFloat($("#SimPnGastosFleteF").val().replace(",", "."));
    } else {
        parametro = parseFloat($("#SimPnGastosFleteAereoF").val().replace(",", "."));
    }

    var total = parseFloat(costo) * parametro;

    $("#SimPnpGastosFleteUsdF").val(total.toString().replace(".", ","));
    $("#SimPnpGastosFleteUsdF").trigger("change");
    cambioDecimales();
}

$("#SimPnpGastosFleteUsdF").change(function () {
    var valor = $(this).val();
    var trm = $("#SimPnpTrmM").val();

    if (valor.length > 0 && valor !== null && trm.length > 0 && trm !== null) {
        total_por = parseFloat(valor.replace(",", ".")) * parseFloat(trm.replace(",", "."));
        total_por = total_por.toFixed(0);
        $("#SimPnpGastosFletePesosM").val(total_por.toString().replace(".", ","));
        formato($("#SimPnpGastosFletePesosM"));

        var total = 0;
        $(".trm").each(function (index, value) {
            if ($(this).val !== null && $(this).val.length > 0) {
                total = total + parseFloat($(this).val().replace(",", "."));
            }
        });

        total = total.toFixed(4);
        total = total.toString().replace(",", ".");

        $("#SimPnpTotalCostoBodegaF").val(total.replace(".", ","));

        trm = trm.replace(",", ".");
        var total_bodega = parseFloat(total) * parseFloat(trm);
        $("#SimPnpTotalCostoBodegaM").val(total_bodega.toString().replace(".", ","));

        $("#SimPnpTotalCostoBodegaF").trigger("change");
        ActualizarGrafico();
        cambioDecimales();
    }
});

$("#SimPnpGastosArancelUsdF").change(function () {
    var valor = $(this).val();
    var trm = $("#SimPnpTrmM").val();

    if (valor.length > 0 && valor !== null && trm.length > 0 && trm !== null) {
        total_por = parseFloat(valor.replace(",", ".")) * parseFloat(trm.replace(",", "."));
        total_por = total_por.toFixed(0);
        $("#SimPnpGastosArancelPesosM").val(total_por.toString().replace(".", ","));
        formato($("#SimPnpGastosArancelPesosM"));

        var total = 0;
        $(".trm").each(function (index, value) {
            if ($(this).val !== null && $(this).val.length > 0) {
                total = total + parseFloat($(this).val().replace(",", "."));
            }
        });

        total = total.toFixed(4);
        total = total.toString().replace(",", ".");

        $("#SimPnpTotalCostoBodegaF").val(total.replace(".", ","));

        trm = trm.replace(",", ".");
        var total_bodega = parseFloat(total) * parseFloat(trm);
        $("#SimPnpTotalCostoBodegaM").val(total_bodega.toString().replace(".", ","));

        $("#SimPnpTotalCostoBodegaF").trigger("change");
        ActualizarGrafico();
        cambioDecimales();
    }
});

$("#SimPnpGastosSeguroUsdF").change(function () {
    var valor = $(this).val();
    var trm = $("#SimPnpTrmM").val();

    if (valor.length > 0 && valor !== null && trm.length > 0 && trm !== null) {
        total_por = parseFloat(valor.replace(",", ".")) * parseFloat(trm.replace(",", "."));
        total_por = total_por.toFixed(0);
        $("#SimPnpGastosSeguroPesosM").val(total_por.toString().replace(".", ","));
        formato($("#SimPnpGastosSeguroPesosM"));

        var total = 0;
        $(".trm").each(function (index, value) {
            if ($(this).val !== null && $(this).val.length > 0) {
                total = total + parseFloat($(this).val().replace(",", "."));
            }
        });

        total = total.toFixed(4);
        total = total.toString().replace(",", ".");

        $("#SimPnpTotalCostoBodegaF").val(total.replace(".", ","));

        trm = trm.replace(",", ".");
        var total_bodega = parseFloat(total) * parseFloat(trm);
        $("#SimPnpTotalCostoBodegaM").val(total_bodega.toString().replace(".", ","));

        $("#SimPnpTotalCostoBodegaF").trigger("change");
        ActualizarGrafico();
        cambioDecimales();
    }
});

$("#SimPnpGastosDestinoUsdF").change(function () {
    var valor = $(this).val();
    var trm = $("#SimPnpTrmM").val();

    if (valor.length > 0 && valor !== null && trm.length > 0 && trm !== null) {
        total_por = parseFloat(valor.replace(",", ".")) * parseFloat(trm.replace(",", "."));
        total_por = total_por.toFixed(0);
        $("#SimPnpGastosDestinoPesosM").val(total_por.toString().replace(".", ","));
        formato($("#SimPnpGastosDestinoPesosM"));

        var total = 0;
        $(".trm").each(function (index, value) {
            if ($(this).val !== null && $(this).val.length > 0) {
                total = total + parseFloat($(this).val().replace(",", "."));
            }
        });

        total = total.toFixed(4);
        total = total.toString().replace(",", ".");

        $("#SimPnpTotalCostoBodegaF").val(total.replace(".", ","));

        trm = trm.replace(",", ".");
        var total_bodega = parseFloat(total) * parseFloat(trm);
        $("#SimPnpTotalCostoBodegaM").val(total_bodega.toString().replace(".", ","));

        $("#SimPnpTotalCostoBodegaF").trigger("change");
        ActualizarGrafico();
        cambioDecimales();
    }
});

$("#SimPnpGastosOtrosUsdF").change(function () {
    var valor = $(this).val();
    var trm = $("#SimPnpTrmM").val();

    if (valor.length > 0 && valor !== null && trm.length > 0 && trm !== null) {
        total_por = parseFloat(valor.replace(",", ".")) * parseFloat(trm.replace(",", "."));
        total_por = total_por.toFixed(0);
        $("#SimPnpGastosOtrosPesosM").val(total_por.toString().replace(".", ","));
        formato($("#SimPnpGastosOtrosPesosM"));

        var total = 0;
        $(".trm").each(function (index, value) {
            if ($(this).val !== null && $(this).val.length > 0) {
                total = total + parseFloat($(this).val().replace(",", "."));
            }
        });

        total = total.toFixed(4);
        total = total.toString().replace(",", ".");

        $("#SimPnpTotalCostoBodegaF").val(total.replace(".", ","));

        trm = trm.replace(",", ".");
        var total_bodega = parseFloat(total) * parseFloat(trm);
        $("#SimPnpTotalCostoBodegaM").val(total_bodega.toString().replace(".", ","));

        $("#SimPnpTotalCostoBodegaF").trigger("change");
        ActualizarGrafico();
        cambioDecimales();
    }
});

$("#SimPnpTotalCostoBodegaF").change(function () {
    $(".trm").each(function (index, value) {
        if ($(this).val() !== null && $(this).val().length > 0) {
            if ($(this).attr("id") === "SimPnpCostoCompraUsdF") {
                $("#SimPnpCostoCompraPorcF").val(Math.round(parseFloat($(this).val().replace(",", ".")) / parseFloat($("#SimPnpTotalCostoBodegaF").val().replace(",", ".")) * 100));
            }
            if ($(this).attr("id") === "SimPnpGastosOrigenUsdF") {
                $("#SimPnpGastosOrigenPorcF").val(Math.round(parseFloat($(this).val().replace(",", ".")) / parseFloat($("#SimPnpTotalCostoBodegaF").val().replace(",", ".")) * 100));
            }
            if ($(this).attr("id") === "SimPnpGastosFleteUsdF") {
                $("#SimPnpGastosFletePorcF").val(Math.round(parseFloat($(this).val().replace(",", ".")) / parseFloat($("#SimPnpTotalCostoBodegaF").val().replace(",", ".")) * 100));
            }
            if ($(this).attr("id") === "SimPnpGastosArancelUsdF") {
                $("#SimPnpGastosArancelPorcF").val(Math.round(parseFloat($(this).val().replace(",", ".")) / parseFloat($("#SimPnpTotalCostoBodegaF").val().replace(",", ".")) * 100));
            }
            if ($(this).attr("id") === "SimPnpGastosSeguroUsdF") {
                $("#SimPnpGastosSeguroPorcF").val(Math.round(parseFloat($(this).val().replace(",", ".")) / parseFloat($("#SimPnpTotalCostoBodegaF").val().replace(",", ".")) * 100));
            }
            if ($(this).attr("id") === "SimPnpGastosDestinoUsdF") {
                $("#SimPnpGastosDestinoPorcF").val(Math.round(parseFloat($(this).val().replace(",", ".")) / parseFloat($("#SimPnpTotalCostoBodegaF").val().replace(",", ".")) * 100));
            }
            if ($(this).attr("id") === "SimPnpGastosOtrosUsdF") {
                $("#SimPnpGastosOtrosPorcF").val(Math.round(parseFloat($(this).val().replace(",", ".")) / parseFloat($("#SimPnpTotalCostoBodegaF").val().replace(",", ".")) * 100));
            }
            if ($(this).attr("id") === "SimPnpPinSeguridadUsdF") {
                $("#SimPnpPinSeguridadPorcF").val(Math.round(parseFloat($(this).val().replace(",", ".")) / parseFloat($("#SimPnpTotalCostoBodegaF").val().replace(",", ".")) * 100));
            }
        }
    });

    var trm = $("#SimPnpTrmM").val();
    var total = $("#SimPnpTotalCostoBodegaF").val();

    trm = trm.replace(",", ".");
    total = parseFloat(total.replace(",", ".")).toFixed(4);
    //total = total.toFixed(4);
    total = total.toString().replace(",", ".");
    var total_bodega = parseFloat(total) * parseFloat(trm);
    total_bodega = total_bodega.toFixed(0);
    $("#SimPnpTotalCostoBodegaM").val("$" + total_bodega.toString().replace(".", ","));

    $("#SimPnpTotalCostosGastosRealF").trigger("change");
    $("#SimPnpTotalCostosGastosEstimadoF").trigger("change");
    cambioDecimales();
});

$("#SimPnpCostoCompraUSDD").change(function () {

    $("#SimPnpCostoCompraUsdF").val(this.value);
    $(".trm").each(function (index, value) {
        $(this).trigger("change");
    });
    cambioDecimales();

});

$("#SimPnpTrmM").change(function () {

    $(".trm").each(function (index, value) {
        $(this).trigger("change");
    });
    cambioDecimales();
});

$("#SimPnpAdecuacionPrdM").change(function () {
    var total = parseFloat($("#SimPnpAdecuacionPrdM").val().replace(",", ".").replace("$", "")) / parseFloat($("#SimPnpTrmM").val().replace(",", "."))
    //total = total.toFixed(2);
    $("#SimPnpAdecuacionPrdF").val(total.toString().replace(".", ","));
    $("#SimPnpTotalCostosGastosRealF").trigger("change");
    $("#SimPnpTotalCostosGastosEstimadoF").trigger("change");
    cambioDecimales();
});

$("#SimPnpSensorizacionM").change(function () {
    var total = parseFloat($("#SimPnpSensorizacionM").val().replace(",", ".").replace("$", "")) / parseFloat($("#SimPnpTrmM").val().replace(",", "."))
    //total = total.toFixed(2);
    $("#SimPnpSensorizacionF").val(total.toString().replace(".", ","));
    $("#SimPnpTotalCostosGastosRealF").trigger("change");
    $("#SimPnpTotalCostosGastosEstimadoF").trigger("change");
    cambioDecimales();
});

$("#SimPnpArregloM").change(function () {
    var total = parseFloat($("#SimPnpArregloM").val().replace(",", ".").replace("$", "")) / parseFloat($("#SimPnpTrmM").val().replace(",", "."))
    //total = total.toFixed(2);
    $("#SimPnpArregloF").val(total.toString().replace(".", ","));
    $("#SimPnpTotalCostosGastosRealF").trigger("change");
    $("#SimPnpTotalCostosGastosEstimadoF").trigger("change");
    cambioDecimales();
});

$("#SimPnpReconstruccionM").change(function () {
    var total = parseFloat($("#SimPnpReconstruccionM").val().replace(",", ".").replace("$", "")) / parseFloat($("#SimPnpTrmM").val().replace(",", "."))
    //total = total.toFixed(2);
    $("#SimPnpReconstruccionF").val(total.toString().replace(".", ","));
    $("#SimPnpTotalCostosGastosRealF").trigger("change");
    $("#SimPnpTotalCostosGastosEstimadoF").trigger("change");
    cambioDecimales();
});

$("#SimPnpGastosAdmonRealF").change(function () {
    var total = parseFloat($("#SimPnpGastosAdmonRealF").val().replace(",", ".").replace("$", "")) * parseFloat($("#SimPnpTrmM").val().replace(",", "."))
    //total = total.toFixed(2);
    $("#SimPnpGastosAdmonRealM").val(total.toString().replace(".", ","));
    formato($("#SimPnpGastosAdmonRealM"));
    $("#SimPnpTotalCostosGastosRealF").trigger("change");
    $("#SimPnpTotalCostosGastosEstimadoF").trigger("change");
    cambioDecimales();
});

$("#SimPnpGastosAdmonEstimadoF").change(function () {
    var total = parseFloat($("#SimPnpGastosAdmonEstimadoF").val().replace(",", ".").replace("$", "")) * parseFloat($("#SimPnpTrmM").val().replace(",", "."))
    //total = total.toFixed(2);
    $("#SimPnpGastosAdmonEstimadoM").val(total.toString().replace(".", ","));
    formato("#SimPnpGastosAdmonEstimadoM");
    $("#SimPnpTotalCostosGastosRealF").trigger("change");
    $("#SimPnpTotalCostosGastosEstimadoF").trigger("change");
    cambioDecimales();
});

$("#SimPnpTotalCostosGastosRealF").change(function () {
    var total = 0;
    $(".total_gastos_real").each(function (index, value) {
        if (value.value !== null) {
            total = total + parseFloat(value.value.replace(",", "."));
        }
    });
    //total = total.toFixed(2);
    $("#SimPnpTotalCostosGastosRealF").val(total.toString().replace(".", ","));

    var total_pesos = parseFloat(total.toString().replace(",", ".")) * parseFloat($("#SimPnpTrmM").val().replace(",", "."));
    total_pesos = total_pesos.toFixed(2);
    $("#SimPnpTotalCostosGastosRealM").val(total_pesos.toString().replace(".", ","));
    formato("#SimPnpTotalCostosGastosRealM");
    $("#SimPnpTotalCostosGastosRealM").trigger("change");
    cambioDecimales();
});

$("#SimPnpTotalCostosGastosEstimadoF").change(function () {
    var total = 0;
    $(".total_gastos_est").each(function (index, value) {
        if (value.value !== null) {
            total = total + parseFloat(value.value.replace(",", "."));
        }
    });
    //total = total.toFixed(2);
    $("#SimPnpTotalCostosGastosEstimadoF").val(total.toString().replace(".", ","));

    var total_pesos = parseFloat(total.toString().replace(",", ".")) * parseFloat($("#SimPnpTrmM").val().replace(",", "."));
    total_pesos = total_pesos.toFixed(2);
    $("#SimPnpTotalCostosGastosEstimadoM").val(total_pesos.toString().replace(".", ","));
    formato("#SimPnpTotalCostosGastosEstimadoM");
    $("#SimPnpTotalCostosGastosEstimadoM").trigger("change");
    cambioDecimales();
});

$('#Exportar').click(function (e) {
    e.preventDefault();

    $.confirm({
        title: 'Confirmar!',
        content: 'Seleccione la operación a realizar!',
        buttons: {
            PDF: function () {
                var action = "/HojaNoProducidoSimulada/ExportPDF";
                $("#FrmAcciones").attr("action", action);
                $("#FrmAcciones").submit();
            },
            EXCEL: function () {
                var action = "/HojaNoProducidoSimulada/ExportExcel";
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
                var action = "/HojaNoProducidoSimulada/GenerarPdf";
                $("#FrmAcciones").attr("action", action);
                $("#FrmAcciones").submit();
            },
            CANCELAR: function () {

            }
        }
    });
});

$("input[type='text']").change(function () {
    if (PARAMETROS === 1) {
        return;
    }
    var id = $(this).attr("id").replace("Sim", "");
    //var formula = $("input[data-name='McCostoManoObraD']").data("formula");
    //if (formula.length > 0) {
    $("input[data-formula]").each(function (index, elemento) {
        //console.log("Indice: " + index);
        //console.log("atributo: " + $(this).attr("data-formula"));
        if ($(this).attr("data-formula").includes(id)) {
            //Abro Modal Loading
            //$("#boModal").val("false");
            //AbrirModal();

            /* EJECUTO LA FORMULA DEL PRIMER CAMPO DEPENDIENTE */

            var nombre_campo = $(this).attr("data-name");
            var split = $(this).attr("data-formula").split("|");
            var formula = $(this).attr("data-consulta");
            $.each(split, function (index, value) {
                if (value.includes("#")) {

                    var val_campo;
                    if ($(value.replace("#", "#Sim")).length > 0) {
                        val_campo = $(value.replace("#", "#Sim")).val();
                    }
                    else {
                        val_campo = "0";
                    }

                    val_campo = val_campo.replace(",", ".");

                    if (value.includes("Pnp") && !value.includes("F")) {
                        val_campo = val_campo.replace(".", "");
                    } 

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
                            if ($(value.replace("#", "#Sim")).length > 0) {
                                val_campo = $(value.replace("#", "#Sim")).val();
                            }
                            else {
                                val_campo = "0";
                            }
                            val_campo = val_campo.replace(",", ".");

                            if (value.includes("Pnp") && !value.includes("F")) {
                                val_campo = val_campo.replace(".", "");
                            } 

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
                                    if ($(value.replace("#", "#Sim")).length > 0) {
                                        val_campo = $(value.replace("#", "#Sim")).val();
                                    }
                                    else {
                                        val_campo = "0";
                                    }
                                    val_campo = val_campo.replace(",", ".");

                                    if (value.includes("Pnp") && !value.includes("F")) {
                                        val_campo = val_campo.replace(".", "");
                                    } 

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
                                            if ($(value.replace("#", "#Sim")).length > 0) {
                                                val_campo = $(value.replace("#", "#Sim")).val();
                                            }
                                            else {
                                                val_campo = "0";
                                            }
                                            val_campo = val_campo.replace(",", ".");

                                            if (value.includes("Pnp") && !value.includes("F")) {
                                                val_campo = val_campo.replace(".", "");
                                            } 

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
                                                    if ($(value.replace("#", "#Sim")).length > 0) {
                                                        val_campo = $(value.replace("#", "#Sim")).val();
                                                    }
                                                    else {
                                                        val_campo = "0";
                                                    }
                                                    val_campo = val_campo.replace(",", ".");

                                                    if (value.includes("Pnp") && !value.includes("F")) {
                                                        val_campo = val_campo.replace(".", "");
                                                    } 

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
                                                            if ($(value.replace("#", "#Sim")).length > 0) {
                                                                val_campo = $(value.replace("#", "#Sim")).val();
                                                            }
                                                            else {
                                                                val_campo = "0";
                                                            }
                                                            val_campo = val_campo.replace(",", ".");

                                                            if (value.includes("Pnp") && !value.includes("F")) {
                                                                val_campo = val_campo.replace(".", "");
                                                            } 

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
                                                                    if ($(value.replace("#", "#Sim")).length > 0) {
                                                                        val_campo = $(value.replace("#", "#Sim")).val();
                                                                    }
                                                                    else {
                                                                        val_campo = "0";
                                                                    }
                                                                    val_campo = val_campo.replace(",", ".");

                                                                    if (value.includes("Pnp") && !value.includes("F")) {
                                                                        val_campo = val_campo.replace(".", "");
                                                                    } 

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
                                                                            if ($(value.replace("#", "#Sim")).length > 0) {
                                                                                val_campo = $(value.replace("#", "#Sim")).val();
                                                                            }
                                                                            else {
                                                                                val_campo = "0";
                                                                            }
                                                                            val_campo = val_campo.replace(",", ".");

                                                                            if (value.includes("Pnp") && !value.includes("F")) {
                                                                                val_campo = val_campo.replace(".", "");
                                                                            } 

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
    //$("#boModal").val("true");
});

function EjecutarFormula(formula, nombre_campo) {
    var params = { formula: formula };
    $.ajax({
        url: '/HojaNoProducidoSimulada/EjecutarFormula',
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
                if (nombre_campo.includes("PnpMargenMaxBrutoRealF") || nombre_campo.includes("PnpMargenMaxOpeRealF") || nombre_campo.includes("PnpMargenMinBrutoRealF") || nombre_campo.includes("PnpMargenMinOpeRealF") ||
                    nombre_campo.includes("PnpMargenMaxBrutoEstimadoF") || nombre_campo.includes("PnpMargenMaxOpeEstimadoF") || nombre_campo.includes("PnpMargenMinBrutoEstimadoF") || nombre_campo.includes("PnpMargenMinOpeEstimadoF")) {
                    $("#Sim" + nombre_campo).val(Math.round(result.mensaje * 100));
                }
                else if (nombre_campo.includes("PnpPrecioMaxRealM") || nombre_campo.includes("PnpPrecioMinRealM")) {
                    $("#Sim" + nombre_campo).val(Math.round(result.mensaje));
                }
                else if (nombre_campo.includes("PnpGastosAdmonRealF")) {
                    //var total = result.mensaje.toFixed(2).toString().replace(".", ",");
                    var total = result.mensaje.toString().replace(".", ",");
                    var total2 = result.mensaje.toString().replace(".", ","); //Total con decimales
                    var trm = $("#SimPnpTrmM").val();
                    var total_pesos = parseFloat(total2.replace(",", ".")) * parseFloat(trm.toString().replace(",", "."));
                    $("#SimPnpGastosAdmonRealF").val(total);
                    $("#SimPnpGastosAdmonRealM").val(total_pesos.toFixed(3).toString().replace(".", ","));
                    formato("#SimPnpGastosAdmonRealM");
                }
                else if (nombre_campo.includes("PnpGastosAdmonEstimadoF")) {
                    //var total = result.mensaje.toFixed(2).toString().replace(".", ",");
                    total = result.mensaje.toString().replace(".", ",");
                    total2 = result.mensaje.toString().replace(".", ","); //Total con decimales
                    trm = $("#SimPnpTrmM").val();
                    total_pesos = parseFloat(total2.replace(",", ".")) * parseFloat(trm.toString().replace(",", "."));
                    $("#SimPnpGastosAdmonEstimadoF").val(total);
                    $("#SimPnpGastosAdmonEstimadoM").val(total_pesos.toFixed(3).toString().replace(".", ","));
                    formato("#SimPnpGastosAdmonEstimadoM");
                }
                else {
                    var valor = result.mensaje.toString();
                    valor = valor.replace(".", ",");
                    $("#Sim" + nombre_campo).val(valor);
                }
                cambioDecimales();
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

function validaParametros(){
    $("input").prop('disabled', true);
    PARAMETROS = 1;
    alerta("Alerta!", 'No hay parametros configurados para simular');
}