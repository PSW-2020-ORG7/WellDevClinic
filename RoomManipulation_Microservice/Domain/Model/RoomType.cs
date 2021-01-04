namespace RoomManipulation_Microservice.Domain.Model
{
    public class RoomType : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public RoomType(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public RoomType()
        {
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}