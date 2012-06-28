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
    public class EmployeeModule : ModuleBase
    {
        public EmployeeModule()
            : base("/Employees")
        {
            //Before += ctx => { System.Diagnostics.Debug.WriteLine(""); };

            Get["/{firstLetter}"] = parameters =>
            {
                string firstLetter = parameters.firstLetter;
                var employees = DocumentSession.Query<Employee>()
                    .Where(x => x.FirstName.StartsWith(firstLetter))
                    .ToList();
                //new Nancy.Json.JavaScriptSerializer().Serialize(employees);
                return Response.AsJson(employees);
                //return @"callback({""result"": " + new Nancy.Json.JavaScriptSerializer().Serialize(employees) + "});";
                    
            };

           
        }
    }   
}