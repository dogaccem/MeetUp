using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using System.Runtime;
using Newtonsoft.Json;

namespace MeetUp.Application.Abstractions.Caching
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICacheableMediatrQuery
    {
        private readonly IDistributedCache _cache;

        public CachingBehavior(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            TResponse response;
            if (request is not ICacheableMediatrQuery)
                {  
                    //Console.WriteLine($"Remove from Cache -> '{request.CacheKey}'.");
                    return await next();
                }
                async Task<TResponse> GetResponseAndAddToCache()
                {
                    response = await next();
                    var slidingExpiration = TimeSpan.FromHours(1);
                    var options = new DistributedCacheEntryOptions { SlidingExpiration = slidingExpiration };
                    var serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
                    await _cache.SetAsync(request.CacheKey, serializedData, options, cancellationToken);
                    return response;
                }
                var cachedResponse = await _cache.GetAsync((string)request.CacheKey, cancellationToken);
                if (cachedResponse != null)
                {
                    response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
                    Console.WriteLine($"Fetched from Cache -> '{request.CacheKey}'.");
                }
                else
                {
                    response = await GetResponseAndAddToCache();
                    Console.WriteLine($"Added to Cache -> '{request.CacheKey}'.");
                }
                return response;

        }
    }
}
