class Program
{
    static void Main(string[] args)
    {
        string[] menuItems = { "Element 1", "Element 2", "Element 3" };
        int selectedIndex = 0;

        ConsoleKey key;
        do
        {
            Console.Clear();
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(menuItems[i]);
                }
            }

            key = Console.ReadKey().Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = menuItems.Length - 1;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= menuItems.Length)
                {
                    selectedIndex = 0;
                }
            }
        } while (true);
    }
}