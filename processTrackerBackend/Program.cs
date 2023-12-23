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
            ListCardDAT listCardDAT = new ListCardDAT();
            CardDAT cardDAT = new CardDAT();

            //dbctrl.DropDatabase();

            //dbctrl.CreateDatabase();

            // Insert User 
            // Click đang ki

            //Console.WriteLine(UserDAT.Insert("cristthien0", "Thien@123"));
            //Console.WriteLine(UserDAT.Insert("cristthien1", "Thien@123"));
            //Console.WriteLine(UserDAT.Insert("cristthien2", "Thien@123"));
            //Console.WriteLine(UserDAT.Insert("cristthien3", "Thien@123"));
            //Console.WriteLine(UserDAT.Insert("cristthien4", "Thien@123"));

            // Insert Fail
            //Console.WriteLine(UserDAT.Insert("cristthien4", "thien@123"));
            // CheckLogin
            // True 
            Console.WriteLine(userDAT.CheckLogin("cristthien0", "Thien@123"));
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
            //Console.WriteLine(BoardDAT.Insert("Big Data", "255, 123, 182", 8)); // false


            // Update table name 
            //Console.WriteLine(BoardDAT.UpdateName(2, "OOP", 3)); // success
            //Console.WriteLine(BoardDAT.UpdateName(7, "Nguyen Thien", 3)); // Fail
            //Console.WriteLine(BoardDAT.UpdateName(2, "Big Data", 4)); // Fail
            // Update table color

            //Console.WriteLine(BoardDAT.UpdateColor(2, "255, 255,255", 3)); // success
            //Console.WriteLine(BoardDAT.UpdateColor(7, "255, 255, 255", 8)); // Fail

            // GetColor 

            //Console.WriteLine(BoardDAT.GetColor(2)); // Success
            //Console.WriteLine(BoardDAT.GetColor(7)); //fail  asign to empty

            // Get Board

            //List<Board> boards = BoardDAT.GetBoards();
            //foreach(var b in boards)
            //{
            //   Console.WriteLine("{0} - {1} - {2} - {3}\n",b.id, b.name, b.owner.id,b.color);

            //}

            // Delete Board
            //Console.WriteLine(BoardDAT.DeleteBoard(2, 3));

            // Viewer DAT 
            //Console.WriteLine(viewerDAT.InsertViewer(2, 3));
            //Console.WriteLine(viewerDAT.InsertViewer(1, 3));
            //Console.WriteLine(viewerDAT.InsertViewer(1, 3));
            //Console.WriteLine(viewerDAT.InsertViewer(5, 3));

            //Console.WriteLine(viewerDAT.InsertViewer(2, 4));
            //Console.WriteLine(viewerDAT.InsertViewer(4, 4));
            //Console.WriteLine(viewerDAT.InsertViewer(1, 4));
            //Console.WriteLine(viewerDAT.InsertViewer(5, 4));


            //Console.WriteLine(viewerDAT.InsertViewer(2, 5));
            //Console.WriteLine(viewerDAT.InsertViewer(5, 5));
            //Console.WriteLine(viewerDAT.InsertViewer(1, 5));
            //Console.WriteLine(viewerDAT.InsertViewer(2, 5));

            // Test Cascade delete

            //Console.WriteLine(BoardDAT.DeleteBoard(1, 2));
            //Console.WriteLine(viewerDAT.DeleteViewers(1));

            //List<Board> boards = viewerDAT.GetViwerBoards(2);
            //foreach (var b in boards)
            //{
            //    Console.WriteLine("{0} - {1} - {2} - {3}\n", b.id, b.name, b.OnwerID, b.color);

            //}



            //Console.WriteLine(listCardDAT.Insert("To Do",2));
            //Console.WriteLine(listCardDAT.Insert("Done",2));
            //Console.WriteLine(listCardDAT.Insert("Done",2));

            //Console.WriteLine(listCardDAT.Insert("To Do", 4));
            //Console.WriteLine(listCardDAT.Insert("Done", 4));
            //Console.WriteLine(listCardDAT.Insert("Done", 4));
            //Console.WriteLine(listCardDAT.Insert("Nothing", 2));


            //Console.WriteLine(listCardDAT.Insert("To Do", 5));
            //Console.WriteLine(listCardDAT.Insert("Done", 5));
            //Console.WriteLine(listCardDAT.Insert("Done", 5));

            //Console.WriteLine(listCardDAT.Insert("To Oo", 11));

            // test update 
            //Console.WriteLine(listCardDAT.UpdateName(1, "To Do"));
            //Console.WriteLine(listCardDAT.UpdateName(2, "Doing"));



            // test delete by id 

            //Console.WriteLine(listCardDAT.DeletebyID(7));    
            //Console.WriteLine(listCardDAT.DeletebyID(8));    
            //Console.WriteLine(listCardDAT.DeletebyID(9));


            //Console.WriteLine(listCardDAT.DeletebyID(10));
            //Console.WriteLine(listCardDAT.DeletebyID(11));
            //Console.WriteLine(listCardDAT.DeletebyID(12));

            // Delete all list card whose board id is same
            //Console.WriteLine(listCardDAT.DeleteAll(5));
            // Check if it does not exist 
            // Console.WriteLine(listCardDAT.DeleteAll(5));

            // Get ListCards 
            //List<ListCard> listCards = listCardDAT.Get(2);
            //foreach(ListCard lc in listCards)
            //{
            //    Console.WriteLine("{0} - {1} - {2} ", lc.name, lc.location, lc.boardID);
            //}

            // Move Left 
            //Console.WriteLine(listCardDAT.MoveLeft(2, 13));
            //Console.WriteLine(listCardDAT.MoveLeft(2, 1)); // Fail

            // Move Right  
            // Console.WriteLine(ListCardDAT.MoveRight(2, 3));
            //Console.WriteLine(ListCardDAT.MoveRight(2, 13));

            // Card 
            // Insert
            //Console.WriteLine(cardDAT.Insert("lc 1 card 1 board 2", "day laf hoat dong hay", 1));
            //Console.WriteLine(cardDAT.Insert("lc 1 card 2 board 2", "day laf hoat dong hay", 1));
            //Console.WriteLine(cardDAT.Insert("lc 2 card 1 board 2", "day laf hoat dong hay", 2));
            //Console.WriteLine(cardDAT.Insert("lc 2 card 2 board 2", "day laf hoat dong hay", 2));
            //Console.WriteLine(cardDAT.Insert("lc 2 card 3 board 2", "day laf hoat dong hay", 2));
            //Console.WriteLine(cardDAT.Insert("lc 4 card 1 board 4", "day laf hoat dong hay", 4));
            //Console.WriteLine(cardDAT.Insert("lc 4 card 2 board 4", "day laf hoat dong hay", 4));
            //Console.WriteLine(cardDAT.Insert("lc 5 card 1 board 4", "day laf hoat dong hay", 5));
            //Console.WriteLine(cardDAT.Insert("lc 6 card 1 board 4", "day laf hoat dong hay", 6));
            //Console.WriteLine(cardDAT.Insert("lc 5 card 2 board 4", "day laf hoat dong hay", 5));

            // Update title

            //Console.WriteLine(CardDAT.UpdateTittle(1, "lc 1 card 1 board 2 after change"));
            //Console.WriteLine(CardDAT.UpdateTittle(11, "lc 1 card 11 board 2 after change"));


            // update des
            //Console.WriteLine(CardDAT.UpdateDescription(1, "After change"));



























        }
    }
}
