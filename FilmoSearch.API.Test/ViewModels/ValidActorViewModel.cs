using FilmoSearch.API.ViewModels.Actor;

namespace FilmoSearch.API.Test.ViewModels
{
    public class ValidActorViewModel
    {
        public static ActorViewModel ActorViewModel = new()
        {
            Id = 1,
            FirstName = "Vlad",
            LastName = "Zagorsky",
        };

        public static IEnumerable<ActorViewModel> ListActorViewModel = new List<ActorViewModel>()
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
                LastName = "Paulson"
            }
        };
        public static ShortActorViewModel ShortActorViewModel = new()
        {
            FirstName = "Vlad",
            LastName = "Zagorsky",
        };
    }
}
