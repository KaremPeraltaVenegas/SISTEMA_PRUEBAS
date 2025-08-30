function viewRecord() {
    var cID = iCodRegistro.GetValue();
    var pTable = (cFormMetadata.Get('pTable'));

    $.ajax(
           {
               url: pTable + ".aspx/GetRecord",
               data: "{'pID':" + cID + "}",
               dataType: "json",
               type: "POST",
               contentType: "application/json; charset=utf-8",
               success: function (response) {
                   var data = response.d;
                   data = $.parseJSON(data);

                    cNroContrato.SetText(data[0].cNroContrato);
                   cNomContrato.SetValue(data[0].cNomContrato);
                   cZona.SetValue(data[0].cZona);
                   dFechaTermino.SetText(data[0].dFechaTermino);
                   iHeadCount.SetText(data[0].iHeadCount);
                    cAreaUsuaria.SetText(data[0].cAreaUsuaria);
                   cAreaUsuariaSupervisor.SetText(data[0].cAreaUsuariaSupervisor);
                   cDatosContacto.SetText(data[0].cDatosContacto);
                   cObs.SetText(data[0].cObs);

                   if (data[0].bCerrado == 1 || data[0].iEstado == 5) {

                       HabilitarControlesPopupPrincipal("Deshabilitar")
                   }
                   else {

                       HabilitarControlesPopupPrincipal("Habilitar")
                   }

               },
               fail: function (result) {
                   alert("FAIL " + result.status + ' ' + result.statusText);
               },
               error: function (result) {
                   alert("ERROR " + result.status + ' ' + result.statusText);
               }
           });
}


function OnToolbarItemClickCustom(s, e) {

    if (IsCustomExportToolbarCommand(e.item.name)) {
        e.processOnServer = true;
        e.usePostBack = true;
    }

    if (e.item.name == "BtnAgregar") {

        iCodRegistro.SetText("0");
        cFormMetadata.Set("cTipoOpe", "A");
        ClearContentControls();
        FormMainModalShow();
        e.processOnServer = false;
        BtnGuardar.SetEnabled(true);

    }
    else if (e.item.name == "BtnEditar") {
        cFormMetadata.Set("cTipoOpe", "M");
        iCodRegistro.SetText(TablaRegistros.GetRowKey(TablaRegistros.GetFocusedRowIndex()));
        var popupWindow = PopupFormMainCli.GetWindow(0);
        popupWindow.SetHeaderText("Edici\u00F3n del Contrato");
        ClearContentControls();
        viewRecord();
        FormMainModalShow();
        e.processOnServer = false;
    }
    else if (e.item.name == "BtnEliminar") {
        var popupWindow = PopupConfirmDelete.GetWindow(0);
        popupWindow.SetHeaderText("Eliminaci\u00F3n del Contrato");
        PopupConfirmDelete.ShowWindow(popupWindow);
        e.processOnServer = false;
    }
    else if (e.item.name == "BtnAnular") {
        var popupWindow = PopupConfirmAnulacion.GetWindow(0);
        popupWindow.SetHeaderText("Anulaci\u00F3n del Contrato");
        PopupConfirmAnulacion.ShowWindow(popupWindow);
        e.processOnServer = false;
    }


}

function OnBtnGuardarClickCustom(s, e) {
    if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopup.GetMainElement(), null, true)) {
        CallBackFunction.PerformCallback();
    }
    else {
        e.processOnServer = false;
    }
}

function OnEndCallBackFunctionCustom(s, e) {

    var arrayItems = e.result.split('-');

    if (arrayItems[1] == "OK") {
        if (arrayItems[2] == "ED_CONT") {

            ShowAlertMessageMain('Se modifico el contrato con \u00E9xito.');
            var popupWindow = PopupFormMainCli.GetWindow(0);
            PopupFormMainCli.HideWindow(popupWindow);

        } else if (arrayItems[2] == "CR_CONT") {

            ShowAlertMessageMain('Se creo el contrato con \u00E9xito.');
            var popupWindow = PopupFormMainCli.GetWindow(0);
            PopupFormMainCli.HideWindow(popupWindow);
        }

        iCodRegistro.SetText(arrayItems[0]);
        TablaRegistros.PerformCallback();
    }
    else if (arrayItems[1] == "SIN_PUESTOS") {
        ShowAlertMessageMain('No se puede enviar porque a\u00fan no ha creado puestos.');

    } else {
        ShowAlertMessageMain('Ocurri\u00F3 un error durante el proceso.');
    }

}

function AnularRecord(e, s) {
    var cID = iCodRegistro.GetValue();
    var pTable = (cFormMetadata.Get('pTable'));

    $.ajax(
        {
            url: pTable + ".aspx/AnularRecord",
            data: "{'pID':" + cID + "}",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.d == "OK") {
                    var popupWindow = PopupConfirmAnulacion.GetWindow(0);
                    PopupConfirmAnulacion.HideWindow(popupWindow);
                    TablaRegistros.PerformCallback();
                    ShowAlertMessage('El Registro se anuló con éxito.');
                    e.processOnServer = false;
                }
                else {
                    var popupWindow = PopupConfirmAnulacion.GetWindow(0);
                    PopupConfirmAnulacion.HideWindow(popupWindow);
                    ShowAlertMessage(response.d);
                }
            },
            fail: function (result) {
                alert("FAIL " + result.status + ' ' + result.statusText);
            },
            error: function (result) {
                alert("ERROR " + result.status + ' ' + result.statusText);
            }
        });
}

function CloseFormConfirmAnulacion(e, s) {
    var popupWindow = PopupConfirmAnulacion.GetWindow(0);
    PopupConfirmAnulacion.HideWindow(popupWindow);
    e.processOnServer = false;
}

function HabilitarControlesPopupPrincipal(_pTipo) {

    if (_pTipo == "Habilitar") {

        cNroContrato.SetEnabled(true);
        cNomContrato.SetEnabled(true);
        cZona.SetEnabled(true);
        dFechaTermino.SetEnabled(true);
        iHeadCount.SetEnabled(true);
        cDatosContacto.SetEnabled(true);
        cObs.SetEnabled(true);
        cAreaUsuaria.SetEnabled(true);
        cAreaUsuariaSupervisor.SetEnabled(true);

        BtnGuardar.SetEnabled(true);
    }
    else if (_pTipo == "Deshabilitar") {

        cNroContrato.SetEnabled(false);
        cNomContrato.SetEnabled(false);
        cZona.SetEnabled(false);
        dFechaTermino.SetEnabled(false);
        iHeadCount.SetEnabled(false);
        cDatosContacto.SetEnabled(false);
        cObs.SetEnabled(false);
        cAreaUsuaria.SetEnabled(false);
        cAreaUsuariaSupervisor.SetEnabled(false);

        BtnGuardar.SetEnabled(false);
    }

}