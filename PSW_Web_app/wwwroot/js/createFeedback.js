$(document).ready(function () {

    let form = $("#feedbackForm");
    form.submit(function (event) {

        event.preventDefault();
        let comment = $("#comment");
        let anonymous = document.getElementById('anonymous');
        let private = document.getElementById('private');
        let patient = "Jack Smith";

        if (jQuery.trim(comment.val()) != '') {
            let anonymousBool = false;
            if (anonymous.checked) {
                anonymousBool = true;
            }

            let privateBool = false;
            if (private.checked) {
                privateBool = true;
            }

            $.post({
                url: "http://localhost:49153/api/feedback",
                data: JSON.stringify({ content: comment.val(), isAnonymous: anonymousBool, isPrivate: privateBool, patient: patient}),
                success: function () {
                    alert("Uspesno ste poslali komentar")
                },
                contentType: "application/json; charset=utf-8"
            })
        }
        else {
            alert("Unesite komentar u odgovarajuce polje")
            comment.css("border-width","5px")
            comment.css("borderColor", "red")
        }

    })
})