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
    for (api of apiDb) {
        content = '<tr><td>';
        content += api.nameOfPharmacy;
        content += '</td><td>';
        content += api.apiKey;
        content += '</td><td>';
        content += api.url;
        content += '</td><td>';
        content += '<button class="buttonDelete" id=';
        content += api.nameOfPharmacy;
        content += ' onclick="deleteEntry(this)" class="buttonDelete"> &times; </button > ';
        content += '</td></tr>'
        $("#apiTable").append(content);
    }
}

function deleteEntry(button) {
    $.ajax({
        method: "DELETE",
        url: "../api/apikey/delete/" + button.id,
        contentType: "application/json",
        success: function (data) {
            if (data) {
                alert("Successfully deleted");
                window.location.reload();
            }
        },
    });
}
