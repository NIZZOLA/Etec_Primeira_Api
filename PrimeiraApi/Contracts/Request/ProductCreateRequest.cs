using PrimeiraApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraApi.Contracts.Request
{
    public class ProductCreateRequest
    {
        public string Descricao { get; set; }
        public string UnidadeDeMedida { get; set; }
        public Decimal ValorDeCusto { get; set; }
        public Decimal MargemDeLucro { get; set; }
        public Decimal ValorDeVenda { get; set; }
        
    }
}
