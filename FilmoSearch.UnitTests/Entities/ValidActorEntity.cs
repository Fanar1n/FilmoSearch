using FilmoSearch.DAL.Entities;

namespace FilmoSearch.UnitTests.Entities
{
    public class ValidActorEntity
    {
        public static ActorEntity actorEntity = new()
        {
            Id = 1,

            FirstName = "Vlad",

            LastName = "Zagorsky"
        };
    }
}
