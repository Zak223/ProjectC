using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static bool isUrban(string code)
        {
            if(code[1] != 1){
                return true;
            }else
            {
                return false;
            }
            
        }
        private static bool isValid(string code)
        { 
            if (code.Length == 6)
            {
                String modified = code.Insert(3, " ");
                code = modified;
            }
             if (code[0].ToString().CompareTo("A") >= 0 && code[0].ToString().CompareTo("Z") <= 0)
             {
                if (code[0].ToString() != "D" && code[0].ToString() != "F" && code[0].ToString() != "I" &&
                    code[0].ToString() != "O" && code[0].ToString() != "Q" && code[0].ToString() != "U" &&
                    code[0].ToString() != "W" && code[0].ToString() != "Z")
                {
                    if (isInteger(code[1].ToString()))
                    {
                        if (code[2].ToString().CompareTo("A") >= 0 && code[2].ToString().CompareTo("Z") <= 0)
                        {
                            if (code[2].ToString() != "D" && code[2].ToString() != "F" && code[2].ToString() != "I" &&
                                code[2].ToString() != "O" && code[2].ToString() != "Q" && code[2].ToString() != "U" &&
                                code[2].ToString() != "W" && code[2].ToString() != "Z")
                            {
                                if (code[3].ToString() == " ")
                                {
                                    if (isInteger(code[4].ToString()))
                                    {
                                        if (code[5].ToString().CompareTo("A") >= 0 &&
                                            code[5].ToString().CompareTo("Z") <= 0)
                                        {
                                            if (code[5].ToString() != "D" && code[5].ToString() != "F" &&
                                                code[5].ToString() != "I" &&
                                                code[5].ToString() != "O" && code[5].ToString() != "Q" &&
                                                code[5].ToString() != "U")
                                            {
                                                if (isInteger(code[6].ToString()))
                                                {
                                                    return true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }  
                        }
                    }
                }
                
            }
            
            return false;
            
        }
        private static bool isInteger(string s)
        {
            try
            {
                Convert.ToInt32(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            string temp = "";
            int postalcodes = 0;
            string[] code;
            string[] invalid;
            string[] valid;
            int validcount = 0;
            int invalidcount = 0;
            string[] urban;
            string[] rural;

            
                
            
                do
                {
                    do 
                    { 
                        Console.WriteLine("How many postal codes would you like to enter"); 
                        temp = Console.ReadLine();
                    } while (!isInteger(temp));
                } while (Convert.ToInt32(temp) <= 0);

            postalcodes = Convert.ToInt32(temp);

            code = new string[postalcodes];
            for (int i = 0; i != postalcodes; i++)
            {
                do
                {
                    Console.WriteLine("Please enter a postal code");
                    code[i] = Console.ReadLine();
                } while (code[i].Length != 6 && code[i].Length != 7);
            }

            for (int i = 0; i != postalcodes; i++)
            {
                if (!isValid(code[i]))
                {
                    invalid = new string[i];
                    invalidcount++;
                }
            }
            Console.WriteLine("Urban");
            for (int i = 0; i != postalcodes; i++)
            {
                validcount = 0;
                int j = 0;
                int l = 0;
                if (isValid(code[i]))
                {
                    valid = new string[postalcodes];
                    valid[validcount] = code[i];
                    validcount++;
                    if (isUrban(code[i]))
                    {

                        urban = new string[postalcodes];
                        urban[i] = valid[j];
                        j++;
                        Console.WriteLine(urban[i]);
                    }
                }
            }
            Console.WriteLine("Rural");
            for (int i= 0; i != postalcodes; i++)
            {
                int j = 0;
                int l = 0;
                if (isValid(code[i]))
                {
                    valid = new string[postalcodes];
                    valid[validcount] = code[i];
                    validcount++;
                    if (!isUrban(valid[i]))
                    {
                        
                        rural = new string[postalcodes];
                        rural[i] = valid[j];
                        j++;
                        Console.WriteLine(rural[i]);
                    }

                }
            }
            Console.WriteLine("Invalid");
            for (int i= 0; i != postalcodes; i++)
            {
                
                if (!isValid(code[i]))
                {
                    invalid = new string[postalcodes];
                    Console.WriteLine(code[i]);
                }

               
                
            }
        }
    }
}
