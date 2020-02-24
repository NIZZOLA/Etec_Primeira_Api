using PrimeiraApi.Contracts.Request;
using PrimeiraApi.Contracts.Response;
using PrimeiraApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraApi.ExtensionMethods
{
    public static class ExtensionMethodsUtil
    {
        public static Produto ConverteParaProduto( this ProductCreateRequest produto )
        {
            Produto prod = new Produto();
            prod.Ativo = true;
            prod.DataCadastro = DateTime.Now;
            prod.Descricao = produto.Descricao;
            prod.MargemDeLucro = produto.MargemDeLucro;

            if (Enum.GetNames(typeof(UnidadeDeMedidaEnum)).Contains(produto.UnidadeDeMedida))
            {
                prod.UnidadeDeMedida = (UnidadeDeMedidaEnum)Enum.Parse(typeof(UnidadeDeMedidaEnum),
                                                                        produto.UnidadeDeMedida);
            }
            prod.ValorDeCusto = produto.ValorDeCusto;
            prod.ValorDeVenda = produto.ValorDeVenda;
            return prod;
        }

        public static ProdutoCreateResponse ConverteParaResponse(this Produto prod)
        {
            ProdutoCreateResponse response = new ProdutoCreateResponse();
            response.Descricao = prod.Descricao;
            response.MargemDeLucro = prod.MargemDeLucro;
            response.UnidadeDeMedida = prod.UnidadeDeMedida.ToString();
            response.ValorDeCusto = prod.ValorDeCusto;
            response.ValorDeVenda = prod.ValorDeVenda;
            return response;
        }

    }
}
