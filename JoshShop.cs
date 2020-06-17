using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProjWithFile
{
    public class JoshShop
    {
        Item[] items;
        public JoshShop() { items = null; }
        private int FindNull() // find and return index with null or -1 if not found
        {
            for (int i = 0; items != null && i < items.Length; i++)
                if (items[i] == null) return i;
            return -1;
        }
        private void MakeRoom4Items() // enlarge array
        {
            if (items == null)
                items = new Item[1];
            else
            {
                Item[] temp = new Item[items.Length + 1];
                for (int i = 0; i < items.Length; i++)
                    temp[i] = items[i];
                items = temp;
            }
        }
        public bool AddItem(Item item) // add item if not exist return bool status
        {
            if (FindIndexByName(item.GetName()) != -1)
                return false;
            int index2Add = 0;
            if (items == null)
                items = new Item[1];
            else
            {
                index2Add = FindNull();
                if (index2Add == -1)
                {
                    index2Add = items.Length;
                    MakeRoom4Items();
                }
            }
            items[index2Add] = item;
            return true;
        }
        private int FindIndexByName(string name) // find and return index of item or -1 if not exist in array
        {
            for (int i = 0; items != null && i < items.Length; i++)
                if (items[i].GetName() == name) return i;
            return -1;
        }
        public Item GetItemByName(string name) // get Item by name (null if not there)
        {
            Item i = null;
            int indexFound = FindIndexByName(name);
            if (indexFound != -1)
                i = items[indexFound];
            return i;
        }
        public bool DelItemByName(string name) // delete item by name (return status)
        {
            int indexFound = FindIndexByName(name);
            if (indexFound != -1)
            {
                items[indexFound] = null;
                return true;
            }
            return false;
        }
        public bool UpdateItem(Item item) // update existig item (return status) 
        {
            int indexFound = FindIndexByName(item.GetName());
            if (indexFound != -1)
            {
                items[indexFound] = item;
                return true;
            }
            return false;
        }
        public int ItemCount()
        {
            int count = 0;
            for (int i = 0; items != null && i < items.Length; i++)
                if (items[i] != null)
                    count++;
            return count;
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                    str += items[i].ToString() + "\n";
            }
            return str;
        }

        public string[] AllItemArray()
        {
            int length = ItemCount();
            string[] arr = new string[length];
            for (int i = 0; i < items.Length; i++)
                if (items[i] != null)
                {
                    string str = "name: " + items[i].GetName() + ", Comp:" + items[i].GetCompany() + ", Price:" + items[i].GetPrice();
                    arr[--length] = str;
                }
            return arr;
        }
    }
}
