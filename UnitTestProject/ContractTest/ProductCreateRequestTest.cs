using PrimeiraApi.Contracts.Request;
using PrimeiraApi.Validators;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestProject.ContractTest
{
    public class ProductCreateRequestTest
    {
        private ProductCreateRequestValidator _validator;

        public ProductCreateRequestTest()
        {
            _validator = new ProductCreateRequestValidator();
        }

        [Fact(DisplayName = "Contrato Produto válido para ser incluído")]
        public async Task ProdutoValidoParaInclusao()
        {
            var produto = new ProductCreateRequest()
            {
                Descricao = "PRODUTO TESTE",
                MargemDeLucro = 30,
                UnidadeDeMedida = "CX",
                ValorDeCusto = 1,
                ValorDeVenda = 2
            };
            Assert.True(_validator.IsValid(produto));
        }

        [Fact(DisplayName = "Contrato Produto inválido para inclusão")]
        public async Task ProdutoInvalidoParaInclusao()
        {
            var produto = new ProductCreateRequest()
            {
                Descricao = "",
                MargemDeLucro = 30,
                UnidadeDeMedida = "",
                ValorDeCusto = 1,
                ValorDeVenda = 2
            };
            Assert.False(_validator.IsValid(produto));
        }

    }
}
