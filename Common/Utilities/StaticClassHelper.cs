using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utilities
{
    public class StaticClassHelper
    {
        private static IHttpContextAccessor httpContextAccessor;
        public static void SetHttpContextAccessor(IHttpContextAccessor accessor)
        {
            httpContextAccessor = accessor;
        }

    }
}