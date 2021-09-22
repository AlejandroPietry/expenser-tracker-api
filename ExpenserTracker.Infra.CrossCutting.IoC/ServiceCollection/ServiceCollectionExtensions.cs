using Expenser_Tracker.Domain.Interfaces.Repositorios;
using Expenser_Tracker.Domain.Interfaces.Servicos;
using Expenser_Tracker.Domain.Services;
using Expenser_Tracker.Infra.Data.Context;
using Expenser_Tracker.Infra.Data.Repositories;
using ExpenserTracker.Application;
using ExpenserTracker.Application.Interfaces;
using ExpenserTracker.Infra.CrossCutting.Services.Interfaces;
using ExpenserTracker.Infra.CrossCutting.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ExpenserTracker.Infra.CrossCutting.IoC.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("teste"));
            services.AddTransient(typeof(ITokenService),typeof(TokenService));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("chavetemporariaDepoisFacoBonitinho")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddTransient(typeof(ITransacaoAppService), typeof(TransacaoAppService));
            services.AddTransient(typeof(IUsuarioAppService), typeof(UsuarioAppService));
            services.AddTransient(typeof(ILoginAppService), typeof(LoginAppService));

            return services;
        }

        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            #region Service
            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient(typeof(ITransacaoService), typeof(TransacaoService));
            services.AddTransient(typeof(IUsuarioService), typeof(UsuarioService));
            #endregion

            #region Repositorio
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient(typeof(ITransacaoRepositorio), typeof(TransacaoRepository));
            services.AddTransient(typeof(IUsuarioRepositorio), typeof(UsuarioRepository));
            #endregion
            return services;
        }

        public static IServiceCollection AddService(this IServiceCollection services)
        {
            return services;
        }
    }
}
