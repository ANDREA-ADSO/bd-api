using WebApi.Model;

namespace WebApi.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoService(ApplicationDbContext context)
        {
            _context = context;
        }


        public Empleado AddEmpleado(AddUpdateEmpleado empleadoData)
        {
            var newEmpleado = new Empleado
            {
                Identificacion = empleadoData.Identificacion,
                Nombre = empleadoData.Nombre,

                HorasTrabajadas = empleadoData.HorasTrabajadas,
                SueldoPorHora = empleadoData.SueldoPorHora,
                IsActive = empleadoData.IsActive
            };

            _context.Empleados.Add(newEmpleado);
            _context.SaveChanges(); return newEmpleado;
        }


        public bool DeleteEmpleadoByID(int id)
        {
            var empleado = _context.Empleados.Find(id); if (empleado == null) return false;

            _context.Empleados.Remove(empleado);
            _context.SaveChanges(); return true;
        }


        public List<Empleado> GetAllEmpleados(bool? isActive = null)

        {
            return isActive == null
            ? _context.Empleados.ToList()
            : _context.Empleados.Where(emp => emp.IsActive ==

            isActive).ToList();
        }


        public Empleado? GetEmpleadoByID(int id)
        {
            return _context.Empleados.Find(id);
        }




        public Empleado? UpdateEmpleado(int id, AddUpdateEmpleado empleadoData)
        {
            var empleado = _context.Empleados.Find(id); if (empleado == null) return null;

            empleado.Identificacion = empleadoData.Identificacion; empleado.Nombre = empleadoData.Nombre; empleado.HorasTrabajadas =
            empleadoData.HorasTrabajadas;
            empleado.SueldoPorHora = empleadoData.SueldoPorHora; empleado.IsActive = empleadoData.IsActive;

            _context.SaveChanges(); return empleado;
        }

    }

}
