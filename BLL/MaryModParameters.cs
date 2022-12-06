using BigDLL4221.Models;
using UnityEngine;

namespace Mary_Ib21341.BLL
{
    public static class MaryModParameters
    {
        public const string PackageId = "MaryIb21341.Mod";
        public const string KamiyoModPackPackageId = "LorModPackRe21341.Mod";
        public const string VortexTowerPackageId = "VortexTowerModSa21341.Mod";
        public static string Path;

        public static UnitModel PaintingNpcModel = new UnitModel(2, PackageId, 2, lockedEmotion: true,
            customPos: new XmlVector2 { x = 20, y = 0 });

        public static UnitModel PaintingPlayerModel = new UnitModel(10000002, PackageId, 2, lockedEmotion: true,
            customPos: new XmlVector2 { x = 20, y = 0 });

        public static UnitModel MaryNpcModel = new UnitModel(1, PackageId, 1);
        public static UnitModel MaryPlayerModel = new UnitModel(10000001, PackageId, 1);
        public static Color Green = new Color(0f, 0.6f, 0f);
        public static Color Blue = new Color(0, 0.5f, 1f);
    }
}