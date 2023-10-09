using System.Data;
using System.Linq.Expressions;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {

        Double netice = 0;
        bool optDurum = false;
        string opt = "";
        public Form1()
        {
            InitializeComponent();
            txt_Calc.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ReqemHadise(object sender, EventArgs e)
        {
            if (txt_Calc.Text == "0" || optDurum)
                txt_Calc.Clear();

            optDurum = false;
            Button btn = (Button)sender;
            txt_Calc.Text += btn.Text;


        }

        private void OptResult(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string yeniOpt = btn.Text;

            lbResult.Text += " " + txt_Calc.Text + " " + yeniOpt;

            double operand = Double.Parse(txt_Calc.Text);

            switch (opt)
            {
                case "+": netice += operand; 
                    break;
                case "-": netice -= operand; 
                    break;
                case "/": netice /= operand; 
                    break;
                case "*": netice *= operand; 
                    break;
                default: 
                    break;
            }

            optDurum = true;
            opt = yeniOpt;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            lbResult.Text += txt_Calc.Text;
            optDurum = false;

            var result = CalculateExpression();

            MessageBox.Show(result.ToString());

            lbResult.Text = "";

            txt_Calc.Text = result.ToString();
        }

        private double CalculateExpression()
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), lbResult.Text);
            DataRow row = table.NewRow();
            table.Rows.Add(row);

            return double.Parse((string)row["expression"]);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txt_Calc.Text = "0";
            netice = 0;
            lbResult.Text = "";
            opt = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_Calc.Text == "0")
            {
                txt_Calc.Text = "0";
            }
            else if (optDurum)
            {
                txt_Calc.Text = "0";
            }

            if (!txt_Calc.Text.Contains("."))
            {
                txt_Calc.Text += ".";
            }

            optDurum = false;
        }
    }
}