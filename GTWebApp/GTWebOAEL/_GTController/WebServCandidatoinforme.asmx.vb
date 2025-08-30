Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Newtonsoft

<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WebServCandidatoinforme
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GetRecordPostulante(pNroDoc As String, pTipoDoc As String) As String
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then

                Dim CRecordW As New Candidatoinforme
                Dim JSONString As String = String.Empty
                JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(CRecordW.GetCandidatoInformePorDniYTipoDoc((pNroDoc), (pTipoDoc)), Json.Formatting.None)
                CRecordW = Nothing
                Return JSONString
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try
    End Function

    <WebMethod()>
    Public Function GetRecordPostulanteReniec(ByVal pDoc As String) As String

        Return System.Net.WebUtility.HtmlDecode(WebDNICloud((pDoc), ""))

    End Function

    <WebMethod()>
    Public Function GetRecordPostulantePorCodigo(pCodRegistroPostulante As String) As String
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then

                Dim CRecordW As New Candidatoinforme
                Dim JSONString As String = String.Empty
                JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(CRecordW.GetCandidatoInformePorCodigo(pCodRegistroPostulante), Json.Formatting.None)
                CRecordW = Nothing
                Return JSONString
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try
    End Function

End Class