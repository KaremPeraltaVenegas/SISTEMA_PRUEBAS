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
                   cNroDoc.SetText(data[0].cNroDoc);
                   iCodPersona.SetText(data[0].iCodPersona);
                   //alert(data[0].iCodUsuario);
                   iCodUsuario.SetText(data[0].iCodUsuario);
                   //alert('user ' + iCodUsuario.GetValue());
                   cApelP.SetText(data[0].cApellidos);
                   cNombres.SetText(data[0].cNombres);
                   cFono.SetText(data[0].cFono);
                   cCorreo.SetText(data[0].cCorreo);
                   bAcceder.SetValue(data[0].bAcceder);
                   iCodContrata.SetValue(data[0].iCodContrata);
                   cSexo.SetValue(data[0].cSexo);
                   cTipo.SetValue(data[0].cTipo);

 },
               fail: function (result) {
                   alert("FAIL " + result.status + ' ' + result.statusText);
               },
               error: function (result) {
                   alert("ERROR " + result.status + ' ' + result.statusText);
               }
           });
}



function viewRecordPersona() {
    //alert("buscara");
    var pDoc = cNroDoc.GetValue();
    var pTipo = "";
    var pTable = (cFormMetadata.Get('pTable'));
    //pCodCI_Cli = 0;
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
                       iCodPersona.SetText(data[0].iCodPersona);
                       //alert(data[0].iCodUsuario);
                       iCodUsuario.SetText(data[0].iCodUsuario);
                       //alert('user ' + iCodUsuario.GetValue());
                       cApelP.SetText(data[0].cApellidos);
                       cNombres.SetText(data[0].cNombres);
                       cFono.SetText(data[0].cFono);
                       cCorreo.SetText(data[0].cCorreo);
                       //bAcceder.SetValue(data[0].bAcceder);
                       //iCodContrata.SetValue(data[0].iCodContrata);
                       cSexo.SetValue(data[0].cSexo);
                       //cStats.SetValue('EXPEDIENTE OAEL : ' + data[0].cExpediente + "\nFFLL : " + data[0].cFFLL + '\nCONDICION DETALLE : ' + data[0].cCondicionDes);
                   }
                   else {

                       cApelP.SetText('Buscando ...');
                       cApelP.SetEnabled(false);
                       cNombres.SetText('Buscando ...');
                       cNombres.SetEnabled(false);



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

                                            cApelP.SetText((data.apellidos).trim());
                                            cNombres.SetText((data.nombres).trim());
                                        }
                                        else {



                                            cApelP.SetText('');
                                            cNombres.SetText('');
                                        }

                                    },
                                    fail: function (result) {
                                        cApelP.SetText('');
                                        cNombres.SetText('');
                                        alert("FAIL " + result.status + ' ' + result.statusText);
                                    },
                                    error: function (result) {
                                        cApelP.SetText('');
                                        cNombres.SetText('');
                                        alert("ERROR " + result.status + ' ' + result.statusText);
                                    }
                                });


                       cApelP.SetEnabled(true);
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



