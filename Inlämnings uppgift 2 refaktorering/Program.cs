using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning_2_ra_kod
{
    class Person
    {
        public string namn, adress, telephone, email;
        public Person(string N, string A, string T, string E)
        {
            namn = N; adress = A; telephone = T; email = E;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> Dict = new List<Person>();

            Console.Write("Laddar adresslistan ... ");
            using (StreamReader fileStream = new StreamReader(@"C:\Users\Anthony\newadressfile.txt"))
            {
                while (fileStream.Peek() >= 0)
                {
                    string line = fileStream.ReadLine();
                    // Console.WriteLine(line);
                    string[] word = line.Split('#');
                    // Console.WriteLine("{0}, {1}, {2}, {3}", word[0], word[1], word[2], word[3]);
                    Person P = new Person(word[0], word[1], word[2], word[3]);
                    Dict.Add(P);
                }
            }
            Console.WriteLine("klart!");

            Console.WriteLine("Hej och välkommen till adresslistan");
            Console.WriteLine("Skriv 'sluta' för att sluta!");
            string command;
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "sluta")
                {
                    Console.WriteLine("Hej då!");
                }
                else if (command == "ny")
                {
                    Console.WriteLine("Lägger till ny person");
                    Console.Write("  1. ange namn:    ");
                    string name = Console.ReadLine();
                    Console.Write("  2. ange adress:  ");
                    string adress = Console.ReadLine();
                    Console.Write("  3. ange telefon: ");
                    string telephone = Console.ReadLine();
                    Console.Write("  4. ange email:   ");
                    string email = Console.ReadLine();
                    Dict.Add(new Person(name, adress, telephone, email));
                }
                else if (command == "ta bort")
                {
                    Console.Write("Vem vill du ta bort (ange namn): ");
                    string wantToRemove = Console.ReadLine();
                    int found = -1;
                    for (int i = 0; i < Dict.Count(); i++)
                    {
                        if (Dict[i].namn == wantToRemove) found = i;
                    }
                    if (found == -1)
                    {
                        Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", wantToRemove);
                    }
                    else
                    {
                        Dict.RemoveAt(found);
                    }
                }
                else if (command == "visa")
                {
                    for (int i = 0; i < Dict.Count(); i++)
                    {
                        Person P = Dict[i];
                        Console.WriteLine("{0}, {1}, {2}, {3}", P.namn, P.adress, P.telephone, P.email);
                    }
                }
                else if (command == "ändra")
                {
                    Console.Write("Vem vill du ändra (ange namn): ");
                    string wantToChange = Console.ReadLine();
                    int found = -1;
                    for (int i = 0; i < Dict.Count(); i++)
                    {
                        if (Dict[i].namn == wantToChange) found = i;
                    }
                    if (found == -1)
                    {
                        Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", wantToChange);
                    }
                    else
                    {
                        Console.Write("Vad vill du ändra (namn, adress, telefon eller email): ");
                        string fieldToChange = Console.ReadLine();
                        Console.Write("Vad vill du ändra {0} på {1} till: ", fieldToChange, wantToChange);
                        string newValue = Console.ReadLine();
                        switch (fieldToChange)
                        {
                            case "namn": Dict[found].namn = newValue; break;
                            case "adress": Dict[found].adress = newValue; break;
                            case "telefon": Dict[found].telephone = newValue; break;
                            case "email": Dict[found].email = newValue; break;
                            default: break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Okänt kommando: {0}", command);
                }
            } while (command != "sluta");
        }
    }
}
