
using BestPractice.Database;
using BestPractice.ExtendedServiceNamespace;
using BestPractice.Factory;
using BestPractice.Inputs;
using BestPractice.Outputs;
using BestPractice.services;
using Microsoft.EntityFrameworkCore;

namespace BestPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationContext")));


            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IEntityRepository<Actor, Guid>, ActorRepository>();
            builder.Services.AddScoped<IEntityRepository<Movie, Guid>, MovieRepository>();

            builder.Services.AddScoped(typeof(IEntityRepository<,>), typeof(EntityRepository<,>));
            //builder.Services.AddScoped<IEntityRepository<ExtendedComponent, Guid>, ExtendedRepository>();

            builder.Services.AddScoped(typeof(IExtendedService<, , , >), typeof(ExtendedService<, , , >));
            //builder.Services.AddScoped<IExtendedService<ExtendedCreateInput, ExtendedUpdateInput, ExtendedComponent, Guid>, ExtendedService<ExtendedCreateInput, ExtendedUpdateInput, ExtendedComponent, Guid>>();


            //builder.Services.AddScoped(typeof(IExtendedService<ExtendedCreateInput, ExtendedUpdateInput, ExtendedComponent, Guid>), typeof(ExtendedService<ExtendedCreateInput, ExtendedComponent, ExtendedUpdateInput, Guid>));


            builder.Services.AddScoped<IComponentFactory<ExtendedComponent, ExtendedObject>, ExtendedFactory>();
            
            builder.Services.AddScoped<IComponentFactory<Extended2Component, Extended2Object>, Extended2Factory>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
