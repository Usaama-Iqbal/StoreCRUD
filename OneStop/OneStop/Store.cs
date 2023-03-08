using Business;
using DataAccess.Models;
using System.Data;

namespace OneStop
{
    public partial class frmProductEntry : Form
    {
        public frmProductEntry()
        {
            InitializeComponent();
        }





        private void frmProductEntry_Load(object sender, EventArgs e)
        {
            ShowRecord();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRecord();
            ShowRecord();
            clear();
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            StoreEntity entity = new StoreEntity();
            entity.id = Convert.ToInt32(txtId.Text);
            entity.Name = txtName.Text;
            entity.Category = txtCategory.Text;
            entity.Quantity = Convert.ToInt32(txtQuantity.Text);
            entity.Weight = txtWeight.Text;
            entity.Price = Convert.ToInt32(txtPrice.Text);
            entity.Date = dtpExpDate.Text;

            OneStopBusiness obj = new OneStopBusiness();



            int result = obj.UpdateStoreRecord(entity);
            if (result > 0)
                MessageBox.Show("Record Updated SuccessFully");
            else
                MessageBox.Show("Error");

            ShowRecord();
            clear();

        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord(Convert.ToInt32(txtId.Text));

            ShowRecord();
            clear();
        }

        public void ShowRecord()
        {
            // Create a new instance of the business logic layer class
            OneStopBusiness bal = new OneStopBusiness();

            // Call the GetStudents method to get the student records
            DataTable studentsTable = bal.GetRecord();

            // Set the DataGridView's DataSource property to the DataTable object containing the student records
            dgvShow.DataSource = studentsTable;
            if (dgvShow.Rows.Count > 0)
            {
                dgvShow.Rows[0].Selected = true;
            }
        }

        public void SaveRecord()
        {
            StoreEntity entity = new StoreEntity();
            entity.Name = txtName.Text;
            entity.Category = txtCategory.Text;
            entity.Quantity = Convert.ToInt32(txtQuantity.Text);
            entity.Weight = txtWeight.Text;
            entity.Price = Convert.ToInt32(txtPrice.Text);
            entity.Date = dtpExpDate.Text;
            OneStopBusiness obj = new OneStopBusiness();
            int result = obj.SaveStoreRecord(entity);
            if (result > 0)
                MessageBox.Show("Record Inserted SuccessFully");
            else
                MessageBox.Show("Error");
        }

        public void clear()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtCategory.Text = "";
            txtQuantity.Text = "";
            txtWeight.Text = "";
            txtPrice.Text = "";
            dtpExpDate.Text = "";

        }

        public void DeleteRecord(int StoreId)
        {
            // Create a new instance of the business logic layer class
            OneStopBusiness bal = new OneStopBusiness();

            // Call the DeleteStudent method in the business logic layer to delete the student record
            int result = bal.DeleteStoreRecord(StoreId);

            if (result > 0)
                MessageBox.Show("Record Deleted SuccessFully");
            else
                MessageBox.Show("Error");

        }

        private void dgvShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvShow.Rows[e.RowIndex];
                row.Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtCategory.Text = row.Cells[2].Value.ToString();
                txtQuantity.Text = row.Cells[3].Value.ToString();
                txtWeight.Text = row.Cells[4].Value.ToString();
                txtPrice.Text = row.Cells[5].Value.ToString();
                dtpExpDate.Text = row.Cells[6].Value.ToString();

                // add more textboxes for other columns if needed
            }
        }
    }
}

