using System.Text;
using System.Threading.Channels;

class Program
{
    static void Main()
    {
        Console.WriteLine("Fayilin youlunu daxil edin: ");
        string filePath = Console.ReadLine();

        if(File.Exists(filePath))
        {
            string fileContent = File.ReadAllText(filePath);

            Console.WriteLine("Acari daxil edin: ");
            int key = Convert.ToInt32(Console.ReadLine());    
            string encryptData = EncryptData(fileContent, key);
            
            File.WriteAllText(filePath, encryptData);
            Console.WriteLine("Fayl sifrelendi");
        }
        else
        {
            {
                Console.WriteLine("Bele fayl movcud deyil!");
            }
        }

        static string EncryptData(string data, int key)
        {
            StringBuilder encrypted_file = new StringBuilder(); 

            foreach(char c in data)
            {
                encrypted_file.Append((char)(c ^ key));
            }

            return encrypted_file.ToString();
        }
    }
}