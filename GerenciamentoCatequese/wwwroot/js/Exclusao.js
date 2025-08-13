

var idCatequisandoExclusao = 0;
function abrirModalExclusao(elemento) {
    // Procura o input hidden mais próximo dentro do mesmo dropdown
    var idInput = elemento.closest('.dropdown-menu').querySelector('input[type="hidden"]');
    idCatequisandoExclusao = idInput.value;
    document.getElementById('idParaExcluir').value = idCatequisandoExclusao;
    $('#modalExcluir').modal('show');

    // Aqui você pode abrir o modal e usar o valor como quiser
};

function ExcluirCatequisando(){
    console.log(IdCatequisandoExcluir);
    //if (IdCatequisandoExcluir !== null) {
    //    window.location.href = "/Index?handler=ExcluirCadastro&IdCatequisando=" + encodeURIComponent(IdCatequisandoExcluir);
    //}
}

