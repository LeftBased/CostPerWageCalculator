using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization; //for IsNumeric() extension
namespace CostPerWageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string cpw_ver = "0.01";
            Console.Title = "CostPerWage Calculator - version: " + cpw_ver;
            Console.WriteLine("Welcome to CPW Calculator.\nIt's pretty simple to use. Just type in a price like 14.99 and hit enter!");
            cpw_init();

            Console.WriteLine("Continue?");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("Enter a numerological number (ie: 14.99)");
                cpw_init();
            }
            else if (Console.ReadLine() == "n")
            {
                Console.WriteLine("Thanks for using! Press anything to exit!");
                Console.ReadLine();
            }
        } //end of main


        static void cpw_init()
        {
            string cpw_input = "";
           
            cpw_input = Console.ReadLine();
            if (cpw_input.IsNumeric() == false)//cpw_input.All(char.IsDigit))
            {
                Console.WriteLine("error - enter a valid number");
                cpw_init();
            }
            else if (cpw_input.IsNumeric() == true)
            {
                cpw_calc(cpw_input);
            }
            else if (String.IsNullOrEmpty(cpw_input))
            {
                cpw_init();
            }
        } //end of cpw_init
        static void cpw_calc(string MyNumber)
        {
            decimal ProductCost;
            decimal CostPerDay;
            decimal CostPerHour;
            decimal CostPerMinute;

            string cpw_input;
            cpw_input = MyNumber;

            ProductCost = Convert.ToDecimal(cpw_input);
            CostPerDay = Convert.ToDecimal(Math.Round(ProductCost / 30, 2));
            CostPerHour = Convert.ToDecimal(Math.Round(ProductCost / 30 / 24, 2));
            CostPerMinute = Convert.ToDecimal(Math.Round(ProductCost / 30 / 24 / 60, 4));
            Console.WriteLine("Cost per Day:\r\n" + CostPerDay + "\r\nCost per Hour:\r\n" + CostPerHour + "\r\nCost per Minute:\r\n" + CostPerMinute);
            Console.ReadLine();
        }

    } //end of class
    public static class Extensions
    {
        /// <summary>
        /// Returns true if string is numeric and not empty or null or whitespace.
        /// Determines if string is numeric by parsing as Double
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style">Optional style - defaults to NumberStyles.Number (leading and trailing whitespace, leading and trailing sign, decimal point and thousands separator) </param>
        /// <param name="culture">Optional CultureInfo - defaults to InvariantCulture</param>
        /// <returns></returns>
        public static bool IsNumeric(this string str, NumberStyles style = NumberStyles.Number,
            CultureInfo culture = null)
        {
            double num;
            if (culture == null) culture = CultureInfo.InvariantCulture;
            return Double.TryParse(str, style, culture, out num) && !String.IsNullOrWhiteSpace(str);
        }
    }
} //end of namespace