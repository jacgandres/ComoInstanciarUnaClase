-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE InventariosPorEmpresa 
	@IdEmpresa int
AS
BEGIN
	SELECT        IdInventario, Nombre, FechaRegistro, IdEmpresa, IdTipoInventario
	FROM            Inventario
	WHERE        (IdEmpresa = @IdEmpresa)	 
END
