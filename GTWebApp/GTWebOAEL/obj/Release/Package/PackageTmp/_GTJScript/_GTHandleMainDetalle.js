function CloseFormMainModal(pResult) {
    var pConfigForm = (cFormMetadata.Get('pConfigForm'));
    var pResultCli = pResult;
    //alert("1");
    if (pConfigForm == 'MainDetalle') {       
        if (parseInt(pResultCli) > 0) {
            cFormMetadata.Set("cTipoOpe", "M");
            iCodRegistro.SetText(pResult);       
            TablaRegistrosDetalle.PerformCallback('LoadAfterInsert');
            ShowAlertMessage("Datos guardados con éxito.");
        }
        else {
            //alert("2");
            var popupWindow = PopupFormMainCli.GetWindow(0);
            PopupFormMainCli.HideWindow(popupWindow);
        }
    }   
}