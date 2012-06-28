using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Kemwell.NancyFx.Rest
{
    public class MainModule : ModuleBase
    {
        public MainModule()
            : base("/customers")
        {
            Get["/"] = x =>
            {
                return "Hello world!";
            };
        }
    }
}
