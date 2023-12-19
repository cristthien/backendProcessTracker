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

        public static List<Board> GetBoards()
        {

            using (var dbcontext = new Context()) {
                return dbcontext.boards.Include(b => b.owner).ToList();
            }
        }


        public static bool Insert(string name, string color, int userID)
        {
            using (var dbcontext = new Context())
            {
                    var user = dbcontext.users.Where(u => u.id == userID).FirstOrDefault();
                if (user != null) {
                    try
                    {

                        var newBoard = new Board()
                        {
                            name = name,
                            color = color,
                            owner = user,
                        };

                        dbcontext.boards.Add(newBoard);
                        dbcontext.SaveChanges();

                        return true;

                    }
                    catch
                    {
                        return false;
                    }

                } else {
                    return false;
                } 

            }
        }

        public static bool UpdateName(int idBoard, string name)
        {
            using (var dbcontext = new Context())
            {
                try
                {
                    var board = dbcontext.boards.Where(b => b.id == idBoard).FirstOrDefault();
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

        public static bool UpdateColor(int idBoard, string color)
        {
            using (var dbcontext = new Context())
            {
                try
                {
                    var board = dbcontext.boards.Where(b => b.id == idBoard).FirstOrDefault();
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
                var validateUser = dbcontext.users.Where(u => u.id == userID);
                if (validateUser == null) { return false; }
                try { 

                    var removeBoard = dbcontext.boards.Where(b => b.id == idBoard).FirstOrDefault();
                    var e = dbcontext.Entry(removeBoard);
                    e.Reference(p => p.owner).Load();
                    if (removeBoard.owner.id == userID) {
                        dbcontext.Remove(removeBoard);
                        dbcontext.SaveChanges();

                        return true;
                    } 
                     else
                    {
                        return false;
                    }
                
                
                } catch {
                    return false;
                }

            }

        }
        

    
    }
}
