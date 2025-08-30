
function CloseFormMainModal(pResult) {
   


    
    var pResultCli = pResult;
    if (pResultCli == "OK") {
        var popupWindow = PopupFormMainCli.GetWindow(0);
        PopupFormMainCli.HideWindow(popupWindow);
        ShowAlertMessage("Datos guardados con éxito.");
    }
    else {
        ShowAlertMessage("Error de Registro.");
    }
}