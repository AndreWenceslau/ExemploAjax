using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private SistemaContext context;

        public ProdutoRepository()
        {
            context = new SistemaContext();
        }



        public bool Apagar(int id)
        {
            var venda = context.Produtos.FirstOrDefault(X => X.id == id);

            if (venda == null)
                return false;

            venda.RegistroAtivo = true;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public int Inserir(Produto produto)
        {
            context.Produtos.Add(produto);
            context.SaveChanges();
            return produto.id;
        }

        public Produto ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ObterProdutospeloIdVenda(int IdVenda)
        {
            return context.Produtos.Where(x => x.IdVenda == IdVenda).ToList();
        }

        public bool Alterar(Produto produto)
        {
            var produtoOriginal = context.Produtos.FirstOrDefault(x => x.id == produto.id);

            if (produtoOriginal == null)
                return false;

            produtoOriginal.Nome = produto.Nome;
            produtoOriginal.Quantidade = produto.Quantidade;
            produtoOriginal.Valor = produto.Valor;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;

        }
    }
}
