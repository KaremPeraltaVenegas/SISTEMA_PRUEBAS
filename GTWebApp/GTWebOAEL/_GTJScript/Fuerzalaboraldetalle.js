function viewRecordDetalle() {
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
										//iCodFuerzaLaboral.SetText(data.iCodFuerzaLaboral);
										//iCodCandidatoInforme.SetText(data.iCodCandidatoInforme);
										//iCodSubContrata.SetText(data.iCodSubContrata);
										//cTipoCargo.SetText(data.cTipoCargo);
										//cOcupacion.SetText(data.cOcupacion);
										//cMOCMONC.SetText(data.cMOCMONC);
										//cRotacion.SetText(data.cRotacion);
										//cTurno.SetText(data.cTurno);
										//cTipoContrato.SetText(data.cTipoContrato);
										//cRegimenLaboral.SetText(data.cRegimenLaboral);
										//iHorasHombre.SetText(data.iHorasHombre);
										//cLugarPernocte.SetText(data.cLugarPernocte);
										//cAreaTrabajo.SetText(data.cAreaTrabajo);
										//dFechaIni.SetText(data.dFechaIni);
										//dFechaCese.SetText(data.dFechaCese);
										//cMotivoCese.SetText(data.cMotivoCese);
										//cObs.SetText(data.cObs);
										//iCalificacion.SetText(data.iCalificacion);
										//bDevolvioFotocheck.SetText(data.bDevolvioFotocheck);
										//bActivo.SetText(data.bActivo);
										//bCesado.SetText(data.bCesado);
										//bConsentimiento.SetText(data.bConsentimiento);
										//iPeriodo.SetText(data.iPeriodo);
										//iMes.SetText(data.iMes);
										//cGrupo.SetText(data.cGrupo);
										//cNivel.SetText(data.cNivel);
										//cUrlDoc.SetText(data.cUrlDoc);
										//iCodUsuarioModifica.SetText(data.iCodUsuarioModifica);
										//dFechaModifica.SetText(data.dFechaModifica);
										//iCodUsuarioCierra.SetText(data.iCodUsuarioCierra);
										//dFechaCierre.SetText(data.dFechaCierre);
										//iCodUsuario.SetText(data.iCodUsuario);
										//dFechaSis.SetText(data.dFechaSis);

 },
               fail: function (result) {
                   alert("FAIL " + result.status + ' ' + result.statusText);
               },
               error: function (result) {
                   alert("ERROR " + result.status + ' ' + result.statusText);
               }
           });
}
