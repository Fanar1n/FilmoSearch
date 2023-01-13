using FluentAssertions;
using NetArchTest.Rules;

namespace FilmoSearch.ArchTests
{
    public class InterfaceTest
    {
        [Fact]
        public void InterfaceNamesShouldStartWithAnI()
        {
            var result = Types.InCurrentDomain()
                .That().AreInterfaces()
                .Should()
                .HaveNameStartingWith("I")
                .GetResult().IsSuccessful;

            result.Should().Be(true);
        }
    }
}