namespace Genocs.MicroserviceLight.Template.Application.UseCases
{
    using Genocs.MicroserviceLight.Template.Application.Boundaries.GetCustomerDetails;
    using Genocs.MicroserviceLight.Template.Application.Repositories;
    using Genocs.MicroserviceLight.Template.Domain.Accounts;
    using Genocs.MicroserviceLight.Template.Domain.Customers;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public sealed class GetCustomerDetails : IUseCase
    {
        private readonly IOutputPort _outputHandler;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;

        public GetCustomerDetails(
            IOutputPort outputHandler,
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository)
        {
            _outputHandler = outputHandler;
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
        }

        public async Task Execute(GetCustomerDetailsInput input)
        {
            ICustomer customer = await _customerRepository.Get(input.CustomerId);

            if (customer == null)
            {
                _outputHandler.NotFound($"The customer {input.CustomerId} does not exist or is not processed yet.");
                return;
            }

            List<Boundaries.GetCustomerDetails.Account> accounts = new List<Boundaries.GetCustomerDetails.Account>();

            foreach (Guid accountId in customer.Accounts.GetAccountIds())
            {
                IAccount account = await _accountRepository.Get(accountId);

                if (account != null)
                {
                    Boundaries.GetCustomerDetails.Account accountOutput = new Boundaries.GetCustomerDetails.Account(account);
                    accounts.Add(accountOutput);
                }
            }

            GetCustomerDetailsOutput output = new GetCustomerDetailsOutput(customer, accounts);
            _outputHandler.Default(output);
        }
    }
}