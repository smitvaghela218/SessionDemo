var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure session storage (in-memory).
builder.Services.AddDistributedMemoryCache();

// Configure session with expiration and cookie options.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30); // Expire session after 30 seconds of inactivity.
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add session middleware to enable session support.
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
