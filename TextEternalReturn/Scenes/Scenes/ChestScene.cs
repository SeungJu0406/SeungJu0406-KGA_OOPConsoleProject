﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class ChestScene : Scene 
    {
        public ChestScene(Player player) : base(player)
        {

        }
        public override void Render()
        {
            
        }
        public override void Input()
        {
            
        }
        public override void Update()
        {

        }
        public override void Enter()
        {

        }
        public override void Exit()
        {
            game.prevScene = this;
        }
    }
}
