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

        Label[,] labels = new Label[10, 5];
        int x, y, max = -1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (labels[x + 1, y].Text != "")
            {
                gameOver();
            }
            x++;
            if (x == 1)
            {
                labels[x, y].Text = randomNumber().ToString();
                labels[x, y].BackColor = Color.Red;
            }
            else
            {
                labels[x, y].Text = labels[x - 1, y].Text;
                labels[x, y].BackColor = labels[x - 1, y].BackColor;
            }
            labels[x - 1, y].Text = "";
            labels[x - 1, y].BackColor = Color.White;
            if (x > 8 || labels[x + 1, y].Tag == "locked")
            {
                if (x <= 8 && labels[x + 1, y].Text == labels[x, y].Text)
                {
                    labels[x + 1, y].Text = Convert.ToString(Convert.ToInt32(labels[x, y].Text) * 2);
                    if (Convert.ToInt32(labels[x + 1, y].Text) > max)
                        max = Convert.ToInt32(labels[x + 1, y].Text);
                    labels[x, y].Text = "";
                    labels[x, y].BackColor = Color.White;
                }
                else
                    labels[x, y].Tag = "locked";
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (labels[i, j].Text != "")
                        {
                            if (i + 1 < 10 && labels[i, j].Text == labels[i + 1, j].Text)
                            {
                                labels[i + 1, j].Text = Convert.ToString(Convert.ToInt32(labels[i, j].Text) * 2);
                                if (Convert.ToInt32(labels[i + 1, j].Text) > max)
                                    max = Convert.ToInt32(labels[i + 1, j].Text);
                                labels[i, j].Text = "";
                                labels[i, j].BackColor = Color.White;
                                labels[i, j].Tag = "";
                            }
                            else if (j - 1 >= 0 && labels[i, j].Text == labels[i, j - 1].Text)
                            {
                                labels[i, j].Text = Convert.ToString(Convert.ToInt32(labels[i, j].Text) * 2);
                                if (Convert.ToInt32(labels[i, j].Text) > max)
                                    max = Convert.ToInt32(labels[i, j].Text);
                                labels[i, j - 1].Text = "";
                                labels[i, j - 1].BackColor = Color.White;
                                labels[i, j - 1].Tag = "";
                            }
                            else if (j + 1 < 5 && labels[i, j].Text == labels[i, j + 1].Text)
                            {

                                labels[i, j + 1].Text = Convert.ToString(Convert.ToInt32(labels[i, j].Text) * 2);
                                if (Convert.ToInt32(labels[i, j + 1].Text) > max)
                                    max = Convert.ToInt32(labels[i, j + 1].Text);
                                labels[i, j].Text = "";
                                labels[i, j].BackColor = Color.White;
                                labels[i, j].Tag = "";
                            }
                        }
                    }
                }
                generateNumber();
            }
            
            if (max < 2)
                score.Text = "Score: 2";
            else
                score.Text = "Score: " + max;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (labels[i, j].Text == "2")
                    {
                        labels[i, j].BackColor = Color.Gray;
                    }
                    else if (labels[i, j].Text == "4")
                    {
                        labels[i, j].BackColor = Color.Coral;
                    }
                    else if (labels[i, j].Text == "8")
                    {
                        labels[i, j].BackColor = Color.Cyan;
                    }
                    else if (labels[i, j].Text == "16")
                    {
                        labels[i, j].BackColor = Color.Honeydew;
                    }
                    else if (labels[i, j].Text == "32")
                    {
                        labels[i, j].BackColor = Color.IndianRed;
                    }
                    else if (labels[i, j].Text == "64")
                    {
                        labels[i, j].BackColor = Color.DarkOrchid;
                    }
                    else if (labels[i, j].Text == "128")
                    {
                        labels[i, j].BackColor = Color.LightPink;
                    }
                    else if (labels[i, j].Text == "256")
                    {
                        labels[i, j].BackColor = Color.Yellow;
                    }
                    else if (labels[i, j].Text == "512")
                    {
                        labels[i, j].BackColor = Color.Orange;
                    }
                    else if (labels[i, j].Text == "1024")
                    {
                        labels[i, j].BackColor = Color.Violet;
                    }
                    else if (labels[i, j].Text != "")
                    {
                        labels[i, j].BackColor = Color.Red;
                    }
                }
            }
        }

        private int randomNumber()
        {
            int max2 = max, nr = 0;

            while(max2 > 0)
            {
                max2 /= 2;
                nr++;
            }

            if (nr > 1)
                return Convert.ToInt32(Math.Pow(2, new Random().Next(1, nr-1)));
            else
                return 2;
        }

        private void generateNumber()
        {
            x = 0;
            y = 2;
        }

        private void pause_btn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled == true)
                pause_btn.Text = "Pause";
            else
                pause_btn.Text = "Continue";
        }

        private void restart_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    labels[i, j].Text = "";
                    labels[i, j].BackColor = Color.White;
                    labels[i, j].Tag = "";
                }
            }
            x = 0;
            y = 2;
            max = -1;
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            menu.Enabled = false;
            menu.Visible = false;

            title.Enabled = false;
            title.Visible = false;

            start_button.Enabled = false;
            start_button.Visible = false;

            quit_button.Enabled = false;
            quit_button.Visible = false;

            timer1.Enabled = true;
        }

        private void quit_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void gameOver()
        {
            menu.Enabled = true;
            menu.Visible = true;

            title.Text = "Game Over!";
            title.Enabled = true;
            title.Visible = true;

            start_button.Text = "Play Again";
            start_button.Enabled = true;
            start_button.Visible = true;

            quit_button.Enabled = true;
            quit_button.Visible = true;

            timer1.Enabled = false;
            restart_btn_Click(new Object(), new EventArgs());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                y--;
                labels[x, y].Text = labels[x, y + 1].Text;
                labels[x, y].BackColor = labels[x, y + 1].BackColor;
                labels[x, y + 1].Text = "";
                labels[x, y + 1].BackColor = Color.White;
            }
            else if (e.KeyCode == Keys.Right)
            {
                y++;
                labels[x, y].Text = labels[x, y - 1].Text;
                labels[x, y].BackColor = labels[x, y - 1].BackColor;
                labels[x, y - 1].Text = "";
                labels[x, y - 1].BackColor = Color.White;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (x < 8 || labels[x + 1, y].Tag != "locked")
                {
                    x++;
                    labels[x, y].Text = labels[x - 1, y].Text;
                    labels[x, y].BackColor = labels[x - 1, y].BackColor;
                    labels[x - 1, y].Text = "";
                    labels[x - 1, y].BackColor = Color.White;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labels = new Label[,]
            {
                { label1, label2, label3, label4, label5 },
                { label6, label7, label8, label9, label10 },
                { label11, label12, label13, label14, label15 },
                { label16, label17, label18, label19, label20 },
                { label21, label22, label23, label24, label25 },
                { label26, label27, label28, label29, label30 },
                { label31, label32, label33, label34, label35 },
                { label36, label37, label38, label39, label40 },
                { label41, label42, label43, label44, label45 },
                { label46, label47, label48, label49, label50 },
            };

            generateNumber();
        }
    }
}
