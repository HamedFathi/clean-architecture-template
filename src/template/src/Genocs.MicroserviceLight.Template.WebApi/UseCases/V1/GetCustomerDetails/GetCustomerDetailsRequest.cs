namespace Genocs.MicroserviceLight.Template.WebApi.UseCases.V1.GetCustomerDetails
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The Get Customer Details Request
    /// </summary>
    public sealed class GetCustomerDetailsRequest
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        [Required]
        public Guid CustomerId { get; set; }
    }
}