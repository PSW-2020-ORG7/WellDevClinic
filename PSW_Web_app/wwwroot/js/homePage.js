function authorize() {
    let token = sessionStorage.getItem("token");
    let payload = parseJwt(token);
    userType = payload["type"];
    if (userType != "Patient") {
        alert("You are not authorized for this page!!!");
        window.location.replace(window.location.protocol + "//" + window.location.host + "/html/viewFeedbackAdmin.html");
    }
}

var userType = "";
function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};