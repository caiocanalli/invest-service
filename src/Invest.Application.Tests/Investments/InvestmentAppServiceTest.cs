using System;
using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using Invest.Application.Investments;
using Invest.Domain.Investments;
using Invest.Infra.Cache;
using Invest.Infra.DirectTreasury;
using Invest.Infra.FixedIncome;
using Invest.Infra.Funds;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using InvestmentDto = Invest.Application.Investments.InvestmentDto;
using RecoverInvestmentDto = Invest.Application.Investments.RecoverInvestmentDto;

namespace Invest.Application.Tests.Investments
{
    public class InvestmentAppServiceTest
    {
        readonly InvestmentAppService _investmentAppService;

        readonly Mock<IMapper> _mapperMock;
        readonly Mock<ILogger<InvestmentAppService>> _logger;
        readonly Mock<IInvestmentCacheService> _investmentCacheServiceMock;
        readonly Mock<IDirectTreasuryService> _directTreasuryServiceMock;
        readonly Mock<IFixedIncomeService> _fixedIncomeServiceMock;
        readonly Mock<IFundsService> _fundsServiceMock;

        public InvestmentAppServiceTest()
        {
            _mapperMock = new Mock<IMapper>();
            _logger = new Mock<ILogger<InvestmentAppService>>();
            _investmentCacheServiceMock = new Mock<IInvestmentCacheService>();
            _directTreasuryServiceMock = new Mock<IDirectTreasuryService>();
            _fixedIncomeServiceMock = new Mock<IFixedIncomeService>();
            _fundsServiceMock = new Mock<IFundsService>();

            _investmentAppService = new InvestmentAppService(
                _mapperMock.Object,
                _logger.Object,
                _investmentCacheServiceMock.Object,
                _directTreasuryServiceMock.Object,
                _fixedIncomeServiceMock.Object,
                _fundsServiceMock.Object);
        }

        [Fact]
        public void Recover_CacheValid_ReturnsIt()
        {
            var customerId = new Random().Next();

            var cacheDto = new RecoverInvestmentCacheDto
            {
                Investments = new List<InvestmentCacheDto> { new(), new() },
                TotalValue = new Random().Next(1, 5000)
            };
            
            var dto = new RecoverInvestmentDto
            {
                Investments = new List<InvestmentDto> { new(), new() },
                TotalValue = new Random().Next(1, 5000)
            };

            _investmentCacheServiceMock.Setup(x =>
                    x.Recover(customerId))
                .ReturnsAsync(cacheDto);

            _mapperMock.Setup(x =>
                    x.Map<RecoverInvestmentDto>(cacheDto))
                .Returns(dto);

            var actualResult = _investmentAppService.Recover(customerId).Result;

            actualResult.Should().NotBeNull();
            actualResult.Success.Should().BeTrue();
            actualResult.Value.Should().Be(dto);
            actualResult.Value.Investments.Count.Should().Be(2);

            _investmentCacheServiceMock.Verify(x =>
                    x.Recover(customerId),
                Times.Once);

            _directTreasuryServiceMock.Verify(x =>
                    x.RecoverInvestment(),
                Times.Never);

            _fixedIncomeServiceMock.Verify(x =>
                    x.RecoverInvestment(),
                Times.Never);

            _fundsServiceMock.Verify(x =>
                    x.RecoverInvestment(),
                Times.Never);

            _investmentCacheServiceMock.Verify(x =>
                    x.Store(It.IsAny<int>(), It.IsAny<RecoverInvestmentCacheDto>()),
                Times.Never);
        }
        
        [Fact]
        public void Recover_CacheInvalid_ReturnsInvestments()
        {
            var customerId = new Random().Next();

            _investmentCacheServiceMock.Setup(x =>
                    x.Recover(customerId))
                .ReturnsAsync(() => null);

            _directTreasuryServiceMock.Setup(x =>
                    x.RecoverInvestment())
                .ReturnsAsync(() => new List<Investment>());

            _fixedIncomeServiceMock.Setup(x =>
                    x.RecoverInvestment())
                .ReturnsAsync(() => new List<Investment>());

            _fundsServiceMock.Setup(x =>
                    x.RecoverInvestment())
                .ReturnsAsync(() => new List<Investment>());

            var dto = new RecoverInvestmentDto
            {
                Investments = new List<InvestmentDto> { new(), new() },
                TotalValue = new Random().Next(1, 5000)
            };

            _mapperMock.Setup(x =>
                    x.Map<RecoverInvestmentDto>(new List<Investment>()))
                .Returns(dto);

            var actualResult = _investmentAppService.Recover(customerId).Result;

            actualResult.Should().NotBeNull();
            actualResult.Success.Should().BeTrue();
            actualResult.Value.Should().Be(dto);
            actualResult.Value.Investments.Count.Should().Be(2);

            _investmentCacheServiceMock.Verify(x =>
                    x.Recover(customerId),
                Times.Once);

            _directTreasuryServiceMock.Verify(x =>
                    x.RecoverInvestment(),
                Times.Once);

            _fixedIncomeServiceMock.Verify(x =>
                    x.RecoverInvestment(),
                Times.Once);

            _fundsServiceMock.Verify(x =>
                    x.RecoverInvestment(),
                Times.Once);

            _investmentCacheServiceMock.Verify(x =>
                    x.Store(It.IsAny<int>(), It.IsAny<RecoverInvestmentCacheDto>()),
                Times.Once);
        }
    }
}