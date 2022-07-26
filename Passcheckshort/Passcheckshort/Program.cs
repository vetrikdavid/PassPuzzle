using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Passcheckshort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------Passcheckshort!----------------");
            string line = "";//üres sor amibe betöltjük a következő sort
            try
            {
               if (File.Exists("passwords.txt"))//ha a file létezik, akkor továbblépünk
                {
                    StreamReader reader = new StreamReader("passwords.txt");//behivatkozzuk az olvasni kívánt file-t
                    int lettercount = 0, passcount = 0;
                    while ((line = reader.ReadLine()) != null)//addig olvassuk, amíg a következő sor nem üres. *feltételezzük, hogy nincs üres sor az adatszerkezetben a végéig*
                    {
                        string[] parts = Removedot(line).Split(" "); // Szóközök mentén a mondat szavakká tördelve, hogy könnyebben lehessen őket eltárolni
                                                                     // parts[0] -> min karakter | parts[1] - > max karakter | parts[2] -> keresett karakter | parts[3] -> jelszó
                        if(parts[3].Contains(parts[2]))
                        {
                            lettercount = Regex.Matches(parts[3], parts[2].ToString()).Count; //megvizsgáljuk, hogy az adott jelszóban hány alkalommal fordul elő a karakterünk
                            if(lettercount >= int.Parse(parts[0]) && lettercount <= int.Parse(parts[1])) //megvizsgáljuk, hogy határon belülre esik e
                            {
                                passcount++; //növeljük a számlálót
                            }
                        }
                    }
                    reader.Close();
                    Console.WriteLine("Jó jelszók: " +passcount);
                }
                else
                {
                    Console.WriteLine("nem létező file");
                }
            }
            catch(Exception error)
            {
                Console.WriteLine("A program a következő hibába futott: " + error);
            }
        }
        public static string Removedot(string inputline) //megszűntetjük a nem szükséges karaktereket (:,-)
        {
            inputline = inputline.Replace(":", "");
            inputline = inputline.Replace("-", " ");
            return inputline;
        }
    }
}
