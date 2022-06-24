using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marzlam3
{
    public interface ITest
    {
        //接口 只需表明 返回类型 方法名 接收参数
        string testautofac(string content);

    }
    public class Test : ITest
    {
        //接口实现  
        public string testautofac(string content)
        {
            return content;
        }
    }
}
