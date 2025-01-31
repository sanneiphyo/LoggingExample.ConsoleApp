// See https://aka.ms/new-console-template for more information
using System.Text;
using Effortless.Net.Encryption;

Console.WriteLine("Hello, World!");

//byte[] key = Bytes.GenerateKey();
//byte[] iv = Bytes.GenerateIV();

//Console.WriteLine("12345678".Length);

byte[] key = Encoding.ASCII.GetBytes("1234567890123456");//string to bytes
byte[] iv = Encoding.ASCII.GetBytes("1234567890123456");

string encrypted = Strings.Encrypt("Secret", key, iv);
Console.WriteLine(encrypted);
string decrypted = Strings.Decrypt(encrypted, key, iv);
Console.WriteLine(encrypted);
Console.ReadLine();

