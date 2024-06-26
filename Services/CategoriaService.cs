using Api_Prueba.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api_Prueba.Services
{
    public class CategoriaService:ICategoriaService
    {
        ApplicationDbcontex context;

        public CategoriaService(ApplicationDbcontex dbcontex)
        {
            context = dbcontex;
        }
        public IEnumerable<Categoria>Get()
        {
            return context.Categorias;
        }

        public async Task Save(Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id,Categoria categoria)
        {   
            var categoriaActual = context.Categorias.Find(id);
            if (categoriaActual != null)
            {
                categoriaActual.Nombre = categoria.Nombre;
                categoria.Descripcion = categoria.Descripcion;
                categoria.Peso = categoria.Peso;

                await context.SaveChangesAsync();
            }
            
        }

        public async Task Delete(Guid id)
        {   
            var categoriaActual = context.Categorias.Find(id);
            if (categoriaActual != null)
            {
                context.Remove(categoriaActual);
                await context.SaveChangesAsync();
            }
            
        }
    }
}