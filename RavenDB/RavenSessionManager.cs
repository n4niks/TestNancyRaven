using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace Kemwell.RavenDB
{
    public class RavenSessionManager : IRavenSessionManager
    {
        private static IDocumentStore _documentStore;

        public static IDocumentStore DocumentStore
        {
            get { return (_documentStore == null || _documentStore.WasDisposed ? _documentStore = CreateDocumentStore() : _documentStore); }
        }

        private static IDocumentStore CreateDocumentStore()
        {
            var documentStore = new DocumentStore
            {
                //ConnectionStringName = "kemwell-workflow",
                ApiKey = "ddce8dd1-fc15-4817-8530-afe740e7cb1f",
                Url = "https://1.ravenhq.com/databases/senthilsweb-senthilsdb"
            }.Initialize();

            //documentStore.DatabaseCommands.EnsureDatabaseExists("senthilsweb-senthilsdb");
            return documentStore;
        }

        public IDocumentSession GetSession()
        {
            var session = DocumentStore.OpenSession("senthilsweb-senthilsdb");
            return session;
        }

        public IDocumentStore GetDocumentStore()
        {
            return DocumentStore;
        }
    }
}
