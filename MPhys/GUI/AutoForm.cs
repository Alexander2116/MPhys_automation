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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices.WindowsRuntime;

namespace MPhys.GUI
{
    public partial class AutoForm : Form
    {
        private System.Data.DataTable dataTable; // Current loaded dataTable (Tasks to perform)

        //Devices
        FC102C NDF1; FC102C NDF2;
        HR550 MonoSpec;
        M9700 TempDev;
        PM100A PMDev;
        MyFunctionsClass myfunctions = new MyFunctionsClass();
        private bool DeviceInitialized = false;

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
            textBoxSlit.Text = "0.1";

            dataTable = new DataTable();
            dataTable.TableName = "PendingTask";
            Create_DataSet();
            MonoSpec = new HR550();
        }

        private async void buttonInit_Click(object sender, EventArgs e)
        {
            bool ok = connect_devices();
            if (ok)
            {
                labelInit.ForeColor = Color.Green;
                labelInit.Text = "Initialized - ready";
                await Task.Run(() => UpdateTemp());
            }
            else
            {
                labelInit.ForeColor = Color.Red;
                labelInit.Text = "Not ready";
            }
        }

        private async Task UpdateTemp() // only use I see is awaited anyways, so why make it a Task?
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(2000);
                    textCurrTemp.Text = TempDev.Get_temperature();
                }
            }
            catch (Exception ex) { } // why not do something about the exception?
        }

        private bool connect_devices()
        {
            bool all_good = true;

            string NDF1port = ConfigurationManager.AppSettings.Get("NDF1");
            string NDF2port = ConfigurationManager.AppSettings.Get("NDF2");
            string PMport = ConfigurationManager.AppSettings.Get("PM100A");
            string M9700port = ConfigurationManager.AppSettings.Get("M9700");

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

            // NDF1
            Thread.Sleep(500); // not sure if mixing Threads or Tasks is a good idea. Probs best to stick to one only
            try
            {
                //NDF1 = null;
                NDF1 = new FC102C(NDF1port);
                /*if (NDF1.IsOpen() == 1)
                {
                    myfunctions.add_to_log("bool connect_devices()","NDF1 connected");
                }
                else
                {
                    //all_good = false;
                    MessageBox.Show("NDF1 connection cannot be opened");
                }*/
            }
            catch
            {
                all_good = false;
                MessageBox.Show("NDF1 not connected");
            }
            // NDF2
            if (all_good)
            {
                Thread.Sleep(500);
                try
                {
                    //NDF2 = null;
                    NDF2 = new FC102C(NDF2port);
                    /*if (NDF2.IsOpen() == 1)
                    {
                        myfunctions.add_to_log("bool connect_devices()", "NDF2 connected");
                    }
                    else
                    {
                        //all_good = false;
                        MessageBox.Show("NDF2 connection cannot be opened");
                    }*/
                }
                catch
                {
                    all_good = false;
                    MessageBox.Show("NDF2 not connected");
                }
            }
            if (all_good)
            {
                // PM
                Thread.Sleep(500);
                try
                {
                    PMDev = new PM100A(PMport);
                    PMDev.Get_power();
                    myfunctions.add_to_log("bool connect_devices()", "PM100A connected");

                }
                catch
                {
                    all_good = false;
                    MessageBox.Show("PM100A not connected");
                }
            }
            if (all_good)
            {
                Thread.Sleep(500);
                // TEMP
                try
                {
                    TempDev = new M9700(M9700port);
                    TempDev.Open();
                    TempDev.Close();
                    myfunctions.add_to_log("bool connect_devices()", "M9700 connected");
                    TempDev.Set_mode(2);
                }
                catch
                {
                    all_good = false;
                    MessageBox.Show("Temperature controller not connected");
                }
            }
            if (all_good)
            {
                // Mono & CCD
                Thread.Sleep(500);
                try
                {
                    //bool Bmono = true;
                    MonoSpec = new HR550();
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
                Thread.Sleep(500);
            }
            DeviceInitialized = all_good;
            return all_good;

        }


        private bool Check_unique_rows()
        {
            DataView view = new DataView(dataTable);
            DataTable distinctValues = view.ToTable(true, "temperature", "NDF1pos", "NDF2pos", "ExpTime", "Slit");
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

            //Slit Width
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Slit";
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column); // Since you're using a global variable, I recommend logging everything you do with it to make sure no issues arise
        }

        private void Update_TextBox()
        {
            string textrow;
            listBoxTasks.Items.Clear(); // Really dislike accessing global vars like this - maybe create functions that do these for you instead? E.g.:
            /*
            private void clearListBoxTasks() {
                log.info("Clearing list box tasks!);
                listBoxTasks.Items.Clear();
            }

            private void addListBoxTasks() {...}
                etc.
            */
            for (int i =0; i < dataTable.Rows.Count; i++)
            {
                DataRow lastRow = dataTable.Rows[i];

                string id = i.ToString();
                string temp = lastRow["temperature"].ToString();
                string pos1 = lastRow["NDF1pos"].ToString();
                string pos2 = lastRow["NDF2pos"].ToString();
                string expt = lastRow["ExpTime"].ToString();
                string slit = lastRow["Slit"].ToString();

                textrow = id + "  |  " + temp + "  |  " + pos1 + "  |  " + pos2 + "  |  " + expt + "  |  " + slit + "  ";
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
                double slit = double.Parse(textBoxSlit.Text);

                if (temp < 5.0 || temp > 400) // IDK how much time you have left, but these could be read form a config file instead
                {
                    MessageBox.Show("Temperature is too small or too big");
                    return;
                }
                if (expt < 0.01)
                {
                    MessageBox.Show("Exposure time is too small");
                    return;
                }
                if(slit > 2.2 || slit < 0.0028)
                {
                    MessageBox.Show("Slit is out of range");
                    return;
                }

                row = dataTable.NewRow();

                id = dataTable.Rows.Count;
                row["temperature"] = temp;
                row["NDF1pos"] = pos1;
                row["NDF2pos"] = pos2; 
                row["ExpTime"] = expt;
                row["Slit"] = slit;
                dataTable.Rows.Add(row);

                string text = id + "  |  " + temp + "  |  " + pos1 + "  |  " + pos2 + "  |  " + expt + "  |  " + slit + "  ";
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

        [Obsolete]
        private async void buttonRun_Click(object sender, EventArgs e)
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
                buttonRun.Enabled = false;
                if (RangeMode.Checked)
                {
                    myfunctions.add_to_log("buttonRun_Click", "auto_run() started");

                    Console.WriteLine("Run");
                    var thread = new Thread(() =>
                    {
                        Console.WriteLine("Thread");
                        auto_run();
                    });
                    thread.Priority = ThreadPriority.Highest;
                    thread.Start();

                }
                if (PositionMode.Checked)
                {
                    myfunctions.add_to_log("buttonRun_Click", "auto_run_central() started");
                    //int code = Task.Run(() => auto_run_central()).Result;
                    /*var thread = new Thread(() =>
                    {
                        auto_run_central();
                    });
                    thread.Priority = ThreadPriority.Highest;
                    thread.Start();
                    bool loop_while = true;
                    while (loop_while)
                    {
                        if ((thread.ThreadState == ThreadState.Stopped || thread.ThreadState == ThreadState.Suspended) && !(thread.ThreadState == ThreadState.Unstarted) && thread.ThreadState == ThreadState.Running)
                        {
                            thread.Resume();
                        }
                        if (!thread.IsAlive)
                        {
                            loop_while = false;
                        }
                    }*/
                    await Task.Run(() =>
                    {
                        auto_run_central();
                    });
                }
                buttonRun.Enabled = true;
            }
            else
            {
                MessageBox.Show("Not ready to start the acquisition");
            }

        }


        private async void auto_run()
        {
            Console.WriteLine("autorun"); // Why console when you have a logging function?
            double ct = 0.0; double ce = 0.0; // current temperature ; current exposure time
            double cs = 1.0; // current slit width
            Int32 cp1 = 0; Int32 cp2 = 0; // current possition 1, 2
            int count = 0;
            double mStart, mEnd;
            bool all_good = false;
            double Inc = 0.036; // nm
            bool temp_changed = false;
            int cont = 0;
            bool temp_good = false;


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
                ct = 0; // for safety
                myfunctions.add_to_log("auto_run()", "Starting data acquisition");
                int Loop_no = dataTable.Rows.Count;
                for (int i = 0; i < Loop_no; i++)
                {
                    Console.WriteLine("ReadLine"); // what? xD
                    myfunctions.add_to_log("auto_run()", "Task"+i.ToString());
                    DataRow lastRow = dataTable.Rows[i];

                    double temp = double.Parse(lastRow["temperature"].ToString());
                    Int32 pos1 = Int32.Parse(lastRow["NDF1pos"].ToString());
                    int pos2 = int.Parse(lastRow["NDF2pos"].ToString());
                    double expt = double.Parse(lastRow["ExpTime"].ToString());
                    double slit = double.Parse(lastRow["Slit"].ToString());
                    int wait_few = 0;
                    myfunctions.add_to_log("auto_run()", "Setting devices...");
                    // Statements to avoid unecessary commands to be send
                    
                    if (ct != temp)
                    {
                        ct = temp;
                        // Set temp
                        TempDev.Set_temperature(ct);
                        temp_changed = true;
                    }
                    if (cp1 != pos1)
                    {
                        wait_few = Math.Abs(cp1 - pos1);
                        cp1 = pos1;
                        // Set pos1
                        myfunctions.add_to_log("auto_run()", "Setting NDF1 position...");
                        NDF1.SetPostion(cp1);
                    }
                    if (cp2 != pos2)
                    {
                        if(Math.Abs(cp2-pos2) > wait_few)
                        {
                            wait_few = Math.Abs(cp2 - pos2);
                        }
                        cp2 = pos2;
                        // Set pos2
                        NDF2.SetPostion(cp2);
                    }
                    if (ce != expt)
                    {
                        ce = expt;
                        MonoSpec.SetIntegrationTime(ce);
                        // Set exp time
                    }
                    if(cs != slit)
                    {
                        cs = slit;
                        MonoSpec.SetSlit(cs);
                    }

                    // Wait 2s to make sure wheel is set
                    if (wait_few > 0)
                    {
                        Console.WriteLine("Wait for wheel");
                        await Task.Delay(wait_few);
                    }

                    // Wait for pos to change

                    // Wait for temp to change
                    // Wait additional 20s for stability

                //int code = Task.Run(() => check_temperature(ct)).Result;
                  /*
                    if (temp_changed)
                    {
                        int cont = 1;
                        while (!TempDev.is_temp_good(ct,0.7) && cont > 5)
                        {
                            Thread.Sleep(3000);
                            cont += 1;
                        }
                    }*/
                    //temp_good = false;
                    cont = 0;
                    if (temp_changed == false)
                    {
                        cont = 8;
                    }
                    else
                    {
                        if (TempDev.is_temp_good(ct, 0.7) != true)
                        {
                            Console.WriteLine("Wait 30s");
                            Thread.Sleep(30000); // 30s
                            Console.WriteLine("Waiting finished");
                        }
                    }
                    // Best case scenario - wait 8s
                    Console.WriteLine("Loop");
                    while (cont < 8 )
                    {

                        Console.WriteLine("InLoop");
                        Thread.Sleep(500); // 0.5s
                        //Task.Delay(TimeSpan.FromSeconds(2000));
                        Console.WriteLine("Reading");
                        // it stops here when the temp is changed 20->50
                        //temp_good = TempDev.is_temp_good(ct, 0.7);
                        //Console.WriteLine(temp_good);
                        if (Math.Abs(double.Parse(textCurrTemp.Text.ToString()) - ct) < 0.7)
                        {
                            cont++;
                            Console.WriteLine(cont);
                        }
                        else
                        {
                            Console.WriteLine("Wait");
                            Thread.Sleep(10000); // 10s
                        }
                        //myfunctions.add_to_log("auto_run()", "Wait for temperature... " + cont.ToString());
                    }
                    Console.WriteLine("OutLoop");
                    temp_changed = false;

                    // Take power
                    double power = PMDev.Get_power();
                    //double power = 0;

                    List<double> wavelengthdata;
                    List<Int32> intensitydata;
                    DataTable DataToBeSaved = new DataTable();

                    // Save data
                    myfunctions.add_to_log("auto_run()", "Getting data...");
                    List<double> testList = MonoSpec.Get_Central_Positions(mStart, mEnd, (int)MonoSpec.current_grating);
                    MonoSpec.GetDataRange(testList);
                    myfunctions.add_to_log("auto_run()", "Data taken...");
                    wavelengthdata = MonoSpec.GetWavelengthDataColumn();
                    intensitydata = MonoSpec.GetIntensityDataColumn();

                    myfunctions.add_to_log("auto_run()", "Adding data to DataSet...");
                    myfunctions.DataAddColumn(ref DataToBeSaved, wavelengthdata, "Wavelength");
                    myfunctions.DataAddColumn(ref DataToBeSaved, intensitydata, "Intensity0");

                    wavelengthdata.Clear();
                    intensitydata.Clear();
                    myfunctions.add_to_log("auto_run()", "Taking N-1 times...");

                    // Getting data count-1 times
                    for (int j=1; j < count; j++)
                    {
                        myfunctions.add_to_log("auto_run()", "Getting data...");
                        MonoSpec.GetDataRange(testList);
                        intensitydata = MonoSpec.GetIntensityDataColumn();

                        string intensityName = "Intensity" + j.ToString();
                        myfunctions.DataAddColumn(ref DataToBeSaved, intensitydata, intensityName);
                        wavelengthdata.Clear();
                        intensitydata.Clear();
                    }


                    // Name:  [SAMPLE]_[pos1]_[pos2]_[power]_[exp time]_[temp]K_[slit width]
                    string path;
                    path = default_path();
                    
                    if(path == "")
                    {
                        path = FileName.Text.ToString();
                    }

                    string fullPath = path + "\\" + textSample.Text.ToString() + "_" + Math.Round(power, 4) + "uW_n1_" + cp1 + "_n2_" + cp2 + "_" + ce + "s_" + ct + "K" + "_" + cs + "nm" + ".csv";

                    myfunctions.add_to_log("auto_run()", "Saving " + fullPath);
                    myfunctions.ToCSV(DataToBeSaved, fullPath);
                    DataToBeSaved.Dispose();
                    DataToBeSaved = null;
                    //MonoSpec.GoStream(path, count, 2);
                    // Increase number of finished tasks - thread error do not uncomment
                    //labelFinishTasks.Text = (int.Parse(labelFinishTasks.Text.ToString()) + 1).ToString();


                }
            }
            else
            {
                MessageBox.Show("Count is not set. It's current value is: 0 (must be greater than that)");
            }
            myfunctions.add_to_log("auto_run()", "The tasks are finished");
        }

        private async Task<int> check_temperature(double current_temp)
        {
            bool temp_good = false;
            int cont = 0;

            var t = Task.Run(async delegate
            {
                await Task.Delay(TimeSpan.FromSeconds(2000));
                return TempDev.is_temp_good(current_temp, 0.7);
            });

            try
            {
                // Best case scenario - wait 8s <- hm? This whole section can be replaced with: t.Wait(8000);
                await Task.Run(() =>
                {
                    while (cont < 4)
                    {
                        t.Wait();
                        temp_good = t.Result;
                        if (temp_good)
                        {
                            cont++;
                        }
                        else
                        {
                            Console.WriteLine("Wait");
                        }
                        myfunctions.add_to_log("auto_run()", "Wait for temperature... " + cont.ToString());
                    }
                });
            
                return 0;
            }
            catch (Exception e){
                return -1;
            }
            
        }

        private async void auto_run_central()
        {
            double ct = 0.0; double ce = 0.0; // current temperature ; current exposure time
            double cs = 1.0; // current slit width
            Int32 cp1 = 0; Int32 cp2 = 0; // current possition 1, 2
            int count = 0;
            double mCentral;
            bool all_good = false;
            double Inc = 0.036; // nm
            bool temp_changed = false;

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
                mCentral = double.Parse(textBoxCentral.Text.ToString());
                if (mCentral > 0)
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
                myfunctions.add_to_log("auto_run_central()", "Starting data acquisition");
                int Loop_no = dataTable.Rows.Count;
                for (int i = 0; i < Loop_no; i++)
                {
                    DataRow lastRow = dataTable.Rows[i];

                    double temp = double.Parse(lastRow["temperature"].ToString());
                    Int32 pos1 = Int32.Parse(lastRow["NDF1pos"].ToString());
                    int pos2 = int.Parse(lastRow["NDF2pos"].ToString());
                    double expt = double.Parse(lastRow["ExpTime"].ToString());
                    double slit = double.Parse(lastRow["Slit"].ToString());
                    int wait_few = 0;
                    myfunctions.add_to_log("auto_run_central()", "Setting devices...");
                    // Statements to avoid unecessary commands to be send

                    if (ct != temp)
                    {
                        ct = temp;
                        // Set temp
                        TempDev.Set_temperature(ct);
                        temp_changed = true;
                    }
                    if (cp1 != pos1)
                    {
                        wait_few = Math.Abs(cp1 - pos1);
                        cp1 = pos1;
                        // Set pos1
                        NDF1.SetPostion(cp1);
                    }
                    if (cp2 != pos2)
                    {
                        if (Math.Abs(cp2 - pos2) > wait_few)
                        {
                            wait_few = Math.Abs(cp2 - pos2);
                        }
                        cp2 = pos2;
                        // Set pos2
                        NDF2.SetPostion(cp2);
                    }
                    if (ce != expt)
                    {
                        ce = expt;
                        MonoSpec.SetIntegrationTime(ce);
                        // Set exp time
                    }
                    if (cs != slit)
                    {
                        cs = slit;
                        MonoSpec.SetSlit(cs);
                    }

                    // Wait 2s to make sure wheel is set
                    if (wait_few > 0)
                    {
                        await Task.Delay(wait_few);
                    }

                    // Wait for pos to change

                    // Wait for temp to change
                    // Wait additional 20s for stability

                    int code = Task.Run(() => check_temperature(ct)).Result;

                    //int cont = 1;
                    /*
                    if (temp_changed)
                    {
                        bool temp_good = false;

                        while (cont < 4)
                        {
                            await Task.Delay(2000);
                            temp_good = TempDev.is_temp_good(ct, 0.7);
                            if (temp_good)
                            {
                                cont++;
                            }
                            else
                            {
                                Console.WriteLine("Wait");
                            }
                            myfunctions.add_to_log("auto_run()", "Wait for temperature... " + cont.ToString());
                        }
                    }*/
                    /*
                    while (!TempDev.is_temp_good(ct) && cont<5)
                    {
                        Thread.Sleep(3000);
                        cont += 1;
                    }*/

                    // Take power
                    double power = PMDev.Get_power();
                    //double power = 0;

                    List<double> wavelengthdata;
                    List<Int32> intensitydata;
                    DataTable DataToBeSaved = new DataTable();

                    /*
                                         // Save data
                    myfunctions.add_to_log("auto_run()", "Getting data...");
                    List<double> testList = MonoSpec.Get_Central_Positions(mStart, mEnd, (int)MonoSpec.current_grating);
                    MonoSpec.GetDataRange(testList);
                    myfunctions.add_to_log("auto_run()", "Data taken...");
                    wavelengthdata = MonoSpec.GetWavelengthDataColumn();
                    intensitydata = MonoSpec.GetIntensityDataColumn();

                    myfunctions.add_to_log("auto_run()", "Adding data to DataSet...");
                    myfunctions.DataAddColumn(ref DataToBeSaved, wavelengthdata, "Wavelength");
                    myfunctions.DataAddColumn(ref DataToBeSaved, intensitydata, "Intensity0");

                    wavelengthdata.Clear();
                    intensitydata.Clear();
                    myfunctions.add_to_log("auto_run()", "Taking N-1 times...");

                    // Getting data count-1 times
                    for (int j=1; j < count; j++)
                    {
                        myfunctions.add_to_log("auto_run()", "Getting data...");
                        MonoSpec.GetDataRange(testList);
                        intensitydata = MonoSpec.GetIntensityDataColumn();

                        string intensityName = "Intensity" + j.ToString();
                        myfunctions.DataAddColumn(ref DataToBeSaved, intensitydata, intensityName);
                        wavelengthdata.Clear();
                        intensitydata.Clear();
                    }
                     */


                    // Save data
                    myfunctions.add_to_log("auto_run_central()", "Getting data...");
                    MonoSpec.GetDataPosition(mCentral);
                    myfunctions.add_to_log("auto_run_central()", "Data taken...");
                    wavelengthdata = MonoSpec.GetWavelengthDataColumn();
                    intensitydata = MonoSpec.GetIntensityDataColumn();

                    myfunctions.add_to_log("auto_run_central()", "Adding data to DataSet...");
                    myfunctions.DataAddColumn(ref DataToBeSaved, wavelengthdata, "Wavelength");
                    myfunctions.DataAddColumn(ref DataToBeSaved, intensitydata, "Intensity0");

                    wavelengthdata.Clear();
                    intensitydata.Clear();

                    // Getting data count-1 times
                    for (int j = 1; j < count; j++)
                    {
                        myfunctions.add_to_log("auto_run_central()", "Getting data...");
                        MonoSpec.GetDataPosition(mCentral);
                        intensitydata = MonoSpec.GetIntensityDataColumn();

                        string intensityName = "Intensity" + j.ToString();
                        myfunctions.DataAddColumn(ref DataToBeSaved, intensitydata, intensityName);
                        wavelengthdata.Clear();
                        intensitydata.Clear();
                    }


                    // Name:  [SAMPLE]_[pos1]_[pos2]_[power]_[exp time]_[temp]K_[slit width]
                    string path;
                    path = default_path();
                    // Only for testing
                    //cp1 = 0;
                    //cp2 = 0;
                    //ct = 0;
                    if (path == "")
                    {
                        path = FileName.Text.ToString();
                    }

                    string fullPath = path + "\\" + textSample.Text.ToString() + "_" + Math.Round(power, 4)+ "uW_n1_" + cp1 + "_n2_" + cp2 + "_" + ce + "s_" + ct + "K" + "_" + cs + "nm" + ".csv";

                    myfunctions.add_to_log("auto_run()", "Saving " + fullPath);
                    myfunctions.ToCSV(DataToBeSaved, fullPath);
                    DataToBeSaved.Dispose();
                    DataToBeSaved = null;
                    //MonoSpec.GoStream(path, count, 2);
                    // Increase number of finished tasks - thread error, do not uncomment
                    //labelFinishTasks.Text = (int.Parse(labelFinishTasks.Text.ToString()) + 1).ToString();
                }
            }
            else
            {
                MessageBox.Show("Count is not set. It's current value is: 0 (must be greater than that)");
            }
            myfunctions.add_to_log("auto_run_central()", "The tasks are finished");
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
                path = ".\\Data"; // .\Data
                DateTime aDate = DateTime.Now;
                temp = aDate.ToString("dd MMMM yyyy").Replace(" ", "").Replace(":","");
                path = path + "\\" + temp;

                System.IO.Directory.CreateDirectory(path);
            }

            return path;
        }

        private void PositionMode_CheckedChanged(object sender, EventArgs e)
        {
            textBoxStart.Enabled = false; textBoxEnd.Enabled = false; textBoxCentral.Enabled = true;

        }

        private void RangeMode_CheckedChanged(object sender, EventArgs e)
        {
            textBoxStart.Enabled = true; textBoxEnd.Enabled = true; textBoxCentral.Enabled = false;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listBoxTasks.SelectedIndex.ToString());
            listBoxTasks.Text = listBoxTasks.Text.Remove(listBoxTasks.SelectedIndex);
        }
    }
}
