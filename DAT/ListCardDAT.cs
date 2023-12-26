using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAT
{
    public class ListCardDAT
    {

        public List<ListCard> Get(int BoardId)
        {
            using (var dbcontext = new Context())
            {
                try
                {
                    List<ListCard> listCards = dbcontext.listCards.Where(lc => lc.boardID == BoardId).ToList();

                    return listCards;
                }
                catch
                {
                    return null;
                }
            }


        }
        public int Insert(string Name, int BoardID)
        {


            using (var dbcontext = new Context())
            {
                int location = 0;
                try
                {

                    List<ListCard> listCards = dbcontext.listCards.Where(lc => lc.boardID == BoardID).ToList();
                    
                    var lastListCard = listCards.LastOrDefault();
                    if (lastListCard != null)
                    {
                        location = lastListCard.location + 1;
                    };

                    var newListCard = new ListCard()
                    {
                        name = Name,
                        location = location,
                        boardID = BoardID

                    };
                    dbcontext.listCards.Add(newListCard);
                    dbcontext.SaveChanges();

                    return newListCard.id;
                }
                catch 
                {

                    return -1;
                }

            }
        }

        public bool UpdateName(int listCardID, string Name)
        {
            using (var dbcontext = new Context())
            {
                try
                {
                    var listCard = dbcontext.listCards.Where(lc => lc.id == listCardID).FirstOrDefault();
                    if (listCard != null)
                    {
                        listCard.name = Name;
                        dbcontext.SaveChanges();
                        return true;
                    }
                    else { return false; }

                }
                catch
                {
                    return false;
                }
            }

        }
        public bool DeletebyID(int listCardID)
        {
            using (var dbcontext = new Context())
            {
                try
                {
                    var deletedListCard = dbcontext.listCards.Where(lc => lc.id == listCardID).FirstOrDefault();
                    if (deletedListCard != null)
                    {
                        dbcontext.Remove(deletedListCard);
                        dbcontext.SaveChanges();
                        return true;
                    }
                    else
                    {

                        return false;
                    }



                }
                catch
                {
                    return false;
                }


            }
        }
        public bool MoveLeft(int BoardID, int ListCardID)
        {
            using (var dbcontext = new Context())
            {

                try
                {
                    List<ListCard> selectedlistCards = dbcontext.listCards.Where(lc => lc.boardID == BoardID).OrderBy(lc => lc.location).ToList();
                    if (selectedlistCards.Count > 1)
                    {

                        int indexCurrent = selectedlistCards.FindIndex(lc => lc.id == ListCardID);
                        if (indexCurrent == 0) { return false; }
                        int rightID = selectedlistCards[indexCurrent].id;
                        int rightLocation = selectedlistCards[indexCurrent].location;
                        int leftID = selectedlistCards[indexCurrent-1].id;
                        int leftLocation = selectedlistCards[indexCurrent-1].location;
                        List<Card> rightCardsToUpdate = dbcontext.cards.Where(c => c.listCardid == rightID).ToList();
                        List<Card> leftCardsToUpdate = dbcontext.cards.Where(c => c.listCardid == leftID).ToList();
                        foreach (Card card in rightCardsToUpdate)
                        {
                            card.listCardid = leftID;
                        }
                        foreach (Card card in leftCardsToUpdate)
                        {
                            card.listCardid= rightID;
                        }
                        int temp = rightLocation;
                        rightLocation = leftLocation;
                        leftLocation = temp;
                        dbcontext.SaveChanges();
                        return true;

                    }
                    else
                    {

                        return false;
                    }

                }
                catch
                {
                    return false;

                }

            }

        }
        public static bool MoveRight(int BoardID, int ListCardID)
        {
            using (var dbcontext = new Context())
            {

                try
                {
                    List<ListCard> selectedlistCards = dbcontext.listCards.Where(lc => lc.boardID == BoardID).OrderBy(lc => lc.location).ToList();
                    if (selectedlistCards.Count > 1)
                    {
                        int indexCurrent = selectedlistCards.FindIndex(lc => lc.id == ListCardID);
                        if (indexCurrent == selectedlistCards.Count - 1) { return false; }
                        int tmp = selectedlistCards[indexCurrent].location;
                        selectedlistCards[indexCurrent].location = selectedlistCards[indexCurrent + 1].location;
                        selectedlistCards[indexCurrent + 1].location = tmp;
                        dbcontext.SaveChanges();
                        return true;

                    }
                    else
                    {

                        return false;
                    }

                }
                catch
                {
                    return false;

                }

            }

        }

        public bool DeleteAll(int BoardId)
        {

            using (var dbContext = new Context())
            {
                try
                {
                    List<ListCard> deletedListCards = dbContext.listCards.Where(lc => lc.boardID == BoardId).ToList();
                    if (deletedListCards.Any())
                    {
                        dbContext.RemoveRange(deletedListCards);
                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;

                    }



                }
                catch
                {
                    return false;

                }
            }
        }





    }
}
