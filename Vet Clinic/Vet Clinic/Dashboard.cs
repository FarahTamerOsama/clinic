using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Vet_Clinic
{
    public partial class Dashboard : Form
    {
        private Form previousForm;
        private string connectionString = "Server=DESKTOP-0N62OBP\\SQLEXPRESS;Database=Vet_clinic;Integrated Security=True";
        private System.Windows.Forms.Timer refreshTimer;

        public Dashboard(Form caller)
        {
            InitializeComponent();
            previousForm = caller;
        }

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadTotalCounts();
            LoadLastAppointments();
            StartAutoRefresh();
        }

        private void StartAutoRefresh()
        {
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 30000; // 30 ثانية
            refreshTimer.Tick += (s, e) =>
            {
                LoadTotalCounts();
                LoadLastAppointments();
            };
            refreshTimer.Start();
        }

        private void LoadTotalCounts()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Total Animals
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Animals", con);
                int totalAnimals = (int)cmd1.ExecuteScalar();
                label3.Text = totalAnimals.ToString();

                // Total Doctors
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Veterinarians", con);
                int totalDoctors = (int)cmd2.ExecuteScalar();
                label4.Text = totalDoctors.ToString();

                //Total vaccine
                SqlCommand cmd3 = new SqlCommand(
                "SELECT COUNT(*) FROM Medications WHERE name IS NOT NULL AND name <> ''", con);
                int totalNames = (int)cmd3.ExecuteScalar();
                label6.Text = totalNames.ToString();

                // Today's Appointments
                SqlCommand cmd4 = new SqlCommand(
                    "SELECT COUNT(*) FROM Appointments WHERE CAST(appointment_date AS DATE) = CAST(GETDATE() AS DATE)", con);
                int todaysAppointments = (int)cmd4.ExecuteScalar();
                label8.Text = todaysAppointments.ToString();

                con.Close();
            }
        }

        private void LoadLastAppointments()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Animal Name";
            dataGridView1.Columns[1].Name = "Appointment Date";
            dataGridView1.Columns[2].Name = "Doctor Name";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"
                    SELECT TOP 3 
                        a.name AS AnimalName,
                        ap.appointment_date,
                        v.name AS VetName
                    FROM Appointments ap
                    JOIN Animals a ON ap.animal_id = a.animal_id
                    JOIN Veterinarians v ON ap.vet_id = v.vet_id
                    ORDER BY ap.appointment_date DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string animalName = reader["AnimalName"].ToString();
                    string date = Convert.ToDateTime(reader["appointment_date"]).ToString("yyyy-MM-dd");
                    string doctorName = reader["VetName"].ToString();
                    dataGridView1.Rows.Add(animalName, date, doctorName);
                }

                reader.Close();
                con.Close();
            }
        }

        // Navigation Buttons

        private void button2_Click(object sender, EventArgs e) { }

        private void button7_Click(object sender, EventArgs e)
        {
            Veterinarian veterinarianForm = new Veterinarian(this);
            veterinarianForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (previousForm != null) previousForm.Show();
            Application.Exit();
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            owner ownerForm = new owner(this);
            ownerForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pets petsForm = new pets(this);
            petsForm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            appointment appointmentForm = new appointment(this);
            appointmentForm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MEDICINE medicineForm = new MEDICINE(this);
            medicineForm.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            medication medicationForm = new medication(this);
            medicationForm.Show();
            this.Hide();
        }

        // Unused Event Handlers

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
