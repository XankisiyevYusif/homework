public class Card
{
    public string PAN { get; set; }
    public string PIN { get; set; }
    public string CVC { get; set; }
    public string ExpireDate { get; set; }
    public decimal Balance { get; set; }

    public Card(string pan, string pin, string cvc, string expireDate, decimal balance)
    {
        PAN = pan;
        PIN = pin;
        CVC = cvc;
        ExpireDate = expireDate;
        Balance = balance;
    }
}

public class User
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Card CreditCard { get; set; }

    public User(string name, string surname, Card creditCard)
    {
        Name = name;
        Surname = surname;
        CreditCard = creditCard;
    }
}

class Program
{
    static void Main(string[] args)
    {
        User[] users = new User[5];

        Card card1 = new Card("1111222233334444", "1234", "789", "06/24", 1000m);
        users[0] = new User("John", "Doe", card1);

        Card card2 = new Card("2222333344445555", "5678", "456", "09/25", 2500m);
        users[1] = new User("Alice", "Smith", card2);

        Card card3 = new Card("3333444455556666", "9876", "123", "12/23", 500m);
        users[2] = new User("Bob", "Johnson", card3);

        Card card4 = new Card("4444555566667777", "4321", "987", "03/27", 1500m);
        users[3] = new User("Emily", "Williams", card4);

        Card card5 = new Card("5555666677778888", "7890", "654", "08/26", 200m);
        users[4] = new User("Michael", "Brown", card5);

        begin:

        Console.WriteLine("Enter PIN: ");
        string enteredPIN = Console.ReadLine();

        foreach (var user in users)
        {
            if (enteredPIN == user.CreditCard.PIN)
            {
                
                begin2:

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"{user.Name} {user.Surname} xos gelmisiniz!");
                    Console.WriteLine("1. Balans");
                    Console.WriteLine("2. Nagd Pul");
                    Console.WriteLine("3. Kartdan karta kocurme");
                    Console.WriteLine("Seciminizi daxil edin: ");
                    string choice = Console.ReadLine();
                    switch (Convert.ToInt32(choice))
                    {
                        case 1:
                            Console.WriteLine($"Balansiniz: {user.CreditCard.Balance}");
                            Thread.Sleep(1500);
                            break;
                        case 2:
                            Console.WriteLine("1. 10 AZN");
                            Console.WriteLine("2. 20 AZN");
                            Console.WriteLine("3. 50 AZN");
                            Console.WriteLine("4. 100 AZN");
                            Console.WriteLine("5. Diger (Istediyi meblegi ozu qeyd ede biler)");
                            Console.WriteLine("Seciminizi dail edin: ");
                            string choice1 = Console.ReadLine();
                            switch (Convert.ToInt32(choice1))
                            {
                                case 1:
                                    if (user.CreditCard.Balance >= 10)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Evvelki balans: {user.CreditCard.Balance}");
                                        Console.WriteLine("Balansinizdan 10 AZN cixildi!");
                                        user.CreditCard.Balance -= 10;
                                        Console.WriteLine($"Qalan balans: {user.CreditCard.Balance}");
                                        Thread.Sleep(1500);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Balansinizda kifayet qeder mebleg yoxdur!");
                                    }
                                    break;
                                case 2:
                                    if (user.CreditCard.Balance >= 20)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Evvelki balans: {user.CreditCard.Balance}");
                                        Console.WriteLine("Balansinizdan 20 AZN cixildi!");
                                        user.CreditCard.Balance -= 20;
                                        Console.WriteLine($"Qalan balans: {user.CreditCard.Balance}");
                                        Thread.Sleep(1500);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Balansinizda kifayet qeder mebleg yoxdur!");
                                    }
                                    break;
                                case 3:
                                    if (user.CreditCard.Balance >= 50)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Evvelki balans: {user.CreditCard.Balance}");
                                        Console.WriteLine("Balansinizdan 50 AZN cixildi!");
                                        user.CreditCard.Balance -= 50;
                                        Console.WriteLine($"Qalan balans: {user.CreditCard.Balance}");
                                        Thread.Sleep(1500);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Balansinizda kifayet qeder mebleg yoxdur!");
                                    }
                                    break;
                                case 4:
                                    if (user.CreditCard.Balance >= 100)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Evvelki balans: {user.CreditCard.Balance}");
                                        Console.WriteLine("Balansinizdan 100 AZN cixildi!");
                                        user.CreditCard.Balance -= 100;
                                        Console.WriteLine($"Qalan balans: {user.CreditCard.Balance}");
                                        Thread.Sleep(1500);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Balansinizda kifayet qeder mebleg yoxdur!");
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine("Isediyiniz meblegi daxil edin: ");
                                    string money_amount = Console.ReadLine();
                                    if (user.CreditCard.Balance >= Convert.ToDecimal(money_amount))
                                    {
                                        Console.WriteLine($"Evvelki balans: {user.CreditCard.Balance}");
                                        Console.WriteLine($"Balansinizdan {money_amount} AZN cixildi!");
                                        user.CreditCard.Balance -= Convert.ToDecimal(money_amount);
                                        Console.WriteLine($"Qalan balans: {user.CreditCard.Balance}");
                                        Thread.Sleep(1500);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Balansinizda kifayet qeder mebleg yoxdur!");
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Kocurme etmek istediyiniz kartin PIN daxil edin: ");
                            string card_pin = Console.ReadLine();
                            foreach (User item in users)
                            {
                                if (Convert.ToInt32(item.CreditCard.PIN) == Convert.ToInt32(card_pin))
                                {
                                    Console.WriteLine("Isediyiniz meblegi daxil edin: ");
                                    string money_amount = Console.ReadLine();
                                    if (item.CreditCard.Balance >= Convert.ToDecimal(money_amount))
                                    {
                                        Console.WriteLine($"Evvelki balans: {user.CreditCard.Balance}");
                                        Console.WriteLine($"Balansinizdan {money_amount} AZN cixildi!");
                                        user.CreditCard.Balance -= Convert.ToDecimal(money_amount);
                                        item.CreditCard.Balance += Convert.ToDecimal(money_amount);
                                        Console.WriteLine($"Qalan balans: {user.CreditCard.Balance}");
                                        Console.WriteLine($"Pul kocurulen kartin balansi: {item.CreditCard.Balance}");
                                        Thread.Sleep(3000);
                                        goto begin2;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Balansinizda kifayet qeder mebleg yoxdur!");
                                        Thread.Sleep(1500);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Daxil etdiyiniz PIN tapilmadi!");
                                    Thread.Sleep(1500);
                                    goto begin;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}