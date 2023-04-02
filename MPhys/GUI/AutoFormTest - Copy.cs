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
using MPhys.MyFunctions;

namespace MPhys.GUI
{
    public partial class AutoFormTest : Form
    {
        private System.Data.DataTable dataTable; // Current loaded dataTable (Tasks to perform)

        //Devices
        FC102C NDF1; FC102C NDF2;
        HR550_c MonoSpec;
        M9700 TempDev;
        PM100A PMDev;
        MyFunctionsClass myfunctions = new MyFunctionsClass();
        private bool DeviceInitialized = false;

        public AutoFormTest()
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

        private void buttonInit_Click(object sender, EventArgs e)
        {
            bool ok = connect_devices();
            if (ok)
            {
                labelInit.ForeColor = Color.Green;
                labelInit.Text = "Initialized - ready";
            }
            else
            {
                labelInit.ForeColor = Color.Red;
                labelInit.Text = "Not ready";
            }
        }
        private bool connect_devices()
        {
            bool all_good = true;


            MPhys.Devices.SCDid Mono = new MPhys.Devices.SCDid();
            string sNameM = ConfigurationManager.AppSettings.Get("iHR550_sName");
            string sIDM = ConfigurationManager.AppSettings.Get("iHR550_sID");
            Mono.sID = sIDM;
            Mono.sName = sNameM;

            MPhys.Devices.SCDid CCD = new MPhys.Devices.SCDid();
            string sNameC = ConfigurationManager.AppSettings.Get("iCCD_sName");
            string sIDC = ConfigurationManager.AppSettings.Get("iCCD_sID");
            CCD.sID = sIDC;
            CCD.sName = sNameC;

            // Mono & CCD
            try
            {
                //bool Bmono = true;
                MonoSpec = new HR550_c();
                MonoSpec.InitializeMono(Mono);
                /*while (Bmono == true)
                {
                    Bmono = MonoSpec.MonoIsBusy();
                }*/
                MonoSpec.InitializeCCD(CCD);
                myfunctions.add_to_log("bool connect_devices()", "Mono and CCD connected");
            }
            catch
            {
                all_good = false;
                MessageBox.Show("Issues with connecting with iHR550");
            }
            DeviceInitialized = all_good;
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
            ADCStringType adc = myfunctions.ReadFromBinaryFile<ADCStringType>("ADC_settings.dat");
            PairStringInt gain = myfunctions.ReadFromBinaryFile<PairStringInt>("Gain_settings.dat");

            if (Spectra.Checked)
            {
                MonoSpec.SetParameters(adc, gain);
            }
            else
            {
                MonoSpec.SetParameters(adc, gain, true);
            }

            if (DeviceInitialized && MonoSpec.ReadForAcq() && !MonoSpec.MonoIsBusy())
            {
                myfunctions.add_to_log("buttonRun_Clic", "auto_run() started");
                auto_run();
            }
            else
            {
                MessageBox.Show("Not ready to start the acquisition");
            }

        }

        private void auto_run()
        {
            double ct = 0.0; double ce = 0.0; // current temperature ; current exposure time
            Int32 cp1 = 0; Int32 cp2 = 0; // current possition 1, 2
            int count = 0;
            double mStart, mEnd;
            bool all_good = false;
            double Inc = 1; // nm

            if (checkBoxInc.Enabled)
            {
                try
                {
                    Inc = double.Parse(textBoxInc.Text.ToString());
                }
                catch
                {
                    MessageBox.Show("Unable to change Increment");
                    return;
                }
            }

            try
            {
                count = int.Parse(Count.Text.ToString());
            }
            catch
            {
                MessageBox.Show("Count is not set correctly");
                return;
            }

            try
            {
                mStart = double.Parse(textBoxStart.Text.ToString());
                mEnd = double.Parse(textBoxEnd.Text.ToString());
                if (mStart < mEnd && mStart>0)
                {
                    all_good = true;
                }
                else
                {
                    MessageBox.Show("Start and End are not set correctly");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Start and End are not set correctly");
                return;
            }

            if (count > 0 && all_good)
            {
                myfunctions.add_to_log("auto_run()", "Starting data acquisition");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    myfunctions.add_to_log("auto_run()", "Task"+i.ToString());
                    DataRow lastRow = dataTable.Rows[i];

                    double temp = double.Parse(lastRow["temperature"].ToString());
                    Int32 pos1 = Int32.Parse(lastRow["NDF1pos"].ToString());
                    myfunctions.add_to_log("auto_run()", lastRow["NDF1pos"].ToString());
                    //int pos2 = int.Parse(lastRow["NDF2pos"].ToString());
                    double expt = double.Parse(lastRow["ExpTime"].ToString());

                    myfunctions.add_to_log("auto_run()", "Setting devices...");
                    // Statements to avoid unecessary commands to be send
                    
                    if (ce != expt)
                    {
                        ce = expt;
                        MonoSpec.SetIntegrationTime(ce);
                        // Set exp time
                    }

                    double power = 0;

                    List<double> wavelengthdata;
                    List<double> intensitydata;
                    DataTable DataToBeSaved = new DataTable();

                    // Save data
                    myfunctions.add_to_log("auto_run()", "Getting data...");
                    MonoSpec.Test_GetData(mStart, mEnd, Inc);
                    myfunctions.add_to_log("auto_run()", "Data taken...");
                    wavelengthdata = MonoSpec.GetWavelengthDataColumn();
                    intensitydata = MonoSpec.GetIntensityDataColumn();

                    string intensityName = "Intensity0";
                    myfunctions.add_to_log("auto_run()", "Adding data to DataSet...");
                    myfunctions.DataAddColumn(ref DataToBeSaved, wavelengthdata, "Wavelength");
                    myfunctions.DataAddColumn(ref DataToBeSaved, intensitydata, intensityName);

                    wavelengthdata.Clear();
                    intensitydata.Clear();
                    myfunctions.add_to_log("auto_run()", "Taking N-1 times...");

                    // Getting data count-1 times
                    for (int j=1; j < count; j++)
                    {
                        myfunctions.add_to_log("auto_run()", "Getting data...");
                        MonoSpec.Test_GetData(mStart, mEnd, Inc);
                        intensitydata = MonoSpec.GetIntensityDataColumn();

                        intensityName = "Intensity" + j.ToString();
                        myfunctions.DataAddColumn(ref DataToBeSaved, intensitydata, intensityName);
                        wavelengthdata.Clear();
                        intensitydata.Clear();
                    }


                    // Name:  [SAMPLE]_[pos1]_[pos2]_[power]_[exp time]_[temp]K
                    string path;
                    path = default_path();
                    // Only for testing
                    cp1 = 0;
                    cp2 = 0;
                    ct = 0;

                    if(path == "")
                    {
                        path = FileName.Text.ToString();
                    }
                    string fullPath = path + "\\" + textSample.Text.ToString() + "_" + cp1 + "_" + cp2 +"_"+power +"_" + ce +"_"+ct+"K.csv";

                    myfunctions.add_to_log("auto_run()", "Saving " + fullPath);
                    myfunctions.ToCSV(DataToBeSaved, fullPath);
                    DataToBeSaved.Dispose();
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

        private void checkBoxInc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInc.Checked)
            {
                textBoxInc.Enabled = true;
            }
            else
            {
                textBoxInc.Enabled = false;
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
