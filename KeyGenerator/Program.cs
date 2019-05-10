using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace KeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] dateBytes = BitConverter.GetBytes(DateTime.Now.Date.ToBinary());
            NetworkInterface networkInterface = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();
            byte[] addressBytes = networkInterface.GetPhysicalAddress().GetAddressBytes();
            int[] convertedAddressBytes = addressBytes.Select((x, index) => (x ^ dateBytes[index]) * 10).ToArray();
            string result = string.Join("-", convertedAddressBytes);

            Console.WriteLine("Cenerated key:");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
