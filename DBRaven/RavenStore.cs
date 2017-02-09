using Raven.Client;
using Raven.Client.Embedded;
using System;

namespace DBRavenImplementation
{
    class RavenStore
    {
        private static readonly Lazy<IDocumentStore> theDocStore = new Lazy<IDocumentStore>(() =>
        {
            var path = "~/Database/";
            var docStore = new EmbeddableDocumentStore
            {
                DataDirectory = path
            };
            docStore.Conventions.IdentityPartsSeparator = "-";
            docStore.Initialize();

            return docStore;
        });

        public static IDocumentStore Store
        {
            get { return theDocStore.Value; }
        }
    }
}
