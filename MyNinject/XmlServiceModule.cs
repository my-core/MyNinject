using System.Collections.Generic;
using System.Xml.Linq;
using Ninject;
using Ninject.Extensions.Xml;
using Ninject.Extensions.Xml.Handlers;

namespace MyNinject
{
    public class XmlModuleContext
    {
        protected readonly IKernel kernel;
        protected readonly IDictionary<string, IXmlElementHandler> elementHandlers;

        public XmlModuleContext()
        {
            kernel = new StandardKernel();
            elementHandlers = new Dictionary<string, IXmlElementHandler> { { "bind", new BindElementHandler(kernel) } };
        }
    }

    public class XmlServiceModule : XmlModuleContext
    {
        private static readonly XmlServiceModule instance = new XmlServiceModule();

        protected readonly XmlModule module = null;

        public XmlServiceModule()
        {
            var document = XDocument.Load("Config/NinjectServiceModule.config");
            module = new XmlModule(document.Element("module"), elementHandlers);
            module.OnLoad(kernel);
        }

        public static IKernel GetKernel()
        {
            return instance.kernel;
        }
    }
}