using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Star_Simulation
{
    internal class Export
    {
        public interface IExport
        {
            
        }

        public class ExportJSON<T> where T : IExport
        {
            public string Name { get; private set; }
            public List<T> ExportList { get; set; }

            public string ExportJSONString { get; private set; } = "";

            public ExportJSON(string name, List<T> list = null!)
            {
                if (list == null) list = [];

                Name = name;
                ExportList = list;
            }

            public string BuildList()
            {
                ExportJSONString = JsonSerializer.Serialize(ExportList);
                return ExportJSONString;
            }

            public void WriteJSON(string file = "")
            {
                if (string.IsNullOrEmpty(file)) file = Name + ".json";

                File.WriteAllText(file, BuildList());
            }
        }
    }
}
