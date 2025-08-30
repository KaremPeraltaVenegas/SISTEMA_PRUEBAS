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
										cNomOcupacion.SetText(data.cNomOcupacion);
										cOcupacionAbrev.SetText(data.cOcupacionAbrev);
										cTipo.SetText(data.cTipo);
										cCategoriaRCC.SetText(data.cCategoriaRCC);
										cOcupacionRCC.SetText(data.cOcupacionRCC);
										cEspecialidadRCC.SetText(data.cEspecialidadRCC);

 },
               fail: function (result) {
                   alert("FAIL " + result.status + ' ' + result.statusText);
               },
               error: function (result) {
                   alert("ERROR " + result.status + ' ' + result.statusText);
               }
           });
}
