using Api_Prueba.Models;

namespace Api_Prueba.Services
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria>Get();

        Task Save(Categoria categoria);

        Task Update(Guid id,Categoria categoria);

        Task Delete(Guid id);
    }
}