using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YdyoOBS.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        bool IsAuthenticated { get; }
    }
}
