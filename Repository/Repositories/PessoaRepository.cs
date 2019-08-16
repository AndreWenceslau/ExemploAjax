using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private SistemaContext context;

        public PessoaRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Pessoa pessoa)
        {
            var pessoaOriginal = context.Pessoas.Where(x => x.Id == pessoa.Id).FirstOrDefault();

            if(pessoaOriginal == null)
            {
                return false;
            }
            pessoaOriginal.Nome = pessoa.Nome;
            pessoaOriginal.CPF = pessoa.CPF;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            var pessoa = context.Pessoas.FirstOrDefault(x => x.Id == id);
            if (pessoa == null)
            {
                return false;
            }

            pessoa.RegistroAtivo = false;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public int Inserir(Pessoa pessoa)
        {
            context.Pessoas.Add(pessoa);
            context.SaveChanges();
            return pessoa.Id;
        }

        public Pessoa ObterPeloId(int id)
        {
            var pessoa = context.Pessoas.Where(x => x.Id == id).FirstOrDefault();
            return pessoa;
        }

        public List<Pessoa> ObterTodos()
        {
            //select *from pessoas
            //where registro_ativo = true
            //order by nome;
            return context.Pessoas.Where(x => x.RegistroAtivo == true).ToList();
        }
    }
}
