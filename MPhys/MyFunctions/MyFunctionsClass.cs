using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MPhys.MyFunctions
{
    class MyFunctionsClass
    {
        public void DataAddColumn(ref DataTable dtData, List<double> lis, string columnname)
        {
            DataColumn column;

            // Add column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = columnname;
            column.ReadOnly = false;
            column.Unique = false;
            dtData.Columns.Add(column);

            DataRow row;
            add_to_log("DataAddColumn", lis.Count.ToString());
            add_to_log("DataAddColumn", dtData.Rows.Count.ToString());
            for (int i = 0; i < lis.Count; i++)
            {
                add_to_log("DataAddColumn", i.ToString());
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
            DataColumn column;

            // Add column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = columnname;
            column.ReadOnly = false;
            column.Unique = false;
            dtData.Columns.Add(column);

            DataRow row;
            add_to_log("DataAddColumn", lis.Count.ToString());
            add_to_log("DataAddColumn", dtData.Rows.Count.ToString());
            for (int i = 0; i < lis.Count; i++)
            {
                add_to_log("DataAddColumn", i.ToString());
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

        public void add_to_log(string function_name, string text_message)
        {
            string path = "./LogFolder\\log.txt";
            System.IO.Directory.CreateDirectory("./LogFolder");
            if (!System.IO.File.Exists(path))
            {
                var a = System.IO.File.Create(path);
                a.Close();
            }
            string temp = DateTime.Now.ToString("HH:mm");

            string mes = temp + " : " + function_name + " :  " + text_message;
            File.AppendAllText(path, mes + Environment.NewLine);
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
    }
}
