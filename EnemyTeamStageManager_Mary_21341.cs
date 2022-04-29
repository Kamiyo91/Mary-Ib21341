using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMapUtility;

namespace Mary_Ib21341
{
    public class EnemyTeamStageManager_Mary_21341 : EnemyTeamStageManager
    {
        public override void OnWaveStart()
        {
            CustomMapHandler.InitCustomMap<Mary_21341MapManager>("Mary_Re21341", false, true, 0.5f, 0.2f);
            CustomMapHandler.EnforceMap();
            Singleton<StageController>.Instance.CheckMapChange();
        }
        public override void OnRoundStart()
        {
            CustomMapHandler.EnforceMap();
        }
    }
}
