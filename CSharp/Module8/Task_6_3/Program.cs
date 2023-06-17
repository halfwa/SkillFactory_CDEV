namespace Task_6_3
{

    internal class Program
    {
        static void Main(string[] args)
        {

            string path = "ref";
            long result = 0;
            int fileCount = 0;
            long byteCount = 0;

            DirectoryInfo d = new DirectoryInfo(path);

            if (d.Exists)
            {
                result = GetDirectorySize(d);
                Console.WriteLine($"Исходный размер папки: {result}");

                DeleteDirectory(d, ref fileCount, ref byteCount);
                Console.WriteLine($"Удалено {fileCount} файла, освобождено {byteCount} байт");

                result = GetDirectorySize(d);
                Console.WriteLine($"Текущий размер папки: {result}");
            }
            else
            {
                Console.WriteLine("Дериктории не существует!");
            }
        }
        public static long GetDirectorySize(DirectoryInfo d)
        {
            long size = 0;

            try
            {
                FileInfo[] fs = d.GetFiles();

                foreach (var item in fs)
                {
                    size += item.Length;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            try
            {
                DirectoryInfo[] ds = d.GetDirectories();
                foreach (var item in ds)
                {
                    size += GetDirectorySize(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return size;
        }

        public static void DeleteDirectory(DirectoryInfo d,
        ref int fileCount, ref long byteCount, bool isDeletedRoot = false)
        {
            try
            {
                FileInfo[] fs = d.GetFiles();

                foreach (var item in fs)
                {
                    fileCount++;
                    byteCount += item.Length;
                    item.Delete();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            try
            {
                DirectoryInfo[] ds = d.GetDirectories();
                foreach (var item in ds)
                {
                    DeleteDirectory(item, ref fileCount, ref byteCount, true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            d.Delete();
        }
    }
}
