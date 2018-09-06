using System;
using System.Collections.Generic;

class Words
{
  private string _inputWord;

  public Words(string input)
  {
    _inputWord = input;
  }

  public void SetWord(string input)
  {
    _inputWord = input;
  }

  public String GetWord()
  {
    return _inputWord;
  }

  public bool IsAnagram(Words word, string master)
  {
    int count = 0;
    int isAna = 0;
    string testWord = word.GetWord();
    foreach(char letter in testWord)
    {
      foreach (char mastLetter in master)
      {
        if (mastLetter == letter)
        {
          count++;
          isAna++;
        }
      }
      if (count == 0)
      {
        return false;
      }
      else
      {
        count = 0;
      }
    }
    return (isAna > 0) ? true : false;
  }
}

public class Program
{
  static string MasterWord = "";
  static List<Words> storedList = new List<Words>() {};

  public static void Menu()
  {
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Select one of the following options:");
    Console.WriteLine("1) Set the master word");
    Console.WriteLine("2) Add word to the list to check");
    Console.WriteLine("3) Check the list against the master word");
  }


  public static void Main()
  {
    Console.WriteLine("This program will check to see if a list of words is an Anagram of a master word");
    Console.WriteLine("------------------------------------------");
    Menu();
    string input = Console.ReadLine();
    if (input == "1") {
      Console.WriteLine("Input the master word:");
      MasterWord = Console.ReadLine();
      Main();
    }
    else if (input == "2")
    {
      Console.WriteLine("What word to you want to add to the list of potential Anagrams?");
      if (MasterWord != "")
      {
        Console.WriteLine("Your master word is:" + MasterWord);
      }
      string potentialAnagram = Console.ReadLine();
      Words word = new Words(potentialAnagram);
      storedList.Add(word);
      Console.WriteLine("You list is:");
      foreach (Words item in storedList)
      {
          Console.WriteLine(item.GetWord());
      }
      Main();
    }
    else if (input == "3")
    {
      if (storedList.Count == 0)
      {
        Console.WriteLine("There are no words to compare to the master word");
        Main();
      }
      else if (MasterWord == "")
      {
        Console.WriteLine("There is no master word. Please set.");
        Main();
      }
      else
      {
        Console.WriteLine("Here is a list your words and if they are an Anagram");
        foreach (Words word in storedList)
        {
          Console.WriteLine(word.GetWord() + " - is Anagram " + word.IsAnagram(word, MasterWord));
        }
        Main();
      }
    }

  }


}
