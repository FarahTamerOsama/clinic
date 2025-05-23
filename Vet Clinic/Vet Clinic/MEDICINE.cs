using System;
using System.Data;
using System.Data.SqlClient;  // إضافة هذا using لتمكين الاتصال بقاعدة البيانات
using System.Windows.Forms;

namespace Vet_Clinic
{
    public partial class MEDICINE : Form
    {
        private Form previousForm;
        private SqlConnection connection;  // الاتصال بقاعدة البيانات
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public MEDICINE(Form caller)
        {
            InitializeComponent();
            previousForm = caller;
        }

        public MEDICINE()
        {
            InitializeComponent();
        }

        // دالة لفتح الاتصال بقاعدة البيانات
        private void ConnectToDatabase()
        {
            string connectionString = "Server=DESKTOP-0N62OBP\\SQLEXPRESS;Database=Vet_clinic;Integrated Security=True"; // الاتصال بالسيرفر والقاعدة
            connection = new SqlConnection(connectionString); // تهيئة الاتصال
            connection.Open(); // فتح الاتصال
        }

        // دالة لتحميل البيانات من قاعدة البيانات وعرضها في DataGridView
        private void LoadData()
        {
            ConnectToDatabase();  // فتح الاتصال بقاعدة البيانات

            string query = "SELECT * FROM Medications";
            dataAdapter = new SqlDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);  // ملء البيانات في DataTable

            dataGridView1.DataSource = dataTable;
            connection.Close();  // غلق الاتصال بعد تحميل البيانات
        }

        // دالة لإرجاع المستخدم إلى لوحة التحكم الرئيسية
        private void button5_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        // دالة تحميل البيانات عند تحميل الفورم
        private void MEDICINE_Load(object sender, EventArgs e)
        {
            LoadData();  // تحميل البيانات عند تحميل الفورم
        }

        // دالة لغلق الاتصال بعد الانتهاء
        private void MEDICINE_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close(); // غلق الاتصال بقاعدة البيانات
            }
        }

        // هذا الحدث يتم تفعيله عند النقر على خلية في DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int medicationId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["medication_id"].Value);
                string name = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                int quantity = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["quantity"].Value);
                DateTime expirationDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["expiration_date"].Value);
                decimal price = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["price"].Value);
            }
        }

        // إضافة دوال فاضية للأحداث الغير معرفة
        private void button1_Click(object sender, EventArgs e) // Add
        {
            try
            {
                // فتح الاتصال بقاعدة البيانات
                ConnectToDatabase();

                // استعلام SQL لإضافة دواء جديد
                string query = "INSERT INTO Medications (name, quantity, expiration_date, price) VALUES (@name, @quantity, @expiration_date, @price)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", comboBox1.Text); command.Parameters.AddWithValue("@quantity", numericUpDown1.Value);  // إدخال الكمية من numericUpDown1
                command.Parameters.AddWithValue("@expiration_date", dateTimePicker2.Value);  // إدخال تاريخ الانتهاء من dateTimePicker2
                command.Parameters.AddWithValue("@price", numericUpDown1.Value);  // إدخال السعر من numericUpDown2

                command.ExecuteNonQuery();  // تنفيذ الاستعلام

                connection.Close();  // غلق الاتصال بعد تنفيذ الاستعلام

                // تحديث DataGridView بعد إضافة الدواء
                LoadData();
                MessageBox.Show("تم إضافة الدواء بنجاح.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء إضافة الدواء: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) // Update
        {
            try
            {
                // فتح الاتصال بقاعدة البيانات
                ConnectToDatabase();

                // تأكد من أنه تم تحديد صف في DataGridView
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // الحصول على medicationId من الصف المحدد في DataGridView
                    int medicationId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["medication_id"].Value);

                    // استعلام SQL لتحديث دواء بناءً على ID الدواء
                    string query = "UPDATE Medications SET name = @name, quantity = @quantity, expiration_date = @expiration_date, price = @price WHERE medication_id = @medication_id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", comboBox1.Text); 
                    command.Parameters.AddWithValue("@quantity", numericUpDown1.Value);  // إدخال الكمية من numericUpDown1
                    command.Parameters.AddWithValue("@expiration_date", dateTimePicker2.Value);  // إدخال تاريخ الانتهاء من dateTimePicker2
                    command.Parameters.AddWithValue("@price", numericUpDown1.Value);  // إدخال السعر من numericUpDown2
                    command.Parameters.AddWithValue("@medication_id", medicationId);  // إدخال ID الدواء من المتغير medicationId

                    command.ExecuteNonQuery();  // تنفيذ الاستعلام

                    connection.Close();  // غلق الاتصال بعد تنفيذ الاستعلام

                    // تحديث DataGridView بعد تحديث الدواء
                    LoadData();
                    MessageBox.Show("تم تحديث الدواء بنجاح.");
                }
                else
                {
                    MessageBox.Show("من فضلك اختر دواء من القائمة.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحديث الدواء: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e) // Delete
        {
            try
            {
                // التأكد من تحديد صف في DataGridView
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // الحصول على medicationId من الصف المحدد
                    int medicationId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["medication_id"].Value);

                    // فتح الاتصال بقاعدة البيانات
                    ConnectToDatabase();

                    // استعلام SQL لحذف الدواء بناءً على ID الدواء
                    string query = "DELETE FROM Medications WHERE medication_id = @medication_id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@medication_id", medicationId);  // إدخال ID الدواء من المتغير medicationId

                    command.ExecuteNonQuery();  // تنفيذ الاستعلام

                    connection.Close();  // غلق الاتصال بعد تنفيذ الاستعلام

                    // تحديث DataGridView بعد حذف الدواء
                    LoadData();
                    MessageBox.Show("تم حذف الدواء بنجاح.");
                }
                else
                {
                    MessageBox.Show("من فضلك اختر دواء من القائمة.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حذف الدواء: " + ex.Message);
            }
        }


        private void button4_Click(object sender, EventArgs e) // Search by ID
        {
            try
            {
                // فتح الاتصال بقاعدة البيانات
                ConnectToDatabase();

                // استعلام SQL للبحث عن الأدوية بناءً على الـ ID
                string query = "SELECT * FROM Medications WHERE medication_id = @medication_id";
                SqlCommand command = new SqlCommand(query, connection);

                // إضافة المعامل للبحث باستخدام الـ ID
                command.Parameters.AddWithValue("@medication_id", textBox1.Text);  // البحث باستخدام textBox1 (ID)

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable searchResults = new DataTable();
                dataAdapter.Fill(searchResults);  // ملء نتائج البحث في DataTable

                // ربط نتائج البحث بـ DataGridView
                dataGridView1.DataSource = searchResults;

                connection.Close();  // غلق الاتصال بعد تنفيذ الاستعلام

                // التحقق من وجود نتائج
                if (searchResults.Rows.Count == 0)
                {
                    MessageBox.Show("لم يتم العثور على نتائج.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء البحث: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // دالة فاضية مخصصة لـ textBox1 (medid)
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            // دالة فاضية مخصصة لـ comboBox1 (name)
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // دالة فاضية مخصصة لـ dateTimePicker1 (quantity)
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            // دالة فاضية مخصصة لـ dateTimePicker2 (expirationdate)
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // دالة فاضية مخصصة لـ numericUpDown1 (price)
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            // دالة فاضية مخصصة لـ numericUpDown1 (price)
        }

    }
}
