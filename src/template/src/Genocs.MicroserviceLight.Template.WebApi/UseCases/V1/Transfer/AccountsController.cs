namespace Genocs.MicroserviceLight.Template.WebApi.UseCases.V1.Transfer
{
    using Application.Boundaries.Transfer;
    using Domain.ValueObjects;
    using Extensions.FeatureFlags;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    [FeatureGate(Features.Transfer)]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
        private readonly IUseCase _TransferUseCase;
        private readonly TransferPresenter _presenter;

        public AccountsController(
            IUseCase TransferUseCase,
            TransferPresenter presenter)
        {
            _TransferUseCase = TransferUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Transfer to an account
        /// </summary>
        /// <response code="200">The updated balance.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="request">The request to Transfer.</param>
        /// <returns>The updated balance.</returns>
        [HttpPatch("Transfer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransferResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Transfer([FromBody][Required] TransferRequest request)
        {
            var transferInput = new TransferInput(
                    request.OriginAccountId,
                    request.DestinationAccountId,
                    new PositiveMoney(request.Amount)
                );

            await _TransferUseCase.Execute(transferInput);
            return _presenter.ViewModel;
        }
    }
}