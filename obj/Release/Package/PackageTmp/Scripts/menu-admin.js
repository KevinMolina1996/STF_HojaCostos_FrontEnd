$("#menu li").each(function (ind, val) {
    $(this).hide();
});

$.ajax({
    type: 'POST',
    url: '/OAuth/ValidarTiempo',
    success: function (response) {
        if (response.ruta !== undefined) {
            if (response.ruta.length > 0) {
                var url = '/Login/Index';
                window.location.href = "" + url + "";
            }
        }
        else {
            $("#nombre").text(response.usuario.toString());

            //Menu dinamico

            var obj = jQuery.parseJSON(response.permisos);

            for (var i = 0; i < obj.Permissions.length; i++) {
                var split = obj.Permissions[i].funcionalidades.split(",");
                $.each(split, function (index, value) {
                    $("#menu li").each(function (ind, val) {
                        if ($.trim(value) === val.id) {
                            $(this).show();
                        }
                    });
                });
            }

            //Fin

        }
    },
    error: function (error) {
        console.log(error);
    }
});