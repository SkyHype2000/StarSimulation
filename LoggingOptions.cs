using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Simulation
{
    internal class LoggingOptions
    {
        /// <summary>Activates the Logging of Some Generation-Values (This is the Main Switch, if you turn this of => No Logging.)</summary>
        public static bool Logging = true;
        /// <summary>Activates the Logging of Star-Generation</summary>
        public static bool StarLogging = true;
        /// <summary>Activates the Logging of Planet-Generation</summary>
        public static bool PlanetLogging = true;
        /// <summary>Activates the Logging of Proto Planet-Generation (There can be Many Proto Planets)</summary>
        public static bool ProtoPlanetLogging = false;
        /// <summary>Activates the Logging of Dwarf Planet-Generation (There can be Many Dwarf Planets, so deactivating this can be useful)</summary>
        public static bool DwarfPlanetLogging = false;
        /// <summary>Activates the Logging of Planet-Generation Test of avoiding SOI Collision of the Planet(or Dwarf Planet) with a Asteroid Belt (There can be Many Tests, so Deactivating may Help to keep the Console Readable)</summary>
        public static bool PlanetAsteroidBeltIterationLogging = false;
        /// <summary>Activates the Logging of Astroid-Generation (Not Recommendet if you still wan't to see whats happening in the COnsole)</summary>
        public static bool AstroidLogging = false;
        /// <summary>Activates the Logging of Astroid-Belt-Generation</summary>
        public static bool AstroidBeltLogging = true;

        public static bool LoggingFile = true;
        /// <summary>General Logging File</summary>
        public static string LogFileName = $"{DateTime.Now.ToString("dd_MM_yyyy HH;mm;ss").Replace(";", "")}.log";
        public static string LogFolderName = $"log";

        public static bool ObjectGenerationLogging = true;
        /// <summary>Logging File for Generation of Object Type, Name and General Data in a Single Line</summary>
        public static string ObjectGenerationLogFileName = $"{DateTime.Now.ToString("dd_MM_yyyy HH;mm;ss").Replace(";", "")}-GEN.log";
        public static string ObjectGenerationLogFolderName = $"log/objectGeneration";

        public static bool ObjectGenerationPlacingTrysLoggingFile = true;
        public static bool ObjectGenerationStarLoggingFile = true;
        public static bool ObjectGenerationPlanetLoggingFile = true;
        public static bool ObjectGenerationProtoPlanetLoggingFile = false;
        public static bool ObjectGenerationDwarfPlanetLoggingFile = false;
        public static bool ObjectGenerationAsteroidLoggingFile = false;
        public static bool ObjectGenerationAsteroidBeltLoggingFile = true;
        public static bool ObjectGenerationPlanetAsteroidBeltIterationLoggingFile = false;
        public static bool ObjectGenerationNameLoggingFile = false;

        /// <summary>Logging File of the Name Generation</summary>
        public static string NameGenerationLogFileName = $"{DateTime.Now.ToString("dd_MM_yyyy HH;mm;ss").Replace(";", "")}-NAMEGEN.log";
        public static string NameGenerationLogFolderName = $"log/nameGeneration";

        public static bool LoggingFile_JSON = true;
        public static string LoggingFile_JSON_Folder = "log/objectGeneration/stellarSystem";
        public static bool StarLoggingFile_JSON = true;
        public static string StarLoggingFile_JSON_Folder = "log/objectGeneration/stellarSystem/star";
        public static bool PlanetLoggingFile_JSON = false;
        public static string PlanetLoggingFile_JSON_Folder = "log/objectGeneration/stellarSystem/planet";
        public static bool ProtoPlanetLoggingFile_JSON = false;
        public static string ProtoPlanetLoggingFile_JSON_Folder = "log/objectGeneration/stellarSystem/protoPlanet";
        public static bool DwarfPlanetLoggingFile_JSON = false;
        public static string DwarfPlanetLoggingFile_JSON_Folder = "log/objectGeneration/stellarSystem/dwarfPlanet";
        public static bool AsteroidLoggingFile_JSON = false;
        public static string AsteroidLoggingFile_JSON_Folder = "log/objectGeneration/stellarSystem/asteroid";
        public static bool AsteroidBeltLoggingFile_JSON = false;
        public static string AsteroidBeltLoggingFile_JSON_Folder = "log/objectGeneration/stellarSystem/asteroidField";

        /// <summary>
        /// Ignores All File-Logging Settings and Forces File Logging.<br/>
        /// This will Of course make the log-file Large af.
        /// </summary>
        public static bool ForceLoggingFile = false;

        /// <summary>
        /// Loggs The Generation of RawResources.<br/>
        /// Be Careful: This can make the Console Output Very Very Very Big (It will only log if Logging is True)
        /// </summary>
        public static bool ResourceGeneration_Logging = false;
        public static bool ResourceGeneration_StarLogging = false;
        public static bool ResourceGeneration_ProtoPlanetLogging = false;
        public static bool ResourceGeneration_DwarfPlanetLogging = false;
        public static bool ResourceGeneration_PlanetLogging = false;
        public static bool ResourceGeneration_AsteroidBeltLogging = false;
        public static bool ResourceGeneration_AsteroidLogging = false;
        public static bool ResourceGeneration_BuildResourceLogging = false;
        public static bool ResourceGeneration_ResourceListLogging = false;
        /// <summary>
        /// Loggs The Generation of RawResources into the Log-File.<br/>
        /// Be Careful: This can make the Log File Very Large.
        /// </summary>
        public static bool ResourceGeneration_LoggingFile = false;
        public static bool ResourceGeneration_StarLoggingFile = false;
        public static bool ResourceGeneration_ProtoPlanetLoggingFile = true;
        public static bool ResourceGeneration_DwarfPlanetLoggingFile = false;
        public static bool ResourceGeneration_PlanetLoggingFile = true;
        public static bool ResourceGeneration_AsteroidBeltLoggingFile = true;
        public static bool ResourceGeneration_AsteroidLoggingFile = false;
        public static bool ResourceGeneration_BuildResourceLoggingFile = true;
        public static bool ResourceGeneration_ResourceListLoggingFile = true;
    }
}
