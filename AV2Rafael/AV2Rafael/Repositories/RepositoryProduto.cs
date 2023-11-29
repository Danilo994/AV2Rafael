using AV2Rafael.Repositories;
using AV2Rafael.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AV2Rafael.Repositories
{
    public class RepositoryProduto : RepositoryBase<Produto>
    {
        public RepositoryProduto(bool saveChanges = true) : base(saveChanges)
        {

        }

        public async Task IncluirAsync(List<Produto> listaProdutos)
        {
            foreach (var item in listaProdutos)
            {
                _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Produto> SelecionarPkAsync(int id)
        {
            var produto = await _context.Produto
                .Include(p => p.IdCategoriaNavigation)  // Inclui a navegação para a Categoria
                .FirstOrDefaultAsync(p => p.IdProduto == id);

            return produto;
        }


        public async Task<List<Produto>> SelecionarTodosAsync()
        {
            var produtosComCategoria = await _context.Produto
                .Include(p => p.IdCategoriaNavigation)  // Inclui a navegação para a Categoria
                .ToListAsync();

            return produtosComCategoria;
        }
    }
}