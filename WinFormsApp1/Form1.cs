namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        Panel parca;
        Panel elma = new Panel();
        List<Panel> yilan = new List<Panel>();

        string yon = "sag";

        private void label3_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label2.Text = "0";
            parca = new Panel();

            parca.Location = new Point(200, 200);
            parca.Size = new Size(20, 20);
            parca.BackColor = Color.Gray;

            yilan.Add(parca);
            panel1.Controls.Add(yilan[0]);

            timer1.Start();
            ElmaOlustur();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int locX = yilan[0].Location.X;
            int locY = yilan[0].Location.Y;

            ElmaYendimi();
            Hareket();
            CarpismaControl();

            if (yon == "sag")
            {
                if (locX < 580)
                {
                    locX += 20;
                }
                else
                {
                    locX = 0;
                }
            }

            if (yon == "sol")
            {
                if (locX > 0)
                {
                    locX -= 20;
                }
                else
                {
                    locX = 580;
                }
            }

            if (yon == "yukari")
            {
                if (locY > 0)
                {
                    locY -= 20;
                }
                else
                {
                    locY = 580;
                }
            }

            if (yon == "asagi")
            {
                if (locY < 580)
                {
                    locY += 20;
                }
                else
                {
                    locY = 0;
                }
            }

            yilan[0].Location = new Point(locX, locY);


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && yon != "sol")
                yon = "sag";

            if (e.KeyCode == Keys.Left && yon != "sag")
                yon = "sol";

            if (e.KeyCode == Keys.Up && yon != "asagi")
                yon = "yukari";

            if (e.KeyCode == Keys.Down && yon != "yukari")
                yon = "asagi";


        }

        void ElmaOlustur()
        {
            Random rnd = new Random();
            int elmaX, elmaY;

            elmaX = rnd.Next(580);
            elmaY = rnd.Next(580);

            elmaX -= elmaX % 20;
            elmaY -= elmaY % 20;

            elma.Size = new Size(20, 20);
            elma.BackColor = Color.Red;
            elma.Location = new Point(elmaX, elmaY);
            panel1.Controls.Add(elma);
        }
        int puan = 0;
        void ElmaYendimi()
        {
            if (yilan[0].Location == elma.Location)
            {
                puan += 20;
                label2.Text = puan.ToString();
                panel1.Controls.Remove(elma);
                ElmaOlustur();
                parcaEkle();
            }
        }

        void parcaEkle()
        {
            Panel ekParca = new Panel();

            ekParca.Size = new Size(20, 20);
            ekParca.BackColor = Color.Gray;
            yilan.Add(ekParca);
            panel1.Controls.Add(ekParca);
        }

        void Hareket()
        {
            for (int i = yilan.Count - 1; i > 0; i--)
            {
                yilan[i].Location = yilan[i - 1].Location;
            }
        }

        void CarpismaControl()
        {
            for (int i = 2; i < yilan.Count; i++)
            {
                if (yilan[0].Location == yilan[i].Location)
                {
                    label4.Visible = true;
                    timer1.Stop();
                    label4.Text = "Kaybettiniz";
                    
                }

            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
