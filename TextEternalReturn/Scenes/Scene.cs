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
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Enter();
        public abstract void Exit();
    }
}
