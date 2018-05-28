$(document).ready(function () {
    var titulo;
    if ($("#ID").val() > 0)
        titulo = "Atualizado";
    else
        titulo = "Cadastrado";

    //Grava o Preco
    $("#frmCadastrarPrecos").submit(function (e) {
        var url = "/Cadastros/Precos/Atualizar/";
        $.ajax({
            type: "POST",
            url: url,
            data: $("#frmCadastrarPrecos").serialize(),
            success: function (response) {
                if (response.status) {
                    CarregaItens(response.data);
                } else {
                    swal("Falhou!", response.responseText, "error");
                }
            }
        });
        e.preventDefault();
    });

    $("#Sair").on("click", function () {
        location = "/Cadastros/Precos/Consulta";
    })

    function CarregaItens(idPedido) {

        var url = "/Cadastros/PrecosItens/ListarItens";

        $.ajax({
            url: url
            , type: "GET"
            , data: { id: idPedido }
            , datatype: "json"
            , success: function (data) {
                var divItens = $("#divItens");
                divItens.empty();
                divItens.show();
                divItens.html(data);
            }
        });

    }

    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Pedido/Create"] input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

});
