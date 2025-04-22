using System;
using System.Windows.Forms;
using _3_20_C_;

namespace OrderManagerWinForm
{
    public partial class EditOrderForm : Form
    {
        private OrderManager.Order _order;
        private OrderManager.OrderService _service;

        public EditOrderForm(OrderManager.Order order, OrderManager.OrderService service)
        {
            InitializeComponent();
            _service = service;

            // 如果传入 null，就 new 一个；否则用现有的
            _order = order ?? new OrderManager.Order();

            // **关键：** 确保 Client 不为 null，否则绑定 Client.Name 会抛空
            if (_order.Client == null)
                _order.Client = new OrderManager.Customer();

            // 下面才是数据绑定
            txtOrderId.DataBindings.Add("Text", _order, "OrderId");
            txtCustomerName.DataBindings.Add("Text", _order, "Client.Name");
            txtContact.DataBindings.Add("Text", _order, "Client.Contact");

            bindingSourceDetails.DataSource = _order.Details;
            dgvDetails.DataSource = bindingSourceDetails;
        }


        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            var gd = new OrderManager.Goods { Name = txtGoodsName.Text, Price = double.Parse(txtGoodsPrice.Text) };
            var od = new OrderManager.OrderDetails { Item = gd, Quantity = (int)numQuantity.Value };
            _order.Details.Add(od);
            bindingSourceDetails.ResetBindings(false);
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            if (bindingSourceDetails.Current is OrderManager.OrderDetails od)
            {
                _order.Details.Remove(od);
                bindingSourceDetails.ResetBindings(false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_service.QueryOrders(o => o.OrderId == _order.OrderId).Count > 0)
                    _service.UpdateOrder(_order);
                else
                    _service.AddOrder(_order);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
