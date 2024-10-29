using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new TcpClient();
            try
            {
                await client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 5000);
                using (var stream = client.GetStream())
                {
                    while (true)
                    {
                        if (!client.Connected)
                        {
                            Console.WriteLine("Connection to the server has been lost.");
                            break;
                        }

                        var buffer = new byte[1024];
                        var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        var boardState = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.Clear();
                        DisplayBoard(boardState);

                        Console.WriteLine("Enter your move (1-9):");
                        var move = Console.ReadLine();

                        if (!string.IsNullOrEmpty(move))
                        {
                            var moveBytes = Encoding.UTF8.GetBytes(move);
                            await stream.WriteAsync(moveBytes, 0, moveBytes.Length);
                        }

                        bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.WriteLine(message);
                        if (message.Contains("wins") || message.Contains("draw"))
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
                Console.WriteLine("Client closed.");
            }

            Console.WriteLine("Game over. Press any key to exit.");
            Console.ReadKey();
        }

        static void DisplayBoard(string boardState)
        {
            var board = boardState.Split(' ');

            if (board.Length != 9)
            {
                Console.WriteLine("Invalid board state received.");
                return;
            }

            Console.WriteLine(" {0} | {1} | {2}", board[0], board[1], board[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2}", board[3], board[4], board[5]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2}", board[6], board[7], board[8]);
        }
    }
}
