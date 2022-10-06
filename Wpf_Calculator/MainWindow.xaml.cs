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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Calculator
{
    public partial class MainWindow : Window
    {
        string Number1 = "0";
        string Number2;
        string Answer;
        string action;
        bool change_symbol;
        bool answer_Action;
        public MainWindow()
        {
            InitializeComponent();
            result.Text = Number1;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var num = sender as Button;
            if (action == null)
            {
                if (answer_Action == true || Number1 == "0")
                {
                    Number1 = "";
                    answer_Action = false;
                }
                Number1 += num.Content.ToString();
            }
            else
            {
                Number2 += num.Content.ToString();
            }
            Text_Update();
        }

        private void Button_Op_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Number1))
            {

            }
            else
            {
                var act = sender as Button;
                action = act.Content.ToString();
                Text_Update();
            }
        }
        private void Button_Change(object sender, RoutedEventArgs e)
        {
            if (action == null)
            {
                if (change_symbol == false)
                {
                    Number1 = "-" + Number1;
                    Text_Update();
                    change_symbol = true;
                }
                else
                {
                    Number1 = Number1.Replace("-", "");
                    Text_Update();
                    change_symbol = false;
                }
            }
            else
            {
                if (Number2 != null)
                {
                    if (change_symbol == false)
                    {
                        result.Text = result.Text.Replace(Number2, "");
                        Number2 = "-" + Number2;
                        Text_Update();
                        change_symbol = true;
                    }
                    else
                    {
                        result.Text = result.Text.Replace(Number2, "");
                        Number2 = Number2.Replace("-", "");
                        Text_Update();
                        change_symbol = false;
                    }
                }
            }
        }
        private void Button_Answer(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Number2))
            {
            }
            else
            {
                double num1 = Double.Parse(Number1);
                double num2 = Double.Parse(Number2);
                switch (action)
                {
                    case "+":
                        Answer = (num1 + num2).ToString();
                        break;
                    case "-":
                        Answer = (num1 - num2).ToString();
                        break;
                    case "x":
                        Answer = (num1 * num2).ToString();
                        break;
                    case "/":
                        Answer = (num1 / num2).ToString();
                        break;
                }
                Number1 = Answer;
                Number2 = null;
                action = null;
                answer_Action = true;
                Text_Update();
            }
        }
        private void Button_Comma(object sender, RoutedEventArgs e)
        {
            if (action != null && Number2 != null)
            {
                if (Number2.Contains(",") == false)
                {
                    Number2 += ",";
                    Text_Update();
                }
            }
            else
            {
                if (Number1.Contains(",") == false)
                {
                    Number1 += ",";
                    Text_Update();
                }
            }
        }
        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            result.Text = null;
            Number1 = "0";
            Number2 = null;
            action = null;
            result.Text = Number1;
        }
        private void Button_Eraze(object sender, RoutedEventArgs e)
        {
            if (action != null)
            {
                if (Number2 != null && Number2 != "")
                {
                    result.Text = result.Text.Replace(Number2, "");
                    Number2 = Number2.Remove(Number2.Length - 1);
                    result.Text += Number2;
                }
            }
            else if (Number1 != null && Number1 != "")
            {
                Number1 = Number1.Remove(Number1.Length - 1);
                result.Text = Number1;
            }
            Text_Update();
        }
        private void Button_Clean_Entry(object sender, RoutedEventArgs e)
        {
            if (action == null)
            {
                Number1 = "0";
            }
            else
            {
                Number2 = "";
            }
            Text_Update();
        }
        private void Text_Update()
        {
            result.Text = Number1 + action + Number2;
        }
    }
}
