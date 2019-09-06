using FluentValidation;
using PrimeiraApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraApi.Validators.Rules
{
    public class ProdutoUnidadeDeMedidaValidationRule : AbstractValidator<Produto>
    {

        public ProdutoUnidadeDeMedidaValidationRule()
        {
            RuleFor(a => a.UnidadeDeMedida).NotEqual(UnidadeDeMedidaEnum.UNDEFINED).WithMessage("A unidade de medida não é válida");
            RuleFor(a => a.UnidadeDeMedida).IsInEnum<UnidadeDeMedidaEnum>().withm   
        }
        


}
}
