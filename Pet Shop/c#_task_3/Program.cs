public class Cat
{
    public string Nickname { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public int Energy { get; set; }
    public decimal Price { get; set; }
    public int MealQuantity { get; set; }

    public Cat(string nickname, int age, string gender, int energy, decimal price, int mealQuantity)
    {
        Nickname = nickname;
        Age = age;
        Gender = gender;
        Energy = energy;
        Price = price;
        MealQuantity = mealQuantity;
    }

    public void Eat()
    {
        Energy += 10;
        MealQuantity--;
        Console.WriteLine($"{Nickname} yemek yedi. Energy: {Energy}, Yemek qaldi: {MealQuantity}");
    }

    public void Sleep()
    {
        Energy += 20;
        Console.WriteLine($"{Nickname} yatdi. Energy: {Energy}");
    }

    public void Play()
    {
        if (Energy > 10)
        {
            Energy -= 10;
            Console.WriteLine($"{Nickname} Oynadi. Energy: {Energy}");
        }
        else
        {
            Console.WriteLine($"{Nickname} yorgundur, oynaya bilmir.");
        }
    }
}

public class CatHouse
{
    private Cat[] Cats;
    private int _currentCount;

    public int CatCount => _currentCount;

    public CatHouse(int capacity)
    {
        Cats = new Cat[capacity];
        _currentCount = 0;
    }

    public void AddCat(Cat cat)
    {
        if (_currentCount < Cats.Length)
        {
            Cats[_currentCount++] = cat;
            Console.WriteLine($"{cat.Nickname} pisik evine elave edildi.");
        }
        else
        {
            Console.WriteLine("Pisik evi doludur.");
        }
    }

    public void RemoveByNickname(string nickname)
    {
        int index = Array.FindIndex(Cats, 0, _currentCount, cat => cat != null && cat.Nickname == nickname);
        if (index >= 0)
        {
            for (int i = index; i < _currentCount - 1; i++)
            {
                Cats[i] = Cats[i + 1];
            }
            Cats[--_currentCount] = null;
            Console.WriteLine($"{nickname} pisik evinden silindi.");
        }
        else
        {
            Console.WriteLine($"{nickname} pisik evinde tapilmadi.");
        }
    }

    public void ListCats()
    {
        for (int i = 0; i < _currentCount; i++)
        {
            Cat cat = Cats[i];
            Console.WriteLine($"{cat.Nickname} - Yas: {cat.Age}, Cinsiyyet: {cat.Gender}, Energy: {cat.Energy}, Qiymet: {cat.Price:C}, yemek: {cat.MealQuantity}");
        }
    }
}

public class PetShop
{
    private CatHouse[] CatHouses;
    private int _currentCount;

    public int CatHouseCount => _currentCount;

    public PetShop(int capacity)
    {
        CatHouses = new CatHouse[capacity];
        _currentCount = 0;
    }

    public void AddCatHouse(CatHouse catHouse)
    {
        if (_currentCount < CatHouses.Length)
        {
            CatHouses[_currentCount++] = catHouse;
            Console.WriteLine("Pisik evi elave edidi.");
        }
    }

    public void ListCatHouses()
    {
        for (int i = 0; i < _currentCount; i++)
        {
            Console.WriteLine($"Pisik evi sayi {i + 1}:");
            CatHouses[i].ListCats();
        }
    }
}

public class Program
{
    public static void Main()
    {
        Cat cat1 = new Cat("Pisik 1", 2, "Female", 50, 100m, 5);
        Cat cat2 = new Cat("Pisik 2", 3, "Male", 40, 120m, 3);

        CatHouse catHouse1 = new CatHouse(10);
        catHouse1.AddCat(cat1);
        catHouse1.AddCat(cat2);
    }
}
