using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace DisplayPlayersTable
{
    public partial class PlayersForm : Form
    {
        private BaseballDatabase.BaseballEntities dbcontext = new BaseballDatabase.BaseballEntities();
        private string playerName;
        public PlayersForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            playerName = playerTextBox.Text;
            playerName = playerName.ToUpper(); 
            var query= dbcontext.Players.Local
                .Where(Player => Player.LastName.ToUpper() == playerName);
            /*
            if(query==null)
            {
                notFoundLabel.Text = "Player not found";
            }
             */
            playerBindingSource.DataSource = query;
            playerBindingSource.MoveFirst();
        }

        private void displayAllButton_Click(object sender, EventArgs e)
        {   
            // load data from database into DataGridView
            dbcontext.Players.Load();
            playerBindingSource.DataSource=dbcontext.Players.Local;
        }

        private void PlayersForm_Load(object sender, EventArgs e)
        {
            // load data from database into DataGridView
            dbcontext.Players.Load();
            playerBindingSource.DataSource = dbcontext.Players.Local;
        }
    }
}
