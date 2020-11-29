$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "../api/apikey/all",
        contentType: "application/json",
        success: function (apiDb) {
            if (apiDb) {
                viewApis(apiDb)
            }
        },
    });
});

function viewApis(apiDb) {
    for (api of apiDb) {
        content = "<tr><td>";
        content += api.nameOfPharmacy;
        content += "</td><td>";
        content += api.apiKey;
        content += "</td><td>";
        content += api.url;
        content += "</td></tr>";

        $("#apiTable").append(content);
    }
}
