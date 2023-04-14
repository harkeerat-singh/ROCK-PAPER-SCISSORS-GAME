using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApp1.Properties;
using System.Runtime.InteropServices;
using System.Deployment.Application;
using System.ComponentModel.Design;
using System.Net.Security;
using System.Windows.Forms.VisualStyles;
using System.Management.Instrumentation;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Mail;
using Microsoft.VisualBasic;
using Label = System.Windows.Forms.Label;

namespace WindowsFormsApp1
{

    


    public partial class Form1 : System.Windows.Forms.Form
    {
        


        int timer;
        private void progresstime_Tick(object sender, EventArgs e) // the boot bar which increments
        {
            bar.Increment(3);

            timer += 3;

            if (timer == 150)
            {
                text.Show();

                progresstime.Enabled = false;

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e) // when you click the rock the menu is showed
        {

            

            progresstime.Enabled = false;



            foreach (Control x in this.Controls)
            {
                if (x.Tag == "boot")
                {
                    x.Hide();

                }
            }

            foreach (Control x in this.Controls)
            {
                if (x.Tag == "menu")
                {
                    x.Show();

                }
            }
        }

        PictureBox[] arrows = new PictureBox[12]; // array used to track the arrows that point to the goal

        System.Drawing.Point[] points = new System.Drawing.Point[12]; // and the specific locations

        int aheader = 0;


        void set() // fills in the arrays as i had trouble doing them directly like this:  array[] thingy = {thing,thing,thing};
        {
            arrows[0] = a1;
            arrows[1] = a2;
            arrows[2] = a3;
            arrows[3] = a4;
            arrows[4] = a5;
            arrows[5] = a6;
            arrows[6] = a7;
            arrows[7] = a8;
            arrows[8] = a9;
            arrows[9] = a10;
            arrows[10] = a11;
            arrows[11] = a12;


            points[0] = new Point(107, 418);
            points[1] = new Point(176, 380);
            points[2] = new Point(176, 319);
            points[3] = new Point(199, 319);
            points[4] = new Point(265, 281);
            points[5] = new Point(265, 220);
            points[6] = new Point(265, 159);
            points[7] = new Point(265, 98);
            points[8] = new Point(265, 39);
            points[9] = new Point(196, 39);
            points[10] = new Point(130, 39);
            points[11] = new Point(61, 39);


        }











        int egg = 0; // random named variable waits a certain amount before shwing the arriws





        private void arrowclock_Tick(object sender, EventArgs e)
        {
            if(egg == 3)
            {
                if (aheader != 12) // shows the arrows 1 by 1 by iterating thorugh array
                {
                    arrows[aheader].Location = points[aheader];
                    aheader++;
                }
                else
                {

                    foreach(PictureBox arrow in arrows)
                    {
                        arrow.BackColor = Color.Magenta;
                    }

                    arrowclock.Enabled = false;
                }
            }
            else
            {
                egg++;
            }

            

            
        }




        void proceed()
        {
            foreach (Control x in this.Controls)
            {


                x.Hide();
            }

            

            
            bootdrop.Show();

            devinfo.Location = new Point(150, 88);
            passbox.Location = new Point(174, 409);

            devinfo.BringToFront();
            passbox.BringToFront();

            devinfo.Show();
            passbox.Show();

            bootdrop.SendToBack();


            check();
            




        }

        string password = string.Empty;

        void check()
        {
            StreamReader read = new StreamReader("key.txt");

            password = read.ReadLine();

            read.Close();
        }


        


        private void passbox_TextChanged(object sender, EventArgs e) // security so any old person cant just become a developer
        {


            if (passbox.Visible)
            {
                if (passbox.Text.Length == password.Length)
                {
                    if (passbox.Text == password)
                    {
                        cheat(true);
                    }
                    else
                    {
                        MessageBox.Show("The program has been locked, please seek the administrator for help immediately", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        StreamWriter error = new StreamWriter("logban.txt");

                        error.WriteLine("true");

                        error.Close();

                        this.Close();
                    }
                }
            }

            
        }


        private void locktime_Tick(object sender, EventArgs e)
        {
            lockimg.Size = this.Size;
            lockimg.Location = new Point(0, 0);
        }

        

        void cheat(bool identified) // saves me a bunch of time
        {



            if (!identified)
            {


                passbox.Text = "";
                progresstime.Enabled = false;
                proceed();
            }
            else if(identified)
            {


                game.Enabled = false;

                playername = "developer";


                passbox.Hide();
                devinfo.Text = "DEVELOPER MENU";

                db1.Location = new Point(200, 193); //the core point
                db1.Show();

                db2.Location = new Point(db1.Left, db1.Top + 91);
                db2.Show();

                db3.Location = new Point(db1.Left, db2.Top + 91);
                db3.Show();

                db4.Location = new Point(db1.Left, db3.Top + 91);
                db4.Show();

                db5.Location = new Point(db1.Left + 180, db1.Top); // new row
                db5.Show();

                db6.Location = new Point(db5.Left, db5.Top + 91);
                db6.Show();

                db7.Location = new Point(db6.Left, db6.Top + 91);
                db7.Show();

                db8.Location = new Point(db7.Left, db7.Top + 91);
                db8.Show();

                

                // show the dev menu

                //dmenu




            }



            











        }


        

        Random rnd = new Random();




        void jump()
        {

            progresstime.Enabled = false;

            if(playername == "")
            {
                string[] names = new string[71];
                int nheader = 0;


                

                foreach (string line in System.IO.File.ReadLines(@"names.txt")) // adds all names to array
                {
                    if(line != "")
                    {
                        names[nheader] = line;
                        nheader++;
                    }


                }

                gen();

                void gen()
                {
                    string doobee = names[rnd.Next(0, names.Length)]; // gens a name until its not blank

                    if (doobee != null && doobee != "")
                    {
                        playername = doobee;
                    }
                    else
                    {
                        gen();
                    }
                }

                
                

                
            }

            

            

            foreach (Control x in this.Controls)
            {


                x.Hide();
            }







            foreach (Control x in this.Controls)
            {
                if (x.Tag == "platform" || x.Tag == "game" || x.Tag == "enemy")
                {
                    x.Show();
                }
            }


            refresh();
        }


        void refresh()
        {
            countlabel.Location = new Point(274, 190);
            countlabel.Show();
            gametimer.Enabled = false;
            time = 0;
            initialize();
            countdown.Enabled = true;
        }


        void isbanned()
        {
            StreamReader checker = new StreamReader("logban.txt");


            string check = checker.ReadLine();

            if(check == "true")
            {
                MessageBox.Show("The program has been locked, please seek the administrator for help immediately", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                locktime.Enabled = true;

                foreach(Control x in this.Controls)
                {
                    if(x.Name != "locktime")
                    {
                        x.Enabled = false;
                    }
                }

                checker.Close();


            }
            else
            {
                checker.Close();
            }

            
        }


        public Form1()
        {


            
            

            InitializeComponent();



            isbanned();


            //or ||

            passbox.Hide();

            set();

            foreach (Control x in this.Controls) // shows boot
            {
                if (x.Tag == "boot")
                {
                    x.Top -= 618;
                }
            }

            text.Hide();

            sortboard(); // bubble sort the leaderboard text


            foreach (Control x in this.Controls) 
            {
                if (x.Tag == "menu")
                {
                    x.Hide();
                    x.Left -= 700;
                }
            }




            game.Enabled = false;

            foreach(Control x in this.Controls)
            {
                if(x.Tag == "platform" || x.Tag == "game" || x.Tag == "enemy")
                {
                    x.Hide(); // hides everything
                }
            }



            this.KeyPreview = true; // had issues with the keydown, this sorted it

            player.SizeMode = PictureBoxSizeMode.StretchImage;

            this.MaximumSize = new Size(787, 630); // so you cant see the clutter
        }

        string[] times = new string[200];
        int theader = 0;

        int[] numbers = new int[200];
        int numheader = 0;

        void sortboard() // sorts the leaderbaord file
        {
            foreach (string line in System.IO.File.ReadLines(@"leaderboard.txt")) // puts all strings into array
            {

                if (line.Any(char.IsLetter))
                {
                    times[theader] = line;
                    theader++;

                }



            }


            foreach (string i in times)
            {

                if (i != null)
                {
                    numbers[numheader] = Convert.ToInt32(i.Split('(', ')')[1]);
                    numheader++;
                }

            }



            int t;
            string t2;

            for (int p = 0; p <= numbers.Length - 2; p++) //LOOK ITS BUBBLE SORT!!!
            {
                for (int i = 0; i <= numbers.Length - 2; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        t = numbers[i + 1];
                        t2 = times[i + 1];

                        numbers[i + 1] = numbers[i];
                        times[i + 1] = times[i];

                        numbers[i] = t;
                        times[i] = t2;
                    }
                }
            }



            StreamWriter sw = new StreamWriter("leaderboard.txt");

            foreach (string i in times) // re writes 
            {

                if (i != null)
                {
                    sw.WriteLine(i);
                }

            }

            sw.Close();

            

            StreamReader sr2 = new StreamReader("leaderboard.txt");
            leaderboard.Text = sr2.ReadToEnd();
            sr2.Close();

            

        }





        string playername = "";

        void savedata() // adds user data to leaderboard
        {

            if(playername != "cheater")
            {
                StreamReader sr = new StreamReader("leaderboard.txt");

                string old = sr.ReadToEnd();
                sr.Close();


                StreamWriter sw = new StreamWriter("leaderboard.txt");

                sw.Write(old);
                sw.WriteLine(playername + "(" + time + ")");

                sw.Close();
            }
            

            
        }



        bool goleft, goright,decrease,jumping; // movement

        int pspeed,force,jumpspeed;

        string pstate = "rock";

        int paperspeed = 2;
        int rockspeed = 6;
        int scispeed = 3;
        

        int timecount = 0;
        int header = 0;
        
        void initialize()
        {

            //define variables

            time = 0;
            game.Enabled = false; // game is a timer in which the platformer gravity jump and movemement and other important attributes occur
            goleft = false; // self explanatory
            goright = false;
            decrease = false; // used for the exponential speed (if the key is held for longer the character speeds up etc)
            jumping = false; // if the character is currently mid air
            pspeed = 0; // player speed currently as its exponential
            force = 0; // gravity
            jumpspeed = 0; // 
            timecount = 0; // used for changing pictures of enemies
            header = 0; // header is the variable used to keep track of the changing images of the enmies
            xpointer = 0; // what is xpointer. xpointer is the variable to keep track of the 3 2 1 array menu
            pstate = "rock"; // pstate is the state of the player rock apper or scissors
            updatepic();

            player.Location = new Point(36, 411);

            foreach (Control x in this.Controls)
            {
                if ( x.Tag == "enemy")
                {
                    x.Show(); 
                }
            }

            

            countlabel.Show();
            countlabel.Text = "3";

            countdown.Enabled = true;
            



        }


        void updatepic() // changes player image according to the button currently pressed
        {
            switch (pstate)
            {
                case "rock":

                    player.Image = Properties.Resources.rock;
                    break;
                case "paper":

                    player.Image = Properties.Resources.paper;
                    break;
                case "sci":
                    player.Image = Properties.Resources.scissors;
                    break;
            }
        }


        private void paperbtn_Click(object sender, EventArgs e)
        {
            pstate = "paper";
            updatepic();
        }

        private void scibtn_Click(object sender, EventArgs e)
        {
            pstate = "sci";
            updatepic();
        }

        private void label1_Click(object sender, EventArgs e) // rock the reason why labels are clickable is because i had issues with buttons therefore i used picbox and labels instead
        {
            pstate = "rock";
            updatepic();
        }

        private void label2_Click(object sender, EventArgs e) // paper
        {
            pstate = "paper";
            updatepic();
        }

        private void label3_Click(object sender, EventArgs e) // scissors
        {
            pstate = "sci";
            updatepic();
        }

        private void rockbtn_Click(object sender, EventArgs e)
        {
            pstate = "rock";
            updatepic();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        int pheader = 1;
        int sheader = 2;

        void changepic()
        {
            System.Drawing.Bitmap[] options = { Properties.Resources.rock, Properties.Resources.paper, Properties.Resources.scissors };
            string[] names = { "rock", "paper", "sci" };

            Random rnd = new Random();

            header++;

            if (header == 3)
            {
                header = 0;
            }

            pheader++;

            if(pheader == 3)
            {
                pheader = 0;
            }

            sheader++;

            if(sheader == 3)
            {
                sheader = 0;
            }



            rock.Image = options[header]; // changing enemy pictures
            rock.Name = names[header];

            paper.Image = options[pheader];
            paper.Name = names[pheader];

            sci.Image = options[sheader];
            sci.Name = names[sheader];



            

        }


        int speedlimit = 7;

        private void game_Tick(object sender, EventArgs e)
        {



            
            gametimer.Enabled = true;

            nametag.Text = playername;

            if(pstate == "rock")
            {
                rockbtn.BorderStyle = BorderStyle.Fixed3D; // the borders to make the picbox buttons look like  square radiobuttons in a way

                paperbtn.BorderStyle = BorderStyle.None;
                scibtn.BorderStyle = BorderStyle.None;
            }
            else if(pstate == "paper")
            {
                paperbtn.BorderStyle = BorderStyle.Fixed3D;

                rockbtn.BorderStyle = BorderStyle.None;
                scibtn.BorderStyle = BorderStyle.None;
            }
            else if(pstate == "sci")
            {
                scibtn.BorderStyle = BorderStyle.Fixed3D;

                paperbtn.BorderStyle = BorderStyle.None;
                rockbtn.BorderStyle = BorderStyle.None;
            }



            if (player.Left < 0) // movement 
            {
                player.Left = 0;
            }

            player.Left += pspeed;

            player.Top += jumpspeed;

            


            if (goright == true)
            {

                if (pspeed < speedlimit)
                {
                    pspeed += 2;
                }
                
            }

            if (goleft == true)
            {
                if(pspeed > -speedlimit)
                {
                    pspeed -= 2;
                }
               
            }

            if (decrease)  // movement
            {
                if (pspeed > 0)
                {
                    pspeed -= 2;
                }
                else if(pspeed <0)
                {
                    pspeed += 2;
                }
                else
                {
                    pspeed = 0;
                }
            }

            //need to add

           


            //use sort algorithm for leaderbaord

            


            //notes
           

            // if you really want to add a moving platform tooa maybe

            paper.Left += paperspeed;

            if (paper.Left < paperplat.Left || paper.Left + paper.Width > paperplat.Left + paperplat.Width) // enemy movement with inteligence
            {
                paperspeed = -paperspeed;
            }

            sci.Left += scispeed;

            if (sci.Left < sciplat.Left || sci.Left + sci.Width > sciplat.Left + sciplat.Width)
            {
                scispeed = -scispeed;
            }

            rock.Left += rockspeed;

            if (rock.Left < rockplat.Left || rock.Left + rock.Width > rockplat.Left + rockplat.Width)
            {
                rockspeed = -rockspeed;
            }


            if (timecount == 3000) // keeps track of when to change photo on enemy
            {
                timecount = 0;
                changepic();


            }
            else
            {
                timecount += 25;
            }




            


            if (jumping == true && force < 0) 
            {
                jumping = false;
            }

            if (jumping == true)
            {
                jumpspeed = -jumpvar;
                force -= 1;
            }
            else
            {
                jumpspeed = 10;
            }

            

            foreach (Control x in this.Controls)  //enemy code rock paper scissors
            {
                if (x is PictureBox)
                {

                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            if((pstate == "rock" && x.Name == "sci" || pstate == "paper" && x.Name == "rock" || pstate == "sci" && x.Name == "paper"))
                            {
                                x.Hide();
                            }
                            else if(x.Visible == false) // empty statement so it doesnt game over if x is hidden and touching player
                            {

                            }
                            else if(pstate == x.Name) // if its a draw
                            {

                            }
                            else
                            {
                                gameover();

                            }
                        }


                    }


                }
            }


            

            if (player.Bounds.IntersectsWith(goal.Bounds)) // goal
            {
                if(rock.Visible == false && paper.Visible == false && sci.Visible == false)
                {
                    youwin();




                }
                else
                {
                    

                    

                    reset();

                    
                }

                
            }

            foreach (Control x in this.Controls)  //ensures character doesnt fall through platfoprm , itstays on it
            {
                if (x is PictureBox)
                {

                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && player.Bottom > x.Top)
                        {
                            force = jumpvar;
                            player.Top = x.Top - player.Height;
                        }


                    }


                }
            }



        }


