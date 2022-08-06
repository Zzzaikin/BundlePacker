namespace BundlePacker
{
    public static class Pack
    {
        public static void Copy(string packStorage, string bundleStorage)
        {
            Directory.CreateDirectory(bundleStorage);

            var packs = Directory.GetFiles(packStorage);

            foreach (string pack in packs)
            {
                var packStorageFileName = Path.GetFileName(pack);

                var bundleStorageFileName = bundleStorage + "\\" + packStorageFileName;
                File.Copy(packStorageFileName, bundleStorageFileName);
            }

            var directories = Directory.GetDirectories(packStorage);

            foreach (string directory in directories)
            {
                var packStorageDirectoryName = Path.GetFileName(directory);
                Copy(directory, bundleStorage + "\\" + packStorageDirectoryName);
            }

            Console.WriteLine($"{packStorage} copied");
        }
    }
}
