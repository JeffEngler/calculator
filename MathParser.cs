using System;

namespace Calculator

{/// <summary>
/// Parses and evaluates the expression that was input by the user.
/// Note that index number "i" is passed by reference throughout.
/// </summary>
    class MathParser
    {
        /// <summary>
        /// Entry point for the parsing and evaluting alogorithm 
        /// </summary>
        public static double EvalExpression(char[] UserInput)
        {
            return AddSubtract(UserInput, 0);
        }

        /// <summary>
        /// Gets a number from MultiplyDivide, then checks the next character in user input for + or -, 
        /// if neither are found, passes value up to EvalExpression
        /// if + or - is found, gets the next value from MultiplyDivide and carries out the operation, 
        /// then again checks the next character for + or -, rpeating the aforementioned process as neccesary
        /// </summary>
        private static double AddSubtract(char[] UserInput, int i)
        {
            double Term1 = MultiplyDivide(UserInput, ref i);
            while (true)
            {
                char Operator = UserInput[i];
                if (Operator != '+' && Operator != '-')
                    return Term1;
                i++;
                double Term2 = MultiplyDivide(UserInput, ref i);
                if (Operator == '+')
                    Term1 += Term2;
                else
                    Term1 -= Term2;
            }
        }

        /// <summary>
        /// Gets a number from GetValue, then checks the next character in user input for * or /, 
        /// if neither are found, passes value up to AddSubtract
        /// if * or / is found, gets the next value from GetValue and carries out the operation, 
        /// then again checks the next character for * or /, rpeating the aforementioned process as neccesary
        /// </summary>
        private static double MultiplyDivide(char[] UserInput, ref int i)
        {
            double Value1 = GetValue(UserInput, ref i);
            while (true)
            {
                char Operator = UserInput[i];
                if (Operator != '/' && Operator != '*')
                    return Value1;
                i++;
                double Value2 = GetValue(UserInput, ref i);
                if (Operator == '/')
                    //check for division by 0
                    if (Value2 == 0)
                        throw new Exception("Cannot divide by zero.");
                    else
                        Value1 /= Value2;
                else
                    Value1 *= Value2;
            }
        }

        /// <summary>
        /// Reads user input from left to right, returning the first numarical value it finds in the expression
        /// </summary>
        private static double GetValue(char[] UserInput, ref int i)
        {
            //creates an empty string to hold the numarical value
            string Value = string.Empty;
            //while loop excepts "-" only of it is the first character in the value
            //uses ASCII code to except digits 0-9, and also accepts "."
            while (((UserInput[i] == '-' && Value == string.Empty) || (int)UserInput[i] >= 48 && (int)UserInput[i] <= 57) || UserInput[i] == '.')
            {
                //adds accepted characters to the value string
                Value = Value + UserInput[i].ToString();
                i++;
                //checks to see if we area at the end of the user input
                if (i == UserInput.Length)
                {
                    i--;
                    break;
                }
            }
            //converts from string to double, then passes the value up to the MultiplyDivide function
            return double.Parse(Value);
        }       
    }
}


