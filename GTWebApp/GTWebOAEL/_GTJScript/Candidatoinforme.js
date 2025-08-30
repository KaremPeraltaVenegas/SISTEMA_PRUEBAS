// #region  CONTROLES DEL POPUP

    // #region Busqueda por DNI
    function cDNI_KeyPress(s, e) {
        if ((e.htmlEvent.keyCode >= 48 && e.htmlEvent.keyCode <= 57) || (e.htmlEvent.keyCode >= 65 && e.htmlEvent.keyCode <= 90) || (e.htmlEvent.keyCode >= 97 && e.htmlEvent.keyCode <= 122)) { return true; }
        else {
            ASPxClientUtils.PreventEvent(e.htmlEvent);
        }
        if (e.htmlEvent.keyCode == 13) {
            s.Validate();
            if (s.isValid) {
                viewRecordPostulantePorDni();
            }
        }
    }
    function cDNI_Validation(s, e) {
        var eText = s.GetText();
        if ((eText.length < 8) || (eText.length > 15)) {

            e.isValid = false;
        }
        else {
            e.isValid = true;
        }
    }
    function cDNI_OnButtonClick(s, e) {
        s.Validate();
        if (s.isValid) {
            viewRecordPostulantePorDni();
        }
    }
    // #endregion

    // #region BOTONES DEL POPUP

    function ShowModal_Postulante(pTipoOpe) {
        ClearControls_Postulante();
        var popupWindow = PopupForm_Postulante.GetWindow(0);

        BtnGuardarPostulante.SetEnabled(true);

        if (cTipoOpePostulante.GetText() == 'A') {
            popupWindow.SetHeaderText("Agregar Registro");
        }
        else if (cTipoOpePostulante.GetText() == 'M') {
            popupWindow.SetHeaderText("Edici\u00F3n del Registro");
            viewRecord_Postulante();
        }
        else if (cTipoOpePostulante.GetText() == 'V') {
            popupWindow.SetHeaderText("Visualizaci\u00F3n del Registro");
            viewRecord_Postulante();
            BtnGuardarPostulante.SetEnabled(false);
        }

        PopupForm_Postulante.ShowWindow(popupWindow);
    }
    function CloseModal_Postulante() {
        var popupWindow = PopupForm_Postulante.GetWindow(0);
        PopupForm_Postulante.HideWindow(popupWindow);
    }
    function ClearControls_Postulante() {
        ASPxClientEdit.ClearEditorsInContainer(FormLayoutPopup_Postulante.GetMainElement());
    }
    function OnCompleteCallBackFunctionPostulante(s, e) {

        var arrayItems = e.result.split('-');

        if (arrayItems[0] == "OK") {
            if (arrayItems[1] == "ADD_REG") {

                ShowAlertMessagePostulante('Se creo el contrato con \u00E9xito.');
                CloseModal_Postulante();

            } else if (arrayItems[1] == "UPD_REG") {

                ShowAlertMessagePostulante('Se modifico el contrato con \u00E9xito.');
                CloseModal_Postulante();
            }
            TablaRegistros.PerformCallback();
        }
        else if (arrayItems[0] == "EXISTE") {
            ShowAlertMessagePostulante('Postulante ya existe. No se puede volver a ingresar.');
        }
        else if (arrayItems[0] == "FAIL") {
            ShowAlertMessagePostulante('Error interno del servicio, recargue la pagina.');

        } else {
            ShowAlertMessagePostulante('Ocurri\u00F3 un error durante el proceso.');
        }

}
    function OnBtnGuardarClick_Postulante(s, e) {
        if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopup_Postulante.GetMainElement(), null, true)) {
            CallBackFunctionPostulante.PerformCallback("GuardarRegistro");
        }
        else {
            e.processOnServer = false;
        }
    }
    function viewRecordPostulantePorDni() {

        var pNroDoc = cDNI.GetValue().trim();
        var pTipoDoc = cTipoDoc.GetValue();
        /*   var pTable = (cFormMetadataPostulante.Get('pTablePostulante'));*/

        //Verificar que TipoDoc no sea null o vacio
        if (!pTipoDoc) {
            ShowAlertMessage('Debe seleccionar el Tipo Documento.');
            pTipoDoc.focus();
            return;
        }

        //Verificar dni sea de 8 digitos y no sea null o vacio

        if (!pNroDoc || pNroDoc.length < 8) {
            ShowAlertMessage('DNI incorrecto.');
            cDNI.focus();
            return;
        }

        iCodCandidatoInforme.SetText("0");
        cNombres.SetText('Buscando ...');
        cNombres.SetEnabled(false);
        cApellidos.SetText('Buscando ...');
        cApellidos.SetEnabled(false);
        cCUI.SetText('');
        cSexo.SetValue('');
        dFechaNac.SetText('');
        cUbigeo.SetValue('');
        cUbigeoResidencia.SetValue('');
        cEstCivil.SetText('');
        cCorreo.SetText('');
        cTelefono.SetText('');
        cDireccion.SetText('');
        bCargaBox.SetChecked(false);
        cCondicion.SetText('');
        cCondicion.SetEnabled(false);
        bSustentoCV.SetChecked(false);
        bCumplePefil.SetChecked(false);
        cComunidad.SetText('');
        cMOCMONC.SetText('');
        cOcupacion1.SetText('');
        cOcupacion2.SetText('');
        cLicenciaConducir.SetText('');
        cObservacion.SetText('');
        bDiscapacitado.SetChecked(false);
        bPrioritario.SetChecked(false);

        $.ajax(
            {
                url: "/_GTController/WebServCandidatoinforme.asmx/GetRecordPostulante",
                data: "{'pNroDoc':'" + pNroDoc + "','pTipoDoc':'" + pTipoDoc + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    var data = response.d;
                    data = $.parseJSON(data);
                    var iCant = data.length;
                    if (iCant > 0) {

                        iCodCandidatoInforme.SetText(data[0].iCodCandidatoInforme);
                        cCUI.SetText(data[0].cCUI);
                        cNombres.SetText(data[0].cNombres);
                        cApellidos.SetText(data[0].cApellidos);
                        cSexo.SetValue(data[0].cSexo);

                        if (data[0].dFechaNac && data[0].dFechaNac.trim() !== "") {
                            var dt = new Date(data[0].dFechaNac);
                            var formatted = dt.getDate().toString().padStart(2, '0') + '/' +
                                (dt.getMonth() + 1).toString().padStart(2, '0') + '/' +
                                dt.getFullYear();
                            dFechaNac.SetText(formatted);
                        } else {
                            dFechaNac.SetText('1900-01-01');
                        }
                        cUbigeo.SetValue(data[0].cUbigeo);
                        cUbigeoResidencia.SetValue(data[0].cUbigeoResidencia);
                        cEstCivil.SetValue(data[0].cEstCivil);
                        cCorreo.SetText(data[0].cCorreo);
                        cTelefono.SetText(data[0].cFono);
                        cDireccion.SetText(data[0].cDireccion);
                        bCargaBox.SetChecked(data[0].bCargaBox == 1);
                        cCondicion.SetText(data[0].cCondicion);
                        bSustentoCV.SetChecked(data[0].bSustentoCV == 1);
                        bCumplePefil.SetChecked(data[0].bCumplePefil == 1);
                        cComunidad.SetText(data[0].cComunidad);
                        cMOCMONC.SetText(data[0].cMOCMONC);
                        cOcupacion1.SetText(data[0].cOcupacion1);
                        cOcupacion1.SetText(data[0].cOcupacion2);
                        cLicenciaConducir.SetText(data[0].cLicenciaConducir);
                        cObservacion.SetText(data[0].cObservacion);
                        bDiscapacitado.SetChecked(data[0].bDiscapacitado == 1);
                        bPrioritario.SetChecked(data[0].bPrioritario == 1);
                    }
                    else {


                        $.ajax(
                            {
                                url: "/_GTController/WebServCandidatoinforme.asmx/GetRecordPostulanteReniec",
                                data: "{'pDoc':'" + pNroDoc + "'}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (response) {
                                    var data = response.d;
                                    data = $.parseJSON(data);

                                    var _result = data.success;
                                    if (_result == true) {


                                        cNombres.SetText((data.nombres).trim());
                                        cApellidos.SetText((data.apellidos).trim());
                                        cCUI.SetText((data.cui).trim());
                                        cSexo.SetValue((data.sexo).trim());
                                        dFechaNac.SetText((data.fechaNacimiento).trim());
                                        cUbigeo.SetValue((data.ubigeoNaci).trim());
                                        cUbigeoResidencia.SetValue((data.ubigeoResidencia).trim());
                                        cEstCivil.SetText((data.estadoCivil).trim());
                                    }
                                    else {

                                        cNombres.SetText('');
                                        cApellidos.SetText('');
                                        cCUI.SetText('');
                                        cSexo.SetValue('');
                                        dFechaNac.SetText('');
                                        cUbigeo.SetValue('');
                                        cUbigeoResidencia.SetValue('');
                                        cUbigeoResidencia.SetText('');
                                        cEstCivil.SetText('');
                                    }
                                },
                                fail: function (result) {
                                    cNombres.SetText('');
                                    cApellidos.SetText('');
                                    cCUI.SetText('');
                                    cSexo.SetValue('');
                                    dFechaNac.SetText('');
                                    cUbigeo.SetValue('');
                                    cUbigeoResidencia.SetValue('');
                                    cUbigeoResidencia.SetText('');
                                    cEstCivil.SetText('');
                                    ShowAlertMessagePostulante("FAIL " + result.status + ' ' + result.statusText);
                                },
                                error: function (result) {
                                    cNombres.SetText('');
                                    cApellidos.SetText('');
                                    cCUI.SetText('');
                                    cSexo.SetValue('');
                                    dFechaNac.SetText('');
                                    cUbigeo.SetValue('');
                                    cUbigeoResidencia.SetValue('');
                                    cUbigeoResidencia.SetText('');
                                    cEstCivil.SetText('');
                                    ShowAlertMessagePostulante("ERROR " + result.status + ' ' + result.statusText);
                                }
                            });
                        cApellidos.SetEnabled(true);
                        cNombres.SetEnabled(true);
                    }
                },
                fail: function (result) {
                    ShowAlertMessagePostulante("FAIL " + result.status + ' ' + result.statusText);
                },
                error: function (result) {
                    ShowAlertMessagePostulante("ERROR " + result.status + ' ' + result.statusText);
                }
            });
}
    function viewRecord_Postulante() {

        var pCodRegistroPostulante = iCodRegistroPostulante.GetValue().trim();

        //Verificar que CodRegistroPostulante no sea null o vacio
        if (!pCodRegistroPostulante) {
            ShowAlertMessagePostulante('Debe seleccionar un postulante.');
            return;
        }

        iCodCandidatoInforme.SetText("0");
        cNombres.SetText('Buscando ...');
        cApellidos.SetText('Buscando ...');
        cCUI.SetText('');
        cSexo.SetValue('');
        dFechaNac.SetText('');
        cUbigeo.SetValue('');
        cUbigeoResidencia.SetValue('');
        cEstCivil.SetText('');
        cCorreo.SetText('');
        cTelefono.SetText('');
        cDireccion.SetText('');
        bCargaBox.SetChecked(false);
        cCondicion.SetText('');
        cCondicion.SetEnabled(false);
        bSustentoCV.SetChecked(false);
        bCumplePefil.SetChecked(false);
        cComunidad.SetText('');
        cMOCMONC.SetText('');
        cOcupacion1.SetText('');
        cOcupacion2.SetText('');
        cLicenciaConducir.SetText('');
        cObservacion.SetText('');
        bDiscapacitado.SetChecked(false);
        bPrioritario.SetChecked(false);

        $.ajax(
            {
                url: "/_GTController/WebServCandidatoinforme.asmx/GetRecordPostulantePorCodigo",
                data: "{'pCodRegistroPostulante':'" + pCodRegistroPostulante + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    var data = response.d;
                    data = $.parseJSON(data);
                    var iCant = data.length;
                    if (iCant > 0) {

                        iCodCandidatoInforme.SetText(data[0].iCodCandidatoInforme);
                        cTipoDoc.SetValue(data[0].cTipoDoc);
                        cDNI.SetText(data[0].cDNI);
                        cCUI.SetText(data[0].cCUI);
                        cNombres.SetText(data[0].cNombres);
                        cApellidos.SetText(data[0].cApellidos);
                        cSexo.SetValue(data[0].cSexo);

                        if (data[0].dFechaNac && data[0].dFechaNac.trim() !== "") {
                            var dt = new Date(data[0].dFechaNac);
                            var formatted = dt.getDate().toString().padStart(2, '0') + '/' +
                                (dt.getMonth() + 1).toString().padStart(2, '0') + '/' +
                                dt.getFullYear();
                            dFechaNac.SetText(formatted);
                        } else {
                            dFechaNac.SetText('1900-01-01');
                        }
                        cUbigeo.SetValue(data[0].cUbigeo);
                        cUbigeoResidencia.SetValue(data[0].cUbigeoResidencia);
                        cEstCivil.SetValue(data[0].cEstCivil);
                        cCorreo.SetText(data[0].cCorreo);
                        cTelefono.SetText(data[0].cFono);
                        cDireccion.SetText(data[0].cDireccion);
                        bCargaBox.SetChecked(data[0].bCargaBox == 1);
                        cCondicion.SetText(data[0].cCondicion);
                        bSustentoCV.SetChecked(data[0].bSustentoCV == 1);
                        bCumplePefil.SetChecked(data[0].bCumplePefil == 1);
                        cComunidad.SetText(data[0].cComunidad);
                        cMOCMONC.SetText(data[0].cMOCMONC);
                        cOcupacion1.SetText(data[0].cOcupacion1);
                        cOcupacion2.SetText(data[0].cOcupacion2);
                        cLicenciaConducir.SetText(data[0].cLicenciaConducir);
                        cObservacion.SetText(data[0].cObservacion);
                        bDiscapacitado.SetChecked(data[0].bDiscapacitado == 1);
                        bPrioritario.SetChecked(data[0].bPrioritario == 1);
                        cLicenciaConducir.SetText(data[0].cLicenciaConducir);
                        cObservacion.SetText(data[0].cObservacion);

                    }
                    else {
                        ShowAlertMessagePostulante("Postulante no encontrado");
                    }
                },
                fail: function (result) {
                    ShowAlertMessagePostulante("FAIL " + result.status + ' ' + result.statusText);
                },
                error: function (result) {
                    ShowAlertMessagePostulante("ERROR " + result.status + ' ' + result.statusText);
                }
            });
}
    function ShowAlertMessagePostulante(pMsg) {
        var pMsgLocal = pMsg;
        PopupAlertMessagePostulante.SetContentHtml(pMsgLocal);
        PopupAlertMessagePostulante.ShowAtPos(document.documentElement.clientWidth, document.documentElement.clientHeight);
        setTimeout(function () { PopupAlertMessagePostulante.Hide(); }, 5000);
    }

    // #endregion

// #endregion

// #region Funciones Adicionales

function OnCancelarClickMessageConfirm() {
    var popupWindow = PopupAlertMessageConfirm.GetWindow(0);
    PopupAlertMessageConfirm.HideWindow(popupWindow);
}

function OnAceptarClickMessageConfirm() {
    CallBackFunction.PerformCallback(tipoAccionPopupConfirm);
}


function CloseFormConfirmDelete(e, s) {
    var popupWindow = PopupConfirmDelete.GetWindow(0);
    PopupConfirmDelete.HideWindow(popupWindow);
    e.processOnServer = false;
}

// #endregion