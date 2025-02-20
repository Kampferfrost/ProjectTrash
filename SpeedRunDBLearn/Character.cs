namespace SpeedRunDBLearn
{
    internal class Character : BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
