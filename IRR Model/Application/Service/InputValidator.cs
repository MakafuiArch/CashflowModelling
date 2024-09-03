using FluentValidation;
using IRR.Application.Payload.Request;


namespace IRR.Application.Service
{
    public class InputValidator: AbstractValidator<IRRInputs>
    {

        public InputValidator() {




            RuleSet("mulitiyear", () =>
            {

                RuleFor(x => x.QuarterStartDate).NotNull();
                RuleFor(x => x.CommutationDate).NotNull();
                RuleFor(x => x.SPInvestorId).NotNull();
                RuleFor(x => x.QuarterStartDate).LessThan(day => day.QuarterEndDate);

            });

            RuleSet("singleyear", () =>
            {



            });
        
            
        
        
        
        }
       


    }
}
