function FormMainModalShow() {
    var popupWindow = PopupFormMainCli.GetWindow(0);
    PopupFormMainCli.ShowWindow(popupWindow);
}


//****** FUNCTIONS UX
function ClearContentControls() {
    ASPxClientEdit.ClearEditorsInContainer(FormLayoutPopup.GetMainElement());
}
function ClearControls(s, e) {
    ASPxClientEdit.ClearEditorsInContainer(s);
function CloseFormConfirmDelete(e, s) {
    var popupWindow = PopupConfirmDelete.GetWindow(0);
    PopupConfirmDelete.HideWindow(popupWindow);
    e.processOnServer = false;
}
//function CloseFormMainModal(pResult) {
//    //alert(pResult);
//    var popupWindow = PopupFormMainCli.GetWindow(0);
//    PopupFormMainCli.HideWindow(popupWindow);


//    //var popupWindow = PopupConfirmDelete.GetWindow(0);
//    //PopupConfirmDelete.HideWindow(popupWindow);

//}
function OnBtnGuardarClick(s, e) {
    if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopup.GetMainElement(), null, true)) {
        CallBackFunction.PerformCallback();
        //ShowAlertMessage('Registro guardado con éxito.');
    }
    else {
        e.processOnServer = false;
    }
}

function OnToolbarItemClick(s, e) {
     
    if (IsCustomExportToolbarCommand(e.item.name)) {
        e.processOnServer = true;
        e.usePostBack = true;
    }

    if (e.item.name == "BtnAgregar") {
        iCodRegistro.SetText("0");       
        cFormMetadata.Set("cTipoOpe", "A");
        ClearContentControls();
        FormMainModalShow();
        e.processOnServer = false;
    }
    else if (e.item.name == "BtnEditar") {
        cFormMetadata.Set("cTipoOpe", "M");
        iCodRegistro.SetText(TablaRegistros.GetRowKey(TablaRegistros.GetFocusedRowIndex()));
        ClearContentControls();
        viewRecord();
        FormMainModalShow();
        e.processOnServer = false;
    }
    else if (e.item.name == "BtnEliminar") {
        var popupWindow = PopupConfirmDelete.GetWindow(0);
        PopupConfirmDelete.ShowWindow(popupWindow);

        //PopupConfirmDelete.ShowAtPos(document.documentElement.clientWidth, document.documentElement.clientHeight);
        //setTimeout(function () { PopupConfirmDelete.Hide(); }, 4000);
        e.processOnServer = false;
    }
}
function IsCustomExportToolbarCommand(command) {
    return command == "CustomExportToXLS" || command == "CustomExportToXLSX";
}

function DeleteRecord(e, s) {
    var cID = iCodRegistro.GetValue();
    var pTable = (cFormMetadata.Get('pTable'));

    $.ajax(
           {
               url: pTable + ".aspx/DeleteRecord",
               data: "{'pID':" + cID + "}",
               dataType: "json",
               type: "POST",
               contentType: "application/json; charset=utf-8",
               success: function (response) {
                   if (response.d == "OK") {                     
                       var popupWindow = PopupConfirmDelete.GetWindow(0);
                       PopupConfirmDelete.HideWindow(popupWindow);
                       TablaRegistros.PerformCallback();
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

function OnGridFocusedRowChanged(s, e) {
    iCodRegistro.SetText(s.GetRowKey(s.GetFocusedRowIndex()));
    //alert(iCodRegistro.GetValue());
}

function OnEndCallBackFunction(s, e) {
  

    var Resultado = e.result;

    if (Resultado != "OK") {

    }
    CloseFormMainModal(e.result);
    TablaRegistros.PerformCallback();


   
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
function ShowAlertMessage(pMsg) {
    var pMsgLocal = pMsg;
    PopupAlertMessage.SetContentHtml(pMsgLocal);

    PopupAlertMessage.ShowAtPos(document.documentElement.clientWidth, document.documentElement.clientHeight);
    setTimeout(function () { PopupAlertMessage.Hide(); }, 5000);
}


