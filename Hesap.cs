using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace nesnefinal
{
    public abstract class Hesap
    {
        public int hesapNo;
        public string ad;
        public string soyad;
        public string IBANTR;
        public double miktarIBANTR;

        public Hesap(int hesapNo,string ad,string soyad,string IBANTR,double miktarIBANTR)
        {
            this.hesapNo = hesapNo;
            this.IBANTR = IBANTR;
            this.miktarIBANTR = miktarIBANTR;
            this.soyad = soyad;
            this.ad = ad;
        }

        public Hesap()
        {
            throw new System.NotImplementedException();
        }

        public static string sha512(string şifre)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {

                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(şifre));


                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }


        }


    }
}

