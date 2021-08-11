document.addEventListener("DOMContentLoaded", function (event) {
    var g1 = new JustGage({
        id: 'g1',
        value: 0,
        min: 0,
        max: 100,
        symbol: '%',
        pointer: true,
        title: 'PRODUCIDO ' + 0,
        pointerOptions: {
            toplength: -15,
            bottomlength: 10,
            bottomwidth: 12,
            color: '#8e8e93',
            stroke: '#ffffff',
            stroke_width: 3,
            stroke_linecap: 'round'
        },
        customSectors: [{
            color: '#ff0000',
            lo: 50,
            hi: 100
        }, {
            color: '#00ff00',
            lo: 0,
            hi: 50
        }],
        relativeGaugeSize: true,
        gaugeWidthScale: 0.6,
        counter: true
    });

    var g2 = new JustGage({
        id: 'g2',
        value: 0,
        min: 0,
        max: 100,
        symbol: '%',
        pointer: true,
        title: 'NO PRODUCIDO ' + 0,
        pointerOptions: {
            toplength: -15,
            bottomlength: 10,
            bottomwidth: 12,
            color: '#8e8e93',
            stroke: '#ffffff',
            stroke_width: 3,
            stroke_linecap: 'round'
        },
        customSectors: [{
            color: '#ff0000',
            lo: 50,
            hi: 100
        }, {
            color: '#00ff00',
            lo: 0,
            hi: 50
        }],
        gaugeWidthScale: 0.6,
        relativeGaugeSize: true,
        counter: true
    });

    var aData = null;
    var data1 = null;
    var data2 = null;
    //Grafico Studio F
    var labels = ["Sin Foto / Patronaje", "Pte Hoja de Cto / Informatica", "Telas / Telas", "Insumos / Insumos", "Tiempos / Corte", "Procesos / Oficina Tecnica", "Ruta / Oficina Tecnica", "Maquila / Oficina Tecnica"];
    //var values = ["1", "2", "3", "4", "5", "6", "7", "8"];
    var aLabels = labels;
    var aDatasets1 = data1;
    var dataT = {
        labels: aLabels,
        datasets: [{
            label: "STUDIO F",
            data: aDatasets1,
            fill: false,
            backgroundColor: ["rgba(54, 162, 235, 0.2)", "rgba(255, 99, 132, 0.2)", "rgba(255, 159, 64, 0.2)", "rgba(255, 205, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(201, 203, 207, 0.2)"],
            borderColor: ["rgb(54, 162, 235)", "rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)", "rgb(75, 192, 192)", "rgb(153, 102, 255)", "rgb(201, 203, 207)"],
            borderWidth: 1
        }]
    };
    var ctx = $("#myChart").get(0).getContext("2d");
    var myNewChart = new Chart(ctx, {
        type: 'horizontalBar',
        data: dataT,
        options: {
            responsive: false,
            title: { display: true, text: 'STUDIO F' },
            legend: { position: 'bottom' }
        }
    });

    //Grafico Ela
    labels = ["Sin Foto / Patronaje", "Pte Hoja de Cto / Informatica", "Telas / Telas", "Insumos / Insumos", "Tiempos / Corte", "Procesos / Oficina Tecnica", "Ruta / Oficina Tecnica", "Maquila / Oficina Tecnica"];
    aLabels = labels;
    aDatasets1 = data2;
    dataT = {
        labels: aLabels,
        datasets: [{
            label: "ELA",
            data: aDatasets1,
            fill: false,
            backgroundColor: ["rgba(54, 162, 235, 0.2)", "rgba(255, 99, 132, 0.2)", "rgba(255, 159, 64, 0.2)", "rgba(255, 205, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(201, 203, 207, 0.2)"],
            borderColor: ["rgb(54, 162, 235)", "rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)", "rgb(75, 192, 192)", "rgb(153, 102, 255)", "rgb(201, 203, 207)"],
            borderWidth: 1
        }]
    };
    ctx = $("#myChart2").get(0).getContext("2d");
    myNewChart = new Chart(ctx, {
        type: 'horizontalBar',
        data: dataT,
        options: {
            responsive: false,
            title: { display: true, text: 'ELA' },
            legend: { position: 'bottom' }
        }
    });
});

