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

                   iCodSubContrata.SetValue(data[0].iCodSubContrata);
                   iCodContratistaContrato.SetValue(data[0].iCodContratistaContrato);
                   dFechaIni.SetText(data[0].dFechaIni);
                   dFechaFin.SetText(data[0].dFechaFin);
                   cSolicitante.SetText(data[0].cSolicitante);
                   cObs.SetText(data[0].cObs);

                   TablaRegistrosDetalle.PerformCallback();

                   if (data[0].iEstado == 1) {
                       BtnGuardar.SetEnabled(false);
                       BtnConfirmarEnviar.SetEnabled(true);

                       iCodSubContrata.SetEnabled(false);
                       iCodContratistaContrato.SetEnabled(false);
                       dFechaIni.SetEnabled(false);
                       dFechaFin.SetEnabled(false);
                       cSolicitante.SetEnabled(false);
                       cObs.SetEnabled(false);

                       //BtnImprimirFormatoConvocatoria.SetEnabled(false);
                   }
                   else if (data[0].iEstado == 2) {
                       BtnGuardar.SetEnabled(false);
                       BtnConfirmarEnviar.SetEnabled(false);

                       //BtnImprimirFormatoConvocatoria.SetEnabled(false);
                   }
                   else if (data[0].iEstado == 3) {
                       BtnGuardar.SetEnabled(true);
                       BtnConfirmarEnviar.SetEnabled(true);

                       //BtnImprimirFormatoConvocatoria.SetEnabled(false);
                   }
                   else if (data[0].iEstado == 4) {
                       BtnGuardar.SetEnabled(false);
                       BtnConfirmarEnviar.SetEnabled(false);


                       //BtnImprimirFormatoConvocatoria.SetEnabled(false);
                   }
                   else if (data[0].iEstado == 5) {
                       BtnGuardar.SetEnabled(false);
                       BtnConfirmarEnviar.SetEnabled(false);


                       BtnImprimirFormatoConvocatoria.SetEnabled(true);
                   }
                   else if (data[0].iEstado == 6) {
                       BtnGuardar.SetEnabled(false);
                       BtnConfirmarEnviar.SetEnabled(false);

                       //BtnImprimirFormatoConvocatoria.SetEnabled(false);
                   }
                   else {
                       BtnGuardar.SetEnabled(false);
                       BtnConfirmarEnviar.SetEnabled(false);

                       BtnImprimirFormatoConvocatoria.SetEnabled(false);
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

function HabilitarControlesPopupPrincipal(_pTipo) {

    if (_pTipo == "Habilitar") {
        iCodSubContrata.SetEnabled(true);
        iCodContratistaContrato.SetEnabled(true);
        dFechaIni.SetEnabled(true);
        dFechaFin.SetEnabled(true);
        cSolicitante.SetEnabled(true);
        cObs.SetEnabled(true);
    }
    else if (_pTipo == "Deshabilitar") {
        iCodSubContrata.SetEnabled(false);
        iCodContratistaContrato.SetEnabled(false);
        dFechaIni.SetEnabled(false);
        dFechaFin.SetEnabled(false);
        cSolicitante.SetEnabled(false);
        cObs.SetEnabled(false);
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
