using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEternalReturn.Scenes
{
    public abstract class Scene
    {
        protected Game game;
        protected Scene curScene;
        protected Scene(Game game) 
        {
            this.game = game;
            curScene = game.curScene;
        }
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Enter();
        public abstract void Exit();
    }
}
