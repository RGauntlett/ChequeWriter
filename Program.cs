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

                    
                    //check if there is 1 cent
                    if (Int32.Parse(splitString[1]) == 1)
                    {
                        cents =  "one cent";
                    }
                    // send the cents string to be converted
                    else
                    {
                        
                        cents = converterAgain(splitString[1]) + " cents";
                    }
                    

                    
                    // check if it's only 1 dollar
                    if (Int32.Parse(splitString[0]) == 1)
                    {
                        integers =  "one dollar";
                    }
                    // send the integer string to be converted
                    else
                    {
                        integers = converterAgain(splitString[0])+ "dollars";
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
                    string integers = converterAgain(num) +"dollars";
                    return integers;

                }


        }

        // trying the function by dividing by 3 
        static string converterAgain(string num)
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
                return convertionForHundredsAndOnes(num);
            }
            // if there are only 2 numbers in the string then convert to a word
            else if(num.Length == 2)
            {
                 // if the number is in the teens then check them differently
                if(num[0] == 1)
                {
                    return checkTheTeens(num);
                }
                else 
                {
                    // create a string to store the tenth return
                    string tenths = convertionForTens(num[0].ToString());
                    //create a string to store the second return
                    string ones = convertionForHundredsAndOnes(num[1].ToString());
                    return tenths +" "+ ones;
                }
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
                        // create a string to store the tenth return
                        string tenths = convertionForTens(reversed[0].ToString());
                        //create a string to store the second return
                        string ones = convertionForHundredsAndOnes(reversed[1].ToString());

                        // reset the strings and return the answer
                        holdingString = String.Empty;
                        reversed = String.Empty;
                        
                        
                     
                        // add the answer to the beginning
                        response =  response.Insert(0, tenths +" "+ ones + " ");
                        
                    }
                    else if(i==0 && holdingString.Length == 1)
                    {
                        // reverse the string
                        // reversed = reverseString(holdingString);
                        //create a string to store the second return
                        string ones = convertionForHundredsAndOnes(holdingString[0].ToString());

                        // reset the strings and return the answer
                        holdingString = String.Empty;
                        reversed = String.Empty;
                        
                     
                        response =  response.Insert(0, ones + " ");
                    }
                        
                    // once the string has a length of 3 calculate the string for those 3
                    if (holdingString.Length == 3)
                    {
                        // reverse the string
                        reversed = reverseString(holdingString);
                        
                        // create a string to store the hundredth return
                        string hundredth = convertionForHundredsAndOnes(reversed[0].ToString());
                        // create a string to store the tenth return
                        string tenths = convertionForTens(reversed[1].ToString());
                        //create a string to store the second return
                        string ones = convertionForHundredsAndOnes(reversed[2].ToString());

                        response = response.Insert(0, hundredth + " hundred and " + tenths +" "+ ones + " ");
                        
                        
                        // reset the strings and return the answer
                        holdingString = String.Empty;
                        counter += 1;
                        reversed = String.Empty;
                        
                        

                         
                    }  
                    // get the millions, thousands to print
                    // check if holdingString has cleared and if i is 
                    if(counter == 2 && holdingString.Length == 0 && i!=0)
                    {
                        response = response.Insert(0, "million and ");
                        
                    }
                    if (counter == 1 && holdingString.Length == 0 && i!= 0)
                    {
                        response = response.Insert(0,  "thousand and ");
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
                // create a string to store the tenth return
                string tenths = convertionForTens(strToConvert[1].ToString());
                //create a string to store the second return
                string ones = convertionForHundredsAndOnes(strToConvert[2].ToString());

                return hundredth + " hundred  and " + tenths +" "+ ones;
            }

            else if (strToConvert.Length == 4)
            {
                string thousandth = convertionForHundredsAndOnes(strToConvert[0].ToString());
                // create a string to store the hundredth return
                string hundredth = convertionForHundredsAndOnes(strToConvert[1].ToString());
                 // create a string to store the tenth return
                string tenths = convertionForTens(strToConvert[2].ToString());
                //create a string to store the second return
                string ones = convertionForHundredsAndOnes(strToConvert[3].ToString());


                return thousandth + " thousand " + hundredth + " hundred and " + tenths +" "+ ones;
            }
            else if(strToConvert.Length == 5)
            {
                //create string to hold response
                string response = String.Empty;
                // run a for loop to simplify the code
                for (int i = 0; i<= strToConvert.Length-1; i++)
                {
                    //check if the number is a 0
                    if(strToConvert[i].ToString() != "0")
                    {
                        //if i is divisible by 2 then use the tenths space column 
                        if(i==0 || i==3)
                        {
                            response += convertionForTens(strToConvert[i].ToString())+ " ";
                        }
                        // otherwise use the hundreds and ones
                        else 
                        {
                            response += convertionForHundredsAndOnes(strToConvert[i].ToString()) + " ";
                        }
                        // add thousand to the response at the right time
                      
                        if (i==2)
                        {
                        response+= "hundred and ";
                        }
                        else if(i==1)
                        {
                            response += "thousand ";
                        } 
                    }
                    else if(i==1)
                        {
                            response += "thousand ";
                        } 
                    else if(i == 2)
                    {
                        response+= "and ";
                    }
                    
                }
                return response;
            }
             else if(strToConvert.Length == 6)
            {
                //create string to hold response
                string response = String.Empty;
                // run a for loop to simplify the code
                for (int i = 0; i<= strToConvert.Length-1; i++)
                {
                    //if i is divisible by 2 then use the tenths space column 
                    if(i==1 || i==4)
                    {
                        response += convertionForTens(strToConvert[i].ToString())+ " ";
                    }
                    // otherwise use the hundreds and ones
                    else 
                    {
                        response += convertionForHundredsAndOnes(strToConvert[i].ToString()) + " ";
                    }
                    // add thousand to the response at the right time
                    if(i==2)
                    {
                        response += "thousand ";
                    } 
                    else if (i==0|| i==3)
                    {
                        response+= "hundred and ";
                    }
                    
                }
                return response;
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
