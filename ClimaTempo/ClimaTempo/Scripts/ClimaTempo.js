////$(document).ready(function () {
////    debugger;
////    alert('sample');
////    var status = $('#status');
////    $('#frmTemplateUpload').ajaxForm({
////        beforeSend: function () {
////            if ($("#file").val() != "") {
////                //$("#uploadTemplate").hide();
////                $("#btnAction").hide();
////                $("#progressBarDiv").show();
////                //progress_run_id = setInterval(progress, 300);
////            }
////            status.empty();
////        },
////        success: function () {
////            showTemplateManager();
////        },
////        complete: function (xhr) {
////            if ($("#file").val() != "") {
////                var millisecondsToWait = 500;
////                setTimeout(function () {
////                    //clearInterval(progress_run_id);
////                    $("#uploadTemplate").show();
////                    $("#btnAction").show();
////                    $("#progressBarDiv").hide();
////                }, millisecondsToWait);
////            }
////            status.html(xhr.responseText);
////        }
////    });
////});

function CallClickFunction(cidade) {

    var url = "/Home/Send";
    $.post(url, {
        parameter: cidade
    }, function (data) {
        alert(data);
    });
}