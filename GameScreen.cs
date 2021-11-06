using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Takunda Marowa 20123325
namespace GADE_TASK_2
{
    public partial class GameScreen : Form
    {
        GameEngine gameEngine = new GameEngine();
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            mapLabel.Text = gameEngine.ToString();
            statsLabel.Text = gameEngine.GameMap.hero.ToString();

            FillEnemiesList();
        }
        private void UpdateForm()
        {
            enemiesDropList.Items.Clear();
            FillEnemiesList();
            mapLabel.Text = gameEngine.ToString();
            statsLabel.Text = gameEngine.GameMap.hero.ToString();

            
        }

        /// <summary>
        /// Allows the Enemies to be shown in the dropdown
        /// </summary>
        private void FillEnemiesList()
        {
            for (int i = 0; i < gameEngine.GameMap.enemiesArray.Length; i++)
            {
                if (!gameEngine.GameMap.enemiesArray[i].IsDead()) //Allows it to only show options of goblins NOT DEAD.
                {
                    enemiesDropList.Items.Add(gameEngine.GameMap.enemiesArray[i].ToString());

                }
            }
            
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Only activates if object selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttackButton_Click(object sender, EventArgs e)
        {
            gameEngine.GameMap.hero.Attack(gameEngine.GameMap.enemiesArray[enemiesDropList.SelectedIndex]);
            logBox.Text += "\n"+ gameEngine.GameMap.enemiesArray[enemiesDropList.SelectedIndex].ToString();
            gameEngine.UpdateEngine();
            UpdateForm();

            AttackButton.Enabled = false;





        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            //gameEngine.Update();
            if (gameEngine.MovePlayer(Character.MovementEnum.Up))
            {
                
                gameEngine.UpdateEngine();
                gameEngine.MoveEnemies();
                mapLabel.Text = gameEngine.ToString();
                statsLabel.Text = gameEngine.GameMap.hero.ToString();
            }
            
            
            

        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            //gameEngine.Update();
            if (gameEngine.MovePlayer(Character.MovementEnum.Right))
            {
                gameEngine.UpdateEngine();
                gameEngine.MoveEnemies();
                mapLabel.Text = gameEngine.ToString();
                statsLabel.Text = gameEngine.GameMap.hero.ToString();
            }
            
            

            

        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            //gameEngine.Update();
            if (gameEngine.MovePlayer(Character.MovementEnum.Down))
            {
                gameEngine.UpdateEngine();
                gameEngine.MoveEnemies();
                mapLabel.Text = gameEngine.ToString();
                statsLabel.Text = gameEngine.GameMap.hero.ToString();
            }
            
            

        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            //gameEngine.Update();
            if (gameEngine.MovePlayer(Character.MovementEnum.Left))
            {
                gameEngine.UpdateEngine();
                gameEngine.MoveEnemies();
                mapLabel.Text = gameEngine.ToString();
                statsLabel.Text = gameEngine.GameMap.hero.ToString();
            }
            
            

        }

        /// <summary>
        /// Used to make sure an enemy is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enemiesDropList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AttackButton.Enabled=true;
        }
    }
}
