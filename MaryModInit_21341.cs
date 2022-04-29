using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiyoStaticUtil.Utils;
using Mary_Ib21341.BLL;

namespace Mary_Ib21341
{
    public class MaryModInit_21341 : ModInitializer
    {
        public override void OnInitializeMod()
        {
            InitParameters();
            MapStaticUtil.GetArtWorks(new DirectoryInfo(MaryModParameters.Path + "/ArtWork"));
            UnitUtil.ChangeCardItem(ItemXmlDataList.instance, MaryModParameters.PackageId);
            UnitUtil.ChangePassiveItem(MaryModParameters.PackageId);
            SkinUtil.LoadBookSkinsExtra(MaryModParameters.PackageId);
            LocalizeUtil.AddLocalLocalize(MaryModParameters.Path, MaryModParameters.PackageId);
            SkinUtil.PreLoadBufIcons();
            LocalizeUtil.RemoveError();
        }

        private static void InitParameters()
        {

        }
    }
}
