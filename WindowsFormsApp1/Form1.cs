using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button5.Click += new System.EventHandler(this.button5_Click);
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-IES908U;Initial Catalog=CRUDFormGrid;Integrated Security=True");

        // Method to clear the form fields
        private void ClearForm()
        {
            // Clear all textboxes
            textBox1.Clear();

            // Reset combobox
            comboBox1.SelectedIndex = -1;

            // Reset radio buttons (deselect all)
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            // Uncheck all checkboxes
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Determine gender
                string gender = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;

                // Determine hobby
                string hobby = checkBox1.Checked ? checkBox1.Text : checkBox2.Text;

                // Determine status
                string status = radioButton4.Checked ? radioButton4.Text : radioButton3.Text;

                // Insert new record
                SqlCommand cmd = new SqlCommand("insert into grid (name, country, gender, hobby, stutus) values (@name, @country, @gender, @hobby, @stutus)", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@country", comboBox1.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@hobby", hobby);
                cmd.Parameters.AddWithValue("@stutus", status);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully saved");

                // Fetch all records from the table
                SqlCommand fetchCmd = new SqlCommand("SELECT * FROM grid", con);
                SqlDataAdapter adapter = new SqlDataAdapter(fetchCmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Bind the fetched data to the DataGridView
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Clear form after insertion
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete grid where name= @name", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully deleted");

                SqlCommand fetchCmd = new SqlCommand("SELECT * FROM grid", con);
                SqlDataAdapter adapter = new SqlDataAdapter(fetchCmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Clear form after deletion
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string gender = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;
                string hobby = checkBox1.Checked ? checkBox1.Text : checkBox2.Text;
                string stutus = radioButton4.Checked ? radioButton4.Text : radioButton3.Text;

                SqlCommand cmd = new SqlCommand("update grid set country=@country,gender=@gender,hobby=@hobby,stutus=@stutus where name= @name", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@country", comboBox1.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@hobby", hobby);
                cmd.Parameters.AddWithValue("@stutus", stutus);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated");

                SqlCommand fetchCmd = new SqlCommand("SELECT * FROM grid", con);
                SqlDataAdapter adapter = new SqlDataAdapter(fetchCmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Clear form after update
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from grid where name= @name", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Clear form after search
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand fetchCmd = new SqlCommand("SELECT * FROM grid", con);
                SqlDataAdapter adapter = new SqlDataAdapter(fetchCmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
