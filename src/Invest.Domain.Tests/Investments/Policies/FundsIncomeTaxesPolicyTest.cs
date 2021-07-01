using System;
using FluentAssertions;
using Invest.Domain.Investments;
using Xunit;

namespace Invest.Domain.Tests.Investments.Policies
{
    public class FundsIncomeTaxesPolicyTest
    {
        [Theory]
        [InlineData(100, 110, 1.5)]
        [InlineData(200, 225, 3.75)]
        [InlineData(555, 500, 0)]
        [InlineData(125, 115, 0)]
        [InlineData(546, 658, 16.8)]
        [InlineData(7878, 7800, 0)]
        [InlineData(145, 140, 0)]
        public void CalcIncomeTaxes_Returns(decimal investedValue, decimal totalValue, decimal expectedResult)
        {
            var investment = new Investment(
                Guid.NewGuid().ToString(),
                investedValue,
                totalValue,
                DateTime.Now.AddHours(1),
                new FundsIncomeTaxesPolicy());

            investment.IncomeTaxes.Should().Be(expectedResult);
        }
    }
}