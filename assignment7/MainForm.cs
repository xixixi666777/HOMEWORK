using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using _3_20_C_;   // 引用原项目的命名空间

namespace OrderManagerWinForm
{
    public partial class MainForm : Form
    {
        private OrderManager.OrderService _service = new OrderManager.OrderService();
        private BindingSource _orderBs = new BindingSource();
        private BindingSource _detailsBs = new BindingSource();

        public MainForm()
        {
            InitializeComponent();

            // 绑定主从数据源
            _orderBs.DataSource = new BindingList<OrderManager.Order>(_service.QueryOrders(o => true));
            dgvOrders.DataSource = _orderBs;

            _detailsBs.DataSource = _orderBs;
            _detailsBs.DataMember = "Details";
            dgvDetails.DataSource = _detailsBs;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            var list = _service.QueryOrders(o =>
                o.OrderId.Contains(kw) ||
                o.Client.Name.Contains(kw) ||
                o.Details.Any(d => d.Item.Name.Contains(kw)));
            _orderBs.DataSource = new BindingList<OrderManager.Order>(list);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var f = new EditOrderForm(null, _service);
            if (f.ShowDialog() == DialogResult.OK)
                RefreshList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_orderBs.Current is OrderManager.Order cur)
            {
                using var f = new EditOrderForm(cur, _service);
                if (f.ShowDialog() == DialogResult.OK)
                    RefreshList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_orderBs.Current is OrderManager.Order cur)
            {
                _service.RemoveOrder(cur.OrderId);
                RefreshList();
            }
        }

        private void RefreshList()
        {
            _orderBs.DataSource = new BindingList<OrderManager.Order>(_service.QueryOrders(o => true));

        }
    }
}
