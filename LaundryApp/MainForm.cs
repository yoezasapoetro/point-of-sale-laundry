using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using LaundryApp.Devices;
using LaundryApp.Model;
using MySql.Data.MySqlClient;

namespace LaundryApp
{
    public partial class MainForm : Form
    {
        DigitalScale digitalScale;
        ReceiptPrinter printer;
        OrderEntities orderEntities;
        Order order;
        List<OrderItem> orderItems;
        bool isNewRecord = true;

        delegate void ScaleStreamTextCallback(string scale);

        public MySqlConnection DbConnection
        {
            get
            {
                string connectionString = String.Format("Server=localhost; UID=root; database={0}", "laundryapp");
                return new MySqlConnection(connectionString);
            }
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeScales();
            InitializeReceiptPrint();
        }

        private void InitializeDatabase()
        {
            order = new Order();
            orderItems = new List<OrderItem>();
            orderEntities = new OrderEntities(DbConnection);

            if (!orderEntities.Database.Exists())
            {
                MessageBox.Show("Database not found", "Order!");
                Close();
            }
        }

        private void InitializeReceiptPrint()
        {
            printer = new ReceiptPrinter();
            printer.Initialized();

            bool _printerStatus = false;

            if (printer.ReceiptPrinterInitialized())
            {
                _printerStatus = printer.ReceiptPrinterStatus();
            }

            receiptPrinterStatus.Text = String.Format("Printer: -{0}", _printerStatus ? "Aktif" : "Tidak Aktif");
        }

        private void InitializeScales()
        {
            digitalScale = new DigitalScale();
            digitalScale.Initialize();

            bool _scaleStatus = false;

            if (digitalScale.ScalesInitialized())
            {
                _scaleStatus = digitalScale.ScaleStatus();
                digitalScale.BaseSerialPort().DataReceived += new SerialDataReceivedEventHandler(ScaleStream);
            }

            scaleStatus.Text = String.Format("Timbangan: -{0}", _scaleStatus ? "Aktif" : "Tidak Aktif");
        }

        private void InitializeOrderGridView(List<Order> order)
        {
            dgvOrder.Columns.Clear();

            var btnEditOrder = new DataGridViewButtonColumn();
            var btnRemoveOrder = new DataGridViewButtonColumn();

            btnEditOrder.HeaderText = "Edit";
            btnEditOrder.Name = "btnEditOrder";
            btnEditOrder.ReadOnly = true;
            btnEditOrder.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            btnEditOrder.Text = "Edit";
            btnEditOrder.ToolTipText = "Edit";
            btnEditOrder.UseColumnTextForButtonValue = true;
            btnEditOrder.Width = 60;

            btnRemoveOrder.HeaderText = "Hapus";
            btnRemoveOrder.Name = "btnRemoveOrder";
            btnRemoveOrder.ReadOnly = true;
            btnRemoveOrder.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            btnRemoveOrder.Text = "Hapus";
            btnRemoveOrder.ToolTipText = "Hapus";
            btnRemoveOrder.UseColumnTextForButtonValue = true;
            btnRemoveOrder.Width = 60;

            dgvOrder.DataSource = order;
            dgvOrder.Columns.AddRange(new DataGridViewColumn[]
            {
                btnEditOrder,
                btnRemoveOrder
            });

            int removedColumn = dgvOrder.ColumnCount - 3;
            dgvOrder.Columns.Remove(dgvOrder.Columns[removedColumn]);
        }

        private void InitializeOrderItemGridView(List<OrderItem> orderItem)
        {
            dgvOrderItem.Columns.Clear();

            var btnRemoveOrderItem = new DataGridViewButtonColumn();

            btnRemoveOrderItem.HeaderText = "Hapus";
            btnRemoveOrderItem.Name = "btnRemoveOrderItem";
            btnRemoveOrderItem.ReadOnly = true;
            btnRemoveOrderItem.Text = "Hapus";
            btnRemoveOrderItem.ToolTipText = "Hapus";
            btnRemoveOrderItem.UseColumnTextForButtonValue = true;
            btnRemoveOrderItem.Width = 60;

            dgvOrderItem.DataSource = orderItem;
            dgvOrderItem.Columns.AddRange(new DataGridViewColumn[]
            {
                btnRemoveOrderItem
            });

            int removedColumn = dgvOrderItem.ColumnCount - 2;
            dgvOrderItem.Columns.Remove(dgvOrderItem.Columns[removedColumn]);
        }

