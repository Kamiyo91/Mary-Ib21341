using System.Collections.Generic;
using BigDLL4221.Models;

namespace Mary_Ib21341.BLL
{
    public static class MaryModParameters
    {
        public const string PackageId = "MaryIb21341.Mod";
        public const string KamiyoModPackPackageId = "LorModPackRe21341.Mod";
        public const string VortexTowerPackageId = "VortexTowerModSa21341.Mod";
        public static string Path;

        public static MapModel MaryMapModel = new MapModel(typeof(Mary_21341MapManager),
            "Mary_21341", bgy: 0.55f, originalMapStageIds: new List<LorId> { new LorId(PackageId, 1) });

        public static UnitModel PaintingNpcModel = new UnitModel(2, PackageId, 2, lockedEmotion: true,
            customPos: new XmlVector2 { x = 20, y = 0 });

        public static UnitModel PaintingPlayerModel = new UnitModel(10000002, PackageId, 2, lockedEmotion: true,
            customPos: new XmlVector2 { x = 20, y = 0 });

        public static UnitModel MaryNpcModel = new UnitModel(1, PackageId, 1);
        public static UnitModel MaryPlayerModel = new UnitModel(10000001, PackageId, 1);
    }
}