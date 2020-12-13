$(document).ready(function () {

    $('#create_feedback').click(function (event) {
        var origin = window.location.origin;
        window.location.href = origin + "/html/createFeedback.html"
    });

    $('#view_feedbak_user').click(function (event) {
        var origin = window.location.origin;
        window.location.href = origin + "/html/viewFeedbackUser.html"
    });

    $('#view_feedbak_admin').click(function (event) {
        var origin = window.location.origin;
        window.location.href = origin + "/html/viewFeedbackAdmin.html"
    });

    $('#view_documents').click(function (event) {
        var origin = window.location.origin;
        window.location.href = origin + "/html/viewDocuments.html"
    });

    $('#survey').click(function (event) {
        var origin = window.location.origin;
        window.location.href = origin + "/html/survey.html"
    });

    $('#view_survey').click(function (event) {
        var origin = window.location.origin;
        window.location.href = origin + "/html/viewSurvey.html"
    });

    $('#registration').click(function (event) {
        var origin = window.location.origin;
        window.location.href = origin + "/html/registration.html"
    });

    $('#block_users').click(function (event) {
        var origin = window.location.origin;
        window.location.href = origin + "/html/blockUsers.html"
    });

    $('#patientFile').click(function (event) {
        var origin = window.location.origin;
        window.location.href = origin + "/html/viewPatientFile.html"
    });

    $('#recommendation').click(function (event) {
        var origin = window.location.origin;
        window.location.href = origin + "/html/appointmentRecommendation.html"
    });
});