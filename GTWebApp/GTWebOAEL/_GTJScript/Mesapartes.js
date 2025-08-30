var tipoAccionPopupConfirm = "";
// #region Controles del Popup

    // #region Busqueda por DNI
    function cDNI_KeyPress(s, e) {
        if ((e.htmlEvent.keyCode >= 48 && e.htmlEvent.keyCode <= 57) || (e.htmlEvent.keyCode >= 65 && e.htmlEvent.keyCode <= 90) || (e.htmlEvent.keyCode >= 97 && e.htmlEvent.keyCode <= 122)) { return true; }
        else {
            ASPxClientUtils.PreventEvent(e.htmlEvent);
        }
        if (e.htmlEvent.keyCode == 13) {
            s.Validate();
            if (s.isValid) {
                viewRecordCI();
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
            viewRecordCI();
        }
    }
    // #endregion

    function LimpiarControlesPopup() {
        ASPxClientEdit.ClearEditorsInContainer(FormLayoutPopup.GetMainElement());
    }

    function bImprocedente_onCheckBoxChanged(s, e) {

        var checked = s.GetChecked();
        if (checked) {
            s.SetText("No procede el Trámite");
        } else {
            s.SetText("Procede el Trámite");
        }
    }

    function bDocumentoTramite_onCheckBoxChanged(s, e) {

        var checked = s.GetChecked();
        if (checked) {
            s.SetText("No Presenta Documentos");
        } else {
            s.SetText("Si Presenta Documentación");
        }
    }

    function bActualizaDatosContacto_onCheckBoxChanged(s, e) {

        var checked = s.GetChecked();
        if (checked) {
            s.SetText("Actualizar Datos de Contacto");
        } else {
            s.SetText("Sin Acciones");
        }
    }

    function OnBtnGuardarClickCustom(s, e) {
        if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopup.GetMainElement(), null, true)) {

            var nombres = cNombres.GetValue().trim(); 
            var apellidos = cApellidos.GetValue().trim();
            var mensaje = "";

            const codCandidatoInforme = parseInt(iCodCandidatoInforme.GetText(), 10);
            const codCandidatoAdmisionTipo = parseInt(iCodCandidatoAdmisionTipo.GetValue(), 10);
            const bCargaBoxChecked = bCargaBox.GetChecked();
/*            const codConvocatoria = iCodConvocatoria.GetValue();*/

            // Si existe trabajador, y si escogió Registro nuevo y tiene expediente
            if (codCandidatoInforme > 0 &&
                codCandidatoAdmisionTipo === 1 &&
                bCargaBoxChecked)
            {
                ShowAlertMessage('La persona ya cuenta con expediente. No procede el REGISTRO NUEVO');
                return null;
            }

            // Si existe trabajador, y si escogió Registro nuevo
            if (codCandidatoInforme > 0 &&
                codCandidatoAdmisionTipo === 1) {
                ShowAlertMessage('La persona ya cuenta con un trámite existente. No procede el REGISTRO NUEVO');
                return null;
          
            }

/*            CRecord.bRequierePostulacion = false;*/

            //// Si es del tipo POSTULACION
            //if (codCandidatoAdmisionTipo === 2) {
            //    CRecord.bRequierePostulacion = true;
            //} else {
            //    CRecord.bRequierePostulacion = false;
            //}

            //// Si requiere postulación y no tiene convocatoria
            //if (CRecord.bRequierePostulacion && !codConvocatoria) {
            //    ShowAlertMessage('Ha seleccionado el trámite POSTULACIÓN. Debe seleccionar un perfil vigente.');
            //    return null;
            //}

            //Guarda uno existente 
            if (!bCargaBoxChecked && codCandidatoAdmisionTipo !== 1) {

                mensaje = "El postulante no cuenta con expediente. <br />" +
                    "¿Seguro de registrar el trámite de ACTUALIZACIÓN del postulante seleccionado? <br />" +
                    "<b>" + nombres + " " + apellidos + "</b>";

                tipoAccionPopupConfirm = "SIN_EXPE";
            } else {
                mensaje = "¿ Seguro de Agregar al postulante Seleccionado ?" +
                    "<b>" + nombres + " " + apellidos + "</b>";

                tipoAccionPopupConfirm = "CON_EXPE";
            }

            lblMensajeConfirmacion.SetText(mensaje); 
            lblMensajeConfirmacion.EncodeHtml = false;

            var popupWindow = PopupAlertMessageConfirm.GetWindow(0);
            PopupAlertMessageConfirm.ShowWindow(popupWindow);

        }
        else {
            e.processOnServer = false;
        }
    }

    function CloseFormPopupMain() {
        var popupWindow = PopupFormMain.GetWindow(0);
        PopupFormMain.HideWindow(popupWindow);
    }