        int jumpvar = 8;


        void start() // start btn
        {

            if(namebox.Text == "")
            {
                MessageBox.Show("Please enter a name to continue","For your information");


            }
            
            else if(namebox.Text == "developer")
            {
                MessageBox.Show("Please choose another name", "Access denied",MessageBoxButtons.OK,MessageBoxIcon.Error);
                namebox.Text = "";
            }
            else
            {




                playername = namebox.Text;

                foreach (Control x in this.Controls)
                {
                    if (x.Tag == "menu") // hide the menu
                    {
                        x.Hide();
                    }
                }


                bool show = false;

                if (!show) // skip the menu and boot logo by using //insert command here
                {

                    controls.Location = new Point(179, 101); // the tutorial
                    controls.Size = new Size(397, 349);

                    

                    MessageBox.Show("WASD to move, Space to jump", "How to play");

                    controls.Hide();

                    

                    rockbtn.Show();
                    paperbtn.Show();
                    scibtn.Show();
                    label1.Show();
                    label2.Show();
                    label3.Show();

                    //notes improve tutorial


                    border1.Location = new Point(12, 482);
                    border1.Size = new Size(749, 113);

                    player.Show();

                    

                    MessageBox.Show("Click the buttons at the bottom to switch the player's item from rock paper and scissors","How to play");


                    

                    border1.Hide();



                    border2.Size = new Size(108, 108);
                    border3.Size = new Size(108, 108);
                    border4.Size = new Size(108, 108);

                    border2.Location = new Point(336, 334);
                    border3.Location = new Point(11, 167);
                    border4.Location = new Point(432, 62);
                    rock.Show();
                    sci.Show();
                    paper.Show();

                    foreach (Control x in this.Controls)
                    {
                        if (x.Tag == "platform")
                        {
                            x.Show();
                        }
                    }




                    MessageBox.Show("Kill the enemies by walking into them using the appropriate item to defeat them(rock paper or scissors)", "How to play");
                    MessageBox.Show("The enemies also change their items frequently so don't get tricked!", "How to play");
                    border2.Hide();
                    border3.Hide();
                    border4.Hide();



                    goal.Show();
                    label4.Show();

                    player.Show();
                    arrowclock.Enabled = true;

                    MessageBox.Show("Get to the goal and complete the game", "How to play");

                    foreach (PictureBox arrow in arrows)
                    {
                        arrow.Hide();
                    }

                    timelabel.Show();

                    timelabel.BackColor = Color.Magenta;

                    MessageBox.Show("Keep playing and get your best time to beat the leaderboard", "How to play");



                    //end of tutorial

                }

                timelabel.BackColor = Color.IndianRed;
                


                //notes

                //add snake arrow for goal

            

                foreach (Control x in this.Controls) // pretty reduntant at this point but ill keep it,  no harm
                {
                    if (x.Tag == "platform" || x.Tag == "game" || x.Tag == "enemy")
                    {
                        x.Show();
                    }
                }



                countlabel.Location = new Point(274, 190);

                countdown.Enabled =true; // starts the game with the 3 2 1


            }


            
        }


        

        



