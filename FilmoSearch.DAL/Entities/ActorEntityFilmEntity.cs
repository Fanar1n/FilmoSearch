namespace FilmoSearch.DAL.Entities
{
    public class ActorEntityFilmEntity
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int FilmId { get; set; }
        public ActorEntity Actor { get; set; }
        public FilmEntity Film { get; set; }
    }
}
