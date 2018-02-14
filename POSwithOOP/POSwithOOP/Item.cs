using System.Collections.Generic;

namespace POSwithOOP
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public int ItemStock { get; set; }

        public List<Item> AllItems { get; set; }
        public List<string> ItemNameList { get; set; } 

        public Item()
        {
            ItemId++;
            AllItems = new List<Item>();
            ItemNameList=new List<string>();
        }

        public Item(string itemName, double itemPrice, int itemStock)
        {
            ItemId++;
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemStock = itemStock;

        }


        
    }
}