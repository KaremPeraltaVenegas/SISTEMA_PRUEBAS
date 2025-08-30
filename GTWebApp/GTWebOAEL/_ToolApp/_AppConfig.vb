Imports System.Configuration
Imports System.Reflection
Public Class _AppConfig
    Private CEncripta As New _Encripta
    Private _config As Configuration
    Private _settings As AppSettingsSection
    Public Function ReadSetting(ByVal key As String) As String
        Try

            Dim appSettings = ConfigurationManager.AppSettings
            Dim result As String = appSettings(key)
            If IsNothing(result) Then
                result = "-"
            End If

            Return result
        Catch e As ConfigurationErrorsException
            Return ""
            'MsgBox("Error al leer los datos")
        End Try
    End Function
    Public Sub setSetting(ByVal key As String, ByVal value As String)
        Try
            Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim settings = configFile.AppSettings.Settings
            If IsNothing(settings(key)) Then
                settings.Add(key, value)
            Else
                settings(key).Value = value
            End If
            configFile.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name)
        Catch e As ConfigurationErrorsException
            'MsgBox("Error writing app settings")
        End Try
    End Sub
End Class