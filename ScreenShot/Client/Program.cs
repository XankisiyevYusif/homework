using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Sockets;

class Program
{
    static void Main()
    {
        string serverIp = "192.168.0.109";
        int port = 27001;

        while (true)
        {
            using (TcpClient client = new TcpClient(serverIp, port))
            using (NetworkStream stream = client.GetStream())
            {
                int widh = 1920;
                int height = 1080;

                using (Bitmap bmp = new Bitmap(widh, height))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.CopyFromScreen(0, 0, 0, 0, new Size(widh, height));
                    }

                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmp.Save(ms, ImageFormat.Jpeg);
                        byte[] imageBytes = ms.ToArray();

                        stream.Write(imageBytes, 0, imageBytes.Length);
                    }

                    Console.WriteLine("Picture sent succeesful!");
                }
            }
            Thread.Sleep(10000);
        }
    }
}