using BigDLL4221.Utils;

namespace Mary_Ib21341
{
    public class EnemyTeamStageManager_Mary_21341 : EnemyTeamStageManager
    {
        public override void OnWaveStart()
        {
            CustomMapHandler.InitCustomMap<Mary_21341MapManager>("Mary_21341", false, true, 0.5f, 0.55f);
            CustomMapHandler.EnforceMap();
            Singleton<StageController>.Instance.CheckMapChange();
        }

        public override void OnRoundStart()
        {
            CustomMapHandler.EnforceMap();
        }
    }
}