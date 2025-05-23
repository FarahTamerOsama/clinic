using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Vet_Clinic
{
    public partial class medication : Form
    {
        private Form _previousForm;
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public medication(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        private void ConnectToDatabase()
        {
            string connectionString = "Server=DESKTOP-0N62OBP\\SQLEXPRESS;Database=Vet_clinic;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void LoadData()
        {
            ConnectToDatabase();
            string query = "SELECT * FROM Treatments";
            dataAdapter = new SqlDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _previousForm.Show();
            this.Close();
        }

        private void medication_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void medication_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int treatmentId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["treatment_id"].Value);
                int animalId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["animal_id"].Value);
                int vetId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["vet_id"].Value);
                string diagnosis = dataGridView1.Rows[e.RowIndex].Cells["diagnosis"].Value.ToString();
                string treatment = dataGridView1.Rows[e.RowIndex].Cells["treatment"].Value.ToString();
                decimal cost = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cost"].Value);
                DateTime treatmentDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["treatment_date"].Value);

                MessageBox.Show($"تم اختيار العلاج: {treatment}\n" +
                                 $"التشخيص: {diagnosis}\n" +
                                 $"تكلفة العلاج: {cost:C}\n" +
                                 $"تاريخ العلاج: {treatmentDate.ToShortDateString()}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int treatmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["treatment_id"].Value);
                DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا العلاج؟", "تأكيد الحذف", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        ConnectToDatabase();
                        string query = "DELETE FROM Treatments WHERE treatment_id = @treatmentId";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@treatmentId", treatmentId);
                        command.ExecuteNonQuery();
                        connection.Close();
                        LoadData();
                        MessageBox.Show("تم الحذف بنجاح!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("حدث خطأ أثناء الحذف: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("يرجى تحديد صف للحذف.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int treatmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["treatment_id"].Value);
                ConnectToDatabase();
                string query = "UPDATE Treatments SET diagnosis = @diagnosis, treatment = @treatment, cost = @cost, treatment_date = @treatmentDate WHERE treatment_id = @treatmentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@diagnosis", textBox1.Text);
                command.Parameters.AddWithValue("@treatment", textBox2.Text);
                command.Parameters.AddWithValue("@cost", numericUpDown2.Value);
                command.Parameters.AddWithValue("@treatmentDate", dateTimePicker2.Value);
                command.Parameters.AddWithValue("@treatmentId", treatmentId);
                command.ExecuteNonQuery();
                connection.Close();
                LoadData();
                MessageBox.Show("تم التحديث بنجاح!");
            }
            else
            {
                MessageBox.Show("يرجى تحديد صف للتحديث.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || numericUpDown2.Value == 0 || dateTimePicker2.Value == null)
            {
                MessageBox.Show("يرجى تعبئة جميع الحقول.");
                return;
            }

            try
            {
                ConnectToDatabase();
                string query = "INSERT INTO Treatments (animal_id, vet_id, diagnosis, treatment, cost, treatment_date) VALUES (@animalId, @vetId, @diagnosis, @treatment, @cost, @treatmentDate)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@animalId", textBox3.Text);
                command.Parameters.AddWithValue("@vetId", textBox4.Text);
                command.Parameters.AddWithValue("@diagnosis", textBox1.Text);
                command.Parameters.AddWithValue("@treatment", textBox2.Text);
                command.Parameters.AddWithValue("@cost", numericUpDown2.Value);
                command.Parameters.AddWithValue("@treatmentDate", dateTimePicker2.Value);
                command.ExecuteNonQuery();
                connection.Close();
                LoadData();
                MessageBox.Show("تم الإضافة بنجاح!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء الإضافة: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // تأكد من أن قيمة النص في textBox1 ليست فارغة
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("يرجى إدخال قيمة للتشخيص.");
                return;
            }

            try
            {
                ConnectToDatabase();
                string query = "SELECT * FROM Treatments WHERE diagnosis LIKE @diagnosis";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@diagnosis", "%" + textBox1.Text + "%");

                // تنفيذ الاستعلام باستخدام SqlDataAdapter
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable searchResults = new DataTable();
                dataAdapter.Fill(searchResults);

                // تحديث DataGridView
                dataGridView1.DataSource = searchResults;

                // غلق الاتصال بعد استرجاع البيانات
                connection.Close();

                // التحقق إذا كانت هناك نتائج
                if (searchResults.Rows.Count == 0)
                {
                    MessageBox.Show("لم يتم العثور على نتائج.");
                }
                else
                {
                    MessageBox.Show($"تم العثور على {searchResults.Rows.Count} نتائج.");
                }
            }
            catch (Exception ex)
            {
                // عرض رسالة خطأ مفصلة
                MessageBox.Show("حدث خطأ أثناء البحث: " + ex.Message);
            }
        }


        // دوال الفاضية للأحداث
        private void numericUpDown2_ValueChanged(object sender, EventArgs e) { }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e) { }

        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}
