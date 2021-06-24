namespace MiniEx
{
    public abstract class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }

        public override string ToString()
        {
            return $"Animal information: id is {Id}, name {Name}, birthday {Dob}";
        }

        public abstract void Speak();
    }
}