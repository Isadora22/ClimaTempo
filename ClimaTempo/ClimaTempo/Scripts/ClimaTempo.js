function CallClickFunction(cidade) {

    var url = "/Home/Send";
    $.post(url, {
        cidade: cidade
    }, function (response) {
        /*$("rData").html(data)*/
        convertJsonToHtmlTable(JSON.parse(response), $("#TableId"));
    });
}