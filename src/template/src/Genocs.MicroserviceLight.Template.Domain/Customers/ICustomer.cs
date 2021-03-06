namespace Genocs.MicroserviceLight.Template.Domain.Customers
{
    using Accounts;

    public interface ICustomer : IAggregateRoot
    {
        AccountCollection Accounts { get; }
        void Register(IAccount account);
    }
}