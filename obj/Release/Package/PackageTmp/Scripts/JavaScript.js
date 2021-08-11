function alerta(titulo, mensaje) {
    $.alert({
        title: titulo,
        content: mensaje
    });
}

function alerta_ok(titulo, mensaje) {
    $.alert({
        title: titulo,
        content: mensaje,
        buttons: {
            Confirmar: function () {
                refrescarFrame();
            }
        }
    });
}

var x = window.matchMedia("(max-width: 992px)");
myFunction(x) // Call listener function at run time
x.addListener(myFunction) // Attach listener function on state changes

function myFunction(x) {
    if (x.matches) { // If media query matches
        $("body").removeClass("sidenav-toggled");
    } else {
        $("body").addClass("sidenav-toggled");
    }
}

function bs_input_file() {
    $(".input-file").before(
        function () {
            if (!$(this).prev().hasClass('input-ghost')) {
                var element = $("<input type='file' class='input-ghost' style='display:none; height:0'>");
                element.attr("name", $(this).attr("name"));
                element.change(function () {
                    element.next(element).find('input').val((element.val()).split('\\').pop());
                });
                $(this).find("button.btn-choose").click(function () {
                    element.click();
                });
                $(this).find("button.btn-reset").click(function () {
                    element.val(null);
                    $(this).parents(".input-file").find('input').val('');
                });
                $(this).find('input').css("cursor", "pointer");
                $(this).find('input').mousedown(function () {
                    $(this).parents('.input-file').prev().click();
                    return false;
                });
                return element;
            }
        }
    );
}
$(function () {
    bs_input_file();
});