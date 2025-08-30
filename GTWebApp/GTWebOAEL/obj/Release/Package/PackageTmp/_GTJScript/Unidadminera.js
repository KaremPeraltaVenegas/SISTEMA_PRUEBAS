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
										iCodEmpresa.SetValue(data.iCodEmpresa);
										cNomUnidadMinera.SetText(data.cNomUnidadMinera);
										cUbigeo.SetText(data.cUbigeo);
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
