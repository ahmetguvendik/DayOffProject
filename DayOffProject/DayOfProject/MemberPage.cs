using DayOfProject.Context;
using DayOfProject.Entities;
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
    public partial class MemberPage : Form
    {
        ProjectDbContext dbContext = new ProjectDbContext();
        Form1 form2 = new Form1();

        public MemberPage()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public string userId;
        private void button1_Click(object sender, EventArgs e)
        {
            var request = new Request()
            {
                RequestDay = Int32.Parse(textBox1.Text),
                Statues = "Onay Bekliyor",
                UserId = Int32.Parse(userId)
            };

            dbContext.Requests.Add(request);
            dbContext.SaveChanges();
        }

        public string NameSurname;
        public string KalanIzin;
        private void MemberPage_Load(object sender, EventArgs e)
        {
            label5.Text = NameSurname;
            label2.Text = KalanIzin;
        }
    }
}
