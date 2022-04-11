using U2U.BoardGames;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BoardGamesDb>(optionsBuilder =>
        optionsBuilder.UseInMemoryDatabase("BoardGames"));

WebApplication? app = builder.Build();

using( var scope = app.Services.CreateScope() )
{
  BoardGamesDb db = scope.ServiceProvider.GetRequiredService<BoardGamesDb>();
  db.Database.EnsureCreated();
}

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
    pattern: "{controller=Games}/{action=Index}/{id?}");

app.Run();
