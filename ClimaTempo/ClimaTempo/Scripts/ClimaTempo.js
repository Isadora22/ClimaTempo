function CallClickFunction(cidade) {
    var url = "/Home/Send";
    $.post(url, {
        cidade: cidade
    }, function (response) {
        response = JSON.parse(response);

        var htmlText = response.map(function (o) {
            return `
                        <div class="col-md-2 col-lg-2">
                            <div class="card card-border">
                                <h5 class="card-header card-he">${o.PrevisaoVM.DiaSemana}</h5>
                                <div class="card-body">
                                    <div class="col-md-12 col-xs-12 col-sm-12">
                                        <p> ${o.PrevisaoVM.Clima}<p/>
                                        <p> Min: ${o.PrevisaoVM.TemperaturaMinima + "°C"}<p/>
                                        <p> Máx: ${o.PrevisaoVM.TemperaturaMaxima + "°C"}<p/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        `;
        });
        $('#idDiv').append(htmlText)
    });
}