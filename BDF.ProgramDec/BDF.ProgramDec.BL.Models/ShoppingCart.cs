using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDF.ProgramDec.BL.Models
{
    public class ShoppingCart
    {

        //This does not apply to your dvd central app
        //the cost of a movie is retrieved from the tblMovie.cost
        const double ITEM_COST = 49.99;

        public List<ProgDec> Items { get; set; }
        public int TotalCount { get { return Items.Count; } }
        public double TotalCost { get; set; }
        public ShoppingCart()
        {
            Items = new List<ProgDec>();
        }

        public void Add(ProgDec progDec)
        {
            Items.Add(progDec);
            TotalCost += ITEM_COST; //Cost of each movie for DVDCentral
        }
        public void Remove(ProgDec progDec)
        {
            Items.Remove(progDec);
            TotalCost -= ITEM_COST;
        }

        public void Checkout()
        {
            Items = new List<ProgDec>();
            TotalCost = 0;
        }
    }
}
