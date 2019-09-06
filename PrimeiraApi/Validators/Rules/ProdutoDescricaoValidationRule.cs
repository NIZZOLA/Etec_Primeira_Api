using FluentValidation;
using PrimeiraApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraApi.Validators.Rules
{
    public class ProdutoDescricaoValidationRule : AbstractValidator<Produto>
    {
        public ProdutoDescricaoValidationRule()
        {
            RuleFor(a => a.Descricao).NotEmpty().WithMessage("O campo Descrição não pode ser vazio");
            RuleFor(a => a.Descricao).MaximumLength(100).WithMessage("O campo Descrição só pode conter no máximo 100 caracteres");
        }
    }
}
