document.addEventListener("DOMContentLoaded", function () {
    // Event delegation para garantir que novos botões também sejam capturados
    document.addEventListener("click", function (event) {
        if (event.target.classList.contains("edit-link")) {
            let idResponsavel = event.target.closest("tr").querySelector(".id-documento").value;
            let IdCatequisandoEditar = document.getElementById("IdCatequisandoEditar").value;

            if (!idResponsavel) {
                console.error("ID do responsável não encontrado.");
                return;
            }

            let params = new URLSearchParams({ id: idResponsavel, IdCatequisandoEditarGet: IdCatequisandoEditar });
            let xhr = new XMLHttpRequest();
            xhr.open("GET", `/Catequisando?handler=GetResponsavel&` + params.toString(), true);
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    let responsavel = JSON.parse(xhr.responseText);
                    if (!responsavel) return;

                    document.getElementById("modal-responsavel").querySelector(".modal-title").textContent = "Editar Responsável";

                    document.getElementById("NomeResponsavel").value = responsavel.nomeResponsavel;
                    document.getElementById("ParentescoResponsavel").value = responsavel.idTipoParentesco;
                    document.getElementById("DataNascimentoResponsavel").value = responsavel.dataNascimentoResponsavel? responsavel.dataNascimentoResponsavel.split("T")[0] : "";
                    document.getElementById("Religiao").value = responsavel.religiao;
                    document.getElementById("ProfissaoResponsavel").value = responsavel.profissaoResponsavel;
                    document.getElementById("DataCasamento").value = responsavel.dataCasamento ? responsavel.dataCasamento.split("T")[0] : "";

                    document.getElementById("batizadoResponsavel").checked = responsavel.batismo;
                    document.getElementById("eucatistiaResponsavel").checked = responsavel.eucaristia;
                    document.getElementById("crismaResponsavel").checked = responsavel.crisma;
                    document.getElementById("matrimonioResponsavel").checked = responsavel.matrimonio;
                    document.getElementById("CheckboxDizimistaResponsavel").checked = responsavel.dizimista;
                    document.getElementById("CheckboxPastoralResponsavel").checked = responsavel.outraPastoral;

                    document.getElementById("DescricaoPastoralResponsavel").value = responsavel.descricaoOutraPastoral || "";
                    document.getElementById("CelularResponsavel").value = responsavel.telefoneCelular;
                    document.getElementById("IdResponsavelCatequisando").value = responsavel.idResponsavelCatequisando;

                    // Exibir o modal
                    let modal = new bootstrap.Modal(document.getElementById("modal-responsavel"));
                    modal.show();
                }
            };
            xhr.send();
        }
    });
});
