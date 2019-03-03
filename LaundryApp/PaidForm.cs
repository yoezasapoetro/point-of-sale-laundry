using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaundryApp.Model;
using LaundryApp.Devices;

namespace LaundryApp
{
    public partial class PaidForm : Form
    {
        public int OrderId { get; set; }
        public Order order;
        public ReceiptPrinter receiptPrinter;
        long OrderTotal { get; set; }
        long OrderChange { get; set; }
        long OrderPaid { get; set; }

        public PaidForm()
        {
            InitializeComponent();
        }

        public PaidForm(string _OrderId, OrderEntities orderEntities, ReceiptPrinter _printer)
        {
            InitializeComponent();
            OrderId = Convert.ToInt32(_OrderId);
            order = orderEntities.Orders.Find(OrderId);
            receiptPrinter = _printer;
            GetOrderTotal();
        }

        private void GetOrderTotal()
        {
            long total = 0;
            total += order.Price;

            if (order.OrderItems.Count > 0)
            {
                foreach(OrderItem item in order.OrderItems)
                {
                    total += (long)item.ItemPrice;
                }
            }

            OrderTotal = total;
            txtTotal.Text = total.ToString();
        }

        private void PaidForm_Load(object sender, EventArgs e)
        {
            lblOrderId.Text = Transformer.GenerateInvoice(OrderId);
        }
        
        private void btnPaid_Click(object sender, EventArgs e)
        {
            DialogResult printResult = MessageBox.Show("Print Order Receipt?", "Order!", MessageBoxButtons.YesNo);
            if (printResult == DialogResult.Yes)
            {
                receiptPrinter.SetOrderDetail = order;
                receiptPrinter.PrintPaidOrder(OrderPaid, OrderTotal, OrderChange);
            }

            Close();
            Dispose();
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            int paid = 0;
            if (txtTotal.Text.Length > 0)
            {
                if (txtPaid.Text.Length > 0)
                {
                    paid = Convert.ToInt32(txtPaid.Text);
                    OrderPaid = (long)paid;
                    OrderChange = OrderPaid - OrderTotal;

                    if (OrderChange >= 0)
                    {
                        txtChange.Text = OrderChange.ToString();
                    }
                }
            }
            else
            {
                txtChange.Text = "0";
            }
        }

        private void txtPaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPaid.PerformClick();
            }
        }
    }
}
