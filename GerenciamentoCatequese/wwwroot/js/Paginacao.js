
    document.addEventListener("DOMContentLoaded", function () {
    const searchNome = document.getElementById("searchNome");
    const filterTurma = document.getElementById("filterTurma");
    const tableBody = document.getElementById("tabela-body");
    const tableRows = Array.from(tableBody.getElementsByTagName("tr"));

    const pageSize = 5;
    let currentPage = 1;
    let filteredRows = [...tableRows];  // Começa mostrando tudo

    // Criar lista única de turmas e preencher o select
    const turmas = new Set();
    tableRows.forEach(row => {
        const turma = row.querySelector(".turma").textContent.trim();
    if (turma) turmas.add(turma);
    });
    turmas.forEach(turma => {
        const option = document.createElement("option");
    option.value = turma;
    option.textContent = turma;
    filterTurma.appendChild(option);
    });

    function showPage(page) {
        const totalPages = Math.ceil(filteredRows.length / pageSize);
    currentPage = Math.min(Math.max(page, 1), totalPages || 1);

        // Oculta todas as linhas
        tableRows.forEach(row => row.style.display = "none");

    // Exibe apenas as linhas da página atual
    filteredRows.slice((currentPage - 1) * pageSize, currentPage * pageSize)
            .forEach(row => row.style.display = "table-row");

    document.getElementById("page-info").textContent = `Página ${currentPage} de ${totalPages || 1}`;
    }

    function filtrarTabela() {
        const nomeFiltro = searchNome.value.toLowerCase();
    const turmaFiltro = filterTurma.value;

        filteredRows = tableRows.filter(row => {
            const nome = row.querySelector(".nome").textContent.toLowerCase();
    const turma = row.querySelector(".turma").textContent.trim();

    const matchNome = nome.includes(nomeFiltro);
    const matchTurma = turmaFiltro === "" || turma === turmaFiltro;

    return matchNome && matchTurma;
        });

    currentPage = 1; // volta para primeira página ao filtrar
    showPage(currentPage);
    }

    // Eventos
    searchNome.addEventListener("input", filtrarTabela);
    filterTurma.addEventListener("change", filtrarTabela);

    document.getElementById("btnNext").addEventListener("click", () => {
        if (currentPage < Math.ceil(filteredRows.length / pageSize)) {
        showPage(currentPage + 1);
        }
    });
    document.getElementById("btnPrev").addEventListener("click", () => {
        if (currentPage > 1) {
        showPage(currentPage - 1);
        }
    });

    showPage(1); // exibe a primeira página ao carregar
});

