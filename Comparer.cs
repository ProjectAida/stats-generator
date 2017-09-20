using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static StatsGenerator.ConstInfo;
using static StatsGenerator.ErrorInfo;

namespace StatsGenerator
{
    class Comparer
    {
        public static ErrorMsg Compare(StreamReader classifierTrue,
                            StreamReader classifierFalse,
                            StreamReader groundTrue,
                            StreamReader groundFalse,
                            Genre outputGenre,
                            string storagePath)
        {
            bool isPages = outputGenre == Genre.pages;

            Dictionary<string, byte> classifierTrueList = new Dictionary<string, byte>();
            Dictionary<string, byte> groundTrueList = new Dictionary<string, byte>();
            Dictionary<string, byte> groundFalseList = new Dictionary<string, byte>();

            while (!classifierTrue.EndOfStream)
            {
                var line = classifierTrue.ReadLine();
                if (line != "")
                {
                    classifierTrueList.Add(line, 1);
                }
            }

            while (!groundTrue.EndOfStream)
            {
                var line = groundTrue.ReadLine();
                if (line != "")
                {
                    groundTrueList.Add(line, 1);
                }
            }

            while (!groundFalse.EndOfStream)
            {
                var line = groundFalse.ReadLine();
                if(line != "")
                {
                    groundFalseList.Add(line, 1);
                }
            }

            string TPrslt = outputGenre.ToString() + "_TP.csv";
            FileStream TPfs = new FileStream(storagePath + TPrslt, FileMode.Create, FileAccess.Write);
            StreamWriter TPsw = new StreamWriter(TPfs, Encoding.UTF8);

            string FPrslt = outputGenre.ToString() + "_FP.csv";
            FileStream FPfs = new FileStream(storagePath + FPrslt, FileMode.Create, FileAccess.Write);
            StreamWriter FPsw = new StreamWriter(FPfs, Encoding.UTF8);

            string FNrslt = outputGenre.ToString() + "_FN.csv";
            FileStream FNfs = new FileStream(storagePath + FNrslt, FileMode.Create, FileAccess.Write);
            StreamWriter FNsw = new StreamWriter(FNfs, Encoding.UTF8);

            string TNrslt = outputGenre.ToString() + "_TN.csv";
            FileStream TNfs = new FileStream(storagePath + TNrslt, FileMode.Create, FileAccess.Write);
            StreamWriter TNsw = new StreamWriter(TNfs, Encoding.UTF8);

            string statRslt = outputGenre.ToString() + "_stat.csv";
            FileStream statfs = new FileStream(storagePath + statRslt, FileMode.Create, FileAccess.Write);
            StreamWriter statsw = new StreamWriter(statfs, Encoding.UTF8);

            string errorStat = "errorStat.csv";
            FileStream errorfs = new FileStream(storagePath + errorStat, FileMode.Append, FileAccess.Write);
            StreamWriter errsw = new StreamWriter(errorfs, Encoding.UTF8);

            TPsw.WriteLine("num,classifier true,ground truth true");
            FPsw.WriteLine("num,classifier true,ground truth false");
            FNsw.WriteLine("num,classifier false,ground truth true");
            TNsw.WriteLine("num,classifier false,ground truth false");
            statsw.WriteLine("num of TP,num of FP,num of FN,num of TN,precision,recall");

            long TPcount = 0;
            long FPcount = 0;
            long FNcount = 0;
            long TNcount = 0;
            
            foreach (var item in classifierTrueList)
            {
                int count = 0;
                if (isPages)
                {
                    string tmp = item.Key + "_true.jpg";
                    if (groundTrueList.ContainsKey(tmp))
                    {
                        TPcount++;
                        count++;
                        var line = StringFormator(TPcount, item.Key, tmp);
                        TPsw.WriteLine(line);
                    }
                    tmp = item.Key + "_false.jpg";
                    if (groundFalseList.ContainsKey(tmp))
                    {
                        FPcount++;
                        count++;
                        var line = StringFormator(FPcount, item.Key, tmp);
                        FPsw.WriteLine(line);
                    }
                }
                else
                {
                    if (groundTrueList.ContainsKey(item.Key))
                    {
                        TPcount++;
                        count++;
                        var line = StringFormator(TPcount, item.Key, item.Key);
                        TPsw.WriteLine(line);
                    }
                    if (groundFalseList.ContainsKey(item.Key))
                    {
                        FPcount++;
                        count++;
                        var line = StringFormator(FPcount, item.Key, item.Key);
                        FPsw.WriteLine(line);
                    }
                }
                if (count == 0)
                {
                    var errorLine = StringFormator(outputGenre.ToString(),
                                                    outputGenre == Genre.snippet ? "classifier-snippets-true.txt"
                                                                                : "classifier-pages-true.txt",
                                                    item.Key, ErrorMsg.item_not_found.ToString());
                    errsw.WriteLine(errorLine);
                    //return ErrorMsg.item_not_found;
                }
                if (count > 1)
                {
                    var errorLine = StringFormator(outputGenre.ToString(),
                                                    outputGenre == Genre.snippet ? "classifier-snippets-true.txt"
                                                                                : "classifier-pages-true.txt",
                                                    item.Key, ErrorMsg.dup_item_groundT_groudF.ToString());
                    errsw.WriteLine(errorLine);
                    //return ErrorMsg.dup_item_groundT_groudF;
                }
            }

            classifierTrueList.Clear();
            Dictionary<string, byte> classifierFalseList = new Dictionary<string, byte>();

            while (!classifierFalse.EndOfStream)
            {
                var line = classifierFalse.ReadLine();
                if (line != "")
                {
                    classifierFalseList.Add(line, 1);
                }
            }

            foreach (var item in classifierFalseList)
            {
                int count = 0;
                if (isPages)
                {
                    string tmp = item.Key + "_true.jpg";
                    if (groundTrueList.ContainsKey(tmp))
                    {
                        FNcount++;
                        count++;
                        var line = StringFormator(FNcount, item.Key, tmp);
                        FNsw.WriteLine(line);
                    }
                    tmp = item.Key + "_false.jpg";
                    if (groundFalseList.ContainsKey(tmp))
                    {
                        TNcount++;
                        count++;
                        var line = StringFormator(TNcount, item.Key, tmp);
                        TNsw.WriteLine(line);
                    }
                }
                else
                {
                    if (groundTrueList.ContainsKey(item.Key))
                    {
                        FNcount++;
                        count++;
                        var line = StringFormator(FNcount, item.Key, item.Key);
                        FNsw.WriteLine(line);
                    }
                    if (groundFalseList.ContainsKey(item.Key))
                    {
                        TNcount++;
                        count++;
                        var line = StringFormator(TNcount, item.Key, item.Key);
                        TNsw.WriteLine(line);
                    }
                }
                if (count == 0)
                {
                    var errorLine = StringFormator(outputGenre.ToString(),
                                                    outputGenre == Genre.snippet ? "classifier-snippets-false.txt"
                                                                                : "classifier-pages-false.txt",
                                                    item.Key, ErrorMsg.item_not_found.ToString());
                    errsw.WriteLine(errorLine);
                    //return ErrorMsg.item_not_found;
                }
                if (count > 1)
                {
                    var errorLine = StringFormator(outputGenre.ToString(),
                                                    outputGenre == Genre.snippet ? "classifier-snippets-false.txt"
                                                                                : "classifier-pages-false.txt",
                                                    item.Key, ErrorMsg.dup_item_groundT_groudF.ToString());
                    errsw.WriteLine(errorLine);
                    //return ErrorMsg.dup_item_groundT_groudF;
                }
            }

            double precision = (double)TPcount / ((double)TPcount + (double)FPcount);
            double recall = (double)TPcount / ((double)TPcount + (double)FNcount);
            string statLine = StringFormator(TPcount, FPcount, FNcount, TNcount, precision, recall);
            statsw.WriteLine(statLine);

            TPsw.Close();
            TPfs.Close();
            FPsw.Close();
            FPfs.Close();
            FNsw.Close();
            FNfs.Close();
            TNsw.Close();
            TNfs.Close();
            statsw.Close();
            statfs.Close();
            errsw.Close();
            errorfs.Close();

            return ErrorMsg.success;
        }

        private static string StringFormator(params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args.Length; i++)
            {
                if(i == args.Length - 1)
                {
                    sb.Append(args[i]);
                }
                else
                {
                    sb.Append(args[i]).Append(",");
                }
            }
            return sb.ToString();
        }
    }
}
