namespace Genocs.MicroserviceLight.Template.UnitTests.InputValidationTests
{
    using Application.Boundaries.Withdraw;
    using Application.Exceptions;
    using Domain.ValueObjects;
    using System;
    using Xunit;

    public sealed class WithdrawInputValidationTests
    {
        [Fact]
        public void GivenEmptyAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new WithdrawInput(
                    Guid.Empty,
                    new PositiveMoney(10)
                ));
            Assert.Contains("accountId", actualEx.Message);
        }

        [Fact]
        public void GivenNullAmount_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new WithdrawInput(
                    Guid.NewGuid(),
                    null
                ));
            Assert.Contains("amount", actualEx.Message);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new WithdrawInput(
                Guid.NewGuid(),
                new PositiveMoney(10)
            );
            Assert.NotNull(actual);
        }
    }
}