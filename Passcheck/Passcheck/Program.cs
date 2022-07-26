using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Passcheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------Passcheck!----------------");
            Password password = new Password();//osztály példányosítás
            List<Password> passwords = new List<Password>(); //Lista a szétbontott jelszavaknak
            string line = "";//üres sor amibe betöltjük a következő sort
            try
            {
                if (File.Exists("passwords.txt"))//ha a file létezik, akkor továbblépünk
                {
                    StreamReader reader = new StreamReader("passwords.txt");//behivatkozzuk az olvasni kívánt file-t
                    while ((line = reader.ReadLine()) != null)//addig olvassuk, amíg a következő sor nem üres. *feltételezzük, hogy nincs üres sor az adatszerkezetben a végéig*
                    {
                        string[] parts = Removedot(line).Split(" "); // Szóközök mentén a mondat szavakká tördelve, hogy könnyebben lehessen őket eltárolni
                        //Passwords pass = new Passwords(); //A darabolt részeket eltároljuk 
                        password = new Password();
                        password.Lenghtmin = int.Parse(parts[0]);
                        password.Lenghtmax = int.Parse(parts[1]);
                        password.Passletter = char.Parse(parts[2]);
                        password.Word = parts[3];
                        passwords.Add(password); //-----------------
                    }
                    reader.Close();//Lezárjuk a beolvasást

                    int finalcount = 0;
                    foreach (Password data in passwords)
                    {
                        finalcount = finalcount + Passvalidity(data.Lenghtmin, data.Lenghtmax, data.Passletter, data.Word);//paraméterek átadása a függvénynek számításra
                    }
                    Console.WriteLine("A feldolgozott jelszavak száma: " + passwords.Count);
                    Console.WriteLine("A megfelelő jelszavak száma: "+finalcount);
                    Passpercent(finalcount,passwords.Count);
                }
                else
                {
                    Console.WriteLine("nem létező file");
                }
            }
            catch(Exception error)
            {
                Console.WriteLine("Hiba leírása: " + error);
            }
 
        }

        public static string Removedot(string inputline) //megszűntetjük a nem szükséges karaktereket (:,-)
        {
            inputline = inputline.Replace(":", "");
            inputline = inputline.Replace("-", " ");
            return inputline;
        }

        public static int Passvalidity(int _lenghtmin,int _lenghtmax, char _passletter, string _word) //a jelszavak validitásának ellenőrzése és összeszámítása
        {
            if(_word.Contains(_passletter))
            {
                int lettercount = Regex.Matches(_word, _passletter.ToString()).Count;
                if(lettercount >= _lenghtmin && lettercount <= _lenghtmax)
                {
                    return 1;
                }
            }
            return 0;
        }

        public static void Passpercent(int finalcount, int listsize)
        {
            float percent = 0F;
            percent = (float)finalcount / (float)listsize * 100;
            Console.WriteLine("A jelszavak: "+percent + "%"+"-a felel meg az irányelvnek.");           
        }
        
    }
}