// #endregion

// #region Funciones Adicionales
function viewRecordCI() {

    var pNroDoc = cDNI.GetValue().trim();
    var pTipoDoc = cTipoDoc.GetValue();
    var pTable = (cFormMetadata.Get('pTable'));

    //Verificar que TipoDoc no sea null o vacio
    if (!pTipoDoc ) {
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
    bCargaBox.SetChecked(false);
    cBloqueadoRegistroActualizacion.SetText('');
    cFechaFinBloqueo.SetText('');
    cFechaFinObservado.SetText('');
    cCondicion.SetValue('');

    cNombres.SetText('Buscando ...');
    cNombres.SetEnabled(false);
    cApellidos.SetText('Buscando ...');
    cApellidos.SetEnabled(false);
    cCUI.SetText('');
    cSexo.SetValue('');
    dFechaNac.SetText('');
    cUbigeo.SetValue('');
    cUbigeoResidencia.SetValue('');
    cCorreo.SetText('');

    $("#mensajeRegistrado").html("Situaci&oacute;n : ");
    $("#mensajeEvaluado").html("Evaluado : ");
    $("#mensajeExpediente").html("Expediente : ");

    iCodTDCondicionSustento.SetValue('');
    cEstCivil.SetText('');
    cTelefono.SetText('');

    iCodCandidatoAdmisionTipo.SetValue('');
    iCodCandidatoAdmisionOrigen.SetValue('');
    cObs.SetText('');
    bImprocedente.SetChecked(false);
    bDocumentoTramite.SetChecked(false);
    bActualizaDatosContacto.SetChecked(false);

    var cb = bImprocedente;
    bImprocedente_onCheckBoxChanged(cb, null);
    var cb2 = bDocumentoTramite;
    bDocumentoTramite_onCheckBoxChanged(cb2, null);
    var cb3 = bActualizaDatosContacto;
    bActualizaDatosContacto_onCheckBoxChanged(cb3, null);

    iCodTDCondicionSustento.SetEnabled(true);

    $.ajax(
        {
            url: pTable + ".aspx/GetRecordPersonaCI",
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
                    
                    $("#mensajeRegistrado").html("Situaci&oacute;n : <b>REGISTRADO</b>");
                    $("#mensajeRegistrado").removeClass("infoDanger").addClass("infoOK");

                    if (data[0].bEvaluado == 'True') {
                        $("#mensajeEvaluado").html("Evaluado : <b>SI</b>");
                        $("#mensajeEvaluado").removeClass("infoDanger").addClass("infoOK");
                    }
                    else {
                        $("#mensajeEvaluado").html("Evaluado : <b>NO</b>");
                        $("#mensajeEvaluado").removeClass("infoOK").addClass("infoDanger");
                    }

                    if (data[0].bCargaBox == 'True') {
                        $("#mensajeExpediente").html("Expediente : <b>SI</b>");
                        $("#mensajeExpediente").removeClass("infoDanger").addClass("infoOK");
                        bCargaBox.SetChecked(true);
                    }
                    else {
                        $("#mensajeExpediente").html("Expediente : <b>NO</b>");
                        $("#mensajeExpediente").removeClass("infoOK").addClass("infoDanger");
                        bCargaBox.SetChecked(false);
                    }

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

                    if (data[0].cCondicion == 'LOCAL') {
                        iCodTDCondicionSustento.SetValue(2);
                    }
                    else if (data[0].cCondicion == 'RESIDENTE') {
                        iCodTDCondicionSustento.SetValue(3);
                    }
                    else if (data[0].cCondicion == 'COMUNIDAD') {
                        iCodTDCondicionSustento.SetValue(3);
                    } else {
                        iCodTDCondicionSustento.SetValue(16);
                    }
                    iCodTDCondicionSustento.SetEnabled(false);
                   
                    cEstCivil.SetValue(data[0].cEstCivil);
                    cCorreo.SetValue(data[0].cCorreo);
                    cTelefono.SetValue(data[0].cFono);

                    $.ajax({
                        url: pTable + ".aspx/GetHabilitadoActualizacion",
                        data: JSON.stringify({ pICodCandidatoInforme: data[0].iCodCandidatoInforme }),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (response) {
                            var data = response.d;
                            data = $.parseJSON(data);

                            cBloqueadoRegistroActualizacion.SetText(data[0].cBloqueaRegistroActualizacion);
                            cFechaFinBloqueo.SetText(data[0].cFechaFinBloqueo);
                            cFechaFinObservado.SetText(data[0].cFechaFinObservado);

                        },
                        error: function (xhr, status, error) {
                            ShowAlertMessage("ERROR " + xhr.status + ' ' + xhr.statusText);
                        }
                    });
                }
                else {

                    $("#mensajeRegistrado").html("Situaci&oacute;n : <b>NO REGISTRADO</b>");
                    $("#mensajeRegistrado").removeClass("infoOK").addClass("infoDanger");
                    $("#mensajeEvaluado").html("Evaluado : <b>NO</b>");
                    $("#mensajeEvaluado").removeClass("infoOK").addClass("infoDanger");
                    $("#mensajeExpediente").html("Expediente : <b>NO</b>");
                    $("#mensajeExpediente").removeClass("infoOK").addClass("infoDanger");

                    $.ajax(
                        {
                            url: pTable + ".aspx/GetRecordPersonaReniec",
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
                                ShowAlertMessage("FAIL " + result.status + ' ' + result.statusText);
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
                                ShowAlertMessage("ERROR " + result.status + ' ' + result.statusText);
                            }
                        });
                    cApellidos.SetEnabled(true);
                    cNombres.SetEnabled(true);
                }
            },
            fail: function (result) {
                ShowAlertMessage("FAIL " + result.status + ' ' + result.statusText);
            },
            error: function (result) {
                ShowAlertMessage("ERROR " + result.status + ' ' + result.statusText);
            }
        });
}
function ShowAlertMessage(pMsg) {
    var pMsgLocal = pMsg;
    PopupAlertMessage.SetContentHtml(pMsgLocal);
    PopupAlertMessage.ShowAtPos(document.documentElement.clientWidth, document.documentElement.clientHeight);
    setTimeout(function () { PopupAlertMessage.Hide(); }, 5000);
}

