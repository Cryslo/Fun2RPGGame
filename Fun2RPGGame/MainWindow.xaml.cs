using System;
using System.Collections.Generic;
using System.Data;
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

namespace Fun2RPGGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void getSQLdata1_Click(object sender, RoutedEventArgs e)
        {
            RPGSQLContext rmc = new RPGSQLContext();
            RPGRepository rpr = new RPGRepository(rmc);
            string query = "Select C.Name, CL.Name as Classname, IT.Name as Itemname, CAT.Name as Category, IT.LevelRequirement " +
            "From Inventory I " +
            "join Character C on C.CharacterID = I.CharacterID " +
            "join Class CL on CL.ClassID = C.ClassID " +
            "join Item IT on IT.ItemID = I.ItemID " +
            "join Category CAT on CAT.CategoryID = IT.CategoryID ";
            DataTable dt = rpr.Query1(query);
            dataGridView.DataContext = dt.DefaultView;
        }

        private void getSQLdata2_Click(object sender, RoutedEventArgs e)
        {
            RPGSQLContext rmc = new RPGSQLContext();
            RPGRepository rpr = new RPGRepository(rmc);
            string query = "select  C.name, A.Dexterity "+
            "from BaseAttributes BA "+
            "join Attributes A on a.AttributeID = BA.AttributeID " +
            "join Class C on C.ClassID = BA.ClassID " +
            "Order by A.Dexterity asc ";
            DataTable dt = rpr.Query1(query);
            dataGridView.DataContext = dt.DefaultView;
        }

        private void getSQLdata3_Click(object sender, RoutedEventArgs e)
        {
            RPGSQLContext rmc = new RPGSQLContext();
            RPGRepository rpr = new RPGRepository(rmc);
            string query = "select Health, Mana, ch.Name " +
            "from BaseAttributes b " +
            "join Attributes a on a.AttributeID = b.AttributeID " +
            "join Class c on c.ClassID = b.ClassID " +
            "full outer join Character ch on ch.ClassID = c.ClassID";
            DataTable dt = rpr.Query1(query);
            dataGridView.DataContext = dt.DefaultView;
        }

        private void getSQLdata4_Click(object sender, RoutedEventArgs e)
        {
            RPGSQLContext rmc = new RPGSQLContext();
            RPGRepository rpr = new RPGRepository(rmc);
            string query = "select Health " +
            "from attributes " +
            "group by Strength, Health " +
            "having Strength > 4 ";
            DataTable dt = rpr.Query1(query);
            dataGridView.DataContext = dt.DefaultView;
        }

        private void getSQLdata5_Click(object sender, RoutedEventArgs e)
        {
            RPGSQLContext rmc = new RPGSQLContext();
            RPGRepository rpr = new RPGRepository(rmc);
            string query = "with Categoryrecursive as (" +
            "    select CategoryID, ParentID, Name,0 AS LEVEL " +
            "    from Category " +
            "    where ParentID is null " +
            "    union ALL " +
            "    select c.CategoryID, c.ParentID, c.Name,Level + 1 AS LEVEL " +
            "    from Category c " +
            "    inner " +
            "    join Categoryrecursive as cr on c.ParentID = cr.CategoryID " +
            ") select * from Categoryrecursive ";
            DataTable dt = rpr.Query1(query);
            dataGridView.DataContext = dt.DefaultView;
        }

        private void getSQLdata6_Click(object sender, RoutedEventArgs e)
        {
            RPGSQLContext rmc = new RPGSQLContext();
            RPGRepository rpr = new RPGRepository(rmc);
            string query = "Select (select price from item it where it.ItemID = inv.ItemID) as Itemprices from Inventory inv";
            DataTable dt = rpr.Query1(query);
            dataGridView.DataContext = dt.DefaultView;
        }
    }
}
