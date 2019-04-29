using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using EEGSoftWare;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class PatientReg : Form
    {
        public OleDbConnection connection = new OleDbConnection();
        public string P_ID;
        public PatientReg()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\EEG_Mavencube.accdb";
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            groupBox1.Width = (Screen.PrimaryScreen.Bounds.Width / 2) - 10;
            p_detail_grp.Location = new Point(groupBox1.Width+40,40);
            groupBox1.Location = new Point(20, 40);
            p_detail_grp.Width = (Screen.PrimaryScreen.Bounds.Width / 2) - 50;
            p_record_data.Height = groupBox1.Height = p_detail_grp.Height = (Screen.PrimaryScreen.Bounds.Height-200);


            p_record_data.Location = new Point(groupBox1.Width + 40, 40);
            p_record_data.Width = (Screen.PrimaryScreen.Bounds.Width / 2) - 50;

            


            groupBox2.Width = (Screen.PrimaryScreen.Bounds.Width / 2) - 10;
            groupBox4.Location = new Point(groupBox1.Width + 40, Screen.PrimaryScreen.Bounds.Height-100);
            groupBox2.Location = new Point(20, Screen.PrimaryScreen.Bounds.Height - 100);
            groupBox4.Width = (Screen.PrimaryScreen.Bounds.Width / 2) - 50;

            pictureBox5.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 35, 0);
            pictureBox6.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 70, 0);

            dataGridView2.SelectionMode = dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = dataGridView1.MultiSelect = false;
            dataGridView2.EditMode = dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void PatientReg_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eEG_MavencubeDataSet2.PatientData_T' table. You can move, or remove it, as needed.
            this.patientData_TTableAdapter.Fill(this.eEG_MavencubeDataSet2.PatientData_T);
            // TODO: This line of code loads data into the 'eEG_MavencubeDataSet1.PatientData_T' table. You can move, or remove it, as needed.
            this.patientData_TTableAdapter.Fill(this.eEG_MavencubeDataSet.PatientData_T);
            // TODO: This line of code loads data into the 'eEG_MavencubeDataSet.PatientData_T' table. You can move, or remove it, as needed.
           // this.patientData_TTableAdapter.Fill(this.eEG_MavencubeDataSet.PatientData_T);

            this.patient_TTableAdapter.Fill(this.eEG_MavencubeDataSet.Patient_T);
           this.dataGridView2.Columns[0].Visible = false;
            this.dataGridView2.Columns[1].Visible = false;
            this.dataGridView2.Columns[4].Visible = false;
            this.dataGridView2.Columns[3].Visible = false;
            this.dataGridView2.Columns[6].Visible = false;
            this.dataGridView2.Columns[7].Visible = false;
            this.dataGridView2.Columns[8].Visible = false;

            this.dataGridView2.Columns[2].Width = this.dataGridView2.Width / 2;
            this.dataGridView2.Columns[5].Width = this.dataGridView2.Width / 2;

            viewData();

            try
            {
               
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error",ex.Message);
            }

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
            System.Windows.Forms.Application.Exit();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (validationInputText())
            {
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();

                if (save_up.Text == "Save")
                {


                    
                    cmd.CommandText = "Insert into Patient_T(firstname,lastname,age,address,sex,contactno)Values('" + fname.Text + "','" + lname.Text + "','" + age.Text + "','" + address.Text + "','" + sex.Text + "','" + contact.Text + "')";
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Patient Added Successfully", "Congrats");

                   
                }
                else
                {
                    string str = "UPDATE Patient_T SET firstname = ?,lastname = ?,address =?,sex = ?,contactno = ? ,age = ? WHERE ID = ?";

                   // string queryString = "UPDATE Patient_T set firstname='" + fname.Text + "',lastname='" + lname.Text + "',address='" + address.Text + "',sex='"+sex.Text+"',contact='"+contact.Text+"',age='"+age.Text+"' where ID=1";
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = str;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("firstname", fname.Text);
                    cmd.Parameters.AddWithValue("lastname", lname.Text);
                    cmd.Parameters.AddWithValue("address", address.Text);
                    cmd.Parameters.AddWithValue("sex", sex.Text);
                    cmd.Parameters.AddWithValue("contactno", contact.Text);
                    cmd.Parameters.AddWithValue("age", age.Text);
                    cmd.Parameters.AddWithValue("ID", Convert.ToInt32( P_ID));

                  
                    
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Patient details updated Successfully", "Congrats");

                   
                }
                connection.Close();
                LoadData();
                clearText(sender, e);
            }
           
        }
        private Boolean validationInputText()
        {
            bool valid = true;
            if (fname.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter first name");
                valid = false;
            }
            else if (contact.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter contact number");
                valid = false;
            }
            else if (age.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter correct age");
                valid = false;
            }
            else if (sex.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter appropiate gender");
                valid = false;
            }
            return valid;
        }
        private void patient_TBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.patient_TBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.eEG_MavencubeDataSet);

        }

        public void LoadData()
        {

            
            string query = "SELECT * From Patient_T";
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Refresh();
            }
        }

        private void age_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch !=8)
            {
                e.Handled = true;
            }
            else
            {
                MessageBox.Show("Enter valid number");
            }
        }

        private void clearText(object sender, EventArgs e)
        {
            p_record_data.Visible = false;
            p_detail_grp.Visible = true;
            fname.Text = lname.Text = age.Text = address.Text = contact.Text = sex.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            P_ID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Form1 fm = new Form1(false);
                fm.patient_id = P_ID;
                fm.ShowDialog();
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            P_ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            p_record_data.Visible = true;
            p_detail_grp.Visible = false;
            viewData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p_record_data.Visible = false;
            p_detail_grp.Visible = true;
            P_ID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            fname.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            lname.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            address.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            age.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            sex.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            contact.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
            save_up.Text = "Update";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            P_ID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Do you really want to delete patient record", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                connection.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM Patient_T WHERE ID = " + Convert.ToInt32(P_ID), connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                LoadData();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }
       
        public void insertPatientRecord(string p_id,string start_time,string end_time, string data,string montage,string highpass,string lowpass)
        {
           
            try
            {
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();
                // cmd.CommandText = "Insert into PatientData_T(p_id,test_start_time,test_end_time,data)Values('3','12:40','12:50','hello')";//'" + data + "'
                cmd.CommandText = "Insert into PatientData_T(p_id,test_start_time,test_end_time,data,duration,montage,hpass,lpass)Values('" + p_id + "','" + start_time + "','" + end_time + "','" + data + "','"+getTimeDifference(start_time, end_time) +"','"+montage+"','"+highpass+"','"+lowpass+"')";//'" + data + "'
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Recorded Successfully", "Congrats");

                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Record not done "+ ex.Message, "Sorry");
            }
            connection.Close();
        }

        public string getTimeDifference(string start_time,string end_time)
        {

            DateTime dateOne = Convert.ToDateTime(start_time);
            DateTime dateTwo = Convert.ToDateTime(end_time);
            var diff = dateTwo.Subtract(dateOne);
            string str_h;
            string str_m;
            string str_s;
            if (diff.Hours<10)
            {
                str_h = "0" + diff.Hours;
            }
            else
            {
                str_h = "" + diff.Hours;
            }
            if (diff.Minutes < 10)
            {
                str_m = "0" + diff.Minutes;
            }
            else
            {
                str_m = "" + diff.Minutes;
            }
            if (diff.Seconds < 10)
            {
                str_s = "0" + diff.Seconds;
            }
            else
            {
                str_s = "" + diff.Seconds;
            }
            return str_h+":"+str_m+":"+str_s;
        }

        private void viewData()
        {
            P_ID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            string strSQL = "SELECT * FROM PatientData_T WHERE p_id='"+P_ID+"'";
            OleDbCommand command = new OleDbCommand(strSQL, connection);
            connection.Open();

            using (OleDbDataAdapter adapter = new OleDbDataAdapter(strSQL, connection))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                dataGridView2.Refresh();
            }




          /*  OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Debug.WriteLine("{0} {1}", reader["test_start_time"].ToString(), reader["duration"].ToString());
            }*/
            connection.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           
            string j_data = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[4].Value.ToString();
            Form1 fm = new Form1(true);
            fm.isPatientData = true;
            fm.dateTime = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
            fm.patientName = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString()+" "+ dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            fm.patientID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            fm.patientAge = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString() + " years";
            fm.p_low = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[8].Value.ToString();
            fm.p_high = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[7].Value.ToString();
            fm.lineGraph.viewDataOnChart(j_data,fm.y_chart_min,fm.sample_rate);
            fm.viewMontage(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[6].Value.ToString());
               // dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[7].Value.ToString(),
               // dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[8].Value.ToString());
            fm.ShowDialog();
           
        }
    }
}
