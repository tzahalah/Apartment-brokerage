using Apartment_brokerage.Entities;

namespace Apartment_brokerage
{
    public class DataContext
    {
        public  List<Sellers> Sellers { get; set; }
        public  int countS = 0; 
        public  List<Customers> Customers { get; set; }
        public  int countC=0;
        public  List<Apartments> Apartments { get; set; }
        public  int countA = 0;

        public DataContext()
        {
            Sellers = new List<Sellers>();
            Customers = new List<Customers>();
            Apartments= new List<Apartments>();
        }

    }
}
