using LabAcademiaAPI.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

var m_Configuracao = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

//Configurando serialização
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "LabAcademiaAPI", Version = "v1" });

    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization usando o scheme Bearer"
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });
});

//Base de dados EFCore - PostgreSQL
builder.Services.AddDbContext<LabAcademiaContext>(opt =>
{
    opt.UseNpgsql(m_Configuracao.GetSection("DefaultConnectionString").Value);
});

//Injeção de dependências
builder.Services.AddScoped<EFRepositoryAbstract<Treino>, TreinoRepository>();
builder.Services.AddScoped<EFRepositoryAbstract<Exercicio>, ExercicioRepository>();
builder.Services.AddScoped<EFRepositoryAbstract<UsuariosTreinos>, UsuariosTreinosRepository>();
builder.Services.AddScoped<ITreinoService, TreinoService>();
builder.Services.AddScoped<IHistoricoService, HistoricoService>();
builder.Services.AddScoped<IExercicioService, ExercicioService>();
builder.Services.AddScoped<IUsuarioTreinoService, UsuarioTreinoService>();

builder.Services.AddSingleton<IConfiguration>(m_Configuracao);
builder.Services.AddSingleton<IAuthorizationHandler, RoleRequirementAuthorizationHandler>();

builder.Services.AddScoped(http => new HttpClient());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = m_Configuracao["Jwt:Issuer"],
            ValidAudience = m_Configuracao["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(m_Configuracao["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrador", policy => policy.Requirements.Add(new RoleRequirement("ADM")));
});

var app = builder.Build();

//Migração da base de dados
app.MigrationExtension();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
