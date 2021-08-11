$("#Sinc").on("click", function () {
    var $this = $(this);
    var loadingText = '<i class="fa fa-circle-o-notch fa-spin"></i> Sincronizando...';
    var originalText = '<span class="fa fa-retweet"></span> Sincronizar Referencia';

    var Inventario = $('#Inventario option:selected').val();
    var Referencia = $("#Referencia").val();

    var params = { Inventario, Referencia };

    if (Inventario !== "" && Referencia !== "") {
        $.ajax({
            url: '/Sincronizacion/SincronizacionManual',
            method: "post",
            data: params,
            beforeSend: function () {
                if ($(this).html() !== loadingText) {
                    $this.data('original-text', $(this).html());
                    $this.html(loadingText);
                }
            },
            success: function (result) {
                $this.html(originalText);
                if (result.estado === 0) {
                    alerta("Mensaje!", result.mensaje);
                }
                else {
                    alerta("Mensaje!", result.mensaje);
                }
            },
            error: function (result) {

            }
        });
    }
    else {
        alerta("Alerta!", 'Faltan campos por diligenciar.');
    }
});