/*
 *  Group: Jesse, Jake, Blayke
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strNumbers = textBox1.Text;
            string[] strArr = strNumbers.Split(',');

            string placeholder;
            double sum = 0;
            int max, min;

            try
            {
                min = Convert.ToInt32(strArr[0]);
                max = min;

                for (int i = 0; i < strArr.Length; i++)
                {
                    placeholder = strArr[i];

                    sum += Convert.ToInt32(strArr[i]);

                    if (Convert.ToInt32(strArr[i]) > max)
                    {
                        max = Convert.ToInt32(strArr[i]);
                    }
                    if (Convert.ToInt32(strArr[i]) < min)
                    {
                        min = Convert.ToInt32(strArr[i]);
                    }
                }

                textBox3.Text = sum.ToString();
                textBox4.Text = min.ToString();
                textBox5.Text = max.ToString();
                textBox6.Text = (sum / strArr.Length).ToString();
            }
            catch
            {
                MessageBox.Show("Code failure");
            }
        }
    }
}
