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
            sceneList[(int)SceneType.MapScene] = new MapScene(this);
            sceneList[(int)SceneType.HotelScene] = new HotelScene(this);
            sceneList[(int)SceneType.PoliceOfficeScene] = new PoliceOfficeScene(this);
            sceneList[(int)SceneType.HarborScene] = new HarborScene(this);
            sceneList[(int)SceneType.HospitalScene] = new HospitalScene(this);
            sceneList[(int)SceneType.BonFireScene] = new BonfireScene(this);
            sceneList[(int)SceneType.StatusScene] = new StatusScene(this);
            sceneList[(int)SceneType.InventoryScene] = new InventoryScene(this);
            sceneList[(int)SceneType.BattleScene] = new BattleScene(this);
            sceneList[(int)SceneType.ChoiceScene] = new ChoiceScene(this);
            sceneList[(int)SceneType.EndScene] = new EndScene(this);
            
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
