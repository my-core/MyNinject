using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNinject
{
    public class Test : ITest
    {
        public void ShowMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
