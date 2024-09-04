using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionsString("DefaultConnection")));
    services.AddAuthentication(JwtBearerDefaults.AddAuthenticationScheme)
        .AddJwtBearer(options =>
        {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKeyResolver = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationBinder["Jwt:Key"]))
                };
        });
    services.AddSwaggerGen();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductCatalogApi v1"));
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}