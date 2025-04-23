
using JobCandidate.Data.DbContexts;
using JobCandidate.Data.IRepository;
using JobCandidate.Data.Repository;
using JobCandidate.Service.Interfaces;
using JobCandidate.Service.Mappings;
using JobCandidate.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace JobCandidate.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //registered dbContext
            builder.Services.AddDbContext<AppDbContext>(option
                => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );
            //automapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddScoped<IIUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

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
