$(document).ready(function () {

    getAllMedicationStock();

    $("#btnSendMedication").click(function () {
        askPharmacy();
    });

    $(".close").click(function () {
        $(".modalMed").hide(200);
    });
});


function getAllMedicationStock() {
    $.ajax({
        method: "GET",
        url: "../api/medication",
        contentType: "application/json",
        success: function (allMeds) {
            $("#viewMedication").empty();
            $("#viewMedication").append('<a class="dropdown-item" href="#" onClick="setName(\'All medications\')">All medications</a>');
            for (let med of allMeds) {
                let content = '<a class="dropdown-item" href="#" onClick="setName(\'' + med.name + '\')">';
                content += med.name;
                content += '</a>';

                $("#viewMedication").append(content);
            }
        },
    });
}

function askPharmacy() {
    var medicationName = $("#phName").text();
    var pharmacyName = $("#phName").text();

    let uri;
    if (medicationName == 'All medications')
        uri = "../api/grpc/medications/" + pharmacyName;
    else
        uri = "../api/grpc/available/" + medicationName + "/" + pharmacyName; 
    $.ajax({
        method: "GET",
        url: uri,             
        contentType: "text/plain",
        success: function (data) {
            $('#write').html("It's sent to pharmacy. Soon you will get response.");
            $("#stockAction").show();
            $("#btnOk").click(function () {
                $("#txtResponse").val(data);
            });
        },
    });
}

function setName(name) {
    $("#btnMed").html(name);
}
