using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Inventory : Form
    {
        class NumberFormatException : Exception
        {
            public NumberFormatException(string quantity) : base(quantity) { }
        }
        class StringFormatException : Exception
        {
            public StringFormatException(string name) : base(name) { }
        }
        class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(string price) : base(price) { }
        }
        private int _Quantity;
        private double _SellPrice;
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        BindingSource showProductList;
        public Inventory()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }
        private void Inventory_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[]
            {
                "Beverages","Bread / Bakery",
                "Canned / Jarred Goods",
                "Dairy",
                "Frozen Goods",
                "Meat",
                "Personal Care",
                "Others"
            };
            foreach (string variableName in ListOfProductCategory)
            {
                comboBoxCategory.Items.Add(variableName);
            }
        }
        public string Product_Name(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    throw new StringFormatException(name);
                }
            }
            catch (StringFormatException sfe)
            {
                MessageBox.Show("String Format input in product name." + sfe.Message);
                    }
            finally
            {
                Console.WriteLine("Input String only in product name.");
            }
            return name;
        }
        public int Quantity(string qty)
        {
            try
            {
                if (!Regex.IsMatch(qty, @"^[0-9]"))
                {
                    throw new NumberFormatException(qty);
                }
            }
            catch (NumberFormatException nfe)
            {
                MessageBox.Show("Number format input in quantity." + nfe.Message); 
            }
            finally
            {
                Console.WriteLine("Numeric Data Type Quantity.");  
            }
            return _Quantity;
            
        }
        public double SellingPrice(string price)
        {
            try
            {
                if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                {
                    throw new CurrencyFormatException(price);
                }

            }
            catch (CurrencyFormatException cfe)
            {
                MessageBox.Show("Currency Format Input In Price" + cfe.Message);
            }
            finally
            {
                Console.WriteLine("Currency Data Type Price.");
            }
            return _SellPrice;
        }
  
        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(textBoxProductName.Text);
            _Category = comboBoxCategory.Text;
            _MfgDate = dateTimePickerMfgdate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dateTimePickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTextBoxDescription.Text;
            _Quantity = Quantity(textBoxQuantity.Text);
            _SellPrice = SellingPrice(textBoxSellPrice.Text);
            showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate, _ExpDate, _SellPrice, _Quantity, _Description));
            dataGridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductList.DataSource = showProductList;
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        
    }
}