function CargarDashBoard() {
    $("#vel1").empty();
    $("#vel2").empty();
    $("#barra1").empty();
    $("#barra2").empty();
    $("#vel1").append("<div id='g1' class='gauge'></div>");
    $("#vel2").append("<div id='g2' class='gauge'></div>");
    $("#barra1").append("<canvas id='myChart' style='padding: 0; margin: auto; display: block; height: 350px; width: 100 %;'></canvas>");
    $("#barra2").append("<canvas id='myChart2' style='padding: 0; margin: auto; display: block; height: 350px; width: 100 %;'></canvas>");

    var params = { Marca: $("#Marca option:selected").text(), Coleccion: $("#Coleccion option:selected").text() };

    //Se consulta fecha mas antigua de aprobacion
    $.ajax({
        type: "POST",
        url: "/DashBoardLvl1/ConsultarUltimaFecha",
        data: params,
        success: function (mems) {
            $("#fecha_inicial").text(mems);
        }
    });
    //Fin

    //se consultan las referencias pendientes de costo, y las completas con precio y sin precio

    $.ajax({
        type: "POST",
        url: "/DashBoardLvl1/ConsultaPendientesVelocimetro",
        data: params,
        success: function (mems) {
            $("#completa").text(mems.completas);
            $("#pendiente").text(mems.pendientes);
            $("#producido_precio").text(mems.con_precio);
            $("#producido_sin_precio").text(mems.sin_precio);
            $("#TotalProducido").val(parseInt($("#completa").text()) + parseInt($("#pendiente").text()));
            if (parseInt($("#TotalProducido").val()) === 0) {
                $("#PorcentajeProducido").val(0);
            } else {
                $("#PorcentajeProducido").val(parseInt($("#completa").text()) / parseInt($("#TotalProducido").val()) * 100);
            }

            //Producto no producido
            $("#completa_pnp").text(mems.completas_pnp);
            $("#pendiente_pnp").text(mems.pendientes_pnp);
            $("#no_tracking").text(mems.no_tracking);
            $("#no_producido_precio").text(mems.no_producido_precio);
            $("#no_producido_sin_precio").text(mems.no_producido_sin_precio);
            $("#TotalNoProducido").val(parseInt($("#completa_pnp").text()) + parseInt($("#pendiente_pnp").text()));
            if (parseInt($("#TotalNoProducido").val()) === 0) {
                $("#PorcentajeNoProducido").val(0);
            } else {
                $("#PorcentajeNoProducido").val(parseInt($("#completa_pnp").text()) / parseInt($("#TotalNoProducido").val()) * 100);
            }

            //Armo grafico
            var g1 = new JustGage({
                id: 'g1',
                value: $("#PorcentajeProducido").val(),
                min: 0,
                max: 100,
                symbol: '%',
                pointer: true,
                title: 'PRODUCIDO ' + $("#TotalProducido").val(),
                pointerOptions: {
                    toplength: -15,
                    bottomlength: 10,
                    bottomwidth: 12,
                    color: '#8e8e93',
                    stroke: '#ffffff',
                    stroke_width: 3,
                    stroke_linecap: 'round'
                },
                customSectors: [{
                    color: '#ff0000',
                    lo: 50,
                    hi: 100
                }, {
                    color: '#00ff00',
                    lo: 0,
                    hi: 50
                }],
                relativeGaugeSize: true,
                gaugeWidthScale: 0.6,
                counter: true
            });

            var g2 = new JustGage({
                id: 'g2',
                value: $("#PorcentajeNoProducido").val(),
                min: 0,
                max: 100,
                symbol: '%',
                pointer: true,
                title: 'NO PRODUCIDO ' + + $("#TotalNoProducido").val(),
                pointerOptions: {
                    toplength: -15,
                    bottomlength: 10,
                    bottomwidth: 12,
                    color: '#8e8e93',
                    stroke: '#ffffff',
                    stroke_width: 3,
                    stroke_linecap: 'round'
                },
                customSectors: [{
                    color: '#ff0000',
                    lo: 50,
                    hi: 100
                }, {
                    color: '#00ff00',
                    lo: 0,
                    hi: 50
                }],
                gaugeWidthScale: 0.6,
                relativeGaugeSize: true,
                counter: true
            });
        }
    });

    //fin consulta

    //Consulta de fechas por marca y coleccion

    $.ajax({
        type: "POST",
        url: "/DashBoardLvl1/ConsultarFechas",
        data: params,
        success: function (mems) {
            $.each(mems, function (index, obj) {
                if (obj.FdSemana1S !== null && obj.FdSemana1S !== "") {

                    var splitCampo = obj.FdSemana1S.split(";");
                    var splitFecha = splitCampo[0].split("=");
                    $("#" + splitFecha[0] + " span").text(splitFecha[1]);

                    var fecSplit = splitFecha[1].split("-");

                    var d1 = moment(fecSplit[0]);
                    var d2 = moment(fecSplit[1]);

                    $("#" + splitFecha[0]).data('daterangepicker').setStartDate(d1);
                    $("#" + splitFecha[0]).data('daterangepicker').setEndDate(d2);

                    var campo = splitFecha[0].replace("_pnp", "").replace("_pn", "").replace("fec", "val_fec");
                    $("#" + campo).text(splitCampo[1]);

                } if (obj.FdSemana2S !== null && obj.FdSemana2S !== "") {

                    splitCampo = obj.FdSemana2S.split(";");
                    splitFecha = splitCampo[0].split("=");
                    $("#" + splitFecha[0] + " span").text(splitFecha[1]);

                    fecSplit = splitFecha[1].split("-");

                    d1 = moment(fecSplit[0]);
                    d2 = moment(fecSplit[1]);

                    $("#" + splitFecha[0]).data('daterangepicker').setStartDate(d1);
                    $("#" + splitFecha[0]).data('daterangepicker').setEndDate(d2);

                    campo = splitFecha[0].replace("_pnp", "").replace("_pn", "").replace("fec", "val_fec");
                    $("#" + campo).text(splitCampo[1]);

                } if (obj.FdSemana3S !== null && obj.FdSemana3S !== "") {

                    splitCampo = obj.FdSemana3S.split(";");
                    splitFecha = splitCampo[0].split("=");
                    $("#" + splitFecha[0] + " span").text(splitFecha[1]);

                    fecSplit = splitFecha[1].split("-");

                    d1 = moment(fecSplit[0]);
                    d2 = moment(fecSplit[1]);

                    $("#" + splitFecha[0]).data('daterangepicker').setStartDate(d1);
                    $("#" + splitFecha[0]).data('daterangepicker').setEndDate(d2);

                    campo = splitFecha[0].replace("_pnp", "").replace("_pn", "").replace("fec", "val_fec");
                    $("#" + campo).text(splitCampo[1]);

                } if (obj.FdSemana4S !== null && obj.FdSemana4S !== "") {

                    splitCampo = obj.FdSemana4S.split(";");
                    splitFecha = splitCampo[0].split("=");
                    $("#" + splitFecha[0] + " span").text(splitFecha[1]);

                    fecSplit = splitFecha[1].split("-");

                    d1 = moment(fecSplit[0]);
                    d2 = moment(fecSplit[1]);

                    $("#" + splitFecha[0]).data('daterangepicker').setStartDate(d1);
                    $("#" + splitFecha[0]).data('daterangepicker').setEndDate(d2);

                    campo = splitFecha[0].replace("_pnp", "").replace("_pn", "").replace("fec", "val_fec");
                    $("#" + campo).text(splitCampo[1]);

                } if (obj.FdSemana5S !== null && obj.FdSemana5S !== "") {

                    splitCampo = obj.FdSemana5S.split(";");
                    splitFecha = splitCampo[0].split("=");
                    $("#" + splitFecha[0] + " span").text(splitFecha[1]);

                    fecSplit = splitFecha[1].split("-");

                    d1 = moment(fecSplit[0]);
                    d2 = moment(fecSplit[1]);

                    $("#" + splitFecha[0]).data('daterangepicker').setStartDate(d1);
                    $("#" + splitFecha[0]).data('daterangepicker').setEndDate(d2);

                    campo = splitFecha[0].replace("_pnp", "").replace("_pn", "").replace("fec", "val_fec");
                    $("#" + campo).text(splitCampo[1]);

                } if (obj.FdSemana6S !== null && obj.FdSemana6S !== "") {

                    splitCampo = obj.FdSemana6S.split(";");
                    splitFecha = splitCampo[0].split("=");
                    $("#" + splitFecha[0] + " span").text(splitFecha[1]);

                    fecSplit = splitFecha[1].split("-");

                    d1 = moment(fecSplit[0]);
                    d2 = moment(fecSplit[1]);

                    $("#" + splitFecha[0]).data('daterangepicker').setStartDate(d1);
                    $("#" + splitFecha[0]).data('daterangepicker').setEndDate(d2);

                    campo = splitFecha[0].replace("_pnp", "").replace("_pn", "").replace("fec", "val_fec");
                    $("#" + campo).text(splitCampo[1]);

                } if (obj.FdSemana7S !== null && obj.FdSemana7S !== "") {

                    splitCampo = obj.FdSemana7S.split(";");
                    splitFecha = splitCampo[0].split("=");
                    $("#" + splitFecha[0] + " span").text(splitFecha[1]);

                    fecSplit = splitFecha[1].split("-");

                    d1 = moment(fecSplit[0]);
                    d2 = moment(fecSplit[1]);

                    $("#" + splitFecha[0]).data('daterangepicker').setStartDate(d1);
                    $("#" + splitFecha[0]).data('daterangepicker').setEndDate(d2);

                    campo = splitFecha[0].replace("_pnp", "").replace("_pn", "").replace("fec", "val_fec");
                    $("#" + campo).text(splitCampo[1]);

                } if (obj.FdSemana8S !== null && obj.FdSemana8S !== "") {

                    splitCampo = obj.FdSemana8S.split(";");
                    splitFecha = splitCampo[0].split("=");
                    $("#" + splitFecha[0] + " span").text(splitFecha[1]);

                    fecSplit = splitFecha[1].split("-");

                    d1 = moment(fecSplit[0]);
                    d2 = moment(fecSplit[1]);

                    $("#" + splitFecha[0]).data('daterangepicker').setStartDate(d1);
                    $("#" + splitFecha[0]).data('daterangepicker').setEndDate(d2);

                    campo = splitFecha[0].replace("_pnp", "").replace("_pn", "").replace("fec", "val_fec");
                    $("#" + campo).text(splitCampo[1]);

                } if (obj.FdSemana9S !== null && obj.FdSemana9S !== "") {

                    splitCampo = obj.FdSemana9S.split(";");
                    splitFecha = splitCampo[0].split("=");
                    $("#" + splitFecha[0] + " span").text(splitFecha[1]);

                    fecSplit = splitFecha[1].split("-");

                    d1 = moment(fecSplit[0]);
                    d2 = moment(fecSplit[1]);

                    $("#" + splitFecha[0]).data('daterangepicker').setStartDate(d1);
                    $("#" + splitFecha[0]).data('daterangepicker').setEndDate(d2);

                    campo = splitFecha[0].replace("_pnp", "").replace("_pn", "").replace("fec", "val_fec");
                    $("#" + campo).text(splitCampo[1]);

                } if (obj.FdSemana10S !== null && obj.FdSemana10S !== "") {

                    splitCampo = obj.FdSemana10S.split(";");
                    splitFecha = splitCampo[0].split("=");
                    $("#" + splitFecha[0] + " span").text(splitFecha[1]);

                    fecSplit = splitFecha[1].split("-");

                    d1 = moment(fecSplit[0]);
                    d2 = moment(fecSplit[1]);

                    $("#" + splitFecha[0]).data('daterangepicker').setStartDate(d1);
                    $("#" + splitFecha[0]).data('daterangepicker').setEndDate(d2);

                    campo = splitFecha[0].replace("_pnp", "").replace("_pn", "").replace("fec", "val_fec");
                    $("#" + campo).text(splitCampo[1]);

                }
            });
        }
    });

    //fin

    $.ajax({
        type: "POST",
        url: "/DashBoardLvl1/ChartPendientes",
        data: params,
        success: function (mems) {
            var aData = mems;
            var data1 = aData[0];
            var data2 = aData[1];
            //Grafico Studio F
            var labels = ["Sin Foto / Patronaje", "Pte Hoja de Cto / Informatica", "Telas / Telas", "Insumos / Insumos", "Tiempos / Corte", "Procesos / Oficina Tecnica", "Ruta / Oficina Tecnica", "Maquila / Oficina Tecnica"];
            //var values = ["1", "2", "3", "4", "5", "6", "7", "8"];
            var aLabels = labels;
            var aDatasets1 = data1;
            var dataT = {
                labels: aLabels,
                datasets: [{
                    label: "STUDIO F",
                    data: aDatasets1,
                    fill: false,
                    backgroundColor: ["rgba(54, 162, 235, 0.2)", "rgba(255, 99, 132, 0.2)", "rgba(255, 159, 64, 0.2)", "rgba(255, 205, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(201, 203, 207, 0.2)"],
                    borderColor: ["rgb(54, 162, 235)", "rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)", "rgb(75, 192, 192)", "rgb(153, 102, 255)", "rgb(201, 203, 207)"],
                    borderWidth: 1
                }]
            };
            var ctx = $("#myChart").get(0).getContext("2d");
            var myNewChart = new Chart(ctx, {
                type: 'horizontalBar',
                data: dataT,
                options: {
                    responsive: false,
                    title: { display: true, text: 'STUDIO F' },
                    legend: { position: 'bottom' }
                }
            });

            //Grafico Ela
            labels = ["Sin Foto / Patronaje", "Pte Hoja de Cto / Informatica", "Telas / Telas", "Insumos / Insumos", "Tiempos / Corte", "Procesos / Oficina Tecnica", "Ruta / Oficina Tecnica", "Maquila / Oficina Tecnica"];
            aLabels = labels;
            aDatasets1 = data2;
            dataT = {
                labels: aLabels,
                datasets: [{
                    label: "ELA",
                    data: aDatasets1,
                    fill: false,
                    backgroundColor: ["rgba(54, 162, 235, 0.2)", "rgba(255, 99, 132, 0.2)", "rgba(255, 159, 64, 0.2)", "rgba(255, 205, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(201, 203, 207, 0.2)"],
                    borderColor: ["rgb(54, 162, 235)", "rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)", "rgb(75, 192, 192)", "rgb(153, 102, 255)", "rgb(201, 203, 207)"],
                    borderWidth: 1
                }]
            };
            ctx = $("#myChart2").get(0).getContext("2d");
            myNewChart = new Chart(ctx, {
                type: 'horizontalBar',
                data: dataT,
                options: {
                    responsive: false,
                    title: { display: true, text: 'ELA' },
                    legend: { position: 'bottom' }
                }
            });
        }
    });
}

