function LimparFormularioResponsavel() {
    let form = document.getElementById('AdicionarResponsavel');

    if (form) {
        form.reset(); // Reseta todos os campos do formulário

        // Limpa campos do tipo select manualmente
        form.querySelectorAll('select').forEach(select => {
            select.selectedIndex = 0; // Define o primeiro item como selecionado
        });

        // Limpa campos ocultos e outros inputs que não sejam resetados automaticamente
        form.querySelectorAll('input[type="hidden"]').forEach(input => {
            if (input.id !== "IdCatequisandoResponsavel") { // Verifica se o id é diferente do campo que você não quer limpar
                input.value = "";
            }
        });

        console.log("🧹 Formulário limpo com sucesso!");
    } else {
        console.error("⚠️ Formulário não encontrado!");
    }
}
