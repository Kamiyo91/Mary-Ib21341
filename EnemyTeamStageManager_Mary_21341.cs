using CustomMapUtility;
using Mary_Ib21341.BLL;

namespace Mary_Ib21341
{
    public class EnemyTeamStageManager_Mary_21341 : EnemyTeamStageManager
    {
        private readonly CustomMapHandler _cmh = CustomMapHandler.GetCMU(MaryModParameters.PackageId);

        public override void OnWaveStart()
        {
            _cmh.InitCustomMap<Mary_21341MapManager>("Mary_21341", false, true, 0.5f, 0.55f);
            _cmh.EnforceMap();
            Singleton<StageController>.Instance.CheckMapChange();
        }

        public override void OnRoundStart()
        {
            _cmh.EnforceMap();
        }
    }
}