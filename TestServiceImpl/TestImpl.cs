using System;
using System.Collections.Generic;
using System.Text;

namespace TestServiceImpl
{
    public class TestImpl:ITest
    {
        //接口实现  
        public string testautofac(string content)
        {
            return content;
        }
    }
}
