
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


function LimparFormulario(idFormulario) {
    $('#' + idFormulario +'').each(function () {
        this.reset();
    });
}

// Dialog

function AlertaSucessoComBotao(titulo, texto = '', textoBotao = 'Ok') {
    Swal.fire({
        title: titulo,
        text: texto,
        icon: 'success',
        confirmButtonText: textoBotao
    });
}

function AlertaErroComBotao(titulo, texto, textoBotao = 'Ok', rodape = '') {
    Swal.fire({
        icon: "error",
        title: titulo,
        text: texto,
        confirmButtonText: textoBotao,
        footer: '<a href="#">' + rodape + '</a>'
    });
}


function AlertaSucessoSemBotao(texto, tempo = 3500) {
    const Toast = Swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: tempo,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.onmouseenter = Swal.stopTimer;
            toast.onmouseleave = Swal.resumeTimer;
        }
    });
    Toast.fire({
        icon: "success",
        title: texto
    });
}

function AlertaErroSemBotao(texto, tempo = 3500) {
    const Toast = Swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: tempo,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.onmouseenter = Swal.stopTimer;
            toast.onmouseleave = Swal.resumeTimer;
        }
    });
    Toast.fire({
        icon: "error",
        title: texto
    });
}

function AlertaAvisoSemBotao(texto, tempo = 3500) {
    const Toast = Swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: tempo,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.onmouseenter = Swal.stopTimer;
            toast.onmouseleave = Swal.resumeTimer;
        }
    });
    Toast.fire({
        icon: "warning",
        title: texto
    });
}


//Debug

function RetornarUrlAtual() {
    let diretorioAtual = window.location.pathname;
    console.log(diretorioAtual);
}






