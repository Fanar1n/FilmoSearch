using NetArchTest.Rules;

namespace FilmoSearch.ArchTests
{
    public class NotSealedTest
    {
        [Fact]
        public void ServiceClassesShouldBePublicAndNotSealed()
        {
            var result = Types.InCurrentDomain()
                        .That().ResideInNamespace(("Core.Infrastructure.Services"))
                        .Should().BePublic().And().NotBeSealed()
                        .GetResult();
            Assert.True(result.IsSuccessful);
        }
    }
}
