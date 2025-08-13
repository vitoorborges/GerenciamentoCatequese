function carregarDadosPagamento(idCatequisando) {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', `/Catequisando?handler=BuscarDadosPagamento&id=${idCatequisando}`, true);

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            var data = JSON.parse(xhr.responseText);

            console.log(data);

            // Preencher os checkboxes dos documentos
            document.querySelectorAll('.documento-checkbox').forEach(checkbox => {
                let doc = data.documentos.find(d => d.idTipoDocumento == checkbox.dataset.id);
                checkbox.checked = doc ? doc.entregue : false;
            });

            // Preencher os selects dos locais dos documentos não entregues
            document.querySelectorAll('.documento-local').forEach(select => {
                let doc = data.documentos.find(d => d.idTipoDocumento == select.dataset.id);

                if (doc) {
                    if (!doc.entregue) {
                        select.value = doc.localDocumento;
                        select.disabled = false; // Garante que o campo fique habilitado se o documento não foi entregue
                    } else {
                        select.disabled = true; // Desativa o campo se o documento foi entregue
                        select.value = ""; // Opcional: Limpa o valor do select quando desativado
                    }
                }
            });

            // Preencher os campos do pagamento
            if (data.pagamento.nomeResponsavelPagamento != null) {
                document.getElementById('ResponsavelPagamento').value = data.pagamento.nomeResponsavelPagamento || "";
                document.getElementById('DataPagamento').value = data.pagamento.dataPagamento.split("T")[0] || "";
            }

            // Selecionar o tipo de pagamento (Pix ou Dinheiro)
            let radios = document.getElementsByName("radios-inline");
            radios.forEach(radio => {
                if (parseInt(radio.value) == data.pagamento.idTipoPagamento) {  // Ajustado para usar data.idTipoPagamento
                    radio.checked = true;
                }
            });
        }
    };

    xhr.send();
};