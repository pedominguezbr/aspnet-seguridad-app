function habilitaFechaExpiracion(checkbox, txtCuenta, rfvFechaExpiracion) {

    chk = document.getElementById(checkbox);
    if (chk.checked) {
        document.getElementById(txtCuenta).disabled = false;
        ValidatorEnable(document.getElementById(rfvFechaExpiracion), true);
    }
    else {
        document.getElementById(txtCuenta).value = "";
        document.getElementById(txtCuenta).disabled = true;
        ValidatorEnable(document.getElementById(rfvFechaExpiracion), false);        
    }

}

function confirmarEliminacionPermisoObjeto(nombreTreeviewData, nombreTreeview) {
    if (verificarNodoSeleccionado(nombreTreeviewData, nombreTreeview)) {
        return confirm('¿Esta seguro que desea eliminar el Permiso para el Objeto seleccionado?')
    }
    else {
        return false;
    }
}

function confirmarEliminacionObjeto(nombreTreeviewData, nombreTreeview) {
    if (verificarNodoSeleccionado(nombreTreeviewData, nombreTreeview)) {
        return confirm('¿Esta seguro que desea eliminar el Objeto seleccionado?')
    }
    else {
        return false;
    }
}

function verificarNodoSeleccionado(nombreTreeviewData, nombreTreeview) {

    var nodoSeleccionado = nombreTreeviewData.selectedNodeID.value
    if (nodoSeleccionado != null && nodoSeleccionado != "") {
        if(nodoSeleccionado == nombreTreeview + "t0")
        {
            alert("Debe seleccionar un Objeto.");
            return false;
        }
        else
        {
            return true;
        }
    }
    else
    {
        alert("Debe seleccionar un Objeto.");
        return false;
    }

}

//Permite que solo se ingrese caracteres dependiendo de la longitud maxima permitida
function verificaLongitudTexto(control, longitud) {
    var cadena = control.value;

    if (cadena.length >= longitud) {
        return false;
    }
}

//Corta una cadena de caracteres dependiendo de la longitud maxima permitida
function cortarLongitudTexto(control, longitud) {
    var cadena = control.value;

    if (cadena.length >= longitud) {
        cadena = cadena.substring(0, longitud)
        control.value = cadena;
    }
}

function cortarLongitudTexto_OnPaste(control, longitud, mensaje) {

    var portapapeles = clipboardData.getData("Text");
    var cadena = control.value;

    if (cadena.length + portapapeles.length > longitud) {
        alert(mensaje);
        cadena = cadena + "" + portapapeles.substring(0, longitud - cadena.length)
        control.value = cadena;

        return false;
    }
}

function habilitaCambioPassword(checkbox, txtPassword, rfvPassword) {

    chk = document.getElementById(checkbox);
    if (chk.checked) {
        document.getElementById(txtPassword).disabled = false;
        ValidatorEnable(document.getElementById(rfvPassword), true);
    }
    else {
        document.getElementById(txtPassword).value = "";
        document.getElementById(txtPassword).disabled = true;
        ValidatorEnable(document.getElementById(rfvPassword), false);
    }
}

function habilitaFechaCaduca(checkbox, txtFechaCaduca, rfvFechaCaduca) {

    chk = document.getElementById(checkbox);
    if (chk.checked) {
        document.getElementById(txtFechaCaduca).disabled = false;
        ValidatorEnable(document.getElementById(rfvFechaCaduca), true);
    }
    else {
        document.getElementById(txtFechaCaduca).value = "";
        document.getElementById(txtFechaCaduca).disabled = true;
        ValidatorEnable(document.getElementById(rfvFechaCaduca), false);
    }

}