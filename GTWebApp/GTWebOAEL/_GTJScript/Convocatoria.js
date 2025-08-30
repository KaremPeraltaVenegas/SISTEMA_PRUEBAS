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


                /*    cFuncionesPuesto.SetText(data[0].cFuncionesPuesto);*/
                //cOtrosBeneficios.SetText(data[0].cOtrosBeneficios);
                //cExperiencia.SetText(data[0].cExperiencia);
                //iTipoObra.SetValue(data[0].iTipoObra);
                //dFechaEstimadaIngreso.SetText(data[0].dFechaEstimadaIngreso);
                //cFrenteLugarTrabajo.SetText(data[0].cFrenteLugarTrabajo);
                //cCompetencias.SetText(data[0].cCompetencias);

            },
            fail: function (result) {
                alert("FAIL " + result.status + ' ' + result.statusText);
            },
            error: function (result) {
                alert("ERROR " + result.status + ' ' + result.statusText);
            }
        });
}

function iCodOcupacion_SelectedIndexChanged(s, e) {
    var cID = s.GetValue()
    console.log(cID)

    var pTable = (cFormMetadata.Get('pTable'));

    $.ajax(
        {
            url: pTable + ".aspx/GetDetallePerfil",
            data: "{'pID':" + cID + "}",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                var data = response.d;
                data = $.parseJSON(data);

                cGenero.SetValue(data[0].cGenero);
                iEdadMinimaRequerida.SetText(18);
                iEdadMaximaRequerida.SetText(60);
                iGradoInstrucion.SetValue(data[0].iGradoInstruccion);
                cExperiencia.SetText(data[0].cExperiencia);
                cCompetencias.SetText(data[0].cCompetencia);
                cDesPerfil.SetText(data[0].cDetalleOcupacion)
            },
            fail: function (result) {
                alert("FAIL " + result.status + ' ' + result.statusText);
            },
            error: function (result) {
                alert("ERROR " + result.status + ' ' + result.statusText);
            }
        });
}