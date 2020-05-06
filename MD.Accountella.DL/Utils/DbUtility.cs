using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MD.Accountella.DL.Helper
{
    internal static class DbUtility
    {
        public static string FormatSeedDataId(string id)
        {
            return $"{id}_sys";
        }
    }
}
