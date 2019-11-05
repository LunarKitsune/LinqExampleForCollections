using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLClassExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnArray_Click(object sender, EventArgs e)
        {
            double[] salesArray = { 1200, 1500, 2000, 1000 };

            var sales1500 = from item in salesArray
                            where item >= 1500
                            select item;

            string output = string.Empty;

            foreach(var saleItem in sales1500)
            {
                output += $"{saleItem:C}\n";
            }

            MessageBox.Show(output, "Sales > 1500");
        }

        private void BtnCollection_Click(object sender, EventArgs e)
        {
            List<Invoice> invoiceList = new List<Invoice>();
            Invoice aInvoice = new Invoice();
            aInvoice.invoiceID = "111";
            aInvoice.custID = "AAA";
            aInvoice.productTotal = 100;
            aInvoice.salesTax = 7;
            aInvoice.invoiceTotal = 107;
            invoiceList.Add(aInvoice);

            Invoice bInvoice = new Invoice();
            bInvoice.invoiceID = "222";
            bInvoice.custID = "BBB";
            bInvoice.productTotal = 200;
            bInvoice.salesTax = 14;
            bInvoice.invoiceTotal = 214;
            invoiceList.Add(bInvoice);

            List<Customer> customerList = new List<Customer>();
            Customer aCustomer = new Customer();
            aCustomer.custID = "AAA";
            aCustomer.custName = "Republic Inc.";
            customerList.Add(aCustomer);

            Customer bCustomer = new Customer();
            bCustomer.custID = "BBB";
            bCustomer.custName = "Master Solutions";
            customerList.Add(bCustomer);

            double total = (from inv in invoiceList select inv.invoiceTotal).Sum();

            MessageBox.Show($"Invoices Total: {total:C}", "Total");

            var invoiceOfCustomer = from invoiceItem in invoiceList
                                    join custItem in customerList
                                    on invoiceItem.custID equals custItem.custID
                                    select new { custItem.custName, invoiceItem.invoiceTotal };

            string output = "Customer Name \t Invoice Amounts\n";

            foreach(var item in invoiceOfCustomer)
            {
                output += $"{item.custName}\t{item.invoiceTotal:C}\n";
            }

            MessageBox.Show(output, "Customer Records");


        }
    }
}
