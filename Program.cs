using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Artical
{
    class Program
{
    static bool IsPal(string str)
{
    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] != str[str.Length - i - 1])
        {
            return false;
        }
    }
    return true;
}

    static void Main(string[] args)
    {
      Console.WriteLine("Please enter file path：");
      string filePath = Console.ReadLine(); 
      StreamReader sr = new StreamReader(filePath);
      string article = sr.ReadToEnd(); 


//1. Count the number of lines, words, and characters ......
      int lineCount = 0;
      while (sr.ReadLine() != null)
            {
                lineCount++;
            }
            Console.WriteLine($"line number：{lineCount}");


      string[] words=article.Split(' ',StringSplitOptions.RemoveEmptyEntries);
      int wordCount = words.Length;
      Console.WriteLine($"word number：{wordCount}");


      int charCount=0;
      foreach (char c in article)
      {
        if(char.IsLetterOrDigit(c)){
            charCount++;
        }
      }
      Console.WriteLine($"字charactor number：{charCount}");

//2. Find the longest and shortest words i .....
      // 找到最长和最短的单词
        string longestWord = words[0];
        string shortestWord = words[0];
        foreach (string word in words)
        {
    if (word.Length > longestWord.Length)
    {
        longestWord = word;
    }
    if (word.Length < shortestWord.Length)
    {
        shortestWord = word;
    }
    }
Console.WriteLine($"the longest word:{longestWord},lenth:{longestWord.Length}");
Console.WriteLine($"the shortest word:{shortestWord},lenth:{shortestWord.Length}");


//3. Compute the frequency of each word and output the top N ......
// 找到相同的单词并排序
int[] sameWordCount = new int[words.Length]; // 存储每个单词出现的次数
for (int i = 0; i < words.Length; i++)
{
    for (int j = 0; j < words.Length; j++)
    {
        if (i != j && words[i] == words[j])
        {
            sameWordCount[i]++;
        }
    }
}
// 将单词和出现次数组合成二维数组
string[,] wordFrequency = new string[words.Length, 2];
for (int i = 0; i < words.Length; i++)
{
    wordFrequency[i, 0] = words[i];
    wordFrequency[i, 1] = sameWordCount[i].ToString();
}
// 按照出现次数降序排序
for (int i = 0; i < words.Length - 1; i++)
{
    for (int j = i + 1; j < words.Length; j++)
    {
        if (Convert.ToInt32(wordFrequency[i, 1]) < Convert.ToInt32(wordFrequency[j, 1]))
        {
            // 交换位置
            string tempWord = wordFrequency[i, 0];
            string tempCount = wordFrequency[i, 1];
            wordFrequency[i, 0] = wordFrequency[j, 0];
            wordFrequency[i, 1] = wordFrequency[j, 1];
            wordFrequency[j, 0] = tempWord;
            wordFrequency[j, 1] = tempCount;
        }
    }
}
// 输出前N个出现次数最多的单词

Console.WriteLine("How many top words do you want?");
int N=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("top {0}frequency words:", N);
for (int i = 0; i < N && i < words.Length; i++)
{
    Console.WriteLine("{0}: {1}", wordFrequency[i, 0], wordFrequency[i, 1]);
}

//4. Identify and output all palindromic words (words that are spelled the same backward and forwards).

foreach (string word in words)
{
    if (IsPal(word))
    {
        Console.WriteLine($"{word} is a palindrome.");
    }
}

//5. Identify and output all pairs of words ......
string[] newString=new string[words.Length-1];
for(int i=0;i<words.Length-1;i++){
    newString[i]=string.Concat(words[i]," ",words[i+1]);
}
int[] newStringCount=new int[words.Length-1];
for(int i=0;i<words.Length-1;i++){
    for(int j=0;j<words.Length-1;j++){
         if (i != j && newString[i] == newString[j])
        {
            newStringCount[i]++;
        }
            }
        }

string[,] newFrequency = new string[words.Length-1, 2];
for (int i = 0; i < words.Length-1; i++)
{
    newFrequency[i, 0] = newString[i];
    newFrequency[i, 1] = newStringCount[i].ToString();
}
Console.WriteLine("Please enter the threshold:");
        int threshold = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("\nPairs of words and their frequency:");
        for (int i = 0; i < newFrequency.GetLength(0); i++) {
            Console.WriteLine($"{newFrequency[i, 0]}: {newFrequency[i, 1]} times");
            if (newStringCount[i] == threshold) {
                Console.WriteLine($"{newFrequency[i, 0]} occurs {threshold} times");
            }
        }
    }
    }
}


