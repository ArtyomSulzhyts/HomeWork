using Zenject;

public class GameStatsManager: IInitializable
{
   public int CurrentTownId;
   public int CrewAmount;
   public int FoodAmount;
   public int GoodsAmount = 5;
   public int ShipSpace = 20;
   public int Money = 100;
   
   public void Initialize()
   {
      
   }
}
