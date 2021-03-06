﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YdyoOBS.Application.Common.Interfaces;

namespace WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {

            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = UserId != null;
        }


        public string UserId { get; }

        public bool IsAuthenticated { get; }
    }
}
