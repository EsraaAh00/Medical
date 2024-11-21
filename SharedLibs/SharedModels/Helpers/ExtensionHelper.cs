using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Helpers
{
    public static class ExtensionHelper
    {
        public static DateTime? EndFilter(this DateTime? dateTime)
        {
            return dateTime?.AddDays(1).AddSeconds(-1);
        }
        public static List<BaseDropDown>? GetListDropDownWithAll(this List<BaseDropDown>? list,bool? All=false)
        {
            if (All == true)
            {
                list?.Insert(0, new BaseDropDown { Id = null, Name = "All" });
            }
            return list;
        }
        
        public static bool IsNullOrEmpty(this string? str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static bool? IsDoc(this IFormFile? file)
        {
            List<string> strings = new List<string>() {"pdf"};
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                return strings.Contains(extension.ToLower());
                
            }
            return false;
        }
        public static bool? IsImage(this IFormFile? file)
        {
            List<string> strings = new List<string>() { "jpg","jpeg", "png", "heif" };
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                return strings.Contains(extension.ToLower());

            }
            return false;
        }

    }
}
