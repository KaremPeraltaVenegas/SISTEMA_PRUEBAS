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
                 
                cDescripcionBienServicio.SetText(data[0].cDescripcionBienServicio);
                cDetalleRequerimiento.SetText(data[0].cDetalleRequerimiento);
                iCodTipoMedida.SetValue(data[0].iCodTipoMedida);
                
                nCantidad.SetValue(data[0].nCantidad);
                nPrecioUnit.SetValue(data[0].nPrecioUnit);
                nSubTotal.SetValue(data[0].nSubTotal);
               
                nTiempoDuracion.SetValue(data[0].nTiempoDuracion);
                
                cOtrosRequisitos.SetText(data[0].cOtrosRequisitos);
 
            },
            fail: function (result) {
                alert("FAIL " + result.status + ' ' + result.statusText);
            },
            error: function (result) {
                alert("ERROR " + result.status + ' ' + result.statusText);
            }
        });
}
 