using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAT;
using DTO;
using Utility;



namespace processTrackerBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            DBController dbctrl = new DBController();
            UserDAT userDAT = new UserDAT();
            ViewerDAT viewerDAT = new ViewerDAT();
            dbctrl.DropDatabase();
            dbctrl.CreateDatabase();

            // Insert User 
            //Console.WriteLine(UserDAT.Insert("cristthien0", "Thien@123"));
            //Console.WriteLine(UserDAT.Insert("cristthien1", "Thien@123"));
            //Console.WriteLine(UserDAT.Insert("cristthien2", "Thien@123"));
            //Console.WriteLine(UserDAT.Insert("cristthien3", "Thien@123"));
            //Console.WriteLine(UserDAT.Insert("cristthien4", "Thien@123"));
            // Insert Fail
            //Console.WriteLine(UserDAT.Insert("cristthien4", "thien@123"));
            // CheckLogin
            // True 
            //Console.WriteLine(userDAT.CheckLogin("cristthien2", "Thien@123"));
            //Console.WriteLine(userDAT.CheckLogin("cristthieN2", "Thien@123"));
            //Console.WriteLine(userDAT.CheckLogin(" cristthien2 ", "Thien@123"));
            // False 
            //Console.WriteLine(userDAT.CheckLogin("cristthien2", "Thien"));
            //Console.WriteLine(userDAT.CheckLogin("cristthien", "Thien@123"));
            //Console.WriteLine(userDAT.CheckLogin("cristthien2", ""));
            //Console.WriteLine(userDAT.CheckLogin("", "Thien@123"));
            //Console.WriteLine(userDAT.CheckLogin("1' or '1' = '1", "1' or '1' = '1"));
            //Console.WriteLine(userDAT.CheckLogin("1' or '1' = '1", ""));
            //Console.WriteLine(userDAT.CheckLogin("", "1' or '1' = '1"));



            // Insert Board
            //Console.WriteLine(BoardDAT.Insert("CNPM", "255, 0, 244", 2));
            //Console.WriteLine(BoardDAT.Insert("XSTK", "255, 0, 123", 3));
            //Console.WriteLine(BoardDAT.Insert("TRR", "255, 56, 0", 2));
            //Console.WriteLine(BoardDAT.Insert("OS", "255, 17, 45", 1));
            //Console.WriteLine(BoardDAT.Insert("HTMT", "255, 79, 43", 3));
            //Console.WriteLine(BoardDAT.Insert("PTTK", "255, 123, 182", 3));
            // Update table name 
            //Console.WriteLine(BoardDAT.UpdateName(2, "OOP")); // success
            //Console.WriteLine(BoardDAT.UpdateName(7, "Nguyen Thien")); // Fail
            // Update table color
            //Console.WriteLine(BoardDAT.UpdateColor(2, "255, 255,255")); // success
            //Console.WriteLine(BoardDAT.UpdateColor(7, "255, 255, 255")); // Fail
            // GetColor 
            //Console.WriteLine(BoardDAT.GetColor(2)); // Success
            //Console.WriteLine(BoardDAT.GetColor(7)); //fail  asign to empty
            // Get Board
            //List<Board> boards = BoardDAT.GetBoards();
            //foreach(var b in boards)
            //{
            //    Console.WriteLine("{0} - {1} - {2} - {3}\n",b.id, b.name, b.owner.id,b.color);

            //}

            //Delete Board
            //Console.WriteLine(BoardDAT.DeleteBoard(2,3)); \
            List <Card>                     




        }
    }
}
