using System;

namespace ChequeWriter
{
    class Program
    {
        static void Main()
        {
            // check if there are decimals
            Console.Write("please enter a number..");
            string number = Console.ReadLine();
            try
            {
                double errorCheck = Double.Parse(number);
            
                // Make sure that the user enters a valid number
                if (errorCheck <0 || errorCheck >= 1000000000)
                {
                    Console.WriteLine("You have entered an invalid amount, please try again");
                }
                else
                {
                    Console.WriteLine(divideAndConquer(number));
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception Caught:", e);
                Console.WriteLine("Please Try Again:");
            }
            
        }
        

        //create a function to split up the string if there are decimal places
        static string divideAndConquer (string numbers)
        {
            
            // create an empty string for cents and integers
            string strCents = String.Empty;
            string strIntegers = String.Empty;

            // get the index of the "." if it exists
            int index = numbers.IndexOf(".");
            // check if the string contains a "." point
            if (index == -1)
            {
                // if there is no decimal point then send the integers to be converted
                strIntegers += splitUpTheNumbers(numbers); 
                return strIntegers + prepareTheAnswerDollars(numbers) + " zero cents";
            }
            // if there is a decimal point
           else
           {
               string[] dollarsAndCents = numbers.Split(".");
               strIntegers += splitUpTheNumbers(dollarsAndCents[0]);
               strCents += splitUpTheNumbers(dollarsAndCents[1]);
               return strIntegers + prepareTheAnswerDollars(dollarsAndCents[0]) + strCents + prepareTheAnswerCents(dollarsAndCents[1]);
           }
             
        }

        static string prepareTheAnswerDollars(string dollars)
        {
            if(Int32.Parse(dollars)==1)
            {
                return "dollar and";
            }
            else
            {
                return "dollars and";
            }
        }
        static string prepareTheAnswerCents(string cents)
        {
            if(Int32.Parse(cents)==1)
            {
                return "cent";
            }
            else
            {
                return "cents";
            }
        }
        static string splitUpTheNumbers(string dollarsOrCents)
        {
            // create a holding variable to contain each character 
            string holdingStr = String.Empty;

            // create a string to hold the total amount
            string response = String.Empty;

            //create a counting variable
            int counter = 0;

            // loop over the length of i and convert to written word
            for(int i=dollarsOrCents.Length-1; i>=0; i--)
            {          
                holdingStr += dollarsOrCents[i];

                if (i == 0 && holdingStr.Length == 1)
                {
                    response = response.Insert(0, convertToThree(holdingStr));
                }
                else if (holdingStr.Length == 2 && i == 0)
                {
                    response = response.Insert(0, convertToThree(holdingStr));
                }
                else if (holdingStr.Length == 3)
                {
                    string placeHolder = convertToThree(holdingStr);
                    response = response.Insert(0, placeHolder);
                    counter = counter + 1;
                    holdingStr = String.Empty;
                }
                if(counter == 1 && i!=0)
                {
                    response = response.Insert(0, "thousand "); 
                    counter += 1;
                }
                // if counter gets to 2 and i !=0 then we are in the millions
                if(counter == 3 && i != 0)
                {
                    response = response.Insert(0,"million ");
                    counter += 1;
                }  
            }
                            // if the counter gets to 1 and i != 0 then we are in the thousands
                
            return response;
        }

        // create a function to add characters to lengths less than 3
        static string convertToThree(string n)
        {
            string answer = String.Empty;
            //  if n already has 3 characters then convert them
            if (n.Length == 3)
            {
                return numToWordConvertor(n);
            }
            // if n only has 2 characters then add a 0 at the beginning
            else if(n.Length == 2)
            {
                return numToWordConvertor(n += "0");
                
            }
            // if n only has 1 character then add two 0's to the beginning
            else if(n.Length == 1)
            {
                return numToWordConvertor(n += "0" + "0");
            }
            return "";
        }


        // create a function to convert each string of 3 numbers to words
        static string numToWordConvertor(string num)
        {

            // create arrays to hold all of the possible return values
            // hundreds and ones array
            string[] hundredsAndOnes = new string[]{"", "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine "};
            // tenth place arrays
            string[] tenths = new string[]{"", "", "twenty-", "thirty-", "fourty-", "fifty-", "sixty-", "seventy-", "eighty-", "ninety-"}; 
            // create the teen array
            string[] teens = new string[]{"ten ", "eleven ", "twelve ", "thirteen ", "fourteen ", "fifteen ", "sixteen ", "seventeen ", "eighteen ", "nineteen "};
            
            // create a string to hold the response
            string response = String.Empty;
            // Create an array of integers by parsing the individual characters of num and reverse the string to make sure it's the correct order
            int[] intNum = new int[3]{Int16.Parse(num[2].ToString()), Int16.Parse(num[1].ToString()), Int16.Parse(num[0].ToString())};
            
            
            // if the first character of num is not 0 then 
            if(intNum[0] != 0)
            {
                response += hundredsAndOnes[intNum[0]] + "hundred and ";
            }

            // check if the tenth place does not equal 0
            if (intNum[1] != 0 && intNum[1] != 1)
            {
                response += tenths[intNum[1]];

                // check if the oneth place does not equal 0
                if(intNum[2] != 0)
                {
                    response += hundredsAndOnes[intNum[2]];
                }
            }
             // check if the tenth place is 1
            else if(intNum[1] == 1)
            {
                // return the teen string
                response += teens[intNum[2]];
            } 
            else
            {
                response += hundredsAndOnes[intNum[2]];
            }  
            return response;
        }
    }
}
