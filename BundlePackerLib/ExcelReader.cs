using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace BundlePacker
{
    public class ExcelReader
    {
        private readonly Application _exel;

        private Workbook _workbook;

        private Worksheet _sheet;

        public ExcelReader()
        {
            _exel = new Application();
        }

        public void Open(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException($"{nameof(filePath)} is null or empty");

            if (!File.Exists(filePath))
                throw new Exception($"File by path {filePath} is not found");

            _workbook = _exel.Workbooks.Open(filePath);
        }

        public List<string> GetMarkedPackages(string bundleName)
        {
            if (string.IsNullOrEmpty(bundleName))
                throw new ArgumentNullException($"{nameof(bundleName)} is null or empty");

            _sheet = (Excel.Worksheet) _workbook.ActiveSheet;
            var packages = new List<string>();

            var bundleRowIndex = GetBundleIndex(bundleName);

            if (bundleRowIndex != -1)
            {
                var columnCount = _sheet.Columns.Count;

                for (var i = 2; i < columnCount; i++)
                {
                    var cellValue = (string)_sheet.Cells[bundleRowIndex, i].Value;

                    if (cellValue == "+")
                    {
                        var columnHeader = (string)_sheet.Cells[1, i].Value;
                        var columnHeaderWithouGZ = columnHeader.Replace(".gz", string.Empty);
                        packages.Add(columnHeaderWithouGZ);
                    }
                }
            }

            else
            {
                throw new Exception($"There is no bundle like {bundleName}");
            }

            return packages;
        }


        private int GetBundleIndex(string bundleName)
        {
            var rowCount = _sheet.Rows.Count;

            for(var i = 1; i < rowCount; i++)
            {
                var cellValue = (string)_sheet.Cells[i, 1].Value;

                if (cellValue == bundleName)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}