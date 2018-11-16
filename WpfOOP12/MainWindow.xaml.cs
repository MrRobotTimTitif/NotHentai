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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace WpfOOP12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double x0 = -5;                         
        private double xk = 5;
        private double delta = 0.5;
        ZedGraphControl ze1 = new ZedGraphControl();
        ZedGraphControl ze2 = new ZedGraphControl();
        ZedGraphControl ze3 = new ZedGraphControl();
        public MainWindow()
        {
            InitializeComponent();

            windowsformhost1.Child = ze1;
            windowsformhost2.Child = ze2;
            windowsformhost3.Child = ze3;
          
        }
        private double Func1(double x)
        {
            if (x == 0)
            {
                return 1;
            }
            return Math.Pow(x,2);
        }               
        private double Func2(double x)
        {
            if (x == 0)
            {
                return 1;
            }
            return 10*x;
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GraphPane myPane1 = ze1.GraphPane;
            GraphPane myPane2 = ze2.GraphPane;
            GraphPane myPane3= ze3.GraphPane;
            
            myPane1.Title.Text = "F(x,y)";
            myPane1.XAxis.Title.Text = "x";
            myPane1.YAxis.Title.Text = "y";

            myPane2.Title.Text = "F(x,y)";
            myPane2.XAxis.Title.Text = "x";
            myPane2.YAxis.Title.Text = "y";

            myPane3.Title.Text = "F(x,y)";
            myPane3.XAxis.Title.Text = "x";
            myPane3.YAxis.Title.Text = "y";

            PointPairList list1= new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            PointPairList list5 = new PointPairList();
            PointPairList list6 = new PointPairList();

            for (double x = x0; x <= xk; x += delta)
            {
                list1.Add(x, Func1(x));
                list2.Add(x, Func2(x));
            }
            LineItem myCurve1 = myPane1.AddCurve("x^2", list1, Color.Green, SymbolType.Triangle);
            
            myPane1.AddCurve("10x", list2, Color.Black, SymbolType.HDash);

            for (double x = x0; x <= 2.5; x += delta)
            {
                list3.Add(x, Func1(x));
                list4.Add(x, Func2(x));
            }
            LineItem myCurve2= myPane2.AddCurve("x^2", list3, Color.Blue, SymbolType.Diamond);
            myPane2.AddCurve("10x", list4, Color.Brown, SymbolType.Plus);

            for (double x = 2.5; x <= xk; x += delta)
            {
                list5.Add(x, Func1(x));
                list6.Add(x, Func2(x));
            }

            LineItem myCurve3 = myPane3.AddCurve("x^2", list5, Color.DarkBlue, SymbolType.XCross);
            myPane3.AddCurve("10x", list6, Color.DarkGreen,SymbolType.TriangleDown);

            ze1.AxisChange();
            ze1.Invalidate();

            ze2.AxisChange();
            ze2.AxisChange();

            ze3.AxisChange();
            ze3.AxisChange();

            ze1.Invalidate();
            ze2.Invalidate();
            ze3.Invalidate();
        }
    } 
}
