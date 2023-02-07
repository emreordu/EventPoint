using EventPoint.DataAccess.IdentityServer.Dto;
using EventPoint.DataAccess.IdentityServer.Models;
using EventPoint.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPoint.DataAccess.Helpers
{
    public interface ITokenHelper
    {
        TokenDTO CreateToken(User appUser);
    }
}