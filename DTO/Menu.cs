using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTraSua.DTO
{
    public class Menu
    {
        private string foodName;
        private float price;
        private int count;
        private float totalPrice;

        public Menu(string foodName, float price, int count, float totalPrice = 0)
        {
            this.FoodName = foodName;
            this.Price = price;
            this.Count = count;
            this.TotalPrice = totalPrice;
        }

        public Menu(DataRow row) 
        {
            this.FoodName = row["foodName"].ToString();
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.Count = (int)row["count"];
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }

        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public float TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
    }
}
