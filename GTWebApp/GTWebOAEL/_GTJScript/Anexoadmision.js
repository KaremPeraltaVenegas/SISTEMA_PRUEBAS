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
                    iCodContratistaContrato.SetValue(data.iCodContratistaContrato);
                   iCodAnexoAdmisionTipo.SetValue(data.iCodAnexoAdmisionTipo);
                    cGrupo.SetValue(data.cGrupo);
                   
										//cNroAnexo.SetText(data.cNroAnexo);
										 
										cPersonaSolicita.SetText(data.cPersonaSolicita);
										cPersonaSolicitaCargo.SetText(data.cPersonaSolicitaCargo);
										cAreaUsuaria.SetText(data.cAreaUsuaria);
										cNotas.SetText(data.cNotas);
										cEstado.SetText(data.cEstado);
										cObsDocumento.SetText(data.cObsDocumento);
 										//cFormMetadata.Set("pEstado", data.cEstado);
										if (data.cEstado == 'C') {
										    BtnGuardar.SetEnabled(true);
										    BtnConfirmarEnviar.SetEnabled(true);
										    BtnImprimirFormatoPGI.SetEnabled(false);
										    iCodContratistaContrato.SetEnabled(true);
										}
										else if (data.cEstado == 'F') {
										    BtnGuardar.SetEnabled(false);
										    BtnConfirmarEnviar.SetEnabled(false);
										    BtnImprimirFormatoPGI.SetEnabled(true);
										    iCodContratistaContrato.SetEnabled(false);
										}
										else if (data.cEstado == 'O') {
										    BtnGuardar.SetEnabled(true);
										    BtnConfirmarEnviar.SetEnabled(true);
										    BtnImprimirFormatoPGI.SetEnabled(false);
										    iCodContratistaContrato.SetEnabled(false);
										}
										else {
										    BtnGuardar.SetEnabled(false);
										    BtnConfirmarEnviar.SetEnabled(false);
										    BtnImprimirFormatoPGI.SetEnabled(false);
										    iCodContratistaContrato.SetEnabled(false);
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

function viewRecordDetalle() {
    var cID = iCodRegistroDetalle.GetValue();
    var pTable = (cFormMetadata.Get('pTable'));
    $("#pgiData").html("");
    $("#pgiFecha").html("");
    BtnGuardarDetalle.SetEnabled(true);

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
                   iCodCandidatoInforme.SetText(data[0].iCodCandidatoInforme);
                   cApellidos.SetText(data[0].cApellidos);
                   cNombres.SetText(data[0].cNombres);
                   cTipoDoc.SetValue(data[0].cTipoDoc);
                   cUbigeo.SetValue(data[0].cUbigeo);
                   cCondicion.SetValue(data[0].cCondicion);
                   cMOCMONC.SetValue(data[0].cMOCMONC);
                   iCodAnexoAdmisionTipoDet.SetValue(data[0].iCodAnexoAdmisionTipo);

                   //iCodCandidatoInforme.SetText(data[0].iCodCandidatoInforme);
                   iCodSubContrata.SetValue(data[0].iCodSubContrata);
                   //iCodAnexoAdmisionTipo.SetText(data.iCodAnexoAdmisionTipo);
                   //cOcupacion.SetText(data[0].cCargo);
                   cOcupacion.SetValue(data[0].iCodOcupacion);
                   cMOCMONC.SetText(data[0].cMOCMONC);
                   //cProcesoEtapa.SetText(data.cProcesoEtapa);
                   cNota.SetText(data[0].cNota);
                   //cObs.SetText(data[0].cObs);

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
               url: pTable + ".aspx/GetRecordPersona",
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
                       //cMOCMONC.SetValue(data[0].cMOCMONC);
                       //cStats.SetValue('EXPEDIENTE OAEL : ' + data[0].cExpediente + "\nFFLL : " + data[0].cFFLL + '\nCONDICION DETALLE : ' + data[0].cCondicionDes);
                       $("#oaelCondicion").html("Condici&oacute;n : <b>" + data[0].cCondicionDes + "</b>");
                       $("#oaelExpediente").html("Expediente : <b>" + data[0].cDoc + "</b>");
                       //$("#oaelFFLL").html("Fuerza Laboral : <b>" + data[0].cFFLLGlobal) + "</b>)";
                       $("#oaelEmpresa").html("Empresa : <b>" + data[0].cEmpresaTrabaja + "</b>");
                       if (data[0].cFFLLGlobal == 'SI') {

                           //$("#oaelFFLL").removeClass("infoOK").addClass("infoDanger");
                           $("#oaelEmpresa").removeClass("infoOK").addClass("infoDanger");
                       }
                       else {
                           //$("#oaelFFLL").removeClass("infoDanger").addClass("infoOK");
                           $("#oaelEmpresa").removeClass("infoDanger").addClass("infoOK");
                       }

                       // PGI
                       if ((data[0].cEstadoPGI == 'V') || (data[0].cEstadoPGI == 'N')) {
                           //ESTADO VENCIDO O NO TIENE
                           $("#pgiData").removeClass("infoDanger").addClass("infoOK");
                           $("#pgiData").html("STAT PGI : <b>SIN RESTRICCIONES</b>");
                           $("#pgiFecha").html("");
                           BtnGuardarDetalle.SetEnabled(true);
                       }
                       else
                       {
                           $("#pgiData").removeClass("infoOK").addClass("infoDanger");
                           $("#pgiFecha").removeClass("infoOK").addClass("infoDanger");
                           var cResult = data[0].cEstadoPGI.split('**');

                           if (cResult[0] == 'R') {
                               $("#pgiData").removeClass("infoDanger").addClass("infoOK");
                               $("#pgiData").html("STAT PGI : <b>SIN RESTRICCIONES</b>");
                               $("#pgiFecha").html("");
                               BtnGuardarDetalle.SetEnabled(true);
                           }
                           else {
                               $("#pgiData").html("STAT PGI : <b>PGI EN PROCESO</b>");
                               $("#pgiFecha").html("FECHA FIN : <b>" + cResult[1] + "</b>");
                               BtnGuardarDetalle.SetEnabled(false);
                           }
                       }
                       
                   }
                   else {
                      
                       cApellidos.SetText('Buscando ...');
                       cApellidos.SetEnabled(false);
                       cNombres.SetText('Buscando ...');
                       cNombres.SetEnabled(false);

                       $("#oaelCondicion").html("Condici&oacute;n : <b>SIN DATOS</b>");
                       $("#oaelExpediente").html("Expediente : <b>" + "NO" + "</b>");
                       //$("#oaelFFLL").html("Fuerza Laboral : <b>" + "NO" + "</b>");
                       $("#oaelEmpresa").html("Empresa : <b>NINGUNA</b>");
                       //$("#oaelFFLL").removeClass("infoDanger").addClass("infoOK");
                       $("#oaelEmpresa").removeClass("infoDanger").addClass("infoOK");

                       $("#pgiData").removeClass("infoDanger").addClass("infoOK");
                       $("#pgiData").html("STAT PGI : <b>SIN RESTRICCIONES</b>");
                       $("#pgiFecha").html("");
                       BtnGuardarDetalle.SetEnabled(true);

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

