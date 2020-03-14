using System;
using System.IO;
using System.Collections;


namespace cw2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(args[0]);
            Console.WriteLine(args[1]);
            Console.WriteLine(args[2]);

            Console.WriteLine(args[0]);
            if (args.Length == 2)
            {
                args[2] = "xml";
            }
            else if (args.Length == 1)
            {

                args[2] = "xml";
                args[1] = "zezult.xml";
            }
            else if (args.Length == 0) 
            {
                args[2] = "xml";
                args[1] = "zazult.xml";
                args[0] = "dane.csv";
            }


            try
            {
                Path.GetFullPath(args[1]);
            }
            catch (ArgumentException e)
            {
                File.AppendAllText(@"C:\Users\s18916\Desktop\log.txt", "\nPodana sciezka jest niepoprawna " + DateTime.Now);
                Console.WriteLine("Podana sciezka jest niepoprawna");
                return;
            }
            try
            {
              // if (!File.Exists(args[0]))
                  //throw new FileNotFoundException("Plik nazwa nie istnieje");
            }
            catch (FileNotFoundException e)
            {
                File.AppendAllText(@"C:\Users\s18916\Desktop\log.txt", "\n" + e.Message + " " + DateTime.Now);
                Console.WriteLine(e.Message);
                return;
            }
                
                var lines = File.ReadLines(args[0]);

                System.Text.StringBuilder builder = new System.Text.StringBuilder("<uczelnia createdAt =");
                builder.Append(String.Format("\'", DateTime.Today));
                builder.Append("\" author=\"Alia Molodets\" <studenci>");

                ArrayList students = new ArrayList();
                foreach (var line in lines)
                {
                    //Console.WriteLine(line);
                    System.Text.StringBuilder student = new System.Text.StringBuilder("<uczelnia createdAt = ");
                    //student.Append();
                    String[] word = line.Split(",");
                    if (word.Length < 8)
                    {
                    File.AppendAllText(@"Rekord ma mniej niz 8 slow", "\n" + " " + DateTime.Now);
                    continue;
                    }
                    bool isOk = true;
                for (int i = 0; i < 9; i++)
                {
                    if (word[i] == " " || word[i] == null)


                    {
                        File.AppendAllText(@"Rekord ma pustu wartosc", "\n" + " " + DateTime.Now);
                        isOk = false;
                        break;
                    }

                }
                if (isOk)
                {
                    student.Append("<student indexNumber=\"" + word[4] + "\"> \n" +
                    "<fname>" + word[0] + "</fname>\n" +
                    "<lname>" + word[1] + "</lname>\n" +
                    "<birthdate>" + word[5] + "</birthdate>\n" +
                    "<email>" + word[6] + "</email>\n" +
                    "<mothersName>" + word[7] + "</mothersName>\n" +
                    "<fathersName>" + word[8] + "</fathersName>\n" +
                    "<studies>\n" +
                    "<name>" + word[2] + "</name>\n" +
                    "<mode>" + word[3] + "</mode >\n" +
                    "</studies>\n" +
                    "</student>\n");
                    builder.Append(student);
                    student.Clear();
                }


            }
            builder.Append("</studenci>");
            Console.WriteLine(builder);
        }

            
            }

        }
    

