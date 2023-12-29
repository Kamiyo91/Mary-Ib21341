using System;
using System.IO;
using System.Reflection;
using Mary_Ib21341.BLL;

namespace Mary_Ib21341
{
    public class MaryModInit_21341 : ModInitializer
    {
        public override void OnInitializeMod()
        {
            MaryModParameters.Path = Path.GetDirectoryName(
                Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
        }
    }
}