function OnCancelarClickMessageConfirm() {
    var popupWindow = PopupAlertMessageConfirm.GetWindow(0);
    PopupAlertMessageConfirm.HideWindow(popupWindow);
}

function OnAceptarClickMessageConfirm() {
    CallBackFunction.PerformCallback(tipoAccionPopupConfirm);
}

function DeleteRecord(e, s) {

    var cID = iCodRegistro.GetValue();
    var pTable = (cFormMetadata.Get('pTable'));


    $.ajax(
        {
            url: pTable + ".aspx/GetRecordAdmision",
            data: "{'pID':" + cID + "}",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (response) {

                var data = response.d;
                data = $.parseJSON(data);
                var iCant = data.length;
                if (iCant > 0) {

                    if (data[0].iCodCandidatoAdmisionTipo == 1) {

                        var popupWindow = PopupConfirmDelete.GetWindow(0);
                        PopupConfirmDelete.HideWindow(popupWindow);
                        ShowAlertMessage('No se puede eliminar por ser Registro NUEVO.');
                    }
                    else {

                        $.ajax(
                            {
                                url: pTable + ".aspx/DeleteRecord",
                                data: "{'pID':" + cID + "}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (response) {
                                    if (response.d == "OK") {
                                        var popupWindow = PopupConfirmDelete.GetWindow(0);
                                        PopupConfirmDelete.HideWindow(popupWindow);
                                        TablaRegistros.PerformCallback();
                                        ShowAlertMessage('El Registro se borró con éxito.');
                                        e.processOnServer = false;
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
                }
                else {
                    ShowAlertMessage('Debe seleccionar un registro.');
                    e.processOnServer = false;
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

function CloseFormConfirmDelete(e, s) {
    var popupWindow = PopupConfirmDelete.GetWindow(0);
    PopupConfirmDelete.HideWindow(popupWindow);
    e.processOnServer = false;
}

//function OnBtnLimpiarPerfil(s, e) {
//    iCodConvocatoria.SetText('');
//    iCodConvocatoria.SetSelectedIndex(-1);
//}

// #endregion