using System.Collections.Generic;
using CustomColorUtil.Models;
using Mary_Ib21341.BLL;

namespace Mary_Ib21341
{
    public static class CustomColorLoader21341
    {
        public static List<KeypageOptionRoot> KeypageOptionRoot()
        {
            return new List<KeypageOptionRoot>
            {
                new KeypageOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, Ids = new List<int> { 10000001, 1, 4 },
                    KeypageColorOptions = new ColorOptionsRoot
                    {
                        FrameColor = new ColorRoot { R = 0, G = 127, B = 255, A = 255 },
                        TextColor = new ColorRoot { R = 0, G = 127, B = 255, A = 255 }
                    }
                }
            };
        }

        public static List<PassiveOptionRoot> PassiveOptionRoot()
        {
            return new List<PassiveOptionRoot>
            {
                new PassiveOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, Ids = new List<int> { 4, 5 },
                    PassiveColorOptions = new ColorOptionsRoot
                    {
                        FrameColor = new ColorRoot { R = 0, G = 127, B = 255, A = 255 },
                        TextColor = new ColorRoot { R = 0, G = 127, B = 255, A = 255 }
                    }
                }
            };
        }

        public static List<DropBookOptionRoot> DropBookOptionRoot()
        {
            return new List<DropBookOptionRoot>
            {
                new DropBookOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, Ids = new List<int> { 1 }, DropBookColorOptions =
                        new ColorOptionsRoot
                        {
                            FrameColor = new ColorRoot { R = 0, G = 127, B = 255, A = 255 },
                            TextColor = new ColorRoot { R = 0, G = 127, B = 255, A = 255 }
                        }
                }
            };
        }

        public static List<StageOptionRoot> StageOptionRoot()
        {
            return new List<StageOptionRoot>
            {
                new StageOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, Ids = new List<int> { 1 }, StageColorOptions =
                        new ColorOptionsRoot
                        {
                            FrameColor = new ColorRoot { R = 0, G = 127, B = 255, A = 255 },
                            TextColor = new ColorRoot { R = 0, G = 127, B = 255, A = 255 }
                        }
                }
            };
        }

        public static List<CategoryOptionRoot> CategoryOptionRoot()
        {
            return new List<CategoryOptionRoot>
            {
                new CategoryOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, AdditionalValue = "_1",
                    BookDataColor = new ColorOptionsRoot
                    {
                        FrameColor = new ColorRoot { R = 0, G = 127, B = 255, A = 255 },
                        TextColor = new ColorRoot { R = 0, G = 127, B = 255, A = 255 }
                    }
                }
            };
        }

        public static List<CardOptionRoot> CardOptionRoot()
        {
            return new List<CardOptionRoot>
            {
                new CardOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, Ids = new List<int> { 1, 2, 3, 4, 5, 6 },
                    CardColorOptions = new CardColorOptionRoot
                    {
                        CardColor = new ColorRoot { R = 0, G = 127, B = 255, A = 255 },
                        CustomIconColor = new ColorRoot { R = 0, G = 127, B = 255, A = 255 }, UseHSVFilter = false,
                        LeftFrame = "MaryLeftPage_21341",
                        RightFrame = "MaryRightPage_21341",
                        FrontFrame = "MaryUIBattlePage_Cover_21341"
                    }
                }
            };
        }
    }
}