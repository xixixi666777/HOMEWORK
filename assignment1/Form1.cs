namespace _2_21c_2
{
    public partial class Form1 : Form
    {
        int result;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a, b;
            a = textBox1.Text;
            b = textBox2.Text;
            int x, y, z;
            x = int.Parse(a);
            y = int.Parse(b);
            z = x + y;
            result = z;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a, b;
            a = textBox1.Text;
            b = textBox2.Text;
            int x, y, z;
            x = int.Parse(a);
            y = int.Parse(b);
            z = x * y;
            result = z;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a, b;
            a = textBox1.Text;
            b = textBox2.Text;
            int x, y, z;
            x = int.Parse(a);
            y = int.Parse(b);
            z = x - y;
            result = z;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a, b;
            a = textBox1.Text;
            b = textBox2.Text;
            int x, y, z;
            x = int.Parse(a);
            y = int.Parse(b);
            z = x / y;
            result = z;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = result.ToString();
        }
    }
}
