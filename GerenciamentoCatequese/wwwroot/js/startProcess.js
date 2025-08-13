function startProcess() {
    abrirEManterPor10s();
    // Captura os dados do formulário
    let formData = new FormData(document.getElementById('SalvarDadosPessoais'));

    // Converte o FormData para URL-encoded
    const params = new URLSearchParams();
    formData.forEach((value, key) => {
        params.append(key, value);
    });

    // Criação da requisição XMLHttpRequest
    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/Catequisando?handler=SalvarDadosPessoais', true);  // Ajuste a URL conforme necessário
    xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

    // Obtém o token de verificação
    var token = document.querySelector('input[name="__RequestVerificationToken"]').value;
    xhr.setRequestHeader('RequestVerificationToken', token);

    // Define a função de callback para quando o estado da requisição mudar
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                // Sucesso no processamento da resposta
                var data = JSON.parse(xhr.responseText);
                // Aqui você pode acessar os dados retornados se necessário
                alert("✅ " + data.message);  // Exemplo de mensagem de sucesso
                console.log(data.idcatequisandoresponsavel);           
                // Executa metodo de trazer os pagamentos                       
                document.getElementById('IdCatequisandoDocumento').value = data.idcatequisandoresponsavel;
                document.getElementById('IdCatequisandoResponsavel').value = data.idcatequisandoresponsavel;
                document.getElementById('IdCatequisandoObservacao').value = data.idcatequisandoresponsavel;
                document.getElementById('IdCatequisandoEditar').value = data.idcatequisandoresponsavel;
                // Chama o método step para avançar no processo
                step('DadosPessoais', 'DadosResponsaveis', 1);  // Exemplo de como usar a função step
            } else {
                console.error('Erro:', xhr.statusText);
                alert("❌ Erro ao processar a requisição");
            }
        }
    };

    // Envia os dados do formulário no formato URL-encoded
    xhr.send(params.toString());
}  

function abrirEManterPor10s() {
    var modalElem = document.getElementById("modal-small");

    if (!modalElem) {
        console.error("Modal não encontrado!");
        return;
    }

    modalElem.style.display = "block";// Abre o modal

    setTimeout(function () {
        modalElem.style.display = "none";
    }, 3000); // 10 segundos (10000 milissegundos)
}