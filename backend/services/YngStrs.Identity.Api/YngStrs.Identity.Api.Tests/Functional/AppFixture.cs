﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YngStrs.Common.Cqrs.Core;
using YngStrs.Identity.Api.Persistence.EntityFramework;

namespace YngStrs.Identity.Api.Tests.Functional
{
    public class AppFixture
    {
        public static readonly string BaseUrl = "https://localhost:5111";
        private static readonly IConfiguration _configuration;
        private static readonly IServiceScopeFactory _scopeFactory;

        static AppFixture()
        {

            var host = Program
                .CreateHostBuilder(new[] { "--environment", "IntegrationTests" })
                .Build();

            host.Start();

            var scopeFactory = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));

            _scopeFactory = scopeFactory;

            using var scope = scopeFactory.CreateScope();
            _configuration = scope.ServiceProvider.GetService<IConfiguration>();
        }

        public static string EventStoreConnectionString => _configuration.GetSection("EventStore")["ConnectionString"];
        public static string RelationalDbConnectionString => _configuration.GetConnectionString("DefaultConnection");

        public Task ExecuteDbContextAsync(Func<IdentityContext, Task> action) =>
            ExecuteScopeAsync(sp =>
            {
                var dbContext = sp.GetService<IdentityContext>();

                return action(dbContext);
            });

        public Task<T> ExecuteDbContextAsync<T>(Func<IdentityContext, Task<T>> action) =>
            ExecuteScopeAsync(sp =>
            {
                var dbContext = sp.GetService<IdentityContext>();

                return action(dbContext);
            });

        public Task<TResult> ExecuteHttpClientAsync<TResult>(Func<HttpClient, Task<TResult>> action, string accessToken = null)
        {
            var client = BuildHttpClient(accessToken);
            return action(client);
        }

        public Task ExecuteHttpClientAsync(Func<HttpClient, Task> action, string accessToken = null)
        {
            var client = BuildHttpClient(accessToken);
            return action(client);
        }

        public async Task ExecuteScopeAsync(Func<IServiceProvider, Task> action)
        {
            using var scope = _scopeFactory.CreateScope();
            try
            {
                await action(scope.ServiceProvider).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<T> ExecuteScopeAsync<T>(Func<IServiceProvider, Task<T>> action)
        {
            using var scope = _scopeFactory.CreateScope();
            try
            {
                var result = await action(scope.ServiceProvider).ConfigureAwait(false);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task ExecuteServiceAsync<TService>(Func<TService, Task> action)
        {
            var service = await ExecuteScopeAsync(async sp => sp.GetRequiredService<TService>());
            await action(service);
        }

        public string GetCompleteServerUrl(string route)
        {
            route = route.TrimStart('/', '\\');
            return $"{BaseUrl}/{route}";
        }

        public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            return ExecuteScopeAsync(sp =>
            {
                var mediator = sp.GetService<IMediator>();

                return mediator.Send(request);
            });
        }

        public Task SendAsync(IRequest request)
        {
            return ExecuteScopeAsync(sp =>
            {
                var mediator = sp.GetService<IMediator>();

                return mediator.Send(request);
            });
        }

        public Task SendManyAsync(params ICommand[] commands)
        {
            return ExecuteScopeAsync(async sp =>
            {
                var mediator = sp.GetService<IMediator>();

                foreach (var command in commands)
                {
                    await mediator.Send(command);
                }

                return Task.CompletedTask;
            });
        }

        private static HttpClient BuildHttpClient(string accessToken = null)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };

            if (!string.IsNullOrEmpty(accessToken))
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            }

            return client;
        }
    }
}
