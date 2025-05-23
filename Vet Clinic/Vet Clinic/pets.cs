using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vet_Clinic
{
    public partial class pets : Form
    {
        private Form _previousForm;
        private SqlConnection connection;
        private string connectionString = "Server=DESKTOP-0N62OBP\\SQLEXPRESS;Database=Vet_clinic;Integrated Security=true;";

        public pets(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        public pets()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _previousForm.Show();
            this.Close();
        }

        private void pets_Load(object sender, EventArgs e)
        {
            LoadAnimalsData();
        }

        private void LoadAnimalsData()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT animal_id, name, species, breed, age, gender, health_status FROM Animals";
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

        private void button1_Click(object sender, EventArgs e) // Add
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "INSERT INTO Animals (name, species, breed, age, gender, health_status) VALUES (@name, @species, @breed, @age, @gender, @health_status)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", string.IsNullOrWhiteSpace(textBox2.Text) ? DBNull.Value : (object)textBox2.Text);
                command.Parameters.AddWithValue("@species", string.IsNullOrWhiteSpace(textBox5.Text) ? DBNull.Value : (object)textBox5.Text);
                command.Parameters.AddWithValue("@breed", string.IsNullOrWhiteSpace(textBox4.Text) ? DBNull.Value : (object)textBox4.Text);
                command.Parameters.AddWithValue("@age", string.IsNullOrWhiteSpace(textBox3.Text) ? DBNull.Value : (object)textBox3.Text);
                command.Parameters.AddWithValue("@gender", string.IsNullOrWhiteSpace(textBox7.Text) ? DBNull.Value : (object)textBox7.Text);
                command.Parameters.AddWithValue("@health_status", string.IsNullOrWhiteSpace(textBox6.Text) ? DBNull.Value : (object)textBox6.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("تمت إضافة الحيوان بنجاح");
                LoadAnimalsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e) // Update
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "UPDATE Animals SET name = @name, species = @species, breed = @breed, age = @age, gender = @gender, health_status = @health_status WHERE animal_id = @animal_id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@animal_id", Convert.ToInt32(textBox1.Text));
                command.Parameters.AddWithValue("@name", string.IsNullOrWhiteSpace(textBox2.Text) ? DBNull.Value : (object)textBox2.Text);
                command.Parameters.AddWithValue("@species", string.IsNullOrWhiteSpace(textBox5.Text) ? DBNull.Value : (object)textBox5.Text);
                command.Parameters.AddWithValue("@breed", string.IsNullOrWhiteSpace(textBox4.Text) ? DBNull.Value : (object)textBox4.Text);
                command.Parameters.AddWithValue("@age", string.IsNullOrWhiteSpace(textBox3.Text) ? DBNull.Value : (object)textBox3.Text);
                command.Parameters.AddWithValue("@gender", string.IsNullOrWhiteSpace(textBox7.Text) ? DBNull.Value : (object)textBox7.Text);
                command.Parameters.AddWithValue("@health_status", string.IsNullOrWhiteSpace(textBox6.Text) ? DBNull.Value : (object)textBox6.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("تم تحديث بيانات الحيوان بنجاح");
                LoadAnimalsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e) // Delete
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "DELETE FROM Animals WHERE animal_id = @animal_id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@animal_id", Convert.ToInt32(textBox1.Text));

                command.ExecuteNonQuery();
                MessageBox.Show("تم حذف الحيوان بنجاح");
                LoadAnimalsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["animal_id"].Value.ToString();
                textBox2.Text = row.Cells["name"].Value.ToString();
                textBox5.Text = row.Cells["species"].Value.ToString();
                textBox4.Text = row.Cells["breed"].Value.ToString();
                textBox3.Text = row.Cells["age"].Value.ToString();
                textBox7.Text = row.Cells["gender"].Value.ToString();
                textBox6.Text = row.Cells["health_status"].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // animalid
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // name
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e) // age
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e) // breed
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e) // species
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e) // healthstatus
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e) // gendertxtbox
        {
        }
    }
}
