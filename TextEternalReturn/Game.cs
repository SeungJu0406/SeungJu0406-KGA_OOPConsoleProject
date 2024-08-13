using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Scenes;
using TextEternalReturn.Scenes.Scenes;
using TextEternalReturn.Players;
using TextEternalReturn.Items.Foods;

namespace TextEternalReturn
{
    public class Game
    {
        public Scene[] sceneList = new Scene[12];
        public Scene curScene {  get; set; }
        public Player player = new Player();
        bool isRunning;
       
        public void Run()
        {
            Start();
            while (isRunning)
            {
                Render();
                Input();
                Update();
            }
            End();
        }
        public void ChangeScene(SceneType sceneType)
        {
            curScene.Exit();
            curScene = sceneList[(int)sceneType];
            curScene.Enter();
        }
        private void Start()
        {
            isRunning = true;
            Console.CursorVisible = false;
            sceneList[(int)SceneType.StartScene] = new StartScene(this,player);
            sceneList[(int)SceneType.MapScene] = new MapScene(this, player);
            sceneList[(int)SceneType.HotelScene] = new HotelScene(this, player);
            sceneList[(int)SceneType.PoliceOfficeScene] = new PoliceOfficeScene(this, player);
            sceneList[(int)SceneType.HarborScene] = new HarborScene(this, player);
            sceneList[(int)SceneType.HospitalScene] = new HospitalScene(this, player);
            sceneList[(int)SceneType.BonFireScene] = new BonfireScene(this, player);
            sceneList[(int)SceneType.StatusScene] = new StatusScene(this, player);
            sceneList[(int)SceneType.InventoryScene] = new InventoryScene(this, player);
            sceneList[(int)SceneType.BattleScene] = new BattleScene(this, player);
            sceneList[(int)SceneType.ChoiceScene] = new ChoiceScene(this, player);
            sceneList[(int)SceneType.EndScene] = new EndScene(this, player);
            
            curScene = sceneList[(int)SceneType.StartScene];
        }
        private void Render()
        {
            curScene.Render();
        }
        private void Input()
        {
            curScene.Input();
        }
        private void Update()
        {
            curScene.Update();
        }
        private void End()
        {
            
        }
    }
}
