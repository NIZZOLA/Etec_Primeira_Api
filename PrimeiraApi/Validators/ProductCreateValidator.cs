using PrimeiraApi.Data;
using PrimeiraApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraApi.Validators
{
    public class ProductCreateValidator
    {
        PrimeiraApiContext _context;
        Produto produto;

        public ProductCreateValidator( PrimeiraApiContext context, Produto prod )
        {
            produto = prod;
            _context = context;
        }

        public List<string> IsValid()
        {
            List<string> errors = new List<string>();

            

            // validacao descricao e unidade
            var exist = _context.Produto.Where(a => a.Descricao == produto.Descricao &&
                                                    a.UnidadeDeMedida == produto.UnidadeDeMedida &&
                                                    a.Ativo == true).Count();
            if (exist > 0)
                errors.Add( "Produto já existe com esta descrição e unidade de medida" );
            // 
            return errors;
        }
    }
}
