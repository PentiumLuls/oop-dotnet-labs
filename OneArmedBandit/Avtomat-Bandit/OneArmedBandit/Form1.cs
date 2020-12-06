using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtomat_Bandit
{
    public partial class Form1 : Form
    {
        int balance = 100;
        int bid = 0; // Current bid
        int hasTry = 0;  // If bid was maid
        int win_money = 0;
        bool IsActive = true; //Активность кнопки "Погнали!"

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void dvg1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int dvg = random.Next(8);
            label1.Text = dvg.ToString();
        }

        private void dvg2_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int dvg = random.Next(8);
            label2.Text = dvg.ToString();
        }

        private void dvg3_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int dvg = random.Next(8);
            label3.Text = dvg.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dvg1.Enabled = true; 
            dvg2.Enabled = true;
            dvg3.Enabled = true;
            stop1.Enabled = true;
            stop2.Enabled = true;
            stop3.Enabled = true;
            IsActive = true; 
            button1.Enabled = false;
        }

        private void stop1_Tick(object sender, EventArgs e)
        {
            dvg1.Enabled = false;
            stop1.Enabled = false;
        }

        private void stop2_Tick(object sender, EventArgs e)
        {
            dvg2.Enabled = false;
            stop2.Enabled = false;
        }

        private void stop3_Tick(object sender, EventArgs e)
        {
            hasTry = false;
            dvg3.Enabled = false;
            stop3.Enabled = false;
            Win_Money();
            if (IsActive)
            {
                if (hasTry)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button2.Enabled = true;
                }
            }
        }
        private void Init_Counter(decimal counter)
        {
            bid = Convert.ToInt32(counter); 
            balance = balance - bid;
            label4.Text = "Баланс: $" + balance;
            hasTry = true;
        }

        private void Win_Money()
        {
            if (label1.Text == "0" && label2.Text == "0" && label3.Text == "0") Upd_Win_Money(17);
            if (label1.Text == "1" && label2.Text == "1" && label3.Text == "1") Upd_Win_Money(10);
            if (label1.Text == "2" && label2.Text == "2" && label3.Text == "2") Upd_Win_Money(11);
            if (label1.Text == "3" && label2.Text == "3" && label3.Text == "3") Upd_Win_Money(12);
            if (label1.Text == "4" && label2.Text == "4" && label3.Text == "4") Upd_Win_Money(13);
            if (label1.Text == "5" && label2.Text == "5" && label3.Text == "5") Upd_Win_Money(14);
            if (label1.Text == "6" && label2.Text == "6" && label3.Text == "6") Upd_Win_Money(15);
            if (label1.Text == "7" && label2.Text == "7" && label3.Text == "7") Upd_Win_Money(20);
            if ((label1.Text == "0" && label2.Text == "0") || (label2.Text == "0" && label3.Text == "0")) Upd_Win_Money(7);
            if ((label1.Text == "1" && label2.Text == "1") || (label2.Text == "1" && label3.Text == "1")) Upd_Win_Money(1);
            if ((label1.Text == "2" && label2.Text == "2") || (label2.Text == "2" && label3.Text == "2")) Upd_Win_Money(2);
            if ((label1.Text == "3" && label2.Text == "3") || (label2.Text == "3" && label3.Text == "3")) Upd_Win_Money(3);
            if ((label1.Text == "4" && label2.Text == "4") || (label2.Text == "4" && label3.Text == "4")) Upd_Win_Money(4);
            if ((label1.Text == "5" && label2.Text == "5") || (label2.Text == "5" && label3.Text == "5")) Upd_Win_Money(5);
            if ((label1.Text == "6" && label2.Text == "6") || (label2.Text == "6" && label3.Text == "6")) Upd_Win_Money(6);
            if ((label1.Text == "7" && label2.Text == "7") || (label2.Text == "7" && label3.Text == "7")) Upd_Win_Money(10);
        }
        private void Upd_Win_Money(int number)
        {
            win_money = bid * number; //умножаем ставку на коэффициент получаем кол-во выигранных денег
            DialogResult result = MessageBox.Show("Вы выиграли: $" + win_money, "Поздравляем!", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Выыодим поздравления.
            balance = balance + win_money; //Прибавляем выигрыш к балансу
            label4.Text = "Баланс: $" + balance; //Выводим обновленный балансе
            button1.Enabled = false; //Блокируем кнопку "Погнали!"
            button2.Enabled = true; //Открываем кнопку "Сделать ставку"
            IsActive = false; //Это костыль, может кто-то предложит как от него отказаться ))
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Делайте новую ставку!", "Новая игра", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label6.Text = "Осталось попыток: 0"; // Скидываем оставшиеся попытки.
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Init_Counter(numericUpDown1.Value);
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}