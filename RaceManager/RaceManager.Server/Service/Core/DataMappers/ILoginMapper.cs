﻿using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using RaceManager.Server.Service.Core.DataTransferObjects;

namespace RaceManager.Server.Service.Core.DataMappers
{
    interface ILoginMapper : IDataMapper<UserDAO, LoginDTO>
    {
    }
}