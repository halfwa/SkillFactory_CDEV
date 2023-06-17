namespace Task_6_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string path = "ref";

            DirectoryInfo d = new DirectoryInfo(path);

            if (d.Exists)
            {
                DeleteUnusedDir(d);
            }
            else
            {
                Console.WriteLine("Дериктории не существует!");
            }

        }
        public static void DeleteUnusedDir(DirectoryInfo d, bool isDeleted = false)
        {
            try
            {
                FileInfo[] fs = d.GetFiles();

                foreach (var item in fs)
                {
                    if (DateTime.Now - item.LastAccessTime > TimeSpan.FromMinutes(30))
                    {
                        item.Delete();
                    }
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
                    DeleteUnusedDir(item, true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            if ((DateTime.Now - d.LastAccessTime > TimeSpan.FromMinutes(30)) && isDeleted)
            {
                d.Delete();
            }
        }


    }
}