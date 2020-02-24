using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraApi.Contracts.Response
{
    public class ProdutoCreateResponse
    {
        public string Descricao { get; set; }
        public string UnidadeDeMedida { get; set; }
        public Decimal ValorDeCusto { get; set; }
        public Decimal MargemDeLucro { get; set; }
        public Decimal ValorDeVenda { get; set; }

    }
}
