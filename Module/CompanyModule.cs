using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Hosting.Self;
using System.Dynamic;
using nSupport.Domain;
using Domain;
using Nancy.Extensions;
using Nancy.ModelBinding;


namespace nSupport.NancyFx.Module
{
    public class CompanyModule : ModuleBase
    {
       public CompanyModule() : base("/Companies")
        {
            //Task i.e. loading test data for first time
            Get["/save"] = _ =>
            {
                var Companies = new List<Company>() {
                        new Company{ CompanyName = "Vmoksha Technologies", Country = "India", City="Bangalore",Region="Asia"},
                        new Company{ CompanyName = "Infosys Technologies", Country = "India", City="Bangalore",Region="Asia"},
                        new Company{ CompanyName = "Wipro Infotech", Country = "India", City="Bangalore",Region="Asia"},
                    };

                foreach (var company in Companies)
                    DocumentSession.Store(company);

                return Response.AsJson("Companies Saved Successfully");

            };

            Get["/"] = _ =>
            {
                return Response.AsJson(DocumentSession.Query<Company>().ToList());
            };

            Post["/"] = p =>
            {                
                var company =  this.Bind<Company>();
                DocumentSession.Store(company);
                return Response.AsJson("Successfully Posted");
            };
        }
    }
}
