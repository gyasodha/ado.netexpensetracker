
using System.Data.SqlClient;
namespace Expensetrackerapplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. View Income");
                Console.WriteLine("4. View Balance");
                Console.WriteLine("Enter Your choice: ");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            SqlConnection con = new SqlConnection("Server=IN-8B3K9S3; database=testdxcdemodb; Integrated Security=true");
                            con.Open();
                            SqlCommand cmd = new SqlCommand($"insert into Expensetracker values(@title, @descr, @amount, @da_te)", con);
                            Console.Write("Enter Title ");
                            string title = Console.ReadLine();
                            Console.Write("Enter Description ");
                            string descr = Console.ReadLine();
                            Console.Write("Enter Amount: ");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter Date(DD/MM/YYYY): ");
                            string da_te = Console.ReadLine();
                            cmd.Parameters.AddWithValue("@title", title);
                            cmd.Parameters.AddWithValue("@descr", descr);
                            cmd.Parameters.AddWithValue("@da_te", da_te);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Transaction added successfully");
                            con.Close();
                            break;
                        }
                    case 2:
                        {
                            SqlConnection con1 = new SqlConnection("Server=IN-8B3K9S3; database=testdxcdemodb; Integrated Security=true");
                            con1.Open();
                            SqlCommand cmd1 = new SqlCommand("select * from Expensetracker where Amount < 0", con1);
                            SqlDataReader rd = cmd1.ExecuteReader();
                            while (rd.Read())
                            {
                                for(int i=0; i<rd.FieldCount; i++) 
                                {
                                    Console.WriteLine($"{rd[i]}");
                                }
                                Console.WriteLine();
                            }
                            con1.Close();
                            break;
                        }
                    case 3:
                        {
                            SqlConnection con2 = new SqlConnection("Server=IN-8B3K9S3; database=testdxcdemodb; Integrated Security=true");
                            con2.Open();
                            SqlCommand cmd2 = new SqlCommand("select * from Expensetracker where Amount > 0", con2);
                            SqlDataReader rd = cmd2.ExecuteReader();
                            while (rd.Read())
                            {
                                for (int i = 0; i < rd.FieldCount; i++)
                                {
                                    Console.WriteLine($"{rd[i]}");
                                }
                                Console.WriteLine();

                            }
                            con2.Close();
                            break;
                        }
                    case 4:
                        {
                            SqlConnection con3 = new SqlConnection("Server=IN-8B3K9S3; database=testdxcdemodb; Integrated Security=true");
                            con3.Open();
                            SqlCommand cmd3 = new SqlCommand("select sum(Amount) from Expensetracker ", con3);
                            SqlDataReader rd = cmd3.ExecuteReader();
                            while (rd.Read())
                            {
                                Console.WriteLine($"Balance  :{rd[0]}");
                            }
                            con3.Close();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Choice Entered");
                            break;
                        }
                }
            }

        }
    }
}