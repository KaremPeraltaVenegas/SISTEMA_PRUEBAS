var miRespuestaFeedback = [];
var miRespuestaFeedbackNegativa = ["NO CUMPLE EL PERFIL CURRICULAR", "PLAZA COBERTURADA POR LOCAL"];


window.addEventListener('load', function () {
     
    getRespuestaFeedback();
   
});

function getRespuestaFeedback() {
    var cID = iCodRegistro.GetValue();
    var pTable = (cFormMetadata.Get('pTable'));

    $.ajax(
           {
               url: pTable + ".aspx/GetRespuestaFeedback",
               data: "{'pID':" + cID + "}",
               dataType: "json",
               type: "POST",
               contentType: "application/json; charset=utf-8",
               success: function (response) {
                   var dataFeed = response.d;
                   dataFeed = $.parseJSON(dataFeed);
                   var iCant = dataFeed.length;
                 
                   for (i = 0; i < iCant-1; i++) {
                       miRespuestaFeedback.push(dataFeed[i].DisplayMember);
                   }
                   //miRespuestaFeedback.push("OTROS"); 

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
                     
                   cSeleccionado.SetValue(data[0].cSeleccionado);
                   cRptaContrata.ClearItems();
                   var pSelect = data[0].cSeleccionado;
                   if (pSelect.charAt(0) == 'S') {
                       miRespuestaFeedback.forEach(addComboBoxFeedback);

                       cSeleccionado.SetText('SELECCIONADO');
                   }
                   else {
                       miRespuestaFeedbackNegativa.forEach(addComboBoxFeedback);
                       cSeleccionado.SetText('NO SELECCIONADO');
                   }


                   cRptaContrata.SetValue(data[0].cRptaContrata);
                   cObs.SetValue(data[0].cObs);


                   cNomCompleto.SetText(data[0].cApellidos + ' ' + data[0].cNombres);
                   cPerfil.SetText(data[0].cPerfil);
                   cFono.SetText(data[0].cFono);
                   dFechaCargaCV.SetText(data[0].dFechaCargaCV);


                   cOcupacionPrincipal.SetText(data[0].cOcupacionPrincipal);
                   iTiempoOcupacionPrincipal.SetText(data[0].iTiempoOcupacionPrincipal);

                   cOcupacionAlterna.SetText(data[0].cOcupacionAlterna);
                   iTiempoOcupacionAlterna.SetText(data[0].iTiempoOcupacionAlterna);

                   iEdad.SetText(data[0].iEdad);
                   //cHorarioDisp.SetText(data[0].cHorarioDisp);
                   cCorreo.SetText(data[0].cCorreo);

                   cTipoPostulacion.SetText(data[0].cTipoPostulacion);
                   //alert(data[0].cTipoPostulacion);
                   //var pLaboro = data[0].iCantFLD;
                   //if (pLaboro > 0) {
                   //    cLaboroAAQ.SetText("SI LABORO EN EL PROYECTO");
                   //}
                   //else {
                   //    cLaboroAAQ.SetText("AUN NO LABORO EN EL PROYECTO");
                   //}
                   
                   var pResult = data[0].bResult;
                   if (pResult == true) {
                       BtnGuardarDetalle.SetEnabled(false);
                   }
                   else {
                       BtnGuardarDetalle.SetEnabled(true);
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
