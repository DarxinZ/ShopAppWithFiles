using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProjWithFile
{
    public class SportsItem : Item
    {
        protected string[] fit4Sports;
        protected string userInstructions;
        public SportsItem(string company, string name, double price, bool isRecycable, string[] fit4Sports, string userInstructions)
            : base(company, name, price, isRecycable)
        {
            this.fit4Sports = fit4Sports; this.userInstructions = userInstructions;
        }
        public SportsItem(string company, string name, double price, bool isRecycable, string userInstructions)
            : base(company, name, price, isRecycable)
        {
            //fit4Sports = new string[1]; fit4Sports[0] = "General";
            this.userInstructions = userInstructions;
        }
        public void AddSport(string sport)
        {
            if (this.fit4Sports == null)
            {
                this.fit4Sports = new string[1];
                this.fit4Sports[0] = sport;
            }
            else
            {
                string[] temp = new string[this.fit4Sports.Length + 1];
                for (int i = 0; i < this.fit4Sports.Length; i++)
                    temp[i] = this.fit4Sports[i];
                temp[this.fit4Sports.Length] = sport;
                this.fit4Sports = temp;
            }
        }
        public string GetInstructions() { return userInstructions; }
        public void SetUserInstructions(string userInstructions)
        { this.userInstructions = userInstructions; }
        public bool IsSportSupported(string fit4Sports)
        {
            for (int i = 0; i < this.fit4Sports.Length; i++)
                if (this.fit4Sports[i] == fit4Sports)
                    return true;
            return false;
        }
        public override string ToString()
        {
            string str = "Sports: ";
            for (int i = 0; fit4Sports != null && i < fit4Sports.Length; i++)
            {
                str += fit4Sports[i];
                if (i != fit4Sports.Length - 1) str += ",";
            }
            return base.ToString() + str + ", Instruction Manual: " + userInstructions;
        }
        public override string MakeLine4File()
        {
            string str = "";
            for (int i = 0; fit4Sports != null && i < fit4Sports.Length; i++)
                str += ":" + fit4Sports[i];
            return String.Format("ie:{0}:{1}:{2}:{3}:{4}{5}", company, name, price, isRecycable, userInstructions, str);
        }
    }
}
