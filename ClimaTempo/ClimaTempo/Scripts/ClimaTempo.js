function CallClickFunction(cidade) {

    var url = "/Home/Send";
    $.get(url, {
        cidade: cidade
    }, function (response) {
        response = JSON.parse(response);
        $(response).each(function (i) {
            document.writeln("<p>Clima: " + response[i].Clima)
        });
        //JSON.parse(response), $("#TableId");
    });
}