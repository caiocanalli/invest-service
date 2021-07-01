using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Invest.Infra.Cache
{
    public class InvestmentCacheService : BaseCacheService, IInvestmentCacheService
    {
        private const string LayerNameSpace = "Investment";

        public InvestmentCacheService(
            IConfiguration configuration,
            ILogger<InvestmentCacheService> logger) : base(configuration, logger)
        {
        }

        public async Task<RecoverInvestmentCacheDto> Recover(int customerId)
        {
            if (Db == null) return null;

            var data = await Db?.StringGetAsync($"{RootNamespace}:{LayerNameSpace}:{customerId.ToString()}");
            return string.IsNullOrWhiteSpace(data)
                ? null
                : JsonSerializer.Deserialize<RecoverInvestmentCacheDto>(data);
        }

        public async Task Store(int customerId, RecoverInvestmentCacheDto dto)
        {
            if (Db == null) return;

            var expire = GetExpire();
            await Db?.StringSetAsync($"{RootNamespace}:{LayerNameSpace}:{customerId.ToString()}",
                JsonSerializer.Serialize(dto), TimeSpan.FromSeconds(expire));
        }

        static double GetExpire()
        {
            var date = DateTime.Now.Date.Add(new TimeSpan(23, 59, 59));
            var timeOfDay = date.TimeOfDay;
            return timeOfDay.TotalSeconds - DateTime.Now.TimeOfDay.TotalSeconds;
        }
    }
}