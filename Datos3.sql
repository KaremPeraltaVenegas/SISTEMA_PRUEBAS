USE [GTManpowerLocal]
GO
/****** Object:  StoredProcedure [main].[SP_ACTU_BloqueoUsuario]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_ACTU_BloqueoUsuario]  
@cNick varchar(40)  
AS  
BEGIN  
  
 BEGIN TRY  
   BEGIN TRAN SP_ACTU_BloqueoUsuario  
  
   UPDATE dbo.Usuario  
   SET bBloqueado = 1,  
       dFechaUltimoBloqueo = ( SELECT TOP 1 dFechaBloqueo   
          FROM dbo.SeguridadUsuarioHistorial  
          WHERE cNick=@cNick  
          ORDER BY iCodSeguridadUsuarioHistorial DESC)  
   WHERE cNick = @cNick  
     
   SELECT 1  
   COMMIT TRAN SP_ACTU_BloqueoUsuario  
     
 END TRY  
 BEGIN CATCH  
   SELECT -1  
   ROLLBACK TRAN SP_ACTU_BloqueoUsuario  
 END CATCH  
    
END  
GO
/****** Object:  StoredProcedure [main].[SP_COND_VerificarBloqueoPorUsuario]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_COND_VerificarBloqueoPorUsuario]  
@cNick varchar(40)  
AS  
BEGIN  
  
 BEGIN TRY  
   BEGIN TRAN VerificarBloqueoPorUsuario  
  
   /*Obtengo el USUARIO*/  
  
   IF EXISTS ( SELECT * FROM dbo.Usuario  
      WHERE cNick= @cNick  
      AND bBloqueado = 1)   
   BEGIN  
       DECLARE @TiempoTranscurridominutos int  
  
       SELECT @TiempoTranscurridominutos = DATEDIFF(minute,dFechaUltimoBloqueo,GETDATE()) FROM dbo.Usuario  
       --SELECT dFechaUltimoBloqueo,* FROM dts.Usuario  
       WHERE cNick= @cNick  
  
       IF (@TiempoTranscurridominutos>=60)  
       BEGIN  
      UPDATE dbo.Usuario  
      SET bBloqueado = NULL,dFechaUltimoBloqueo=NULL  
      WHERE cNick= @cNick  
      SELECT 0 --Usuario No Bloqueado  
       END  
       ELSE  
       BEGIN  
      SELECT 1 --Usuario Bloqueado  
       END  
   END  
   ELSE  
   BEGIN  
    SELECT 0 --Usuario No Bloqueado  
   END  
   COMMIT TRAN VerificarBloqueoPorUsuario  
     
 END TRY  
 BEGIN CATCH  
   SELECT -1  
   ROLLBACK TRAN VerificarBloqueoPorUsuario  
 END CATCH  
    
END  
GO
/****** Object:  StoredProcedure [main].[SP_COND_VerificarTienePermisoPorNombrePagina]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_COND_VerificarTienePermisoPorNombrePagina]  
    @iCodUsuario int,  
    @cNombrePagina varchar(max)  
AS  
BEGIN  
    DECLARE @resultado int;  
  
    BEGIN TRY  
        BEGIN TRAN VerificarPermisoPorNomPag  
  
        -- Usar EXISTS para verificar la existencia  
        SELECT @resultado = CASE   
            WHEN EXISTS (  
                SELECT *  
                FROM UsuarioPermiso up  
                LEFT JOIN UFormulario f ON up.iCodUFormulario = f.iCodUFormulario  
                WHERE f.cGrupo = 'Web Main'  
                  AND up.iCodUsuarioSistema = @iCodUsuario  
                  AND f.cNomCortoFormulario = @cNombrePagina  
      AND bVisualizar=1  
            ) THEN 1 ELSE 0  
        END  
  
        COMMIT TRAN VerificarPermisoPorNomPag  
    END TRY  
    BEGIN CATCH  
        SET @resultado = 0  
        ROLLBACK TRAN VerificarPermisoPorNomPag  
    END CATCH  
  
    -- Retornamos el resultado  
    SELECT @resultado AS TienePermiso  
END
GO
/****** Object:  StoredProcedure [main].[SP_COND_VerificarTipoAccesoPorUsuario]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_COND_VerificarTipoAccesoPorUsuario]  
@cNick varchar(40)  
AS  
BEGIN  
  
 BEGIN TRY  
   BEGIN TRAN VerificarTipoAccesoPorUsuario  
  
   /*Obtengo el acceso del usuaro*/  
  
   IF EXISTS ( SELECT * FROM dbo.Usuario  
      WHERE cNick= @cNick  
      AND bBloqueado = 0 AND cTipo IN('1','2','3'))   
   BEGIN  
     SELECT 1  --Dar acceso
   END  
   ELSE  
   BEGIN  
    SELECT 0   --NO Dar Acceso
   END 
   
   COMMIT TRAN VerificarTipoAccesoPorUsuario
     
 END TRY  
 BEGIN CATCH  
   SELECT -1  
   ROLLBACK TRAN VerificarTipoAccesoPorUsuario  
 END CATCH  
    
