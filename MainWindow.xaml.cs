using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static CoffeeShopFinal.CoffeeShop;

namespace CoffeeShopFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int mCappuccino = 0;
        private int mCaffeLatte = 0;
        private int mEspresso = 0;
        private int mVanillaLatte = 0;
        private int mCaramelLatte = 0;
        private int mCaffeMocha = 0;
        private int mPeppermint = 0;
        private int mForestBerry = 0;
        private int mMatcha = 0;
        private double Total = 0;
        private DrinkType selectedDrink;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CappuccinoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mCappuccino++;
            txtCappuccino.Text = mCappuccino.ToString();
        }
        private void CaffeLatteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mCaffeLatte++;
            txtCaffeLatte.Text = mCaffeLatte.ToString();
        }
        private void EspressoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mEspresso++;
            txtEspresso.Text = mEspresso.ToString();
        }
        private void VanillaLatteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mVanillaLatte++;
            txtVanilla.Text = mVanillaLatte.ToString();
        }
        private void CaramelLatteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mCaramelLatte++;
            txtCaramel.Text = mCaramelLatte.ToString();
        }
        private void CaffeMochaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mCaffeMocha++;
            txtMocha.Text = mCaffeMocha.ToString();
        }
        private void PeppermintMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mPeppermint++;
            txtPeppermint.Text = mPeppermint.ToString();
        }
        private void ForestBerryMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mForestBerry++;
            txtForestBerry.Text = mForestBerry.ToString();

        }


        private void MatchaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mMatcha++;
            txtMatcha.Text = mMatcha.ToString();
        }

        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        KeyValuePair<DrinkType, double>[] PriceList =
        {
            new KeyValuePair<DrinkType, double>(DrinkType.Cappuccino,8),
            new KeyValuePair<DrinkType, double>(DrinkType.CaffeLatte,9),
            new KeyValuePair<DrinkType, double>(DrinkType.Espresso,6),
            new KeyValuePair<DrinkType, double>(DrinkType.VanillaLatte,12),
            new KeyValuePair<DrinkType, double>(DrinkType.CaramelLatte,14),
            new KeyValuePair<DrinkType, double>(DrinkType.CaffeMocha,15),
            new KeyValuePair<DrinkType, double>(DrinkType.Peppermint,6.5),
            new KeyValuePair<DrinkType, double>(DrinkType.ForestBerry,8.5),
            new KeyValuePair<DrinkType, double>(DrinkType.Matcha,10),
        };

        private void MakingCoffeeandTea_Click(object sender, RoutedEventArgs e)
        {
            string mesaj;
            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            mesaj = SelectedItem.Header.ToString() + " Drinks are being prepared!";
            this.Title = mesaj;
        }
        private void frmMain_Loaded_1(object sender, RoutedEventArgs e)
        {
            cmbType.ItemsSource = PriceList;
            cmbType.DisplayMemberPath = "Key";
            cmbType.SelectedValuePath = "Value";
        }

        private void cmbType_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            txtPrice.Text = cmbType.SelectedValue.ToString();
            KeyValuePair<DrinkType, double> selectedEntry =
           (KeyValuePair<DrinkType, double>)cmbType.SelectedItem;
            selectedDrink = selectedEntry.Key;
        }

    private int ValidateQuantity(DrinkType selectedDrink)
        {
            int q = int.Parse(txtQuantity.Text);
            int r = 1;

            switch (selectedDrink)
            {
                case DrinkType.Cappuccino:
                    if (q > mCappuccino)
                        r = 0;
                    break;
                case DrinkType.CaffeLatte:
                    if (q > mCaffeLatte)
                        r = 0;
                    break;
                case DrinkType.Espresso:
                    if (q > mEspresso)
                        r = 0;
                    break;
                case DrinkType.VanillaLatte:
                    if (q > mVanillaLatte)
                        r = 0;
                    break;
                case DrinkType.CaramelLatte:
                    if (q > mCaramelLatte)
                        r = 0;
                    break;
                case DrinkType.CaffeMocha:
                    if (q > mCaffeMocha)
                        r = 0;
                    break;
                case DrinkType.Peppermint:
                    if (q > mPeppermint)
                        r = 0;
                    break;
                case DrinkType.ForestBerry:
                    if (q > mForestBerry)
                        r = 0;
                    break;
                case DrinkType.Matcha:
                    if (q > mMatcha)
                        r = 0;
                    break;
            }
            return r;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuantity(selectedDrink) > 0)
            {
                lstSale.Items.Add(txtQuantity.Text + " " + selectedDrink.ToString() +
               ":" + txtPrice.Text + " " + double.Parse(txtQuantity.Text) *
               double.Parse(txtPrice.Text));
                Total = Total + double.Parse(txtQuantity.Text) * double.Parse(txtPrice.Text);
                txtTotal.Text = Total.ToString();
            }
            else
            {
                MessageBox.Show("Cantitatea introdusa nu este disponibila in stoc!");
            }
        }
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            lstSale.Items.Remove(lstSale.SelectedItem);
        }
          private void btnCheckout_Click_1(object sender, RoutedEventArgs e)
        {
            txtTotal.Text = "0";
            foreach (string s in lstSale.Items)
            {
                switch (s.Substring(s.IndexOf(" ") + 1, s.IndexOf(":") - s.IndexOf(" ") - 1))
                {
                    case "Cappuccino":
                        mCappuccino = mCappuccino - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtCappuccino.Text = mCappuccino.ToString();
                        break;
                    case "Caffe Latte":
                        mCaffeLatte = mCaffeLatte - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtCaffeLatte.Text = mCaffeLatte.ToString();
                        break;
                    case "Espresso":
                        mEspresso = mEspresso - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtEspresso.Text = mEspresso.ToString();
                        break;
                    case "Vanilla Latte":
                        mVanillaLatte = mVanillaLatte - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtVanilla.Text = mVanillaLatte.ToString();
                        break;
                    case "Caramel Latte":
                        mCaramelLatte = mCaramelLatte - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtCaramel.Text = mCaramelLatte.ToString();
                        break;
                    case "Caffe Mocha":
                        mCaffeMocha = mCaffeMocha - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtMocha.Text = mCaffeMocha.ToString();
                        break;
                    case "Peppermint":
                        mPeppermint = mPeppermint - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtPeppermint.Text = mPeppermint.ToString();
                        break;
                    case "Forest Berry":
                        mForestBerry = mForestBerry - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtForestBerry.Text = mForestBerry.ToString();
                        break;
                    case "Matcha":
                        mMatcha = mMatcha - Int32.Parse(s.Substring(0, s.IndexOf(" ")));
                        txtMatcha.Text = mMatcha.ToString();
                        break;
                }
            }
            lstSale.Items.Clear();

        }

        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }

        }
    }

}
