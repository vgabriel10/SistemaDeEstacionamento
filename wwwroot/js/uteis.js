
// Funções Uteis

/**
 * @param {string} idTabela - Id da tabela.
 * @param {string} tamanhoTabela - Tamanho da tabela no seguinte formato -> 800px
 *                                 | por padrão vem com esse valor.
 * */
function CarregarTabela(idTabela,tamanhoTabela = '800px'){
    $('#'+idTabela).DataTable({
        language: {
            /*url: "../lib/traducao-datatables/pt_br.json"*/
            url: "//cdn.datatables.net/plug-ins/1.11.3/i18n/pt_br.json"
        },
        scrollCollapse: true,
        scrollY: tamanhoTabela
    })
}



//Debug

function RetornarUrlAtual() {
    let diretorioAtual = window.location.pathname;
    console.log(diretorioAtual);
}