END  
GO
/****** Object:  StoredProcedure [main].[SP_COND_VerificarUsuarioExiste]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_COND_VerificarUsuarioExiste]  
@cNick varchar(50)  
AS  
BEGIN  
 BEGIN TRY  
   BEGIN TRAN VerificarUsuarioExiste  
  
   /*Si existe usuario, Retorna el iCodUsuario*/  
   IF EXISTS ( SELECT * FROM dbo.Usuario WHERE cNick = @cNick)   
   BEGIN  
  
       SELECT iCodUsuario FROM dbo.Usuario  
       WHERE cNick= @cNick  
       --SELECT 0  
   END  
   ELSE  
   BEGIN  
    SELECT 0 --Usuario No Existe  
   END  
   COMMIT TRAN VerificarUsuarioExiste  
     
 END TRY  
 BEGIN CATCH  
   SELECT -1  
   ROLLBACK TRAN VerificarUsuarioExiste  
 END CATCH  
END  
GO
/****** Object:  StoredProcedure [main].[SP_DT_CandidatoInformeListaEstudios]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_DT_CandidatoInformeListaEstudios]   
 @iCodCandidatoInforme int     
AS  
BEGIN  
	 SET NOCOUNT ON  
	  -- POR PUESTO   
	 SELECT cast(e.iCodCandidatoEstudios as varchar) as iCodCandidatoEstudios,  
	   e.cCentroEstudios,  
	   e.cCarrera,  
	   e.iCicloAcademico,  
	   catgradins.cDisplayMember  as cGradoInstruccion,  
	   catsitacad.cDisplayMember  as cSituacionAcademica,  
	   catrank.cDisplayMember as cRankingAcademico,  
	   catgradacad.cDisplayMember  as cGradoAcademico,  
	   case   
		when isnull( catsitacad.cDisplayMember,'') = 'EN CURSO' then 'EN CURSO'  
		else cast(iPeriodoFinAno as varchar(10))   
	   end as cPeriodoFin    
	 from CandidatoEstudios as e   
	 left JOIN Catalogo as catgradins on e.iGradoInstruccion=catgradins.cValueMember AND catgradins.cTabla='Estudios' AND catgradins.cNombreGrupo = 'iGradoInstruccion'   
	 left JOIN Catalogo as catsitacad on e.iSituacionAcademica=catsitacad.cValueMember AND catsitacad.cTabla='Estudios' AND catsitacad.cNombreGrupo = 'iSituacionAcademica'  
	 left JOIN Catalogo as catrank on e.iRankingAcademico=catrank.cValueMember AND catrank.cTabla='Estudios' AND catrank.cNombreGrupo = 'iRankingAcademico'    
	 left JOIN Catalogo as catgradacad on e.iGradoAcademico=catgradacad.cValueMember AND catgradacad.cTabla='Estudios' AND catgradacad.cNombreGrupo = 'iGradoAcademico'  
	 where e.iCodCandidatoInforme = @iCodCandidatoInforme   
	 --and e.bActivo = 1  
END  
GO
/****** Object:  StoredProcedure [main].[SP_DT_CandidatoInformeListaExperienciaLaboral]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_DT_CandidatoInformeListaExperienciaLaboral]     
 @iCodCandidatoInforme int       
AS    
BEGIN    
  SET NOCOUNT ON     
  SELECT	iCodCandidatoExperienciaLaboral,
			cSectorExperiencia,
			cEmpresa,
			cPuesto,
			dFechaIni,
			dFechaFin,
			bDocumentado  
  from CandidatoExperienciaLaboral  
  where iCodCandidatoInforme = @iCodCandidatoInforme      
END 
GO
/****** Object:  StoredProcedure [main].[SP_DT_GetCandidatoAdmision]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [main].[SP_DT_GetCandidatoAdmision] 
@dFechaRegistroInicio as date,
@dFechaRegistroFin  as date
AS
BEGIN
	 SELECT *
	 FROM m_CandidatoAdmisionSolicitud
	 WHERE dFechaRegistro>=@dFechaRegistroInicio AND dFechaRegistro<=@dFechaRegistroFin
	 order by dFechaSolicitud desc,dFechaRegistro desc,cNomCompleto asc
END
GO
/****** Object:  StoredProcedure [main].[SP_DT_GetCandidatoAdmisionPorFechaRegistro]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [main].[SP_DT_GetCandidatoAdmisionPorFechaRegistro]   
@dFechaRegistroInicio as date,  
@dFechaRegistroFin  as date  
AS  
BEGIN  
  SELECT	
			iCodCandidatoAdmision,
			CONVERT(VARCHAR, dFechaRegistro, 103) as dFechaRegistro,
			CONVERT(VARCHAR, dFechaSolicitud, 103) as dFechaSolicitud,
			cCandidatoAdmisionTipo,
			cCandidatoAdmisionOrigenGrupo,
			cDNI,
			cNomCompleto,
			cCondicion
  FROM m_CandidatoAdmisionSolicitud  
  WHERE dFechaRegistro>=@dFechaRegistroInicio AND dFechaRegistro<=@dFechaRegistroFin  
  order by dFechaSolicitud desc,dFechaRegistro desc,cNomCompleto asc  
END
GO
/****** Object:  StoredProcedure [main].[SP_DT_ListaCandidatoInformePorDni]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [main].[SP_DT_ListaCandidatoInformePorDni]  
@cDniBusqueda VARCHAR(20)  
AS  
BEGIN  
 SELECT ci.iCodCandidatoInforme,  
     ci.cDNI,  
     ci.cApellidos + ' ' + ci.cNombres AS cNomCompleto,  
     ci.cUbigeo,  
     ci.cSexo,  
     ci.cCondicion,  
     ci.cComunidad,  
     ci.cEstCivil,  
     com.cTipoAreaInfluencia,  
     CASE  
      WHEN ci.cOcupacion IS NULL THEN ''  
      ELSE ci.cOcupacion+ CASE  
            WHEN ci.cOcupacion2 IS NULL THEN ''  
            WHEN ci.cOcupacion2='' THEN ''  
            ELSE ' - ' + ci.cOcupacion2  
           END  
     END AS cOcupacion,  
     ci.dFechaEvaluacion,  
     ci.bEvaluado,  
     ci.cAptitud,  
     ci.bVerificativa,  
     ci.iEstadoVerificativa,  
     ci.bCargaBox,  
     ci.iResultadoVerificativa,  
     ci.cPuestoEspecialidad,  
     ci.iTiempoExperiencia,  
     ci.bDisponible,  
     ci.dFechaSis  
 FROM dbo.CandidatoInforme ci  
 LEFT JOIN CandidatoInformeAdd cid ON ci.iCodCandidatoInforme=cid.iCodCandidatoInforme  
 LEFT JOIN Comunidad com ON com.cComunidad=ci.cComunidad   
 WHERE ci.cDNI=@cDniBusqueda
 ORDER BY ci.iCodCandidatoInforme DESC
END
GO
/****** Object:  StoredProcedure [main].[SP_DT_ListaCandidatoInformePorMesRegistrado]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [main].[SP_DT_ListaCandidatoInformePorMesRegistrado]      
@dFechaBusqueda DATE      
AS      
BEGIN      
 SELECT ci.iCodCandidatoInforme,      
     ci.cDNI,      
     ci.cApellidos + ' ' + ci.cNombres AS cNomCompleto,      
     ci.cUbigeo,      
     ci.cSexo,      
     ci.cCondicion,      
     ci.cComunidad,      
     ci.cEstCivil,      
     com.cTipoAreaInfluencia,      
     CASE      
      WHEN ci.cOcupacion IS NULL THEN ''      
      ELSE ci.cOcupacion+ CASE      
            WHEN ci.cOcupacion2 IS NULL THEN ''      
            WHEN ci.cOcupacion2='' THEN ''      
            ELSE ' - ' + ci.cOcupacion2      
           END      
     END AS cOcupacion,      
     ci.dFechaEvaluacion,      
     ci.bEvaluado,      
     ci.cAptitud,      
     ci.bVerificativa,      
     ci.iEstadoVerificativa,      
     ci.bCargaBox,      
     ci.iResultadoVerificativa,      
     ci.cPuestoEspecialidad,      
     ci.iTiempoExperiencia,      
     ci.bDisponible,      
     ci.dFechaSis      
 FROM dbo.CandidatoInforme ci      
 LEFT JOIN CandidatoInformeAdd cid ON ci.iCodCandidatoInforme=cid.iCodCandidatoInforme      
 LEFT JOIN Comunidad com ON com.cComunidad=ci.cComunidad     
 WHERE MONTH(ci.dFechaSis) = MONTH(@dFechaBusqueda) and year(ci.dFechaSis)= YEAR(@dFechaBusqueda)  
 ORDER BY ci.iCodCandidatoInforme DESC
END
GO
/****** Object:  StoredProcedure [main].[SP_DT_ListaConvocatoriasVigentes]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [main].[SP_DT_ListaConvocatoriasVigentes] 
AS
BEGIN
	SELECT  * from  mpg_ConvocatoriasListaDetalleVigente 
	order by cNomCorto asc,dFechaFin desc,cPerfil asc		
END
GO
/****** Object:  StoredProcedure [main].[SP_DT_UsuarioPermiso]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_DT_UsuarioPermiso]      
@iCodUsuario int                                
AS                              
BEGIN      
      
 SELECT up.iCodUFormulario, up.iCodUsuarioSistema, f.cNomCortoFormulario, f.cNomFormulario     
 FROM UsuarioPermiso up      
 LEFT JOIN UFormulario f ON up.iCodUFormulario=f.iCodUFormulario      
 WHERE f.cGrupo='Web Main'      
 AND up.iCodUsuarioSistema=@iCodUsuario    
 AND up.bVisualizar=1      
      
END
GO
/****** Object:  StoredProcedure [main].[SP_ELIM_CandidatoEstudioPorCodigo]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_ELIM_CandidatoEstudioPorCodigo]
@iCodCandidatoEstudios int
AS
BEGIN

	BEGIN TRY
			BEGIN TRAN SP_ELIM_CandidatoEstudio

			IF NOT EXISTS(SELECT * FROM dbo.CandidatoEstudios                          
			          WHERE iCodCandidatoEstudios = @iCodCandidatoEstudios)
			BEGIN
				SELECT 0
			END
			ELSE
			BEGIN
				DELETE FROM dbo.CandidatoEstudios
				WHERE iCodCandidatoEstudios = @iCodCandidatoEstudios 
				SELECT 1
			END
			
			COMMIT TRAN SP_ELIM_CandidatoEstudio
			
	END TRY
	BEGIN CATCH
			SELECT -1
			ROLLBACK TRAN SP_ELIM_CandidatoEstudio
	END CATCH
		
END

GO
/****** Object:  StoredProcedure [main].[SP_ELIM_CandidatoExperienciaLaboralPorCodigo]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_ELIM_CandidatoExperienciaLaboralPorCodigo]  
@iCodCandidatoExperienciaLaboral int  
AS  
BEGIN  
  
 BEGIN TRY  
   BEGIN TRAN SP_ELIM_CandidatoExperienciaLab  
  
   IF NOT EXISTS(SELECT * FROM dbo.CandidatoExperienciaLaboral                            
             WHERE iCodCandidatoExperienciaLaboral = @iCodCandidatoExperienciaLaboral)  
   BEGIN  
    SELECT 0  
   END  
   ELSE  
   BEGIN  
    DELETE FROM dbo.CandidatoExperienciaLaboral  
    WHERE iCodCandidatoExperienciaLaboral = @iCodCandidatoExperienciaLaboral   
    SELECT 1  
   END  
     
   COMMIT TRAN SP_ELIM_CandidatoExperienciaLab  
     
 END TRY  
 BEGIN CATCH  
   SELECT -1  
   ROLLBACK TRAN SP_ELIM_CandidatoExperienciaLab  
 END CATCH  
    
END  
GO
/****** Object:  StoredProcedure [main].[SP_INSER_GenerarPermisosPorUsuario]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_INSER_GenerarPermisosPorUsuario]
@iCodUsuarioSistema int,    
@iCodUsuario int,    
@cTipoUsuario varchar(4)    
AS    
BEGIN  
 IF NOT EXISTS (  
  SELECT 1   
  FROM UsuarioPermiso   
  WHERE iCodUFormulario IN (  
   SELECT iCodUFormulario   
   FROM UFormulario   
   WHERE cGrupo = 'Web Main'  
  )  
  AND iCodUsuarioSistema = @iCodUsuarioSistema  
 )  
 BEGIN  
  -- Si no existen, se procede a insertar los registros  
  INSERT INTO UsuarioPermiso (iCodUFormulario, iCodUsuarioSistema, bVisualizar, bAgregar,    
  bGuardar, bEditar, bEliminar, iCodUsuario, dFechaSis)    
  SELECT iCodUFormulario, @iCodUsuarioSistema, 0, 0, 0, 0, 0, @iCodUsuario, GETDATE()     
  FROM UFormulario   
  WHERE cGrupo = 'Web Main';  
 END  
  
 -- Continuamos con las actualizaciones de permisos para los tipos de usuarios  
 IF (@cTipoUsuario = '3')  --  3: Sistema Administrador    
 BEGIN    
  UPDATE UsuarioPermiso    
  SET bVisualizar = 1    
  WHERE iCodUsuarioSistema = @iCodUsuarioSistema;    
 END    
 IF (@cTipoUsuario = 'UC')  --  UC: Usuario Operador Contratistas    
 BEGIN    
  UPDATE UsuarioPermiso    
  SET bVisualizar = 1    
  WHERE iCodUsuarioSistema = @iCodUsuarioSistema    
  AND iCodUFormulario NOT IN (101, 102, 107, 109);    
 END    
 IF (@cTipoUsuario = 'US')  --  US: Usuario Operador Cliente Antamina usuarios    
 BEGIN    
  UPDATE UsuarioPermiso    
  SET bVisualizar = 1    
  WHERE iCodUsuarioSistema = @iCodUsuarioSistema    
  AND iCodUFormulario NOT IN (107);    
 END    
 IF (@cTipoUsuario = '1')  --  1: Usuario Operador OAEL    
 BEGIN    
  UPDATE UsuarioPermiso    
  SET bVisualizar = 1    
  WHERE iCodUsuarioSistema = @iCodUsuarioSistema    
  AND iCodUFormulario NOT IN (101, 102, 109);    
 END    
END
GO
/****** Object:  StoredProcedure [main].[SP_ROW_CandidatoAdmisionPorCodigo]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_ROW_CandidatoAdmisionPorCodigo]  
@iCodCandidatoAdmision  int 
AS  
BEGIN  
 SELECT TOP 1 *  
 FROM dbo.CandidatoAdmision   
 where  iCodCandidatoAdmision = @iCodCandidatoAdmision 
END
GO
/****** Object:  StoredProcedure [main].[SP_ROW_CandidatoEstudioPorCodigo]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [main].[SP_ROW_CandidatoEstudioPorCodigo]          
@iCodCandidatoEstudios int          
AS          
BEGIN   
  SELECT   e.iCodCandidatoEstudios,
			e.iCodCandidatoInforme,
			e.cCentroEstudios,
			e.iGradoInstruccion,
			e.cCarrera,
			e.iSituacionAcademica,
			e.iGradoAcademico,
			e.iCicloAcademico,
			e.iRankingAcademico,
			e.iPeriodoInicioMes,
			e.iPeriodoInicioAno,
			e.iPeriodoFinMes,
			e.iPeriodoFinAno,
			e.bPrincipal,
			e.bActivo
  FROM dbo.CandidatoEstudios e                       
  WHERE e.iCodCandidatoEstudios = @iCodCandidatoEstudios  
END
GO
/****** Object:  StoredProcedure [main].[SP_ROW_CandidatoExperienciaLaboralPorCodigo]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [main].[SP_ROW_CandidatoExperienciaLaboralPorCodigo]              
@iCodCandidatoExperienciaLaboral int              
AS              
BEGIN       
  SELECT  iCodCandidatoExperienciaLaboral,  
   iCodCandidatoInforme,  
   iCodOcupacion,  
   iCodCandidatoExperienciaNivel,  
   cSectorExperiencia,  
   cRubroExperiencia,  
   cRegimenExperiencia,  
   cEmpresa,  
   cPuesto,  
   cFuncionesLogros,  
   cDestacariasEmpresa,  
   iPeriodoInicioMes,  
   iPeriodoInicioAno,  
   iPeriodoFinMes,  
   iPeriodoFinAno,  
   dFechaIni,  
   dFechaFin,  
   bActualmenteTrabajado,  
   bObservado,  
   cObservacionExperiencia,  
   cReferenciaPersona,  
   cReferenciaPuesto,  
   cReferenciaFono,  
   cReferenciaCalificacion,  
   cReferenciaObs,  
   dFechaValidacionExperiencia,  
   iCodUsuarioValidaExperiencia,  
   cUrlDocumento,  
   bActivo,  
   bOcupacion1,  
   bOcupacion2,  
   bDocumentado,  
   iCodUsuarioRegistro,  
   dFechaRegistro,  
   iCodUsuario,  
   dFechaSis  
  FROM dbo.CandidatoExperienciaLaboral                           
  WHERE iCodCandidatoExperienciaLaboral = @iCodCandidatoExperienciaLaboral      
END
GO
/****** Object:  StoredProcedure [main].[SP_ROW_CandidatoInformePorCodigo]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [main].[SP_ROW_CandidatoInformePorCodigo]        
@iCodCandidatoInforme int        
AS        
BEGIN 
	 SELECT 
	   ci.iCodCandidatoInforme,  
	   ci.cDNI,
	   ci.cUbigeo,
	   ci.cApellidos,  
	   ci.cNombres,        
	   ci.cSexo,
	   ci.cUbigeoResidencia,
	   ci.cEstCivil,
	   ci.cFono,
	   ci.cCorreo,
	   ci.dFechaNac,
	   ci.cCUI,
	   ci.cDireccion,
	   ci.cCondicion,               
       isnull(ci.cOcupacion,'') as cOcupacion1,
       isnull(ci.cOcupacion2,'') as cOcupacion2,
	   ci.cComunidad,        
	   com.cTipoAreaInfluencia,
	   ci.cLicenciaConducir,
	   ci.cMOCMONC,
	   ci.dFechaEvaluacion,        
	   ci.bEvaluado,        
	   ci.cAptitud,        
	   ci.bVerificativa,        
	   ci.iEstadoVerificativa,        
	   ci.bCargaBox,        
	   ci.iResultadoVerificativa,        
	   ci.cPuestoEspecialidad,        
	   ci.iTiempoExperiencia,        
	   ci.bDisponible,        
	   ci.dFechaSis,
	   ci.cTipoDoc,
	   ci.cPaisNacimiento,
	   ci.bCumplePefil,
	   ci.iCodUsuario,
	   ci.dFechaSis,
	   ci.cObservacion,
	   ci.bSustentoCV,
	   ci.bDiscapacitado,
	   ci.bPrioritario
	 FROM dbo.CandidatoInforme ci             
	 LEFT JOIN Comunidad com ON com.cComunidad=ci.cComunidad       
	 WHERE ci.iCodCandidatoInforme=@iCodCandidatoInforme  
END
GO
/****** Object:  StoredProcedure [main].[SP_ROW_CandidatoInformePorDni_Y_TipoDoc]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_ROW_CandidatoInformePorDni_Y_TipoDoc]
@cDNI varchar(15),
@cTipoDoc varchar(6)    
AS
BEGIN
	SELECT TOP 1 *
	FROM dbo.CandidatoInforme AS ci    
	where  ci.cDNI=@cDNI and ci.cTipoDoc=@cTipoDoc
END
GO
/****** Object:  StoredProcedure [main].[SP_ROW_GetLogin]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_ROW_GetLogin] 
@cNick varchar(40),@cClave varchar(40)   
AS  
BEGIN
	SELECT  u.iCodUsuario,  
			p.iCodPersona,   
			p.cApelP + ' ' + p.cApelM + ' ' + p.cNombres as cNomPersona,  
			u.cNick,   
			u.cTipo 
	FROM  usuario u   
	INNER JOIN PersonaNatural p on u.iCodPersona=p.iCodPersona     
	where dbo.fnLeeClave(u.cClave)=ltrim(rtrim(@cClave)) and u.cNick=@cNick and   
	u.bBloqueado=0
 END
GO
/****** Object:  StoredProcedure [main].[SP_ROW_PersonaUCByNick]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_ROW_PersonaUCByNick] 
@cNick varchar(40)    
AS
BEGIN
	SELECT  uc.iCodUsuarioContrata,uc.iCodContrata,u.iCodUsuario,   
			ltrim(rtrim(pn.cApelP + ' ' + pn.cApelM )) + ' ' +  pn.cNombres as cNomCompleto,  
			pn.cCorreo,  
			uc.bAcceder   
	FROM   UsuarioContrata AS uc   
	inner join usuario u on uc.iCodUsuario=u.iCodUsuario  
	inner join personanatural pn on u.iCodPersona=pn.iCodPersona     
	where  u.cNick=@cNick   
END
GO
/****** Object:  StoredProcedure [main].[SP_ROW_UltimaActualizacionDiasBloqueado]    Script Date: 4/09/2025 15:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [main].[SP_ROW_UltimaActualizacionDiasBloqueado]        
@iCodCandidatoInforme int         
AS      
BEGIN      
	SELECT top 1 CASE
					 WHEN DATEDIFF(DAY, ISNULL(ca.dFechaRegistro, GETDATE()), GETDATE())>6 THEN 'NO'
					 ELSE 'SI'
				 END cBloqueaRegistroActualizacion,
				 convert(varchar(16), DATEADD(DAY, 7, ca.dFechaRegistro), 103) as cFechaFinBloqueo,
				 convert(varchar(16), ciad.dFechaFinObservado, 103) AS cFechaFinObservado
	FROM CandidatoAdmision ca
	LEFT JOIN candidatoinformeadd ciad ON ca.iCodCandidatoInforme=ciad.iCodCandidatoInforme
	WHERE ca.iCodCandidatoInforme=@iCodCandidatoInforme
	  AND ca.iCodCandidatoAdmisionTipo=3
	  AND ca.iResultadoTramite<>102 -- and ca.bImprocedente=0
	ORDER BY ca.iCodCandidatoAdmision DESC 
END   
GO
