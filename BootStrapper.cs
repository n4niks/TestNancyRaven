using Nancy;
using Nancy.Bootstrapper;

using Kemwell.RavenDB;
public class Bootstrapper : DefaultNancyBootstrapper
{
    protected override NancyInternalConfiguration InternalConfiguration
    {
        get { return NancyInternalConfiguration.WithOverrides(x => x.NancyModuleBuilder = typeof(RavenSessionModule)); }
    }
}