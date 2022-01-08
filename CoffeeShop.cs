using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopFinal
{
    class CoffeeShop
    {
        private DrinkType mFlavor;
        public DrinkType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }
        private float mPrice;
        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        public CoffeeShop(DrinkType aFlavor) // constructor
        {
            mFlavor = aFlavor;
        }
        public enum DrinkType
        {
            Cappuccino,
            CaffeLatte,
            Espresso,
            VanillaLatte,
            CaramelLatte,
            CaffeMocha,
            Peppermint,
            ForestBerry,
            Matcha,
        }

    }

}

