using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;

Random random = new Random();

byte death = 0;
string guessed_word = "";
string player_letter = "";
bool game_end = false;

string lang = "en";

string[] words_to_guess = { "apple", "window", "toothbrush", "book", "chair", "shoe", "stove", "morning", "school", "pencil", "knife", "camera", "microphone", "headphones", "toaster", "microwave", "toothbrush", "laptop", "phone", "mirror", "television", "flower", "washboard", "cobweb", "inkwell", "fipple", "quodlibet", "objurgate", "pandiculation", "gaberlunzie", "gallimaufry" };
string[] words_to_guess_ru = { "яблоко", "окно", "щётка", "книга", "стул", "обувь", "печь", "утро", "школа", "карандаш", "нож", "камера", "микрофон", "наушники", "тостер", "микроволновка", "ноутбук", "телефон", "зеркало", "телевизор", "цветок", "доска", "явства", "чернильница", "русич", "катастрофа", "бюрократство", "пустомеля", "терем", "чашница", "супостат", "золотник" };

string[] guessed_letters = new string[4];

void ChangeLang()
{
    while (true)
    {
        Console.WriteLine("Select language\nEnglish - en\nRussian - ru");
        lang = Convert.ToString(Console.ReadLine());

        if (lang == "en" || lang == "ru") break;
        else
        {
            Console.Clear();
            continue;
        }
    }
}

void MakeWord()
{
    if (lang == "en")
    {
        guessed_word = words_to_guess[new Random().Next(words_to_guess.Length)];

        if (guessed_word.Length < 6) // 5 and less.
        {
            for (int i = 0; i < 1; i++)
            {
                int randomIndex = random.Next(0, guessed_word.Length);
                char randomChar = guessed_word[randomIndex];
                guessed_letters[i] = randomChar.ToString();
            }
        }
        else if (guessed_word.Length > 5 && guessed_word.Length < 9) // 6 - 8
        {
            for (int i = 0; i < 2; i++)
            {
                int randomIndex = random.Next(0, guessed_word.Length);
                char randomChar = guessed_word[randomIndex];
                guessed_letters[i] = randomChar.ToString();
            }
        }
        else if (guessed_word.Length > 8 && guessed_word.Length < 11) // 9 - 10
        {
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = random.Next(0, guessed_word.Length);
                char randomChar = guessed_word[randomIndex];
                guessed_letters[i] = randomChar.ToString();
            }
        }
        else if (guessed_word.Length > 10) // 11 and more
        {
            for (int i = 0; i < 4; i++)
            {
                int randomIndex = random.Next(0, guessed_word.Length);
                char randomChar = guessed_word[randomIndex];
                guessed_letters[i] = randomChar.ToString();
            }
        }
    }
    if (lang == "ru")
    {
        guessed_word = words_to_guess_ru[new Random().Next(words_to_guess_ru.Length)];

        if (guessed_word.Length < 6) // 5 and less.
        {
            for (int i = 0; i < 1; i++)
            {
                int randomIndex = random.Next(0, guessed_word.Length);
                char randomChar = guessed_word[randomIndex];
                guessed_letters[i] = randomChar.ToString();
            }
        }
        else if (guessed_word.Length > 5 && guessed_word.Length < 9) // 6 - 8
        {
            for (int i = 0; i < 2; i++)
            {
                int randomIndex = random.Next(0, guessed_word.Length);
                char randomChar = guessed_word[randomIndex];
                guessed_letters[i] = randomChar.ToString();
            }
        }
        else if (guessed_word.Length > 8 && guessed_word.Length < 11) // 9 - 10
        {
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = random.Next(0, guessed_word.Length);
                char randomChar = guessed_word[randomIndex];
                guessed_letters[i] = randomChar.ToString();
            }
        }
        else if (guessed_word.Length > 10) // 11 and more
        {
            for (int i = 0; i < 4; i++)
            {
                int randomIndex = random.Next(0, guessed_word.Length);
                char randomChar = guessed_word[randomIndex];
                guessed_letters[i] = randomChar.ToString();
            }
        }
    }
}

