using AspNetCoreTips.NetCore6Ver.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ValidateOpnStart. ASP.NET 6 より追加された。これを使うとアプリ起動時 (app.Run()) のタイミングに検証を行い、失敗したら落ちるようになる。
builder.Services.AddOptions<ValidatableOption>()
    .Bind(builder.Configuration.GetSection(nameof(ValidatableOption)))
    .ValidateDataAnnotations()
    .ValidateOnStart();


builder.Services.AddControllers();
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
