using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf_Calc
{
    /// <summary>
    /// Interaction logic for SolutionWindow.xaml
    /// </summary>
    public partial class SolutionWindow : Window
    {
        public SolutionWindow()
        {
            InitializeComponent();
        }

        public SolutionWindow(string calculatedValue)
        {
            InitializeComponent();
            DisplayResult(calculatedValue);
        }

        public SolutionWindow(CalcResult calculatedValue)
        {
            InitializeComponent();
            DisplayResult(calculatedValue.ResultText);
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Display the calculated result
        /// </summary>
        /// <param name="result"></param>
        public void DisplayResult(TextBox txt)
        {
            tblk_Result.Text = txt.Text;
        }

        /// <summary>
        /// Display the calculated result
        /// </summary>
        /// <param name="result"></param>
        public void DisplayResult(string result)
        {
            tblk_Result.Text = result;
        }

    }
}
