using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nesnefinal
{
    public partial class Form1 : Form,Banlama
    {
        public static string tempo;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }
        bool sayackontrol = false;
        bool sayackontrol2 = false;
        bool sayackontrol21 = false;
        bool sayackontrol22 = false;
        bool sayackontrol31 = false;
        bool sayackontrol32 = false;
        bool sayackontrol41 = false;
        bool sayackontrol42 = false;
        int[] kullanıcılar = { 0, 0, 0, 0 };
        bool[] bankontrol = { false, false, false, false };
        Dictionary<int,int> hatalıgiriş = new Dictionary<int,int>();
        private void button1_Click(object sender, EventArgs e)
        {
            
            bool kontrol = false;
            string kullanicişifre, tempşifre,tempkullaniciadi;
            string[] şifre = new string[4];
            string[] kullaniciadi = new string[4];
            tempşifre = textBox2.Text;
            tempkullaniciadi = textBox1.Text;           
            şifre[0] = KullanıcıBilgileri.ŞifreTutucu();
            şifre[1] = KullanıcıBilgileri.ŞifreTutucu();
            şifre[2] = KullanıcıBilgileri.ŞifreTutucu();
            şifre[3] = KullanıcıBilgileri.ŞifreTutucu();
            kullaniciadi[0] = KullanıcıBilgileri.KullaniciAdi();
            kullaniciadi[1] = KullanıcıBilgileri.KullaniciAdi();
            kullaniciadi[2] = KullanıcıBilgileri.KullaniciAdi();
            kullaniciadi[3] = KullanıcıBilgileri.KullaniciAdi();
            kullanicişifre = Hesap.sha512(tempşifre);
            if (File.Exists(@"C:\final\BanListesi.txt"))
            {
                try
                {
                    string[] dosyaokuma = System.IO.File.ReadAllLines(@"C:\final\BanListesi.txt");
                    int i = 0;                  
                    foreach (string item in dosyaokuma)
                    {
                        string[] item2 = item.Split(',');
                        DateTime dt2 = Convert.ToDateTime(item2[1]);
                        DateTime dt = DateTime.Now;
                        TimeSpan fark = dt2.AddHours(24) - dt;
                        if (fark.TotalHours < 0)
                        {
                            
                            var file = new List<string>(System.IO.File.ReadAllLines(@"C:\final\BanListesi.txt"));
                            file.RemoveAt(i); 
                            File.WriteAllLines(@"C:\final\BanListesi.txt", file.ToArray());
                            MessageBox.Show("Programı tekrar açın. Banınız kalkmış olacaktır");
                        }                       
                        if (item2[0] == tempkullaniciadi)
                        {
                            for (int p = 0; p < kullanıcılar.Length; p++)
                            {
                                if (kullaniciadi[p] == tempkullaniciadi)
                                {
                                    bankontrol[p] = true;
                                }
                            }
                            MessageBox.Show("Hesabınız 24 saat boyunca banlanmıştır.\nBanın kalkmasına kalan süre:"+
                              " "  + fark.Hours+":"+fark.Minutes+":"+fark.Seconds);
                            
                        }
                        i++;
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
            for (int i = 0; i < şifre.Length; i++)
            {
                if (tempkullaniciadi == kullaniciadi[i] && !bankontrol[i])
                {
                    if (tempkullaniciadi == kullaniciadi[0]) kullanıcılar[0]++;
                    if (kullanıcılar[0] % 4 == 0)
                    {
                        kullanıcılar[0] = 1;
                    } 
                    if (tempkullaniciadi == kullaniciadi[1]) kullanıcılar[1]++;
                    if (kullanıcılar[1] % 4 == 0)
                    {
                        kullanıcılar[1] = 1;
                    }
                    if (tempkullaniciadi == kullaniciadi[2]) kullanıcılar[2]++;
                    if (kullanıcılar[2] % 4 == 0)
                    {
                        kullanıcılar[2] = 1;
                    }
                    if (tempkullaniciadi == kullaniciadi[3]) kullanıcılar[3]++;
                    if (kullanıcılar[3] % 4 == 0)
                    {
                        kullanıcılar[3] = 1;
                    }
                    if (şifre[i] == kullanicişifre)
                    {               
                    tempo = kullaniciadi[i];
                    this.Hide();
                    Panel2 pn2 = new Panel2();
                    pn2.Show();
                    kontrol = true;
                    }
                }                
            }
            if(tempkullaniciadi != kullaniciadi[0] && tempkullaniciadi != kullaniciadi[1]
                && tempkullaniciadi != kullaniciadi[2] && tempkullaniciadi != kullaniciadi[3])
            {
                MessageBox.Show("Bu kullanici adıyla kayıtlı bir kullanici yok");
            }
            
            if (kontrol == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (tempkullaniciadi == kullaniciadi[i])
                    {                   
                    if (kullanıcılar[i] == 1)
                    {   
                        MessageBox.Show("Kullanici hesap numarası ya da parolası yanlış girilmiştir,tekrar deneyiniz.");
                        if (i == 0)
                        {
                            sayackontrol = true;
                        }
                        if (i == 1)
                        {
                            
                            sayackontrol21 = true;
                        }
                        if (i == 2)
                        {
                           
                            sayackontrol31 = true;
                        }
                        if (i == 3)
                        {
                            sayackontrol41 = true;
                        }
                    }
                    if (kullanıcılar[i] == 2)
                    {
                        MessageBox.Show("Kullanici hesap numarası ya da parolası yanlış girilmiştir,tekrar deneyiniz.");
                    }
                    if (kullanıcılar[i] == 3)
                    {
                        if (i == 0)
                        {
                            sayackontrol2 = true;
                        }
                        if (i == 1)
                        {
                            sayackontrol22 = true;
                        }
                        if (i == 2)
                        {
                            sayackontrol32 = true;
                        }
                        if (i == 3)
                        {
                            sayackontrol42 = true;
                        }

                    }
                   

                }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Hesap1 müşteri1 = new Hesap1(326785, "İsmail", "Borazan", "TR610003200013900000326785", 350,
" ", 0, "TR300003200016420000326785", 8000.0);
            Hesap1 müşteri2 = new Hesap1(400129, "Kamile", "Hurşitgiloğulları", "TR610008324560000000400129"
                , 2980.45, "", 0, "", 0);
            Hesap1 müşteri3 = new Hesap1(388000, "Zebercet", "Bak", "TR610007222250001200388000", 19150.00
                , "TR300008222266600002388000", 2850.00, "TR300007222249000001388000", 52.93);
            Hesap1 müşteri4 = new Hesap1(201005, "Naz Gül", "Uçan", "TR610032455466661200201005",
                666.66, "TR300032455410080003201005", 10000.00, "", 0);
            if (Directory.Exists(@"C:\final"))
            {
                try 
                { FileStream fs = File.Create(@"C:\final\client.txt");
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(müşteri1.hesapNo + "," + müşteri1.IBANTR + "," + müşteri1.miktarIBANTR);
                    sw.WriteLine(müşteri1.hesapNo + "," + müşteri1.ibaneuro + "," + müşteri1.miktaribaneuro);
                    sw.WriteLine(müşteri2.hesapNo + "," + müşteri2.IBANTR + "," + müşteri2.miktarIBANTR);
                    sw.WriteLine(müşteri3.hesapNo + "," + müşteri3.IBANTR + "," + müşteri3.miktarIBANTR);
                    sw.WriteLine(müşteri3.hesapNo + "," + müşteri3.ibanusd + "," + müşteri3.miktaribanusd);
                    sw.WriteLine(müşteri3.hesapNo + "," + müşteri3.ibaneuro + "," + müşteri3.miktaribaneuro);
                    sw.WriteLine(müşteri4.hesapNo + "," + müşteri4.IBANTR + "," + müşteri4.miktarIBANTR);
                    sw.WriteLine(müşteri4.hesapNo + "," + müşteri4.ibanusd + "," + müşteri4.miktaribanusd);
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
            else
            {
                Directory.CreateDirectory(@"C:\final");
                try 
                { FileStream fs = File.Create(@"C:\final\client.txt");
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(müşteri1.hesapNo + "," + müşteri1.IBANTR + "," + müşteri1.miktarIBANTR);
                    sw.WriteLine(müşteri1.hesapNo + "," + müşteri1.ibaneuro + "," + müşteri1.miktaribaneuro);
                    sw.WriteLine(müşteri2.hesapNo + "," + müşteri2.IBANTR + "," + müşteri2.miktarIBANTR);
                    sw.WriteLine(müşteri3.hesapNo + "," + müşteri3.IBANTR + "," + müşteri3.miktarIBANTR);
                    sw.WriteLine(müşteri3.hesapNo + "," + müşteri3.ibanusd + "," + müşteri3.miktaribanusd);
                    sw.WriteLine(müşteri3.hesapNo + "," + müşteri3.ibaneuro + "," + müşteri3.miktaribaneuro);
                    sw.WriteLine(müşteri4.hesapNo + "," + müşteri4.IBANTR + "," + müşteri4.miktarIBANTR);
                    sw.WriteLine(müşteri4.hesapNo + "," + müşteri4.ibanusd + "," + müşteri4.miktaribanusd);
                    sw.Close();
                    fs.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 8;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 6;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);        
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar);



        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        double sayac = 0;
        double sayac2 = 0;
        double sayac3 = 0;
        double sayac4 = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Hesap1 müşteri1 = new Hesap1(326785, "İsmail", "Borazan", "TR610003200013900000326785", 350,
" ", 0, "TR300003200016420000326785", 8000.0);
            Hesap1 müşteri2 = new Hesap1(400129, "Kamile", "Hurşitgiloğulları", "TR610008324560000000400129"
                , 2980.45, "", 0, "", 0);
            Hesap1 müşteri3 = new Hesap1(388000, "Zebercet", "Bak", "TR610007222250001200388000", 19150.00
                , "TR300008222266600002388000", 2850.00, "TR300007222249000001388000", 52.93);
            Hesap1 müşteri4 = new Hesap1(201005, "Naz Gül", "Uçan", "TR610032455466661200201005",
                666.66, "TR300032455410080003201005", 10000.00, "", 0);
            timer1.Interval = 1000;
            timer1.Enabled = true;
            
            if (sayac >=0)
            {
            if (sayackontrol == true)
            {
                    
                timer1.Enabled = true;
                sayac++;
                if(sayackontrol2 == true && sayac <= 300)
                {        
                        if (kullanıcılar[0] == 3)
                        {
                            timer1.Stop();
                            MessageBox.Show(müşteri1.hesapNo +"Kullanici Adli hesap 24 saat banlanmıştır");
                            DosyayaYazma(müşteri1.hesapNo);
                        }
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Hesap1 müşteri1 = new Hesap1(326785, "İsmail", "Borazan", "TR610003200013900000326785", 350,
" ", 0, "TR300003200016420000326785", 8000.0);
            Hesap1 müşteri2 = new Hesap1(400129, "Kamile", "Hurşitgiloğulları", "TR610008324560000000400129"
                , 2980.45, "", 0, "", 0);
            Hesap1 müşteri3 = new Hesap1(388000, "Zebercet", "Bak", "TR610007222250001200388000", 19150.00
                , "TR300008222266600002388000", 2850.00, "TR300007222249000001388000", 52.93);
            Hesap1 müşteri4 = new Hesap1(201005, "Naz Gül", "Uçan", "TR610032455466661200201005",
                666.66, "TR300032455410080003201005", 10000.00, "", 0);
            timer2.Interval = 1000;
            timer2.Enabled = true;
            if (sayac2 >= 0)
            {
                if (sayackontrol21 == true)
                {

                    timer2.Enabled = true;
                    sayac2++;
                    if (sayackontrol22 == true && sayac2 <= 300)
                    {
                        if (kullanıcılar[1] == 3)
                        {
                            timer2.Stop();
                            MessageBox.Show(müşteri2.hesapNo + "Kullanici Adli hesap 24 saat banlanmıştır");
                            DosyayaYazma(müşteri2.hesapNo);
                        }
                    }
                }
                if (sayac2 > 300)
                {
                    sayac2 = 0;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Hesap1 müşteri1 = new Hesap1(326785, "İsmail", "Borazan", "TR610003200013900000326785", 350,
" ", 0, "TR300003200016420000326785", 8000.0);
            Hesap1 müşteri2 = new Hesap1(400129, "Kamile", "Hurşitgiloğulları", "TR610008324560000000400129"
                , 2980.45, "", 0, "", 0);
            Hesap1 müşteri3 = new Hesap1(388000, "Zebercet", "Bak", "TR610007222250001200388000", 19150.00
                , "TR300008222266600002388000", 2850.00, "TR300007222249000001388000", 52.93);
            Hesap1 müşteri4 = new Hesap1(201005, "Naz Gül", "Uçan", "TR610032455466661200201005",
                666.66, "TR300032455410080003201005", 10000.00, "", 0);
            timer3.Interval = 1000;
            timer3.Enabled = true;           
            if (sayac3 >= 0)
            {
                if (sayackontrol31 == true)
                {
                    timer3.Enabled = true;
                    sayac3++;
                    if (sayackontrol32 == true && sayac3 <= 300)
                    {

                        if (kullanıcılar[2] == 3)
                        {
                            timer3.Stop();
                            MessageBox.Show(müşteri3.hesapNo + "Kullanici Adli hesap 24 saat banlanmıştır");
                            DosyayaYazma(müşteri3.hesapNo);
                        }
                    }
                }
            }
            if (sayac3 > 300)
            {
                sayac3 = 0;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Hesap1 müşteri1 = new Hesap1(326785, "İsmail", "Borazan", "TR610003200013900000326785", 350,
" ", 0, "TR300003200016420000326785", 8000.0);
            Hesap1 müşteri2 = new Hesap1(400129, "Kamile", "Hurşitgiloğulları", "TR610008324560000000400129"
                , 2980.45, "", 0, "", 0);
            Hesap1 müşteri3 = new Hesap1(388000, "Zebercet", "Bak", "TR610007222250001200388000", 19150.00
                , "TR300008222266600002388000", 2850.00, "TR300007222249000001388000", 52.93);
            Hesap1 müşteri4 = new Hesap1(201005, "Naz Gül", "Uçan", "TR610032455466661200201005",
                666.66, "TR300032455410080003201005", 10000.00, "", 0);
            timer4.Interval = 1000;
            timer4.Enabled = true;
            if (sayac4 >= 0)
            {
                if (sayackontrol41 == true)
                {

                    timer4.Enabled = true;
                    sayac4++;
                    if (sayackontrol42 == true && sayac4 <= 300)
                    {
                        if (kullanıcılar[3] == 3)
                        {
                            timer4.Stop();
                            MessageBox.Show(müşteri4.hesapNo + "Kullanici Adli hesap 24 saat banlanmıştır");
                            DosyayaYazma(müşteri4.hesapNo);
                        }
                    }
                }
            }
            if (sayac4 > 300)
            {
                sayac4 = 0;
            }
        }

        public void DosyayaYazma(int hesapNo)
        {
            if (File.Exists(@"C:\final\BanListesi.txt"))
            {
                try
                {
                    string zaman = DateTime.Now.ToString();
                    string fs = @"C:\final\BanListesi.txt";
                    StreamWriter sw = File.AppendText(fs);
                    sw.WriteLine(hesapNo+","+zaman);
                    sw.Close();                   
                }
                catch (FileNotFoundException e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (DriveNotFoundException e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (NotSupportedException e)
                {
                   MessageBox.Show(e.Message);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                FileStream fs = File.Create(@"C:\final\BanListesi.txt");
                StreamWriter sw = new StreamWriter(fs);
                string zaman = DateTime.Now.ToString();
                sw.WriteLine(hesapNo+","+zaman);
                sw.Close();
                fs.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
