var pCodCI_Cli;
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
                   //alert(data.iMes);
										//iCodContrata.SetText(data.iCodContrata);
										//iCodSubContratista.SetText(data.iCodSubContratista);
										iCodContratistaContrato.SetValue(data.iCodContratistaContrato);
										iPeriodo.SetValue(data.iPeriodo);
										iMes.SetValue(data.iMes);
										//bActivo.SetText(data.bActivo);
										//iCodEstado.SetText(data.iCodEstado);
										//iCodUsuario.SetText(data.iCodUsuario);
										//dFechaSis.SetText(data.dFechaSis);
										//alert(data.iPeriodo);
 },
               fail: function (result) {
                   alert("FAIL " + result.status + ' ' + result.statusText);
               },
               error: function (result) {
                   alert("ERROR " + result.status + ' ' + result.statusText);
               }
           });
}



function viewRecordDetalle() {
    var cID = iCodRegistroDetalle.GetValue();
    var pTable = (cFormMetadata.Get('pTable'));
     
    $.ajax(
           {
               url: pTable + ".aspx/GetRecordDetalle",
               data: "{'pID':" + cID + "}",
               dataType: "json",
               type: "POST",
               contentType: "application/json; charset=utf-8",
               success: function (response) {
                   var data = response.d;
                   data = $.parseJSON(data);
                   //iCodAnexoAdmision.SetText(data.iCodAnexoAdmision);
                   cDNI.SetText(data[0].cDNI);
                   //iCodCandidatoInforme.SetText(data[0].iCodCandidatoInforme);
                   cApellidos.SetText(data[0].cApellidos);
                   cNombres.SetText(data[0].cNombres);
                   cTipoDoc.SetValue(data[0].cTipoDoc);
                   cUbigeo.SetValue(data[0].cUbigeo);
                   cCondicion.SetValue(data[0].cCondicion);

                   cPaisNacimiento.SetValue(data[0].cPaisNacimiento);
                   cSexo.SetValue(data[0].cSexo);
                   //cStats.SetValue('EXPEDIENTE OAEL : ' + data[0].cExpediente + "\nFFLL : " + data[0].cFFLL + '\nCONDICION DETALLE : ' + data[0].cCondicionDes);

                   //alert(data[0].iCodOcupacion);
                   //iCodFuerzaLaboral.SetText(data.iCodFuerzaLaboral);
                   iCodCandidatoInforme.SetText(data[0].iCodCandidatoInforme);
                   iCodSubContrata.SetValue(data[0].iCodSubContrata);
                   cTipoCargo.SetValue(data[0].cTipoCargo);
                   cOcupacion.SetValue(data[0].iCodOcupacion);
                   cMOCMONC.SetValue(data[0].cMOCMONC);
                   cRotacion.SetValue(data[0].cRotacion);
                   cTurno.SetValue(data[0].cTurno);
                   cTipoContrato.SetValue(data[0].cTipoContrato);
                   cRegimenLaboral.SetValue(data[0].cRegimenLaboral);
                   iHorasHombre.SetValue(data[0].iHorasHombre);
                   cLugarPernocte.SetValue(data[0].cLugarPernocte);
                   cAreaTrabajo.SetText(data[0].cAreaTrabajo);
                   dFechaIni.SetText(data[0].dFechaIni);
                   cSituacionLaboral.SetValue(data[0].cSituacionLaboral);
                   //dFechaCese.SetText(data.dFechaCese);
                   //cMotivoCese.SetText(data.cMotivoCese);
                   //cObs.SetText(data.cObs);
                   //iCalificacion.SetText(data.iCalificacion);
                   //bDevolvioFotocheck.SetText(data.bDevolvioFotocheck);
                   //bActivo.SetText(data.bActivo);
                   //bCesado.SetText(data.bCesado);
                   //bConsentimiento.SetText(data.bConsentimiento);

               },
               fail: function (result) {
                   alert("FAIL " + result.status + ' ' + result.statusText);
               },
               error: function (result) {
                   alert("ERROR " + result.status + ' ' + result.statusText);
               }
           });
}


