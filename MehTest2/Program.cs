using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace MehTest2
{
    public class DataString
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class DataStringContext : DbContext
    {
        public DataStringContext()
            : base("DbConnection")
        { }

        public DbSet<DataString> DataStrings { get; set; }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
