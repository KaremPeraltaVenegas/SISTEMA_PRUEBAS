function FormMainModalShowDetalle() {
    var popupWindow = PopupFormMainCliDetalle.GetWindow(0);
    PopupFormMainCliDetalle.ShowWindow(popupWindow);
}


//****** FUNCTIONS UX
function ClearContentControlsDetalle() {
    ASPxClientEdit.ClearEditorsInContainer(FormLayoutPopupDetalle.GetMainElement());
}
function CloseFormConfirmDeleteDetalle(e, s) {
    var popupWindow = PopupConfirmDeleteDetalle.GetWindow(0);
    PopupConfirmDeleteDetalle.HideWindow(popupWindow);
    e.processOnServer = false;
}
function CloseFormMainModalDetalle() {
    var popupWindow = PopupFormMainCliDetalle.GetWindow(0);
    PopupFormMainCliDetalle.HideWindow(popupWindow);
    
} 
function OnBtnGuardarClickDetalle(s, e) {
    if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopupDetalle.GetMainElement(), null, true)) {
        CallBackFunctionDetalle.PerformCallback('Guardar');
       
    }
    else {
        e.processOnServer = false;
    }
}
function OnToolbarItemClickDetalle(s, e) {
    if (IsCustomExportToolbarCommand(e.item.name)) {
        e.processOnServer = true;
        e.usePostBack = true;
    }
    //TablaRegistrosDetalle.PerformCallback('clear');
    
    if (e.item.name == "BtnAgregarDetalle") {
        iCodRegistroDetalle.SetText("0");
        cFormMetadata.Set("cTipoOpeDetalle", "A");
        ClearContentControlsDetalle();
        FormMainModalShowDetalle();
        e.processOnServer = false;

       
    }
    else if (e.item.name == "BtnEditarDetalle") {
        cFormMetadata.Set("cTipoOpeDetalle", "M");
        iCodRegistroDetalle.SetText(TablaRegistrosDetalle.GetRowKey(TablaRegistrosDetalle.GetFocusedRowIndex()));
        if (iCodRegistroDetalle.GetValue() != null)
        {
            ClearContentControlsDetalle();
            viewRecordDetalle();
            FormMainModalShowDetalle();
        }
       
        e.processOnServer = false;
    }
    else if (e.item.name == "BtnEliminarDetalle") {
        var popupWindow = PopupConfirmDeleteDetalle.GetWindow(0);
        PopupConfirmDeleteDetalle.ShowWindow(popupWindow);
         
        e.processOnServer = false;
    }
}
function IsCustomExportToolbarCommand(command) {
    return command == "CustomExportToXLS" || command == "CustomExportToXLSX";
}

function DeleteRecordDetalle(e, s) {
    var cID = iCodRegistroDetalle.GetValue();
    var pTable = (cFormMetadata.Get('pTableDetalle'));

    $.ajax(
           {
               url: pTable + ".aspx/DeleteRecordDetalle",
               data: "{'pID':" + cID + "}",
               dataType: "json",
               type: "POST",
               contentType: "application/json; charset=utf-8",
               success: function (response) {
                   if (response.d == "OK") {
                       var popupWindow = PopupConfirmDeleteDetalle.GetWindow(0);
                       PopupConfirmDeleteDetalle.HideWindow(popupWindow);
                       TablaRegistrosDetalle.PerformCallback("Elimina");
                       //TablaRegistrosDetalle.UnselectRows();
                       ShowAlertMessage('El Registro se borró con éxito.');
                       e.processOnServer = false;
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
function OnGridFocusedRowChangedDetalle(s, e) {
    iCodRegistroDetalle.SetText(s.GetRowKey(s.GetFocusedRowIndex()));

}
function OnEndCallBackFunctionDetalle(s, e) {
    //alert("cerrar");
    CloseFormMainModalDetalle();
    TablaRegistrosDetalle.PerformCallback('load');
}
function grid_Init(s, e) {
    //TablaRegistros.Refresh();
    //e.processOnServer = false;
}
function grid_BeginCallback(s, e) {
    ////start = new Date();
    ////ClientCommandLabel.SetText(e.command);
    ////ClientTimeLabel.SetText("working...");

    //command = e.command;

}
function grid_EndCallback(s, e) {
    //if (command == "REFRESH") {
    //    //s.Refresh();           
    //}
}
function deleteRowGrid() {
    //alert(TablaRegistrosDetalle.GetVisibleRowsOnPage());
    for (i = 0; i < TablaRegistrosDetalle.GetVisibleRowsOnPage() ; i++) {
        TablaRegistrosDetalle.DeleteRow(i);
        //alert("borrar");
    }
}

function changeToolbarStat(value1,value2,value3) {
    var toolbar = TablaRegistrosDetalle.GetToolbarByName("ToolbarGridDetalle");
    var newItem = toolbar.GetItemByName("BtnAgregarDetalle");
    var editItem = toolbar.GetItemByName("BtnEditarDetalle");
    var deleteItem = toolbar.GetItemByName("BtnEliminarDetalle");

    newItem.SetEnabled(value1);
    editItem.SetEnabled(value2);
    deleteItem.SetEnabled(value3);
    //alert(value);
}