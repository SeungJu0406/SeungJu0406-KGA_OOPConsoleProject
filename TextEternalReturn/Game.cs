using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEternalReturn
{
    public class Game
    {
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
