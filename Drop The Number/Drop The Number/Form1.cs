using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drop_The_Number
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int speed = 1, size = 0;
        Label[] labelArray = new Label[100];

        public static Label CopyLabel(Label label)
        {
            Label l = new Label();
            l.Font = label.Font;
            l.Width = label.Width;
            l.Height = label.Height;
            l.Margin = label.Margin;
            l.Text = "2";
            l.TextAlign = label.TextAlign;
            l.BorderStyle = label.BorderStyle;
            l.BackColor = label.BackColor;
            l.ForeColor = label.ForeColor;
            l.Visible = true;
            return l;
        }

        private int check_Collision()
        {
            int bottom = number.Top + number.Height;
            for (int i = 0; i < size; i++)
                if (number.Bounds.IntersectsWith(labelArray[i].Bounds))
                    return 2;
            if (bottom >= 507)
                return 1;
            return 0;
        }

        private void merge(int i)
        {
            labelArray[i].Text = (Convert.ToInt32(labelArray[i].Text) * 2).ToString();
            number.Location = new Point(168, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            number.Top += speed;
            if (check_Collision() == 1)
            {
                labelArray[size++] = number;
                number = CopyLabel(number);
                number.Location = new Point(168, 0);
                this.Controls.Add(number);
            }
            if (check_Collision() == 2)
            {
                int i;
                for (i = 0; i < size; i++)
                    if (number.Bounds.IntersectsWith(labelArray[i].Bounds))
                        break;
                if (number.Text == labelArray[i].Text)
                    merge(i);
                else
                {
                    labelArray[size++] = number;
                    number = CopyLabel(number);
                    number.Location = new Point(168, 0);
                    this.Controls.Add(number);
                }
            }
            for (int i = 0; i < size - 1; i++)
                for (int j = i + 1; j < size; j++)
                    if (labelArray[i].Bounds.IntersectsWith(labelArray[j].Bounds) && labelArray[i].Text == labelArray[j].Text)
                    { 
                        merge(i);
                        labelArray[j].Visible = false;
                        labelArray[j].Enabled = false;
                        for (int p = j; p < size - 1; p++)
                            labelArray[p] = labelArray[p + 1];
                        size--;
                    }
            for (int i = 0; i < size; i++)
            {
                if (labelArray[i].Text == "4")
                    labelArray[i].BackColor = Color.Green;
                else if (labelArray[i].Text == "8")
                    labelArray[i].BackColor = Color.Blue;
                else if (labelArray[i].Text == "16")
                    labelArray[i].BackColor = Color.Red;
                else if (labelArray[i].Text == "32")
                    labelArray[i].BackColor = Color.Purple;
                else if (labelArray[i].Text == "64")
                    labelArray[i].BackColor = Color.Gold;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                number.Left -= number.Width;
                if (number.Left < 0)
                    number.Left += number.Width;
            }
            else if (e.KeyCode == Keys.Right)
            {
                number.Left += number.Width;
                if (number.Left + number.Width > 394)
                    number.Left -= number.Width;
            }
        }
    }
}
