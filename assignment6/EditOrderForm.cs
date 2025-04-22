using System;
using System.Windows.Forms;
using _3_20_C_;

namespace OrderManagerWinForm
{
    public partial class EditOrderForm : Form
    {
        private OrderManager.Order currentOrder;
        private OrderManager.OrderService service;

        public EditOrderForm(OrderManager.Order order, OrderManager.OrderService service)
        {
            InitializeComponent();
            this.service = service;

            if (order == null)
            {
                currentOrder = new OrderManager.Order();
            }
            else
            {
                currentOrder = order;
                txtOrderId.Text = currentOrder.OrderId;
                txtCustomerName.Text = currentOrder.Client.Name;
                txtContact.Text = currentOrder.Client.Contact;
            }

            bindingSourceDetails.DataSource = currentOrder.Details;
            dgvOrderDetails.DataSource = bindingSourceDetails;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            currentOrder.OrderId = txtOrderId.Text;
            currentOrder.Client = new OrderManager.Customer
            {
                Name = txtCustomerName.Text,
                Contact = txtContact.Text
            };

            try
            {
                if (service.QueryOrders(o => o.OrderId == currentOrder.OrderId).Count > 0)
                    service.UpdateOrder(currentOrder);
                else
                    service.AddOrder(currentOrder);

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            currentOrder.Details.Add(new OrderManager.OrderDetails
            {
                Item = new OrderManager.Goods
                {
                    Name = txtGoodsName.Text,
                    Price = double.Parse(txtGoodsPrice.Text)
                },
                Quantity = int.Parse(txtQuantity.Text)
            });
            bindingSourceDetails.ResetBindings(false);
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            var detail = bindingSourceDetails.Current as OrderManager.OrderDetails;
            if (detail != null)
            {
                currentOrder.Details.Remove(detail);
                bindingSourceDetails.ResetBindings(false);
            }
        }
    }
}

