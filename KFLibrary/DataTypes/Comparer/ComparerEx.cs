//<auto-generated />

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KFLibrary.DataTypes.Comparer
{
    public static class ComparerEx
    {
        /// <summary>
        /// Hàm kiểm tra khoảng thời gian từ ngày - đến ngày với ngày bắt đầu và kết thúc trong sổ kế toán
        /// </summary>
        /// <param name="ngayBatDau">Ngày bắt đầu sổ kế toán</param>
        /// <param name="ngayKetThuc">Ngày kêt thúc sổ kế toán</param>
        /// <param name="startDate">Từ ngày</param>
        /// <param name="endDate">Đến ngày</param>
        /// <returns></returns>
        /// Author: DUONG NGUYEN PHU CUONG
        public static bool IsInPeriod(DateTime ngayBatDau, DateTime? ngayKetThuc, DateTime? startDate, DateTime? endDate)
        {
            // Giả sử ngày bắt đầu luôn <= ngày kết thúc (sổ kế toán)
            if (ngayBatDau > ngayKetThuc)
            {
                return false;
            }

            if (ngayBatDau < startDate)
            {
                // After
                if (ngayKetThuc < startDate)
                {
                    return false;
                }

                // Start Touching
                if (ngayKetThuc == startDate)
                {
                    return true;
                }

                // Start Inside
                if (ngayKetThuc > startDate)
                {
                    return true;
                }
            }

            if (ngayBatDau == startDate)
            {
                // Inside Start Touching
                if (ngayKetThuc > endDate)
                {
                    return true;
                }

                // Enclosing Start Touching
                if (ngayKetThuc < endDate)
                {
                    return true;
                }
            }

            if (ngayBatDau > startDate)
            {
                // Enclosing
                if (ngayKetThuc < endDate)
                {
                    return true;
                }

                // Enclosing End Touching
                if (ngayKetThuc == endDate)
                {
                    return true;
                }
            }

            // Exact Match
            if (ngayBatDau == startDate && ngayKetThuc == endDate)
            {
                return true;
            }

            // Inside
            if (ngayBatDau < startDate && ngayKetThuc > endDate)
            {
                return true;
            }

            // Inside End Touching
            if (ngayBatDau < startDate && ngayKetThuc == endDate)
            {
                return true;
            }

            // End Inside
            if (ngayBatDau < endDate && ngayKetThuc > endDate)
            {
                return true;
            }

            // End Touching
            if (ngayBatDau == endDate && ngayKetThuc > endDate)
            {
                return true;
            }

            // Before
            if (ngayBatDau > endDate)
            {
                return false;
            }

            return false;
        }
    }
}
