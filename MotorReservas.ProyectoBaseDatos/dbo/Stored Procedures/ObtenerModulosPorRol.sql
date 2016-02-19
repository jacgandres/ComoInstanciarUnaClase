-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerModulosPorRol
	-- Add the parameters for the stored procedure here
	@IdRol int
AS
BEGIN 
	SELECT        Modulo.IdModulo, Modulo.Nombre, Modulo.FechaRegistro, Modulo.Activo, Modulo.Descripcion
	FROM            Modulo INNER JOIN
							 Modulos_Tiene_Rol ON Modulo.IdModulo = Modulos_Tiene_Rol.IdModulo
	WHERE        (Modulos_Tiene_Rol.IdRol = @IdRol)
END