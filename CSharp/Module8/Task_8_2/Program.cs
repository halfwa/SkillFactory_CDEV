namespace Task_8_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = "ref";
            long result = 0;

            DirectoryInfo d = new DirectoryInfo(path);

            if (d.Exists)
            {
                result = GetDirectorySize(d);
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
    }
}