        private void ScaleStream(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadLine();
            ScaleStreamText(digitalScale.ParseRegex(indata));
        }

        private void ScaleStreamText(string scale)
        {
            if (txtWeight.InvokeRequired)
            {
                ScaleStreamTextCallback d = new ScaleStreamTextCallback(ScaleStreamText);
                this.Invoke(d, new object[] { scale });
            }
            else
            {
                txtWeight.Text = String.Format("{0}", Double.Parse(scale, CultureInfo.CurrentCulture.NumberFormat) / 1000.0); ;
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenantInfoForm tenantInfo = new TenantInfoForm();
            tenantInfo.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CloseMessage();
            digitalScale.Close();
            Application.Exit();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void CloseMessage()
        {
            DialogResult result = MessageBox.Show("Are you sure to exit application?", "LaundryApp Warning!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
                Dispose();
            }
        }

        private void EnterKeyEvent(KeyEventArgs e, Control nextElementFocus, bool performClick = false)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (performClick)
                {
                    btnAddItem.PerformClick();
                } else
                {
                    nextElementFocus.Focus();
                }
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyEvent(e, dtDateReceived);
        }

        private void dtDateReceived_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyEvent(e, rbServiceTypeStandard);
        }

        private void rbServiceTypeExpress_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyEvent(e, txtUnitPrice);
        }

