using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAT
{
    public class BoardDAT
    {

        public static int Insert(string name, string color, int userID)
        {
            using (var dbcontext = new Context())
            {
                var user = dbcontext.users.Where(u => u.id == userID).FirstOrDefault();
                if (user != null)
                {
                    try
                    {

                        var newBoard = new Board()
                        {
                            name = name,
                            color = color,
                            OnwerID = userID,
                        };

                        dbcontext.boards.Add(newBoard);
                        dbcontext.SaveChanges();

                        return newBoard.id;

                    }
                    catch
                    {
                        return -1;
                    }

                }
                else
                {
                    return -1;
                }

            }
        }

        public static bool UpdateName(int idBoard, string name, int ownerID)
        {
            using (var dbcontext = new Context())
            {
                try
                {
                    var board = dbcontext.boards.Where(b => (b.id == idBoard) && (b.OnwerID == ownerID)).FirstOrDefault();
                    if (board != null)
                    {
                        board.name = name;
                        dbcontext.SaveChanges();
                    }
                    else { return false; }

                    return true;

                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool UpdateColor(int idBoard, string color, int ownerID)
        {
            using (var dbcontext = new Context())
            {
                try
                {
                    var board = dbcontext.boards.Where(b => b.id == idBoard && b.OnwerID == ownerID).FirstOrDefault();
                    if (board != null)
                    {
                        board.color = color;
                        dbcontext.SaveChanges();
                    }
                    else { return false; }

                    return true;

                }
                catch
                {
                    return false;
                }
            }
        }
        public static string GetColor(int idBoard)
        {
            using (var dbcontext = new Context())
            {
                try
                {
                    var board = dbcontext.boards.Where(b => b.id == idBoard).FirstOrDefault();
                    if (board != null)
                    {
                        return board.color;
                    }
                    else { return string.Empty; }

                }
                catch
                {
                    return string.Empty;
                }
            }

        }
        public static bool DeleteBoard(int idBoard, int userID)
        {

            using (var dbcontext = new Context())
            {
                var deletedBoard = dbcontext.boards.Where(b => b.id == idBoard && b.OnwerID == userID ).FirstOrDefault();

                if (deletedBoard == null) { return false; }
                try
                {
                    ViewerDAT viewerDAT = new ViewerDAT();
                    viewerDAT.DeleteViewers(idBoard);
                    dbcontext.Remove(deletedBoard);
                    dbcontext.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }

        }



    }
}
