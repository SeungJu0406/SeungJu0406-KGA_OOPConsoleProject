namespace TextEternalReturn
{
    public enum SceneType
    {
        StartScene, 
        MapScene, HotelScene, AlleyOfficeScene, HarborScene, HospitalScene, BonFireScene,
        InventoryScene, BattleScene, ChoiceScene, FishingScene,
        HotelChest, AlleyChest, HarborChest, HospitalChest,
        EndScene, SIZE
    }
    public enum PlaceType
    {
        Hotel, PoliceOffice, Harbor, Hospital, BonFire, SIZE
    }
    public enum MonsterType
    {
        Chicken, WildBoar, Wolf, Bear, Hyunwoo, SIZE
    }
    public enum FoodType
    {
        SalmonSteak, FishCuttlet, Steak, Salmon, CodFish, Meat
    }
    public enum ItemType
    {
        Bandage, Scrap, Shirt, ShortRod, // 필요한 것
        Axe, Chain, Cloth, Oil, Paper, Rubber, Sisser, // 필요하지 않은 것
        SIZE 
    }
}
