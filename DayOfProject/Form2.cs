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

        private  void button1_Click(object sender, EventArgs e)
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
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var dayOff = new DayOff()
            {
                Number = 30,
                UserId = user.Id,
            };

          
            dbContext.DayOffs.Add(dayOff);
            dbContext.SaveChanges();

           
  ;
        }

    }
}
