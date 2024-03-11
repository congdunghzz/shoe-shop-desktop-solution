using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using DTO;
using BLL;

namespace ShoesRetailClient
{
    public class Program
    {



        static void Main(string[] args)
        {
            BLL_Employees employeeAccess = new BLL_Employees();
            BLL_Report reportAccess = new BLL_Report();
            BLL_Productions prodAccess = new BLL_Productions();
            BLL_ImportDetails importAccess = new BLL_ImportDetails();
            BLL_Orders OrderAccess = new BLL_Orders();
            List<DTO_ImportDetails> imports = new List<DTO_ImportDetails>();
            DTO_ImportDetails imp = new DTO_ImportDetails("imp001", "Công ty may Việt Thành", 1400, DateTime.Parse("12/12/2022"), 5, "emp002", "pro002");
            DTO_Productions pro = new DTO_Productions("pro012", "Bitis Hunter", 1950, "Vải", 0, 0);
            DTO_Orders order = new DTO_Orders("ord001",DateTime.Parse("3/6/2021"),"Lê Công Dụng", "0123456789", 0, "emp002");
            DTO_OrderDetails orderDetail = new DTO_OrderDetails("ord005", "pro008", 19);
            DTO_Employees emp = new DTO_Employees("emp002", "Lê Văn B", "Nhân Viên", "aaa@gmail.com", DateTime.Parse("12/02/2000"), "0123", 5000);
            TcpChannel channel = new TcpChannel(8080);
            ChannelServices.RegisterChannel(channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(BLL_Productions), "BLL_Productions", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(BLL_ImportDetails), "BLL_ImportDetails", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(BLL_Employees), "BLL_Employees", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(BLL_Orders), "BLL_Orders", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(BLL_Report), "BLL_Report", WellKnownObjectMode.Singleton);


            /*
                        List<DTO_Productions> pros = prodAccess.LoadProduct();
                        foreach(DTO_Productions item in pros)
                        {
                            Console.WriteLine(item.ProdName);
                        }*/

            //Console.WriteLine(OrderAccess.DeleteOrderDetail(orderDetail));

            Console.WriteLine("Server is running....");
            
            Console.ReadLine();






        }
    }
}

