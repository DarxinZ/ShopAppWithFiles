using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProjWithFile
{
    public class Item
    {
        protected string company;
        protected string name;
        protected double price;
        protected bool isRecycable;

        protected Item() { }
        public Item(string company, string name, double price, bool isRecycable)
        {
            this.company = company; this.name = name; this.price = price; this.isRecycable = isRecycable;
        }
        public Item(string company, string name, double price)
        {
            this.company = company; this.name = name; this.price = price;
            this.isRecycable = false;
        }
        public string GetName() { return name; }
        public string GetCompany() { return company; }
        public double GetPrice() { return price; }
        public bool IsRecycable() { return isRecycable; }
        public void SetPrice(double price) { this.price = price; }
        public void SetRecycable(bool recycable) { this.isRecycable = recycable; }
        public override string ToString()
        {
            string str = String.Format("Item name: {0}, made by {1}, cost: {2}", name, company, price);
            if (isRecycable)
                str += ", we recycle! ";
            return str;
        }

        public virtual string MakeLine4File()
        {
            return String.Format("ii:{0}:{1}:{2}:{3}",company,name,price, isRecycable);
        }
    }
}
