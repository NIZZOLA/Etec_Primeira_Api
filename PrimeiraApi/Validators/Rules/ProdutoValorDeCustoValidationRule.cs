using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraApi.Validators.Rules
{
    public class ProdutoValorDeCustoValidationRule
    {
        // validação do preço
            if (produto.ValorDeCusto == 0)
                errors.Add( "Valor de custo não pode ser zero" );

    }
}
