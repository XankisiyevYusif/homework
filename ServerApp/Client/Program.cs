using System.Net.Sockets;
using System.Text;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. All Users");
                Console.WriteLine("2. Add User");
                Console.WriteLine("3. Delete User");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        SendRequest("ALL");
                        break;
                    case "2":
                        Console.Write("Enter username to add: ");
                        string userName = Console.ReadLine();
                        SendRequest($"ADD {userName}");
                        break;
                    case "3":
                        Console.Write("Enter user ID to delete: ");
                        string userId = Console.ReadLine();
                        SendRequest($"DELETE {userId}");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        static void SendRequest(string request)
        {
            try
            {
                TcpClient client = new TcpClient("192.168.0.109", 49669);
                NetworkStream stream = client.GetStream();

                byte[] data = Encoding.UTF8.GetBytes(request);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int byteCount = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, byteCount);
                Console.WriteLine(response);

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
