using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace formdanhsachsv
{
    public partial class Form1 : Form
    {
        private List<Student> students = new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Mã sinh viên"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Tên sinh viên"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Class",
                HeaderText = "Lớp học"
            });

            dataGridView1.DataSource = students;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Thêm sinh viên
            var student = new Student
            {
                Id = int.Parse(textBox1.Text),
                Name = textBox2.Text,
                Class = textBox3.Text
            };
            students.Add(student);
            RefreshDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Sửa sinh viên
            if (dataGridView1.CurrentRow != null)
            {
                var student = dataGridView1.CurrentRow.DataBoundItem as Student;
                if (student != null)
                {
                    student.Id = int.Parse(textBox1.Text);
                    student.Name = textBox2.Text;
                    student.Class = textBox3.Text;
                    RefreshDataGridView();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Xóa sinh viên
            if (dataGridView1.CurrentRow != null)
            {
                var student = dataGridView1.CurrentRow.DataBoundItem as Student;
                if (student != null)
                {
                    students.Remove(student);
                    RefreshDataGridView();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Điền dữ liệu vào các ô textbox từ hàng được chọn
            if (dataGridView1.CurrentRow != null)
            {
                var student = dataGridView1.CurrentRow.DataBoundItem as Student;
                if (student != null)
                {
                    textBox1.Text = student.Id.ToString();
                    textBox2.Text = student.Name;
                    textBox3.Text = student.Class;
                }
            }
        }

        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }

        // Các xử lý sự kiện khác
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
    }
}
