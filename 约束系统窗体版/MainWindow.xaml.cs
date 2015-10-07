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

namespace 约束系统窗体版
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combinator.initial(cdegree, fdegree);
        }
        cesius cdegree = new cesius();
        fah fdegree = new fah();
       
        private void quitbt_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("你要退出吗？", "退出程序", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                Environment.Exit(0);

        }

       

        public void fok_Click(object sender, RoutedEventArgs e)
        {
            if (fabox.Text == "")
            {
                MessageBox.Show("请输入数字！");
            }
            else
            {
                int temp = int.Parse(fabox.Text);
                fdegree.Tempeture = temp;
            }
        }

        private void cok_Click(object sender, RoutedEventArgs e)
        {
            if (cdbox.Text == "")
            {
                MessageBox.Show("请输入数字！");

            }
            else
            {
                int temp = int.Parse(cdbox.Text);
                cdegree.Tempeture = temp;
            }
        }

        private void cal_Click(object sender, RoutedEventArgs e)
        {
            if (fabox.Text != "" && cdbox.Text != "")
            {
                MessageBox.Show("应至多一个文本框为空！");

            }if (fabox.Text == "" && cdbox.Text == "") { MessageBox.Show("至少输入一个数字！"); }
            else
            {
                int check = combinator.check(cdegree, fdegree);
                if (check == 0)
                    cdbox.Text = cdegree.Tempeture.ToString();
                else if (check == 1)
                    fabox.Text = fdegree.Tempeture.ToString();
            }
        }

        private void calagain_Click(object sender, RoutedEventArgs e)
        {
            combinator.initial(cdegree,fdegree);
            cdbox.Clear();
            fabox.Clear();
            
        }

        private void cdbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void fabox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    public class cesius
    {

        private int tempeture;
        public int Tempeture
        {
            get
            {
                return this.tempeture;
            }
            set
            {
                if (value != this.tempeture)
                {
                    this.tempeture = value;

                    combinator.cchanger0 = 1;

                }
            }
        }
    }
    public class fah
    {

        private int tempeture;
        public int Tempeture
        {
            get
            {
                return tempeture;
            }
            set
            {
                if (value != tempeture)
                {
                    tempeture = value;

                    combinator.fahchanger0 = 1;

                }

            }
        }
    }


    public static class combinator
    {
        public static int cchanger0 = 0;
        public static int fahchanger0 = 0;
        public static int  check(cesius cd, fah fa)
        {
            if (cchanger0 == 0)
            {
                productc(cd, fa);
                return 0;
            }
            else if (fahchanger0 == 0)
            {
                productf(cd, fa);
                return 1;
            }
            return -1;
        }

        public static void productf(cesius cd, fah fa)
        {
            int pipe = 9 * cd.Tempeture;
            int pipe2 = pipe / 5;
            fa.Tempeture = pipe2 + 32;
        }

        public static void productc(cesius cd, fah fa)
        {
            cd.Tempeture = (5 * (fa.Tempeture - 32)) / 9;
        }
        public static void initial(cesius cd, fah fa)
        {
            cd.Tempeture = int.MinValue;
            fa.Tempeture = int.MinValue;
            cchanger0 = 0;
            fahchanger0 = 0;
        }
    }

}
