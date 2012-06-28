using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Hosting.Self;
using Nancy.Extensions;
using Nancy.ModelBinding;
using Kemwell.Core;
using System.Configuration;



namespace Kemwell.NancyFx.Rest.Module
{
    public class RealEstatePropertyModule : ModuleBase
    {
        public RealEstatePropertyModule()
            : base("/RealEstateProperty") //http://localhost:9999/RealEstateProperty/load
        {
            //Task i.e. loading test data for first time
            Get["/load"] = _ =>
            {                
                List<RealEstateProperty> rep = new List<Core.RealEstateProperty>(); 
                var P1 = new RealEstateProperty { Name = "402 Gold Hill", Address = "Green water 98022", Cost = 165000, Type = "Residential" };
                var P2 = new RealEstateProperty { Name = "408 Gold Hills Rd", Address = "Green water 98022", Cost = 165000, Type = "Residential" };
                var P3 = new RealEstateProperty { Name = "Crystal Apartments", Address = "Luxemberg Ave 8765", Cost = 193000, Type = "Residential" };
                var P4 = new RealEstateProperty { Name = "Canlen Walk", Address = "202 Alpharetta Rd", Cost = 2350000, Type = "Residential" };
                var P5 = new RealEstateProperty { Name = "Oxford House", Address = "Park st 4th Ave", Cost = 6660000, Type = "Commercial" };

                DocumentSession.Store(P1);
                DocumentSession.Store(P2);
                DocumentSession.Store(P3);
                DocumentSession.Store(P4);
                DocumentSession.Store(P5);

                //var img1 = System.IO.File.OpenRead(@"E:\RealEstateProperty\P1.jpg");
                //var img2 = System.IO.File.OpenRead(@"E:\RealEstateProperty\P2.jpg");
                //var img3 = System.IO.File.OpenRead(@"E:\RealEstateProperty\P3.jpg");
                //var img4 = System.IO.File.OpenRead(@"E:\RealEstateProperty\P4.jpg");
                //var img5 = System.IO.File.OpenRead(@"E:\RealEstateProperty\P5.jpg");

                //DocumentStore.DatabaseCommands.PutAttachment(P1.Id, null, img1, new Raven.Json.Linq.RavenJObject { { "Description", "402 Gold Hill" } });

                return Response.AsJson("RealEstateProperty Saved Successfully");

            };

            Get["/"] = _ =>
            {

                try {

                    //var imageurl = ConfigurationManager.AppSettings.Get("image-ur1");
                    //List<RealEstateProperty> realestateproperties = new List<RealEstateProperty>();

                    //var P1 = new RealEstateProperty { Id = "1" , Name = "402 Gold Hill", Address = "Green water 98022", Cost = 165000, Type = "Residential" };
                    //var P2 = new RealEstateProperty { Id = "2", Name = "408 Gold Hills Rd", Address = "Green water 98022", Cost = 165000, Type = "Residential" };
                    //var P3 = new RealEstateProperty { Id = "3", Name = "Crystal Apartments", Address = "Luxemberg Ave 8765", Cost = 193000, Type = "Residential" };
                    //var P4 = new RealEstateProperty { Id = "4", Name = "Canlen Walk", Address = "202 Alpharetta Rd", Cost = 2350000, Type = "Residential" };
                    //var P5 = new RealEstateProperty { Id = "5", Name = "Oxford House", Address = "Park st 4th Ave", Cost = 6660000, Type = "Commercial" };
                    //realestateproperties.Add(P1);
                    //realestateproperties.Add(P2);
                    //realestateproperties.Add(P3);
                    //realestateproperties.Add(P4);
                    //realestateproperties.Add(P5);

                    //realestateproperties.ForEach(rp => rp.ImageIdentifier = ConfigurationManager.AppSettings.Get("image-ur1") + "P" + rp.Id + ".jpg");
                    //return Response.AsJson(realestateproperties);  

                    var realestateproperties = DocumentSession.Query<RealEstateProperty>()                   
                    .ToList();
                    //new Nancy.Json.JavaScriptSerializer().Serialize(employees);
                    return Response.AsJson(realestateproperties);

                }
                catch (Exception ex)
                {
                    return Response.AsJson(ex.StackTrace);                    
                }

               ;
                          

            };


           

        }
    }
}
