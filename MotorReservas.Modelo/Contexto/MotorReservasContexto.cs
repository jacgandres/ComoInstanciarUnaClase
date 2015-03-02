namespace MotorReservas.ModeloAdministrativo
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using MotorReservas.Entidad;

    public class MotorReservasContexto : DbContext
    {
        public MotorReservasContexto()
            : base("name=MotorReservasContexto")
        {
        }

        public DbSet<CanalVenta> CanalVenta { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<DetalleReserva> DetalleReserva { get; set; }
        public DbSet<Diccionario> Diccionario { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EstadoContrato> EstadoContrato { get; set; }
        public DbSet<FormaPago> FormaPago { get; set; }
        public DbSet<FormaPago_Tiene_Reserva> FormaPago_Tiene_Reserva { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Modulos_Tiene_Rol> Modulos_Tiene_Rol { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Producto_Tiene_Reserva> Producto_Tiene_Reserva { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Sede> Sede { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Servicio_Tiene_Reserva> Servicio_Tiene_Reserva { get; set; }
        public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public DbSet<TipoInventario> TipoInventario { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<TipoReserva> TipoReserva { get; set; }
        public DbSet<TipoServicio> TipoServicio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Usuario_Tiene_Rol> Usuario_Tiene_Rol { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}
