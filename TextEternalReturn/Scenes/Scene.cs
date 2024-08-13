using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes
{
    public abstract class Scene
    {
        protected Game game;
        protected Scene curScene;
        protected ConsoleKey consoleKey;
        protected Player player;
        protected Scene(Game game, Player player) 
        {
            this.game = game;
            this.player = player;
            curScene = game.curScene;
        }
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Enter();
        public abstract void Exit();
    }
}
