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
										cDetalle.SetText(data.cDetalle);
										cResumen.SetText(data.cResumen);
										iGrupo.SetText(data.iGrupo);

 },
               fail: function (result) {
                   alert("FAIL " + result.status + ' ' + result.statusText);
               },
               error: function (result) {
                   alert("ERROR " + result.status + ' ' + result.statusText);
               }
           });
}
