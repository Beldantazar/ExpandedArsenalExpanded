using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MechTemplateGen
{
    internal class UtilityDataBuilder
    {
        static ItemMapping itemMapping;
        public static ItemMapping buildItemMappingData()
        {
            List<string> ignoreFiles = ["global.json", "lancedef_mech_dynamic_common.json", "milestone_010_skipPrologue.json", "pilot_fp_BH_Reaper.json", "pilot_fp_BW_LynnSheridan.json", "SimGameConstants.json", "CompanyTags.json"];
            try
            {
                itemMapping = JsonConvert.DeserializeObject<ItemMapping>(File.ReadAllText("itemmapping.json"));
            }
            catch (Exception e)
            {
                itemMapping = new ItemMapping()
                {
                    entries = []
                };
                Console.WriteLine("Generating Item Mapping File");
                foreach (var file in Directory.EnumerateFiles("..\\..\\BattleTech_Data\\StreamingAssets\\data", "*.json", SearchOption.AllDirectories))
                {
                    if (ignoreFiles.Contains(Path.GetFileName(file))) continue;
                    JToken jsonData;
                    try
                    {
                        jsonData = JToken.Parse(File.ReadAllText(file), new JsonLoadSettings());
                    }
                    catch (Exception f)
                    {
                        Console.WriteLine(f.Message);
                        continue;
                    }
                    if (jsonData is JObject && jsonData["ComponentType"] != null)
                    {
                        itemMapping.entries[jsonData["Description"]["Id"].ToString()] = new ItemMappingEntry { itemId = jsonData["Description"]["Id"].ToString(), itemType = jsonData["ComponentType"].ToString() };
                    }
                }
                foreach (var file in Directory.EnumerateFiles("..\\", "*.json", SearchOption.AllDirectories))
                {
                    if (ignoreFiles.Contains(Path.GetFileName(file))) continue;
                    JToken jsonData;
                    try
                    {
                        jsonData = JToken.Parse(File.ReadAllText(file), new JsonLoadSettings());
                    }
                    catch (Exception f)
                    {
                        Console.WriteLine(f.Message);
                        continue;
                    }
                    if (jsonData is JObject && jsonData["ComponentType"] != null)
                    {
                        itemMapping.entries[jsonData["Description"]["Id"].ToString()] = new ItemMappingEntry { itemId = jsonData["Description"]["Id"].ToString(), itemType = jsonData["ComponentType"].ToString() };
                    }
                }
                File.WriteAllText("itemmapping.json", JsonConvert.SerializeObject(itemMapping, Formatting.Indented));
            }
            return itemMapping;
        }

        static string baseComponentTemplate = """
     {{
      "MountedLocation": "{2}",
      "ComponentDefID": "{0}",
      "ComponentDefType": "{1}",
      "HardpointSlot": -1,
      "DamageLevel": "Functional"
     }}
     """;

        static string baseEquipmentTemplate = """
     {{
      "MountedLocation": "{2}",
      "ComponentDefID": "{0}",
      "ComponentDefType": "{1}",
      "HardpointSlot": 0,
      "IsFixed": false,
      "GUID": null,
      "DamageLevel": "Functional",
      "hasPrefabName": false
     }}
     """;

        public static JObject? generateComponentString(string componentId, string location)
        {
            if (itemMapping.entries.ContainsKey(componentId))
            {
                var objectString = String.Format(baseComponentTemplate, itemMapping.entries[componentId].itemId, itemMapping.entries[componentId].itemType, location);
                return JObject.Parse(objectString);
            }
            return null;
        }

        public static JObject? generateEquipmentString(string componentId, string location)
        {
            if (itemMapping.entries.ContainsKey(componentId))
            {
                var objectString = String.Format(baseEquipmentTemplate, itemMapping.entries[componentId].itemId, itemMapping.entries[componentId].itemType, location);
                return JObject.Parse(objectString);
            }
            return null;
        }
    }
}
