using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace files_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // set views + asthetics
            panel1.Hide();
            panel2.Show();
            attackview.Visible = false;
            panel2.BackgroundImage = Image.FromFile(systemPath + "\\backship.jpg");
            pictureBox1.Image = Image.FromFile(systemPath + "\\radar.gif");

            // generate enemy map on file
            files.CpuMap();
        }

        // variable initialization
        public int cpuTotalHits = 0;
        public int playerTotalHits = 0;
        bool gameStarts = false;
        public int row, column;
        public int maxchecks = 0;
        string systemPath = Directory.GetCurrentDirectory();
        public int checks = 0;
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        bool startSelection = false;


        public void button1_Click(object sender, EventArgs e)   // submit user map selection button
        {
            files.CpuMap();       // calls function for creating cpu selection
        }

        private void submitButton(object sender, EventArgs e)
        {
            gameStarts = true;
            var disabled = tableLayoutPanel1.Controls.OfType<CheckBox>().Count(d => d.Enabled == false);    // checks to see if points are disabled (i.e ships selected)

            if (disabled == 17) // all ships selected
            {
                var result = MessageBox.Show("Are you sure you are ready?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    playerSpawns();
                    button2.Visible = false;
                    attackview.Visible = true;
                    textBox2.Visible = false;
                    panel2.Hide();
                    panel1.Show();  // get rid of ship view and open attack module
                }
                if (result == DialogResult.No)
                {
                    Application.Restart();  // restart selection
                }
            }
            else
            {
                MessageBox.Show("You haven't completed your seleciton.");
                return;
            }
        }

        // checks where the user checked their spawn placements
        public void playerSpawns()
        {
            File.Delete(systemPath + "\\user_map.txt"); // resets file

            // iterate through controls in both enemny + attack panel
            // should probably use byte[] to allocate file space and utf encode but this will work for this project
            foreach (Control c in this.tableLayoutPanel1.Controls) 
            {   
                if (c is CheckBox && ((CheckBox)c).Checked == true)
                {
                    row = tableLayoutPanel1.GetRow(c);
                    column = tableLayoutPanel1.GetColumn(c);

                    File.AppendAllText(systemPath + "\\user_map.txt", (row + ", " + column + "\n").ToString());       // all future values will be stored in this format, IMPORTANT     
               }
                           
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        { }

        // This will ensure only 17 boxes will can be checked. This is just to make sure the max ships are always 17 spots, being in a row will be solved later
        private void checkBoxRules(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            // Console.WriteLine(tableLayoutPanel1.GetRow(cb) + " + " + tableLayoutPanel1.GetColumn(cb)); // debug purposes

            /*
             *  In order for these to make sense auto checked must be turned off since I'm switching user input over to programmatic control
             */
        
            if (checks == maxchecks && cb.Checked == false)            // if the max amount of ships have been selected
            {
                cb.Checked = false;     //      don't add more
            }
            if (checks <= maxchecks && cb.Checked == true)       // if the max haven't been & the user wants to remove a check
            {
                cb.Checked = false;             // remove their check
                checks--;               // remove amount of checks

                return;
            }
            if (checks < maxchecks && cb.Checked == false)             // Everything else (but this really refers to if max hasnt been checked & user wants to add a piece
            {
                    cb.Checked = true;      // check the position
                    checks++;               // increase amount of checks
                   // firstCheck = true;
                    row = tableLayoutPanel1.GetRow(cb);
                    column = tableLayoutPanel1.GetColumn(cb);
                    return;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        // Which ship the user is currently placing
        private void radioSelection(object sender, EventArgs e)
        {
            var placements = tableLayoutPanel1.Controls.OfType<CheckBox>().Count(d => d.Checked);   // (This will return the amount of total checkboxes checked)
            var disabled = tableLayoutPanel1.Controls.OfType<CheckBox>().Count(d => d.Enabled == false);    // This will return how many CheckBoxes are disabled (already selected ships)
            var total = placements - disabled;          // finds total remainder that aren't already disabled

            if (startSelection == true)     // If user has already started selecting a ship varient do:
            {
                foreach (Control c in this.tableLayoutPanel1.Controls)
                {
                   // Console.WriteLine(total); // debug purposes
                    if (c is CheckBox && ((CheckBox)c).Checked == true && total == maxchecks)   // If checkboxes are checked and equal the required ship size,
                    {
                        ((CheckBox)c).Enabled = false;                  // Disable the ship selections to confirm ship   
                       
                        if (maxchecks == 5)             // disables the ship, probably a better way to do this considering they can have the same maxchecks
                        {
                            ((RadioButton)carrierRadio).Enabled = false;
                        }
                        if (maxchecks == 4)
                        {
                            ((RadioButton)battleshipRadio).Enabled = false;
                        }
                        if (maxchecks == 3 && ((RadioButton)sender) != submarineRadio)
                        {
                            ((RadioButton)submarineRadio).Enabled = false;
                        }
                        if (maxchecks == 3 && ((RadioButton)sender) != cruiserRadio)
                        {
                            ((RadioButton)cruiserRadio).Enabled = false;
                        }
                        if (maxchecks == 2)
                        {
                            ((RadioButton)destroyerRadio).Enabled = false;
                        }
                    }
                    if (total < maxchecks && gameStarts != true)        // validates the user having enough selected boxes per ship requirements
                    {
                        MessageBox.Show("Please select the required boat size/layout.");
                        ((RadioButton)sender).Checked = false;

                        if (maxchecks == 5)
                        {
                            ((RadioButton)carrierRadio).Checked = true;
                        }
                        if (maxchecks == 4)
                        {
                            ((RadioButton)battleshipRadio).Checked = true;
                        }
                        if (maxchecks == 3 && ((RadioButton)sender) != submarineRadio)
                        {
                            ((RadioButton)submarineRadio).Checked = true;
                        }
                        if (maxchecks == 3 && ((RadioButton)sender) != cruiserRadio)
                        {
                            ((RadioButton)cruiserRadio).Checked = true;
                        }
                        if (maxchecks == 2)
                        {
                            ((RadioButton)destroyerRadio).Checked = true;
                        }

                        break;
                    }
                    startSelection = false;
                }
            }
            if (startSelection == false)
            {
                if (carrierRadio.Checked == true)
                {
                    maxchecks = 5;
                    checks = 0;
                }
                if (battleshipRadio.Checked == true)
                {
                    maxchecks = 4;
                    checks = 0;
                }
                if (cruiserRadio.Checked == true)
                {
                    maxchecks = 3;
                    checks = 0;
                }
                if (submarineRadio.Checked == true)
                {
                    maxchecks = 3;
                    checks = 0;
                }
                if (destroyerRadio.Checked == true)
                {
                    maxchecks = 2;
                    checks = 0;
                }
                startSelection = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
        }

        private void attack_button(object sender, EventArgs e)
        {
            // apply the selected box to the attack field and validate hit or miss, then disable checkbox

            int attackrow = 0;
            int attackcol = 0;

            foreach (Control c in this.tableLayoutPanel2.Controls)
            {
                if (c is CheckBox && ((CheckBox)c).Checked == true && ((CheckBox)c).Enabled == true)
                {
                    attackrow = tableLayoutPanel2.GetRow((CheckBox)c);
                    attackcol = tableLayoutPanel2.GetColumn((CheckBox)c);

                    textBox3.Text = (attackrow + 1).ToString();
                    textBox1.Text = (attackcol + 1).ToString(); // + 1 accounts for the translation from a 0 based index

                    break;
                }
            }
            bool isHit = files.CheckHit(attackrow, attackcol);

             // Console.WriteLine(attackrow.ToString() + ", " + attackcol.ToString()); // debug
            //  Console.WriteLine(isHit);       // debug

            if (isHit == false)
            {
                // Below sees if its a hit or not
                textBox20.Visible = true;
                textBox20.Text = "Missed!";
                textBox20.ForeColor = Color.FromArgb(255, 0, 0);
                textBox20.BackColor = Color.Black;

                foreach (Control c in this.tableLayoutPanel2.Controls)
                {
                    if (c is CheckBox && ((CheckBox)c).Checked == true)
                    {
                        ((CheckBox)c).Enabled = false;

                        // I want to set this to a specific color but it tends to overide hit color
                        // maybe come back later for this

                    }
                }
            }
            if (isHit == true)
            {
                // if the selection was a hit
                textBox20.Visible = true;
                textBox20.Text = "Hit!";
                textBox20.BackColor = Color.FromArgb(255, 0, 0);
                textBox20.ForeColor = Color.FromArgb(0, 0, 255);

                // explosion sound effect
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(systemPath + "\\explosion.wav");
                player.Play();

                // disable checkbox
                foreach (Control c in this.tableLayoutPanel2.Controls)
                {
                    if (c is CheckBox && ((CheckBox)c).Checked == true)
                    {
                        ((CheckBox)c).Enabled = false;

                        int rowSink = tableLayoutPanel1.GetRow((CheckBox)c);
                        int colSink = tableLayoutPanel1.GetColumn((CheckBox)c);

                        if (rowSink == attackrow && colSink == attackcol)
                        {
                            ((CheckBox)c).BackColor = Color.FromArgb(255, 0, 0);
                        }

                    }
                }
                playerTotalHits++;
                Console.WriteLine(playerTotalHits);
                if (playerTotalHits == 17)
                {
                    DialogResult r = MessageBox.Show("You Win! You sunk all the enemy ships! Replay?", "Game Win", MessageBoxButtons.YesNo);
                    if (r == DialogResult.No)
                    {
                        Application.Exit();
                    }
                    if (r == DialogResult.No)
                    {
                        Application.Restart();
                    }
                }
            }

            bool cpuHit = cpuAttack();

            if (cpuHit == true)
            {
                textBox21.Visible = true;
                textBox21.BackColor = Color.FromArgb(255, 0, 0);
                textBox21.Text = "Bot has hit your ship!";
                cpuTotalHits++;
                if(cpuTotalHits == 17)  // ends game if all ship plots are destroyed
                {
                    DialogResult r = MessageBox.Show("You lose! The Bot has suken all your ships! Try again?", "Game Over", MessageBoxButtons.YesNo);
                    if (r == DialogResult.No)
                    {
                        Application.Exit();
                    }
                    if (r == DialogResult.No)
                    {
                        Application.Restart();
                    }
                }
            }
            if (cpuHit == false)
            {
                textBox21.Visible = true;
                textBox21.BackColor = Color.FromArgb(0, 255, 0);
                textBox21.Text = "Bot has missed their shot!";
            }

        }

        private void attackbox(object sender, EventArgs e)
        {
            textBox21.Visible = false; // set bot attack window to hidden

            // This code essentially just makes sure only one attack checkbox is checked at a time
            int count = 0;
            CheckBox cb = (CheckBox)sender;

            foreach (Control c in this.tableLayoutPanel2.Controls)
            {
                if (c is CheckBox)
                {
                    if (((CheckBox)c).Checked == true && ((CheckBox)c).Enabled == true)
                    {
                        count++;
                    }
                }
            }

            if (count > 1)
            {
                cb.Checked = false;
            }

        }


        public void disableHomeShips(int attackRow, int attackColumn)
        {
            // disables ships if cpu gets a hit
            foreach (Control c in this.tableLayoutPanel1.Controls)
            {
                if (c is CheckBox && ((CheckBox)c).Enabled == false)
                {
                    int row = tableLayoutPanel1.GetRow((CheckBox)c);
                    int col = tableLayoutPanel1.GetColumn((CheckBox)c);

                    if (row == attackRow && col == attackColumn)
                    {
                        ((CheckBox)c).BackColor = Color.FromArgb(255, 0, 0);
                    }
                }
            }
        }

        public bool cpuAttack()
        {
            // randomly generates a number for row and col then checks it against the user_map generated file

            Random rnd = new Random();
            bool cpuHit = false;

            int attackRow = rnd.Next(8);
            int attackColumn = rnd.Next(7);

            string systemPath = Directory.GetCurrentDirectory();
            string line;

            StreamReader file = new StreamReader(systemPath + "\\user_map.txt");

            while ((line = file.ReadLine()) != null)
            {
                if (line == attackRow + ", " + attackColumn)
                {
                    cpuHit = true;
                    disableHomeShips(attackRow, attackColumn); // calls home function to disable ship that was destroyed
                }
               //  System.Console.WriteLine(line); // debug
            }

            // Console.WriteLine(cpuHit); // debug

            file.Close();

            return cpuHit;

        }

        private void attackview_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel1.Show();
        }
    }
}




/*      Jesse Zetko
 *      CIS Objec-Oriented Programming
 * 
 *      BattleShip Game
 *          Known Issues: 
 *              Sometimes the indexer array that is supposed to keep cpu generated row, column values unique will generate two of the same,
 *              making it impossible for a win case. If I worked on this more I could probably figure it out .
 *              
 *              Switching off submarine / cruiser while making selection may end up with the program returning the user to the wrong
 *              boat in whihc they were working on. This is since they have the same maxvalue, I'm sure there's a solution
 *              I just didn't look much into it since the severity of the problem is pretty low.
 *              
 *          Wanted Features I wasn't able to add:
 *                 Make checkboxes green if miss, it seemed to override the red checkboxes on hits
 *                 
 */