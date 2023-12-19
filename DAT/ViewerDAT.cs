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
        public static bool InsertViewer(int userID, int boardID)
        {
            using (var dbcontext = new Context())
            {
                var user = dbcontext.users.Where(u => u.id == userID).FirstOrDefault();
                var board = dbcontext.boards.Where(b => b.id == boardID).FirstOrDefault();
                if (user != null && board != null)
                {
                    var viewer = new Viewer() { userID = userID, boardID = boardID };
                    dbcontext.viewers.Add(viewer);
                    dbcontext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // Get
        public static List<Board> GetViwerBoards(int userID) {
            using (var dbcontext = new Context() ) {
                try { 
                
                  var viewer = (from v in dbcontext.viewers
                                     where v.userID == userID
                                     select v);
                    var boards = from v in viewer
                                 join b in dbcontext.boards on v.boardID equals b.id
                                 select b;
                    return boards.ToList();
                } catch {
                    return new List<Board>();
                
                } 
            
            }


        }
        // Delete
        public static bool DeleteViewer(int userID, int boardID) {


            using (var dbcontext = new Context()) {
                try { 
                    var viewer = dbcontext.viewers.Where(v => v.userID == userID && v.boardID == boardID).FirstOrDefault();
                    if (viewer != null)
                    {
                        dbcontext.Remove(viewer);
                        dbcontext.SaveChanges();
                        return true;
                    }
                    else {
                        return false;
                    }
                
                
                } catch { return false; }
            }
        }
        // Khi xóa một board thì nó thay đổi như thế nào đối với viwer 
    }
}
