﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword
{
    public class GetUserByUserNameAndPasswordQuery : IGetUserByUserNameAndPasswordQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUserByUserNameAndPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService; 
            _mapper = mapper;   
        }

        public async Task<GetUserByUserNameAndPasswordModel> Execute(string userName, string Password)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == Password);
            return _mapper.Map<GetUserByUserNameAndPasswordModel>(entity);  
        }
    }
}
