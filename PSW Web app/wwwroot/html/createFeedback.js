$(document).ready(function () {

    let form = $("#feedbackForm");
    form.submit(function (event) {

        event.preventDefault();
        let comment = $("#comment");
        let anonymous = $("#anonymous");        // uzimamo potrebne podatke
        let publish = $("#publish");

        let anonymousBool = false;
        if(anonymous.val() === "on"){
            anonymousBool = true;
        }

        let publishBool = false;
        if(publish.val() === "on"){
            publishBool = true;
        }


        $.post({
            url: "http://localhost:49153/api/feedback",
            data: JSON.stringify({ content: comment.val(), isAnonymous: anonymousBool, publish: publishBool }),
            success: function () {
                alert("Uspesno ste poslali komentar")
            },
            contentType: "application/json; charset=utf-8"
        })
    })
})