﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.Utils;
using Mary_Ib21341.BLL;
using MonoMod.Utils;

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
            ModParameters.PackageIds.Add(MaryModParameters.PackageId);
            MaryModParameters.Path =
                Path.GetDirectoryName(
                    Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(MaryModParameters.Path);
            ModParameters.Language = GlobalGameManager.Instance.CurrentOption.language;
            ModParameters.SpritePreviewChange.AddRange(new Dictionary<string, List<LorId>>
            {
                { "MaryDefault_21341", new List<LorId> { new LorId(MaryModParameters.PackageId, 10000001) } }
            });
            ModParameters.BooksIds.AddRange(new List<LorId>
            {
                new LorId(MaryModParameters.PackageId, 10000001)
            });
            ModParameters.OnlyCardKeywords.AddRange(new List<Tuple<List<string>, List<LorId>, LorId>>
            {
                new Tuple<List<string>, List<LorId>, LorId>(new List<string> { "MaryPage_Sa21341" },
                    new List<LorId> { new LorId(MaryModParameters.PackageId, 1) },
                    new LorId(MaryModParameters.PackageId, 10000001))
            });
            ModParameters.UntransferablePassives.AddRange(new List<LorId>
            {
                new LorId(MaryModParameters.PackageId, 4), new LorId(MaryModParameters.PackageId, 5)
            });
            ModParameters.PersonalCardList.AddRange(new List<LorId>
            {
                new LorId(MaryModParameters.PackageId, 2)
            });
            //ModParameters.EgoPersonalCardList.AddRange(new List<LorId>
            //{
            //    new LorId(MaryModParameters.PackageId, 9)
            //});
            ModParameters.DynamicNames.AddRange(new Dictionary<LorId, LorId>
            {
                { new LorId(MaryModParameters.PackageId, 10000001), new LorId(MaryModParameters.PackageId, 1) }
            });
            ModParameters.ExtraConditionPassives.AddRange(new List<Tuple<LorId, LorId>>
            {
                new Tuple<LorId, LorId>(new LorId(230008), new LorId(MaryModParameters.PackageId, 3)),
                new Tuple<LorId, LorId>(new LorId(MaryModParameters.PackageId, 3), new LorId(230008))
            });
            ModParameters.DefaultKeyword.Add(MaryModParameters.PackageId, "MaryModPage_Sa21341");
            ModParameters.BookList.AddRange(new List<LorId>
            {
                new LorId(MaryModParameters.PackageId, 2)
            });
        }
    }
}