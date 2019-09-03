using System;
using System.Windows.Forms;
namespace Calculator
{
    /// <summary>
    /// A basic calculator
    /// </summary>
    public partial class Form1 : Form
    {

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Operator Methods
        // These methods provide functunality to the /, X, +, -, and = buttons



        /// <summary>
        /// inserts "/" into the user text box at the position of the user cursor
        /// </summary>
        private void DivideButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("/");
        }

        /// <summary>
        /// inserts "*" into the user text box at the position of the user cursor
        /// </summary>
        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("*");
        }

        /// <summary>
        /// inserts "-" into the user text box at the position of the user cursor
        /// </summary>
        private void SubtractButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("-");
        }

        /// <summary>
        /// inserts "+" into the user text box at the position of the user cursor
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("+");
        }

        /// <summary>
        /// Calls MathParser.EvalExpression to parse and calculate the given expression, 
        /// then handles errors and displays the results
        /// </summary>
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.CalculationResultText.Text = MathParser.EvalExpression(UserInputText.Text.ToCharArray()).ToString();
            }
            catch (Exception ex)
            {
                this.CalculationResultText.Text = ($"***ERROR*** { ex.Message }");
                return;
            }
        }

        #endregion

        #region Number Methods 
        // these methods insert the specified number into the user text box at the position of the user cursor
        
       
        private void ZeroButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("0");

        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("1");
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("2");
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("3");
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("4");
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("5");
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("6");
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("7");
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("8");
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("9");
        }

        #endregion

        #region Back, Clear, and Decimal Methods

        /// <summary>
        /// Deletes the character to the left of the user cursor then moves the curor one space to the left  
        /// </summary>
        private void BackButton_Click(object sender, EventArgs e)
        {
            // remember cursor location
            var selectionStart = this.UserInputText.SelectionStart;
            // check that we aren't at the first space in the string, avoid out-of-range error
            if (selectionStart < 1)
                return;
            // remove character to the left of the cursor
            this.UserInputText.Text = this.UserInputText.Text.Remove(this.UserInputText.SelectionStart - 1, 1);
            // move the cursor one space to the left
            this.UserInputText.SelectionStart = selectionStart - 1;
        }

        /// <summary>
        /// clears the user input text
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            //clears the text from the user input text
            this.UserInputText.Text = string.Empty;
        }

        /// <summary>
        /// inserts "." into the user text box at the position of the user cursor
        /// </summary>
        private void DecimalButtom_Click(object sender, EventArgs e)
        {
            InsertTextValue(".");
        }
        #endregion

        #region Private Helpers

        /// <summary>
        /// inserts a given string into the user text box at the position of the user cursor
        /// then moves cursor one space to the right
        /// </summary>
        private void InsertTextValue(string value)
        {   //remember cursor location
            var selectionStart = this.UserInputText.SelectionStart;
            //insert string at cursor location
            this.UserInputText.Text = this.UserInputText.Text.Insert(this.UserInputText.SelectionStart, value);
            //move cursor one space to the right 
            this.UserInputText.SelectionStart = selectionStart + 1;
        }
    }
}

       #endregion