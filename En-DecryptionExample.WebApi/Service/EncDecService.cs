using System.Text;
using Effortless.Net.Encryption;

namespace En_DecryptionExample.WebApi.Service
{
    public class EncDecService
    {

       private readonly byte[] key = Encoding.ASCII.GetBytes("1234567890123456");//string to bytes
       private readonly byte[] iv = Encoding.ASCII.GetBytes("1234567890123456");

        public EncDecService(IConfiguration configuration)
        {
            key = Encoding.ASCII.GetBytes(configuration["Security : Key"]!);
            iv = Encoding.ASCII.GetBytes(configuration["Security : IV"]!);
        }

        public string Encrypt(string plainText)
        {
            return Strings.Encrypt(plainText, key, iv);
        }

        public string Decrypt(string plainText)
        {
            return Strings.Decrypt(plainText, key, iv);
        }

       
    }
}
