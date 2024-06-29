using System;
using System.IO;
using System.Text;
using water_task.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        
        User user = new User();
        int icilenSu = 0;
        int noramSu = 4;


        Console.WriteLine("Adinizi daxil edin: ");
        user.name = Console.ReadLine();
        Console.WriteLine("Yasinizi daxil eidn: ");
        user.age = int.Parse(Console.ReadLine());
        Console.WriteLine($"{user.name} xos geldiniz!");

        int choice;
        do
        {
            Console.WriteLine("1. Su ic");
            Console.WriteLine("2. Tarixce(History)");
            Console.WriteLine("3. Gunu Bitir");
            Console.WriteLine("4. Cixis");
            Console.Write("Seciminizi daxil edin: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    drikWater();
                    break;
                case 2:
                    history();
                    break;
                case 3:
                    Console.WriteLine("Su ic!");
                    break;
                case 4:
                    Console.WriteLine("Cixis etdiniz!");
                    break;
                default:
                    Console.WriteLine("Yalnis secim");
                    break;
            }
        } while (choice != 4);

        void drikWater()
        {
            Console.Clear();
            Console.WriteLine("Icmel istediyiniz suyun miqdarini daxil edin:");
            int icilensu = int.Parse(Console.ReadLine());
            icilenSu += icilensu;
            var fs = new FileStream(path: "history.txt", mode: FileMode.OpenOrCreate, access: FileAccess.Write);
            int count = 1;
            var data = $"{count}. {icilensu} litr su icildi.";
            var bytes = Encoding.UTF8.GetBytes(data);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush(); 
            fs.Dispose();
        }

        void history()
        {
            Console.Clear();
            using (var stream = new FileStream(path: "history.txt", mode: FileMode.Open, access: FileAccess.Read))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                var str = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(str);
            }
        }
    }
}