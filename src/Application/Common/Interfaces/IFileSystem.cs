using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YdyoOBS.Application.Common.Interfaces
{
    public interface IFileSystem
    {
        Task<bool> SavePicture(string pictureName, string pictureBase64, CancellationToken cancellationToken);
    }
}
