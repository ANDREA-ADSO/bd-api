using WebApi.Model;

namespace WebApi.Services
{
    public interface IEmpleadoService
    {
        List<Empleado> GetAllEmpleados(bool? isActive); 
        Empleado? GetEmpleadoByID(int id);
        Empleado AddEmpleado(AddUpdateEmpleado obj);
        Empleado? UpdateEmpleado(int id, AddUpdateEmpleado obj); 
        bool DeleteEmpleadoByID(int id);
    }

}