function FiltroMarca() {
    $.ajax({
        url: '/DashBoardLvl1/FiltroMarca',
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
        url: '/DashBoardLvl1/FiltroColeccion',
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

function cb(start, end, id) {
    //$("#" + id + " span").html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
    var Marca = $("#lista1 input").val();
    var Coleccion = $("#lista2 input").val();
    if (Marca.length === 0 && Coleccion.length === 0) {
        alerta("Debe seleccionar los filtros!", "Falta información para realizar la busqueda.")
    }
    else {
        $("#" + id + " span").html(start.format('YYYY/MM/DD') + ' - ' + end.format('YYYY/MM/DD'));
        var Fecha = $("#" + id + " span").text();
        var params = { Id: id, Marca, Coleccion, Fecha };
        if (id.includes("_pnp")) {
            $.ajax({
                type: "POST",
                url: "/DashBoardLvl1/ReferenciasAprobadasPNP",
                data: params,
                success: function (mems) {
                    var campo = id.replace("_pnp", "").replace("fec", "val_fec");
                    $("#" + campo).text(mems);
                }
            });
        } else {
            $.ajax({
                type: "POST",
                url: "/DashBoardLvl1/ReferenciasAprobadasPN",
                data: params,
                success: function (mems) {
                    var campo = id.replace("_pn", "").replace("fec", "val_fec");
                    $("#" + campo).text(mems);
                }
            });
        }
    }
}

$(function () {
    //COMPONENTE LISTA AUTOCOMPLETABLE
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
                .addClass("form-control input-sm input-dashboard")
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
                .addClass("ui-button ui-widget ui-button-icon-only custom-combobox-toggle ui-corner-right ref input-dashboard")
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
    $("#Coleccion").combobox({ select: function (event, ui) { CargarDashBoard(); /*alert(ui.item.value);*/ } });
    FiltroMarca();

    //FIN COMPONENTE AUTOCOMPLETABLE

    //PLACEHOLDER FILTROS
    $("#lista1 input").attr("placeholder", "Marca");
    $("#lista2 input").attr("placeholder", "Colección");
    //FIN

    var start = moment().subtract(29, 'days');
    var end = moment();

    $("div[name='reportrange']").each(function () {
        var id = $(this).attr("id");
        $("#" + id).each(function () {
            $(this).daterangepicker({
                startDate: start,
                endDate: end,
                opens: 'left',
                locale: {
                    cancelLabel: 'Clear'
                }
            }, function (start, end) {
                cb(start, end, id);
            });
        });

        $('#' + id).on('cancel.daterangepicker', function (ev, picker) {
            //do something, like clearing an input
            var Marca = $("#lista1 input").val();
            var Coleccion = $("#lista2 input").val();
            if (Marca.length === 0 && Coleccion.length === 0) {
                alerta("Debe seleccionar los filtros!", "Falta información para realizar la busqueda.")
            }
            else {
                var Fecha = "";
                var params = { Id: id, Marca, Coleccion, Fecha };
                if (id.includes("_pnp")) {
                    $.ajax({
                        type: "POST",
                        url: "/DashBoardLvl1/ReferenciasAprobadasPNP",
                        data: params,
                        success: function (mems) {
                            var campo = id.replace("_pnp", "").replace("fec", "val_fec");
                            $("#" + campo).text("");
                            $('#' + id + ' span').text('');
                        }
                    });
                } else {
                    $.ajax({
                        type: "POST",
                        url: "/DashBoardLvl1/ReferenciasAprobadasPN",
                        data: params,
                        success: function (mems) {
                            var campo = id.replace("_pn", "").replace("fec", "val_fec");
                            $("#" + campo).text("");
                            $('#' + id + ' span').text('');
                        }
                    });
                }
            }
        });
    });
});