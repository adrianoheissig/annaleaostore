var $excluir = $('.tablecontainer').on('click', 'a.remove', function(e) {
                e.preventDefault();
                var url = e.currentTarget;
                swal({
                    title: "Deseja Excluir?",
                    text: "Excluindo, todos os dados do Cliente serão perdidos!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Sim",
                    closeOnConfirm: false,
                    cancelButtonText: "Cancelar"
                }, function() {
                    $.ajax({
                        type: "GET",
                        url: url,
                        success: function(response) {
                            if (response.success) {
                                swal("Sucesso!", response.responseText, "success");
                            } else {
                                swal("Falhou!", response.responseText, "error");
                            }
                            oTable.ajax.reload();
                        }
                    });
                });
            });
