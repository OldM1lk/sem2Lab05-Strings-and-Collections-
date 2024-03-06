using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace StringsAndCollections {
  class Program {
    static string ReplacePhoneNumber(string input, Match match) {
      string phoneNumber = match.Value;
      string replacedPhoneNumber = "+380 " + phoneNumber.Substring(2, 2) + " " + phoneNumber.Substring(6, 3)
                                   + " " + phoneNumber.Substring(10, 2) + " " + phoneNumber.Substring(13, 2);
      
      return input.Replace(match.Value, replacedPhoneNumber);
    }

    static void Main(string[] args) {
      Console.Write("Введите директорию: ");
      string directoryPath = Console.ReadLine();
      Dictionary<string, string> wrongWords = new Dictionary<string, string> {
        {"привте", "привет"},
        {"притев", "привет"},
        {"пртвеи", "привет"},
        {"птивер", "привет"},
        {"приевт", "привет"},
        {"превит", "привет"},
        {"пеиврт", "привет"},
        {"првиет", "привет"},
        {"пвирет", "привет"},
        {"пирвет", "привет"},
        {"правет", "привет"},
        {"прувит", "привет"},
        {"превет", "привет"},
        {"провет", "привет"},
        {"привот", "привет"},
        {"прывет", "привет"},
        {"привэт", "привет"},
        {"привят", "привет"},
        {"прювет", "привет"},
        {"прявет", "привет"}
      };
      string numberToFind = @"\((\d{3})\) (\d{3})-(\d{2})-(\d{2})";
      string[] filesInPath = Directory.GetFiles(directoryPath, "*.txt");

      foreach (string file in filesInPath) {
        string fileContent = File.ReadAllText(file);
        
        foreach (KeyValuePair<string, string> wrongWord in wrongWords) {
          fileContent = fileContent.Replace(wrongWord.Key, wrongWord.Value);
        }

        MatchCollection matches = Regex.Matches(fileContent, numberToFind);

        foreach (Match match in matches) {
          fileContent = ReplacePhoneNumber(fileContent, match);
        }

        File.WriteAllText(file, fileContent);
      }

      Console.WriteLine("\nЗамена успешно выполнена");
      Console.ReadKey();
    }
  }
}
