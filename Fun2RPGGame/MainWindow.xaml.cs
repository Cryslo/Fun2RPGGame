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
            string query = "SELECT sk.Naam from Character_Skills cs join Skill sk on sk.SkillID = cs.SkillID where sk.Damage > 50 ";
            DataTable dt = rpr.Query1(query);
            dataGridView.DataContext = dt.DefaultView;
        }

        private void getSQLdata2_Click(object sender, RoutedEventArgs e)
        {
            RPGSQLContext rmc = new RPGSQLContext();
            RPGRepository rpr = new RPGRepository(rmc);
            string query = "SELECT ch.Name, cl.Name\r\nfrom Character ch\r\njoin Class cl on cl.ClassID = ch.ClassID\r\njoin BaseAttributes ba on ba.ClassID = ch.ClassID\r\njoin Attributes atri on atri.AttributeID = ba.AttributeID\r\nwhere Strength < (Select avg(Strength) from Attributes) and cl.Name = \'Warlock\'\r\n";
            DataTable dt = rpr.Query1(query);
            dataGridView.DataContext = dt.DefaultView;
        }

        private void getSQLdata3_Click(object sender, RoutedEventArgs e)
        {
            RPGSQLContext rmc = new RPGSQLContext();
            RPGRepository rpr = new RPGRepository(rmc);
            string query = "SELECT ch.Name, sk.Naam\r\nfrom Character ch\r\njoin Character_Skills chs on chs.CharacterID = ch.CharacterID\r\njoin Skill sk on sk.SkillID = chs.SkillID\r\n";
            DataTable dt = rpr.Query1(query);
            dataGridView.DataContext = dt.DefaultView;
        }

        private void getSQLdata4_Click(object sender, RoutedEventArgs e)
        {
            RPGSQLContext rmc = new RPGSQLContext();
            RPGRepository rpr = new RPGRepository(rmc);
            string query = "SELECT ch.Name, itm.Name as itemname, itm.LevelRequirement, inv.Itemcount as AmmountInInventory\r\nfrom item itm\r\njoin Inventory inv on inv.ItemID = itm.ItemID\r\njoin Character ch on ch.CharacterID = inv.CharacterID\r\norder by ch.Name\r\n";
            DataTable dt = rpr.Query1(query);
            dataGridView.DataContext = dt.DefaultView;
        }

        private void getSQLdata5_Click(object sender, RoutedEventArgs e)
        {
            RPGSQLContext rmc = new RPGSQLContext();
            RPGRepository rpr = new RPGRepository(rmc);
            string query = "SELECT ch.Name, itm.Name as itemname, itm.LevelRequirement, inv.Itemcount as AmmountInInventory\r\nfrom item itm\r\njoin Inventory inv on inv.ItemID = itm.ItemID\r\njoin Character ch on ch.CharacterID = inv.CharacterID\r\nwhere inv.ItemCount > 5\r\norder by AmmountInInventory desc\r\n";
            DataTable dt = rpr.Query1(query);
            dataGridView.DataContext = dt.DefaultView;
        }

        private void getSQLdata6_Click(object sender, RoutedEventArgs e)
        {
            RPGSQLContext rmc = new RPGSQLContext();
            RPGRepository rpr = new RPGRepository(rmc);
            string query = "Select c1.Name, c2.name\r\nfrom Category c1\r\njoin Category c2 on c1.ParentID = c2.categoryid\r\n";
            DataTable dt = rpr.Query1(query);
            dataGridView.DataContext = dt.DefaultView;
        }
    }
}
