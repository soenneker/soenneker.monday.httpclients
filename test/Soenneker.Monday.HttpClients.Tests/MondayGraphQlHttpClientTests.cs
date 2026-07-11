using Soenneker.Monday.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Monday.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class MondayGraphQlHttpClientTests : HostedUnitTest
{
    private readonly IMondayGraphQlHttpClient _httpclient;

    public MondayGraphQlHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IMondayGraphQlHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
