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

                iCodSubContrata.SetValue(data[0].iCodSubContrata);
                iCodContratistaContrato.SetValue(data[0].iCodContratistaContrato);
                cObs.SetText(data[0].cObs);
                cSolicitante.SetText(data[0].cSolicitante);
                dFechaIni.SetText(data[0].dFechaIni);
                dFechaFin.SetText(data[0].dFechaFin);

                if (data[0].bAprobadoCED) {

                    if (!data[0].bAprobadoCliente) {

                        BtnAprobarFinalizar.SetEnabled(true);
                        BtnDesaprobarFinalizar.SetEnabled(true);
                    }
                    else if (data[0].bAprobadoCliente) {

                        BtnAprobarFinalizar.SetEnabled(false);
                        BtnDesaprobarFinalizar.SetEnabled(false);
                    }
                    else {
                        BtnAprobarFinalizar.SetEnabled(false);
                        BtnDesaprobarFinalizar.SetEnabled(false);
                    }
                }
                else
                {
                    BtnAprobarFinalizar.SetEnabled(false);
                    BtnDesaprobarFinalizar.SetEnabled(false);
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

                iCodOcupacion.SetValue(data[0].iCodOcupacion);
                iCantidad.SetText(data[0].iCantidad);
                //iPeriodoContrataMeses.SetText(data[0].iPeriodoContrataMeses);
                cGenero.SetValue(data[0].cGenero);
                iEdadMinimaRequerida.SetText(data[0].iEdadMinimaRequerida);
                iEdadMaximaRequerida.SetText(data[0].iEdadMaximaRequerida);
                //iEscalaRemunerativa.SetValue(data[0].iEscalaRemunerativa);
                iGradoInstruccion.SetValue(data[0].iGradoInstruccion);
                cDesPerfil.SetHtml(data[0].cDesPerfil);
                iBandaSalarialMin.SetValue(data[0].iBandaSalarialMin);
                iBandaSalarialMax.SetValue(data[0].iBandaSalarialMax);
                iTiempoExpRequerida.SetValue(data[0].iTiempoExpRequerida);

            },
            fail: function (result) {
                alert("FAIL " + result.status + ' ' + result.statusText);
            },
            error: function (result) {
                alert("ERROR " + result.status + ' ' + result.statusText);
            }
        });
}