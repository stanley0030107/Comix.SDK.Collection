namespace Comix.Core.Helpers;

public class ExcelHelper
{
    public static DataTable ReadCSVData(string fileName, out string errMsg)
    {
        DataTable result = ReadDataFromCSVFile(fileName, out errMsg);
        errMsg = "";
        return result;
    }
    private static DataTable ReadDataFromCSVFile(string fileName, out string errMsg)
    {
        int num = 0;
        errMsg = string.Empty;
        string value = "\t";
        try
        {
            string[] array = File.ReadAllLines(fileName, Encoding.GetEncoding("utf-8"));
            if (array == null || array.Length == 0)
            {
                errMsg = "读取的文件中没有数据!";
                return null;
            }

            DataTable dataTable = new DataTable();
            string[] array2 = array[0].Split('\t');
            for (int i = 0; i < array2.Length; i++)
            {
                dataTable.Columns.Add(new DataColumn(array2[i], typeof(string)));
            }

            for (int j = 1; j < array.Length; j++)
            {
                if (!string.IsNullOrEmpty(array[j].Trim()))
                {
                    DataRow dataRow = dataTable.NewRow();
                    string[] array3 = array[j].Split(Convert.ToChar(value));
                    for (int k = 0; k < array3.Length; k++)
                    {
                        dataRow[k] = array3[k];
                    }

                    dataTable.Rows.Add(dataRow);
                }
            }

            dataTable.AcceptChanges();
            return dataTable;
        }
        catch (Exception ex)
        {
            errMsg = $"{num}读取失败！ {ex.Message}";
            return null;
        }
    }

}