using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelResAPI.Services
{
    public class SecurityService
    {
        public static string Encrypt(string key, string toEncrypt, bool useHashing = true)
        {
            byte[] resultArray = null;
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

                if (useHashing)
                {
                    using (MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider())
                    {
                        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    }
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);


                using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = keyArray;
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;
                    ICryptoTransform cTransform = tdes.CreateEncryptor();
                    resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string key, string cipherString, bool useHashing = true)
        {
            byte[] resultArray = null;
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                if (useHashing)
                {
                    using (MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider())
                    {
                        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    }
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);


                using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = keyArray;
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tdes.CreateDecryptor();
                    resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public static string Hasher(string password, string salt)
        {
            SHA256Managed sHA256Managed = new SHA256Managed();
            byte[] bytes = Encoding.UTF8.GetBytes(password + salt);
            byte[] hash = sHA256Managed.ComputeHash(bytes);
            string compHash = Convert.ToBase64String(hash);
            return compHash;
        }
        public static string getSalt()
        {
            var random = new RNGCryptoServiceProvider();
            int maxLength = 16;
            byte[] salt = new byte[maxLength];
            random.GetNonZeroBytes(salt);

            return Convert.ToBase64String(salt);
        }
    }
}
