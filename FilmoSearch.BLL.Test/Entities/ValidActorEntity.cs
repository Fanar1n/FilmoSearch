using FilmoSearch.DAL.Entities;

namespace FilmoSearch.BLL.Test.Entities
{
    public class ValidActorEntity
    {
        public static ActorEntity ActorEntity = new()
        {
            Id = 1,
            FirstName = "Vlad",
            LastName = "Zagorsky",
        };

        public static IEnumerable<ActorEntity> ListActorEntity = new List<ActorEntity>()
        {
            new()
            {
                Id = 1,
                FirstName = "Vlad",
                LastName = "Zagorsky",
            },
            new()
            {
                Id = 2,
                FirstName = "Robert",
                LastName="Paulson"
            }
        };
    }
}
