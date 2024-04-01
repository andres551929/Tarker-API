

using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Tarker.Booking.Application.DataBase.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDataBaseService  _dataBaseService;

        public DeleteUserCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(int UserId)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (entity == null)
            {
                return false;
            }
            else
            {
                _dataBaseService.User.Remove(entity);
                return await _dataBaseService.SaveAsync();

            }

        }
    }
}
