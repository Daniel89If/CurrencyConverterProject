using CurrencyConverterProjectBL.Managers;
using CurrencyConverterProjectDAL;

namespace CurrencyConverterProjectConsol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChartsMng mng = new ChartsMng("f394e9227ad54d00ee3bc3bbabf39c3b");

            // For Backup
            //ChartsMng mng = new ChartsMng("6cd44b2005e12018ebc6985f7c07779e");

            mng.getChartByBaseAndSymbols();

            ReadMng reader = new ReadMng();
            reader.ReadFromFile();
        }
    }
}
