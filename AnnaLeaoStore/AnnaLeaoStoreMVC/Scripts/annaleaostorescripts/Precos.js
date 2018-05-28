$(document).ready(function() {
            var titulo;
            if ($("#ID").val() > 0)
                titulo = "Atualizado";
            else
                titulo = "Cadastrado";

            $("#frmCadastrarPrecos").submit(function(e) {

                var url = "/Cadastros/Precos/Atualizar/";

                $.ajax({
                    type: "POST",
                    url: url,
                    data: $("#frmCadastrarPrecos").serialize(),
                    success: function(response) {
                        if (response.status) {
                            Voltar();
                        } else {
                            swal("Falhou!", response.responseText, "error");
                        }
                    }
                });
                e.preventDefault();
            });

            $("#Sair").on("click", function() {
                Voltar();
            })

            function Voltar() {
                location = "/Cadastros/Precos/Consulta";
            }

});
