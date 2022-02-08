using System;
using System.Collections.Generic;
using System.IO;

namespace Kaladont
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            List<string> lista = new List<string>();

            //Console.WriteLine("Second commit to develop branch");
            ////
            Console.WriteLine("Third commit to develop branch");
            //this will maybe produce some conflicts .. :(
            //Sad bi trebao za ovu liniju da bude ispred developa

            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            
            Console.WriteLine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName);

            

            Console.WriteLine(fajl);

            Console.WriteLine(File.Exists("C:\\Users\\Lenovo\\source\\repos\\Kaladont\\Kaladont\\TextFile1.txt"));

            Console.WriteLine(File.Exists("\\TextFile1.txt"));

            Console.WriteLine(Directory.GetDirectoryRoot(path));

            using (var sr = new StreamReader(fajl))
            {
                // Read the stream as a string, and write the string to the console.
                Console.WriteLine(sr.ReadToEnd());
            }
            */

            Stack<string> myStack = new Stack<string>();
            myStack.Push("first");
            myStack.Push("second");
            myStack.Push("third");

            Console.WriteLine(myStack.Contains("first"));
            Console.WriteLine(myStack.Contains("first1"));

            string fajl = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "TextFile1.txt");
            Dictionary<string, LinkedList<string>> graph = new Dictionary<string, LinkedList<string>>();

            string root = "######";

            //last two characters        Console.WriteLine(root.Substring(root.Length - 2));
            //first two characters       Console.WriteLine(root.Substring(0, 2));

            List<string> alreadyAdded = new List<string>();

            
            try
            {
                using (StreamReader sr = new StreamReader(fajl))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!line.EndsWith("ka"))
                        {
                            Graph.addEdge(graph, root, line);
                            Graph.addEdge(graph, line, root);

                            foreach (string s in alreadyAdded)
                            {
                                if (s.Substring(s.Length - 2).Equals(line.Substring(0, 2)))
                                {
                                    Graph.addEdge(graph, s, line);
                                }
                                if (line.Substring(line.Length - 2).Equals(s.Substring(0, 2)))
                                {
                                    Graph.addEdge(graph, line, s);
                                }
                            }

                            alreadyAdded.Add(line);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("ispis recnika:");

            foreach (var help in graph)
            {
                Console.Write(help.Key + " : ");
                foreach (string k in help.Value) {
                    Console.WriteLine(k);
                }
                Console.WriteLine();
            }



        }
    }
}
