using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAT
{
    public class CardDAT
    {
        public int Insert(string title, string des, int listCardId ) {

            using (var dbcontext = new Context())
            {
                int location = 0;
                try
                {
                    List<Card> cards = dbcontext.cards.Where(c => c.listCardid ==listCardId).ToList();

                    var lastcard = cards.LastOrDefault();
                    if (lastcard != null)
                    {
                        location = lastcard.location + 1;
                    };

                    var newCard = new Card()
                    {
                        tittle = title,
                        desciption = des,
                        location = location,
                        listCardid= listCardId

                    };
                    dbcontext.cards.Add(newCard);
                    dbcontext.SaveChanges();

                    return newCard.id;
                }
                catch 
                {
                    return -1;
                }

            }
        }

        public static bool UpdateTittle(int cardID, string tittle)
        {
            using (var dbcontext = new Context())
            {
                try
                {
                    var card = dbcontext.cards.Where(c => c.id == cardID).FirstOrDefault();
                    if (card != null)
                    {
                        card.tittle = tittle;
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
        public static bool UpdateDescription(int cardID, string des)
        {
            using (var dbcontext = new Context())
            {
                try
                {
                    var card = dbcontext.cards.Where(c => c.id == cardID).FirstOrDefault();
                    if (card != null)
                    {
                        card.desciption = des;
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
        public bool DeletebyID(int cardID)
        {
            using (var dbcontext = new Context())
            {
                try
                {
                    var deletedCard = dbcontext.cards.Where(c => c.id == cardID).FirstOrDefault();
                    if (deletedCard != null)
                    {
                        dbcontext.Remove(deletedCard);
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
        public bool MoveUpward(int listCardID, int cardID)
        {
            using (var dbcontext = new Context())
            {

                try
                {
                    List<Card> selectedCards = dbcontext.cards.Where(c => c.listCardid == listCardID).ToList();
                    if (selectedCards.Count > 1)
                    {
                        int indexCurrent = selectedCards.FindIndex(lc => lc.id == cardID);
                        if (indexCurrent == 0) { return false; }
                        int tmp = selectedCards[indexCurrent].location;
                        selectedCards[indexCurrent].location = selectedCards[indexCurrent - 1].location;
                        selectedCards[indexCurrent - 1].location = tmp;
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
        public bool MoveDownward(int listCardID, int cardID)
        {
            using (var dbcontext = new Context())
            {

                try
                {
                    List<Card> selectedCards = dbcontext.cards.Where(c => c.listCardid == listCardID).ToList();
                    if (selectedCards.Count > 1)
                    {
                        int indexCurrent = selectedCards.FindIndex(lc => lc.id == cardID);
                        if (indexCurrent == selectedCards.Count-1 ) { return false; }
                        int tmp = selectedCards[indexCurrent].location;
                        selectedCards[indexCurrent].location = selectedCards[indexCurrent + 1].location;
                        selectedCards[indexCurrent + 1].location = tmp;
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
        

        public bool MoveHorizontally(int cardID,int listCardID ) {
            using (var dbcontext = new Context()) {
                try {
                    List<Card> cards = dbcontext.cards.Where(c => c.listCardid == listCardID).ToList();
                    Card lastCard = cards.LastOrDefault();
                    Card changedCard = dbcontext.cards.Where(c => c.id == cardID).FirstOrDefault();
                    if (changedCard != null)
                    {
                        int location = 0;
                        if (lastCard != null)
                        {
                            location = lastCard.location + 1;
                        }
                        changedCard.location = location;
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

        public bool DeleteAll(int listCardID)
        {

            using (var dbContext = new Context())
            {
                try
                {
                    List<Card> deletedCards = dbContext.cards.Where(c => c.listCardid == listCardID).ToList();
                    if (deletedCards.Any())
                    {
                        dbContext.RemoveRange(deletedCards);
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
