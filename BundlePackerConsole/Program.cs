using BundlePacker;

const string filePath = "D:\\Documents\\Наборы пакетов в бандлах3.xlsx";
const string targetCopyDirectory = "D:\\BpmSoft\\Bundles\\Service\\CustomerCenter";
const string allPackagesPath = "D:\\BpmSoft\\AllProductPackages_7.18.5\\AllProductPackages_7.18.5_Extracted";

var exelReader = new ExcelReader();
exelReader.Open(filePath);

var packages = exelReader.GetMarkedPackages("7.18.5.1500_CustomerCenter_Softkey_MSSQL_ENU");

Console.WriteLine("Found packages in excel:\n");
Console.WriteLine(string.Join("\n", packages));

Console.WriteLine(new string('-', 20));

foreach (var package in packages)
{
    var packagePath = allPackagesPath + "\\" + package;
    var targetPackageCopyDirectory = targetCopyDirectory + "\\" + package;

    if (!Directory.Exists(packagePath))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{packagePath} not found");
        Console.ResetColor();

        continue;
    }

    Pack.Copy(packagePath, targetPackageCopyDirectory);
    Console.WriteLine($"{package} copied");
}



Console.ReadLine();