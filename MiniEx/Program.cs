namespace MiniEx
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AnimalCollection<Animal> animalCollection = new AnimalCollection<Animal>();
            animalCollection.Add(new Dog() {Id = 1, Name = "Fox", Dob = "2018"});
            animalCollection.Add(new Dog() {Id = 2, Name = "Bull", Dob = "2018"});
            animalCollection.Add(new Cat() {Id = 3, Name = "LyLy", Dob = "2018"});
            animalCollection.Remove(2);
            animalCollection.ShowInfomation();
        }
    }
}