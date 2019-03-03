namespace LaundryApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.scaleStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.receiptPrinterStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tenantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dgvOrderPanel = new System.Windows.Forms.Panel();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.mainFormPanel = new System.Windows.Forms.Panel();
            this.orderPanel = new System.Windows.Forms.Panel();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnPaid = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtDateReceived = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.gbServiceType = new System.Windows.Forms.GroupBox();
            this.rbServiceTypeStandard = new System.Windows.Forms.RadioButton();
            this.rbServiceTypeExpress = new System.Windows.Forms.RadioButton();
            this.btnUpdateOrder = new System.Windows.Forms.Button();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.rdStatusAccept = new System.Windows.Forms.RadioButton();
            this.rdStatusIroned = new System.Windows.Forms.RadioButton();
            this.rdStatusWash = new System.Windows.Forms.RadioButton();
            this.rdStatusFinish = new System.Windows.Forms.RadioButton();
            this.rdStatusDry = new System.Windows.Forms.RadioButton();
            this.rdStatusTaken = new System.Windows.Forms.RadioButton();
            this.scalePanel = new System.Windows.Forms.Panel();
            this.txtWeight = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.itemPanel = new System.Windows.Forms.Panel();
            this.dgvOrderItemPanel = new System.Windows.Forms.Panel();
            this.dgvOrderItem = new System.Windows.Forms.DataGridView();
            this.itemFormPanel = new System.Windows.Forms.Panel();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtItemPrice = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtItemQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.dgvOrderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.mainFormPanel.SuspendLayout();
            this.orderPanel.SuspendLayout();
            this.gbServiceType.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.scalePanel.SuspendLayout();
            this.itemPanel.SuspendLayout();
            this.dgvOrderItemPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItem)).BeginInit();
            this.itemFormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaleStatus,
            this.receiptPrinterStatus});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip.Location = new System.Drawing.Point(0, 628);
            this.statusStrip.Margin = new System.Windows.Forms.Padding(3);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1532, 25);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "Service Console";
            // 
            // scaleStatus
            // 
            this.scaleStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.scaleStatus.Margin = new System.Windows.Forms.Padding(6, 3, 0, 2);
            this.scaleStatus.Name = "scaleStatus";
            this.scaleStatus.Size = new System.Drawing.Size(168, 20);
            this.scaleStatus.Text = "Timbangan: -Tidak Aktif";
            // 
            // receiptPrinterStatus
            // 
            this.receiptPrinterStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.receiptPrinterStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.receiptPrinterStatus.Margin = new System.Windows.Forms.Padding(6, 3, 0, 2);
            this.receiptPrinterStatus.Name = "receiptPrinterStatus";
            this.receiptPrinterStatus.Size = new System.Drawing.Size(136, 20);
            this.receiptPrinterStatus.Text = "Printer: -Tidak Aktif";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1532, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tenantToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tenantToolStripMenuItem
            // 
            this.tenantToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.tenantToolStripMenuItem.Name = "tenantToolStripMenuItem";
            this.tenantToolStripMenuItem.ShowShortcutKeys = false;
            this.tenantToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.tenantToolStripMenuItem.Text = "Tenant";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.ShowShortcutKeys = false;
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(101, 26);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.dgvOrderPanel);
            this.mainPanel.Controls.Add(this.mainFormPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 28);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1532, 600);
            this.mainPanel.TabIndex = 2;
            // 
            // dgvOrderPanel
            // 
            this.dgvOrderPanel.AutoScroll = true;
            this.dgvOrderPanel.Controls.Add(this.dgvOrder);
            this.dgvOrderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderPanel.Location = new System.Drawing.Point(0, 314);
            this.dgvOrderPanel.Name = "dgvOrderPanel";
            this.dgvOrderPanel.Size = new System.Drawing.Size(1530, 284);
            this.dgvOrderPanel.TabIndex = 33;
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrder.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            this.dgvOrder.RowTemplate.Height = 24;
            this.dgvOrder.Size = new System.Drawing.Size(1530, 284);
            this.dgvOrder.TabIndex = 27;
            this.dgvOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellContentClick);
            // 
            // mainFormPanel
            // 
            this.mainFormPanel.Controls.Add(this.orderPanel);
            this.mainFormPanel.Controls.Add(this.scalePanel);
            this.mainFormPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainFormPanel.Location = new System.Drawing.Point(0, 0);
            this.mainFormPanel.Name = "mainFormPanel";
            this.mainFormPanel.Size = new System.Drawing.Size(1530, 314);
            this.mainFormPanel.TabIndex = 32;
            // 
            // orderPanel
            // 
            this.orderPanel.Controls.Add(this.btnCancelOrder);
            this.orderPanel.Controls.Add(this.btnAddOrder);
            this.orderPanel.Controls.Add(this.label1);
            this.orderPanel.Controls.Add(this.txtCustomerName);
            this.orderPanel.Controls.Add(this.btnPaid);
            this.orderPanel.Controls.Add(this.label2);
            this.orderPanel.Controls.Add(this.txtOrderId);
            this.orderPanel.Controls.Add(this.label7);
            this.orderPanel.Controls.Add(this.dtDateReceived);
            this.orderPanel.Controls.Add(this.label4);
            this.orderPanel.Controls.Add(this.btnFinish);
            this.orderPanel.Controls.Add(this.label6);
            this.orderPanel.Controls.Add(this.gbServiceType);
            this.orderPanel.Controls.Add(this.btnUpdateOrder);
            this.orderPanel.Controls.Add(this.gbStatus);
            this.orderPanel.Location = new System.Drawing.Point(400, 0);
            this.orderPanel.Name = "orderPanel";
            this.orderPanel.Size = new System.Drawing.Size(579, 314);
            this.orderPanel.TabIndex = 34;
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(297, 263);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(126, 35);
            this.btnCancelOrder.TabIndex = 47;
            this.btnCancelOrder.Text = "Batal";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(32, 210);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(126, 35);
            this.btnAddOrder.TabIndex = 40;
            this.btnAddOrder.Text = "Tambah";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.EnabledChanged += new System.EventHandler(this.btnAddOrder_EnabledChanged);
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "Nama Pelanggan";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(21, 36);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(226, 22);
            this.txtCustomerName.TabIndex = 34;
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerName_KeyDown);
            // 
            // btnPaid
            // 
            this.btnPaid.Enabled = false;
            this.btnPaid.Location = new System.Drawing.Point(165, 263);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(126, 35);
            this.btnPaid.TabIndex = 46;
            this.btnPaid.Text = "Bayar";
            this.btnPaid.UseVisualStyleBackColor = true;
            this.btnPaid.Click += new System.EventHandler(this.btnPaid_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Diterima Tanggal";
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(459, 36);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.ReadOnly = true;
            this.txtOrderId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOrderId.Size = new System.Drawing.Size(99, 22);
            this.txtOrderId.TabIndex = 45;
            this.txtOrderId.Click += new System.EventHandler(this.txtOrderId_Click);
            this.txtOrderId.TextChanged += new System.EventHandler(this.txtOrderId_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(455, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 44;
            this.label7.Text = "Order Id";
            // 
            // dtDateReceived
            // 
            this.dtDateReceived.Checked = false;
            this.dtDateReceived.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtDateReceived.Location = new System.Drawing.Point(270, 36);
            this.dtDateReceived.Name = "dtDateReceived";
            this.dtDateReceived.Size = new System.Drawing.Size(167, 22);
            this.dtDateReceived.TabIndex = 36;
            this.dtDateReceived.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtDateReceived_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "Jenis Layanan";
            // 
            // btnFinish
            // 
            this.btnFinish.Enabled = false;
            this.btnFinish.Location = new System.Drawing.Point(32, 263);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(126, 35);
            this.btnFinish.TabIndex = 43;
            this.btnFinish.Text = "Selesai";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(161, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 39;
            this.label6.Text = "Status";
            // 
            // gbServiceType
            // 
            this.gbServiceType.Controls.Add(this.rbServiceTypeStandard);
            this.gbServiceType.Controls.Add(this.rbServiceTypeExpress);
            this.gbServiceType.Location = new System.Drawing.Point(21, 93);
            this.gbServiceType.Name = "gbServiceType";
            this.gbServiceType.Size = new System.Drawing.Size(114, 98);
            this.gbServiceType.TabIndex = 42;
            this.gbServiceType.TabStop = false;
            // 
            // rbServiceTypeStandard
            // 
            this.rbServiceTypeStandard.AutoSize = true;
            this.rbServiceTypeStandard.Checked = true;
            this.rbServiceTypeStandard.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbServiceTypeStandard.Location = new System.Drawing.Point(6, 21);
            this.rbServiceTypeStandard.Name = "rbServiceTypeStandard";
            this.rbServiceTypeStandard.Size = new System.Drawing.Size(87, 21);
            this.rbServiceTypeStandard.TabIndex = 7;
            this.rbServiceTypeStandard.TabStop = true;
            this.rbServiceTypeStandard.Text = "Standard";
            this.rbServiceTypeStandard.UseVisualStyleBackColor = true;
            this.rbServiceTypeStandard.CheckedChanged += new System.EventHandler(this.rbServiceTypeStandard_CheckedChanged);
            this.rbServiceTypeStandard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbServiceTypeStandard_KeyDown);
            // 
            // rbServiceTypeExpress
            // 
            this.rbServiceTypeExpress.AutoSize = true;
            this.rbServiceTypeExpress.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbServiceTypeExpress.Location = new System.Drawing.Point(6, 65);
            this.rbServiceTypeExpress.Name = "rbServiceTypeExpress";
            this.rbServiceTypeExpress.Size = new System.Drawing.Size(79, 21);
            this.rbServiceTypeExpress.TabIndex = 8;
            this.rbServiceTypeExpress.Text = "Express";
            this.rbServiceTypeExpress.UseVisualStyleBackColor = true;
            this.rbServiceTypeExpress.CheckedChanged += new System.EventHandler(this.rbServiceTypeExpress_CheckedChanged);
            this.rbServiceTypeExpress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbServiceTypeExpress_KeyDown);
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.Enabled = false;
            this.btnUpdateOrder.Location = new System.Drawing.Point(164, 210);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(126, 35);
            this.btnUpdateOrder.TabIndex = 38;
            this.btnUpdateOrder.Text = "Ubah";
            this.btnUpdateOrder.UseVisualStyleBackColor = true;
            this.btnUpdateOrder.EnabledChanged += new System.EventHandler(this.btnUpdateOrder_EnabledChanged);
            this.btnUpdateOrder.Click += new System.EventHandler(this.btnUpdateOrder_Click);
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.rdStatusAccept);
            this.gbStatus.Controls.Add(this.rdStatusIroned);
            this.gbStatus.Controls.Add(this.rdStatusWash);
            this.gbStatus.Controls.Add(this.rdStatusFinish);
            this.gbStatus.Controls.Add(this.rdStatusDry);
            this.gbStatus.Controls.Add(this.rdStatusTaken);
            this.gbStatus.Location = new System.Drawing.Point(165, 95);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(301, 96);
            this.gbStatus.TabIndex = 41;
            this.gbStatus.TabStop = false;
            // 
            // rdStatusAccept
            // 
            this.rdStatusAccept.AutoSize = true;
            this.rdStatusAccept.Checked = true;
            this.rdStatusAccept.Location = new System.Drawing.Point(6, 21);
            this.rdStatusAccept.Name = "rdStatusAccept";
            this.rdStatusAccept.Size = new System.Drawing.Size(81, 21);
            this.rdStatusAccept.TabIndex = 12;
            this.rdStatusAccept.TabStop = true;
            this.rdStatusAccept.Text = "Diterima";
            this.rdStatusAccept.UseVisualStyleBackColor = true;
            this.rdStatusAccept.CheckedChanged += new System.EventHandler(this.rdStatusAccept_CheckedChanged);
            // 
            // rdStatusIroned
            // 
            this.rdStatusIroned.AutoSize = true;
            this.rdStatusIroned.Location = new System.Drawing.Point(6, 63);
            this.rdStatusIroned.Name = "rdStatusIroned";
            this.rdStatusIroned.Size = new System.Drawing.Size(84, 21);
            this.rdStatusIroned.TabIndex = 13;
            this.rdStatusIroned.Text = "Disetrika";
            this.rdStatusIroned.UseVisualStyleBackColor = true;
            this.rdStatusIroned.CheckedChanged += new System.EventHandler(this.rdStatusIroned_CheckedChanged);
            // 
            // rdStatusWash
            // 
            this.rdStatusWash.AutoSize = true;
            this.rdStatusWash.Location = new System.Drawing.Point(109, 21);
            this.rdStatusWash.Name = "rdStatusWash";
            this.rdStatusWash.Size = new System.Drawing.Size(67, 21);
            this.rdStatusWash.TabIndex = 14;
            this.rdStatusWash.Text = "Dicuci";
            this.rdStatusWash.UseVisualStyleBackColor = true;
            this.rdStatusWash.CheckedChanged += new System.EventHandler(this.rdStatusWash_CheckedChanged);
            // 
            // rdStatusFinish
            // 
            this.rdStatusFinish.AutoSize = true;
            this.rdStatusFinish.Enabled = false;
            this.rdStatusFinish.Location = new System.Drawing.Point(109, 63);
            this.rdStatusFinish.Name = "rdStatusFinish";
            this.rdStatusFinish.Size = new System.Drawing.Size(75, 21);
            this.rdStatusFinish.TabIndex = 15;
            this.rdStatusFinish.Text = "Selesai";
            this.rdStatusFinish.UseVisualStyleBackColor = true;
            this.rdStatusFinish.CheckedChanged += new System.EventHandler(this.rdStatusFinish_CheckedChanged);
            // 
            // rdStatusDry
            // 
            this.rdStatusDry.AutoSize = true;
            this.rdStatusDry.Location = new System.Drawing.Point(208, 21);
            this.rdStatusDry.Name = "rdStatusDry";
            this.rdStatusDry.Size = new System.Drawing.Size(77, 21);
            this.rdStatusDry.TabIndex = 16;
            this.rdStatusDry.Text = "Dijemur";
            this.rdStatusDry.UseVisualStyleBackColor = true;
            this.rdStatusDry.CheckedChanged += new System.EventHandler(this.rdStatusDry_CheckedChanged);
            // 
            // rdStatusTaken
            // 
            this.rdStatusTaken.AutoSize = true;
            this.rdStatusTaken.Enabled = false;
            this.rdStatusTaken.Location = new System.Drawing.Point(208, 63);
            this.rdStatusTaken.Name = "rdStatusTaken";
            this.rdStatusTaken.Size = new System.Drawing.Size(75, 21);
            this.rdStatusTaken.TabIndex = 17;
            this.rdStatusTaken.Text = "Diambil";
            this.rdStatusTaken.UseVisualStyleBackColor = true;
            this.rdStatusTaken.CheckedChanged += new System.EventHandler(this.rdStatusTaken_CheckedChanged);
            // 
            // scalePanel
            // 
            this.scalePanel.Controls.Add(this.label5);
            this.scalePanel.Controls.Add(this.txtWeight);
            this.scalePanel.Controls.Add(this.label3);
            this.scalePanel.Controls.Add(this.txtUnitPrice);
            this.scalePanel.Controls.Add(this.txtSubTotal);
            this.scalePanel.Controls.Add(this.label10);
            this.scalePanel.Location = new System.Drawing.Point(0, 0);
            this.scalePanel.Name = "scalePanel";
            this.scalePanel.Size = new System.Drawing.Size(400, 314);
            this.scalePanel.TabIndex = 33;
            // 
            // txtWeight
            // 
            this.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(26, 30);
            this.txtWeight.Multiline = false;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ReadOnly = true;
            this.txtWeight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWeight.Size = new System.Drawing.Size(345, 105);
            this.txtWeight.TabIndex = 31;
            this.txtWeight.Text = "0";
            this.txtWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Berat (Kg)";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(248, 278);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUnitPrice.Size = new System.Drawing.Size(123, 22);
            this.txtUnitPrice.TabIndex = 10;
            this.txtUnitPrice.Text = "0";
            this.txtUnitPrice.TextChanged += new System.EventHandler(this.txtUnitPrice_TextChanged);
            this.txtUnitPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnitPrice_KeyDown);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(26, 158);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubTotal.Size = new System.Drawing.Size(345, 114);
            this.txtSubTotal.TabIndex = 25;
            this.txtSubTotal.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Harga";
            // 
            // itemPanel
            // 
            this.itemPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemPanel.Controls.Add(this.dgvOrderItemPanel);
            this.itemPanel.Controls.Add(this.itemFormPanel);
            this.itemPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.itemPanel.Enabled = false;
            this.itemPanel.Location = new System.Drawing.Point(882, 28);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(650, 600);
            this.itemPanel.TabIndex = 3;
            // 
            // dgvOrderItemPanel
            // 
            this.dgvOrderItemPanel.AutoScroll = true;
            this.dgvOrderItemPanel.Controls.Add(this.dgvOrderItem);
            this.dgvOrderItemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderItemPanel.Location = new System.Drawing.Point(0, 100);
            this.dgvOrderItemPanel.Name = "dgvOrderItemPanel";
            this.dgvOrderItemPanel.Size = new System.Drawing.Size(648, 498);
            this.dgvOrderItemPanel.TabIndex = 9;
            // 
            // dgvOrderItem
            // 
            this.dgvOrderItem.AllowUserToAddRows = false;
            this.dgvOrderItem.AllowUserToDeleteRows = false;
            this.dgvOrderItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvOrderItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrderItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrderItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderItem.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderItem.Name = "dgvOrderItem";
            this.dgvOrderItem.ReadOnly = true;
            this.dgvOrderItem.RowTemplate.Height = 24;
            this.dgvOrderItem.Size = new System.Drawing.Size(648, 498);
            this.dgvOrderItem.TabIndex = 5;
            this.dgvOrderItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItem_CellContentClick);
            // 
            // itemFormPanel
            // 
            this.itemFormPanel.Controls.Add(this.btnAddItem);
            this.itemFormPanel.Controls.Add(this.label8);
            this.itemFormPanel.Controls.Add(this.txtItemPrice);
            this.itemFormPanel.Controls.Add(this.txtItemName);
            this.itemFormPanel.Controls.Add(this.label11);
            this.itemFormPanel.Controls.Add(this.label9);
            this.itemFormPanel.Controls.Add(this.txtItemQuantity);
            this.itemFormPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemFormPanel.Location = new System.Drawing.Point(0, 0);
            this.itemFormPanel.Name = "itemFormPanel";
            this.itemFormPanel.Size = new System.Drawing.Size(648, 100);
            this.itemFormPanel.TabIndex = 8;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(463, 49);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(60, 24);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "+";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nama Item";
            // 
            // txtItemPrice
            // 
            this.txtItemPrice.Location = new System.Drawing.Point(357, 50);
            this.txtItemPrice.Name = "txtItemPrice";
            this.txtItemPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtItemPrice.Size = new System.Drawing.Size(100, 22);
            this.txtItemPrice.TabIndex = 7;
            this.txtItemPrice.Text = "0";
            this.txtItemPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemPrice_KeyDown);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(26, 50);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(269, 22);
            this.txtItemName.TabIndex = 1;
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(354, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 17);
            this.label11.TabIndex = 6;
            this.label11.Text = "Harga Per Item";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(298, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Qty";
            // 
            // txtItemQuantity
            // 
            this.txtItemQuantity.Location = new System.Drawing.Point(301, 50);
            this.txtItemQuantity.Name = "txtItemQuantity";
            this.txtItemQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtItemQuantity.Size = new System.Drawing.Size(50, 22);
            this.txtItemQuantity.TabIndex = 3;
            this.txtItemQuantity.Text = "0";
            this.txtItemQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemQuantity_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Harga Per (Kg)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 653);
            this.Controls.Add(this.itemPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laundry App v1.0.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.dgvOrderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.mainFormPanel.ResumeLayout(false);
            this.orderPanel.ResumeLayout(false);
            this.orderPanel.PerformLayout();
            this.gbServiceType.ResumeLayout(false);
            this.gbServiceType.PerformLayout();
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.scalePanel.ResumeLayout(false);
            this.scalePanel.PerformLayout();
            this.itemPanel.ResumeLayout(false);
            this.dgvOrderItemPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItem)).EndInit();
            this.itemFormPanel.ResumeLayout(false);
            this.itemFormPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tenantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel itemPanel;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.TextBox txtItemQuantity;
        private System.Windows.Forms.DataGridView dgvOrderItem;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.ToolStripStatusLabel scaleStatus;
        private System.Windows.Forms.ToolStripStatusLabel receiptPrinterStatus;
        private System.Windows.Forms.RichTextBox txtWeight;
        private System.Windows.Forms.TextBox txtItemPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel dgvOrderPanel;
        private System.Windows.Forms.Panel mainFormPanel;
        private System.Windows.Forms.Panel dgvOrderItemPanel;
        private System.Windows.Forms.Panel itemFormPanel;
        private System.Windows.Forms.Panel scalePanel;
        private System.Windows.Forms.Panel orderPanel;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button btnPaid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DateTimePicker dtDateReceived;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbServiceType;
        private System.Windows.Forms.RadioButton rbServiceTypeStandard;
        private System.Windows.Forms.RadioButton rbServiceTypeExpress;
        private System.Windows.Forms.Button btnUpdateOrder;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.RadioButton rdStatusAccept;
        private System.Windows.Forms.RadioButton rdStatusIroned;
        private System.Windows.Forms.RadioButton rdStatusWash;
        private System.Windows.Forms.RadioButton rdStatusFinish;
        private System.Windows.Forms.RadioButton rdStatusDry;
        private System.Windows.Forms.RadioButton rdStatusTaken;
        private System.Windows.Forms.Label label5;
    }
}

