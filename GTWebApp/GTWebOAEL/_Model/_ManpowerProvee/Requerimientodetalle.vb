Imports System.Data.SqlClient
Public Class Requerimientodetalle
    Public iCodRequerimientoDetalle As String
    Public iCodRequerimiento As String
    Public iCodRubroBienesServicios As String
    Public iCodCategoriaBienesServicios As String
    Public iCodCatalogoBienesServicios As String
    Public cDescripcionBienServicio As String
    Public cDetalleRequerimiento As String
    Public iCodTipoMedida As String
    Public cEstado As String
    Public bAprobado As String
    Public iCodUsuarioAprobado As String
    Public dFechaAprobado As String
    Public cNotasAprobado As String
    Public bExceptuado As String
    Public iCodUsuarioExceptuado As String
    Public dFechaExceptuado As String
    Public bLiberado As String
    Public iCodUsuarioLiberado As String
    Public dFechaLiberado As String
    Public cNotasLiberado As String
    Public nCantidad As String
    Public nPrecioUnit As String
    Public nSubTotal As String
    Public bIGV As String
    Public nTiempoDuracion As String
    Public cUrlBases As String
    Public cObs As String
    Public cNotas As String
    Public cOtrosRequisitos As String
    Public iCodUsuarioCreacion As String
    Public dFechaCreacion As String
    Public iCodUsuarioModificacion As String
    Public dFechaModificacion As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM prov.RequerimientoDetalle"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into prov.RequerimientoDetalle (iCodRequerimiento,iCodRubroBienesServicios,iCodCategoriaBienesServicios,iCodCatalogoBienesServicios,cDescripcionBienServicio,cDetalleRequerimiento,iCodTipoMedida,cEstado,bAprobado,iCodUsuarioAprobado,dFechaAprobado,cNotasAprobado,bExceptuado,iCodUsuarioExceptuado,dFechaExceptuado,bLiberado,iCodUsuarioLiberado,dFechaLiberado,cNotasLiberado,nCantidad,nPrecioUnit,nSubTotal,bIGV,nTiempoDuracion,cUrlBases,cObs,cNotas,cOtrosRequisitos,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodRequerimiento,@iCodRubroBienesServicios,@iCodCategoriaBienesServicios,@iCodCatalogoBienesServicios,@cDescripcionBienServicio,@cDetalleRequerimiento,@iCodTipoMedida,@cEstado,@bAprobado,@iCodUsuarioAprobado,@dFechaAprobado,@cNotasAprobado,@bExceptuado,@iCodUsuarioExceptuado,@dFechaExceptuado,@bLiberado,@iCodUsuarioLiberado,@dFechaLiberado,@cNotasLiberado,@nCantidad,@nPrecioUnit,@nSubTotal,@bIGV,@nTiempoDuracion,@cUrlBases,@cObs,@cNotas,@cOtrosRequisitos,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
        cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
        cmdSQL.Parameters.Add("@iCodCatalogoBienesServicios", SqlDbType.Int).Value = Me.iCodCatalogoBienesServicios
        cmdSQL.Parameters.Add("@cDescripcionBienServicio", SqlDbType.Varchar, -1).Value = Me.cDescripcionBienServicio
        cmdSQL.Parameters.Add("@cDetalleRequerimiento", SqlDbType.Varchar, -1).Value = Me.cDetalleRequerimiento
        cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 20).Value = Me.cEstado
        cmdSQL.Parameters.Add("@bAprobado", SqlDbType.Bit).Value = Me.bAprobado
        cmdSQL.Parameters.Add("@iCodUsuarioAprobado", SqlDbType.Int).Value = Me.iCodUsuarioAprobado
        cmdSQL.Parameters.Add("@dFechaAprobado", SqlDbType.Datetime).Value = Me.dFechaAprobado
        cmdSQL.Parameters.Add("@cNotasAprobado", SqlDbType.Varchar, -1).Value = Me.cNotasAprobado
        cmdSQL.Parameters.Add("@bExceptuado", SqlDbType.Bit).Value = Me.bExceptuado
        cmdSQL.Parameters.Add("@iCodUsuarioExceptuado", SqlDbType.Int).Value = Me.iCodUsuarioExceptuado
        cmdSQL.Parameters.Add("@dFechaExceptuado", SqlDbType.Datetime).Value = Me.dFechaExceptuado
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iCodUsuarioLiberado", SqlDbType.Int).Value = Me.iCodUsuarioLiberado
        cmdSQL.Parameters.Add("@dFechaLiberado", SqlDbType.Datetime).Value = Me.dFechaLiberado
        cmdSQL.Parameters.Add("@cNotasLiberado", SqlDbType.Varchar, -1).Value = Me.cNotasLiberado
        cmdSQL.Parameters.Add("@nCantidad", SqlDbType.Decimal).Value = Me.nCantidad
        cmdSQL.Parameters.Add("@nPrecioUnit", SqlDbType.Decimal).Value = Me.nPrecioUnit
        cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
        cmdSQL.Parameters.Add("@bIGV", SqlDbType.Bit).Value = Me.bIGV
        cmdSQL.Parameters.Add("@nTiempoDuracion", SqlDbType.Decimal).Value = Me.nTiempoDuracion
        cmdSQL.Parameters.Add("@cUrlBases", SqlDbType.Varchar, -1).Value = Me.cUrlBases
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@cNotas", SqlDbType.Varchar, -1).Value = Me.cNotas
        cmdSQL.Parameters.Add("@cOtrosRequisitos", SqlDbType.Varchar, -1).Value = Me.cOtrosRequisitos
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodRequerimientoDetalle = pCodInsert
        Else
            Me.iCodRequerimientoDetalle = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into prov.RequerimientoDetalle (iCodRequerimiento,iCodRubroBienesServicios,iCodCategoriaBienesServicios,iCodCatalogoBienesServicios,cDescripcionBienServicio,cDetalleRequerimiento,iCodTipoMedida,cEstado,bAprobado,iCodUsuarioAprobado,dFechaAprobado,cNotasAprobado,bExceptuado,iCodUsuarioExceptuado,dFechaExceptuado,bLiberado,iCodUsuarioLiberado,dFechaLiberado,cNotasLiberado,nCantidad,nPrecioUnit,nSubTotal,bIGV,nTiempoDuracion,cUrlBases,cObs,cNotas,cOtrosRequisitos,iCodUsuarioCreacion,dFechaCreacion,iCodUsuarioModificacion,dFechaModificacion ) VALUES(@iCodRequerimiento,@iCodRubroBienesServicios,@iCodCategoriaBienesServicios,@iCodCatalogoBienesServicios,@cDescripcionBienServicio,@cDetalleRequerimiento,@iCodTipoMedida,@cEstado,@bAprobado,@iCodUsuarioAprobado,@dFechaAprobado,@cNotasAprobado,@bExceptuado,@iCodUsuarioExceptuado,@dFechaExceptuado,@bLiberado,@iCodUsuarioLiberado,@dFechaLiberado,@cNotasLiberado,@nCantidad,@nPrecioUnit,@nSubTotal,@bIGV,@nTiempoDuracion,@cUrlBases,@cObs,@cNotas,@cOtrosRequisitos,@iCodUsuarioCreacion,@dFechaCreacion,@iCodUsuarioModificacion,@dFechaModificacion); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
        cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
        cmdSQL.Parameters.Add("@iCodCatalogoBienesServicios", SqlDbType.Int).Value = Me.iCodCatalogoBienesServicios
        cmdSQL.Parameters.Add("@cDescripcionBienServicio", SqlDbType.Varchar, -1).Value = Me.cDescripcionBienServicio
        cmdSQL.Parameters.Add("@cDetalleRequerimiento", SqlDbType.Varchar, -1).Value = Me.cDetalleRequerimiento
        cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 20).Value = Me.cEstado
        cmdSQL.Parameters.Add("@bAprobado", SqlDbType.Bit).Value = Me.bAprobado
        cmdSQL.Parameters.Add("@iCodUsuarioAprobado", SqlDbType.Int).Value = Me.iCodUsuarioAprobado
        cmdSQL.Parameters.Add("@dFechaAprobado", SqlDbType.Datetime).Value = Me.dFechaAprobado
        cmdSQL.Parameters.Add("@cNotasAprobado", SqlDbType.Varchar, -1).Value = Me.cNotasAprobado
        cmdSQL.Parameters.Add("@bExceptuado", SqlDbType.Bit).Value = Me.bExceptuado
        cmdSQL.Parameters.Add("@iCodUsuarioExceptuado", SqlDbType.Int).Value = Me.iCodUsuarioExceptuado
        cmdSQL.Parameters.Add("@dFechaExceptuado", SqlDbType.Datetime).Value = Me.dFechaExceptuado
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iCodUsuarioLiberado", SqlDbType.Int).Value = Me.iCodUsuarioLiberado
        cmdSQL.Parameters.Add("@dFechaLiberado", SqlDbType.Datetime).Value = Me.dFechaLiberado
        cmdSQL.Parameters.Add("@cNotasLiberado", SqlDbType.Varchar, -1).Value = Me.cNotasLiberado
        cmdSQL.Parameters.Add("@nCantidad", SqlDbType.Decimal).Value = Me.nCantidad
        cmdSQL.Parameters.Add("@nPrecioUnit", SqlDbType.Decimal).Value = Me.nPrecioUnit
        cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
        cmdSQL.Parameters.Add("@bIGV", SqlDbType.Bit).Value = Me.bIGV
        cmdSQL.Parameters.Add("@nTiempoDuracion", SqlDbType.Decimal).Value = Me.nTiempoDuracion
        cmdSQL.Parameters.Add("@cUrlBases", SqlDbType.Varchar, -1).Value = Me.cUrlBases
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@cNotas", SqlDbType.Varchar, -1).Value = Me.cNotas
        cmdSQL.Parameters.Add("@cOtrosRequisitos", SqlDbType.Varchar, -1).Value = Me.cOtrosRequisitos
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodRequerimientoDetalle = pCodInsert
        Else
            Me.iCodRequerimientoDetalle = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  prov.RequerimientoDetalle SET iCodRequerimiento=@iCodRequerimiento,iCodRubroBienesServicios=@iCodRubroBienesServicios,iCodCategoriaBienesServicios=@iCodCategoriaBienesServicios,iCodCatalogoBienesServicios=@iCodCatalogoBienesServicios,cDescripcionBienServicio=@cDescripcionBienServicio,cDetalleRequerimiento=@cDetalleRequerimiento,iCodTipoMedida=@iCodTipoMedida,cEstado=@cEstado,bAprobado=@bAprobado,iCodUsuarioAprobado=@iCodUsuarioAprobado,dFechaAprobado=@dFechaAprobado,cNotasAprobado=@cNotasAprobado,bExceptuado=@bExceptuado,iCodUsuarioExceptuado=@iCodUsuarioExceptuado,dFechaExceptuado=@dFechaExceptuado,bLiberado=@bLiberado,iCodUsuarioLiberado=@iCodUsuarioLiberado,dFechaLiberado=@dFechaLiberado,cNotasLiberado=@cNotasLiberado,nCantidad=@nCantidad,nPrecioUnit=@nPrecioUnit,nSubTotal=@nSubTotal,bIGV=@bIGV,nTiempoDuracion=@nTiempoDuracion,cUrlBases=@cUrlBases,cObs=@cObs,cNotas=@cNotas,cOtrosRequisitos=@cOtrosRequisitos,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRequerimientoDetalle=@iCodRequerimientoDetalle"
        cmdSQL.Parameters.Add("@iCodRequerimientoDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoDetalle
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
        cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
        cmdSQL.Parameters.Add("@iCodCatalogoBienesServicios", SqlDbType.Int).Value = Me.iCodCatalogoBienesServicios
        cmdSQL.Parameters.Add("@cDescripcionBienServicio", SqlDbType.Varchar, -1).Value = Me.cDescripcionBienServicio
        cmdSQL.Parameters.Add("@cDetalleRequerimiento", SqlDbType.Varchar, -1).Value = Me.cDetalleRequerimiento
        cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 20).Value = Me.cEstado
        cmdSQL.Parameters.Add("@bAprobado", SqlDbType.Bit).Value = Me.bAprobado
        cmdSQL.Parameters.Add("@iCodUsuarioAprobado", SqlDbType.Int).Value = Me.iCodUsuarioAprobado
        cmdSQL.Parameters.Add("@dFechaAprobado", SqlDbType.Datetime).Value = Me.dFechaAprobado
        cmdSQL.Parameters.Add("@cNotasAprobado", SqlDbType.Varchar, -1).Value = Me.cNotasAprobado
        cmdSQL.Parameters.Add("@bExceptuado", SqlDbType.Bit).Value = Me.bExceptuado
        cmdSQL.Parameters.Add("@iCodUsuarioExceptuado", SqlDbType.Int).Value = Me.iCodUsuarioExceptuado
        cmdSQL.Parameters.Add("@dFechaExceptuado", SqlDbType.Datetime).Value = Me.dFechaExceptuado
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iCodUsuarioLiberado", SqlDbType.Int).Value = Me.iCodUsuarioLiberado
        cmdSQL.Parameters.Add("@dFechaLiberado", SqlDbType.Datetime).Value = Me.dFechaLiberado
        cmdSQL.Parameters.Add("@cNotasLiberado", SqlDbType.Varchar, -1).Value = Me.cNotasLiberado
        cmdSQL.Parameters.Add("@nCantidad", SqlDbType.Decimal).Value = Me.nCantidad
        cmdSQL.Parameters.Add("@nPrecioUnit", SqlDbType.Decimal).Value = Me.nPrecioUnit
        cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
        cmdSQL.Parameters.Add("@bIGV", SqlDbType.Bit).Value = Me.bIGV
        cmdSQL.Parameters.Add("@nTiempoDuracion", SqlDbType.Decimal).Value = Me.nTiempoDuracion
        cmdSQL.Parameters.Add("@cUrlBases", SqlDbType.Varchar, -1).Value = Me.cUrlBases
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@cNotas", SqlDbType.Varchar, -1).Value = Me.cNotas
        cmdSQL.Parameters.Add("@cOtrosRequisitos", SqlDbType.Varchar, -1).Value = Me.cOtrosRequisitos
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  prov.RequerimientoDetalle SET iCodRequerimiento=@iCodRequerimiento,iCodRubroBienesServicios=@iCodRubroBienesServicios,iCodCategoriaBienesServicios=@iCodCategoriaBienesServicios,iCodCatalogoBienesServicios=@iCodCatalogoBienesServicios,cDescripcionBienServicio=@cDescripcionBienServicio,cDetalleRequerimiento=@cDetalleRequerimiento,iCodTipoMedida=@iCodTipoMedida,cEstado=@cEstado,bAprobado=@bAprobado,iCodUsuarioAprobado=@iCodUsuarioAprobado,dFechaAprobado=@dFechaAprobado,cNotasAprobado=@cNotasAprobado,bExceptuado=@bExceptuado,iCodUsuarioExceptuado=@iCodUsuarioExceptuado,dFechaExceptuado=@dFechaExceptuado,bLiberado=@bLiberado,iCodUsuarioLiberado=@iCodUsuarioLiberado,dFechaLiberado=@dFechaLiberado,cNotasLiberado=@cNotasLiberado,nCantidad=@nCantidad,nPrecioUnit=@nPrecioUnit,nSubTotal=@nSubTotal,bIGV=@bIGV,nTiempoDuracion=@nTiempoDuracion,cUrlBases=@cUrlBases,cObs=@cObs,cNotas=@cNotas,cOtrosRequisitos=@cOtrosRequisitos,iCodUsuarioCreacion=@iCodUsuarioCreacion,dFechaCreacion=@dFechaCreacion,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRequerimientoDetalle=@iCodRequerimientoDetalle"
        cmdSQL.Parameters.Add("@iCodRequerimientoDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoDetalle
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
        cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
        cmdSQL.Parameters.Add("@iCodCatalogoBienesServicios", SqlDbType.Int).Value = Me.iCodCatalogoBienesServicios
        cmdSQL.Parameters.Add("@cDescripcionBienServicio", SqlDbType.Varchar, -1).Value = Me.cDescripcionBienServicio
        cmdSQL.Parameters.Add("@cDetalleRequerimiento", SqlDbType.Varchar, -1).Value = Me.cDetalleRequerimiento
        cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
        cmdSQL.Parameters.Add("@cEstado", SqlDbType.Varchar, 20).Value = Me.cEstado
        cmdSQL.Parameters.Add("@bAprobado", SqlDbType.Bit).Value = Me.bAprobado
        cmdSQL.Parameters.Add("@iCodUsuarioAprobado", SqlDbType.Int).Value = Me.iCodUsuarioAprobado
        cmdSQL.Parameters.Add("@dFechaAprobado", SqlDbType.Datetime).Value = Me.dFechaAprobado
        cmdSQL.Parameters.Add("@cNotasAprobado", SqlDbType.Varchar, -1).Value = Me.cNotasAprobado
        cmdSQL.Parameters.Add("@bExceptuado", SqlDbType.Bit).Value = Me.bExceptuado
        cmdSQL.Parameters.Add("@iCodUsuarioExceptuado", SqlDbType.Int).Value = Me.iCodUsuarioExceptuado
        cmdSQL.Parameters.Add("@dFechaExceptuado", SqlDbType.Datetime).Value = Me.dFechaExceptuado
        cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        cmdSQL.Parameters.Add("@iCodUsuarioLiberado", SqlDbType.Int).Value = Me.iCodUsuarioLiberado
        cmdSQL.Parameters.Add("@dFechaLiberado", SqlDbType.Datetime).Value = Me.dFechaLiberado
        cmdSQL.Parameters.Add("@cNotasLiberado", SqlDbType.Varchar, -1).Value = Me.cNotasLiberado
        cmdSQL.Parameters.Add("@nCantidad", SqlDbType.Decimal).Value = Me.nCantidad
        cmdSQL.Parameters.Add("@nPrecioUnit", SqlDbType.Decimal).Value = Me.nPrecioUnit
        cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
        cmdSQL.Parameters.Add("@bIGV", SqlDbType.Bit).Value = Me.bIGV
        cmdSQL.Parameters.Add("@nTiempoDuracion", SqlDbType.Decimal).Value = Me.nTiempoDuracion
        cmdSQL.Parameters.Add("@cUrlBases", SqlDbType.Varchar, -1).Value = Me.cUrlBases
        cmdSQL.Parameters.Add("@cObs", SqlDbType.Varchar, -1).Value = Me.cObs
        cmdSQL.Parameters.Add("@cNotas", SqlDbType.Varchar, -1).Value = Me.cNotas
        cmdSQL.Parameters.Add("@cOtrosRequisitos", SqlDbType.Varchar, -1).Value = Me.cOtrosRequisitos
        cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.Datetime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.Datetime).Value = Me.dFechaModificacion

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  prov.RequerimientoDetalle  WHERE iCodRequerimientoDetalle=@iCodRequerimientoDetalle"
        'cmdSQL.CommandText = "UPDATE prov.RequerimientoDetalle  SET bAnulado=1 WHERE  iCodRequerimientoDetalle=@iCodRequerimientoDetalle"
        cmdSQL.Parameters.Add("@iCodRequerimientoDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoDetalle
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  prov.RequerimientoDetalle  WHERE iCodRequerimientoDetalle=@iCodRequerimientoDetalle"
        'cmdSQL.CommandText = "UPDATE prov.RequerimientoDetalle  SET bAnulado=1 WHERE  iCodRequerimientoDetalle=@iCodRequerimientoDetalle"
        cmdSQL.Parameters.Add("@iCodRequerimientoDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoDetalle
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM prov.RequerimientoDetalle WHERE iCodRequerimientoDetalle=@iCodRequerimientoDetalle"
        cmdSQL.Parameters.Add("@iCodRequerimientoDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoDetalle
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodRequerimientoDetalle = CStr(readers.GetValue(0))
            Me.iCodRequerimiento = CStr(readers.GetValue(1))
            Me.iCodRubroBienesServicios = CStr(readers.GetValue(2))
            Me.iCodCategoriaBienesServicios = CStr(readers.GetValue(3))
            Me.iCodCatalogoBienesServicios = CStr(readers.GetValue(4))
            Me.cDescripcionBienServicio = CStr(readers.GetValue(5))
            Me.cDetalleRequerimiento = CStr(readers.GetValue(6))
            Me.iCodTipoMedida = CStr(readers.GetValue(7))
            Me.cEstado = CStr(readers.GetValue(8))
            Me.bAprobado = CStr(readers.GetValue(9))
            Me.iCodUsuarioAprobado = CStr(readers.GetValue(10))
            Me.dFechaAprobado = CStr(readers.GetValue(11))
            Me.cNotasAprobado = CStr(readers.GetValue(12))
            Me.bExceptuado = CStr(readers.GetValue(13))
            Me.iCodUsuarioExceptuado = CStr(readers.GetValue(14))
            Me.dFechaExceptuado = CStr(readers.GetValue(15))
            Me.bLiberado = CStr(readers.GetValue(16))
            Me.iCodUsuarioLiberado = CStr(readers.GetValue(17))
            Me.dFechaLiberado = CStr(readers.GetValue(18))
            Me.cNotasLiberado = CStr(readers.GetValue(19))
            Me.nCantidad = CStr(readers.GetValue(20))
            Me.nPrecioUnit = CStr(readers.GetValue(21))
            Me.nSubTotal = CStr(readers.GetValue(22))
            Me.bIGV = CStr(readers.GetValue(23))
            Me.nTiempoDuracion = CStr(readers.GetValue(24))
            Me.cUrlBases = CStr(readers.GetValue(25))
            Me.cObs = CStr(readers.GetValue(26))
            Me.cNotas = CStr(readers.GetValue(27))
            Me.cOtrosRequisitos = CStr(readers.GetValue(28))
            Me.iCodUsuarioCreacion = CStr(readers.GetValue(29))
            Me.dFechaCreacion = CStr(readers.GetValue(30))
            Me.iCodUsuarioModificacion = CStr(readers.GetValue(31))
            Me.dFechaModificacion = CStr(readers.GetValue(32))
        End If
        readers.Close()
    End Sub
    Public Function ListaDatosCombo() As DataTable
        Dim miDataTable As New DataTable
        Dim readers As IDataReader
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "SELECT * FROM prov.RequerimientoDetalle"
        readers = cmdSQL.ExecuteReader
        While readers.Read()
            miDataTable.Rows.Add(CStr(readers.GetValue(0)), CStr(readers.GetValue(1)))
        End While
        readers.Close()
        Return miDataTable
    End Function
    Public Function LastID() As Integer
        Const query As String = "SELECT SCOPE_IDENTITY()"
        Return mc.ExecuteScalar(query)
    End Function
    Public Function LastIDT() As Integer
        Const query As String = "SELECT SCOPE_IDENTITY()"
        Return mc.ExecuteScalarTransact(query)
    End Function
    '***********************************************************
    Public bEditar As Boolean

    Public Sub AnularRequerimientoLista()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  prov.RequerimientoDetalle SET cEstado='ANULADO',dFechaModificacion=@dFechaModificacion,iCodUsuarioModificacion=@iCodUsuarioModificacion WHERE iCodRequerimiento=@iCodRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = Me.dFechaModificacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Function ListaRequerimientoDetallePorCodigo() As DataTable
         Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_DTW_RequerimientoDetallePorCodRequerimiento"
        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function

    Public Function ListaRequerimientoDetalleParaCotizar() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "SELECT iCodRequerimientoDetalle,nCantidad from prov.RequerimientoDetalle where iCodRequerimiento=@iCodRequerimiento"

        cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt
    End Function

    Public Sub UpdateRegistroWeb()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  prov.RequerimientoDetalle SET cDescripcionBienServicio=@cDescripcionBienServicio,cDetalleRequerimiento=@cDetalleRequerimiento,iCodTipoMedida=@iCodTipoMedida,nCantidad=@nCantidad,nPrecioUnit=@nPrecioUnit,nSubTotal=@nSubTotal,nTiempoDuracion=@nTiempoDuracion,cOtrosRequisitos=@cOtrosRequisitos,iCodUsuarioModificacion=@iCodUsuarioModificacion,dFechaModificacion=@dFechaModificacion WHERE iCodRequerimientoDetalle=@iCodRequerimientoDetalle"
        cmdSQL.Parameters.Add("@iCodRequerimientoDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoDetalle
        'cmdSQL.Parameters.Add("@iCodRequerimiento", SqlDbType.Int).Value = Me.iCodRequerimiento
        'cmdSQL.Parameters.Add("@iCodRubroBienesServicios", SqlDbType.Int).Value = Me.iCodRubroBienesServicios
        'cmdSQL.Parameters.Add("@iCodCategoriaBienesServicios", SqlDbType.Int).Value = Me.iCodCategoriaBienesServicios
        'cmdSQL.Parameters.Add("@iCodCatalogoBienesServicios", SqlDbType.Int).Value = Me.iCodCatalogoBienesServicios
        cmdSQL.Parameters.Add("@cDescripcionBienServicio", SqlDbType.VarChar, -1).Value = Me.cDescripcionBienServicio
        cmdSQL.Parameters.Add("@cDetalleRequerimiento", SqlDbType.VarChar, -1).Value = Me.cDetalleRequerimiento
        cmdSQL.Parameters.Add("@iCodTipoMedida", SqlDbType.Int).Value = Me.iCodTipoMedida
        'cmdSQL.Parameters.Add("@cEstado", SqlDbType.VarChar, 20).Value = Me.cEstado
        'cmdSQL.Parameters.Add("@bAprobado", SqlDbType.Bit).Value = Me.bAprobado
        'cmdSQL.Parameters.Add("@iCodUsuarioAprobado", SqlDbType.Int).Value = Me.iCodUsuarioAprobado
        'cmdSQL.Parameters.Add("@dFechaAprobado", SqlDbType.DateTime).Value = Me.dFechaAprobado
        'cmdSQL.Parameters.Add("@cNotasAprobado", SqlDbType.VarChar, -1).Value = Me.cNotasAprobado
        'cmdSQL.Parameters.Add("@bExceptuado", SqlDbType.Bit).Value = Me.bExceptuado
        'cmdSQL.Parameters.Add("@iCodUsuarioExceptuado", SqlDbType.Int).Value = Me.iCodUsuarioExceptuado
        'cmdSQL.Parameters.Add("@dFechaExceptuado", SqlDbType.DateTime).Value = Me.dFechaExceptuado
        'cmdSQL.Parameters.Add("@bLiberado", SqlDbType.Bit).Value = Me.bLiberado
        'cmdSQL.Parameters.Add("@iCodUsuarioLiberado", SqlDbType.Int).Value = Me.iCodUsuarioLiberado
        'cmdSQL.Parameters.Add("@dFechaLiberado", SqlDbType.DateTime).Value = Me.dFechaLiberado
        'cmdSQL.Parameters.Add("@cNotasLiberado", SqlDbType.VarChar, -1).Value = Me.cNotasLiberado
        cmdSQL.Parameters.Add("@nCantidad", SqlDbType.Decimal).Value = Me.nCantidad
        cmdSQL.Parameters.Add("@nPrecioUnit", SqlDbType.Decimal).Value = Me.nPrecioUnit
        cmdSQL.Parameters.Add("@nSubTotal", SqlDbType.Decimal).Value = Me.nSubTotal
        'cmdSQL.Parameters.Add("@bIGV", SqlDbType.Bit).Value = Me.bIGV
        cmdSQL.Parameters.Add("@nTiempoDuracion", SqlDbType.Decimal).Value = Me.nTiempoDuracion
        'cmdSQL.Parameters.Add("@cUrlBases", SqlDbType.VarChar, -1).Value = Me.cUrlBases
        'cmdSQL.Parameters.Add("@cObs", SqlDbType.VarChar, -1).Value = Me.cObs
        'cmdSQL.Parameters.Add("@cNotas", SqlDbType.VarChar, -1).Value = Me.cNotas
        cmdSQL.Parameters.Add("@cOtrosRequisitos", SqlDbType.VarChar, -1).Value = Me.cOtrosRequisitos
        'cmdSQL.Parameters.Add("@iCodUsuarioCreacion", SqlDbType.Int).Value = Me.iCodUsuarioCreacion
        'cmdSQL.Parameters.Add("@dFechaCreacion", SqlDbType.DateTime).Value = Me.dFechaCreacion
        cmdSQL.Parameters.Add("@iCodUsuarioModificacion", SqlDbType.Int).Value = Me.iCodUsuarioModificacion
        cmdSQL.Parameters.Add("@dFechaModificacion", SqlDbType.DateTime).Value = Me.dFechaModificacion

        cmdSQL.ExecuteNonQuery()
       
    End Sub

    Public Function GetRequerimientoPorId() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "prov.SP_ROW_RequerimientoDetalle"
        cmdSQL.Parameters.Add("@iCodRequerimientoDetalle", SqlDbType.Int).Value = Me.iCodRequerimientoDetalle

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function
End Class
