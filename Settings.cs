using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ZKTQavi
{
    [Serializable()]
    public class Settings
    {
        public string Devices { get; set; }
        public int SyncDeviceInterval { get; set; }
        public bool AutoStart { get; set; }
        public bool minimizeToTray { get; set; }
        public string DBServer { get; set; }
        public string DBUsername { get; set; }
        public string DBPassword { get; set; }
        public string DBName { get; set; }

        internal static string ConfigDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ZKTQavi";
        public static Settings CurrentSettings = new Settings();

        public Settings()
        {
            
            if (!Directory.Exists(ConfigDirectory))
                Directory.CreateDirectory(ConfigDirectory);

            SyncDeviceInterval = 30;
            Devices = "";
        }
        //-------------------------------------//
        public static void LoadSettings()
        {
            try
            {
                //MessageBox.Show(Temp);
                

                if (File.Exists(ConfigDirectory + "\\config.bin"))
                {
                    // load settings
                    BinaryFormatter DeSerializer = new BinaryFormatter();
                    Stream TestFileStream = File.OpenRead(ConfigDirectory + "\\config.bin");
                    CurrentSettings = (Settings)DeSerializer.Deserialize(TestFileStream);
                    TestFileStream.Close();
                }
            }
            catch (Exception)
            {
            }
        }
        //-------------------------------------//
        public static void SaveSettings()
        {
            if (!Directory.Exists(ConfigDirectory))
                Directory.CreateDirectory(ConfigDirectory);

            Stream TestFileStream = File.Create(ConfigDirectory + "\\config.bin");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(TestFileStream, CurrentSettings);
            TestFileStream.Close();
        }
    }
}
