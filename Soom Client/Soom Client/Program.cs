using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Soom_Client
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("10.0.0.15"), 13000);
            while (true)
            {
                try
                {
                    sock.Connect(iPEndPoint);
                    byte[] communicationKey = GetSymetricKey(sock);
                    if (communicationKey == null)
                        MessageBox.Show("Failed to make secure communication");
                    else
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        OpenningScreen openningScreen = new OpenningScreen(sock, communicationKey);
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
            int exponentSize = parameters.Exponent.Length;
            int byteArraySize = keySize;
            byte[] byteArray = new byte[byteArraySize];


            // Copy the modulus into the byte array
            Buffer.BlockCopy(parameters.Modulus, 0, byteArray, 0, keySize);

            return byteArray;
        }
        static byte[] GetSymetricKey(Socket sock)
        {
            var rsa = new RSACryptoServiceProvider();
            RSAParameters publicKey = rsa.ExportParameters(false);
            byte[] publicKeyArray = ConvertToByteArray(publicKey);
            byte[] msg = (Encoding.UTF8.GetBytes("KEY" + $"{publicKeyArray.Length.ToString("000")}")).Concat(publicKeyArray).ToArray();
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
                    return rsa.Decrypt(data, false);
                }
            }
            return null;
        }

    }
}
