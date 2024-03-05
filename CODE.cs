using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace StringsAndCollections {
  class Program {
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
        {"прювет", "привет"}
      };
      string numberToFind = @"\((\d{3})\) (\d{3})-(\d{2})-(\d{2})";
      string numberToReplace = "+38 $1 $2 $3 $4";
      string[] filesInPath = Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);

      foreach (string file in filesInPath) {
        string fileContent = File.ReadAllText(file);
        
        foreach (KeyValuePair<string, string> wrongWord in wrongWords) {
          fileContent = fileContent.Replace(wrongWord.Key, wrongWord.Value);
        }

        Regex regex = new Regex(numberToFind);
        fileContent = regex.Replace(fileContent, numberToReplace);

        File.WriteAllText(file, fileContent);
      }

      Console.WriteLine("\nЗамена успешно выполнена");
      Console.ReadKey();
    }
  }
}
