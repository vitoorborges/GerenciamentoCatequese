function salvarDocumentos() {
    let documentos = [];

    // Obtendo todos os checkboxes
    document.querySelectorAll(".documento-checkbox").forEach(checkbox => {
        let documentoId = checkbox.getAttribute("data-id");
        let entregue = checkbox.checked;

        // Captura o valor do select correspondente
        let localDocumentoElement = document.querySelector(`.documento-local[data-id="${documentoId}"]`);
        let localDocumento = localDocumentoElement ? localDocumentoElement.value : null;

        // Adiciona ao array
        documentos.push({
            idTipoDocumento: parseInt(documentoId),
            entregue: entregue,
            localDocumento: localDocumento
        });
    });

    // Captura os dados do pagamento
    let IdTipoPagamento = document.querySelector('input[name="radios-inline"]:checked')?.value;
    let NomeResponsavelPagamento = document.getElementById("ResponsavelPagamento")?.value;
    let IdCatequisando = document.getElementById("IdCatequisandoDocumento")?.value;
    let dataPagamento = document.getElementById("DataPagamento")?.value;

    let dadosEnvio = {
        Documentos: documentos,
        Pagamento: {
            IdTipoPagamento: IdTipoPagamento ? parseInt(IdTipoPagamento) : 0,
            NomeResponsavelPagamento: NomeResponsavelPagamento || null,
            DataPagamento: dataPagamento ? dataPagamento : null
        },
        IdCatequisando: IdCatequisando
    };

    // Obtendo o token de verificação CSRF
    let tokenElement = document.querySelector('input[name="__RequestVerificationToken"]');
    let token = tokenElement ? tokenElement.value : "";

    // Fazendo a requisição POST
    fetch('/Catequisando?handler=SalvarDocumentos', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': token
        },
        body: JSON.stringify(dadosEnvio)
    })
        .then(response => {
            return response.text().then(message => {
                return { status: response.status, message: message };
            });
        })
        .then(data => {
            if (data.status >= 200 && data.status < 300) { // HTTP 2xx (sucesso)
                alert("✅ " + data.message);
                step('DadosPagamento', 'ObservacoesGerais', 3);
            } else {
                alert("❌ Erro: " + data.message);
            }
        })
        .catch(error => {
            console.error("Erro ao salvar:", error);
            alert("❌ Erro ao salvar documentos. Verifique o console.");
        });
}