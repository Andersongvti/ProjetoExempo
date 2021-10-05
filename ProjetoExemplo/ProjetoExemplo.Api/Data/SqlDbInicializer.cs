using ProjetoExemplo.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoExemplo.Api.Data
{
    public class SqlDbInicializer : CreateDatabaseIfNotExists<SqlDbContext>
    {
        protected override void Seed(SqlDbContext context)
        {
            IList<Produto> defaultProdutos = new List<Produto>();

            defaultProdutos.Add(new Produto
            {
                CodigoDoProduto = "001",
                DescricaoDoProduto = "Desc Prod 001",
                Status = "0"
            });

            defaultProdutos.Add(new Produto
            {
                CodigoDoProduto = "002",
                DescricaoDoProduto = "Desc Prod 002",
                Status = "2"
            });

            defaultProdutos.Add(new Produto
            {
                CodigoDoProduto = "003",
                DescricaoDoProduto = "Desc Prod 002",
                Status = "1"
            });

            context.Produtos.AddRange(defaultProdutos);

            IList<ProdutoCosif> defaultProdutosCosif = new List<ProdutoCosif>();

            defaultProdutosCosif.Add(new ProdutoCosif
            {
                CodigoClassificacao = "12345",
                CodigoCosif = "11111",
                CodigoProduto = "003",
                Status = "0"
            });

            defaultProdutosCosif.Add(new ProdutoCosif
            {
                CodigoClassificacao = "123456",
                CodigoCosif = "22222",
                CodigoProduto = "002",
                Status = "0"
            });

            defaultProdutosCosif.Add(new ProdutoCosif
            {
                CodigoClassificacao = "1234567",
                CodigoCosif = "33333",
                CodigoProduto = "001",
                Status = "0"
            });

            context.ProdutosCosif.AddRange(defaultProdutosCosif);
            
            base.Seed(context);
        }
    }
}