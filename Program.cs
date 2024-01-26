using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamento;
using SistemaDeEstacionamento.Models.DAO;
using SistemaDeEstacionamento.Service;

var builder = WebApplication.CreateBuilder(args);
// Configuração EF core
// Adicionando o service que vai referenciar a string de conexão que fica no appsettings.json
builder.Services.AddDbContext<BaseEstacionamentoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BaseEstacionamentoContext") ?? throw new InvalidOperationException("Connection string 'BaseEstacionamentoContext' not found.")));
// Injeções de dependencias

//Services
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IClienteDAO, ClienteDAO>();
builder.Services.AddTransient<IEstacionamentoService, EstacionamentoService>();
builder.Services.AddTransient<IEstacionamentoDAO, EstacionamentoDAO>();
builder.Services.AddTransient<IFaturamentoService, FaturamentoService>();
builder.Services.AddTransient<IFaturamentoDAO, FaturamentoDAO>();
builder.Services.AddTransient<IRelatorioService, RelatorioService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
