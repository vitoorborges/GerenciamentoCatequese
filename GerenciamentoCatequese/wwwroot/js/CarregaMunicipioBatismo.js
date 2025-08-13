document.addEventListener("DOMContentLoaded", function () {
    let idCatequisandoEditarElem = document.getElementById("IdCatequisandoEditar");

    if (idCatequisandoEditarElem) {
        let idCatequisandoEditar = parseInt(idCatequisandoEditarElem.value, 10) || 0;

        if (idCatequisandoEditar !== 0) {
            let ufBatismoElem = document.getElementById("ufBatismo");

            if (ufBatismoElem && ufBatismoElem.value) {
                const ufElem = document.getElementById("ufBatismo");
                const municipioSelect = document.getElementById("municipioBatismo");

                if (!ufElem || !municipioSelect) return;

                const uf = ufElem.value;
                municipioSelect.innerHTML = '<option value="">Carregando...</option>';

                if (!uf) return;

                // Criando a requisição usando XHR para evitar problemas com async/await
                var xhr = new XMLHttpRequest();
                xhr.open("GET", `https://brasilapi.com.br/api/ibge/municipios/v1/${uf}`, true);
                xhr.setRequestHeader("Content-Type", "application/json");

                xhr.onreadystatechange = function () {
                    if (xhr.readyState === 4) {
                        if (xhr.status === 200) {
                            let municipios = JSON.parse(xhr.responseText);
                            municipioSelect.innerHTML = '<option value="">Selecione um município</option>';

                            municipios.forEach(municipio => {
                                const option = document.createElement("option");
                                option.value = municipio.nome;
                                option.textContent = municipio.nome;
                                municipioSelect.appendChild(option);
                            });

                            // Seleciona o município salvo anteriormente, se houver
                            let municipioSalvo = municipioSelect.getAttribute("data-selecionado");
                            if (municipioSalvo && municipioSelect.querySelector(`option[value="${municipioSalvo}"]`)) {
                                municipioSelect.value = municipioSalvo;
                            }

                        } else {
                            console.error("Erro ao carregar municípios para Batismo:", xhr.statusText);
                            municipioSelect.innerHTML = '<option value="">Erro ao carregar</option>';
                        }
                    }
                };

                xhr.send();

                let checkbox = document.getElementById("batizadoCheckbox");
                let campos = ["dataBatismo", "ufBatismo", "municipioBatismo", "paroquiaBatismo"];

                campos.forEach(id => {
                    let campo = document.getElementById(id);
                    if (campo) {
                        campo.disabled = !checkbox.checked;
                    }
                });
            }
        }
    }
});
