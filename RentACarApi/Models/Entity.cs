namespace RentACarApi.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }

        protected Entity() { }

        public Entity(int id) : this() 
        {
            Id = id;
        }
    }
}
