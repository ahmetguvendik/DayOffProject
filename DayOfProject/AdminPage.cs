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
                             r.UserId,
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var request = dbContext.Requests.Find(dataGridView2.CurrentRow.Cells[0].Value);
                if (request.Statues != "Onaylandi")
                {
                    request.Statues = "Onaylandi";
                    var user = dbContext.Users.Find(dataGridView2.CurrentRow.Cells[1].Value);
                    var sorgu = from u in dbContext.Users
                                join d in dbContext.DayOffs on user.Id equals d.UserId
                                select new
                                {
                                    d.Id
                                };
                    var dayOff = dbContext.DayOffs.Where(x => x.UserId == user.Id);
                    var value = dayOff.FirstOrDefault();
                    value.Number = value.Number - request.RequestDay;
                    dbContext.SaveChanges();
                }

                MessageBox.Show("Islem Onaylandi");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var request = dbContext.Requests.Find(dataGridView2.CurrentRow.Cells[0].Value);
                request.Statues = "Reddedildi";
                dbContext.SaveChanges();
                MessageBox.Show("Islem Reddedildi");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
