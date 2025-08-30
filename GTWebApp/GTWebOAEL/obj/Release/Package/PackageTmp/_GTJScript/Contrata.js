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
										cNomContrata.SetText(data.cNomContrata);
										cRUC.SetText(data.cRUC);
										cResponsable.SetText(data.cResponsable);
										cFono.SetText(data.cFono);
										cCorreo.SetText(data.cCorreo);
										cContacto1.SetText(data.cContacto1);
										cFono1.SetText(data.cFono1);
										cCorreo1.SetText(data.cCorreo1);
										cContacto2.SetText(data.cContacto2);
										cFono2.SetText(data.cFono2);
										cNomCorto.SetText(data.cNomCorto);
										bSubContrata.SetText(data.bSubContrata);
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
