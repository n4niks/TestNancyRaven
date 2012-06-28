using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Raven.Client;
using Nancy.Extensions;

namespace Kemwell.NancyFx.Rest
{
    //http://elegantcode.com/2010/11/28/introducing-nancy-a-lightweight-web-framework-inspired-by-sinatra/
    //http://stuff-for-geeks.com/category/RavenDB.aspx
    //http://iamnotmyself.com/2011/04/22/new-sample-nancyfx-app-tickerviewer/
    //http://www.picnet.com.au/blogs/Guido/post/2011/03/22/Understanding-Nancy-Sinatra-for-Net.aspx
    public abstract class ModuleBase : NancyModule
    {
        protected ModuleBase()
        {
           
        }

        protected ModuleBase(string modulePath)
            : base(modulePath)
        {

        }

        public IDocumentSession DocumentSession
        {
            get { return Context.Items["RavenSession"] as IDocumentSession; }           
        }

        public IDocumentStore DocumentStore
        {
            get { return Context.Items["RavenStore"] as IDocumentStore; }
        }
    }
}