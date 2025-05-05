using PrimeiraApi.Data;
using AutoMapper;
using PrimeiraApi.Contracts.Response;
using PrimeiraApi.Models;
using Microsoft.OpenApi.Models;

namespace PrimeiraApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<PrimeiraApiContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PrimeiraApiContext")));

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Primeira Api CORE",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core",
                        Contact = new OpenApiContact
                        {
                            Name = "Prof Nizzola",
                            Url = new Uri("https://github.com/nizzola")
                        }
                    });
            });

            #region Automapper
            var configAutomapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoCreateResponse>();
            });
            IMapper mapper = configAutomapper.CreateMapper();
            services.AddSingleton(mapper);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.Extensions.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Primeira Api");
            });
        }
    }
}
