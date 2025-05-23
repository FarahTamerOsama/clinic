using Microsoft.VisualBasic.Logging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Vet_Clinic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            login.BackColor = ColorTranslator.FromHtml("#007BFF"); // لون أزرق حديث
            login.ForeColor = Color.White; // لون الخط أبيض
            login.FlatStyle = FlatStyle.Flat; // إزالة الحدود الافتراضية
            login.Font = new Font("Segoe UI", 14, FontStyle.Bold); // خط أنيق
            login.FlatAppearance.BorderSize = 0; // إزالة الإطار
            login.Size = new Size(180, 55); // ضبط الحجم
            login.Cursor = Cursors.Hand; // تغيير شكل المؤشر

            // تأثير تغيير اللون عند تمرير الماوس
            login.MouseEnter += (s, ev) => login.BackColor = ColorTranslator.FromHtml("#0056B3");
            login.MouseLeave += (s, ev) => login.BackColor = ColorTranslator.FromHtml("#007BFF");

            // تأثير عند الضغط على الزر
            login.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#00408A");

        }

        // جعل الزر بزوايا دائرية
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 20; // تحديد مقدار استدارة الزوايا
            path.AddArc(login.ClientRectangle.Left, login.ClientRectangle.Top, radius, radius, 180, 90);
            path.AddArc(login.ClientRectangle.Right - radius, login.ClientRectangle.Top, radius, radius, 270, 90);
            path.AddArc(login.ClientRectangle.Right - radius, login.ClientRectangle.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(login.ClientRectangle.Left, login.ClientRectangle.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            login.Region = new Region(path);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            login loginForm = new login(); // إنشاء نسخة من الفورم التاني
            loginForm.Show();              // عرض فورم الـ login
            this.Hide();
        }
    }
}
