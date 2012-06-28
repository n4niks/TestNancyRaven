using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Hosting.Self;
using Nancy.Extensions;
using Nancy.ModelBinding;
using Kemwell.Core;
using Kemwell.Core;


namespace Kemwell.NancyFx.Rest.Module
{
    public class SyscodeModule : ModuleBase
    {
        public SyscodeModule()
            : base("/Syscodes") //http://localhost:9999/Syscodes/load
        {
            //Task i.e. loading test data for first time
            Get["/load"] = _ =>
            {
                var parent = new Syscode { Code = "Department", Description = "Cost Centre", Parent = null };
                DocumentSession.Store(parent);
                var Syscodes = new List<Syscode>() {
                        new Syscode{ Code = "Administration", Description="Administration", Parent=parent},
                        new Syscode{ Code = "MIS", Description="MIS", Parent=parent},
                        new Syscode{ Code = "HR", Description="HR", Parent=parent},
                    };

                foreach (var syscode in Syscodes)
                    DocumentSession.Store(syscode);

                return Response.AsJson("Syscodes Saved Successfully");

            };

            Get["/"] = _ =>
            {
                return Response.AsJson(DocumentSession.Query<Syscode>().ToList());

            };
            Get["/{parentCode}"] = parameters =>
            {
                string parentCode = parameters.parentCode;
                var syscodes = DocumentSession.Query<Syscode>()
                    .Where(x => x.Parent.Code.StartsWith(parentCode))
                    .ToList();
                //new Nancy.Json.JavaScriptSerializer().Serialize(employees);
                return Response.AsJson(syscodes);
                //return @"callback({""result"": " + new Nancy.Json.JavaScriptSerializer().Serialize(employees) + "});";

            };

        }
    }
}
