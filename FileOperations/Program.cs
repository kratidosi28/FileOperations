using System;
using System.IO;

namespace FileOperations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("1. Create File which include text of your choice!!");
            Console.WriteLine("2. Copy File Content into Another File!!");
            Console.WriteLine("3. Rename a File!!");
            Console.WriteLine("4. Append the content of the files!!");
            Console.WriteLine("5. Delete a File!!");
            Console.WriteLine("6. View Content of the file!!");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    createFile();
                    break;

                case 2:
                    copyFile();
                    break;

                case 3:
                    renameFile();
                    break;

                case 4:
                    appendFileContent();
                    break;

                case 5:
                    deleteFile();
                    break;

                case 6:
                    viewContentFile();
                    break;

            }
        }

        public static void createFile()
        {
            Console.WriteLine("Enter a FileName with .txt Extension");
            string fileName = Console.ReadLine();

            string path = @"F:\Files\";
            string createFile = path + fileName;
            if (!File.Exists(createFile))
            {

                using (StreamWriter sw = File.CreateText(createFile))
                {
                    Console.WriteLine("Enter the text which you want to write in file!!");
                    string text = Console.ReadLine();
                    sw.Write(text);
                    sw.Close();
                    Console.WriteLine("Successfully created file along with the text!!");
                }
            }
            else
            {
                Console.WriteLine("File with the same name is exist");
            }

            // Open the file to read from.
            /*    using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }*/
        }

        public static void copyFile()
        {
            Console.WriteLine("Create a File to Copy Content of another File!!");
            string fileName = Console.ReadLine();

            string path = @"F:\Files\";
            string createFile = path + fileName;
            if (!File.Exists(createFile))
            {
                Console.WriteLine("Enter a FileName which Content do you want to copy!!");
                string reader = Console.ReadLine();
                string existFile = path + reader;
                if (File.Exists(existFile))
                {
                    string data;

                    data = File.ReadAllText(existFile);
                    Console.WriteLine("Content of previous File is :\n" + data);

                    File.Copy(existFile, createFile);

                    data = File.ReadAllText(createFile);
                    Console.WriteLine("Content of File in which you copied is :\n" + data);


                }
                else
                {
                    Console.WriteLine("you enter invalid filename which content do you want to copy in new file!!");
                }
            }
        }


        public static void renameFile()
        {
            Console.WriteLine("Enter a FileName do you want to rename!!");
            string fileName = Console.ReadLine();

            string path = @"F:\Files\";
            string existFile = path + fileName;
            if (File.Exists(existFile))
            {
                Console.WriteLine("Enter a FileName which you want to give!!");
                string reader = Console.ReadLine();
                string renameFile = path + reader;
                if (!File.Exists(renameFile))
                {
                    File.Move(existFile, renameFile);
                    Console.WriteLine("FileName is successfully Renamed!!");


                }
                else
                {
                    Console.WriteLine("you enter invalid filename which you want to rename!!");
                }
            }
        }

        public static void appendFileContent()
        {
            Console.WriteLine("Enter a First FileName !!");
            string fileName = Console.ReadLine();

            string path = @"F:\Files\";
            string firstFile = path + fileName;
            if (File.Exists(firstFile))
            {
                Console.WriteLine("Enter a Second FileName !!");
                string secondFile = Console.ReadLine();
                string appendFile = path + secondFile;
                if (File.Exists(appendFile))
                {
                    using (Stream input = File.OpenRead(firstFile))
                    using (Stream output = new FileStream(appendFile, FileMode.Append))
                    {
                        input.CopyTo(output); // Using .NET 4
                    }


                    Console.WriteLine("File Operation is done!!");


                }
                else
                {
                    Console.WriteLine("you enter invalid filename!!");
                }
            }
        }


        public static void deleteFile()
        {
            Console.WriteLine("Enter a FileName which you want to delete!!");
            string fileName = Console.ReadLine();

            string path = @"F:\Files\";
            string existFile = path + fileName;
            if (File.Exists(existFile))
            {

                File.Delete(existFile);

                Console.WriteLine("File is deleted!!");


                }
                else
                {
                    Console.WriteLine("you enter invalid filename which you want to delete!!");
                }
            }

        public static void viewContentFile()
        {
            Console.WriteLine("Enter a FileName which content do you want to see!!");
            string fileName = Console.ReadLine();

            string path = @"F:\Files\";
            string existFile = path + fileName;
            if (File.Exists(existFile))
            {
                StreamReader sr = new StreamReader(existFile);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("you enter invalid filename");
            }
        }
    }
    }

    


