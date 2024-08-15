using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes.PlaceScenes.PlaceScenes
{
    internal class HospitalScene : PlaceScene
    {

        public HospitalScene(Player player) : base(player)
        {
            SceneID = (int)SceneType.HospitalScene;
        }
        public override void Render()
        {
            base.Render();
            PrintHospital();
        }
        public override void Update()
        {
            base.Update();
        }
       
        private void PrintHospital()
        {
            SetCursor(points[(int)Pos.Place]);
            Console.WriteLine(" 병 원 ");
            SetCursor(points[(int)Pos.Chest]);
            Console.WriteLine("▷ 상자 열기");
            SetCursor(points[(int)Pos.Rest]);
            Console.WriteLine("▷ 휴식");
            SetCursor(points[(int)Pos.MoveMap]);
            Console.WriteLine("▷ 이동 하기");
            SetCursor(points[(int)Pos.Inventory]);
            Console.WriteLine("▷ 아이템 확인");
            SetCursor(curPoint);
            Console.WriteLine("▶");
        }
        protected override void PushKeyZ()
        {
            if (curPoint.y == points[(int)Pos.Chest].y)
            {
                game.ChangeScene(SceneType.HospitalChest);
            }
            else if (curPoint.y == points[(int)Pos.Rest].y)
            {
                player.Rest();
            }
            else if (curPoint.y == points[(int)Pos.MoveMap].y)
            {
                game.ChangeScene(SceneType.MapScene);
            }
            else if (curPoint.y == points[(int)Pos.Inventory].y)
            {
                game.ChangeScene(SceneType.InventoryScene);
            }
        }       
    }
}
