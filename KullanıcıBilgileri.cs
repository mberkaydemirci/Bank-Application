using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nesnefinal
{
    class KullanıcıBilgileri
    {
        static int i = 0;
        
        public static string ŞifreTutucu(){
            if (i % 4 == 0)
            {
                i = 0;
            }
            string[] lines = new string[4];
            try
            {
                lines = System.IO.File.ReadAllLines(@"C:\final\auth.txt");
                string temp = lines[i];
                string[] temp2 = temp.Split(',');
                string şifre = temp2[1];
                i++;
                return şifre;
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
            return "";
        }
        public static string ŞifreDönüştürücü(string kullanicişifre)
        {
            
            return kullanicişifre;
        }
        public static string KullaniciAdi()
        {
            if (i % 4 == 0)
            {
                i = 0;
            }
            string[] lines = new string[4];
            try
            {
                lines = System.IO.File.ReadAllLines(@"C:\final\auth.txt");
                string temp = lines[i];
                string[] temp2 = temp.Split(',');
                string kullaniciadi = temp2[0];
                i++;
                return kullaniciadi;
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
            return "";
            
        }
    }
}
