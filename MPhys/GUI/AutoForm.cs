using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPhys.Devices;
using System.Configuration;
using System.Threading;

namespace MPhys.GUI
{
    public partial class AutoForm : Form
    {
        private System.Data.DataTable dataTable; // Current loaded dataTable (Tasks to perform)

        //Devices
        FC102C NDF1, NDF2;
        HR550 MonoSpec;
        M9700 TempDev;
        PM100A PMDev;

        public AutoForm()
        {
            InitializeComponent();
            this.Location = new Point(60, 26);
            this.ControlBox = false;
            this.TopLevel = false;
            this.TopMost = true;

            comboNDF1pos.SelectedIndex = 0;
            comboNDF2pos.SelectedIndex = 0;
            //comboNDF1pos.Text = "Select";
            //comboNDF2pos.Text = "Select";
            textBoxTemp.Text = "295.55";
            textBoxExp.Text = "0.1";

            dataTable = new DataTable();
            dataTable.TableName = "PendingTask";
            Create_DataSet();
        }

        private bool connect_devices()
        {
            bool all_good = true;

            string NDF1port = ConfigurationManager.AppSettings.Get("NDF1");
            string NDF2port = ConfigurationManager.AppSettings.Get("NDF2");
            string PMport = ConfigurationManager.AppSettings.Get("PM100A");
            string M9700port = ConfigurationManager.AppSettings.Get("M9700");

            SCDid Mono = new SCDid();
            string sNameM = ConfigurationManager.AppSettings.Get("iHR550_sName");
            string sIDM = ConfigurationManager.AppSettings.Get("iHR550_sID");
            Mono.sID = sIDM;
            Mono.sName = sNameM;

            SCDid CCD = new SCDid();
            string sNameC = ConfigurationManager.AppSettings.Get("iCCD_sName");
            string sIDC = ConfigurationManager.AppSettings.Get("iCCD_sID");
            CCD.sID = sIDC;
            CCD.sName = sNameC;

            // NDF1
            try
            {
                NDF1 = new FC102C(NDF1port);
                if (NDF1.IsOpen() == 1)
                {
                }
                else
                {
                    all_good = false;
                    MessageBox.Show("NDF1 connection cannot be opened");
                }
            }
            catch
            {
                all_good = false;
                MessageBox.Show("NDF1 not connected");
            }
            // NDF2
            try
            {
                NDF2 = new FC102C(NDF2port);
                if (NDF2.IsOpen() == 1)
                {
                }
                else
                {
                    all_good = false;
                    MessageBox.Show("NDF2 connection cannot be opened");
                }
            }
            catch
            {
                all_good = false;
                MessageBox.Show("NDF2 not connected");
            }
            // PM
            try
            {
                PMDev = new PM100A(PMport);
                PMDev.Get_power();
            }
            catch
            {
                all_good = false;
                MessageBox.Show("PM100A not connected");
            }
            // TEMP
            try
            {
                TempDev = new M9700(M9700port);
                TempDev.Open();
                TempDev.Close();
            }
            catch
            {
                all_good = false;
                MessageBox.Show("Temperature controller not connected");
            }
            // Mono & CCD
            try
            {
                MonoSpec = new HR550();
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                if (MonoSpec.can_be_initialized())
                {
                    MonoSpec.InitializeMono(Mono);
                    MonoSpec.InitializeMono(CCD);
                }


            }
            catch
            {
                all_good = false;
                MessageBox.Show("Issues with connecting with iHR550");
            }

            return all_good;

        }


        private bool Check_unique_rows()
        {
            DataView view = new DataView(dataTable);
            DataTable distinctValues = view.ToTable(true, "temperature", "NDF1pos", "NDF2pos", "ExpTime");
            if(distinctValues.Rows.Count == dataTable.Rows.Count)
            {
                return true;
            }
            else
            {
                dataTable = distinctValues;
                MessageBox.Show("This value was already entered");
                return false;
            }
        }

        private void Create_DataSet()
        {
            DataColumn column;
            
            // TEMP
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "temperature";
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            //NDF1
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "NDF1pos";
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            //NDF2
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "NDF2pos";
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            //Exposure Time
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "ExpTime";
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);
        }

