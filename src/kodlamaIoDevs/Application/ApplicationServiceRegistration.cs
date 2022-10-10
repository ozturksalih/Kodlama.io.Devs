using Application.Features.Frameworks.Rules;
using Application.Features.GithubAccounts.Rules;
using Application.Features.Auths.Rules;
using Application.Features.ProgrammingLanguages.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services.AuthService;
using Application.Features.OperationClaims.Rules;
using Application.Features.UserOperationClaims.Rules;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            
            services.AddScoped<IAuthService, AuthManager>();

            //businessRules
            services.AddScoped<ProgrammingLanguageBusinessRules>();
            services.AddScoped<FrameworkBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<GithubAccountBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<UserOperationClaimBusinessRules>();


            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;

        }
    }
}
