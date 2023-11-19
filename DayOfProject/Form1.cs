using DayOfProject.Context;
using DayOfProject.Entities;

namespace DayOfProject
{
    public partial class Form1 : Form
    {
        ProjectDbContext dbContext = new ProjectDbContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if(dbContext.Users.Where(x =>x.UserName == textBox1.Text && x.Password == textBox2.Text && x.Role=="Member").Count() >0)
            {
                var user = dbContext.Users.FirstOrDefault(x => x.UserName == textBox1.Text);
                var sorgu = from u in dbContext.Users
                            join d in dbContext.DayOffs on user.Id equals d.UserId
                            select new
                            {      
                               d.Number
                            };

                MemberPage mp = new MemberPage();
                mp.NameSurname = user.Name.ToString();
                mp.userId = user.Id.ToString();
                mp.KalanIzin = sorgu.FirstOrDefault().ToString();
                mp.ShowDialog();
               
            }
            else if(dbContext.Users.Where(x => x.UserName == textBox1.Text && x.Password == textBox2.Text && x.Role == "Admin").Count() > 0)
            {
                AdminPage admin = new AdminPage();
                admin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Giris BASARISIZ");
            }
        }
    }
}
