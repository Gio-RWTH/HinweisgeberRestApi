using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Security.Claims;
using HinweigeberRestApi.Data.ContextFactory.MainContextDB;
using HinweigeberRestApi.SharedModels;

namespace HinweigeberRestApi.Data.ContextFactory
{
    public class PartnerContextFactory : IDbContextFactory<HinweisDbContext>
	{
		private IHttpContextAccessor _httpContext;
		private readonly MainContext _lizenzContext;
		private readonly IMemoryCache _memoryCache;

		public PartnerContextFactory(IHttpContextAccessor httpContext, MainContext lizenzContext, IMemoryCache memoryCache)
		{
			_httpContext = httpContext;
			_lizenzContext = lizenzContext;
			_memoryCache = memoryCache;
		}

		public HinweisDbContext CreateDbContext()
		{
			try
			{
				_httpContext.HttpContext.Request.Headers.TryGetValue("X-partnerid", out StringValues partner);
				Guid partnerid = Guid.Parse(partner);
				if (!_memoryCache.TryGetValue(partner, out PartnerDbContextOptionsBuilder<HinweisDbContext> context))
				{
							var partnerDb = _lizenzContext.Partners.FirstOrDefault(p => p.Id == partnerid);
							var _optionsBuilder = new PartnerDbContextOptionsBuilder<HinweisDbContext>();
							_optionsBuilder.UseSqlServer(EncryptionService.DecryptString(partnerDb.ConStr.ToConnectionString(), "309C23359677"));
							var ss = EncryptionService.DecryptString(partnerDb.ConStr.ToConnectionString(), "309C23359677");

							var cacheEntryOptions = new MemoryCacheEntryOptions()
								.SetSlidingExpiration(TimeSpan.FromMinutes(3));

							_memoryCache.Set(partnerid, _optionsBuilder, cacheEntryOptions);
							return new HinweisDbContext(_optionsBuilder.Options);
						
						throw new Exception("User is not authenticated");
				}
				return new HinweisDbContext(context.Options);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message + " CreateDbContext User is not authenticated");
			}
		}
	}

	[Serializable]
	public class PartnerDbContextOptionsBuilder<TContext> : DbContextOptionsBuilder<TContext>
	where TContext : DbContext
	{
		public PartnerDbContextOptionsBuilder()
			: base()
		{
		}

		public PartnerDbContextOptionsBuilder(DbContextOptions<TContext> options) : base(options)
		{
		}
	}
}
