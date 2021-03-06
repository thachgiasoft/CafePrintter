//<auto-generated />

#region "Author"
/****************************************************************************************
 * Solution     : CUSC His Framework
 * Project code : APP1105
 * Author       : Dương Nguyễn Phú Cường
 * Company      : Cusc Software
 * Version      : 1.0.0.1
 * Created date : 29/03/2013
 ***************************************************************************************/
#endregion

using System;
using System.Data;

namespace KFLibrary.Data
{
    public class DataUtils
    {
        // Convert data grid to array
        public static object[,] ConvertDataTableToArray(DataTable dt, bool isStoreColumnHeader = false)
        {
            object[,] arrData;
            int index = 0;
            if (isStoreColumnHeader)
            {
                arrData = new object[dt.Rows.Count + 1, dt.Columns.Count]; // Thêm 1 dòng lưu column header
                index = 0;
                //Save ColumnName in 1st row of the array
                foreach (DataColumn dc in dt.Columns)
                {
                    arrData[0, index] = Convert.ToString(dc.Caption);
                    index++;
                }
                //Reset Index
                index = 0;
                //Now save DataTable values in array,
                //here we start from second row as ColumnNames are stored in first row
                for (int row = 1; row < dt.Rows.Count + 1; row++)
                {
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        arrData[row, col] =
                            Convert.ToString(dt.Rows[row - 1][col]);
                    }
                }
                //Return 2D-String Array
                return arrData;
            }

            // Không lưu column header
            arrData = new object[dt.Rows.Count, dt.Columns.Count];
            index = 0;
            //Now save DataTable values in array,
            //here we start from second row as ColumnNames are stored in first row
            for (int row = 0; row < dt.Rows.Count; row++)
            {
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    arrData[row, col] =
                        Convert.ToString(dt.Rows[row][col]);
                }
            }
            //Return 2D-String Array
            return arrData;
        }
    }
}
