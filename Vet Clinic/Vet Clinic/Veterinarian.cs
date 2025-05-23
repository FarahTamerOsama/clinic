using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Vet_Clinic
{
    public partial class Veterinarian : Form
    {
        private Form previousForm;
        private SqlConnection connection;
        private string connectionString = "Server=DESKTOP-0N62OBP\\SQLEXPRESS;Database=Vet_clinic;Integrated Security=true;";

        public Veterinarian(Form caller)
        {
            InitializeComponent();
            previousForm = caller;
        }
        
        public Veterinarian()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // txtspecialisty
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // idtxtbox
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // nametxtbox
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e) // experience
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["vet_id"].Value.ToString();
                textBox2.Text = row.Cells["name"].Value.ToString();
                comboBox1.Text = row.Cells["specialty"].Value.ToString();
                textBox4.Text = row.Cells["experience_years"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Close();
        }

        private void Veterinarian_Load(object sender, EventArgs e)
        {
            LoadVeterinariansData();
        }

        private void LoadVeterinariansData()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT vet_id, name, specialty, experience_years FROM Veterinarians";
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

        private void button8_Click(object sender, EventArgs e) // btnadd
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "INSERT INTO Veterinarians (name, specialty, experience_years) VALUES (@name, @specialty, @experience)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", string.IsNullOrWhiteSpace(textBox2.Text) ? DBNull.Value : (object)textBox2.Text);
                command.Parameters.AddWithValue("@specialty", string.IsNullOrWhiteSpace(comboBox1.Text) ? DBNull.Value : (object)comboBox1.Text);
                command.Parameters.AddWithValue("@experience", string.IsNullOrWhiteSpace(textBox4.Text) ? DBNull.Value : (object)textBox4.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("تمت إضافة الطبيب البيطري بنجاح");
                LoadVeterinariansData();
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

        private void button10_Click(object sender, EventArgs e) // btnupdate
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "UPDATE Veterinarians SET name = @name, specialty = @specialty, experience_years = @experience WHERE vet_id = @vet_id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@vet_id", Convert.ToInt32(textBox1.Text));
                command.Parameters.AddWithValue("@name", string.IsNullOrWhiteSpace(textBox2.Text) ? DBNull.Value : (object)textBox2.Text);
                command.Parameters.AddWithValue("@specialty", string.IsNullOrWhiteSpace(comboBox1.Text) ? DBNull.Value : (object)comboBox1.Text);
                command.Parameters.AddWithValue("@experience", string.IsNullOrWhiteSpace(textBox4.Text) ? DBNull.Value : (object)textBox4.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("تم تحديث بيانات الطبيب البيطري بنجاح");
                LoadVeterinariansData();
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

        private void button9_Click(object sender, EventArgs e) // btndelete
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "DELETE FROM Veterinarians WHERE vet_id = @vet_id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@vet_id", Convert.ToInt32(textBox1.Text));

                command.ExecuteNonQuery();
                MessageBox.Show("تم حذف الطبيب البيطري بنجاح");
                LoadVeterinariansData();
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
    }
}
