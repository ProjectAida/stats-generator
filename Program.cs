using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static StatsGenerator.ConstInfo;
using static StatsGenerator.ErrorInfo;

namespace StatsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 2)
            {
                string filePath = "";
                string storagePath = "";

                if (args[0][args[0].Length - 1] != '/')
                {
                    filePath = args[0] + '/';
                }
                else
                {
                    filePath = args[0];
                }
                
                if (args[1][args[1].Length - 1] != '/')
                {
                    storagePath = args[1] + '/';
                }
                else
                {
                    storagePath = args[1];
                }

                StreamReader classifierTrue = null;
                StreamReader classifierFalse = null;
                StreamReader groundTrue = null;
                StreamReader groundFalse = null;

                string errorStat = "errorStat.csv";
                FileStream errorfs = new FileStream(storagePath + errorStat, FileMode.Create, FileAccess.Write);
                StreamWriter errsw = new StreamWriter(errorfs, Encoding.UTF8);
                errsw.WriteLine("Type,File Name,Name,Error Info");
                errsw.Close();
                errorfs.Close();

                Console.WriteLine("Start to calculate statistical data for snippets.");
                Genre genre = Genre.snippet;
                try
                {
                    classifierTrue = new StreamReader(File.OpenRead(filePath + "classifier-snippets-true.txt"));
                    classifierFalse = new StreamReader(File.OpenRead(filePath + "classifier-snippets-false.txt"));
                    groundTrue = new StreamReader(File.OpenRead(filePath + "ground-truth-snippets-true.txt"));
                    groundFalse = new StreamReader(File.OpenRead(filePath + "ground-truth-snippets-false.txt"));
                    ErrorMsg rslt =
                        Comparer.Compare(classifierTrue, classifierFalse, groundTrue, groundFalse, genre, storagePath);
                    if (rslt == ErrorMsg.success)
                    {
                        Console.WriteLine("Success.");
                    }
                    else
                    {
                        Console.Write("Something went wrong when calculating statistical data for snippets. ");
                        Console.WriteLine("Error Message: ");
                        Console.WriteLine(rslt.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Something went wrong when calculating statistical data for snippets. ");
                    Console.WriteLine("Error Message: ");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("In current new solution, the files names for comparison is fixed.");
                    Console.WriteLine("Please make sure the file names are: ");
                    Console.WriteLine("\tclassifier-snippets-true.txt");
                    Console.WriteLine("\tclassifier-snippets-false.txt");
                    Console.WriteLine("\tground-truth-snippets-true.txt");
                    Console.WriteLine("\tground-truth-snippets-false.txt");
                }

                classifierTrue.Close();
                classifierFalse.Close();
                groundTrue.Close();
                groundFalse.Close();
                classifierTrue = null;
                classifierFalse = null;
                groundTrue = null;
                groundFalse = null;

                Console.WriteLine("Start to calculate statistical data for pages.");
                genre = Genre.pages;
                try
                {
                    classifierTrue = new StreamReader(File.OpenRead(filePath + "classifier-pages-true.txt"));
                    classifierFalse = new StreamReader(File.OpenRead(filePath + "classifier-pages-false.txt"));
                    groundTrue = new StreamReader(File.OpenRead(filePath + "ground-truth-pages-true.txt"));
                    groundFalse = new StreamReader(File.OpenRead(filePath + "ground-truth-pages-false.txt"));
                    ErrorMsg rslt =
                        Comparer.Compare(classifierTrue, classifierFalse, groundTrue, groundFalse, genre, storagePath);
                    if (rslt == ErrorMsg.success)
                    {
                        Console.WriteLine("Success.");
                    }
                    else
                    {
                        Console.Write("Something went wrong when calculating statistical data for pages. ");
                        Console.WriteLine("Error Message: ");
                        Console.WriteLine(rslt.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Something went wrong when calculating statistical data for pages. ");
                    Console.WriteLine("Error Message: ");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("In current new solution, the files names for comparison is fixed.");
                    Console.WriteLine("Please make sure the file names are: ");
                    Console.WriteLine("\tclassifier-pages-true.txt");
                    Console.WriteLine("\tclassifier-pages-false.txt");
                    Console.WriteLine("\tground-truth-pages-true.txt");
                    Console.WriteLine("\tground-truth-pages-false.txt");
                }
            }
            //temp solution
            else if (args.Length == 4)
            {
                string groudFilePath = "";
                string filePath = "";
                string storagePath = "";
                
                if (args[0][args[0].Length - 1] != '/')
                {
                    groudFilePath = args[0] + '/';
                }
                else
                {
                    groudFilePath = args[0];
                }

                if (args[1][args[1].Length - 1] != '/')
                {
                    filePath = args[1] + '/';
                }
                else
                {
                    filePath = args[1];
                }

                if (args[2][args[2].Length - 1] != '/')
                {
                    storagePath = args[2] + '/';
                }
                else
                {
                    storagePath = args[2];
                }
                
                StreamReader classifierTrue = null;
                StreamReader classifierFalse = null;
                StreamReader groundTrue = null;
                StreamReader groundFalse = null;

                string errorStat = "errorStat.csv";
                FileStream errorfs = new FileStream(storagePath + errorStat, FileMode.Create, FileAccess.Write);
                StreamWriter errsw = new StreamWriter(errorfs, Encoding.UTF8);
                errsw.WriteLine("Type,File Name,Name,Error Info");
                errsw.Close();
                errorfs.Close();

                Console.WriteLine("Start to calculate statistical data for snippets.");
                Genre genre = Genre.snippet;
                try
                {
                    classifierTrue = new StreamReader(File.OpenRead(filePath + "TrueSnippets.txt"));
                    classifierFalse = new StreamReader(File.OpenRead(filePath + "FalseSnippets.txt"));
                    groundTrue = new StreamReader(File.OpenRead(groudFilePath + "ground-truth-snippets-true.txt"));
                    groundFalse = new StreamReader(File.OpenRead(groudFilePath + "ground-truth-snippets-false.txt"));
                    ErrorMsg rslt =
                        Comparer.Compare(classifierTrue, classifierFalse, groundTrue, groundFalse, genre, storagePath);
                    if (rslt == ErrorMsg.success)
                    {
                        Console.WriteLine("Success.");
                    }
                    else
                    {
                        Console.Write("Something went wrong when calculating statistical data for snippets. ");
                        Console.WriteLine("Error Message: ");
                        Console.WriteLine(rslt.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Something went wrong when calculating statistical data for snippets. ");
                    Console.WriteLine("Error Message: ");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("In current new solution, the files names for comparison is fixed.");
                    Console.WriteLine("Please make sure the file names are: ");
                    Console.WriteLine("\tclassifier-snippets-true.txt");
                    Console.WriteLine("\tclassifier-snippets-false.txt");
                    Console.WriteLine("\tground-truth-snippets-true.txt");
                    Console.WriteLine("\tground-truth-snippets-false.txt");
                }

                classifierTrue.Close();
                classifierFalse.Close();
                groundTrue.Close();
                groundFalse.Close();
                classifierTrue = null;
                classifierFalse = null;
                groundTrue = null;
                groundFalse = null;

                Console.WriteLine("Start to calculate statistical data for pages.");
                genre = Genre.pages;
                try
                {
                    classifierTrue = new StreamReader(File.OpenRead(filePath + "TruePages.txt"));
                    classifierFalse = new StreamReader(File.OpenRead(filePath + "FalsePages.txt"));
                    groundTrue = new StreamReader(File.OpenRead(groudFilePath + "ground-truth-pages-true.txt"));
                    groundFalse = new StreamReader(File.OpenRead(groudFilePath + "ground-truth-pages-false.txt"));
                    ErrorMsg rslt =
                        Comparer.Compare(classifierTrue, classifierFalse, groundTrue, groundFalse, genre, storagePath);
                    if (rslt == ErrorMsg.success)
                    {
                        Console.WriteLine("Success.");
                    }
                    else
                    {
                        Console.Write("Something went wrong when calculating statistical data for pages. ");
                        Console.WriteLine("Error Message: ");
                        Console.WriteLine(rslt.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Something went wrong when calculating statistical data for pages. ");
                    Console.WriteLine("Error Message: ");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("In current new solution, the files names for comparison is fixed.");
                    Console.WriteLine("Please make sure the file names are: ");
                    Console.WriteLine("\tclassifier-pages-true.txt");
                    Console.WriteLine("\tclassifier-pages-false.txt");
                    Console.WriteLine("\tground-truth-pages-true.txt");
                    Console.WriteLine("\tground-truth-pages-false.txt");
                }
            }

            else if (args.Length == 3)
            {
                if (args[2][args[2].Length - 1] != '/')
                {
                    args[2] = args[2] + '/';
                }
                args[2] = args[2] + "comparison result.csv";
                FileStream fs = new FileStream(args[2], System.IO.FileMode.Create, System.IO.FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);

                var reader = new StreamReader(File.OpenRead(args[0]));
                LinkedList<string> fileA = new LinkedList<string>();
                var reader2 = new StreamReader(File.OpenRead(args[1]));
                LinkedList<string> fileB = new LinkedList<string>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    fileA.AddLast(line);
                }

                while (!reader2.EndOfStream)
                {
                    var line = reader2.ReadLine();
                    fileB.AddLast(line);
                }

                sw.WriteLine("classifier,ground truth");

                LinkedListNode<string> testingNode = fileA.First;
                while (testingNode != null)
                {
                    bool flag = false;
                    LinkedListNode<string> searchingNode = fileB.First;
                    while (searchingNode != null)
                    {
                        if (testingNode.Value == searchingNode.Value)
                        {
                            fileB.Remove(searchingNode);
                            flag = true;
                            break;
                        }
                        searchingNode = searchingNode.Next;
                    }
                    if (flag)
                    {
                        sw.WriteLine(testingNode.Value + "," + searchingNode.Value + ",1");
                        LinkedListNode<string> tmp = testingNode.Next;
                        fileA.Remove(testingNode);
                        testingNode = tmp;
                    }
                    else
                    {
                        testingNode = testingNode.Next;
                    }

                }
                testingNode = fileB.First;
                while (testingNode != null)
                {
                    bool flag = false;
                    LinkedListNode<string> searchingNode = fileA.First;
                    while (searchingNode != null)
                    {
                        if (testingNode.Value == searchingNode.Value)
                        {
                            fileA.Remove(searchingNode);
                            flag = true;
                            break;
                        }
                        searchingNode = searchingNode.Next;
                    }
                    if (flag)
                    {
                        sw.WriteLine(searchingNode.Value + "," + testingNode.Value + ",1");
                        LinkedListNode<string> tmp = testingNode.Next;
                        fileA.Remove(testingNode);
                        testingNode = tmp;
                    }
                    else
                    {
                        testingNode = testingNode.Next;
                    }
                }
                if (fileA.Count > 0)
                {
                    testingNode = fileA.First;
                    while (testingNode != null)
                    {
                        sw.WriteLine(testingNode.Value + ",,0");
                        testingNode = testingNode.Next;
                    }
                }
                if (fileB.Count > 0)
                {
                    testingNode = fileB.First;
                    while (testingNode != null)
                    {
                        sw.WriteLine("," + testingNode.Value);
                        testingNode = testingNode.Next;
                    }
                }
                sw.Close();
                fs.Close();

                return;
            }
            else{
                Console.WriteLine();
                Console.WriteLine("New solution: ");
                Console.WriteLine("Command formation: 1836_1840CaseStudy.exe [Directory] [Directory]");
                Console.WriteLine("Two path strings are needed. \n\t1st is result files location, \n\t2nd is storage path for comparison!");
                Console.WriteLine();
                Console.WriteLine("Old solution: ");
                Console.WriteLine("Command formation: 1836_1840CaseStudy.exe [File] [File] [Directory]");
                Console.WriteLine("Two file names and its path, and one storage path needed for comparison!");
                Console.Write("\nPress anykey to continue...");
                Console.ReadKey();
                return;
            }
        }
    }
}