function viewRecordCI() {
    //alert("buscara");
    var pDoc = cDNI.GetValue();
    var pTipo = cTipoDoc.GetValue();
    var pTable = (cFormMetadata.Get('pTable'));
    //pCodCI_Cli = 0;
    pDoc = pDoc.trim();

 


    $.ajax(
           {
               url: pTable + ".aspx/GetRecordPersonaFL",
               data: "{'pDoc':'" + pDoc + "','pTipo':'" + pTipo + "'}",
               dataType: "json",
               type: "POST",
               contentType: "application/json; charset=utf-8",
               success: function (response) {
                   var data = response.d;
                   data = $.parseJSON(data);
                   //alert(data.length);
                   var iCant = data.length;
                   if (iCant > 0) {
                       iCodCandidatoInforme.SetText(data[0].iCodCandidatoInforme);
                       cApellidos.SetText(data[0].cApellidos);
                       cNombres.SetText(data[0].cNombres);
                       //cOcupacion.SetValue(data[0].cOcupacion);
                       cTipoDoc.SetValue(data[0].cTipoDoc);
                       cUbigeo.SetValue(data[0].cUbigeo);
                       cCondicion.SetValue(data[0].cCondicion);
                       cMOCMONC.SetValue(data[0].cMOCMONC);
                       cPaisNacimiento.SetValue(data[0].cPaisNacimiento);
                       cSexo.SetValue(data[0].cSexo);
                       $("#oaelCondicion").html("Condici&oacute;n : <b>" + data[0].cCondicionDes + "</b>");
                       $("#oaelExpediente").html("Expediente : <b>" + data[0].cDoc + "</b>");
                       $("#oaelFFLL").html("Fuerza Laboral : <b>" + data[0].cFFLLGlobal + "</b>") ;
                       $("#oaelEmpresa").html("Empresa : <b>" + data[0].cEmpresaTrabaja + "</b>");
                       if (data[0].cFFLLGlobal == 'SI')
                       {
                          
                           $("#oaelFFLL").removeClass("infoOK").addClass("infoDanger");
                           $("#oaelEmpresa").removeClass("infoOK").addClass("infoDanger");
                       }
                       else {
                           $("#oaelFFLL").removeClass("infoDanger").addClass("infoOK");
                           $("#oaelEmpresa").removeClass("infoDanger").addClass("infoOK");
                       }
                       //cStats.SetValue('EXPEDIENTE OAEL : ' + data[0].cExpediente + "\nFFLL : " + data[0].cFFLL + '\nCONDICION DETALLE : ' + data[0].cCondicionDes);
                   }
                   else {

                       cApellidos.SetText('Buscando ...');
                       cApellidos.SetEnabled(false);
                       cNombres.SetText('Buscando ...');
                       cNombres.SetEnabled(false);

                       $("#oaelCondicion").html("Condici&oacute;n : <b>SIN DATOS</b>");
                       $("#oaelExpediente").html("Expediente : <b>" +"NO" + "</b>");
                       $("#oaelFFLL").html("Fuerza Laboral : <b>" + "NO" + "</b>");
                       $("#oaelEmpresa").html("Empresa : <b>NINGUNA</b>");
                       $("#oaelFFLL").removeClass("infoDanger").addClass("infoOK");
                       $("#oaelEmpresa").removeClass("infoDanger").addClass("infoOK");


                       $.ajax(
                                {
                                    url: pTable + ".aspx/GetRecordPersonaCloud2020",
                                    data: "{'pDoc':'" + pDoc + "'}",
                                    dataType: "json",
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    success: function (response) {
                                        var data = response.d;
                                        data = $.parseJSON(data);
                                        //cApellidos.SetText((data.apellido_paterno + ' ' + data.apellido_materno).trim());
                                        //cNombres.SetText((data.nombres).trim());
                                        var _result = data.success;
                                        if (_result == true) {

                                            cApellidos.SetText((data.apellidos).trim());
                                            cNombres.SetText((data.nombres).trim());
                                        }
                                        else {

                                            cApellidos.SetText('');
                                            cNombres.SetText('');
                                        }
                                    },
                                    fail: function (result) {
                                        cApellidos.SetText('');
                                        cNombres.SetText('');
                                        alert("FAIL " + result.status + ' ' + result.statusText);
                                    },
                                    error: function (result) {
                                        cApellidos.SetText('');
                                        cNombres.SetText('');
                                        alert("ERROR " + result.status + ' ' + result.statusText);
                                    }
                                });


                       cApellidos.SetEnabled(true);
                       cNombres.SetEnabled(true);

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


function viewRecordDetalleCese() {
    var cID = iCodRegistroDetalle.GetValue();
    var pTable = (cFormMetadata.Get('pTable'));

    $.ajax(
           {
               url: pTable + ".aspx/GetRecordDetalleCese",
               data: "{'pID':" + cID + "}",
               dataType: "json",
               type: "POST",
               contentType: "application/json; charset=utf-8",
               success: function (response) {
                   var data = response.d;
                   data = $.parseJSON(data);
                   
                   //iHorasHombre.SetText(data.iHorasHombre);
                  
                   dFechaCese.SetText(data[0].dFechaCese);
                   cMotivoCese.SetValue(data[0].cMotivoCese);
                   //cObs.SetText(data.cObs);
                   bDevolvioFotocheck.SetValue(data[0].bDevolvioFotocheck);
                   iCalificacion.SetValue(data[0].iCalificacion);
                  

               },
               fail: function (result) {
                   alert("FAIL " + result.status + ' ' + result.statusText);
               },
               error: function (result) {
                   alert("ERROR " + result.status + ' ' + result.statusText);
               }
           });
}



