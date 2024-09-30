using Bogus;
using System.Text.Json;

namespace home_work
{
    class Program
    {
        static List<User> listOfUsers = new List<User>();
        static int remainingThreads;
        static void Main()
        {
            #region Fake Users
            //var faker = new Faker<User>();
            //var users = faker.RuleFor(u => u.Name, f => f.Person.FirstName)
            //    .RuleFor(u => u.Surname, f => f.Person.LastName)
            //    .RuleFor(u => u.Email, f => f.Internet.Email())
            //    .RuleFor(u => u.DateOfBirth, f => f.Person.DateOfBirth)
            //    .Generate(10);

            //string filePath = "5.json";

            //using (StreamWriter writer = new StreamWriter(filePath, append: true))
            //{
            //    foreach (var product in users)
            //    {
            //        string jsonString = JsonSerializer.Serialize(product);

            //        writer.WriteLine(jsonString);
            //    }
            //}
            #endregion
            Console.WriteLine("1. Single Thread");
            Console.WriteLine("2. Multi Threads");
            Console.Write("Select mode: ");
            int choice = int.Parse(Console.ReadLine());

            string[] files = { "1.json", "2.json", "3.json", "4.json", "5.json" }; 

            if (choice == 1)
            {
                foreach (var file in files)
                {
                    ReadFromFile(file);
                }
            }
            else if (choice == 2)
            {
                remainingThreads = files.Length;
                ManualResetEvent resetEvent = new ManualResetEvent(false);

                foreach (var file in files)
                {
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        ReadFromFile(file);

                        if (Interlocked.Decrement(ref remainingThreads) == 0)
                        {
                            resetEvent.Set(); 
                        }
                    });
                }

                resetEvent.WaitOne();
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }

            Console.WriteLine($"Total users: {listOfUsers.Count}");
        }

        static void ReadFromFile(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                var users = JsonSerializer.Deserialize<List<User>>(json);

                lock (listOfUsers)
                { 
                    listOfUsers.AddRange(users);
                }

                Console.WriteLine($"File {filePath} processed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
        }
    }
}
