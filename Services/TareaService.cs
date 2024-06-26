using Api_Prueba.Models;

namespace Api_Prueba.Services
{
    public class TareaService: ITareaService
    {
        ApplicationDbcontex context;

        public TareaService(ApplicationDbcontex dbcontex)
        {
            context = dbcontex;
        }

        public IEnumerable<Tarea> Get()
        {
            return context.Tareas;
        }

        public async Task Save(Tarea tarea)
        {
            context.Add(tarea);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tarea tarea)
        {
            var tareaActual = context.Tareas.Find(id);
            if (tareaActual !=null)
            {
                tareaActual.Titulo = tarea.Titulo;
                tarea.Descripcion = tarea.Descripcion;
                tarea.Prioridad = tarea.Prioridad;
                tarea.FechaCreacion = tarea.FechaCreacion;

            }
        }

        public async Task Delete(Guid id)
        {
            var tareaActual = context.Tareas.Find(id);
            if (tareaActual != null)
            {
                context.Remove(tareaActual);
                await context.SaveChangesAsync();
            }
        }




    }

}