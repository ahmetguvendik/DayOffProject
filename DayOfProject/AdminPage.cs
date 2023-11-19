using DayOfProject.Context;
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
    public partial class AdminPage : Form
    {
        ProjectDbContext dbContext = new ProjectDbContext();
        public AdminPage()
        {
            InitializeComponent();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {

            var sorgu = from u in dbContext.Users
                        join d in dbContext.DayOffs on u.Id equals d.UserId
                        select new
                        {
                            u.TC,
                            u.Name,
                            u.Email,
                            d.Number
                        };

            var sorgu2 = from u in dbContext.Users
                         join r in dbContext.Requests on u.Id equals r.UserId
                         select new
                         {
                             r.Id,
                             u.TC,
                             u.Name,
                             u.Email,
                             r.RequestDay,
                             r.Statues,

                         };

            dataGridView1.DataSource = sorgu.ToList();
            dataGridView2.DataSource = sorgu2.ToList();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var request = dbContext.Requests.Find(dataGridView2.CurrentRow.Cells[0].Value);
            request.Statues = "Onaylandi";
            dbContext.SaveChanges();
        }
    }
}
