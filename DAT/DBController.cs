using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT
{
    public class DBController
    {
        public void CreateDatabase()
        {
            using (var dbcontext = new Context())
            {

                var kq = dbcontext.Database.EnsureCreated();
                if (kq)
                {
                    Console.WriteLine($"Tao Db thanh cong");
                }
                else
                {
                    Console.WriteLine($"DB da co san");
                }

            }// tao ra context
        }
        public void DropDatabase()
        {
            var dbcontext = new Context();
            var kq = dbcontext.Database.EnsureDeleted();
            if (kq)
            {
                Console.WriteLine("Xoa Db thanh cong");
            }
            else
            {
                Console.WriteLine("DB nay khong co ");
            }
        }
    }
}
