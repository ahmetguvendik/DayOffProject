using DayOfProject.Context;
using DayOfProject.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayOfProject
{
    public partial class Form2 : Form
    {
        ProjectDbContext dbContext = new ProjectDbContext();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User()
                {
                    TC = Int32.Parse(textBox1.Text),
                    Name = textBox2.Text,
                    UserName = textBox3.Text,
                    Email = textBox4.Text,
                    Password = textBox5.Text,
                    ConfirmPassword = textBox6.Text,
                    Role = "Member"

                };
                if (textBox5.Text == textBox6.Text)
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    MessageBox.Show("Kayit Olma Islemi Basarili");
                }

                MessageBox.Show("Sifre Uyusmuyor");
                var dayOff = new DayOff()
                {
                    Number = 30,
                    UserId = user.Id,
                };


                dbContext.DayOffs.Add(dayOff);
                dbContext.SaveChanges();


                ;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox5.PasswordChar = '*';
            textBox6.PasswordChar = '*';
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