        private void Update_TextBox()
        {
            string textrow;
            listBoxTasks.Items.Clear();
            for (int i =0; i < dataTable.Rows.Count; i++)
            {
                DataRow lastRow = dataTable.Rows[i];

                string id = i.ToString();
                string temp = lastRow["temperature"].ToString();
                string pos1 = lastRow["NDF1pos"].ToString();
                string pos2 = lastRow["NDF2pos"].ToString();
                string expt = lastRow["ExpTime"].ToString();

                textrow = id + "  |  " + temp + "  |  " + pos1 + "  |  " + pos2 + "  |  " + expt + "  ";
                listBoxTasks.Items.Add(textrow);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DataRow row;

            try
            {
                double expt = double.Parse(textBoxExp.Text);
                double temp = double.Parse(textBoxTemp.Text);
                int pos1 = int.Parse(comboNDF1pos.SelectedItem.ToString());
                int pos2 = int.Parse(comboNDF2pos.SelectedItem.ToString());
                int id;

                if (temp < 5.0 || temp > 400)
                {
                    MessageBox.Show("Temperature is too small or too big");
                    return;
                }
                if (expt < 0.01)
                {
                    MessageBox.Show("Exposure time is too small");
                    return;
                }

                row = dataTable.NewRow();

                id = dataTable.Rows.Count;
                row["temperature"] = temp;
                row["NDF1pos"] = pos1;
                row["NDF2pos"] = pos2; 
                row["ExpTime"] = expt;
                dataTable.Rows.Add(row);

                string text = id + "  |  " + temp + "  |  " + pos1 + "  |  " + pos2 + "  |  " + expt + "  ";
                if (Check_unique_rows())
                {
                    listBoxTasks.Items.Add(text);
                    enable_Run();
                }
                    

            }
            catch
            {
                MessageBox.Show("Incorrect inputs, cannot add");
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string CombinedPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Profiles");
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = System.IO.Path.GetFullPath(CombinedPath);
            dlg.Filter = "xml files (*.xml)|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dataTable.Clear();
                string fileName;
                fileName = dlg.FileName;
                dataTable.ReadXml(fileName);
            }

            Update_TextBox();
            enable_Run();
        }

        private void buttonSaveProfile_Click(object sender, EventArgs e)
        {
            string path = ".\\Profiles";
            System.IO.Directory.CreateDirectory(path);

            string filename = "ProfileName";

            if (InputBox("Save the profile", "Enter the name of the profile (.xml)", ref filename) == DialogResult.OK)
            {
                string final_path = path + "\\" + filename + ".xml";
                if (System.IO.File.Exists(final_path) == false)
                {
                    dataTable.WriteXml(final_path);
                }
                else
                {
                    MessageBox.Show("File with the given name already exists. Profile has not been saved");
                }
            }
            
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void enable_Run()
        {
            if(dataTable.Rows.Count > 0)
            {
                buttonRun.Enabled = true;
            }

            labelMaxTask.Text = dataTable.Rows.Count.ToString();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (connect_devices())
            {
                Console.WriteLine("Go on");
                auto_run();
            }

        }

        private void auto_run()
        {
            double ct = 0.0, ce = 0.0; // current temperature ; current exposure time
            int cp1 = 0, cp2 = 0; // current possition 1, 2
            int count = 0;
            try
            {
                count = int.Parse(Count.Text.ToString());
            }
            catch
            {
                MessageBox.Show("Count is not set correctly");
            }

            if(count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow lastRow = dataTable.Rows[i];

                    double temp = double.Parse(lastRow["temperature"].ToString());
                    int pos1 = int.Parse(lastRow["NDF1pos"].ToString());
                    int pos2 = int.Parse(lastRow["NDF2pos"].ToString());
                    double expt = double.Parse(lastRow["ExpTime"].ToString());

                    // Statements to avoid unecessary commands to be send
                    if (ct != temp)
                    {
                        ct = temp;
                        // Set temp
                    }
                    if (cp1 != pos1)
                    {
                        cp1 = pos1;
                        // Set pos1
                    }
                    if (cp2 != pos2)
                    {
                        cp2 = pos2;
                        // Set pos2
                    }
                    if (ce != expt)
                    {
                        ce = expt;
                        // Set exp time
                    }

                    // Wait for pos to change

                    // Wait for temp to change

                    // Take spectra

                    // Take power

                    // Save data
                    // Name:  [SAMPLE]_[pos1]_[pos2]_[power]_[exp time]_[temp]K
                    string path;
                    path = default_path();
                    if(path == "")
                    {
                        path = FileName.Text.ToString();
                    }
                    //MonoSpec.GoStream(path, count, 2);

                }
            }
            else
            {
                MessageBox.Show("Count is not set. It's current value is: 0 (must be greater than that)");
            }
           
        }

        private void OpenPathDialog_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.SelectedPath;
                FileName.Text = fileName;
            }
        }

        private string default_path()
        {
            string path = "";
            string temp;

            if (FileName.Text.ToString() == "Default")
            {
                path = ".\\Data";
                DateTime aDate = DateTime.Now;
                temp = aDate.ToString("dd MMMM yyyy HH:mm").Replace(" ", "").Replace(":","");
                path = path + "\\" + temp;
                Console.WriteLine(temp);

                System.IO.Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
