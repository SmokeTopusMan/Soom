using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Soom_Client
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint;
            if (args.Length > 0)
            {
                try
                {
                    iPEndPoint = new IPEndPoint(IPAddress.Parse(args[0]), 13000);
                }
                catch (FormatException)
                {
                    iPEndPoint = new IPEndPoint(IPAddress.Parse("10.0.0.15"), 13000);
                }
            }
            else
            {
                iPEndPoint = new IPEndPoint(IPAddress.Parse("10.0.0.15"), 13000);
            }
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    sock.Connect(iPEndPoint);
                    GetSymetricKey(sock);
                    if (SymmetricEncryption.Aes == null)
                        MessageBox.Show("Failed to make secure communication, GoodBye!");
                    else
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        OpenningScreen openningScreen = new OpenningScreen(sock);
                        MessageBox.Show("Click ENTER To Procede To The App!");
                        Application.Run(openningScreen);
                    }
                    break;
                }
                catch (SocketException)
                {
                    MessageBox.Show("Oh No... Something went wrong, Press OK to proceed!");
                }
            }
        }
        static byte[] ConvertToByteArray(RSAParameters parameters)
        {
            // Create a new byte array to store the RSAParameters
            int keySize = parameters.Modulus.Length;
            int byteArraySize = keySize;
            byte[] byteArray = new byte[byteArraySize];


            // Copy the modulus into the byte array
            Buffer.BlockCopy(parameters.Modulus, 0, byteArray, 0, keySize);

            return byteArray;
        }
        static void GetSymetricKey(Socket sock)
        {
            var rsa = new RSACryptoServiceProvider();
            RSAParameters publicKey = rsa.ExportParameters(false);
            byte[] publicKeyArray = ConvertToByteArray(publicKey);
            byte[] msg = (Encoding.UTF8.GetBytes("KEY" + $"{publicKeyArray.Length:000}")).Concat(publicKeyArray).ToArray();
            for (int i = 0; i < 5; i++)
            {
                sock.Send(msg);
                byte[] data = new byte[2];
                sock.Receive(data, 2, SocketFlags.None);
                if (Encoding.UTF8.GetString(data) == "OK")
                {
                    data = new byte[3];
                    sock.Receive(data, 3, SocketFlags.None);
                    int symmKeyLength = int.Parse(Encoding.UTF8.GetString(data));
                    data = new byte[symmKeyLength];
                    sock.Receive(data);
                    data = rsa.Decrypt(data, false);
                    List<byte[]> keyAndIv = SplitByteArray(data, new byte[] { 35, 35, 35 });
                    SymmetricEncryption.Aes = Aes.Create();
                    SymmetricEncryption.Aes.Key = keyAndIv[0];
                    SymmetricEncryption.Aes.IV = keyAndIv[1];
                    sock.Send(Encoding.UTF8.GetBytes("OK"));
                    return;
                }
            }
        }
        private static int SearchSequence(byte[] source, byte[] sequence)
        {
            if (sequence == null || source == null)
                throw new ArgumentNullException();
            if (sequence.Length > source.Length || sequence.Length == 0 || source.Length == 0)
                return -1;
            for(int i = 0; i < source.Length - sequence.Length + 1; i++)
            {
                if (source.Skip(i).Take(sequence.Length).SequenceEqual(sequence))
                {
                    return i;
                }
            }
            return -1;
        }
        public static List<byte[]> SplitByteArray(byte[] source, byte[] sequence)
        {
            int index = SearchSequence(source, sequence);
            List<byte[]> returnList = new List<byte[]>
            {
                new byte[32],
                new byte[16]
            };
            Array.Copy(source, returnList[0], index);
            Array.Copy(source, index + sequence.Length, returnList[1], 0, source.Length - index - sequence.Length);
            return returnList;
        }
    }
}
