using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;

namespace Kemwell.RavenDB
{
    public interface IRavenSessionManager
    {
        IDocumentSession GetSession();
        IDocumentStore GetDocumentStore();
    }
}