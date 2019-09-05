using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraApi.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [MaxLength(100, ErrorMessage = "O campo {0} não pode ultrapassar {1} caracteres")]
        public string Descricao { get; set; }
        public UnidadeDeMedidaEnum UnidadeDeMedida { get; set; }
        public Decimal ValorDeCusto { get; set; }
        public Decimal MargemDeLucro { get; set; }
        public Decimal ValorDeVenda { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
