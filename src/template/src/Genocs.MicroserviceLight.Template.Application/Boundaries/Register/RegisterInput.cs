namespace Genocs.MicroserviceLight.Template.Application.Boundaries.Register
{
    using Genocs.MicroserviceLight.Template.Application.Exceptions;
    using Genocs.MicroserviceLight.Template.Domain.ValueObjects;

    public sealed class RegisterInput
    {
        public SSN SSN { get; }
        public Name Name { get; }
        public PositiveMoney InitialAmount { get; }

        public RegisterInput(SSN ssn, Name name, PositiveMoney initialAmount)
        {
            if (ssn == null)
            {
                throw new InputValidationException($"{nameof(ssn)} cannot be null.");
            }

            if (name == null)
            {
                throw new InputValidationException($"{nameof(name)} cannot be null.");
            }

            if (initialAmount == null)
            {
                throw new InputValidationException($"{nameof(initialAmount)} cannot be null.");
            }

            SSN = ssn;
            Name = name;
            InitialAmount = initialAmount;
        }
    }
}