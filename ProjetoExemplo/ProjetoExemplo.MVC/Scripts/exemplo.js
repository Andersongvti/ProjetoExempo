$(document).ready(function () {
    RetornaTodosOsMovimentos();
    RetornaTodosOProdutos();
    RetornaTodosOProdutosCosifs();
});

var apiBaseUrl = "https://localhost:44314/";
var retorno = null;
var retornoProdutos = null;
var retornoProdutosCosif = null;

function RetornaTodosOsMovimentos() {
    $.ajax({
        url: apiBaseUrl + 'api/MovimentosManuais',
        type: 'GET',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            var html = '';
            retorno = result;
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Mes + '</td>';
                html += '<td>' + item.Ano + '</td>';
                html += '<td>' + item.CodigoDoProduto + '</td>';
                html += '<td> </td>';
                html += '<td>' + item.NumeroLancamento + '</td>';
                html += '<td>' + item.Descricao + '</td>';
                html += '<td>' + item.Valor + '</td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            console.log(errormessage.responseText);
        }
    });
}

function RetornaTodosOProdutos() {
    $.ajax({
        url: apiBaseUrl + 'api/Produtos',
        type: 'GET',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            var html = '<option value="0">-- Selecione uma opção. -- </option>';
            retornoProdutos = result;
            $.each(result, function (key, item) {
                html += '<option value="' + item.CodigoDoProduto + '">' + item.DescricaoDoProduto + '</option>';
            });

            $('#slProdutos').html(html);
        },
        error: function (errormessage) {
            console.log(errormessage.responseText);
        }
    });
}

function RetornaTodosOProdutosCosifs() {
    $.ajax({
        url: apiBaseUrl + 'api/ProdutoCosifs',
        type: 'GET',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            var html = '<option value="0">-- Selecione uma opção. -- </option>';
            retornoProdutosCosif = result;
            $.each(result, function (key, item) {
                html += '<option value="' + item.CodigoCosif + '">' + item.CodigoCosif + '-' + item.CodigoClassificacao + '</option>';
            });

            $('#slProdutoCosif').html(html);
        },
        error: function (errormessage) {
            console.log(errormessage.responseText);
        }
    });
}

function AdicionarMovimentos() {
    var res = Validate();
    if (res == false) {
        return false;
    }

    var movimentoObject = {
        Mes: $('#textMes').val(),
        Ano: $('#textAno').val(),
        CodigoCosif: $('#slProdutoCosif').val(),
        CodigoDoProduto: $('#slProdutos').val(),
        Produto: $('#textProduto').val(),
        ProdutoCosif: $('#textProdutoCosif').val(),
        Valor: $('#textValor').val(),
        Descricao: $('#textDescricao').val()
    };

    $.ajax({
        url: apiBaseUrl + 'api/MovimentosManuais',
        type: 'POST',
        data: JSON.stringify(movimentoObject),
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            RetornaTodosOsMovimentos();
        },
        error: function (errormessage) {
            console.log(errormessage.responseText);
        }
    });
}

function Validate() {
    var isValid = true;
    if ($('#textMes').val().trim() == "") {
        $('#textMes').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#textMes').css('border-color', 'lightgrey');
    }
    if ($('#textAno').val().trim() == "") {
        $('#textAno').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#textAno').css('border-color', 'lightgrey');
    }

    if ($('#slProdutos').val().trim() == "0") {
        $('#slProdutos').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#slProdutos').css('border-color', 'lightgrey');
    }

    if ($('#slProdutoCosif').val().trim() == "0") {
        $('#slProdutoCosif').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#slProdutoCosif').css('border-color', 'lightgrey');
    }

    if ($('#textValor').val().trim() == "") {
        $('#textValor').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#textValor').css('border-color', 'lightgrey');
    }

    if ($('#textDescricao').val().trim() == "") {
        $('#textDescricao').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#textDescricao').css('border-color', 'lightgrey');
    }

    return isValid;
}

function clearTextBox() {
    $('#textMes').val("").css('border-color', 'lightgrey');
    $('#textAno').val("").css('border-color', 'lightgrey');
    $('#textValor').val("").css('border-color', 'lightgrey');
    $('#textDescricao').val("").val('').css('border-color', 'lightgrey');
    $('#slProdutos').val("0").css('border-color', 'lightgrey')
    $('#slProdutoCosif').val("0").css('border-color', 'lightgrey');
}

