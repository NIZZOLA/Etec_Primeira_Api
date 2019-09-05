using PrimeiraApi.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraApi.Validators
{
    public class ProductCreateRequestValidator
    {
        public bool IsValid(ProductCreateRequest prod )
        {
            bool resposta = true;

            if (string.IsNullOrEmpty(prod.Descricao))
                resposta = false;

            if (string.IsNullOrEmpty(prod.UnidadeDeMedida))
                resposta = false;

            return resposta;
        }
    }
}
