$(document).ready(function () {
    $("#testDugme").click(function () {
        $.ajax({
            method: "GET",
            url: "../api/medication",
            contentType: "application/json",
            success: function (data) {
                alert(data[0].id);
            },
        });
    })
    
});