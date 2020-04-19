namespace Genocs.WebApi.UseCases.V1.Register
{
    using Genocs.WebApi.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The response for Registration
    /// </summary>
    public sealed class RegisterResponse
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        [Required]
        public Guid CustomerId { get; }

        /// <summary>
        /// SSN
        /// </summary>
        [Required]
        public string SSN { get; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; }

        /// <summary>
        /// Accounts
        /// </summary>
        [Required]
        public List<AccountDetailsModel> Accounts { get; }

        public RegisterResponse(
            Guid customerId,
            string ssn,
            string name,
            List<AccountDetailsModel> accounts)
        {
            CustomerId = customerId;
            SSN = ssn;
            Name = name;
            Accounts = accounts;
        }
    }
}