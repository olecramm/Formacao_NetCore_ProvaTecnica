using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> AdicionaCategoria(string nomeCategoria);
    }

    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<Categoria> AdicionaCategoria(string nomeCategoria)
        {
            var categoriaDB = dbSet.Where(c => c.Nome == nomeCategoria)
                .SingleOrDefault();

            if (categoriaDB != null)
            {
                throw new ArgumentException("Categoria já cadastrada!");
            }

            categoriaDB.Adiciona(nomeCategoria);
            await contexto.SaveChangesAsync();
            return categoriaDB;
        }
    }

}
