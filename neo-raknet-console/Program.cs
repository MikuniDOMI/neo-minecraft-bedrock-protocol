using System.Net;
using neo_raknet.Logger;
using neo_raknet;
using neo_raknet.Server;

namespace neoRaknet
{
    public class NetServer()
    {
        public static void Main()
        {
	        var rakServer = new RakServer(new IPEndPoint(IPAddress.Parse("0.0.0.0"), 19132));
	        var start = rakServer.Start();
	        Console.WriteLine(start);
	        Console.ReadLine();
        }
    }
    
};

