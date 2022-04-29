﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMapUtility;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.Utils;

namespace Mary_Ib21341.Util
{
    public static class MapUtil
    {
        #pragma warning disable 0618
        public static void ChangeMap(MapModel model, Faction faction = Faction.Player)
        {
            if (MapStaticUtil.CheckStageMap(model.StageIds) || SingletonBehavior<BattleSceneRoot>
                    .Instance.currentMapObject.isEgo ||
                Singleton<StageController>.Instance.GetStageModel().ClassInfo.stageType == StageType.Creature) return;
            CustomMapHandler.InitCustomMap(model.Stage, model.Component, model.IsPlayer, model.InitBgm, model.Bgx,
                model.Bgy, model.Fx, model.Fy);
            if (model.IsPlayer && !model.OneTurnEgo)
            {
                CustomMapHandler.ChangeToCustomEgoMapByAssimilation(model.Stage, faction);
                return;
            }

            CustomMapHandler.ChangeToCustomEgoMap(model.Stage, faction);
            MapStaticUtil.MapChangedValue(true);
        }

        public static void ReturnFromEgoMap(string mapName, List<LorId> ids, bool isAssimilationMap = false)
        {
            if (MapStaticUtil.CheckStageMap(ids) ||
                Singleton<StageController>.Instance.GetStageModel().ClassInfo.stageType ==
                StageType.Creature) return;
            CustomMapHandler.RemoveCustomEgoMapByAssimilation(mapName);
            MapStaticUtil.RemoveValueInAddedMap(mapName);
            if (!isAssimilationMap) return;
            MapStaticUtil.MapChangedValue(true);
            if (!string.IsNullOrEmpty(Singleton<StageController>.Instance.GetStageModel().GetCurrentMapInfo()))
                CustomMapHandler.EnforceTheme();
            Singleton<StageController>.Instance.CheckMapChange();
            SingletonBehavior<BattleSoundManager>.Instance.SetEnemyTheme(SingletonBehavior<BattleSceneRoot>
                .Instance.currentMapObject.mapBgm);
            SingletonBehavior<BattleSoundManager>.Instance.CheckTheme();
        }
    }
}
