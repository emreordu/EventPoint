using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPoint.Business.Helpers.Models
{
    public interface IGetCurrentUser
    {
        string GetLoginUser();
    }
}