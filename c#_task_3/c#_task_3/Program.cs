using System;

class Program
{
    static void Main()
    {
        string[] questions = new string[10]
        {
            "Azerbaycanin paytaxtı hansıdır?",
            "Azerbaycanin resmi dili hansıdır?",
            "Azerbaycanin en böyük gölü hansıdır?",
            "Azerbaycanin milli musiqi aleti hansıdır?",
            "Azerbaycanin en meşhur xalça naxışı hansıdır?",
            "Azerbaycanin neft sahesinde ilk böyük inkişafı ne vaxt baş verib?",
            "Azerbaycanin en meşhur şairi kimdir?",
            "Azerbaycanin milli metbexine aid olan hansı yemek daha meşhurdur?",
            "Azerbaycanin en çox ziyaret edilen turistik mekan hansıdır?",
            "Azerbaycanin esas enerji resursu nedir?"
        };

        string[,] answers = new string[10, 3]
        {
            { "Bakı", "Gence", "Sumqayıt" },
            { "Azerbaycan dili", "Rus dili", "İngilis dili" },
            { "Xezer denizi", "Göygöl", "Mingeçevir su anbarı" },
            { "Tar", "Piano", "Fleyta" },
            { "Quba xalçası", "Qarabağ xalçası", "Tabriz xalçası" },
            { "XIX esrin sonu", "XX esrin evveli", "XVIII esrin ortaları" },
            { "Nizami Gencevi", "Mehemmed Füzuli", "Xaqani Şirvani" },
            { "Plov", "Pizza", "Sushi" },
            { "İçerişeher", "Xezer denizi sahili", "Qebele" },
            { "Neft", "Külek enerjisi", "Su enerjisi" }
        };

        int[] correctAnswers = new int[10] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 2 };

        int score = RunQuiz(questions, answers, correctAnswers);

        Console.Clear();
        Console.WriteLine($"İmtahan bitmişdir, siz {score} xal topladınız.");
    }

    static int RunQuiz(string[] questions, string[,] answers, int[] correctAnswers)
    {
        Random rand = new Random();
        int score = 0;

        for (int i = 0; i < questions.Length; i++)
        {
            int[] indices = { 0, 1, 2 };
            rand.Shuffle(indices);

            Console.Clear();
            Console.WriteLine($"Sual {i + 1}: {questions[i]}");

            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine($"{(char)('a' + j)}) {answers[i, indices[j]]}");
            }

            int chosenAnswer = GetChosenAnswer();
            int actualIndex = indices[chosenAnswer];

            Console.Clear();
            Console.WriteLine($"Sual {i + 1}: {questions[i]}");

            for (int j = 0; j < 3; j++)
            {
                if (j == chosenAnswer)
                {
                    if (actualIndex == correctAnswers[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
                else if (indices[j] == correctAnswers[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.WriteLine($"{(char)('a' + j)}) {answers[i, indices[j]]}");
                Console.ResetColor();
            }

            if (actualIndex == correctAnswers[i])
            {
                score += 10;
            }
            else
            {
                score -= 10;
            }

            if (score < 0)
                score = 0;

            System.Threading.Thread.Sleep(2000);
        }

        return score;
    }

    static int GetChosenAnswer()
    {
        ConsoleKeyInfo keyInfo;
        while (true)
        {
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.A || keyInfo.Key == ConsoleKey.B || keyInfo.Key == ConsoleKey.C)
                break;
        }
        return keyInfo.Key switch
        {
            ConsoleKey.A => 0,
            ConsoleKey.B => 1,
            ConsoleKey.C => 2,
            _ => -1 
        };
    }
}
