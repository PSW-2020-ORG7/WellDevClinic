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
        error: function (e) {
            pageInfo("An error has occured while trying to load partner pharmacies!");
        }
    });
});

function viewApis(apiDb) {
    for (let api of apiDb) {
        let content = '<tr><td>';
        content += api.nameOfPharmacy;
        content += '</td><td>';
        content += api.apiKey;
        content += '</td><td>';
        content += api.url.url;
        content += '</td>';
        content += '<td><button class="btn btn-info"';
        content += ' onclick="getMedications(\'' + api.nameOfPharmacy + '\')">Medication stock</button> ';
        content += '</td><td>';
        content += '<button class="btn btn-outline-danger" data-toggle="modal" data-target="#deletePharmacyModal"';
        content += ' onclick="deleteEntry(\'' + api.nameOfPharmacy + '\')"> &times; </button> ';
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
            error: function (e) {
                pageInfo("An error has occured while trying to delete partner pharmacy!");
            }
        });
    })
}

function getMedications(id) {
    $("#phName").html(id);
    $("#txtResponse").val("");
    $("#medModal").slideDown("fast");
}

function pageInfo(text) {
    $("#message").text(text);
    $("#pageInfoModal").modal('toggle');
    $("#pageInfo").show();
}