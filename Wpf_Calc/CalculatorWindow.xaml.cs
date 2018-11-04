using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Wpf_Calc
{

    public struct CalcResult
    {
        public string ResultText { get; set; }
    }

    /// <summary>
    /// Interaction logic for CalculatorWindow.xaml
    /// </summary>
    public partial class CalculatorWindow : Window
    {

                enum EngMet
        {
            feet,
            meters
        }

        enum CalcType
        {
            Geometry,
            Conversion
        }
        public CalculatorWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click event for btn_Num0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Num0_Click(object sender, RoutedEventArgs e)
        {
            InsertCharacter('0');
        }

        /// <summary>
        /// Click event for btn_Num1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Num1_Click(object sender, RoutedEventArgs e)
        {
            InsertCharacter('1');
        }

        /// <summary>
        /// Click event for btn_Num2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Num2_Click(object sender, RoutedEventArgs e)
        {
            InsertCharacter('2');
        }

        /// <summary>
        /// Click event for btn_Num3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Num3_Click(object sender, RoutedEventArgs e)
        {
            InsertCharacter('3');
        }

        /// <summary>
        /// Click event for btn_Num4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Num4_Click(object sender, RoutedEventArgs e)
        {
            InsertCharacter('4');
        }

        /// <summary>
        /// Click event for btn_Num5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Num5_Click(object sender, RoutedEventArgs e)
        {
            InsertCharacter('5');
        }

        /// <summary>
        /// Click event for btn_Num6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Num6_Click(object sender, RoutedEventArgs e)
        {
            InsertCharacter('6');
        }

        /// <summary>
        /// Click event for btn_Num7
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Num7_Click(object sender, RoutedEventArgs e)
        {
            InsertCharacter('7');
        }

        /// <summary>
        /// Click event for btn_Num8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Num8_Click(object sender, RoutedEventArgs e)
        {
            InsertCharacter('8');
        }

        /// <summary>
        /// Click event for btn_Num9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Num9_Click(object sender, RoutedEventArgs e)
        {
            InsertCharacter('9');
        }

        /// <summary>
        /// Click event for btn_DecPoint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_DecPoint_Click(object sender, RoutedEventArgs e)
        {
            InsertCharacter('.');
        }

        /// <summary>
        /// Adds a character to txt_Value1's text value
        /// </summary>
        /// <param name="s"></param>
        public void InsertCharacter(Char s)
        {
            if (s == '.' && txt_Value1.Text.Contains("."))
            {
                int old_index = txt_Value1.Text.IndexOf(".");
                int new_index = txt_Value1.SelectionStart;

                if (old_index != -1)
                {
                    txt_Value1.Text = txt_Value1.Text.Replace(".", "");
                    new_index = (old_index < new_index) ? new_index - 1 : new_index;
                }

                txt_Value1.Text = txt_Value1.Text.Insert(new_index, s.ToString());
            }
            else
            {
                txt_Value1.AppendText(s.ToString());
            }
        }

        /// <summary>
        /// Validates a control's text value as a numeric value
        /// </summary>
        /// <param name="control"></param>
        /// <param name="message"></param>
        /// <returns>bool</returns>
        public bool ValidateNumeric(string str, bool performPreCalcChecks, out string message)
        {
            bool result = false;
            message = "";

            if (performPreCalcChecks || str != "")
            {
                if (str.Contains("-"))
                {
                    message = "This field cannot accept negative values.";
                }
                else if (str.Length - str.Replace(".", "").Length > 1)
                {
                    message = "There are too many decimal points in this field.";
                }
                else if (Regex.IsMatch(str, @"[^\d*\.{0,1}\d*]"))
                {
                    message = "Invalid entry.  Please limit input to numbers and a decimal point.";
                }
                else if (performPreCalcChecks && str == "")
                {
                    message = "Calculation cannot be performed on an empty value.";
                }
                else if (performPreCalcChecks && str == ".")
                {
                    message = "Calculation cannot be performed on a non-numeric value.";
                }
                else
                {
                    if (str != "." && !str.Contains("."))
                    {
                        long i;

                        if (Int64.TryParse(str, out i))
                        {

                            if (i > 2147483647)
                            {
                                message = "Value cannot exceed 2,147,483,647.";
                            }
                            else
                            {
                                result = true;
                            }
                        }
                        else
                        {
                            message = "An error occurred.  Please check your value and try again.";
                        }
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Click event for btn_Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Click event for btn_Calculate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Calculate_Click(object sender, EventArgs e)
        {
            if (txt_Value1.Text != null && (rb_CalcAreaFromRadius.IsChecked.Value == true || rb_CalcAreaFromSide.IsChecked.Value == true || rb_CalcIntToBinary.IsChecked.Value == true || rb_CalcIntToHex.IsChecked.Value == true))
            {
                string numberString = txt_Value1.Text;
                if (!ErrorsExist(true, numberString))
                {
                    if (cmb_CalcType.SelectedItem.ToString().ToLower() == "conversion")
                    {
                        numberString = CleanForConversion(numberString);
                        txt_Value1.Text = numberString;
                    }
                    CalcResult calcResult = new CalcResult();
                    calcResult.ResultText = GenerateResult(numberString);
                    SolutionWindow solutionWindow = new SolutionWindow(calcResult);
                    solutionWindow.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Select a calculation choice radio button to perform a calculation.");
            }
        }

        /// <summary>
        /// Click event for btn_Help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Btn_Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();

            helpWindow.ShowDialog();
        }

        /// <summary>
        /// Click event for btn_Clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            txt_Value1.Clear();
        }

        /// <summary>
        /// Text changed event for txt_Value1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Value1_TextChanged(object sender, TextChangedEventArgs e) //RoutedEventArgs e)
        {
            string str = txt_Value1.Text;//e.RoutedEvent.ToString();
            if (str != null)
            {
                ErrorsExist(false, str);
            }
        }

        /// <summary>
        ///  Determines when to show and hide the error message on txt_Value1
        /// </summary>
        /// <param name="checkForEmpty"></param>
        /// <param name="testValue"></param>
        /// <returns>bool</returns>
        private bool ErrorsExist(bool checkForEmpty, string testValue)
        {
            bool errorExists = true;

            if (!ValidateNumeric(testValue, checkForEmpty, out string error_message))
            {
                tblk_Error.Text = error_message;
                tblk_Error.Visibility = Visibility.Visible;                              
            }
            else
            {
                tblk_Error.Text = "";
                tblk_Error.Visibility = Visibility.Hidden;
                errorExists = false;                
            }

            txt_Value1.BorderBrush = (error_message == ""? System.Windows.Media.Brushes.White : System.Windows.Media.Brushes.Red) ;

            return errorExists;
        }


        /// <summary>
        /// Convert integer to a binary string
        /// </summary>
        /// <param name="baseTenInput"></param>
        /// <returns>string</returns>
        private string ConvertIntegerToBinary(string baseTenInput)
        {
            int baseTenAmount = 0;
            string result = "";
            int remainingAmount = 0;
            int powerOfTwo = 0;

            try
            {
                if (Int32.TryParse(baseTenInput, out baseTenAmount))
                {
                    if (baseTenAmount == 0)
                    {
                        result = "0";
                    }
                    else
                    {
                        // conversion process begins here
                        powerOfTwo = CalcMinPower(baseTenAmount, 2);
                        remainingAmount = baseTenAmount;

                        for (int i = 0; powerOfTwo >= 0; i++)
                        {
                            // Initially, compares value supplied by user against exponent of 2 returned by CalcMaxPower
                            if (remainingAmount >= (Math.Pow(2, powerOfTwo)))
                            {
                                result += "1";
                                remainingAmount -= ((int)Math.Pow(2, powerOfTwo));
                            }

                            // If first value of the above if statement is false, this statement prevents the insertion of a leading zero into the string
                            else if (i != 0)
                            {
                                result += "0";
                            }

                            // Apply a space between every four characters of binary number
                            if (powerOfTwo % 4 == 0 && powerOfTwo > 0 && i != 0)
                            {
                                result += " ";
                            }

                            powerOfTwo--;
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n" +
                    ex.StackTrace, "Exception");
            }
            return result;
        }

        /// <summary>
        /// Convert integer to a hexadecimal string
        /// </summary>
        /// <param name="baseTenInput"></param>
        /// <returns>string</returns>
        private string ConvertIntegerToHex(string baseTenInput)
        {
            string result = "";

            try
            {
                result = int.Parse(baseTenInput).ToString("X");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n" +
                    ex.StackTrace, "Exception");
            }
            return result;
        }

        /// <summary>
        /// Calculate the minimum exponent of a given base necessary to contain an integer value
        /// </summary>
        /// <param name="baseTenAmount"></param>
        /// <param name="baseN"></param>
        /// <returns>int</returns>
        public int CalcMinPower(int baseTenAmount, int baseN)
        {
            int p;
            for (p = 0; Math.Pow(baseN, p) < baseTenAmount; p++)
            { }
            return p;
        }

        /// <summary>
        /// Calculate the area of a circle with a given radius
        /// </summary>
        /// <returns>decimal</returns>
        private string CalculateAreaFromCircleRadiusAnswer(string input)
        {
            string result = Math.Round((Math.PI * Math.Pow(double.Parse(input), 2)), 5).ToString();
            return result;
        }

        /// <summary>
        /// Calculate the area of a circle with a given radius
        /// </summary>
        /// <returns>decimal</returns>
        private string CalculateAreaFromSquareSideAnswer(string input)
        {
            string result = Math.Round(Math.Pow(double.Parse(input), 2), 5).ToString();

            return result;
        }

        /// <summary>
        /// Create a string that holds the formatted result of a calculation
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        private string GenerateResult(string input)
        {
            string result = "";

            if (rb_CalcAreaFromRadius.IsChecked.Value == true)
            {
                result = GenerateAreaFromCircleRadiusAnswer(input);
            }
            else if (rb_CalcAreaFromSide.IsChecked.Value == true)
            {
                result = GenerateAreaFromSquareSideAnswer(input);
            }
            else if (rb_CalcIntToBinary.IsChecked.Value == true)
            {
                result = GenerateBinaryFromIntegerAnswer(input);
            }
            else if (rb_CalcIntToHex.IsChecked.Value == true)
            {
                result = GenerateHexFromIntegerAnswer(input);
            }

            return result;
        }

        /// <summary>
        /// Generate a string of text describing the results of a calculation of the area of a circle
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        private string GenerateAreaFromCircleRadiusAnswer(string input)
        {
            string result = "";
            string uOM = cmb_UnitOfMeasure.SelectedItem.ToString();
            string calculatedValue = CalculateAreaFromCircleRadiusAnswer(input).ToString();
            result = $"The area of a circle that has a radius of {input} {uOM} is {calculatedValue} square {uOM}.";
            return result;
        }

        /// <summary>
        /// Generate a string of text describing the results of a calculation of the area of a square
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        private string GenerateAreaFromSquareSideAnswer(string input)
        {
            string result = "";
            string uOM = cmb_UnitOfMeasure.SelectedItem.ToString();
            string calculatedValue = CalculateAreaFromSquareSideAnswer(input).ToString();
            result = $"The area of a square that has a side of {input} {uOM} is {calculatedValue} square {uOM}.";
            return result;
        }

        /// <summary>
        /// Generate a string of text describing the results of a conversion of an integer value to a binary string
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        private string GenerateBinaryFromIntegerAnswer(string input)
        {
            string result = "";
            string calculatedValue = ConvertIntegerToBinary(input);
            result = $"The binary value of {input} is {calculatedValue}.";
            return result;
        }

        /// <summary>
        /// Generate a string of text describing the results of a conversion of an integer value to a hexadecimal string
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        private string GenerateHexFromIntegerAnswer(string input)
        {
            string result = "";
            string calculatedValue = ConvertIntegerToHex(input);
            result = $"The hexadecimal value of {input} is {calculatedValue}.";
            return result;
        }

        private void cmb_CalcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string calcType = cmb_CalcType.SelectedItem.ToString().ToLower();
            ShowHideCalcRadioButtons(calcType);
        }

        /// <summary>
        /// Show and hide the controls in the grp_CalcOptions group box
        /// depending on the selected item in the cmb_CalcType combobox
        /// </summary>
        private void ShowHideCalcRadioButtons(string calcType)
        {
            string baseTenInput = txt_Value1.Text;
            switch (calcType)
            {
                case "geometry":
                    cmb_UnitOfMeasure.Visibility = Visibility.Visible;
                    lbl_UoM.Visibility = Visibility.Visible;
                    rb_CalcAreaFromRadius.Visibility = Visibility.Visible;
                    rb_CalcAreaFromSide.Visibility = Visibility.Visible;
                    rb_CalcIntToBinary.Visibility = Visibility.Hidden;
                    rb_CalcIntToHex.Visibility = Visibility.Hidden;
                    rb_CalcAreaFromRadius.IsChecked = true;
                    break;
                case "conversion":
                    cmb_UnitOfMeasure.Visibility = Visibility.Hidden;
                    lbl_UoM.Visibility = Visibility.Hidden;
                    rb_CalcAreaFromRadius.Visibility = Visibility.Hidden;
                    rb_CalcAreaFromSide.Visibility = Visibility.Hidden;
                    rb_CalcIntToBinary.Visibility = Visibility.Visible;
                    rb_CalcIntToHex.Visibility = Visibility.Visible;
                    rb_CalcIntToBinary.IsChecked = true;
                    break;
            }
        }

        /// <summary>
        /// Removes negative values and decimal points from numeric strings
        /// </summary>
        /// <param name="baseTenInput"></param>
        /// <returns>string</returns>
        private string CleanForConversion(string baseTenInput)
        {
            string result = Math.Round(Math.Abs(double.Parse(baseTenInput))).ToString();

            return result;
        }

        private void txt_Value1_TextInput(object sender, TextCompositionEventArgs e)
        {
            string str = e.RoutedEvent.ToString();
            if (str != null && str != "")
            {
                ErrorsExist(false, str);
            }
        }

        /// <summary>
        /// Initialize the controls on the window when it is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorWindow_Loaded(object sender, RoutedEventArgs e)
        {
            rb_CalcAreaFromRadius.IsChecked = true;
            cmb_UnitOfMeasure.ItemsSource = Enum.GetValues(typeof(EngMet));
            cmb_UnitOfMeasure.SelectedIndex = 0;
            cmb_CalcType.ItemsSource = Enum.GetValues(typeof(CalcType));
            cmb_CalcType.SelectedIndex = 0;
        }

        private void cmb_CalcType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string calcType = cmb_CalcType.SelectedItem.ToString().ToLower();
            ShowHideCalcRadioButtons(calcType);
        }
    }
}
