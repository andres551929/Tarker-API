using Tarker.Booking.Api;
using Tarker.Booking.Common;
using Tarker.Booking.Application;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Microsoft.AspNetCore.SignalR;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

var app = builder.Build();


app.MapPost("/testService", async (IGetUserByUserNameAndPasswordQuery service) =>
{
    

    return await service.Execute("bill01", "billpas");  
});
app.Run();

