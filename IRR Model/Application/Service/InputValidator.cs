using IRR.Application.Payload;
using FluentValidation;


namespace IRR.Application.Service
{
    public class InputValidator: AbstractValidator<IRRInputs>
    {

        public InputValidator() {




            RuleSet("default", () =>
            {

                RuleFor(x => x.QuarterStartDate).NotNull();
                RuleFor(x => x.CommutationDate).NotNull();


            });
        
            
        
        
        
        }
       


    }
}
