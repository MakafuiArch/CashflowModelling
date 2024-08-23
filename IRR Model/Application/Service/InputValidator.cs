using IRR.Application.IRR.Payload;
using FluentValidation;


namespace IRR.Application.IRR.Service
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
