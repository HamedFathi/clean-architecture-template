namespace Genocs.MicroserviceLight.Template.Domain.Accounts
{
    using Genocs.MicroserviceLight.Template.Domain.ValueObjects;

    public interface IDebit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}