using PanGu.Framework;

namespace PanGu.Setting
{
    class SettingLoader
    {
        private void Load(string fileName)
        {
            PanGuSettings.Load(fileName);
        }

        public SettingLoader(string fileName)
        {
            Load(fileName);
        }

        public SettingLoader()
        {
            string fileName = Path.GetAssemblyPath() + "PanGu.xml";
            Load(fileName);
        }
    }
}
