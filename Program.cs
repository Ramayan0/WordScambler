using WordScambler;
using System.IO;
using WordScambler.workers;
using WordScambler.Data;

public class Program
{
    private static readonly FileReader _fileReader = new FileReader();
    private static readonly WordMatcher _wordMatcher = new WordMatcher();

    static void Main(string[] args)
    {

        try
        {
            bool continueWordUnscramble = true;
            do
            {
                Console.WriteLine(Constants.OptionOnHowToEnterScrambledWords);
                var option = Console.ReadLine() ?? string.Empty;
                switch (option.ToUpper())
                {
                    case Constants.File:
                        Console.Write(Constants.EnterScrambledWordsViaFile);
                        ExecuteWordScramledInFileSecenario();
                        break;
                    case Constants.Manual:
                        Console.Write(Constants.EnterScrambledWordsManually);
                        ExecuteScramledWordManualEntrySecenario();
                        break;
                    default:
                        Console.Write(Constants.EnterScrambledWordsOptionNotRecognized);

                        break;

                }
                var continueDecisions = string.Empty;
                do
                {
                    Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                    continueDecisions = (Console.ReadLine() ?? string.Empty);


                } while (
                    !continueDecisions.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                    !continueDecisions.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                continueWordUnscramble = continueDecisions.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);

            } while (continueWordUnscramble);
        }
        catch (Exception ex)
        {

            Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
        }


    }

    private static void ExecuteScramledWordManualEntrySecenario()
    {
        var manualInput = Console.ReadLine() ?? string.Empty;
        string[] scrambledWords = manualInput.Split(",");
        DisplayMatchedUnscrambleWords(scrambledWords);
    }
    private static void ExecuteWordScramledInFileSecenario()
    {
        try
        {
            var fileInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = _fileReader.Read(fileInput);
            DisplayMatchedUnscrambleWords(scrambledWords);
        }
        catch (Exception ex)
        {
            Console.WriteLine(Constants.ErrorSrambledWordCannotBeLoaded + ex.Message);
        }


    }

    private static void DisplayMatchedUnscrambleWords(string[] scrambledWords)
    {
        string[] wordList = _fileReader.Read(Constants.WordListFileName);
        List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);
        if (matchedWords.Any())
        {
            foreach (var matchedWord in matchedWords)
            {
                Console.WriteLine(Constants.MatchFound,
                matchedWord.ScrambledWord, matchedWord.Word);

            }
        }
        else
        {
            Console.WriteLine(Constants.MatchNotFound);
        }
    }
}




// //Value type it does not change uses stack for popping and pushing
// int a = 10;
//     ChangeNumber(a);
//     Console.WriteLine(a);

// }
// static void ChangeNumber(int a)
// {
//     a = 90;
// }


//   // Reference type from person class uses heap and makes the change
//     Person person = new Person();
//     person.FirstName = "John";
//     person.LastName = "Smith";

//     ChangeNumber(person);
//     Console.WriteLine(person.FirstName);
//     Console.WriteLine(person.LastName);

// }
// static void ChangeNumber(Person personTochange)
// {
//     personTochange.FirstName = "Jane";
//     personTochange.LastName = "Doe";



// ref/out
// changing value type to reference type using ref/out parameter so as to change it
// diff btwn out and ref is that the variable used does not have to be initialized in out
// {
//     int a = 10;
//     ChangeNumber(ref a);
//     Console.WriteLine(a);

// }
// static void ChangeNumber(ref int a)
// {
//     a = 90;
// }
// static void Main(string[] args)
// {
//     int a;
//     ChangeNumber(out a);
//     Console.WriteLine(a);

// }
// static void ChangeNumber(out int a)
// {
//     //variable must be initialize  here when using out
//     a = 90;
// }

// // Null and Null coalascing
// Person person = new Person("John", "Smith");
// // ?? null coalascing operator its a null check
// Person newPerson = person ?? new Person("Default", "Person");
// Console.WriteLine(newPerson.FirstName);



//   // Difference between Const and ReadOnly
//         // const is implicitly static hence can be accessed by the class while readonly is not static hence cannot be accessed
//         Console.WriteLine(someText);
//         Console.WriteLine(someOtherText);
// //const can not be used during initialization of new class but readonly can be
//     // public const  Person  someText = new Person("John", "Smith"); //this brings error
//     // public static readonly Person someOthertext = new Person("John", "Smith");
//     public const string someText = "This is a text";
//     //  const must be initialized first but readonly is not must
//     public static readonly string someOtherText = "This is a some other text";


//    // write a file
//         string[] lines = { "This is the first line", "This is the second line", "This is the third line" };
//         File.WriteAllLines("MyFirstLine.txt", lines);

//         // read a file
//         // this will read from the whole file
//         string[] filecontents = File.ReadAllLines("MyFirstLine.txt");
//         // Console.WriteLine(filecontents[0]);

//         // read from part of the file
//         foreach (string line in File.ReadLines("MyFirstLine.txt"))
//         {
//             Console.WriteLine(line);

//         }
