using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 49669);
            server.Start();
            Console.WriteLine("Server started");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[1024];
                int byteCount = stream.Read(buffer, 0, buffer.Length);
                string request = Encoding.UTF8.GetString(buffer, 0, byteCount);

                using (var db = new UserDbContext())
                {
                    if (request.StartsWith("ADD"))
                    {
                        string userName = request.Substring(4);
                        var user = new User { Name = userName };
                        db.Users.Add(user);
                        db.SaveChanges();
                        Console.WriteLine($"User '{userName}' added.");
                    }
                    else if (request.StartsWith("DELETE"))
                    {
                        try
                        {
                            int userId = int.Parse(request.Substring(7));
                            var user = db.Users.Find(userId);
                            if (user != null)
                            {
                                db.Users.Remove(user);
                                db.SaveChanges();
                                Console.WriteLine($"User with ID '{userId}' deleted.");
                            }
                            else
                            {
                                Console.WriteLine("User not found.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (request == "ALL")
                    {
                        var users = db.Users.ToList();
                        StringBuilder response = new StringBuilder();
                        foreach (var user in users)
                        {
                            response.AppendLine($"{user.Id}: {user.Name}");
                        }

                        byte[] responseBytes = Encoding.UTF8.GetBytes(response.ToString());
                        stream.Write(responseBytes, 0, responseBytes.Length);
                    }
                }
                client.Close();
            }
        }
    }
}
