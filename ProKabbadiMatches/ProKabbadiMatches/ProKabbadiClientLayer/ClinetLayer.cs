using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProKabbadiBusinessLayer;
using ProKabbadiExceptionLayer;
using ProKabbadiEntityLayer;

namespace ProKabbadiClientLayer
{
    class ClinetLayer
    {
      public static BusinessLayer businessLayer = new BusinessLayer();
      static List<Matches> matcheslist = new List<Matches>();
     
            static void Main(string[] args)
            {
                int flag = 1;
                try
                {
                    while (flag == 1)
                    {
                        Console.WriteLine("============welcome to ProKabbadi================");
                        Console.WriteLine("press 1 to Add match Details");
                        Console.WriteLine("press 2 Display all the matches played by given team");
                        Console.WriteLine("press 3 Display all the data to text file");
                        Console.WriteLine("press 4 display all the matches to excel");
                        Console.WriteLine("press 5 to exit");
                        Console.WriteLine("=====================================");
                        Console.WriteLine("enter the choice from menu");
                        int ch = int.Parse(Console.ReadLine());
                        switch (ch)
                        {
                            case 1:
                            Console.WriteLine("display the data");
                            foreach (Teams teams in businessLayer.DisplayTeams())
                            {
                                Console.Write(teams.Team_Id + " ");
                                Console.Write(teams.Team_Name + " ");
                                Console.Write(teams.Team_City + " ");
                                Console.WriteLine();



                            }
                                addData();
                                break;

                            case 2:
                                displayMatches();
                                break;

                            case 3:

                                exportTextData();
                                break;
                            case 4:

                                exportExcelData();
                                break;
                            case 5:
                                flag = 0;
                                break;

                            default:
                                Console.WriteLine("***************enter from menu only***********");
                                break;

                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("integer values only");
                }
                catch (InvalidDetails e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadKey();

            }

        private static void exportExcelData()
        {
            throw new NotImplementedException();
        }

        private static void exportTextData()
        {
            throw new NotImplementedException();
        }

        private static void displayMatches()
        {
            throw new NotImplementedException();
        }

        public static void addData()
        {
            try
            {
                Console.Write("enter no. of data you want to enter : ");
                int n = int.Parse(Console.ReadLine());
                if (n < 1)
                {
                    throw new Exception();
                }
                for (int i = 0; i < n; i++)
                {
                    Matches matches = new Matches();
                    Console.Write("enter the Match Date : ");
                    string t = Console.ReadLine();
                    matches.Match_Date = t;

                    Console.Write("enter the First Team id: ");
                    int id1 = Convert.ToInt32(Console.ReadLine());
                    matches.First_Team_Id = new Teams();
                    matches.First_Team_Id.Team_Id = id1;


                    Console.Write("enter the Second Team id: ");
                    int id2 = Convert.ToInt32(Console.ReadLine());
                    matches.Second_Team_Id = new Teams();
                    matches.Second_Team_Id.Team_Id = id2;


                    Console.Write("enter the First Team score: ");
                    int p = int.Parse(Console.ReadLine());
                    matches.First_Team_Score = p;

                    Console.Write("enter the Second Team score: ");
                    int q = int.Parse(Console.ReadLine());
                    matches.Second_Team_Score = q;
                    matcheslist.Add(matches);
                }
                businessLayer.addTeams(matcheslist);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
    }

