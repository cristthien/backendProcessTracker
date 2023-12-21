using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAT
{
    public class ViewerDAT
    {
        // Insert
        // when the user add id board, add them to follow this bard 
        public bool InsertViewer(int userID, int boardID)
        {
            using (var dbcontext = new Context())
            {
                try
                {
                    var user = dbcontext.users.Where(u => u.id == userID).FirstOrDefault();
                    var board = dbcontext.boards.Where(b => b.id == boardID).FirstOrDefault();
                    var existedViewer = dbcontext.viewers.Where(v => v.BoardId == boardID && v.UserId == userID).FirstOrDefault();
                    if (user != null && board != null && existedViewer == null)
                    {
                        var viewer = new Viewer() { UserId = userID, BoardId = boardID };
                        dbcontext.viewers.Add(viewer);
                        dbcontext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch {

                    return false;
                
                }

            }
        }
        //// Get
        public  List<Board> GetViwerBoards(int userID)
        {
            using (var dbcontext = new Context())
            {
                try
                {

                    var viewer = (from v in dbcontext.viewers
                                  where v.UserId == userID
                                  select v);
                    var boards = from v in viewer
                                 join b in dbcontext.boards on v.BoardId equals b.id
                                 select b;
                    return boards.ToList();
                }
                catch
                {
                    return new List<Board>();

                }

            }


        }
        //// Delete
        public bool DeleteViewers(int boardID)
        {


            using (var dbcontext = new Context())
            {
                try
                {
                    var viewersToDelete = dbcontext.viewers.Where(v =>  v.BoardId == boardID).ToList();
                    if (viewersToDelete.Any())
                    {
                        dbcontext.RemoveRange(viewersToDelete);
                        dbcontext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
                catch { return false; }
            }
        }
        // Khi xóa một board thì nó thay đổi như thế nào đối với viwer 
    }
}
