namespace MADE.Samples.Features.Samples.ViewModels
{
    using System;
    using System.Collections.Generic;
    using CommunityToolkit.Mvvm.Messaging;
    using FluentValidation;
    using MADE.Data.Validation;
    using MADE.Data.Validation.Validators;
    using MADE.UI.Views.Navigation;
    using MADE.UI.Views.Navigation.ViewModels;

    public class InputValidatorPageViewModel : PageViewModel
    {
        private string inputText;
        private DateTimeOffset? inputDate;
        private string fluentValidationInputText;

        public InputValidatorPageViewModel(INavigationService navigationService, IMessenger messenger)
            : base(navigationService, messenger)
        {
        }

        public ValidatorCollection InputTextValidators { get; } =
            new ValidatorCollection { new RequiredValidator(), new MaxLengthValidator(16) };

        public string InputText
        {
            get => inputText;
            set => this.SetProperty(ref inputText, value);
        }

        public ValidatorCollection InputDateValidators { get; } = new ValidatorCollection
        {
            new RequiredValidator(),
            new BetweenValidator(DateTimeOffset.Now.AddDays(-7), DateTimeOffset.Now.AddDays(7))
        };

        public DateTimeOffset? InputDate
        {
            get => inputDate;
            set => this.SetProperty(ref inputDate, value);
        }

        public FluentValidatorCollection<string> FluentValidationValidators { get; } = new(GetFluentValidators());

        public string FluentValidationInputText
        {
            get => fluentValidationInputText;
            set => this.SetProperty(ref fluentValidationInputText, value);
        }

        private static IEnumerable<AbstractValidator<string>> GetFluentValidators()
        {
            var requiredValidator = new InlineValidator<string>();
            requiredValidator
                .RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A value is required.");

            var maxLengthValidator = new InlineValidator<string>();
            maxLengthValidator
                .RuleFor(x => x.Length)
                .LessThanOrEqualTo(16)
                .WithMessage("The length of the value must be less than or equal to 16 characters.");

            return new[] { requiredValidator, maxLengthValidator };
        }
    }
}