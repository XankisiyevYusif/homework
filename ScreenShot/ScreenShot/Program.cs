using System.Net;
using System.Net.Sockets;

class Program
{
    static void Main()
    {
        int port = 27001;
        TcpListener server = new TcpListener(IPAddress.Any, port);
        server.Start();
        Console.WriteLine("Server Started");

        while (true)
        {
            try
            {
                using (TcpClient client = server.AcceptTcpClient())
                using (NetworkStream stream = client.GetStream())
                {
                    string clientId = client.Client.RemoteEndPoint.ToString();
                    string sanitizedClientId = clientId.Replace(":", "_").Replace(".", "_");

                    string clientFolder = Path.Combine("Screenshots", sanitizedClientId);

                    if (!Directory.Exists(clientFolder))
                    {
                        Directory.CreateDirectory(clientFolder);
                    }

                    byte[] buffer = new byte[1024 * 1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    string fileName = Path.Combine(clientFolder, $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.jpg");
                    using (FileStream fs = new FileStream(fileName, FileMode.Create))
                    {
                        fs.Write(buffer, 0, bytesRead);
                    }

                    Console.WriteLine($"Picture downloaded: {fileName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}