using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceProxy.Application.Features.AirportDistance
{
    public class CalculateDistanceCommandValidator : AbstractValidator<CalculateDistanceCommand>
    {
        public CalculateDistanceCommandValidator()
        {
            string threeLettersAllow = "^[a-zA-Z]{3}$";

            RuleFor(x => x.FirstAirportIata).NotNull().NotEmpty().WithMessage("FirstAirportIata can't be empty").Matches(threeLettersAllow).WithMessage("FirstAirportIata isn't correct format");
            RuleFor(x => x.SecondAirportIata).NotNull().NotEmpty().WithMessage("SecondAirportIata can't be empty").Matches(threeLettersAllow).WithMessage("SecondAirportIata isn't correct format");
        }
    }
}
