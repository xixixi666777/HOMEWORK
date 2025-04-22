namespace OrderManagerWinForm
{
    partial class EditOrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.BindingSource bindingSourceDetails;
        private System.Windows.Forms.TextBox txtGoodsName;
        private System.Windows.Forms.TextBox txtGoodsPrice;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnRemoveDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlp;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tlp = new TableLayoutPanel();
            lblOrderId = new Label();
            txtOrderId = new TextBox();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            lblContact = new Label();
            txtContact = new TextBox();
            dgvDetails = new DataGridView();
            txtGoodsName = new TextBox();
            txtGoodsPrice = new TextBox();
            numQuantity = new NumericUpDown();
            btnAddDetail = new Button();
            btnRemoveDetail = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            bindingSourceDetails = new BindingSource(components);
            tlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceDetails).BeginInit();
            SuspendLayout();
            // 
            // tlp
            // 
            tlp.ColumnCount = 4;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tlp.Controls.Add(lblOrderId, 0, 0);
            tlp.Controls.Add(txtOrderId, 1, 0);
            tlp.Controls.Add(lblCustomerName, 0, 1);
            tlp.Controls.Add(txtCustomerName, 1, 1);
            tlp.Controls.Add(lblContact, 0, 2);
            tlp.Controls.Add(txtContact, 1, 2);
            tlp.Controls.Add(dgvDetails, 0, 3);
            tlp.Controls.Add(txtGoodsName, 0, 4);
            tlp.Controls.Add(txtGoodsPrice, 1, 4);
            tlp.Controls.Add(numQuantity, 2, 4);
            tlp.Controls.Add(btnAddDetail, 3, 4);
            tlp.Controls.Add(btnRemoveDetail, 3, 4);
            tlp.Controls.Add(btnSave, 2, 5);
            tlp.Controls.Add(btnCancel, 3, 5);
            tlp.Dock = DockStyle.Fill;
            tlp.Location = new Point(0, 0);
            tlp.Name = "tlp";
            tlp.RowCount = 6;
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlp.Size = new Size(600, 400);
            tlp.TabIndex = 0;
            // 
            // lblOrderId
            // 
            lblOrderId.Location = new Point(3, 0);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(74, 23);
            lblOrderId.TabIndex = 0;
            lblOrderId.Text = "订单号：";
            lblOrderId.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtOrderId
            // 
            tlp.SetColumnSpan(txtOrderId, 3);
            txtOrderId.Location = new Point(83, 3);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.Size = new Size(100, 30);
            txtOrderId.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            lblCustomerName.Location = new Point(3, 30);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(74, 23);
            lblCustomerName.TabIndex = 2;
            lblCustomerName.Text = "客户：";
            lblCustomerName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCustomerName
            // 
            tlp.SetColumnSpan(txtCustomerName, 3);
            txtCustomerName.Location = new Point(83, 33);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(100, 30);
            txtCustomerName.TabIndex = 3;
            // 
            // lblContact
            // 
            lblContact.Location = new Point(3, 60);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(74, 23);
            lblContact.TabIndex = 4;
            lblContact.Text = "联系方式：";
            lblContact.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtContact
            // 
            tlp.SetColumnSpan(txtContact, 3);
            txtContact.Location = new Point(83, 63);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(100, 30);
            txtContact.TabIndex = 5;
            // 
            // dgvDetails
            // 
            dgvDetails.ColumnHeadersHeight = 34;
            tlp.SetColumnSpan(dgvDetails, 4);
            dgvDetails.Dock = DockStyle.Fill;
            dgvDetails.Location = new Point(3, 93);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.RowHeadersWidth = 62;
            dgvDetails.Size = new Size(594, 234);
            dgvDetails.TabIndex = 6;
            // 
            // txtGoodsName
            // 
            txtGoodsName.Location = new Point(3, 333);
            txtGoodsName.Name = "txtGoodsName";
            txtGoodsName.PlaceholderText = "商品名";
            txtGoodsName.Size = new Size(74, 30);
            txtGoodsName.TabIndex = 7;
            // 
            // txtGoodsPrice
            // 
            txtGoodsPrice.Location = new Point(83, 333);
            txtGoodsPrice.Name = "txtGoodsPrice";
            txtGoodsPrice.PlaceholderText = "单价";
            txtGoodsPrice.Size = new Size(100, 30);
            txtGoodsPrice.TabIndex = 8;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(403, 333);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(114, 30);
            numQuantity.TabIndex = 9;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddDetail
            // 
            btnAddDetail.Location = new Point(3, 363);
            btnAddDetail.Name = "btnAddDetail";
            btnAddDetail.Size = new Size(74, 23);
            btnAddDetail.TabIndex = 10;
            btnAddDetail.Text = "+";
            btnAddDetail.Click += btnAddDetail_Click;
            // 
            // btnRemoveDetail
            // 
            btnRemoveDetail.Location = new Point(523, 333);
            btnRemoveDetail.Name = "btnRemoveDetail";
            btnRemoveDetail.Size = new Size(74, 23);
            btnRemoveDetail.TabIndex = 11;
            btnRemoveDetail.Text = "-";
            btnRemoveDetail.Click += btnRemoveDetail_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(403, 363);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = "保存";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(523, 363);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(74, 23);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "取消";
            // 
            // EditOrderForm
            // 
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            ClientSize = new Size(600, 400);
            Controls.Add(tlp);
            Name = "EditOrderForm";
            Text = "编辑订单";
            tlp.ResumeLayout(false);
            tlp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceDetails).EndInit();
            ResumeLayout(false);
        }
    }
}
