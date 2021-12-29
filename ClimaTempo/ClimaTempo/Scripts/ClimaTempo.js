function CallClickFunction(cidade) {

    var url = "/Home/Send";
    $.post(url, {
        cidade: cidade
    }, function (response) {
        response = JSON.parse(response);
        $(response).each(function (i) {
            document.writeln("<p>Clima: " + response[i].PrevisaoVM.Clima)
        });
        //JSON.parse(response), $("#TableId");
    });
}