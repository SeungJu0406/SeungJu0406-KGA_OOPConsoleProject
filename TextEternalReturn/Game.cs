using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Scenes;
using TextEternalReturn.Scenes.Scenes;

namespace TextEternalReturn
{
    public class Game
    {
        public Scene[] sceneList = new Scene[12];
        public Scene curScene {  get; set; }
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

            sceneList[(int)SceneType.StartScene] = new StartScene(this);
            sceneList[(int)SceneType.MapScene] = new MapScene();
            sceneList[(int)SceneType.HotelScene] = new HotelScene();
            sceneList[(int)SceneType.PoliceOfficeScene] = new PoliceOfficeScene();
            sceneList[(int)SceneType.HarborScene] = new HarborScene();
            sceneList[(int)SceneType.HospitalScene] = new HospitalScene();
            sceneList[(int)SceneType.BonFireScene] = new BonfireScene();
            sceneList[(int)SceneType.StatusScene] = new StatusScene();
            sceneList[(int)SceneType.InventoryScene] = new InventoryScene();
            sceneList[(int)SceneType.BattleScene] = new BattleScene();
            sceneList[(int)SceneType.ChoiceScene] = new ChoiceScene();
            sceneList[(int)SceneType.EndScene] = new EndScene();
            
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
