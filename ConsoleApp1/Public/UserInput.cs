using System; 
using System.Text;  

namespace Exercises
{
    /*
     *  User interface contains two types of user input controls: TextInput, which accepts all characters and NumericInput, which accepts only digits.
     *
     *  Implement the class TextInput that contains:
     *
     *  Public method void Add(char c) - adds the given character to the current value
     *  Public method string GetValue() - returns the current value
     *  Implement the class NumericInput that:
     *
     *  Inherits TextInput
     *  Overrides the Add method so that each non-numeric character is ignored
     *  For example, the following code should output "10" 
     *   
     */


    public class TextInput
    {
        protected StringBuilder text;

        public TextInput()
        {
            text = new StringBuilder();
        }

        public virtual void Add(char c)
        {
            text.Append(c);

        }

        public string GetValue()
        {
            return text.ToString();
        }
    }

    public class NumericInput : TextInput
    { 
        public NumericInput()
        {
            base.text = new StringBuilder();
        }
        public override void Add(char c)
        {
            if (char.IsNumber(c))
                text.Append(c);
        }
    }

    public class UserInput
    {
        public static void Run()
        {
            TextInput input = new NumericInput();
            input.Add('1');
            input.Add('a');
            input.Add('0');
            Console.WriteLine(input.GetValue());
        }
    }
}
