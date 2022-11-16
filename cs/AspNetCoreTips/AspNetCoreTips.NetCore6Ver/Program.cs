using AspNetCoreTips.NetCore6Ver.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ValidateOpnStart. ASP.NET 6 ���ǉ����ꂽ�B������g���ƃA�v���N���� (app.Run()) �̃^�C�~���O�Ɍ��؂��s���A���s�����痎����悤�ɂȂ�B
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
