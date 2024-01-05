//HangMan Game, Michaela Condari, march 02, 2023
using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;
using System.IO;
internal class Program
{
    private static void print(int wrongguess) //counts wrong guesses for up to 6 attempts
    {
        if (wrongguess == 0)
        {
            Console.WriteLine("-");
            Console.WriteLine(" |");
        }
        else if (wrongguess == 1)
        {
            Console.WriteLine("-");
            Console.WriteLine("|");
            Console.WriteLine(" ()"); 
        }
        else if (wrongguess == 2)
        {
            Console.WriteLine("-");
            Console.WriteLine(" |");
            Console.WriteLine(" ()");
            Console.WriteLine("|");
        }
        else if (wrongguess == 3)
        {
            Console.WriteLine("-");
            Console.WriteLine(" |");
            Console.WriteLine(" ()");
            Console.WriteLine("\\|"); // uses \\ as an excape character
        }
        else if (wrongguess == 4)
        {
            Console.WriteLine(" -");
            Console.WriteLine(" |");
            Console.WriteLine(" ()");
            Console.WriteLine("\\|/");
        }
        else if (wrongguess == 5)
        {
            Console.WriteLine("-");
            Console.WriteLine(" |");
            Console.WriteLine(" ()");
            Console.WriteLine("\\|/");
            Console.WriteLine("/");
        }
        else if (wrongguess == 6)
        {
            Console.WriteLine("-");
            Console.WriteLine(" |");
            Console.WriteLine(" ()");
            Console.WriteLine("\\|/"); 
            Console.WriteLine("/ \\");
        }

    }
    private static int printWord( List<char> guess, string randomWord )
    {
        int count = 0;
        int correct = 0;
        Console.WriteLine("\n ");
        foreach (char x in randomWord )
        {
            if (guess.Contains(x))
            {
                correct++;
                Console.Write(x + " ");

            }
            else
            {
                Console.Write(" ");
            }
            count++;
        }
        return correct;
    }
    private static void printLine(List<char> guess, string random)
    {
        Console.Write("\r");
        foreach (char c in random)
        {
            if (guess.Contains(c))
            {
                Console.Write(c);
            }
            else
            {
                Console.Write("_");
            }
            
        }
    
}
    private static bool Check (string word, char guess)
    {
        for (int i =0; i<word.Length; i++) 
        { 
            if (guess == word[i])
            {
                return true;
            }
            
        }
        return false;
    }
    static void Main(string[] args)
    {
        Console.Write("_________________________________________________");
        int currWrong = 0;
        int currRight=0;

        // create random list
        Random random = new Random();
        List<string> dictionary = new List<string> (15);
        string line;
        StreamReader file = new StreamReader(@"C:\Users\micha\Desktop\GitHub\HangMan\HangMan\Words.txt");
        while ((line = file.ReadLine()) != null) // place name age and height in seperate arrays
        {
            dictionary.Add(line);
            
        }
        int choose = random.Next(dictionary.Count);
        string word = dictionary[choose];


        for (int i =0; i < word.Length; i++)
        {
            Console.WriteLine("_");
        }


        // create a list of guesses

        List <char> guessed = new List<char>();

        //loop through game
        while (currWrong != 6 && currRight != word.Length )
        {

            Console.Write("\nLetters guessed so far: ");
            foreach (char letter in guessed)
            {
                Console.Write(letter + " ");
            }

            Console.WriteLine("Guess a new letter: ");
            char guessLetter = Console.ReadLine()[0];
            
            // check to make sure letter hasnt already been guessed
            if ( guessed.Contains(guessLetter) ) 
            {
                Console.WriteLine("That letter has already been guessed, guess a new letter: ");
                guessLetter = Console.ReadLine()[0];
                print(currWrong);
                currRight = printWord(guessed, word);
                printLine(guessed, word);
            }
            else
            {
                bool right = Check(word, guessLetter);
                if (right == true) //guess right
                {
                    print(currWrong);
                    guessed.Add(guessLetter);
                    currRight = printWord(guessed, word) ;  
                    printLine(guessed, word);
                    Console.WriteLine("You guessed Right!");
                }
                else if (right == false) // guess wrong
                {
                    currWrong++;
                    print(currWrong);
                    guessed.Add(guessLetter);
                    currRight = printWord(guessed, word);
                    printLine(guessed ,word);
                    Console.WriteLine("You guessed Wrong!");
                }

            }

        }
        Console.WriteLine("thanks for playing your word was," + word +  " Game Over");
    }
}