using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace YdyoOBS.WebUI.Utits
{
    public static class Crypto
    {
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value))
                );
        }

        public static string MD5yapUTF8(string value)
        {
            //byte[] data = Encoding.UTF8.GetBytes(value);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                //texti(girilen parolayı) Encoding.UTF8 in GetBytes() methodu ile bir byte dizisine çevirdik.
                byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
                StringBuilder sb = new StringBuilder();
                foreach (var key in keys)
                {
                    //x2 burda string'e çevirirken vermesini istediğimiz format.
                    //çıktısında göreceğimiz gibi sayılar ve harflerden oluşucaktır.
                    sb.Append(key.ToString("x2").ToLower());
                }
                //oluşturduğumuz string ifadeyi geri döndürdük.
                return sb.ToString();
            }
        }
    }
}
