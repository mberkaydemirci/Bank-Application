using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace nesnefinal
{
    public class Hesap1: Hesap,IUsd,IEuro
    {
        public double miktaribaneuro,miktaribanusd;
        public string ibaneuro,ibanusd;
        public static Dictionary<string, double> dönüşüm = new Dictionary<string, double>();
        public Hesap1(int hesapNo, string ad, string soyad, string IBANTR, double miktarIBANTR) 
            :base(hesapNo,ad,soyad,IBANTR,miktarIBANTR)
        {

        }
        public Hesap1(int hesapNo, string ad, string soyad, string IBANTR, double miktarIBANTR,
            string ibanusd,double miktaribanusd,string ibaneuro,double miktaribaneuro)
            : base(hesapNo, ad, soyad, IBANTR, miktarIBANTR)
        {
            this.ibanusd = IBANUSD(ibanusd);
            this.miktaribanusd = miktarIBANUSD(miktaribanusd);
            this.ibaneuro=IBANEURO(ibaneuro);
            this.miktaribaneuro = miktarIBANEURO(miktaribaneuro);

        }
 

        public string IBANEURO(string ibaneuro)
        {
            return ibaneuro;
        }

        public double miktarIBANEURO(double euro)
        {
            return euro;
        }

        public string IBANUSD(string ibanusd)
        {
            return ibanusd;
        }

        public double miktarIBANUSD(double usd)
        {
            return usd;
        }
    }

}
