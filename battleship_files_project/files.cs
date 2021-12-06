using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace files_project
{
    static public class files
    {
        public static void CpuMap()
        {
            string systemPath = Directory.GetCurrentDirectory();

            Random rnd = new Random();

            int[] valplaceholder = new int[17];
            int[] colplaceholder = new int[17];
            int row = rnd.Next(8); // Assigns text for the file
            int column = rnd.Next(8);
            int y = 0;
            int index, index2;
            int cor = 0;

            File.Delete(systemPath + "\\cpu_map.txt");  // reset file

            // Each of thes for statements will iterate through the piece size after returning a unique column and row value 

            cor = rnd.Next(2);  // randomly decide if the bot will increase it's placement via continuously up/down rows/columns

            for (int x = 0; x < 5; x++)
            {
                valplaceholder[x] = row;    // Index for each value collected to ensure column vals are unique
                colplaceholder[x] = column;

                if (cor == 0)  
                {
                    // These if statements switch the direction the ship will be made if it will exceed map size
                    if (colplaceholder[0] + 3 <= 7)
                    {   
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row).ToString() + ", " + (column + x).ToString() + "\n");
                    }
                    if (colplaceholder[0] + 3 > 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row).ToString() + ", " + (column - x).ToString() + "\n");
                    }
                }
                if (cor == 1)
                {
                    if (valplaceholder[0] + 3 <= 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row + x).ToString() + ", " + (column).ToString() + "\n");
                    }
                    if (valplaceholder[0] + 3 > 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row - x).ToString() + ", " + (column).ToString() + "\n");
                    }
                }

            }

            do
            {
                row = rnd.Next(8); // Assigns text for the file
                column = rnd.Next(8);
                index = Array.IndexOf(valplaceholder, row);
                index2 = Array.IndexOf(colplaceholder, column);
            } while (index > -1 && index2 > -1);

            y++;

            // Below creates random column values for ships and then 

            cor = rnd.Next(2);

            for (int x = 0; x < 4; x++)
            {
                valplaceholder[x + 5] = row;    // Index for each value collected to ensure column vals are unique
                colplaceholder[x + 5] = column;

                if (cor == 0)
                {
                    if (colplaceholder[5] + 3 <= 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row).ToString() + ", " + (column + x).ToString() + "\n");
                    }
                    if (colplaceholder[5] + 3 > 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row).ToString() + ", " + (column - x).ToString() + "\n");
                    }
                }
                if (cor == 1)
                {
                    if (valplaceholder[5] + 3 <= 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row + x).ToString() + ", " + (column).ToString() + "\n");
                    }
                    if (valplaceholder[5] + 3 > 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row - x).ToString() + ", " + (column).ToString() + "\n");
                    }
                }
            }

            do
            {
                row = rnd.Next(8); // Assigns text for the file
                column = rnd.Next(8);
                index = Array.IndexOf(valplaceholder, row);
                index2 = Array.IndexOf(colplaceholder, column);
            } while (index > -1 && index2 > -1);

            y++;

            cor = rnd.Next(2);

            for (int x = 0; x < 3; x++)
            {
                valplaceholder[x + 9] = row;    // Index for each value collected to ensure column vals are unique
                colplaceholder[x +  9] = column;

                if (cor == 0)
                {
                    if (colplaceholder[9] + 3 <= 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row).ToString() + ", " + (column + x).ToString() + "\n");
                    }
                    if (colplaceholder[9] + 3 > 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row).ToString() + ", " + (column - x).ToString() + "\n");
                    }
                }
                if (cor == 1)
                {
                    if (valplaceholder[9] + 3 <= 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row + x).ToString() + ", " + (column).ToString() + "\n");
                    }
                    if (valplaceholder[9] + 3 > 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row - x).ToString() + ", " + (column).ToString() + "\n");
                    }
                }
            }

            do
            {
                row = rnd.Next(8); // Assigns text for the file
                column = rnd.Next(8);
                index = Array.IndexOf(valplaceholder, row);
                index2 = Array.IndexOf(colplaceholder, column);
            } while (index > -1 && index2 > -1);

            y++;

            cor = rnd.Next(2);

            for (int x = 0; x < 3; x++)
            {
                valplaceholder[x + 12] = row;    // Index for each value collected to ensure column vals are unique
                colplaceholder[x + 12] = column;

                if (cor == 0)
                {
                    if (colplaceholder[12] + 3 <= 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row).ToString() + ", " + (column + x).ToString() + "\n");
                    }
                    if (colplaceholder[12] + 3 > 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row).ToString() + ", " + (column - x).ToString() + "\n");
                    }
                }
                if (cor == 1)
                {
                    if (valplaceholder[12] + 3 <= 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row + x).ToString() + ", " + (column).ToString() + "\n");
                    }
                    if (valplaceholder[12] + 3 > 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row - x).ToString() + ", " + (column).ToString() + "\n");
                    }
                }
            }

            do
            {
                row = rnd.Next(8); // Assigns text for the file
                column = rnd.Next(8);
                index = Array.IndexOf(valplaceholder, row);
                index2 = Array.IndexOf(colplaceholder, column);
            } while (index > -1 && index2 > -1);

            y++;

            cor = rnd.Next(2);

            for (int x = 0; x < 2; x++)
            {
                valplaceholder[x + 15] = row;    // Index for each value collected to ensure column vals are unique
                colplaceholder[x + 15] = column;

                if (cor == 0)
                {
                    if (colplaceholder[15] + 3 <= 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row).ToString() + ", " + (column + x).ToString() + "\n");
                    }
                    if (colplaceholder[15] + 3 > 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row).ToString() + ", " + (column - x).ToString() + "\n");
                    }
                }
                if (cor == 1)
                {
                    if (valplaceholder[15] + 3 <= 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row + x).ToString() + ", " + (column).ToString() + "\n");
                    }
                    if (valplaceholder[15] + 3 > 7)
                    {
                        File.AppendAllText(systemPath + "\\cpu_map.txt", (row - x).ToString() + ", " + (column).ToString() + "\n");
                    }
                }
            }

            do
            {
                row = rnd.Next(8); // Assigns text for the file
                column = rnd.Next(8);
                index = Array.IndexOf(valplaceholder, row);
                index2 = Array.IndexOf(colplaceholder, column);
            } while (index > -1 && index2 > -1);

            y++;
        }

        static public bool CheckHit(int attackrow, int attackcol)
        {
            bool isHit = false;
            string systemPath = Directory.GetCurrentDirectory();
            string line;
        
            StreamReader file = new StreamReader(systemPath + "\\cpu_map.txt");
            
            // check each individual line and return true if one line matches selection
            while ((line = file.ReadLine()) != null)
            {
                if (line == attackrow + ", " + attackcol){
                    isHit = true;
                }
                System.Console.WriteLine(line); // debug
            }

           //  Console.WriteLine(isHit); // debug

            file.Close();

            return isHit;
        }
    }
}






