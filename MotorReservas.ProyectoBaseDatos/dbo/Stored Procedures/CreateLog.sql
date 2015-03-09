 -- =============================================
-- Author:		Jaime Carvajal
-- Create date: 04 Marzo del 2015
-- Description: Procedimiento almacenado para creacion de logs
-- =============================================
CREATE PROCEDURE [dbo].[CreateLog] 
@IsTrace bit,
@ModuleId int,
@ElapsedTime decimal(8,3),
@RecordLocator varchar(10),
@Action varchar(100),
@appUsuarioCorreo varchar(50),
@appUsuarioNombre varchar(50),
@FormattedMessage varchar(3000),
@Priority varchar(500),
@Severity varchar(500),
@Title varchar(500),
@Type varchar(500),
@MessageExplicitError varchar(2000),
@Status varchar(2000),
@StackTrace varchar(2000),
@Params varchar(2000),
@TracerGuid varchar(100), 
@Categories varchar(2000),
@ExtendedProperties varchar(2000),
@LogId bigint
AS
BEGIN
	begin try  
		     
		INSERT INTO [dbo].[Logs]
			 ([IsTrace],[ModuleId],[ElapsedTime],[RecordLocator],[Action],[AppUserId],[appUsuarioNombre],[FormattedMessage],[Priority],[Severity],[Title]
			 ,[Type],[MessageExplicitError],[Status],[StackTrace],[Params],[TracerGuid],[TracerDate])
		VALUES (@IsTrace,@ModuleId,@ElapsedTime,@RecordLocator,@Action,@appUsuarioCorreo,@appUsuarioNombre,@FormattedMessage,@Priority,
				@Severity,@Title,@Type,@MessageExplicitError,@Status,@StackTrace,@Params,@TracerGuid,GetDate())
		
		select @LogId = isnull(Max(LogId ),1) from  [dbo].[Logs]
 
		INSERT INTO [dbo].[Categories] ([LogId],[Categories])
		VALUES (@LogId ,@Categories)

		INSERT INTO [dbo].[Properties] ([LogId] ,[ExtendedProperties])
		VALUES (@LogId,@ExtendedProperties) 

		select @LogId 
	end try
	begin catch
		SELECT ERROR_NUMBER() AS ErrorNumber,ERROR_SEVERITY() AS ErrorSeverity,ERROR_STATE() AS ErrorState,
			ERROR_PROCEDURE() AS ErrorProcedure,ERROR_LINE() AS ErrorLine,ERROR_MESSAGE() AS ErrorMessage
	end catch
END