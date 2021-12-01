using ExercicioApiEcommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExercicioApiEcommerce.Servicos
{
    public class ProdutoService
    {
        private readonly List<Produto> _produtos;
        public ProdutoService()
        {
            _produtos ??= new List<Produto>();
        }

        public Produto Cadastrar(Produto produto)
        {
            _produtos.Add(produto);
            return produto;
        }

        public Produto Get(Guid id) => _produtos.Where(u => u.Id == id).SingleOrDefault();
        public IEnumerable<Produto> Get() => _produtos;
        public void Delete(Guid id)
        {
            var produto = _produtos.SingleOrDefault(u => u.Id == id);

            if (produto is null)
                throw new Exception("Produto não encontrado!");

            _produtos.Remove(produto);
        }

        public Produto Atualizar(Guid id, Produto produto)
        {
            var prod = _produtos.SingleOrDefault(u => u.Id == id);

            if (prod is null)
                throw new Exception("Produto não encontrado!");

            prod.Atualizar(produto);
            return prod;
            
        }


    }
}
