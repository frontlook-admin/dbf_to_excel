using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbf
{
    using System;
    using System.Diagnostics;
    using Microsoft.Office.Interop.Excel;

    class program1
    {
        static void Main1(string[] args)
        {
            var excel = new Application();
            excel.DisplayAlerts = false;

            var workbooks = excel.Workbooks;
            var stopwatch = new Stopwatch();
            var blockSize = 10;

            Console.WriteLine("Write by array.");
            MeasureOverIncreasingSize(workbooks, blockSize, stopwatch, WriteNumberFormatArray);

            Console.WriteLine("Write by array.");
            MeasureOverIncreasingSize(workbooks, blockSize, stopwatch, WriteArray);

            Console.WriteLine("Write by column.");
            MeasureOverIncreasingSize(workbooks, blockSize, stopwatch, WriteNumberFormatByColumn);

            Console.WriteLine("Write cell by cell.");
            MeasureOverIncreasingSize(workbooks, blockSize, stopwatch, WriteNumberFormatCellByCell);

            Console.ReadLine();
            excel.Quit();
        }

        private static void MeasureOverIncreasingSize(Workbooks workbooks, int blockSize, Stopwatch stopwatch, Action<int, int, Worksheet> method)
        {
            for (int size = 1; size <= 10; size++)
            {
                var workbook = workbooks.Add(Type.Missing);
                var worksheets = workbook.Sheets;
                var worksheet = (Worksheet)worksheets[1];

                var rows = blockSize * size;
                var columns = blockSize;

                stopwatch.Reset();
                stopwatch.Start();

                method(rows, columns, worksheet);

                stopwatch.Stop();

                WriteEvaluation(stopwatch, rows, columns);
                workbook.Close(false, Type.Missing, Type.Missing);
            }
        }

        private static void WriteArray(int rows, int columns, Worksheet worksheet)
        {
            var data = new object[rows, columns];
            for (var row = 1; row <= rows; row++)
            {
                for (var column = 1; column <= columns; column++)
                {
                    data[row - 1, column - 1] = "Test";
                }
            }

            var startCell = (Range)worksheet.Cells[1, 1];
            var endCell = (Range)worksheet.Cells[rows, columns];
            var writeRange = worksheet.Range[startCell, endCell];

            writeRange.Value2 = data;
        }

        private static void WriteCellByCell(int rows, int columns, Worksheet worksheet)
        {
            for (var row = 1; row <= rows; row++)
            {
                for (var column = 1; column <= columns; column++)
                {
                    var cell = (Range)worksheet.Cells[row, column];
                    cell.Value2 = "Test";
                }
            }
        }

        private static void WriteNumberFormatArray(int rows, int columns, Worksheet worksheet)
        {
            var data = new object[rows, columns];
            for (var row = 1; row <= rows; row++)
            {
                for (var column = 1; column <= columns; column++)
                {
                    data[row - 1, column - 1] = "0.000%";
                }
            }

            var startCell = (Range)worksheet.Cells[1, 1];
            var endCell = (Range)worksheet.Cells[rows, columns];
            var writeRange = worksheet.Range[startCell, endCell];

            writeRange.NumberFormat = data;
        }

        private static void WriteNumberFormatByColumn(int rows, int columns, Worksheet worksheet)
        {
            for (var column = 1; column <= columns; column++)
            {
                var startCell = (Range)worksheet.Cells[1, column];
                var endCell = (Range)worksheet.Cells[rows, column];
                var writeRange = worksheet.Range[startCell, endCell];

                writeRange.NumberFormat = "0.000%";
            }
        }

        private static void WriteNumberFormatCellByCell(int rows, int columns, Worksheet worksheet)
        {
            for (var row = 1; row <= rows; row++)
            {
                for (var column = 1; column <= columns; column++)
                {
                    var cell = (Range)worksheet.Cells[row, column];
                    cell.NumberFormat = "0.000%";
                }
            }
        }

        private static void WriteEvaluation(Stopwatch stopwatch, int rows, int columns)
        {
            var cells = rows * columns;
            var time = stopwatch.ElapsedMilliseconds;
            var timePerCell = Math.Round((double)time / (double)cells, 5);

            Console.WriteLine(string.Format("Writing {0} values took {1} ms or {2} ms/cell.", cells, time, timePerCell));
        }
    }
}
