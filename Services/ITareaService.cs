using Api_Prueba.Models;

namespace Api_Prueba.Services
{
    public interface ITareaService
    {
        IEnumerable<Tarea> Get();

        Task Save(Tarea tarea);

        Task Update(Guid id, Tarea tarea);
        Task Delete(Guid id);
    }
}