using NetArchTest.Rules;

namespace FilmoSearch.ArchTests
{
    public class ControllerReferenceTest
    {
        [Fact]
        public void ControllersShouldNotDirectlyReferenceRepositories()
        {
            var result = Types.InCurrentDomain()
    .That()
    .ResideInNamespace("NetArchTest.SampleLibrary.Presentation")
    .ShouldNot()
    .HaveDependencyOn("NetArchTest.SampleLibrary.Data")
    .GetResult()
    .IsSuccessful;
        }
    }
}
