
CREATE procedure ObtenerModulosRolesPorUsuario
@IdUsuario int
as
begin
SELECT        Modulo.IdModulo, Modulo.Nombre, Modulo.FechaRegistro, Modulo.Activo, Modulo.Descripcion
FROM            Modulos_Tiene_Rol INNER JOIN
                         Modulo ON Modulos_Tiene_Rol.IdModulo = Modulo.IdModulo INNER JOIN
                         Rol ON Modulos_Tiene_Rol.IdRol = Rol.IdRol INNER JOIN
                         Usuario_Tiene_Rol ON Rol.IdRol = Usuario_Tiene_Rol.IdRol
WHERE        (Usuario_Tiene_Rol.IdUsuario = @IdUsuario)
end

