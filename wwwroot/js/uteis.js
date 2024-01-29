
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


// Calendario JQuery




function carregarCampoData(idCampoData, dataMinima, dataMaxima, textoToolTipBotaoCalendario) {
    if (idCampoData.search('#') === -1) idCampoData = '#' + idCampoData;

    if (textoToolTipBotaoCalendario === undefined || textoToolTipBotaoCalendario == null || textoToolTipBotaoCalendario === '') {
        textoToolTipBotaoCalendario = 'Selecione uma data';
    }

    if ((dataMinima === undefined || dataMinima == null) && (dataMaxima === undefined || dataMaxima == null)) {

    }
    else if (dataMaxima === true) {
        dataMaxima = new Date();
    }
    else {
        if (dataMinima === undefined) {
            dataMinima = null;
        }

        if (dataMaxima === undefined) {
            dataMaxima = null;
        }
    }

    //$(idCampoData).datepicker({
    //    showOn: "button",
    //    //buttonImage: "Scripts/jquery-ui/images/calendar.gif",
    //    buttonImageOnly: true,
    //    buttonText: textoToolTipBotaoCalendario,
    //    dateFormat: "dd/mm/yy",
    //    maxDate: dataMaxima,
    //    minDate: dataMinima,
    //    changeMonth: true,
    //    changeYear: true
    //});

    $(idCampoData).datepicker({
        showOn: 'button',
        buttonImage: '/assets/calendario-vermelho-branco.png',
        buttonImageOnly: true,
        /*buttonText: textoToolTipBotaoCalendario,*/
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        maxDate: dataMaxima,
        minDate: dataMinima,
        nextText: 'Próximo',
        prevText: 'Anterior'
    });

    $(idCampoData).datepicker("option", $.datepicker.regional["pt-BR"]);
}




//Debug

function RetornarUrlAtual() {
    let diretorioAtual = window.location.pathname;
    console.log(diretorioAtual);
}






