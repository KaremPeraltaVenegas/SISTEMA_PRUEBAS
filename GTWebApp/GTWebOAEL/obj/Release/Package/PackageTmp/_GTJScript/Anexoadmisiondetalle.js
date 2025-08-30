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
										iCodAnexoAdmision.SetText(data.iCodAnexoAdmision);
										iCodCandidatoInforme.SetText(data.iCodCandidatoInforme);
										iCodSubContrata.SetText(data.iCodSubContrata);
										iCodAnexoAdmisionTipo.SetText(data.iCodAnexoAdmisionTipo);
										cCargo.SetText(data.cCargo);
										cMOCMONC.SetText(data.cMOCMONC);
										cProcesoEtapa.SetText(data.cProcesoEtapa);
										cNota.SetText(data.cNota);
										cObs.SetText(data.cObs);
										bAnulado.SetText(data.bAnulado);
										bNuevo.SetText(data.bNuevo);
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
