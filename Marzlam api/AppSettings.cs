using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marzlam_api
{
    public static class AppSettings 
    {
        public static JwtSetting JwtSetting { get; set; }
       
        /// <summary>
        /// 初始化jwt配置
        /// </summary>
        /// <param name="configuration"></param>
        public static void Init(IConfiguration configuration)
        {
            JwtSetting = new JwtSetting();
            configuration.GetSection("JwtSetting").Bind(JwtSetting);

            
        }
    }
}
