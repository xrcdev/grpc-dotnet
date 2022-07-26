using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcGreeterClient;
using GrpcService1;

namespace GrpcGreeterClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("begin!");
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            using var channel = GrpcChannel.ForAddress("http://10.10.13.137:5056", new GrpcChannelOptions() { Credentials = null });

            var client = new Greeter.GreeterClient(channel);
            var reply = client.SayHello(
                new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}