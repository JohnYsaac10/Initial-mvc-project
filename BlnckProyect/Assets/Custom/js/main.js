function GeneralPost(postTo, objToSend, CBfuncion) {
    var token = $('input[name="__RequestVerificationToken"]');
    token = token.length > 0 ? token.val() : '';
    $(".bg-primary").addClass("bg-loader");
    $.ajax({
        type: "POST",
        traditional: true,
        cache: false,
        url: postTo,
        context: document.body,
        headers: { "__RequestVerificationToken": token },
        data: objToSend,
        success: function (result) {
            if (result.error.code == '200')
                CBfuncion(result);
            else
                alertify.error(result.error.message);
            //$(".bg-primary").removeClass("bg-loader");
        },
        error: function (xhr) {
            alertify.error("Upps! algo salió mal. servicio no disponible. intente mas tarde");
            //$(".bg-primary").removeClass("bg-loader");
        }
    });
}

function CustomPost(postTo, objToSend, CBfuncion) {
    var token = $('input[name="__RequestVerificationToken"]');
    token = token.length > 0 ? token.val() : '';
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        type: "POST",
        dataType: 'json',
        cache: false,
        url: postTo,
        headers: { "__RequestVerificationToken": token },
        context: document.body,
        data: objToSend,
        success: function (result) {
            if (result.error.code == '200') {
                if (result.error.message) alertify.success(esult.error.message);
                CBfuncion(result);
            }
            else
                alertify.error(result.error.message);
        },
        error: function (xhr) {
            alertify.error("Upps! algo salió mal. servicio no disponible. intente mas tarde");
        }
    });
}
