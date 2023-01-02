using CustomMapUtility;
using UnityEngine;

namespace Mary_Ib21341
{
    public class Mary_21341MapManager : CustomMapManager
    {
        protected override string[] CustomBGMs => new[] { "MaryTheme21341.ogg" };

        public override void EnableMap(bool b)
        {
            sephirahColor = Color.black;
            base.EnableMap(b);
        }
    }
}