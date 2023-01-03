using System.Collections.Generic;
using BigDLL4221.Models;
using BigDLL4221.StageManagers;
using CustomMapUtility;
using Mary_Ib21341.BLL;

namespace Mary_Ib21341
{
    public class EnemyTeamStageManager_Mary_21341 : EnemyTeamStageManager_BaseWithCMUOnly_DLL4221
    {
        public override void OnWaveStart()
        {
            SetParameters(CustomMapHandler.GetCMU(MaryModParameters.PackageId),
                new List<MapModel> { MaryModParameters.MaryMapModel });
            base.OnWaveStart();
        }
    }
}