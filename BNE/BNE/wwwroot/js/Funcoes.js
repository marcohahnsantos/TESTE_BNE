//function LimpaValor(valor, validos, tammax) {
//    var result = "";
//    var aux;
//    for (var i = 0; i < valor.length; i++) {
//        aux = validos.indexOf(valor.substring(i, i + 1));
//        if (aux >= 0) {
//            if (result.length < tammax - 1) {
//                result += aux;
//            }
//        }
//    }
//    return result;
//}
//function FormataValor(campo, tammax, teclapres, decimal, ptmilhar, ptdecimal) {
//    var tecla = teclapres.keyCode;
//    vr = LimpaValor(campo.value, "0123456789", tammax);
//    tam = vr.length;
//    dec = decimal;
//    if (tam < tammax && tecla != 8) { tam = vr.length + 1; }
//    if (tecla == 8) { tam = tam - 1; }
//    if (tecla == 8 || tecla >= 48 && tecla <= 57 || tecla >= 96 && tecla <= 105) {
//        if (tam <= dec) { campo.value = vr; }
//        else if ((tam > dec) && (tam <= dec + 3)) {
//            //alert(tam);
//            campo.value = vr.substr(0, tam - dec) + ptdecimal + vr.substr(tam - dec, tam);
//        } else if ((tam >= dec + 4) && (tam <= dec + 6)) {
//            campo.value = vr.substr(0, tam - 3 - dec) + ptmilhar + vr.substr(tam - 3 - dec, 3) + ptdecimal + vr.substr(tam - dec, 12);
//        } else if ((tam >= dec + 7) && (tam <= dec + 9)) {
//            campo.value = vr.substr(0, tam - 6 - dec) + ptmilhar + vr.substr(tam - 6 - dec, 3) + ptmilhar + vr.substr(tam - 3 - dec, 3) + ptdecimal + vr.substr(tam - dec, 12);
//        } else if ((tam >= dec + 10) && (tam <= dec + 12)) {
//            campo.value = vr.substr(0, tam - 9 - dec) + ptmilhar + vr.substr(tam - 9 - dec, 3) + ptmilhar + vr.substr(tam - 6 - dec, 3) + ptmilhar + vr.substr(tam - 3 - dec, 3) + ptdecimal + vr.substr(tam - dec, 12);
//        } else if ((tam >= dec + 13) && (tam <= dec + 15)) {
//            campo.value = vr.substr(0, tam - 12 - dec) + ptmilhar + vr.substr(tam - 12 - dec, 3) + ptmilhar + vr.substr(tam - 9 - dec, 3) + ptmilhar + vr.substr(tam - 6 - dec, 3) + ptmilhar + vr.substr(tam - 3 - dec, 3) + ptdecimal + vr.substr(tam - dec, 12);
//        } else if ((tam >= dec + 16) && (tam <= dec + 18)) {
//            campo.value = vr.substr(0, tam - 15 - dec) + ptmilhar + vr.substr(tam - 15 - dec, 3) + ptmilhar + vr.substr(tam - 12 - dec, 3) + ptmilhar + vr.substr(tam - 9 - dec, 3) + ptmilhar + vr.substr(tam - 6 - dec, 3) + ptmilhar + vr.substr(tam - 3 - dec, 3) + ptdecimal + vr.substr(tam - dec, 12);
//        } else if ((tam >= dec + 19) && (tam <= dec + 21)) {
//            campo.value = vr.substr(0, tam - 18 - dec) + ptmilhar + vr.substr(tam - 18 - dec, 3) + ptmilhar + vr.substr(tam - 15 - dec, 3) + ptmilhar + vr.substr(tam - 12 - dec, 3) + ptmilhar + vr.substr(tam - 9 - dec, 3) + ptmilhar + vr.substr(tam - 6 - dec, 3) + ptmilhar + vr.substr(tam - 3 - dec, 3) + ptdecimal + vr.substr(tam - dec, 12);
//        } else if ((tam >= dec + 22) && (tam <= dec + 24)) {
//            campo.value = vr.substr(0, tam - 21 - dec) + ptmilhar + vr.substr(tam - 21 - dec, 3) + ptmilhar + vr.substr(tam - 18 - dec, 3) + ptmilhar + vr.substr(tam - 15 - dec, 3) + ptmilhar + vr.substr(tam - 12 - dec, 3) + ptmilhar + vr.substr(tam - 9 - dec, 3) + ptmilhar + vr.substr(tam - 6 - dec, 3) + ptmilhar + vr.substr(tam - 3 - dec, 3) + ptdecimal + vr.substr(tam - dec, 12);
//        } else {
//            campo.value = vr.substr(0, tam - 24 - dec) + ptmilhar + vr.substr(tam - 24 - dec, 3) + ptmilhar + vr.substr(tam - 21 - dec, 3) + ptmilhar + vr.substr(tam - 18 - dec, 3) + ptmilhar + vr.substr(tam - 15 - dec, 3) + ptmilhar + vr.substr(tam - 12 - dec, 3) + ptmilhar + vr.substr(tam - 9 - dec, 3) + ptmilhar + vr.substr(tam - 6 - dec, 3) + ptmilhar + vr.substr(tam - 3 - dec, 3) + ptdecimal + vr.substr(tam - dec, 12);
//        }
//    }
    function mydate() {
        //alert("");
        document.getElementById("dt").hidden = false;
        document.getElementById("ndt").hidden = true;
    }
    function mydate1() {
        d = new Date(document.getElementById("dt").value);
        dt = d.getDate();
        mn = d.getMonth();
        mn++;
        yy = d.getFullYear();
        document.getElementById("ndt").value = dt + "/" + mn + "/" + yy
        document.getElementById("ndt").hidden = false;
        document.getElementById("dt").hidden = true;
    }
    function forceKeyPressUppercase(e)
      {
        var charInput = e.keyCode;
        if((charInput >= 97) && (charInput <= 122)) { // lowercase
          if(!e.ctrlKey && !e.shiftKey && !e.metaKey && !e.altKEY) { // no modifier key
            var newChar = charInput - 32;
            var start = e.target.selectionStart;
            var end = e.target.selectionEnd;
            e.target.value = e.target.value.substring(0, start) + String.fromCharCode(newChar) + e.target.value.substring(end);
            e.target.setSelectionRange(start+1, start+1);
            e.preventDefault();
          }
        }
      }

      document.getElementById("field1").addEventListener("keypress", forceKeyPressUppercase, false);
      document.getElementById("field2").addEventListener("keypress", forceKeyPressUppercase, false);
}