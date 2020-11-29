$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "../api/apikey/all",
        contentType: "application/json",
        data: jsonApi,
        success: function (data) {
            if (data) {
                alert("Succesfully loaded from database");
            }
        },
    });
});
