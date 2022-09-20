using Account.Data;
using Account.Data.Repositories.Candidato;
using Account.Data.Repositories.Voto;
using Account.Services.Services.Candidato;
using Account.Services.Services.Voto;
using Account.WebAPI.APIs.Candidato;
using Account.WebAPI.APIs.Voto;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Account.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICandidatoService, CandidatoService>();
            builder.Services.AddTransient<ICandidatoRepository, CandidatoRepository>();

            builder.Services.AddScoped<IVotoService, VotoService>();
            builder.Services.AddTransient<IVotoRepository, VotoRepository>();

            builder.Services.AddDbContext<AccountDbContext>(o =>
            {
                var cs = new SqliteConnectionStringBuilder();
                cs.DataSource = "account_teste.db";
                cs.Mode = SqliteOpenMode.ReadWriteCreate;
                o.UseSqlite(cs.ToString());
                o.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            });

            //dbcontext de fachada para aplicar os migrations em tempo de design
            //builder.Services.AddDbContext<AccountMigrationDbContext>(o =>
            //{
            //    var cs = new SqliteConnectionStringBuilder();
            //    cs.DataSource = "account_teste.db";
            //    cs.Mode = SqliteOpenMode.ReadWriteCreate;
            //    o.UseSqlite(cs.ToString());
            //});

            var app = builder.Build();

            app.UseCors(o =>
            {
                var origins = app.Configuration.AsEnumerable().Where(c => c.Key.StartsWith("Origins") && c.Value != null).Select(c => c.Value).ToArray();
                o.WithOrigins(origins);
                o.AllowAnyHeader();
                o.AllowAnyMethod();
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.ConfigureCandidatoAPI();
            app.ConfigureVotoAPI();

            await app.RunAsync();
        }
    }
}