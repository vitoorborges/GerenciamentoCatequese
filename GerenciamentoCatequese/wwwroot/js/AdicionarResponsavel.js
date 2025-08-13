function AdicionarOuEditarResponsavel() {
    let formData = new FormData(document.getElementById('AdicionarResponsavel'));

    const params = new URLSearchParams();
    formData.forEach((value, key) => {
        params.append(key, value);
    });

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/Catequisando?handler=AdicionarResponsavel", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    var token = document.querySelector('input[name="__RequestVerificationToken"]').value;
    xhr.setRequestHeader("RequestVerificationToken", token);

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                var data = JSON.parse(xhr.responseText);

                if (data.success) {
                    alert("✅ " + data.message);

                    let idResponsavel = data.responsavel.idResponsavelCatequisando; // ID retornado do backend
                    let row = document.querySelector(`tr[data-id='${idResponsavel}']`);

                    if (row) {
                        // Atualizar linha existente (edição)
                        row.querySelector(".nome").textContent = data.responsavel.nomeResponsavel;
                        row.querySelector(".text-secondary:nth-child(2)").textContent = data.responsavel.idTipoParentesco;
                        row.querySelector(".text-secondary:nth-child(3)").textContent = data.responsavel.telefoneCelular;
                    } else {
                        // Criar um novo elemento <tr> e preencher com os dados do novo responsável
                        let newRow = document.createElement("tr");
                        newRow.setAttribute("data-id", idResponsavel);
                        newRow.innerHTML = `
                            <td class="nome">${data.responsavel.nomeResponsavel}</td>
                            <td class="text-secondary">${data.responsavel.idTipoParentesco}</td>
                            <td class="text-secondary">${data.responsavel.telefoneCelular}</td>
                            <td>
                                <div class="btn-list flex-nowrap">
                                    <div class="dropdown">
                                        <button class="btn dropdown-toggle align-text-top" data-bs-toggle="dropdown">
                                            Ações
                                        </button>
                                        <div class="dropdown-menu dropdown-menu-end">
                                            <a class="dropdown-item edit-link">Editar</a>
                                            <input type="hidden" value="${idResponsavel}" class="id-documento" />
                                            <input type="hidden" value="${data.idCatequisandoEditar}" id="IdCatequisandoEditar" />
                                            <a class="dropdown-item" href="#">Finalizar</a>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        `;

                        document.querySelector("table tbody").appendChild(newRow);
                        
                    }

                    // Fechar o modal após adicionar/editar o responsável
                    var modal = bootstrap.Modal.getInstance(document.getElementById("modal-responsavel"));
                    modal.hide();
                } else {
                    alert("❌ Erro ao processar os dados!");
                }
            } else {
                console.error("Erro:", xhr.statusText);
                alert("❌ Erro ao processar a requisição");
            }
        }
    };

    xhr.send(params.toString());
}
