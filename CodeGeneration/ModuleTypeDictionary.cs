using SunSharp.ObjectWrapper;

namespace CodeGeneration
{
    public partial class Data
    {
        public static Dictionary<string, string> GetModuleTypeDictionary()
        {
            var dict = new Dictionary<string, string>();

            foreach (var pair in Enum.GetValues<ModuleType>())
            {
                dict.Add(pair.ToInternalName(), pair.ToString());
            }

            return dict;
        }
    }
}
