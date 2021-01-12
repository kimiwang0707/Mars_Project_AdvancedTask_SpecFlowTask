using SpecflowPages.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowPages
{
    public class ConstantUtils
    {

        #region To access Path from resource file

        public static string Url = MarsResource.Url;
        public static string TestDataPath = MarsResource.TestDataPath;
        public static string ScreenShotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string ReportXMLPath = MarsResource.ReportXMLPath;

        public static string ShareSkillPath = MarsResource.ShareSkillPath;
        public static string ManageListingPath = MarsResource.ManageListingPath;

        #endregion

    }
}
