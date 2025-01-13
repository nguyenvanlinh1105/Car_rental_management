using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace WEBAPI.Utils
{
    public static class CommonUtils
    {


      

        // Hàm kiểm tra dữ liệu hợp lệ
        public static bool IsValidString(string value)
        {
            return !string.IsNullOrEmpty(value) && value.Trim().Length > 0;
        }
    }
}

