using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Hosting.Self;
using System.Dynamic;
using nSupport.Domain;

namespace nSupport.NancyFx.Module
{
    public class CustomerModule : ModuleBase
    {
        public CustomerModule()
            : base("/customers")
        {
            Get["/browse/{firstLetter}"] = parameters =>
            {
                string firstLetter = parameters.firstLetter;
                var customers = DocumentSession.Query<Customer>()
                    .Where(x => x.Name.StartsWith(firstLetter))
                    .ToList();

                return Response.AsJson(customers);
                    
            };            
        }
    }   
}