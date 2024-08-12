using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Scenes;

namespace TextEternalReturn
{
    public class Game
    {
        Scene[] sceneList;
        Scene curScene;
        bool isRunning;
        public Game() 
        {
            sceneList = new Scene[11];
            //sceneList[SceneType.StartScene] = new StartScene(); 
        }
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

        private void Start()
        {

        }
        private void Render()
        {

        }
        private void Input()
        {

        }
        private void Update()
        {

        }
        private void End()
        {

        }
    }
}
