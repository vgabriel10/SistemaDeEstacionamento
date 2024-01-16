

//$(function () {
//    $('input[name=plate]').mask('AAA 0U00', {
//        translation: {
//            'A': {
//                pattern: /[A-Za-z]/
//            },
//            'U': {
//                pattern: /[A-Za-z0-9]/
//            },
//        },
//        onKeyPress: function (value, e, field, options) {
//            // Convert to uppercase
//            e.currentTarget.value = value.toUpperCase();

//            // Get only valid characters
//            let val = value.replace(/[^\w]/g, '');

//            // Detect plate format
//            let isNumeric = !isNaN(parseFloat(val[4])) && isFinite(val[4]);
//            let mask = 'AAA 0U00';
//            if (val.length > 4 && isNumeric) {
//                mask = 'AAA-0000';
//            }
//            $(field).mask(mask, options);
//        }
//    });
//});

// ===========

function MascaraPlaca(name) {
    $('input[name=' + name + ']').mask('AAA 0U00', {
        translation: {
            'A': {
                pattern: /[A-Za-z]/
            },
            'U': {
                pattern: /[A-Za-z0-9]/
            },
        },
        onKeyPress: function (value, e, field, options) {
            // Convert to uppercase
            e.currentTarget.value = value.toUpperCase();

            // Get only valid characters
            let val = value.replace(/[^\w]/g, '');

            // Detect plate format
            let isNumeric = !isNaN(parseFloat(val[4])) && isFinite(val[4]);
            let mask = 'AAA 0U00';
            if (val.length > 4 && isNumeric) {
                mask = 'AAA-0000';
            }
            $(field).mask(mask, options);
        }
    });
}


function MascaraTelefone(id) {
    jQuery(function ($) {
        $('#' + id + '').mask('(99) 99999-9999');
        $('#' + id + '').blur(function (event) {
            if ($(this).val().length == 15) {
                $('#maskFone').mask('(99) 99999-9999');
            } else {
                $('#maskFone').mask('(99) 9999-99999');
            }
        });
    });
}

function MascaraCpf(id) {
    console.log(id);
    //let $mascaraCpf = '#' + id + '';
    //console.log(mascaraCpf);
    //$mascaraCpf.mask('000.000.000-00', { reverse: true });

    //=============

    $('#'+ id +'').mask('000.000.000-00', { reverse: true });
}


function ValidarPlaca(placa) {
    if (placa.length != 8) {
        return false;
    }
}


function ValidarCpf(cpf) {
    cpf = cpf.replace(/\D/g, '');
    if (cpf.toString().length != 11 || /^(\d)\1{10}$/.test(cpf)) return false;
    var result = true;
    [9, 10].forEach(function (j) {
        var soma = 0, r;
        cpf.split(/(?=)/).splice(0, j).forEach(function (e, i) {
            soma += parseInt(e) * ((j + 2) - (i + 1));
        });
        r = soma % 11;
        r = (r < 2) ? 0 : 11 - r;
        if (r != cpf.substring(j, j + 1)) result = false;
    });
    return result;
}


function VerificarHoraValida(hora) {
    console.log(hora);
}

function ValidarDropDownList(valor) {
    if (valor === 0 || valor === null || valor === '0' || valor === '' || valor === undefined)
        return false;
}