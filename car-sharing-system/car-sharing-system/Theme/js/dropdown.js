function dropdown() {
    var language = document.getElementById("mySelect").value;

    if (language == "English") {
        document.getElementById("language").innerHTML = "English";
    } else if (language == "Espanol") {
        document.getElementById("language").innerHTML = "Espanol";
    }else if (language == "Francais") {
        document.getElementById("language").innerHTML = "Francais";
    }
}

$("#mySelect").change(function(){
       dropdown();
});
