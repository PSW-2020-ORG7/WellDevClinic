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
        content += ' onclick="deleteEntry(\'' + api.nameOfPharmacy + '\')"> &times; </button > ';
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
                    alert("Successfully deleted");
                    window.location.reload();
                }
            },
        });
    })
}
