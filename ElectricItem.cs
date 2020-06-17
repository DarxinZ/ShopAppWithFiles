using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProjWithFile
{
    public class ElectricItem : Item
    {
        protected double[] volt = null;
        protected string userInstructions;
        public ElectricItem(string company, string name, double price, bool isRecycable, double[] volt, string userInstructions)
            : base(company, name, price, isRecycable)
        {
            this.volt = volt; this.userInstructions = userInstructions;
        }
        public ElectricItem(string company, string name, double price, bool isRecycable, string userInstructions)
            : base(company, name, price, isRecycable)
        {
            //volt = new double[1]; volt[0] = 220;
            this.userInstructions = userInstructions;
        }
        public void AddVolt(int volt)
        {
            if (this.volt == null)
            {
                this.volt = new double[1];
                this.volt[0] = volt;
            }
            else
            {
                double[] temp = new double[this.volt.Length + 1];
                for (int i = 0; i < this.volt.Length; i++)
                    temp[i] = this.volt[i];
                temp[this.volt.Length] = volt;
                this.volt = temp;
            }
        }
        public string GetInstructions() { return userInstructions; }
        public void SetUserInstructions(string userInstructions)
        { this.userInstructions = userInstructions; }
        public bool IsVoltSupported(double volt)
        {
            for (int i = 0; i < this.volt.Length; i++)
                if (this.volt[i] == volt)
                    return true;
            return false;
        }
        public override string ToString()
        {
            string str = "Voltage: ";
            for (int i = 0; volt!=null && i < volt.Length; i++)
            {
                str += volt[i];
                if (i != volt.Length - 1) str += ",";
            }
            return base.ToString() + str + ", Instruction Manual: " + userInstructions;
        }
        public override string MakeLine4File()
        {
            string str = "";
            for (int i = 0; volt != null && i < volt.Length; i++)
                str += ":" + volt[i];
            return String.Format("ie:{0}:{1}:{2}:{3}:{4}{5}", company, name, price, isRecycable, userInstructions, str);
        }
    }
}
