using System.Collections.Generic;
using UtilLoader21341.Models;

namespace Mary_Ib21341.BLL
{
    public static class MaryModParameters
    {
        public const string PackageId = "MaryIb21341.Mod";
        public const string KamiyoModPackPackageId = "LorModPackRe21341.Mod";
        public const string VortexTowerPackageId = "VortexTowerModSa21341.Mod";
        public static string Path;

        public static MapModelRoot MaryMapModel = new MapModelRoot
        {
            Component = nameof(Mary_21341MapManager),
            Stage = "Mary_21341",
            Bgy = 0.55f,
            OriginalMapStageIds = new List<LorIdRoot> { new LorIdRoot { PackageId = PackageId, Id = 1 } }
        };

        public static UnitModelRoot PaintingNpcModel = new UnitModelRoot
        {
            PackageId = PackageId, Id = 2, UnitNameId = 2, LockedEmotion = true,
            CustomPos = new XmlVector2 { x = 20, y = 0 }
        };

        public static UnitModelRoot PaintingPlayerModel = new UnitModelRoot
        {
            PackageId = PackageId, Id = 10000002, UnitNameId = 2, LockedEmotion = true,
            CustomPos = new XmlVector2 { x = 20, y = 0 }
        };

        public static UnitModelRoot MaryNpcModel = new UnitModelRoot { PackageId = PackageId, Id = 1, UnitNameId = 1 };

        public static UnitModelRoot MaryPlayerModel = new UnitModelRoot
            { PackageId = PackageId, Id = 10000001, UnitNameId = 1 };
    }
}