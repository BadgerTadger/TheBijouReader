using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TheBijouReader
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PopulateComboBox();

            GetTenants(4);
        }

        private void GetTenants(int sortColumn)
        {
            Tenant tenant = new Tenant();
            DataSet ds = tenant.GetTenantData(sortColumn);
            if (ds != null)
            {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void PopulateComboBox()
        {
            ComboboxItem ID = new ComboboxItem();
            ID.Text = "TenantID";
            ID.Value = 1;
            comboBox1.Items.Add(ID);
            ComboboxItem FirstName = new ComboboxItem();
            FirstName.Text = "FirstName";
            FirstName.Value = 2;
            comboBox1.Items.Add(FirstName);
            ComboboxItem MiddleName = new ComboboxItem();
            MiddleName.Text = "MiddleName";
            MiddleName.Value = 3;
            comboBox1.Items.Add(MiddleName);
            ComboboxItem LastName = new ComboboxItem();
            LastName.Text = "LastName";
            LastName.Value = 4;
            comboBox1.Items.Add(LastName);
            ComboboxItem Town = new ComboboxItem();
            Town.Text = "Town";
            Town.Value = 7;
            comboBox1.Items.Add(Town);
            ComboboxItem City = new ComboboxItem();
            City.Text = "City";
            City.Value = 8;
            comboBox1.Items.Add(City);
            ComboboxItem County = new ComboboxItem();
            County.Text = "County";
            County.Value = 9;
            comboBox1.Items.Add(County);
            ComboboxItem Country = new ComboboxItem();
            Country.Text = "Country";
            Country.Value = 10;
            comboBox1.Items.Add(Country);

            comboBox1.SelectedIndex = 3;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            ComboboxItem selected = comboBox1.SelectedItem as ComboboxItem;
            int col = Convert.ToInt32(selected.Value);
            GetTenants(col);
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
