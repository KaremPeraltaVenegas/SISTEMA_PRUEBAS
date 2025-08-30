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
										cDNI.SetText(data.cDNI);
										cUbigeo.SetText(data.cUbigeo);
										cApellidos.SetText(data.cApellidos);
										cNombres.SetText(data.cNombres);
										cSexo.SetText(data.cSexo);
										cEstCivil.SetText(data.cEstCivil);
										cFono.SetText(data.cFono);
										cCorreo.SetText(data.cCorreo);
										dFechaNac.SetText(data.dFechaNac);
										cLugarNac.SetText(data.cLugarNac);
										cDireccion.SetText(data.cDireccion);
										cCondicion.SetText(data.cCondicion);
										cPuestoEspecialidad.SetText(data.cPuestoEspecialidad);
										cOcupacion.SetText(data.cOcupacion);
										cOcupacion2.SetText(data.cOcupacion2);
										cEducaSecundaria.SetText(data.cEducaSecundaria);
										cEducaTecnica.SetText(data.cEducaTecnica);
										cEducaSuperior.SetText(data.cEducaSuperior);
										cExpLaboral.SetText(data.cExpLaboral);
										cEmprEx1.SetText(data.cEmprEx1);
										cCargoEx1.SetText(data.cCargoEx1);
										dFechaIniEx1.SetText(data.dFechaIniEx1);
										dFechaFinEx1.SetText(data.dFechaFinEx1);
										cEmprEx2.SetText(data.cEmprEx2);
										cCargoEx2.SetText(data.cCargoEx2);
										dFechaIniEx2.SetText(data.dFechaIniEx2);
										dFechaFinEx2.SetText(data.dFechaFinEx2);
										cComunidad.SetText(data.cComunidad);
										cMOCMONC.SetText(data.cMOCMONC);
										cObservacion.SetText(data.cObservacion);
										cAptitud.SetText(data.cAptitud);
										cUbigeoResidencia.SetText(data.cUbigeoResidencia);
										dFechaDisponible.SetText(data.dFechaDisponible);
										cCapacitacion.SetText(data.cCapacitacion);
										cLicenciaConducir.SetText(data.cLicenciaConducir);
										cCertificacion.SetText(data.cCertificacion);
										iPAsertividad.SetText(data.iPAsertividad);
										iPTrabajoEquipo.SetText(data.iPTrabajoEquipo);
										iPComEfectiva.SetText(data.iPComEfectiva);
										iPAdaptabilidad.SetText(data.iPAdaptabilidad);
										iEEstable.SetText(data.iEEstable);
										iEInestable.SetText(data.iEInestable);
										iCCompromiso.SetText(data.iCCompromiso);
										iSRptoNorma.SetText(data.iSRptoNorma);
										iSIperC.SetText(data.iSIperC);
										iSActitud.SetText(data.iSActitud);
										dFechaRegistro.SetText(data.dFechaRegistro);
										iCodUsuarioRegistra.SetText(data.iCodUsuarioRegistra);
										dFechaEvaluacion.SetText(data.dFechaEvaluacion);
										bEvaluado.SetText(data.bEvaluado);
										dFechaVerificativa.SetText(data.dFechaVerificativa);
										bVerificativa.SetText(data.bVerificativa);
										iEstadoVerificativa.SetText(data.iEstadoVerificativa);
										iResultadoVerificativa.SetText(data.iResultadoVerificativa);
										dFechaCargaBox.SetText(data.dFechaCargaBox);
										bSustentoCV.SetText(data.bSustentoCV);
										bContratado.SetText(data.bContratado);
										bCargaBox.SetText(data.bCargaBox);
										bDNIMoq.SetText(data.bDNIMoq);
										bCasadoMoq.SetText(data.bCasadoMoq);
										bConviveMoq.SetText(data.bConviveMoq);
										bHijosMoq.SetText(data.bHijosMoq);
										bRucMoq.SetText(data.bRucMoq);
										bEstudioMoq.SetText(data.bEstudioMoq);
										bTrabajoMoq.SetText(data.bTrabajoMoq);
										cTipoDoc.SetText(data.cTipoDoc);
										iTipoIngreso.SetText(data.iTipoIngreso);
										cPaisNacimiento.SetText(data.cPaisNacimiento);
										iTiempoExperiencia.SetText(data.iTiempoExperiencia);
										cDNIConyuge.SetText(data.cDNIConyuge);
										cUbigeoConyuge.SetText(data.cUbigeoConyuge);
										cApellidosConyuge.SetText(data.cApellidosConyuge);
										cNombresConyuge.SetText(data.cNombresConyuge);
										cDNIHijo.SetText(data.cDNIHijo);
										cUbigeoHijo.SetText(data.cUbigeoHijo);
										cApellidosHijo.SetText(data.cApellidosHijo);
										cNombresHijo.SetText(data.cNombresHijo);
										bComunidadPadron.SetText(data.bComunidadPadron);
										bComunidadConstancia.SetText(data.bComunidadConstancia);
										bCip.SetText(data.bCip);
										bCumplePefil.SetText(data.bCumplePefil);
										bDisponible.SetText(data.bDisponible);
										dFechaEmisionDni.SetText(data.dFechaEmisionDni);
										cEmpresaTrabaja.SetText(data.cEmpresaTrabaja);
										dFechaEvaluacionResultado.SetText(data.dFechaEvaluacionResultado);
										iCodPersonaEvalua.SetText(data.iCodPersonaEvalua);
										bDiscapacitado.SetText(data.bDiscapacitado);
										bPrioritario.SetText(data.bPrioritario);
										iCodUsuario.SetText(data.iCodUsuario);
										dFechaSis.SetText(data.dFechaSis);

 },
               fail: function (result) {
                   alert("FAIL " + result.status + ' ' + result.statusText);
               },
               error: function (result) {
                   alert("ERROR " + result.status + ' ' + result.statusText);
               }
           });
}
