using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

byte death = 0;
string guessed_word;
string player_letter = "";
bool game_end = false;

string[] words_to_guess = { "apple", "window", "toothbrush", "book", "chair", "shoe", "stove", "banana", "morning", "school", "pencil", "knife", "camera", "microphone", "headphones", "toaster", "microwave", "toothbrush", "laptop", "phone", "mirror", "television", "flower", "washboard", "cobweb", "inkwell", "fipple", "quodlibet", "objurgate", "pandiculation", "gaberlunzie", "gallimaufry" };
string[] guessed_letters = {};

void MakeWord()
{
    guessed_word = words_to_guess[new Random().Next(words_to_guess.Length)];
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
        Console.WriteLine(" You lose...");
        Console.ResetColor();
        Console.WriteLine($" Word is: {guessed_word}");
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
        Console.WriteLine(" You win!!!");
        Console.ResetColor();
        game_end = true;
    }
}

// Game
MakeWord();

while (game_end == false)
{
    PrintHang(death);

    player_letter = Convert.ToString(Console.ReadLine());
    CheckLetterInWord();

    CheckWin();
}