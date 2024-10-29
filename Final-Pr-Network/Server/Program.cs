using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeServer
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char currentPlayer = 'X';

        static async Task Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
            Console.WriteLine("Server started... Waiting for players...");

            while (true)
            {
                var player1 = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Player 1 connected.");
                var player2 = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Player 2 connected.");

                _ = Task.Run(() => HandleGame(player1, player2));
            }
        }

        static async Task HandleGame(TcpClient player1, TcpClient player2)
        {
            var stream1 = player1.GetStream();
            var stream2 = player2.GetStream();
            int result = 0;

            while (result == 0)
            {
                await SendBoardState(stream1);
                await SendBoardState(stream2);

                result = await PlayerMove(stream1, 'X'); 
                if (result != 0) break;

                await SendBoardState(stream1);
                await SendBoardState(stream2);

                result = await PlayerMove(stream2, 'O');
            }

            await SendBoardState(stream1);
            await SendBoardState(stream2);
            await AnnounceWinner(stream1, 'X', result);
            await AnnounceWinner(stream2, 'O', result);

            player1.Close();
            player2.Close();
        }

        static async Task<int> PlayerMove(NetworkStream stream, char player)
        {
            while (true)
            {
                string move = await ReadClientMove(stream);
                if (IsValidMove(move))
                {
                    MakeMove(move, player);
                    return CheckWinner();
                }
                await SendMessage(stream, "Invalid move! Try again.");
            }
        }

        static async Task SendBoardState(NetworkStream stream)
        {
            var boardState = string.Join(" ", board);
            byte[] data = Encoding.UTF8.GetBytes(boardState);
            await stream.WriteAsync(data, 0, data.Length);
        }

        static async Task<string> ReadClientMove(NetworkStream stream)
        {
            var buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
        }

        static async Task SendMessage(NetworkStream stream, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(data, 0, data.Length);
        }

        static async Task AnnounceWinner(NetworkStream stream, char player, int result)
        {
            if (result == 1 && player == 'X')
                await SendMessage(stream, "Player X wins!");
            else if (result == 1 && player == 'O')
                await SendMessage(stream, "Player O wins!");
            else
                await SendMessage(stream, "It's a draw!");
        }

        static bool IsValidMove(string move)
        {
            if (int.TryParse(move, out int choice) && choice >= 1 && choice <= 9)
            {
                return board[choice - 1] != 'X' && board[choice - 1] != 'O';
            }
            return false;
        }

        static void MakeMove(string move, char player)
        {
            int choice = int.Parse(move);
            board[choice - 1] = player;
        }

        static int CheckWinner()
        {
            int[,] winningCombinations = {
                { 0, 1, 2 }, 
                { 3, 4, 5 }, 
                { 6, 7, 8 }, 
                { 0, 3, 6 }, 
                { 1, 4, 7 }, 
                { 2, 5, 8 }, 
                { 0, 4, 8 }, 
                { 2, 4, 6 }  
            };

            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                if (board[winningCombinations[i, 0]] == board[winningCombinations[i, 1]] &&
                    board[winningCombinations[i, 0]] == board[winningCombinations[i, 2]])
                {
                    return 1; 
                }
            }

            if (Array.IndexOf(board, '1') == -1 && Array.IndexOf(board, '2') == -1 &&
                Array.IndexOf(board, '3') == -1 && Array.IndexOf(board, '4') == -1 &&
                Array.IndexOf(board, '5') == -1 && Array.IndexOf(board, '6') == -1 &&
                Array.IndexOf(board, '7') == -1 && Array.IndexOf(board, '8') == -1 &&
                Array.IndexOf(board, '9') == -1)
            {
                return -1; 
            }
            return 0; 
        }
    }
}
