using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDY.TextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
                
            int backToStart = 0;
            string file = "";
            string text = "";

            Console.WriteLine("Wellcome to the TextEditor! \n");

            while (backToStart != 5)
            {
                int selected = Menu();
                
                switch (selected) 
                {
                    case 1:
                        Console.Clear();

                        Console.Write("Inform the file name: ");
                        file = Console.ReadLine();
                        AlredyExist(file);
                        
                        break;

                    case 2:
                        ShowAText(file);
                        
                        break; 

                    case 3:
                        Console.Write("Inform the text: ");
                        text = Console.ReadLine();

                        WriteInTheFile(file, text, false);

                        break;

                    case 4:
                        Console.Write("Inform the text: ");
                        text = Console.ReadLine();

                        WriteInTheFile(file, text, true);
                        break;

                    case 5:
                        backToStart = 5;
                        break;
                }
                
            } 
        }
        static int Menu()
        {
            Console.Clear();

            int selected = 0;

            Console.WriteLine("Select one of the options below!\n");

            Console.WriteLine("1 - Open/Create an file.");
            Console.WriteLine("2 - Show the file text.");
            Console.WriteLine("3 - Replace the exist text in the file.");
            Console.WriteLine("4 - Add a new line in the text.");
            Console.WriteLine("5 - Exit. \n");

            Console.Write("Select: ");
            selected = Convert.ToInt32(Console.ReadLine());
            return selected;
        }

        static void AlredyExist(string file)
        {
            if (!File.Exists(file))
            {
                try
                {
                    File.Create(file).Close(); // Cria o arquivo se não existir
                    Console.WriteLine($"File '{file}' created successfully.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error creating file: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine($"File '{file}' already exists.");
            }
        }
        static void ShowAText(string file)
        {
            try
            {
                string line = "";
                StreamReader sr = new StreamReader(file);
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + "File empty or don't exist!");
            }
            Console.ReadKey();
        }

        static void WriteInTheFile(string file, string text, bool incrementar)
        {
            try
            {
                StreamWriter sr = new StreamWriter(file, incrementar);
                sr.WriteLine(text);
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            
        }

    }
}
