using System;
using System.Data;
using System.Data.SqlClient;  // إضافة هذا using لتمكين الاتصال بقاعدة البيانات
using System.Windows.Forms;

namespace Vet_Clinic
{
    public partial class owner : Form
    {
        private Form _previousForm; // هنا بنخزن الفورم اللي كنا فيه
        private SqlConnection connection;  // الاتصال بقاعدة البيانات
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public owner(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm; // بنستلم الفورم القديم
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

            // استعلام SQL لاسترجاع البيانات من جدول Owners
            string query = "SELECT * FROM Owners";
            dataAdapter = new SqlDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);  // ملء البيانات في DataTable

            // ربط البيانات بـ DataGridView
            dataGridView1.DataSource = dataTable;

            connection.Close();  // غلق الاتصال بعد تحميل البيانات
        }

        // دالة لإرجاع المستخدم إلى الفورم السابق
        private void button4_Click(object sender, EventArgs e)
        {
            _previousForm.Show(); // نظهر الفورم القديم
            this.Close(); // نقفل الفورم الحالي
        }

        // دالة تحميل البيانات عند تحميل الفورم
        private void owner_Load(object sender, EventArgs e)
        {
            LoadData();  // تحميل البيانات عند تحميل الفورم
        }

        // دالة لغلق الاتصال بعد الانتهاء
        private void owner_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close(); // غلق الاتصال بقاعدة البيانات
            }
        }

        // هذا الحدث يتم تفعيله عند النقر على خلية في DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // تأكد من أن المستخدم نقر على خلية غير رأسية
            if (e.RowIndex >= 0)
            {
                // احصل على القيم من الأعمدة المحددة
                int ownerId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["owner_id"].Value); // العمود الأول: owner_id
                string ownerName = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();  // العمود الثاني: name
                string phone = dataGridView1.Rows[e.RowIndex].Cells["phone"].Value.ToString();  // العمود الثالث: phone
                string address = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();  // العمود الرابع: address

                // هنا يمكنك عرض رسالة أو استخدام البيانات في أشياء أخرى (مثلاً تعديل أو حذف)
                MessageBox.Show($"تم اختيار المالك:\n" +
                                 $"معرف المالك: {ownerId}\n" +
                                 $"الاسم: {ownerName}\n" +
                                 $"الهاتف: {phone}\n" +
                                 $"العنوان: {address}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //owneridtextbox
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//ownernametextbox
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//phonetextbox
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//addresstextbox
        {

        }

        private void button1_Click(object sender, EventArgs e) //buttonadd
        {
            try
            {
                ConnectToDatabase();

                // تأكد من أنك مش بتضيف owner_id لأن ده بيزيد تلقائيًا
                string query = "INSERT INTO Owners (name, phone, address) VALUES (@name, @phone, @address)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", string.IsNullOrWhiteSpace(textBox2.Text) ? DBNull.Value : (object)textBox2.Text); //owner_name
                command.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(textBox3.Text) ? DBNull.Value : (object)textBox3.Text); //phone
                command.Parameters.AddWithValue("@address", string.IsNullOrWhiteSpace(textBox4.Text) ? DBNull.Value : (object)textBox4.Text); //address

                command.ExecuteNonQuery();  // تنفيذ الاستعلام

                MessageBox.Show("تم إضافة المالك بنجاح");
                LoadData();  // تحميل البيانات بعد الإضافة
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e) //buttonupdate
        {
            try
            {
                ConnectToDatabase();

                // التأكد من أنك مش بتغير owner_id لأنه هو اللي معرفه
                string query = "UPDATE Owners SET name = @name, phone = @phone, address = @address WHERE owner_id = @owner_id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@owner_id", Convert.ToInt32(textBox1.Text)); //owner_id
                command.Parameters.AddWithValue("@name", string.IsNullOrWhiteSpace(textBox2.Text) ? DBNull.Value : (object)textBox2.Text); //owner_name
                command.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(textBox3.Text) ? DBNull.Value : (object)textBox3.Text); //phone
                command.Parameters.AddWithValue("@address", string.IsNullOrWhiteSpace(textBox4.Text) ? DBNull.Value : (object)textBox4.Text); //address

                command.ExecuteNonQuery();  // تنفيذ الاستعلام

                MessageBox.Show("تم تحديث المالك بنجاح");
                LoadData();  // تحميل البيانات بعد التحديث
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e) //buttondelete
        {
            try
            {
                ConnectToDatabase();

                string query = "DELETE FROM Owners WHERE owner_id = @owner_id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@owner_id", Convert.ToInt32(textBox1.Text)); //owner_id

                command.ExecuteNonQuery();  // تنفيذ الاستعلام

                MessageBox.Show("تم حذف المالك بنجاح");
                LoadData();  // تحميل البيانات بعد الحذف
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
