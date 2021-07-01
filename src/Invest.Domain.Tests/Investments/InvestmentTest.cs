using System;
using FluentAssertions;
using Invest.Domain.Common;
using Invest.Domain.Investments;
using Xunit;

namespace Invest.Domain.Tests.Investments
{
    public class InvestmentTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void NewInvestment_InvalidName_ThrowsDomainException(string name)
        {
            Action action = () =>
            {
                var investment = new Investment(
                    name,
                    10m,
                    10m,
                    DateTime.Now.AddHours(1),
                    new FixedIncomeTaxesPolicy());
            };

            action.Should().Throw<DomainException>()
                .WithMessage("Invalid name");
        }

        [Theory]
        [InlineData(0, 0, "Invalid invested value")]
        [InlineData(-1, 1, "Invalid invested value")]
        [InlineData(1, -1, "Invalid total value")]
        public void NewInvestment_InvalidValue_ThrowsDomainException(
            decimal investedValue, decimal totalValue, string message)
        {
            Action action = () =>
            {
                var investment = new Investment(
                    Guid.NewGuid().ToString(),
                    investedValue,
                    totalValue,
                    DateTime.Now.AddHours(1),
                    new FixedIncomeTaxesPolicy());
            };

            action.Should().Throw<DomainException>()
                .WithMessage(message);
        }

        [Fact]
        public void NewInvestment_DefaultDueDate_ThrowsDomainException()
        {
            Action action = () =>
            {
                var investment = new Investment(
                    Guid.NewGuid().ToString(),
                    10m,
                    10m,
                    default,
                    new FixedIncomeTaxesPolicy());
            };

            action.Should().Throw<DomainException>()
                .WithMessage("Invalid due date");
        }
    }
}