        int xpointer = 0; // xpointer is variable to iterate through the 2 1 go array

        private void countdown_Tick(object sender, EventArgs e) // countdown
        {

            

            string[] modules = {"2", "1", "GO!" };

            

            if (xpointer == 3)
            {
                countlabel.Hide();
                game.Enabled = true;
                xpointer = 0;
                countdown.Enabled = false;
                
            }
            else
            {
                countlabel.Text = modules[xpointer];
            }

            xpointer++;




            //game.Enabled = true;
        }
        private void gobtn_Click(object sender, EventArgs e) // gobtn
        {

            start();
        }

        private void label7_Click(object sender, EventArgs e) // and label too
        {
            start();
        }

        int time = 0;

        private void gametimer_Tick(object sender, EventArgs e) //keeps tracj of time
        {
            time++;

            timelabel.Text = "Time: " + time.ToString();
        }

        private void db1_Click(object sender, EventArgs e)
        {
            if(!game.Enabled)
            {
                jump();
            }


            
        }

        private void db2_Click(object sender, EventArgs e) // password changer
        {
            if (!game.Enabled)
            {
                string value = "";

                if (InputBox("Password Change", "Enter the new Password", ref value,true) == DialogResult.OK)
                {
                    StreamWriter passchange = new StreamWriter("key.txt");

                    passchange.WriteLine(value);

                    passchange.Close();

                    MessageBox.Show("Password change successful, Please restart the program", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("The password was not changed", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //insert thing here
            }




        }


        public static DialogResult InputBox(string title, string promptText, ref string value,bool pass) // for messagebox password changer
        {
            Form form2 = new Form();
            Label labelx = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
           

            if (pass)
            {
                textBox.PasswordChar = '*';
            }

            form2.Text = title;
            labelx.Text = promptText;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            labelx.SetBounds(36, 36, 372, 13);
            textBox.SetBounds(36, 86, 700, 20);
            buttonOk.SetBounds(228, 160, 160, 60);
            buttonCancel.SetBounds(400, 160, 160, 60);

            labelx.AutoSize = true;
            form2.ClientSize = new Size(796, 307);
            form2.FormBorderStyle = FormBorderStyle.FixedDialog;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.MinimizeBox = false;
            form2.MaximizeBox = false;

            form2.Controls.AddRange(new Control[] { labelx, textBox, buttonOk, buttonCancel });
            form2.AcceptButton = buttonOk;
            form2.CancelButton = buttonCancel;

            DialogResult dialogResult = form2.ShowDialog();

            value = textBox.Text;
            return dialogResult;
        }

        private void db3_Click(object sender, EventArgs e)
        {

            if (!game.Enabled)
            {
                backup();
            }

            
        }

        void backup()
        {
            StreamReader copy = new StreamReader("leaderboard.txt");

            string cc = copy.ReadToEnd();

            copy.Close();

            StreamWriter paste = new StreamWriter("leaderboardcopy.txt");

            paste.Write(cc);

            paste.Close();

            MessageBox.Show("The backup was successful", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db4_Click(object sender, EventArgs e)
        {

            if (!game.Enabled)
            {
                DialogResult d;

                d = MessageBox.Show("Are you sure you want to wipe the leaderboard?", "System Information Module", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (d == DialogResult.OK)
                {
                    backup();

                    StreamWriter wipe = new StreamWriter("leaderboard.txt");

                    wipe.Write("");

                    wipe.Close();

                    MessageBox.Show("The leaderboard has been wiped", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (d == DialogResult.Cancel)
                {
                    MessageBox.Show("No chnages have been made to the leaderboard", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            

            
        }

        private void db5_Click(object sender, EventArgs e)
        {

            if (!game.Enabled)
            {
                DialogResult d;
                d = MessageBox.Show("Are you sure you want to wipe the leaderboard?", "System Information Module", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (d == DialogResult.OK)
                {
                    StreamReader copy = new StreamReader("leaderboardcopy.txt");

                    string cc = copy.ReadToEnd();

                    copy.Close();

                    StreamWriter paste = new StreamWriter("leaderboard.txt");

                    paste.Write(cc);

                    paste.Close();

                    MessageBox.Show("The leaderboard has successfully been restored", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (d == DialogResult.Cancel)
                {
                    MessageBox.Show("No chnages have been made to the leaderboard", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            

            
        }

        private void db6_Click(object sender, EventArgs e)
        {

            string valu = "";

            go();

            void go()
            {
                DialogResult d = InputBox("Modify gamespeed", "Enter the desired gamespeed here, the default value is 25", ref valu,false);


                if (d == DialogResult.OK)
                {
                    if (int.TryParse(valu, out int value))
                    {
                        game.Interval = Convert.ToInt32(valu);
                        MessageBox.Show("The gamespeed has been set to " + valu, "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("The value entered is not an integer, please try again", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        go();
                    }
                }  

            }

            


            

        }

        private void db7_Click(object sender, EventArgs e)
        {
            string valu = "";

            go();

            void go()
            {
                DialogResult d = InputBox("Modify playerspeed", "Enter the player speed here, the default value is 7", ref valu, false);


                if (d == DialogResult.OK)
                {
                    if (int.TryParse(valu, out int value))
                    {
                        speedlimit = Convert.ToInt32(valu);
                        MessageBox.Show("The player speed has been set to " + valu, "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("The value entered is not an integer, please try again", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        go();
                    }
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void db8_Click(object sender, EventArgs e)
        {
            string valu = "";

            go();

            void go()
            {
                DialogResult d = InputBox("Modify int jumpvar", "Enter the desired jumpvar initiative here, the default value is 8", ref valu, false);


                if (d == DialogResult.OK)
                {
                    if (int.TryParse(valu, out int value))
                    {
                        jumpvar = Convert.ToInt32(valu);
                        MessageBox.Show("Int jumpvar has been set to " + valu, "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("The value entered is not an integer, please try again", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        go();
                    }
                }

            }
        }


        string test;
        private void db9_Click(object sender, EventArgs e)
        {

            bool found = false;

            foreach(Control x in this.Controls)
            {
                if(x.Name == "test")
                {
                    found = true;
                    break;
                }
                
            }

            if (!found)
            {
                MessageBox.Show("no found bro", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("found bro", "System Information Module", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void reset() // if the goal is apporached without killing da enemeis first
        {
            game.Enabled=false;
            gametimer.Enabled=false;

            MessageBox.Show("Kill all the enemies first ,stonehead", "Not so fast m8");

            goleft = false; 
            goright = false;
            decrease = false; 
            jumping = false; 
            pspeed = 0; 
            force = 0; 
            jumpspeed = 0; 
            timecount = 0; 
            header = 0; 
            xpointer = 0; 
            pstate = "rock"; 

            player.Location = new Point(36, 411);

            foreach (Control x in this.Controls)
            {
                if (x.Tag == "enemy")
                {
                    x.Show();
                }
            }



            countlabel.Show();
            countlabel.Text = "3";

            countdown.Enabled = true;
            game.Enabled = false; 
           









        }
        
        void youwin() // shows the beatiful masterpiece at the end
        {
            gametimer.Enabled = false;
            savedata();
            

            game.Enabled = false;


            goalimage.Left = -2;
            goalimage.Top = -7;

            goalimage.Size = new Size(763,599);

            




            
            goalimage.Show();
            label5.Location = new Point(170, 461);
            label5.Show();

            string message = "Do you want to play again? Click yes to play or no to close hurrendous image.";
            string title = "For your information";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                label5.Hide();
                goalimage.Hide();
                initialize();
            }
            else
            {
                this.Close();
            }

           
        }
        void gameover() // self explanatory
        {

            gametimer.Enabled = false;

            game.Enabled = false;

            string message = "Game over. Do you want to restart?";
            string title = "For your information";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                
                initialize();
            }
            else
            {
                this.Close();
            }
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e) // the boring stuff
        {
            if (e.KeyCode == Keys.D)
            {
                goright = true;
                decrease = false;


            }

            if (e.KeyCode == Keys.A)
            {
                goleft = true;
                decrease = false;

            }

            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }


            if (e.Control && e.Alt && e.KeyCode == Keys.O)
            {
                cheat(false);
            }

            if (e.Alt && e.KeyCode == Keys.K)
            {
                jump();
            }

            if(e.Control && e.Alt&& e.KeyCode == Keys.E)
            {
                if(locktime.Enabled == true)
                {
                    locktime.Enabled = false;


                    string value = "";

                    DialogResult d = InputBox("Enter developer password", "Please enter the developer password to unlock the program", ref value,true);
                    //dcome
                    if (d == DialogResult.OK)
                    {
                        check();

                        if(value == password)
                        {

                            StreamWriter clear = new StreamWriter("logban.txt");

                            clear.Write("");

                            clear.Close();



                            MessageBox.Show("The program has been unlocked, it will now restart.","System Information Module",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("You have entered the incorrect password, please contact the program administrator immediately", "Critical System Abortion Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.Close();
                            //wishy washy language hahahaha
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
                
            }

            if(e.Control && e.KeyCode == Keys.Insert)
            {
                playername = "cheater";

                rock.Hide();
                paper.Hide();
                sci.Hide();

                player.Location = new Point(148, 44);
            }

            


        }

        

        private void Form1_KeyUp(object sender, KeyEventArgs e) // and more of it
        {
            if (e.KeyCode == Keys.D)
            {
                goright = false;
                decrease = true;


            }

            if (e.KeyCode == Keys.A)
            {
                goleft = false;
                decrease = true;

            }

            if (jumping == true)
            {
                jumping = false;
            }
        }

    }   //the end !! already??
}
