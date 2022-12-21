using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIVS3
{
    public enum State { s, passLabs, onlyLabsAndDontLections, kostyaStateDontSleep, f, unreal }
    public partial class Form1 : Form
    {


        private Dictionary<State, string> messeges = new Dictionary<State, string>()
        { 
            {State.s,"Начало учебы"}, {State.passLabs,"Пытаемся сдать лабы"},{State.onlyLabsAndDontLections,"усердно пилим лабы"},
            {State.kostyaStateDontSleep,"Вы дошли до уровня познания Кости(у вас миллиард долгов и все очень плохо)"},
            {State.unreal,"Успешный успех"},
            {State.f,"Нервный срыв и академ наше все"}
        };
        public Form1()
        {
            InitializeComponent();
        }

        public void ChangeForm( int time, int hung, int slee, int am)
        {
            l_lasting.Text =Convert.ToString(time);
            label3.Text = "Сданные лабы:"+ Convert.ToString(am);
            label2.Text = "Сонливость:" + Convert.ToString(slee);
            label1.Text = "Долги:" + Convert.ToString(hung);
        }
        public void PrintState(State st)
        {
            listBox1.Items.Add(messeges[st]);
        }

        public int getRand12345(Random rand)
        {
            return rand.Next(5)+1;
        }

        public void letsStart()
        {
            State sta = State.s;
            Indicators ind = new Indicators(3, 3, 0);
            Random rand = new Random();


            while ((sta != State.f) && (ind.Days < 10000))
            {
                pictureBox1.Image = null;
                switch (sta)
                {
                    case State.s:
                        sta = State.s;
                        ind.Sleep = 0;

                        if (ind.Dolgi > 2)
                        {
                            if (ind.PassedLabs != 0)
                            {                                
                                sta = State.passLabs;
                                ind.Days += 1;
                            }
                            else if (ind.Dolgi == 3)
                            {
                                sta = State.onlyLabsAndDontLections;
                                ind.Days += 1;
                            }
                            else 
                            {
                                sta = State.kostyaStateDontSleep;
                                ind.Days += 1;
                            }
                        }
                        else
                        {
                            sta = State.unreal;
                            ind.Days += 1;
                        }
                        break;

                    case State.passLabs:
                        sta = State.passLabs;
                        if (ind.PassedLabs >= (5 - ind.Dolgi))
                        {
                            ind.PassedLabs -= ind.Dolgi;
                            ind.Dolgi = 0;
                        }
                        else
                        {
                            ind.Dolgi -= ind.PassedLabs;
                            ind.PassedLabs = 0;
                        }
                        ind.Sleep -= 1;

                        if (ind.Sleep > 5)
                        {
                            sta = State.f;
                        }
                        else if (ind.Dolgi < 2)
                        {
                            sta = State.unreal;
                            ind.Days += 1;
                        }
                        else if (ind.Dolgi < 3)
                        {
                            sta = State.onlyLabsAndDontLections;
                            ind.Days += 1;
                        }
                        else
                        {
                            sta = State.kostyaStateDontSleep;ind.Days += 1;
                        }
                        break;

                    case State.onlyLabsAndDontLections:
                        sta = State.onlyLabsAndDontLections;
                                                
                        ind.Days += getRand12345(rand);
                        ind.Sleep += getRand12345(rand);
                        ind.Dolgi += getRand12345(rand);

                        if (ind.Dolgi > 5)
                        {
                            sta = State.f;
                        }
                        else if (ind.Sleep > 5)
                        {
                            sta = State.f;
                        }
                        else
                        {
                            ind.PassedLabs += getRand12345(rand);
                            sta = State.passLabs;
                            ind.Days += 1;
                        }
                        
                        break;

                    case State.kostyaStateDontSleep:

                        pictureBox1.Image = new Bitmap("C:\\Users\\admin\\OneDrive\\Рабочий стол\\vbdc\u007fmivs\\Глотова\\MIVS3\\MIVS3\\imgs\\qW76rxwpZIU.jpg");

                        sta = State.kostyaStateDontSleep;
                        ind.Days += getRand12345(rand) + 1;
                        ind.Sleep += getRand12345(rand) + 1;
                        ind.Dolgi += getRand12345(rand) + 1;
                        if (ind.Dolgi > 5)
                        {
                            sta = State.f;
                        }
                        else if (ind.Sleep > 5)
                        {
                            sta = State.f;
                        }
                        else
                        {
                            ind.PassedLabs += getRand12345(rand)+1;
                            sta = State.passLabs;
                            ind.Days += 1;
                        }
                        break;

                    case State.unreal:
                        pictureBox1.Image = new Bitmap("C:\\Users\\admin\\OneDrive\\Рабочий стол\\vbdc\u007fmivs\\Глотова\\MIVS3\\MIVS3\\imgs\\jhQVNLgcKnM.jpg");
                        sta = State.unreal;
                        ind.Dolgi += getRand12345(rand);
                        ind.Days += getRand12345(rand) + 5;
                        if (ind.Dolgi >= 5)
                        {
                            sta = State.f;
                        }
                        else
                        {
                            sta = State.s;
                            ind.Days += 1;
                        }
                        break;
                   
                }

                Thread.Sleep(1000);
                this.Invoke((MethodInvoker)delegate {
                    if (sta != State.f) PrintState(sta);
                    else PrintState(sta);
                    ChangeForm(ind.Days,ind.Dolgi,ind.Sleep,ind.PassedLabs);
                });
                
            }
        }

        private void b_start_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Thread t = new Thread(letsStart);
            t.Start();
        }
    }
}
