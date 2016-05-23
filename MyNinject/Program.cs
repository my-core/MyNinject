using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace MyNinject
{
    class Program
    {
        static void Main(string[] args)
        {
            Main1 main1 = new Main1();
            main1.Show();

            Main2 main2 = new Main2();
            main2.Show();

            Main3 main3 = new Main3();
            main3.Show();

            Console.Read();
        }
    }

    /// <summary>
    /// 1、构造器创建对象实例
    /// </summary>
    public class Main1
    {
        
        public ITest test { get; set; }
        public Main1()
        {
            this.test = new Test();
        }

        public void Show()
        {
            test.ShowMsg("Main1：Hello World。");
        }

    }
    /// <summary>
    /// 2、无xml,定义处理模块MyNinjectModule，重写Load
    /// </summary>
    public class Main2
    {
        public ITest test { get; set; }
        public Main2()
        {
            IKernel ninject = new StandardKernel(new MyNinjectModule());
            test = ninject.Get<ITest>();
        }

        public void Show()
        {
            test.ShowMsg("Main2：Hello World。");
        }
    }
    /// <summary>
    /// 3、配置文件(XmlServiceModule.cs)
    /// </summary>
    public class Main3
    {
        public ITest test { get; set; }
        public Main3()
        {
            var kernel = XmlServiceModule.GetKernel();
            kernel.Get<ITest>();
            test = kernel.GetService(typeof(ITest)) as ITest;
        }

        public void Show()
        {
            test.ShowMsg("Main3：Hello World。");
        }

    }
}
