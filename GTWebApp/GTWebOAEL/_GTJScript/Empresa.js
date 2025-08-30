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
										cRUC.SetText(data.cRUC);
										cRazonSocial.SetText(data.cRazonSocial);
										cNomComercial.SetText(data.cNomComercial);
										cTipo.SetText(data.cTipo);
										cFonoCorporativo.SetText(data.cFonoCorporativo);
										cNomContacto.SetText(data.cNomContacto);
										cFonoContacto.SetText(data.cFonoContacto);
										cCorreoContacto.SetText(data.cCorreoContacto);
										dFechaCreacion.SetText(data.dFechaCreacion);
										iCodUsuario.SetText(data.iCodUsuario);
										dFechaSistema.SetText(data.dFechaSistema);

 },
               fail: function (result) {
                   alert("FAIL " + result.status + ' ' + result.statusText);
               },
               error: function (result) {
                   alert("ERROR " + result.status + ' ' + result.statusText);
               }
           });
}
