using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Reflection;

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

        public void add_to_log(string function_name, string text_message)
        {
            string path = ".\\log.txt";
            System.IO.Directory.CreateDirectory(path);
            DateTime aDate = DateTime.Now;
            string temp = aDate.ToString("HH:mm");

            string mes = temp + " : " + function_name + " :  " + text_message;
            File.AppendAllText(path, function_name + " " + text_message + Environment.NewLine);
        }
    }
}
