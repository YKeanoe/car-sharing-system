var userPos = { lat: "", lng: "" };

function getLocation() {
    var dfd = $.Deferred();
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            userPos = { lat: position.coords.latitude, lng: position.coords.longitude }
            console.log(userPos);
            dfd.resolve();
        }, function () {
            dfd.reject();
        });
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
        reject();
    }
    console.log("getlocation done");
    return dfd.promise();
}

function sendUserLoc() {
    var dfd = $.Deferred();
    $.ajax({
        type: "POST",
        url: "/Views/admincaradd.aspx/setLoc",
        data: JSON.stringify(userPos),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            console.log("Location send succ");
            dfd.resolve();
        },
        failure: function () {
            console.error("Location send error");
            dfd.reject();
        }
    });
    return dfd.promise();
}


$(window).on('load', function () {
    var dfd = $.Deferred();
    var getLocationStatus = getLocation();
    getLocationStatus.then(sendUserLoc).done(function () {
        dfd.resolve();
        console.log("set user done");
    })
});