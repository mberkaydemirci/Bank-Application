using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace nesnefinal
{
    public partial class Panel2 : Form
    {
        Point point1 = new Point(0, 0);
        Point point2 = new Point(1, 1);
        int alıcıiban, satıcıiban;
        int baslax, baslay;
        Hesap1 müşteri1 = new Hesap1(326785, "İsmail", "Borazan", "TR610003200013900000326785", 350,
    " ", 0, "TR300003200016420000326785", 8000.0);
        Hesap1 müşteri2 = new Hesap1(400129, "Kamile", "Hurşitgiloğulları", "TR610008324560000000400129"
            , 2980.45, "", 0, "", 0);
        Hesap1 müşteri3 = new Hesap1(388000, "Zebercet", "Bak", "TR610007222250001200388000", 19150.00
            , "TR300008222266600002388000", 2850.00, "TR300007222249000001388000", 52.93);
        Hesap1 müşteri4 = new Hesap1(201005, "Naz Gül", "Uçan", "TR610032455466661200201005",
            666.66, "TR300032455410080003201005", 10000.00, "", 0);
        int kontrol;
        double kontrol2;
        double para;
        public Panel2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Panel2_Load(object sender, EventArgs e)
        {
            try
            {
                string file = "C:\\final\\client.txt";
                StreamReader sr = new StreamReader(file);
                string line1 = sr.ReadLine();
                string[] lines1 = line1.Split(',');
                string line2 = sr.ReadLine();
                string[] lines2 = line2.Split(',');
                string line3 = sr.ReadLine();
                string[] lines3 = line3.Split(',');
                string line4 = sr.ReadLine();
                string[] lines4 = line4.Split(',');
                string line5 = sr.ReadLine();
                string[] lines5 = line5.Split(',');
                string line6 = sr.ReadLine();
                string[] lines6 = line6.Split(',');
                string line7 = sr.ReadLine();
                string[] lines7 = line7.Split(',');
                string line8 = sr.ReadLine();
                string[] lines8 = line8.Split(',');
                sr.Close();
                Hesap1.dönüşüm.Add("dolar", 7.1094);
                Hesap1.dönüşüm.Add("euro", 7.9283);
                int hs = Convert.ToInt32(Form1.tempo);
                int ms1 = müşteri1.hesapNo;
                switch (hs)
                {
                    case 326785:
                        label13.Text = müşteri1.ad;
                        label13.Text += " " + müşteri1.soyad;
                        label3.Text = lines1[1];
                        label4.Text = Convert.ToDouble(lines1[2]) + " TR";
                        label5.Text = müşteri1.ibanusd;
                        if (müşteri1.miktaribanusd == 0)
                        {
                            label6.Text = "";
                        }
                        else
                        {
                            label6.Text = Convert.ToString(müşteri1.miktaribanusd) + " USD";
                        }
                        label8.Text = lines2[2] + " EURO";
                        label7.Text = lines2[1];
                        kontrol = 1;
                        break;
                    case 400129:
                        label13.Text = müşteri2.ad;
                        label13.Text += " " + müşteri2.soyad;
                        label3.Text = lines3[1];
                        label4.Text = Convert.ToDouble(lines3[2]) + ".45" + " TL";
                        label5.Text = müşteri2.ibanusd;
                        if (müşteri2.miktaribanusd == 0)
                        {
                            label6.Text = "";
                        }
                        else
                        {
                            label6.Text = Convert.ToString(müşteri2.miktaribanusd) + " USD";
                        }
                        if (müşteri2.miktaribaneuro == 0)
                        {
                            label8.Text = "";
                        }
                        else
                        {
                            label8.Text = Convert.ToString(müşteri2.miktaribaneuro) + " EURO";
                        }
                        label7.Text = (müşteri2.ibaneuro);
                        kontrol = 2;
                        break;
                    case 388000:
                        label13.Text = müşteri3.ad;
                        label13.Text += " " + müşteri3.soyad;
                        label3.Text = lines4[1];
                        label4.Text = Convert.ToDouble(lines4[2]) + " TL";
                        label5.Text = lines5[1];
                        label6.Text = Convert.ToDouble(lines5[2]) + " USD";
                        label8.Text = Convert.ToDouble(lines6[2]) + ".93" + " EURO";
                        label7.Text = lines6[1];
                        kontrol = 3;
                        break;
                    case 201005:
                        label13.Text = müşteri4.ad;
                        label13.Text += " " + müşteri4.soyad;
                        label3.Text = lines7[1];
                        label4.Text = Convert.ToDouble(lines7[2]) + ".66" + " TL";
                        label5.Text = lines8[1];
                        label6.Text = Convert.ToDouble(lines8[2]) + " USD";
                        if (müşteri4.miktaribaneuro == 0)
                        {
                            label8.Text = "";
                        }
                        else
                        {
                            label8.Text = Convert.ToString(müşteri4.miktaribaneuro) + " EURO";
                        }
                        label7.Text = (müşteri4.ibaneuro);
                        kontrol = 4;
                        break;
                }
                comboBox1.Items.Add(müşteri1.ad + " " + müşteri1.soyad);
                comboBox1.Items.Add(müşteri2.ad + " " + müşteri2.soyad);
                comboBox1.Items.Add(müşteri3.ad + " " + müşteri3.soyad);
                comboBox1.Items.Add(müşteri4.ad + " " + müşteri4.soyad);


                if (kontrol == 1)
                {
                    comboBox3.Items.Add(müşteri1.IBANTR);
                    comboBox3.Items.Add(müşteri1.ibaneuro);
                }
                if (kontrol == 2)
                {
                    comboBox3.Items.Add(müşteri2.IBANTR);
                }
                if (kontrol == 3)
                {
                    comboBox3.Items.Add(müşteri3.IBANTR);
                    comboBox3.Items.Add(müşteri3.ibanusd);
                    comboBox3.Items.Add(müşteri3.ibaneuro);
                }
                if (kontrol == 4)
                {
                    comboBox3.Items.Add(müşteri4.IBANTR);
                    comboBox3.Items.Add(müşteri4.ibanusd);
                }

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DriveNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add(müşteri1.IBANTR);
                comboBox2.Items.Add(müşteri1.ibaneuro);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add(müşteri2.IBANTR);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add(müşteri3.IBANTR);
                comboBox2.Items.Add(müşteri3.ibanusd);
                comboBox2.Items.Add(müşteri3.ibaneuro);
            }
            if (comboBox1.SelectedIndex == 3)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add(müşteri4.IBANTR);
                comboBox2.Items.Add(müşteri4.ibanusd);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string iban = (string)comboBox3.SelectedItem;
            string iban2 = (string)comboBox3.SelectedItem;
            string aliciiban = (string)comboBox2.SelectedItem;
            Hesap1 tempmüşteri2 = İbandanMüşteriBulma(iban);
            if (tempmüşteri2.IBANTR == iban)
            {
                para = tempmüşteri2.miktarIBANTR;
            }

            if (tempmüşteri2.ibanusd == iban)
            {
                para = tempmüşteri2.miktaribanusd;
            }

            if (tempmüşteri2.ibaneuro == iban)
            {
                para = tempmüşteri2.miktaribaneuro;
            }
            kontrol2 = ParaKontrol(para);
            if (kontrol2 == 1)
            {


                Hesap1 tempmüşteri = İbandanMüşteriBulma(iban);
                satıcıiban = ibantürü;
                Hesap1 alicitempmüşteri = İbandanMüşteriBulma(aliciiban);
                alıcıiban = ibantürü;
                if (satıcıiban == 1)
                {
                    tempmüşteri.miktarIBANTR = tempmüşteri.miktarIBANTR - Convert.ToDouble(textBox1.Text);
                    label4.Text = Convert.ToString(tempmüşteri.miktarIBANTR) + " TL";
                    if (alıcıiban == 1)
                    {
                        alicitempmüşteri.miktarIBANTR += Convert.ToDouble(textBox1.Text);
                    }
                    if (alıcıiban == 2)
                    {
                        alicitempmüşteri.miktaribanusd += Convert.ToDouble(textBox1.Text)
                        / Hesap1.dönüşüm["dolar"];
                    }
                    if (alıcıiban == 3)
                    {
                        alicitempmüşteri.miktaribaneuro += Convert.ToDouble(textBox1.Text)
                        / Hesap1.dönüşüm["euro"];
                    }
                }
                if (satıcıiban == 2)
                {
                    tempmüşteri.miktaribanusd = tempmüşteri.miktaribanusd - Convert.ToDouble(textBox1.Text);
                    label6.Text = Convert.ToString(tempmüşteri.miktaribanusd) + " USD";
                    if (alıcıiban == 1)
                    {
                        alicitempmüşteri.miktarIBANTR += Convert.ToDouble(textBox1.Text)
                        * Hesap1.dönüşüm["dolar"];
                    }
                    if (alıcıiban == 2)
                    {
                        alicitempmüşteri.miktaribanusd += Convert.ToDouble(textBox1.Text);
                    }
                    if (alıcıiban == 3)
                    {
                        alicitempmüşteri.miktaribaneuro += Convert.ToDouble(textBox1.Text)
                        * Hesap1.dönüşüm["dolar"] / Hesap1.dönüşüm["euro"];
                    }
                }
                if (satıcıiban == 3)
                {
                    tempmüşteri.miktaribaneuro = tempmüşteri.miktaribaneuro - Convert.ToDouble(textBox1.Text);
                    label8.Text = Convert.ToString(tempmüşteri.miktaribaneuro) + " EURO";
                    if (alıcıiban == 1)
                    {
                        alicitempmüşteri.miktarIBANTR += Convert.ToDouble(textBox1.Text)
                        * Hesap1.dönüşüm["euro"];
                    }
                    if (alıcıiban == 2)
                    {
                        alicitempmüşteri.miktaribanusd += Convert.ToDouble(textBox1.Text)
                        * Hesap1.dönüşüm["euro"] / Hesap1.dönüşüm["dolar"];
                    }
                    if (alıcıiban == 3)
                    {
                        alicitempmüşteri.miktaribaneuro += Convert.ToDouble(textBox1.Text);
                    }
                }

                try
                {
                    FileStream fs = File.Create(@"C:\final\client.txt");
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(müşteri1.hesapNo + "," + müşteri1.IBANTR + "," + müşteri1.miktarIBANTR);
                    sw.WriteLine(müşteri1.hesapNo + "," + müşteri1.ibaneuro + "," + müşteri1.miktaribaneuro);
                    sw.WriteLine(müşteri2.hesapNo + "," + müşteri2.IBANTR + "," + müşteri2.miktarIBANTR);
                    sw.WriteLine(müşteri3.hesapNo + "," + müşteri3.IBANTR + "," + müşteri3.miktarIBANTR);
                    sw.WriteLine(müşteri3.hesapNo + "," + müşteri3.ibanusd + "," + müşteri3.miktaribanusd);
                    sw.WriteLine(müşteri3.hesapNo + "," + müşteri3.ibaneuro + "," + müşteri3.miktaribaneuro);
                    sw.WriteLine(müşteri4.hesapNo + "," + müşteri4.IBANTR + "," + müşteri4.miktarIBANTR);
                    sw.WriteLine(müşteri4.hesapNo + "," + müşteri4.ibanusd + "," + müşteri4.miktaribanusd);
                    label4.Text = Convert.ToString(tempmüşteri.miktarIBANTR) + " TL";
                    label6.Text = Convert.ToString(tempmüşteri.miktaribanusd) + " USD";
                    label8.Text = Convert.ToString(tempmüşteri.miktaribaneuro) + " EURO";
                    sw.Close();
                    fs.Close();
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (DriveNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (NotSupportedException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }
        public double ParaKontrol(double miktar)
        {
            if (miktar >= Convert.ToDouble(textBox1.Text))
            {
                MessageBox.Show("Para Transfer İşlemi Başaralı");
                return 1;
            }
            else
            {
                MessageBox.Show("Yetersiz Bakiye!");
                kontrol2 = 0;
            }
            return 2;
        }
        int ibantürü = 0;
        public Hesap1 İbandanMüşteriBulma(string iban)
        {
            Hesap1[] müşteriler = { müşteri1, müşteri2, müşteri3, müşteri4 };
            foreach (Hesap1 item in müşteriler)
            {
                if (item.IBANTR == iban)
                {
                    ibantürü = 1;
                    return item;
                }
                if (item.ibanusd == iban)
                {
                    ibantürü = 2;
                    return item;
                }
                if (item.ibaneuro == iban)
                {
                    ibantürü = 3;
                    return item;
                }

            }
            return müşteri1;
        }
        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            baslax = e.X;
            baslay = e.Y;

        }
        int zamanlayıcı = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            point1.X = baslax;
            point1.Y = baslay;
            if (point1.X == point2.X && point1.Y == point2.Y)
            {
                zamanlayıcı++;
            }
            else
            {
                zamanlayıcı = 0;
            }

            if (zamanlayıcı >= 240 && zamanlayıcı < 300)
            {
                label14.Text = "GÜVENLİK HATASI !!! \n Ekranda 4 dakikadır aktif değilsiniz: " + (300 - zamanlayıcı) +
                " Saniye sonra program otomatik olarak kapanacaktır";
            }
            else if (zamanlayıcı == 300)
            {
                Application.Exit();
            }
            else if (zamanlayıcı == 0)
            {
                label14.Text = "";
            }

        }
        public Point KonumTutucu(int x, int y)
        {
            Point point1 = new Point(x, y);
            return point1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1500;
            point2.X = baslax;
            point2.Y = baslay;

        }
    }
}
