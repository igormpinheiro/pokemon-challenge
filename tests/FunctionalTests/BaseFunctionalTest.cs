namespace FunctionalTests;

public class BaseFunctionalTest(FunctionalTestWebAppFactory factory) : IClassFixture<FunctionalTestWebAppFactory>
{
    protected HttpClient HttpClient { get; set; } = factory.CreateClient();
}
