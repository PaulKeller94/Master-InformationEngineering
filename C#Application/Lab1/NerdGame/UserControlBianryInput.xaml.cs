using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
namespace NerdGame
{

    /// <summary>
    /// Interaktionslogik für UserControlBianryInput.xaml
    /// </summary>
    public partial class UserControlBianryInput : UserControl
    {
        public delegate void valueChange(byte newVal);
        public event valueChange changeValue;
        
        private int[] bits = { 0, 0, 0, 0, 0, 0, 0, 0 };
        protected byte dataByte;
        private bool flag = true;

        //public decimal Decimal { get; set; }    
        public byte DataByte
        {
            get => dataByte;
            set
            {
                dataByte = value;
                //set event
                if (changeValue != null) changeValue(dataByte);

                if (flag)
                {
                    bitConverting(value);
                }

                flag = true;
                
            }
        }


        public UserControlBianryInput()
        {
            InitializeComponent();
           
        }

        private void Bit_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton btn)
            {
                btn.Content = 1;
                GetAllBits(btn.Name, 1);
            }
        }

    
        private void Bit_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton btn)
            {
                btn.Content = 0;
                GetAllBits(btn.Name, 0);
            }
        }

        private void GetAllBits(string name, int content)
        {
            flag= false;
            string posString = name.Substring(3);
            int pos = Int16.Parse(posString);
            this.bits[pos] = content;
            string bitsStringArray = string.Join("", this.bits);
            HexRepresentation.Content = "0x" + HexConverted(bitsStringArray);
        }

        private string HexConverted(string strBinary)
        {
            //Decimal = Convert.ToInt32(strBinary, 2);
            string strHex = Convert.ToInt32(strBinary, 2).ToString("X2");
            DataByte = Convert.ToByte(strHex, 16);
            return strHex;
        }

        private void bitConverting(byte databyte)
        {
            int value = dataByte;
            //   string s = Convert.ToString(value, 2); //Convert to binary in a string

            string s = Convert.ToString(value, 2); //Convert to binary in a string

            int[] bits = s.PadLeft(8, '0') // Add 0's from left
                         .Select(c => int.Parse(c.ToString())) // convert each char to int
                         .ToArray(); // Convert IEnumerable from select to Array

            ToggleButton [] buttons = { Bit0, Bit1, Bit2, Bit3, Bit4, Bit5, Bit6, Bit7 };
            for (int i = 0; i < bits.Length; i++)
            {
                var btn = buttons[i];
                if (btn.IsChecked == true)
                {
                    btn.IsChecked = false;
                }

                btn.Content = bits[i];
               

            }
    
            HexRepresentation.Content = "0x"+value.ToString("X2");
        }
    }
}
