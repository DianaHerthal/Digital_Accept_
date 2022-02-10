using FluentValidation;

namespace Digital_Accept.Application.Documents.Commands.CreateDocument
{
    public class CreateDocumentCommandValidation : AbstractValidator<CreateDocumentCommand>
    {
        public CreateDocumentCommandValidation()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Enter the description..")
                .MinimumLength(2).WithMessage("The description must be at least 2 characters long.")
                .MaximumLength(400).WithMessage("The description must have a maximum of 400 characters.");

            RuleFor(c => c.Title)
               .NotEmpty().WithMessage("Enter the title.")
               .MinimumLength(2).WithMessage("The title must be at least 2 characters long.")
               .MaximumLength(200).WithMessage("The title must have a maximum of 200 characters.");
        }
    }
}
