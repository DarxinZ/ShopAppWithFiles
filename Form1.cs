using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopProjWithFile
{
    public partial class Form1 : Form
    {
        JoshShop shop;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // קוד להעלאת הקובץ למערך
            shop = new JoshShop();
            comboBox1.Items.Add("General Item");
            comboBox1.Items.Add("Electric Item");
            comboBox1.Items.Add("Sports Item");
            comboBox1.SelectedIndex = 0;
            label5.Hide();
            Item5Desc.Hide();
            item6volt.Hide();
            button7.Hide();
            button8.Hide();
        }
        private bool ValidItem()
        {
            return (item1Name.Text != "" && item2Company.Text != "" && item3Price.Text != "");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidItem())
            {
                Item i;
                bool b = false;
                if (comboBox1.SelectedIndex == 1) // electric
                {
                    i = new ElectricItem(item2Company.Text, item1Name.Text, double.Parse(item3Price.Text), checkBox1.Checked, Item5Desc.Text);
                    b = shop.AddItem(i);
                }
                else if (comboBox1.SelectedIndex == 2) // sports
                {
                    i = new SportsItem(item2Company.Text, item1Name.Text, double.Parse(item3Price.Text), checkBox1.Checked, Item5Desc.Text);
                    b = shop.AddItem(i);
                }
                else // just item
                {
                    i = new Item(item2Company.Text, item1Name.Text, double.Parse(item3Price.Text), checkBox1.Checked);
                    b = shop.AddItem(i);
                }

                if (b)
                {
                    MessageBox.Show("Item Added !!");
                    toStringText.Text = shop.GetItemByName(item1Name.Text).ToString();
                }
                else
                    MessageBox.Show("General or Duplicate Item Error!!");
            }
            else
            {
                MessageBox.Show("Missing Basic Informathion...");
            }
        }

        private void FillData(Item i)
        {
            ClearAllInfo();
            if (i is ElectricItem)
            {
                comboBox1.SelectedIndex = 1;
                Item5Desc.Text = ((ElectricItem)i).GetInstructions();
            }
            else if (i is SportsItem)
            {
                comboBox1.SelectedIndex = 2;
                Item5Desc.Text = ((SportsItem)i).GetInstructions();
            }
            else
            { comboBox1.SelectedIndex = 0; }

            item1Name.Text = i.GetName();
            item2Company.Text = i.GetCompany();
            item3Price.Text = "" + i.GetPrice();
            checkBox1.Checked = i.IsRecycable();
            toStringText.Text = i.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Item i = shop.GetItemByName(item1Name.Text);
            if (i == null)
            {
                MessageBox.Show("Item Not Found !!");
                ClearAllInfo();
            }
            else
            {
                bool b = false;
                if (comboBox1.SelectedIndex == 1) // electric
                {
                    ElectricItem ei = (ElectricItem)i;
                    ei.SetPrice(double.Parse(item3Price.Text));
                    ei.SetRecycable(checkBox1.Checked);
                    ei.SetUserInstructions(Item5Desc.Text);
                    b = shop.UpdateItem(i);
                }
                else if (comboBox1.SelectedIndex == 2) // sports
                {
                    SportsItem ei = (SportsItem)i;
                    ei.SetPrice(double.Parse(item3Price.Text));
                    ei.SetRecycable(checkBox1.Checked);
                    ei.SetUserInstructions(Item5Desc.Text);
                    b = shop.UpdateItem(i);
                }
                else // just item
                {
                    i.SetPrice(double.Parse(item3Price.Text));
                    i.SetRecycable(checkBox1.Checked);
                    b = shop.UpdateItem(i);
                }

                if (b)
                {
                    MessageBox.Show("Item Updated !!");
                    FillData(i);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Item i = shop.GetItemByName(item1Name.Text);
            if (i == null)
            {
                MessageBox.Show("Item Not Found !!");
                ClearAllInfo();
            }
            else
                FillData(i);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            bool b = shop.DelItemByName(item1Name.Text);
            if (b) MessageBox.Show("Item Deleted !!");
            else MessageBox.Show("Item Not Found !!");
            ClearAllInfo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] arr = shop.AllItemArray();
            listView1.Items.Clear();
            listView1.AutoArrange = true;
            for (int i = 0; i < arr.Length; i++)
            {
                listView1.Items.Add(new ListViewItem(arr[i]));
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save Not Ready yet...");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAllInfo();
            if (comboBox1.SelectedIndex == 1)
            {
                label5.Show();
                Item5Desc.Show();
                item6volt.Show();
                button7.Hide();
                button8.Show();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                label5.Show();
                Item5Desc.Show();
                item6volt.Show();
                button7.Show();
                button8.Hide();
            }
            else
            {
                comboBox1.SelectedIndex = 0;
                label5.Hide();
                Item5Desc.Hide();
                item6volt.Hide();
                button7.Hide();
                button8.Hide();
            }
        }

        private void ClearAllInfo()
        {
            item1Name.Text = "";
            item2Company.Text = "";
            item3Price.Text = "";
            Item5Desc.Text = "";
            item6volt.Text = "";
            toStringText.Text = "";
        }
        private void item3Price_TextChanged(object sender, EventArgs e)
        {
            double x;
            if (item3Price.Text != "" && !double.TryParse(item3Price.Text, out x))
            {
                MessageBox.Show("Please enter only numbers 4 price.");
                item3Price.Text = "";
            }
        }

        private void item6volt_TextChanged(object sender, EventArgs e)
        {
            double x;
            if (comboBox1.SelectedIndex == 1 && !double.TryParse(item6volt.Text, out x))
            {
                MessageBox.Show("Volt must be numbers only.");
                item6volt.Text = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1 && item6volt.Text == "")
                MessageBox.Show("Must Enter a number for volt!");
            else if (shop.GetItemByName(item1Name.Text)==null || !(shop.GetItemByName(item1Name.Text) is ElectricItem))
                MessageBox.Show("Electric Item not found!");
            else
            {
                ElectricItem ei = (ElectricItem)(shop.GetItemByName(item1Name.Text));
                ei.AddVolt(int.Parse(item6volt.Text));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2 && item6volt.Text == "")
                MessageBox.Show("Enter Secific sport or 'General'");
            else if (shop.GetItemByName(item1Name.Text) == null || !(shop.GetItemByName(item1Name.Text) is SportsItem))
                MessageBox.Show("Sports Item not found!");
            else
            {
                SportsItem si = (SportsItem)(shop.GetItemByName(item1Name.Text));
                si.AddSport(item6volt.Text);
            }
        }
    }
}
