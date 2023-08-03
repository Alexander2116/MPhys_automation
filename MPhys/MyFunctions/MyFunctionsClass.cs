﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NLog;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Runtime;

namespace MPhys.MyFunctions
{
    class MyFunctionsClass
    {
        public void DataAddColumn(ref DataTable dtData, List<double> lis, string columnname)
        {
            DataColumn column;

            // Add column
            if (!dtData.Columns.Contains(columnname))
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = columnname;
                column.ReadOnly = false;
                column.Unique = false;
                dtData.Columns.Add(column);
            }

            DataRow row;
            add_to_log("DataAddColumn", lis.Count.ToString());
            add_to_log("DataAddColumn", dtData.Rows.Count.ToString());
            for (int i = 0; i < lis.Count; i++)
            {
                if (i >= dtData.Rows.Count)
                {
                    row = dtData.NewRow();
                    row[columnname] = lis[i];
                    dtData.Rows.Add(row);
                }
                else
                {
                    dtData.Rows[i][columnname] = lis[i];
                }
            }

        }
        public void DataAddColumn(ref DataTable dtData, List<int> lis, string columnname)
        {

            if (!dtData.Columns.Contains(columnname))
            {
                DataColumn column;
                // Add column
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = columnname;
                column.ReadOnly = false;
                column.Unique = false;
                dtData.Columns.Add(column);
            }

            DataRow row;
            add_to_log("DataAddColumn", lis.Count.ToString());
            add_to_log("DataAddColumn", dtData.Rows.Count.ToString());
            for (int i = 0; i < lis.Count; i++)
            {
                if (i >= dtData.Rows.Count)
                {
                    row = dtData.NewRow();
                    row[columnname] = lis[i];
                    dtData.Rows.Add(row);
                }
                else
                {
                    dtData.Rows[i][columnname] = lis[i];
                }
            }

        }

        public static DataTable ListToDataTable<T>(List<T> list, string _tableName)
        {
            DataTable dt = new DataTable(_tableName);

            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                dt.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }
            foreach (T t in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo info in typeof(T).GetProperties())
                {
                    row[info.Name] = info.GetValue(t, null) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }


        public void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public void add_to_log(string function_name, string text_message) // why not use an existing logging library. It will work much better and usually async
        {
            string path = "./LogFolder\\log.txt";
            System.IO.Directory.CreateDirectory("./LogFolder");
            if (!System.IO.File.Exists(path))
            {
                var a = System.IO.File.Create(path);
                a.Close();
            }

            //string mes = function_name + " :  " + text_message;
            Logger.Info(" {function_name} {message}", function_name, text_message);
            /*
            string path = "./LogFolder\\log.txt";
            System.IO.Directory.CreateDirectory("./LogFolder");
            if (!System.IO.File.Exists(path))
            {
                var a = System.IO.File.Create(path);
                a.Close();
            }
            string temp = DateTime.Now.ToString("HH:mm");

            string mes = temp + " : " + function_name + " :  " + text_message;
            File.AppendAllText(path, mes + Environment.NewLine);*/
        }



        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="fileName">The name of the file + extension.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public void WriteToBinaryFile<T>(string fileName, T objectToWrite, bool append = false) where T : new()
        {
            System.IO.Directory.CreateDirectory("./SaveObjects");
            var f = System.IO.File.Create("./SaveObjects\\" + fileName);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(f, objectToWrite);
            f.Close();
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="fileName">The name of the file + extension.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public T ReadFromBinaryFile<T>(string fileName) where T : new()
        {
            var f = File.Open("./SaveObjects\\" + fileName, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            var obj = (T)b.Deserialize(f);
            f.Close();
            return obj;
        }


        public void Update_ini(double a, double b, double c, string section_name)
        {
            var MyIni = new IniFile("MappingParameters.ini");
            MyIni.Write("a", a.ToString(), section_name);
            MyIni.Write("b", b.ToString(), section_name);
            MyIni.Write("c", c.ToString(), section_name);
        }

        public double[] Read_ini(string section_name)
        {
            double[] list = new double[3];
            var MyIni = new IniFile("MappingParameters.ini");
            list[0] = double.Parse(MyIni.Read("a", section_name));
            list[1] = double.Parse(MyIni.Read("b", section_name));
            list[2] = double.Parse(MyIni.Read("c", section_name));

            return list;
        }
        public double Read_ini(string key, string section_name)
        {
            var MyIni = new IniFile("MappingParameters.ini");

            return double.Parse(MyIni.Read(key, section_name));
        }


    }


    class IniFile   // revision 11
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
    }

}
