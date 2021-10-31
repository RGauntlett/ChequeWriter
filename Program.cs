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
            Console.WriteLine(Convert(number));
        }

        static string Convert(string num)
        {
          
                // check if there are decimal points
                int index = num.IndexOf(".");
                // if there is a decimal then split the string at that point
                if(index>-1)
                {

                    var splitString = num.Split(".");
                    // create empty strings to hold cents and dollars
                    string cents = String.Empty;
                    string integers = String.Empty;
                    {
                        
                    }

                    // send the cents string to be converted
                    //check if there is 1 cent
                    if (Int16.Parse(splitString[1]) == 1)
                    {
                        cents =  "one cent";
                    }
                    else
                    {
                        cents = converter(splitString[1]) + " cents";
                    }
                    

                    // send the integer string to be converted
                    // check if it's only 1 dollar
                    if (Int16.Parse(splitString[0]) == 1)
                    {
                        integers =  "one dollar";
                    }
                    else
                    {
                        integers = converter(splitString[0])+ " dollars";
                        Console.WriteLine(integers);
                        Console.WriteLine(cents);
                        return integers + " and " + cents;
                    }
                    return integers + " and " + cents;
                    
                }
                // if there is no decimal then just send the integers to be converted
                else 
                {
                    // send the integer string to be converted
                    string integers = converter(num) +" dollars";
                    return integers;

                }


        }

        // create a function to convert each string of 3 and cents to their word form
        static string converter(string strToConvert)
        {
            
            // check the length of the string to be converted and then start the conversion
            if (strToConvert.Length == 1)
            {
                
                return convertionForHundredsAndOnes(strToConvert);

            } else if(strToConvert.Length == 2)
            {
                // if the number is in the teens then check them differently
                if(strToConvert[0] == 1)
                {
                    return checkTheTeens(strToConvert);
                }
                else 
                {
                    // create a string to store the tenth return
                    string tenths = convertionForTens(strToConvert[0].ToString());
                    //create a string to store the second return
                    string ones = convertionForHundredsAndOnes(strToConvert[1].ToString());
                    return tenths +" "+ ones;
                }
            } 
            else if(strToConvert.Length == 3)
            {
                // create a string to store the hundredth return
                string hundredth = convertionForHundredsAndOnes(strToConvert[0].ToString());
                // check if there is a 1 in the tenths spot
                // if(strToConvert[1] == "1")
                // {
                //     int teens = 
                // }
                // create a string to store the tenth return
                string tenths = convertionForTens(strToConvert[1].ToString());
                //create a string to store the second return
                string ones = convertionForHundredsAndOnes(strToConvert[2].ToString());

                return hundredth + " hundred " + tenths +" "+ ones;
            }
            else
            {
                return " nothing for a second";
            }
            
        }

        // create functions for individual words
        static string convertionForHundredsAndOnes(string n)
        {
            if(n == "1")
            {
                return "one";
            }
              else if(n == "2")
            {
                return "two";
            }
              else if(n == "3")
            {
                return "three";
            }
              else if(n == "4")
            {
                return "four";
            }
              else if(n == "5")
            {
                return "five";
            }
              else if(n == "6")
            {
                return "six";
            }
              else if(n == "7")
            {
                return "seven";
            }
              else if(n == "8")
            {
                return "eight";
            }
              else if(n == "9")
            {
                return "nine";
            } else 
            {
                return " ";
            }
        }
        static string convertionForTens(string n)
        {
            
            if(n == "2")
            {
                return "twenty";
            }
              else if(n == "3")
            {
                return "thirty";
            }
              else if(n == "4")
            {
                return "fourty";
            }
              else if(n == "5")
            {
                return "fifty";
            }
              else if(n == "6")
            {
                return "sixty";
            }
              else if(n == "7")
            {
                return "seventy";
            }
              else if(n == "8")
            {
                return "eighty";
            }
              else if(n == "9")
            {
                return "ninety";
            }
            else 
            {
                return " ";
            }
        }

        static string checkTheTeens(string n)
        {
            int integer = Int16.Parse(n);
            if (integer == 10)
            {
                return "ten";
            }
            
            else if(integer == 11)
            {
                return "eleven";
            }
            else if(integer == 12)
            {
                return "twelve";
            }
             else if(integer == 13)
            {
                return "thirteen";
            }
             else if(integer == 14)
            {
                return "fourteen";
            }
             else if(integer == 15)
            {
                return "fifteen";
            }
             else if(integer == 16)
            {
                return "sixteen";
            }
             else if(integer == 17)
            {
                return "seventeen";
            }
             else if(integer == 18)
            {
                return "eighteen";
            }
             else if(integer == 19)
            {
                return "nineteen";
            }
            else 
            {
                return " ";
            }
        }



    }
}
