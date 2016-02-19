-- =============================================
-- Author:		Jaime Andres Carvajal
-- Create date: 02/03/2015
-- Description:	Obtiene los roles por usuario
-- =============================================
CREATE PROCEDURE ObtenerRolesPorUsuario
	@IdUsuario int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT        Rol.IdRol, Rol.Nombre, Rol.FechaRegistro, Rol.Activo, Rol.Descripcion
	FROM            Rol INNER JOIN
							 Usuario_Tiene_Rol ON Rol.IdRol = Usuario_Tiene_Rol.IdRol
	WHERE        (Usuario_Tiene_Rol.IdUsuario = @IdUsuario)
END
