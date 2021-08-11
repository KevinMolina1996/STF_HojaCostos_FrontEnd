$(function () {
    // update notification
    function updateNotification() {
        var count = 0;
        $.ajax({
            type: 'GET',
            url: '/Alertas/GetNotificationContacts',
            success: function (response) {
                //$('#notiContent').empty();
                if (response.length === 0) {
                    //$('#notiContent').append($('<li>No data available</li>'));
                }
                $('#Alertas').empty();
                $.each(response, function (index, value) {
                    var date = eval(value.AlFechaD.slice(1, -1));
                    $('#Alertas').append($('<div id=' + value.AlCodigoN + '><a class="dropdown-item" href="#">' + '<span class="text-success">' + '<strong>' + '<i class="fa fa-long-arrow-up fa-fw"></i>' + value.AlCambioS + '</strong>' + '</span>' + '<span class="float-right" style="color:red;" onclick="LeeAlerta(' + value.AlCodigoN + ');">X</span>' + '<span class="small float-left text-muted">' + date.toString('yyyy-M-d') + '</span>' + '<div class="dropdown-message small">' + value.AlDescripcionS + '</a>' + '<div class="dropdown-divider"></div></div>'));
                    count = count + 1;
                });
                if (count > 0) {
                    $("#campana").addClass("animacion_alerta blanco");
                    $("#circulo").addClass("blanco");
                    $("#count").addClass("blanco");
                }
                else {
                    $("#campana").removeClass("animacion_alerta blanco");
                    $("#circulo").removeClass("blanco");
                    $("#count").removeClass("blanco");
                }
                $('#count').empty();
                $('#count').append($('<a>' + count.toString() + '</a>'));
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
    // signalr js code for start hub and send receive notification
    var notificationHub = $.connection.myHub;
    $.connection.hub.start().done(function () {
        updateNotification();
    });

    // update notification count
    function updateNotificationCount() {
        updateNotification();
        //success("Se actualizo su bandeja de alertas.");
    }

    //signalr method for push server message to client
    notificationHub.client.notify = function (message) {
        if (message && message.toLowerCase() === "added") {
            updateNotificationCount();
        }
    }
})