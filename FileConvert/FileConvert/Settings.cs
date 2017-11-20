using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert
{
    public class Settings
    {
        public string InputFormat { get; set; }
        public string OutputFormat { get; set; }
        public string WorkingFolder { get; set; }
        public bool UseWorkingFolder { get; set; }
        public string OutputFolder { get; set; }

        /// <summary>
        /// Initialise the application default settings
        /// </summary>
        public Settings()
        {

        }

        /// <summary>
        /// Init the app with the user saved settings
        /// </summary>
        /// <param name="useUserSettings">true to use the settings, false to use the program arguments</param>
        /// <param name="args">Launch arguments</param>
        public Settings(bool useUserSettings, string[] args)
        {

        }
    }
}
