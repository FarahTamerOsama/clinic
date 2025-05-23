using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Vet_Clinic
{
    public partial class appointment : Form
    {
        private Form _previousForm;
        private SqlConnection connection;
        private string connectionString = "Server=DESKTOP-0N62OBP\\SQLEXPRESS;Database=Vet_clinic;Integrated Security=true;";

        public appointment(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        private void appointment_Load(object sender, EventArgs e)
        {
            LoadAppointmentsData();
        }

        private void LoadAppointmentsData()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT appointment_id, animal_id, vet_id, appointment_date, service_type, status FROM Appointments";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
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

        private void button3_Click(object sender, EventArgs e) // Add
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "INSERT INTO Appointments (animal_id, vet_id, appointment_date, service_type, status) " +
                               "VALUES (@animal_id, @vet_id, @appointment_date, @service_type, NULL)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@animal_id", string.IsNullOrWhiteSpace(comboBox1.Text) ? DBNull.Value : (object)int.Parse(comboBox1.Text));
                command.Parameters.AddWithValue("@vet_id", string.IsNullOrWhiteSpace(comboBox2.Text) ? DBNull.Value : (object)int.Parse(comboBox2.Text));
                command.Parameters.AddWithValue("@appointment_date", string.IsNullOrWhiteSpace(dateTimePicker1.Text) ? DBNull.Value : (object)DateTime.Parse(dateTimePicker1.Text));
                command.Parameters.AddWithValue("@service_type", string.IsNullOrWhiteSpace(textBox1.Text) ? DBNull.Value : (object)textBox1.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("تم إضافة الموعد بنجاح");
                LoadAppointmentsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء الإضافة: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e) // Edit
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int appointmentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["appointment_id"].Value);

                    connection = new SqlConnection(connectionString);
                    connection.Open();

                    string query = "UPDATE Appointments SET animal_id = @animal_id, vet_id = @vet_id, " +
                                   "appointment_date = @appointment_date, service_type = @service_type " +
                                   "WHERE appointment_id = @appointment_id";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@animal_id", string.IsNullOrWhiteSpace(comboBox1.Text) ? DBNull.Value : (object)int.Parse(comboBox1.Text));
                    command.Parameters.AddWithValue("@vet_id", string.IsNullOrWhiteSpace(comboBox2.Text) ? DBNull.Value : (object)int.Parse(comboBox2.Text));
                    command.Parameters.AddWithValue("@appointment_date", string.IsNullOrWhiteSpace(dateTimePicker1.Text) ? DBNull.Value : (object)DateTime.Parse(dateTimePicker1.Text));
                    command.Parameters.AddWithValue("@service_type", string.IsNullOrWhiteSpace(textBox1.Text) ? DBNull.Value : (object)textBox1.Text);
                    command.Parameters.AddWithValue("@appointment_id", appointmentId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("تم تعديل بيانات الموعد بنجاح");
                    LoadAppointmentsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء التعديل: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e) // Delete
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int appointmentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["appointment_id"].Value);

                    connection = new SqlConnection(connectionString);
                    connection.Open();

                    string query = "DELETE FROM Appointments WHERE appointment_id = @appointment_id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@appointment_id", appointmentId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("تم حذف الموعد بنجاح");
                    LoadAppointmentsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء الحذف: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e) // Search
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT appointment_id, animal_id, vet_id, appointment_date, service_type, status " +
                               "FROM Appointments WHERE service_type LIKE @searchTerm";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@searchTerm", "%" + textBox1.Text + "%");

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء البحث: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e) // رجوع
        {
            _previousForm.Show();
            this.Close();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // ممكن تسيبه فاضي أو تكتب الكود اللي انت عايزه
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // ممكن تسيبه فاضي أو تكتب الكود اللي انت عايزه
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ممكن تسيبه فاضي أو تكتب الكود اللي انت عايزه
        }

    }
}
