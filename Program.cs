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
                    Console.WriteLine(Convert(number));
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception Caught:", e);
                Console.WriteLine("Please Try Again:");
            }
            
        }

        static string Convert(string num)
        {
            // create empty strings to hold cents and dollars
            string cents = String.Empty;
            string integers = String.Empty;
            // check if the first character is a "."
            if(num[0].ToString() == ".")
            // add a 0
            {
                num = num.Insert(0,"0");
            }

            // check if there are decimal points
            int index = num.IndexOf(".");

            if (index>-1)
            {
                 // split the array at the "."
                var splitString = num.Split(".");

                // lets deal with integers first
                // check if there is only one number
                if (splitString[0].Length == 1)
                {
                    // check if there only a 0
                    if(splitString[0][0].ToString() == "0")
                    {
                        integers = "zero dollars and ";
                    } 
                    //check if there is only 1 dollar
                    else if(splitString[0][0].ToString() == "1")
                    {
                        integers = "one dollar and ";
                    }
                  
                }   
                //otherwise convert the integers into their written form
                else
                {
                    // send the dollars 
                    integers = converterToThree(splitString[0])+ " dollars";
                }

                // now the cents 
                //check if  we are usine the hundredth space
                // check if the 10th spot is 0
                if (splitString[1].Length == 2 && (splitString[1][0].ToString() != "0"))
                {   
                    // convert cents
                    cents = converterToThree(splitString[1].ToString()) + " cents";
                    
                   
                } 
                //check if the hundredth spot is 1
                else if(splitString[1][0].ToString() == "0")
                {
                    if(splitString[1][1].ToString() == "1")
                    {
                        cents =  "one cent";
                    } 
                    // check if there is 0 cents
                    else if(splitString[1][1].ToString() == "0")
                    {
                        cents = "zero cents";
                    }
                }
                // check if we are only using 1 decimal
                else if(splitString[1].Length == 1)
                {
                    cents = masterConverter("0" + splitString[1].ToString()+"0") + " cents";
                }
                
            return integers + " and " + cents;

        }
        // if there is no decimal then just send the integers to be converted
        else
        {
            // check if only 0 has been entered
            if(double.Parse(num) == 0)
            {
                return "zero dollars";
            }
            else
            {
            // send the integer string to be converted
            integers = converterToThree(num) +" dollars";
            return integers;
            }
            
        }
    }

        // trying the function by dividing by 3 
        static string converterToThree(string num)
        {
            // create empty string to hold 3 numbers
            string holdingString = String.Empty;
            // create a string to store the response
            string response = String.Empty;
            // create a counter for how many times the holding string has emptied
            int counter = 0;
            // if there is only one number in the string then convert to a word
            if(num.Length == 1)
            {
                return masterConverter("0" + "0" + num);
            }
            // if there are only 2 numbers in the string then convert to a word
            else if(num.Length == 2)
            {
                
                    // add a third character to the string to pass to the masterconverter
                    num = num.Insert(0,"0");
                    return masterConverter(num);
                
            }
            // when you have more than 3 numbers in the input
            else
            {
                // create a string to hold the reversed numbers so they print in the correct order
                string reversed = String.Empty;
                // loop over the array and add each number to a string
                for (int i =num.Length-1, j = 0; i>= 0; i--, j++)
                {
                  
                    // create a string to hold the numbers
                    holdingString += num[i];
                   
                    if(i==0 && holdingString.Length == 2)
                    {
                        // reverse the string
                        reversed = reverseString(holdingString);
                        
                        // add a 0 to make 3 characters in the string
                        reversed = reversed.Insert(0, "0");
                        // send the response to the master converter and return it
                        response = response.Insert(0, masterConverter(reversed));

                        // reset the strings and return the answer
                        holdingString = String.Empty;
                        reversed = String.Empty;
                        
                    }
                    else if(i==0 && holdingString.Length == 1)
                    {
                        // reverse the string
                        reversed = reverseString(holdingString);
                        // add two 0's to make 3 characters in the string
                        reversed = reversed.Insert(0, "0" + "0");
                        Console.WriteLine(reversed);
                        // send the response to the master converter and return it
                        response = response.Insert(0, masterConverter(reversed));
                        

                        // reset the strings and return the answer
                        holdingString = String.Empty;
                        reversed = String.Empty;
                        
                     
                    }
                        
                    // once the string has a length of 3 calculate the string for those 3
                    if (holdingString.Length == 3)
                    {
                        // reverse the string
                        reversed = reverseString(holdingString);
                        response = response.Insert(0, masterConverter(reversed));
                        
                        
                        // reset the strings and return the answer
                        holdingString = String.Empty;
                        counter += 1;
                        reversed = String.Empty;
                         
                    }  
                    // get the millions, thousands to print
                    // check if the counter is 2 holdingString has cleared and if i still does not equal 0
                    if(counter == 2 && holdingString.Length == 0 && i!=0)
                    {
                        // append million
                        response = response.Insert(0, " million, ");
                        
                    }
                    // check if the counter is 2 holdingString has cleared and if i still does not equal 0

                    if (counter == 1 && holdingString.Length == 0 && i!= 0)
                    {
                        // append thousand
                        response = response.Insert(0,  " thousand, ");
                    }      

                }
                
            }
            return response;
            
        }

        //write a function to reverse my strings
        static string reverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse( charArray );
            return new string( charArray );
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
                return String.Empty;
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

        static string masterConverter(string n)
        {
            //check if the first digit of the 3 is 0
            if (n[0].ToString()=="0")
            {
                //if it is check if the second is 0
                if(n[1].ToString()=="0")
                {
                    // if it is then print out the conversion
                    return convertionForHundredsAndOnes(n[2].ToString());
                }
                //check if it is a teen
                else if(n[1].ToString()=="1")
                {
                    // if it is use the teen converter
                    return checkTheTeens(n[1].ToString()+n[2].ToString() + " ");
                }
                // otherwise use the tens and ones converter
                else 
                {
                    // create variable to hold the value while both run
                    string placeHolder =  convertionForTens(n[1].ToString());
                    placeHolder += convertionForHundredsAndOnes(n[2].ToString());
                    return placeHolder;
                }
            }
            else 
            {
                // create place holder again
                string placeHolder =  convertionForHundredsAndOnes(n[0].ToString()) + " hundred and ";
                  //if it is check if the second is 0
                if(n[1].ToString()=="0")
                {
                    // if it is then print out the conversion
                    placeHolder += convertionForHundredsAndOnes(n[2].ToString());
                }
                //check if it is a teen
                else if(n[1].ToString()=="1")
                {
                    // if it is use the teen converter
                    placeHolder += checkTheTeens(n[1].ToString()+n[2].ToString() + " ");
                }
                // otherwise use the tens and ones converter
                else 
                {
                    // create variable to hold the value while both run
                    placeHolder +=  convertionForTens(n[1].ToString()) + " ";
                    placeHolder += convertionForHundredsAndOnes(n[2].ToString());
                    
                }
                return placeHolder;
            }
        }



    }
}
