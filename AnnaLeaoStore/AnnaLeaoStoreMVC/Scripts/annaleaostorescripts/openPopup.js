function OpenPopup(pageUrl, pageTitle) {
    var $pageContent = $('<div/>');
    $pageContent.load(pageUrl, function () {


    });

    var $dialog = $('<div class="popupWindow modal" ></div>')
        .html($pageContent)
        .dialog({
            draggable: false,
            autoOpen: false,
            resizable: false,
            model: true,
            modal: true,
            title: pageTitle,
            height: 600,
            width: 650,
            close: function () {
                $dialog.dialog('destroy').remove();
            },
            buttons: [
            {
                "text": "Salvar",
                "click": function () {
                    var url = $('#popupForm')[0].action;
                    $.ajax({
                        type: "POST",
                        url: url,
                        data: $('#popupForm').serialize(),
                        success: function (data) {
                            if (data.status) {
                                $dialog.dialog('close');
                            } else {
                                swal("Falhou!", data.responseText, "error");
                            }
                        }
                    });
                }
                }, {
                    "text": "Sair",
                    "click": function () {
                        $(this).dialog("close");
                    }
                }],
            open: function (event) {
                $('.ui-dialog-buttonpane').find('button:contains("Sair")').addClass('btn btn-danger');
                $('.ui-dialog-buttonpane').find('button:contains("Salvar")').addClass('btn btn-primary');
            }

        });

    $dialog.dialog('open');
}
