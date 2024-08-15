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
using TextEternalReturn.Scenes.Scenes.PlaceScenes;
using TextEternalReturn.Scenes.Scenes.ChestScenes.Chests;
using TextEternalReturn.Scenes.Scenes.PlaceScenes.PlaceScenes;
using TextEternalReturn.Scenes.Scenes.PlaceScenes.PlaceScenes.BonfireScenes;

namespace TextEternalReturn
{
    public class Game
    {
        public static Game game = new Game();

        public Scene[] sceneList = new Scene[(int)SceneType.SIZE];
        public Scene prevScene;
        public Scene curScene { get; set; }
 
        public Player player = new Player();
        public bool battleHyun;
        public bool isWin;
        bool isRunning;
        private Game() { }
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
        public void GameOver()
        {
            isRunning = false;
        }
        private void Start()
        {
            isRunning = true;
            Console.CursorVisible = false;
            sceneList[(int)SceneType.StartScene] = new StartScene(player);
            sceneList[(int)SceneType.MapScene] = new MapScene(player);
            sceneList[(int)SceneType.HotelScene] = new HotelScene(player);
            sceneList[(int)SceneType.AlleyScene] = new AlleyOfficeScene(player);
            sceneList[(int)SceneType.HarborScene] = new HarborScene(player);
            sceneList[(int)SceneType.HospitalScene] = new HospitalScene(player);
            sceneList[(int)SceneType.BonFireScene] = new BonfireScene(player);
            sceneList[(int)SceneType.HotelChest] = new HotelChest(player);
            sceneList[(int)SceneType.AlleyChest] = new AlleyChest(player);
            sceneList[(int)SceneType.HarborChest] = new HarborChest(player);
            sceneList[(int)SceneType.HospitalChest] = new HospitalChest(player);
            sceneList[(int)SceneType.InventoryScene] = new InventoryScene(player);
            sceneList[(int)SceneType.BattleScene] = new BattleScene(player);
            sceneList[(int)SceneType.ChoiceScene] = new ChoiceScene(player);
            sceneList[(int)SceneType.FishingScene] = new FishingScene(player);
            sceneList[(int)SceneType.EndScene] = new EndScene(player);
            
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
        public static Game getInstance()
        {
            return game;
        }
    }
}
