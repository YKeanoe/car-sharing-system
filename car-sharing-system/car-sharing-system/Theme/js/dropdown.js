function dropdown() {
    var language = document.getElementById("mySelect").value;

    if (language == "English") {
        document.getElementById("language").innerHTML = "English: (03) 9560 2122";
    } else if (language == "Espanol") {
        document.getElementById("language").innerHTML = "Espanol: (03) 9560 2123";
    }else if (language == "Francais") {
        document.getElementById("language").innerHTML = "Francais: (03) 9560 2124";
    }
}

$("#mySelect").change(function(){
       dropdown();
});