void PrintHang(int mistakes)
{
    Console.Clear();
    if (mistakes == 0)
    {
        Console.WriteLine(" _______");
        Console.WriteLine(" |     |");
        Console.WriteLine(" |");
        Console.WriteLine(" |");
        Console.WriteLine(" |/");
        Console.WriteLine(" |");
    }

    if (mistakes == 1)
    {
        Console.WriteLine(" _______");
        Console.WriteLine(" |     |");
        Console.WriteLine(" |     o");
        Console.WriteLine(" |");
        Console.WriteLine(" |/");
        Console.WriteLine(" |");
    }

    if (mistakes == 2)
    {
        Console.WriteLine(" _______");
        Console.WriteLine(" |     |");
        Console.WriteLine(" |     o");
        Console.WriteLine(" |     0");
        Console.WriteLine(" |/");
        Console.WriteLine(" |");
    }

    if (mistakes == 3)
    {
        Console.WriteLine(" _______");
        Console.WriteLine(" |     |");
        Console.WriteLine(" |     o");
        Console.WriteLine(" |    /0");
        Console.WriteLine(" |/");
        Console.WriteLine(" |");
    }

    if (mistakes == 4)
    {
        Console.WriteLine(" _______");
        Console.WriteLine(" |     |");
        Console.WriteLine(" |     o");
        Console.WriteLine(" |    /0\\");
        Console.WriteLine(" |/");
        Console.WriteLine(" |");
    }                       
                            
    if (mistakes == 5)      
    {                       
        Console.WriteLine(" _______");
        Console.WriteLine(" |     |");
        Console.WriteLine(" |     o");
        Console.WriteLine(" |    /0\\");
        Console.WriteLine(" |/   /");
        Console.WriteLine(" |");
    }

    if (mistakes == 6)
    {
        Console.WriteLine(" _______");
        Console.WriteLine(" |     |");
        Console.WriteLine(" |     o");
        Console.WriteLine(" |    /0\\");
        Console.WriteLine(" |/   / \\");
        Console.WriteLine(" |");
    }

    if (mistakes == 7)
    {
        Console.WriteLine(" _______");
        Console.WriteLine(" |     |");
        Console.WriteLine(" |     o");
        Console.WriteLine(" |    /0\\");
        Console.WriteLine(" |\\   / \\");
        Console.WriteLine(" |");
    }

    PrintGuessedWord();
    
    if (mistakes == 7)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        if (lang == "en") Console.WriteLine(" You lose...");
        if (lang == "ru") Console.WriteLine(" Ты проиграл...");
        Console.ResetColor();
        if (lang == "en") Console.WriteLine($" Word is: {guessed_word}");
        if (lang == "ru") Console.WriteLine($" Слово было: {guessed_word}");
        game_end = true;
    }
}

void CheckLetterInWord()
{
    bool contain = guessed_word.Contains(player_letter);
    if (contain == true)
    {
        guessed_letters = guessed_letters.Append(player_letter).ToArray();
    }
    else if (contain == false) death += 1;
}

void PrintGuessedWord()
{
    foreach (char c in guessed_word)
    {
        Console.Write(" ");
        string char_in_guessed_word = Convert.ToString(c);
        if (guessed_letters.Contains(char_in_guessed_word))
        {
            Console.Write(c);
        }
        else
        {
            Console.Write("*");
        }
    }
    Console.WriteLine("\n----------------------------");
}

void CheckWin()
{
    if (guessed_word.All(c => guessed_letters.Contains(c.ToString())) == true)
    {
        PrintHang(death);
        Console.ForegroundColor = ConsoleColor.Green;
        if (lang == "en") Console.WriteLine(" You win!!!");
        if (lang == "ru") Console.WriteLine(" Ты победил!!!");
        Console.ResetColor();
        game_end = true;
    }
}
void resetvars()
{
    death = 0;
    guessed_word = "";
    player_letter = "";
}

// Game
ChangeLang();

MakeWord();

while (true)
{
    while (game_end == false)
    {
        PrintHang(death);

        player_letter = Convert.ToString(Console.ReadLine());
        CheckLetterInWord();

        CheckWin();
    }

    if (game_end == true)
        if (lang == "en") Console.WriteLine("Play again?");
        if (lang == "ru") Console.WriteLine("Ещё раз?");
    Console.ReadLine();
    game_end = false;
    resetvars();
    MakeWord();
}