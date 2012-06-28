using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Routing;
using Nancy.ViewEngines;
using Nancy;
using Nancy.ModelBinding;
using Raven.Client;

using System.IO;

namespace Kemwell.RavenDB
{
    public class RavenSessionModule : INancyModuleBuilder
    {
        private readonly IViewFactory viewFactory;
        private readonly IResponseFormatter responseFormatter;
        private readonly IModelBinderLocator modelBinderLocator;
        private readonly IRavenSessionManager _ravenSessionProvider;

        public RavenSessionModule(IViewFactory viewFactory, IResponseFormatter responseFormatter,
                                       IModelBinderLocator modelBinderLocator,
                                       IRavenSessionManager ravenSessionProvider)
        {
            this.viewFactory = viewFactory;
            this.responseFormatter = responseFormatter;
            this.modelBinderLocator = modelBinderLocator;
            _ravenSessionProvider = ravenSessionProvider;
        }

        public NancyModule BuildModule(NancyModule module, NancyContext context)
        {
            module.Context = context;
            module.Response = this.responseFormatter;
            module.ViewFactory = this.viewFactory;
            module.ModelBinderLocator = this.modelBinderLocator;
            context.Items.Add("RavenStore", _ravenSessionProvider.GetDocumentStore());
            context.Items.Add("RavenSession", _ravenSessionProvider.GetSession());            
            module.After.AddItemToStartOfPipeline(ctx =>
            {
                var session =
                    ctx.Items["RavenSession"] as IDocumentSession;
                session.SaveChanges();
                session.Dispose();
            });

            module.After.AddItemToEndOfPipeline(PrepareJsonp);           
            return module;
        }

        private static void PrepareJsonp(NancyContext context) {
            bool isJson = context.Response.ContentType == "application/json";
            bool hasCallback = context.Request.Query["callback"].HasValue;

            if (isJson && hasCallback)
            {
                Action<Stream> original = context.Response.Contents;
                string callback = "callback";//context.Request.Query["callback"].value;
                context.Response.ContentType = "application/javascript";
                context.Response.Contents = stream =>
                    {
                        StreamWriter writer = new StreamWriter(stream);
                        writer.AutoFlush = true;
                        writer.Write("{0}(", callback);
                        original(stream);
                        writer.Write(");");
                    };
            }
        }
    }
}