        private void rbServiceTypeStandard_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyEvent(e, txtUnitPrice);
        }

        private void txtUnitPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnAddOrder.Enabled)
            {
                EnterKeyEvent(e, btnAddOrder);
            }
            else if(btnUpdateOrder.Enabled)
            {
                EnterKeyEvent(e, btnUpdateOrder);
            }
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyEvent(e, txtItemQuantity);
        }

        private void txtItemQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyEvent(e, txtItemPrice);
        }
        
        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            double weight = 0.00, unitPrice = 0.00;

            if (txtUnitPrice.Text.Length > 0)
            {
                unitPrice = Double.Parse(txtUnitPrice.Text);
            }
            else
            {
                txtUnitPrice.Text = "0";
            }

            txtSubTotal.Text = Convert.ToString(weight * unitPrice);
        }

        private void rdStatusFinish_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentActivity(rdStatusFinish);
            btnAddOrder.Enabled = btnUpdateOrder.Enabled = btnPaid.Enabled = !rdStatusFinish.Checked;
            btnFinish.Enabled = rdStatusFinish.Checked;

            if (rdStatusFinish.Checked == true && order.CurrentActivity == rdStatusFinish.Text)
            {
                rdStatusWash.Enabled = rdStatusDry.Enabled = rdStatusIroned.Enabled = false;
            }
        }

        private void rdStatusAccept_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentActivity(rdStatusAccept);
            btnAddOrder.Enabled = rdStatusAccept.Checked;
            btnUpdateOrder.Enabled = btnFinish.Enabled = !rdStatusAccept.Checked;

            rdStatusWash.Enabled = rdStatusDry.Enabled = rdStatusIroned.Enabled = rdStatusFinish.Enabled = rdStatusTaken.Enabled = !rdStatusAccept.Checked;
        }

        private void rdStatusTaken_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentActivity(rdStatusTaken);
            btnAddOrder.Enabled = btnUpdateOrder.Enabled = btnFinish.Enabled = !rdStatusTaken.Checked;
            btnPaid.Enabled = rdStatusTaken.Checked;

            if (rdStatusTaken.Checked == true && order.CurrentActivity == rdStatusTaken.Text)
            {
                rdStatusWash.Enabled = rdStatusDry.Enabled = rdStatusIroned.Enabled = rdStatusFinish.Enabled = !rdStatusTaken.Checked;
            }
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            double weight = 0.00, unitPrice = 0.00;

            if (txtWeight.Text.Length > 0)
            {
                weight = Double.Parse(txtWeight.Text);
            }
            else
            {
                txtWeight.Text = "0";
            }

            if (txtUnitPrice.Text.Length > 0)
            {
                unitPrice = Double.Parse(txtUnitPrice.Text);
            }
            else
            {
                txtUnitPrice.Text = "0";
            }

            txtSubTotal.Text = Math.Ceiling(weight * unitPrice).ToString();
        }

        private void txtItemPrice_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyEvent(e, btnAddItem);
        }
        
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            int qty = 0, unitPrice = 0;

            if (txtItemQuantity.Text.Length > 0)
            {
                qty = Convert.ToInt32(txtItemQuantity.Text);
            }

            if (txtItemPrice.Text.Length > 0)
            {
                unitPrice = Convert.ToInt32(txtItemPrice.Text);
            }

            orderItems.Add(new OrderItem
            {
                ItemName = txtItemName.Text,
                ItemQty = qty,
                ItemPrice = qty * unitPrice
            });

            DialogResult result = MessageBox.Show("Add a new order item?", "Order!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                InitializeOrderItemGridView(orderItems.ToList());

                // Next trigger
                txtItemName.Text = "";
                txtItemName.Focus();
            }
            else
            {
                order.OrderItems = orderItems;
                if (isNewRecord)
                {
                    orderEntities.Orders.Add(order);
                }

                int saveResult = orderEntities.SaveChanges();

                txtItemName.Text = "";
                txtItemPrice.Text = "0";
                txtItemQuantity.Text = "0";

                if (isNewRecord)
                {
                    DialogResult printResult = MessageBox.Show("Print Order Receipt?", "Order!", MessageBoxButtons.YesNo);
                    if (printResult == DialogResult.Yes)
                    {
                        printer.SetOrderDetail = order;
                        printer.PrintAcceptOrder();
                    }

                    RefreshOrderDataSource();
                    DefaultFormState();
                }
                else
                {
                    RefreshOrderItemDataSource();
                    txtCustomerName.Focus();
                }

                MessageBox.Show("Successfully added order", "Order!", MessageBoxButtons.OK);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeDatabase();
            InitializeOrderGridView(orderEntities.Orders.ToList());

            // Form Init
            txtWeight.Text = "0";
            txtUnitPrice.Text = "5500";
            rbServiceTypeStandard.Checked = true;
            rdStatusWash.Enabled = rdStatusDry.Enabled = rdStatusIroned.Enabled = !isNewRecord;
            txtCustomerName.Focus();
        }
        
        private void SetServiceType(RadioButton control)
        {
            if (control.Checked)
            {
                order.ServiceType = control.Text;
            }
        }

        private void SetCurrentActivity(RadioButton control)
        {
            if (control.Checked)
            {
                order.CurrentActivity = control.Text;
            }
        }

        private void RefreshOrderDataSource()
        {
            InitializeOrderGridView(orderEntities.Orders.ToList());
            dgvOrder.Update();
            dgvOrder.Refresh();
        }

        private void RefreshOrderItemDataSource()
        {
            int OrderId = Convert.ToInt32(txtOrderId.Text);
            InitializeOrderItemGridView(orderEntities.OrderItems.Where(i => i.OrderId == OrderId).ToList());
            dgvOrderItem.Update();
            dgvOrderItem.Refresh();
        }

        private bool SaveOrder()
        {
            bool saving = false;

            if (txtCustomerName.Text.Length > 0 && txtWeight.Text != "0")
            {
                order.CustomerName = txtCustomerName.Text;
                order.Date = dtDateReceived.Value.Date;
                order.Weight = Convert.ToDouble(txtWeight.Text);
                order.Price = Convert.ToInt32(txtSubTotal.Text);

                if (order.ServiceType == "" || order.ServiceType == null)
                {
                    order.ServiceType = rbServiceTypeStandard.Text;
                }

                order.CurrentActivity = rdStatusAccept.Text;
                saving = true;
            }
            
            return saving;
        }

        private void rbServiceTypeStandard_CheckedChanged(object sender, EventArgs e)
        {
            SetServiceType((RadioButton)sender);
            txtUnitPrice.Text = "5500";
        }

        private void rbServiceTypeExpress_CheckedChanged(object sender, EventArgs e)
        {
            SetServiceType((RadioButton)sender);
            txtUnitPrice.Text = "6000";
        }

        private void rdStatusWash_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentActivity((RadioButton)sender);
            btnAddOrder.Enabled = isNewRecord;
        }

        private void rdStatusDry_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentActivity((RadioButton)sender);
            btnAddOrder.Enabled = isNewRecord;
        }

        private void rdStatusIroned_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentActivity((RadioButton)sender);
            btnAddOrder.Enabled = isNewRecord;
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridOrder = (DataGridView)sender;
            int OrderId = Convert.ToInt32(dataGridOrder.Rows[e.RowIndex].Cells[0].Value);

            if (e.ColumnIndex == 9 && dataGridOrder.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                isNewRecord = false;
                orderItems = order.OrderItems.ToList();
                GetOrderById(OrderId);

                if (rdStatusFinish.Checked || rdStatusTaken.Checked)
                {
                    itemPanel.Enabled = false;
                }
                else
                {
                    itemPanel.Enabled = true;
                }

                if (order.CurrentActivity == rdStatusAccept.Text)
                {
                    rdStatusWash.Checked = true;
                }

                txtCustomerName.Focus();
            }

            if (e.ColumnIndex == 10 && dataGridOrder.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                DialogResult result = MessageBox.Show("Are you sure to remove #" + OrderId.ToString() + "?", "Order!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //Remove OrderItem data
                    var deletedOrderItem = orderEntities.OrderItems.Where(orderItem => orderItem.OrderId == OrderId);
                    orderEntities.OrderItems.RemoveRange(deletedOrderItem);

                    //Remove Order data
                    var removeOrder = orderEntities.Orders.Find(OrderId);
                    orderEntities.Orders.Attach(removeOrder);
                    orderEntities.Orders.Remove(removeOrder);

                    orderEntities.SaveChanges();

                    MessageBox.Show("Successfully removed order", "Order!");
                }

                RefreshOrderDataSource();
                DefaultFormState();
            }
        }

        private void GetOrderById(int OrderId)
        {
            txtOrderId.ReadOnly = true;

            order = orderEntities.Orders.Find(OrderId);
            txtCustomerName.Text = order.CustomerName;
            txtOrderId.Text = order.OrderId.ToString();
            dtDateReceived.Value = order.Date;

            txtWeight.Text = Convert.ToString(order.Weight);
            txtUnitPrice.Text = Convert.ToString(Math.Ceiling(order.Price / order.Weight));
            txtSubTotal.Text = Convert.ToString(order.Price);
            
            foreach (RadioButton serviceTypeRadio in gbServiceType.Controls)
            {
                SetRadioButtonValueFromDataSource(serviceTypeRadio, order.ServiceType);
            }

            foreach (RadioButton statusRadio in gbStatus.Controls)
            {
                SetRadioButtonValueFromDataSource(statusRadio, order.CurrentActivity);
            }

            rdStatusAccept.Enabled = rdStatusAccept.Checked = false;
            isNewRecord = false;
        }

        private void SetRadioButtonValueFromDataSource(RadioButton radio, string text)
        {
            radio.Checked = radio.Text == text;
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            DefaultFormState();
        }

        private void DefaultFormState()
        {
            orderEntities.Dispose();
            order = new Order();
            orderItems = new List<OrderItem>();

            orderEntities = new OrderEntities(DbConnection);
            InitializeOrderGridView(orderEntities.Orders.AsNoTracking().ToList());
            InitializeOrderItemGridView(orderItems.ToList());

            txtCustomerName.Text = "";
            txtOrderId.Text = "";
            dtDateReceived.Value = DateTimeOffset.Now.Date;
            txtWeight.Text = "0";
            txtUnitPrice.Text = "5500";
            txtSubTotal.Text = "0";
            rbServiceTypeStandard.Checked = rdStatusAccept.Enabled = rdStatusAccept.Checked = isNewRecord = true;
            txtOrderId.ReadOnly = itemPanel.Enabled = btnPaid.Enabled = !isNewRecord;
            txtCustomerName.Focus();
        }

        private void txtOrderId_TextChanged(object sender, EventArgs e)
        {
            if (txtOrderId.Text.Length > 0)
            {
                int OrderId = Convert.ToInt32(txtOrderId.Text);
                orderItems = orderEntities.OrderItems.Where(i => i.OrderId == OrderId).ToList();
                InitializeOrderItemGridView(orderItems);
                   
                //Update state
                if (txtOrderId.ReadOnly == false)
                {
                    InitializeOrderGridView(orderEntities.Orders.Where(o => o.OrderId == OrderId).ToList());
                    itemPanel.Enabled = true;
                }
            }
            else
            {
                itemPanel.Enabled = false;
                RefreshOrderDataSource();
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            bool saving = false;

            if (txtCustomerName.Text.Length > 0 && txtWeight.Text != "0")
            {
                order.CustomerName = txtCustomerName.Text;
                order.Date = dtDateReceived.Value.Date;
                order.Weight = Convert.ToDouble(txtWeight.Text);
                order.Price = Convert.ToInt32(txtSubTotal.Text);
                saving = true;
            }

            if (saving)
            {
                try
                {
                    orderEntities.SaveChanges();
                    RefreshOrderDataSource();
                    DefaultFormState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Order!");
                }
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (rdStatusFinish.Checked)
            {
                order.FinishAt = DateTime.Now;

                orderEntities.SaveChanges();
                RefreshOrderDataSource();
                DefaultFormState();
            }
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            if (rdStatusTaken.Checked)
            {
                orderEntities.SaveChanges();

                PaidForm paidForm = new PaidForm(txtOrderId.Text, orderEntities, printer);
                paidForm.ShowDialog();

                if (paidForm.IsDisposed)
                {
                    RefreshOrderDataSource();
                    DefaultFormState();
                }
            }
        }

        private void dgvOrderItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridOrderItem = (DataGridView)sender;
            int OrderItemId = Convert.ToInt32(dataGridOrderItem.Rows[e.RowIndex].Cells[0].Value);

            if (e.ColumnIndex == 4 && dataGridOrderItem.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                DialogResult result = MessageBox.Show("Are you sure to remove #" + OrderItemId.ToString() + "?", "Order!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //Remove data
                    var removeOrderItem = new OrderItem { OrderItemId = OrderItemId };

                    orderEntities.Entry(removeOrderItem).State = EntityState.Deleted;
                    orderEntities.OrderItems.Remove(removeOrderItem);
                    orderEntities.SaveChanges();
                }

                RefreshOrderItemDataSource();
            }
        }

        private void btnUpdateOrder_EnabledChanged(object sender, EventArgs e)
        {
            if (btnUpdateOrder.Enabled)
            {
                rdStatusWash.Enabled = rdStatusDry.Enabled = rdStatusIroned.Enabled = btnUpdateOrder.Enabled;
            }
        }

        private void txtOrderId_Click(object sender, EventArgs e)
        {
            txtOrderId.ReadOnly = !txtOrderId.ReadOnly;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            bool saveResult = SaveOrder();

            if (saveResult)
            {
                DialogResult dialogResult = MessageBox.Show("Add order item?", "Order!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    itemPanel.Enabled = true;
                    txtItemName.Focus();
                }
                else
                {
                    if (isNewRecord)
                    {
                        orderEntities.Orders.Add(order);
                        orderEntities.SaveChanges();

                        DialogResult printResult = MessageBox.Show("Print Order Receipt?", "Order!", MessageBoxButtons.YesNo);
                        if (printResult == DialogResult.Yes)
                        {
                            printer.SetOrderDetail = order;
                            printer.PrintAcceptOrder();
                        }
                    }

                    RefreshOrderDataSource();
                    DefaultFormState();
                }
            }
        }

        private void btnAddOrder_EnabledChanged(object sender, EventArgs e)
        {
            txtOrderId.ReadOnly = !btnAddOrder.Enabled;
            rdStatusAccept.Enabled = rdStatusAccept.Checked = isNewRecord;

            if (isNewRecord)
            {
                rdStatusWash.Enabled = rdStatusDry.Enabled = rdStatusIroned.Enabled = false;
            }
            else
            {
                rdStatusFinish.Enabled = rdStatusTaken.Enabled = true;
            }
        }
    }
}
