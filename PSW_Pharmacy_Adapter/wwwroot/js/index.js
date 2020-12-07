$(document).ready(function () {
    $("#testDugme").click(function () {
        $.ajax({
            method: "GET",
            url: "../api/medication/getAll",
            contentType: "application/json",
            success: function (data) {
                alert(data.id);
            },
        });
    })
    
});