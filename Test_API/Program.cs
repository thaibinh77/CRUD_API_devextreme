using Test_API.DAL;

var builder = WebApplication.CreateBuilder(args);

// Configure IP host names
//builder.WebHost.UseUrls(["https://192.168.1.108:7018", "http://192.168.1.108:5096"]);

// Đăng ký dịch vụ CustomerDAL để inject vào controller
builder.Services.AddSingleton<Data_Access_Layer>();

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
