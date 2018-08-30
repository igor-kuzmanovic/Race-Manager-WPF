﻿using RaceManager.Server.Service.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RaceManager.Server.Service.Core.Services
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        UserDTO LogIn(string username, string password);

        [OperationContract]
        void LogOut(string securityToken);
    }
}
