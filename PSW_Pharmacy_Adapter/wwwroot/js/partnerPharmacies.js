$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "../api/apikey/all",
        contentType: "application/json",
        success: function (apiDb) {
            if (apiDb) {
                viewApis(apiDb)
                $(".loader").css("display", "none");
                $("#apiTable").css("display", "table");
            }
        },
    });
});

function viewApis(apiDb) {
    for (let api of apiDb) {
        let content = '<tr><td>';
        content += api.nameOfPharmacy;
        content += '</td><td>';
        content += api.apiKey;
        content += '</td><td>';
        content += api.url;
        content += '</td><td>';
        content += '<button class="btn btn-danger" data-toggle="modal" data-target="#deletePharmacyModal"';
        content += ' onclick="deleteEntry(\'' + api.nameOfPharmacy + '\')"> &times; </button></td> ';
        content += '<td><button class="btn btn-primary"';
        content += ' onclick="getMedications(\'' + api.nameOfPharmacy + '\')"> Medication stock</button> ';
        content += '</td></tr>'
        $("#apiTable").append(content);
    }
}

function deleteEntry(id) {
    $("#nameToDelete").html(id);
    $("#deletePharmacy").show();
    $("button#btnYes").click(function () {
        $.ajax({
            method: "DELETE",
            url: "../api/apikey/delete/" + id,
            contentType: "application/json",
            success: function (data) {
                if (data) {
                    window.location.reload();
                }
            },
        });
    })
}


function getMedicines(id) {
    $.ajax({
        method: "GET",
        url: "../api/medication/check/" + id,
        contentType: "application/json",
        success: function (changes) {
            if (changes) {
                for (let med in changes)
                    alert("Changes detected for:" + med.id + " !!!");
            } else {
                alert("All good. No differences in medication structure");
            }
        },
    });
}

function getMedications(event) {
    //window.location.assign(window.location.origin += "/api/viewMedicationStock.html?id=" + event.id);
    window.location.assign(window.location.origin += "/viewMedicationStock.html");
}