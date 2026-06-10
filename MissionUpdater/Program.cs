using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics.CodeAnalysis;

string[] directoriesToScan = [
    "..\\..\\BattleTech_Data\\StreamingAssets\\data\\chassis",
    "..\\EliteArsenal\\chassis_clan",
    "..\\EliteArsenal\\chassis",
    "..\\EliteArsenal\\chassis_wob",
    "..\\EliteForces\\elitechassis",
    "..\\ExpandedArsenal\\chassis",
    "..\\ExpandedArsenal\\chassis_clan",
    "..\\ExpandedArsenal\\chassis_wob",
    "..\\LAMs\\chassis",
    "..\\superheavies\\chassis",
    "..\\ExpandedArsenalStrongerSClans\\chassis",
    "..\\ExpandedArsenalStrongerSClans\\chassis_clan"
];

bool tagsContainString(JToken tags, string newTag)
{
    JArray temp;
    if (!(tags is JArray))
    {
        temp = new JArray();
        temp.Add(tags.DeepClone());
    }
    else
    {
        temp = (JArray)tags;
    }
    var mechToken = temp.FirstOrDefault(x => x.Value<string>() == newTag);
    if (mechToken != null)
    {
        return true;
    }
    return false;
}



Dictionary<string, OrderedDictionary<string, string>> outputFileData = new Dictionary<string, OrderedDictionary<string, string>>
{
    { "itemCollection_fp_eae_lightparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_lightparts", "itemCollection_fp_eae_lightparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_lightmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_lightmechs", "itemCollection_fp_eae_lightmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_lightmedparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_lightmedparts", "itemCollection_fp_eae_lightmedparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_lightmedmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_lightmedmechs", "itemCollection_fp_eae_lightmedmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_medparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_medparts", "itemCollection_fp_eae_medparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_medmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_medmechs", "itemCollection_fp_eae_medmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_medheavyparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_medheavyparts", "itemCollection_fp_eae_medheavyparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_medheavymechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_medheavymechs", "itemCollection_fp_eae_medheavymechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_heavyparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_heavyparts", "itemCollection_fp_eae_heavyparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_heavymechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_heavymechs", "itemCollection_fp_eae_heavymechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_heavyasltparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_heavyasltparts", "itemCollection_fp_eae_heavyasltparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_heavyasltmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_heavyasltmechs", "itemCollection_fp_eae_heavyasltmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_asltparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_asltparts", "itemCollection_fp_eae_asltparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_asltmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_asltmechs", "itemCollection_fp_eae_asltmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_asltsuperparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_asltsuperparts", "itemCollection_fp_eae_asltsuperparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_asltsupermechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_asltsupermechs", "itemCollection_fp_eae_asltsupermechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_lightparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_lightparts", "itemCollection_fp_eae_ef_lightparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_lightmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_lightmechs", "itemCollection_fp_eae_ef_lightmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_lightmedparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_lightmedparts", "itemCollection_fp_eae_ef_lightmedparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_lightmedmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_lightmedmechs", "itemCollection_fp_eae_ef_lightmedmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_medparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_medparts", "itemCollection_fp_eae_ef_medparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_medmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_medmechs", "itemCollection_fp_eae_ef_medmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_medheavyparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_medheavyparts", "itemCollection_fp_eae_ef_medheavyparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_medheavymechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_medheavymechs", "itemCollection_fp_eae_ef_medheavymechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_heavyparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_heavyparts", "itemCollection_fp_eae_ef_heavyparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_heavymechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_heavymechs", "itemCollection_fp_eae_ef_heavymechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_heavyasltparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_heavyasltparts", "itemCollection_fp_eae_ef_heavyasltparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_heavyasltmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_heavyasltmechs", "itemCollection_fp_eae_ef_heavyasltmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_asltparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_asltparts", "itemCollection_fp_eae_ef_asltparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_asltmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_asltmechs", "itemCollection_fp_eae_ef_asltmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_asltsuperparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_asltsuperparts", "itemCollection_fp_eae_ef_asltsuperparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ef_asltsupermechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ef_asltsupermechs", "itemCollection_fp_eae_ef_asltsupermechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_lightparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_lightparts", "itemCollection_fp_eae_ea_lightparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_lightmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_lightmechs", "itemCollection_fp_eae_ea_lightmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_lightmedparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_lightmedparts", "itemCollection_fp_eae_ea_lightmedparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_lightmedmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_lightmedmechs", "itemCollection_fp_eae_ea_lightmedmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_medparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_medparts", "itemCollection_fp_eae_ea_medparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_medmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_medmechs", "itemCollection_fp_eae_ea_medmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_medheavyparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_medheavyparts", "itemCollection_fp_eae_ea_medheavyparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_medheavymechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_medheavymechs", "itemCollection_fp_eae_ea_medheavymechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_heavyparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_heavyparts", "itemCollection_fp_eae_ea_heavyparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_heavymechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_heavymechs", "itemCollection_fp_eae_ea_heavymechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_heavyasltparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_heavyasltparts", "itemCollection_fp_eae_ea_heavyasltparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_heavyasltmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_heavyasltmechs", "itemCollection_fp_eae_ea_heavyasltmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_asltparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_asltparts", "itemCollection_fp_eae_ea_asltparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_asltmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_asltmechs", "itemCollection_fp_eae_ea_asltmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_asltsuperparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_asltsuperparts", "itemCollection_fp_eae_ea_asltsuperparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_ea_asltsupermechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_ea_asltsupermechs", "itemCollection_fp_eae_ea_asltsupermechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_lightparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_lightparts", "itemCollection_fp_eae_eas_lightparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_lightmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_lightmechs", "itemCollection_fp_eae_eas_lightmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_lightmedparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_lightmedparts", "itemCollection_fp_eae_eas_lightmedparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_lightmedmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_lightmedmechs", "itemCollection_fp_eae_eas_lightmedmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_medparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_medparts", "itemCollection_fp_eae_eas_medparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_medmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_medmechs", "itemCollection_fp_eae_eas_medmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_medheavyparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_medheavyparts", "itemCollection_fp_eae_eas_medheavyparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_medheavymechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_medheavymechs", "itemCollection_fp_eae_eas_medheavymechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_heavyparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_heavyparts", "itemCollection_fp_eae_eas_heavyparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_heavymechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_heavymechs", "itemCollection_fp_eae_eas_heavymechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_heavyasltparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_heavyasltparts", "itemCollection_fp_eae_eas_heavyasltparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_heavyasltmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_heavyasltmechs", "itemCollection_fp_eae_eas_heavyasltmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_asltparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_asltparts", "itemCollection_fp_eae_eas_asltparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_asltmechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_asltmechs", "itemCollection_fp_eae_eas_asltmechs,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_asltsuperparts.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_asltsuperparts", "itemCollection_fp_eae_eas_asltsuperparts,type,qty,weight" } } },
    { "itemCollection_fp_eae_eas_asltsupermechs.csv", new OrderedDictionary<string, string>{{ "itemCollection_fp_eae_eas_asltsupermechs", "itemCollection_fp_eae_eas_asltsupermechs,type,qty,weight" } } }
};



void mapMechToFiles(JObject mechFile, JObject chassisFile)
{
    var tonnage = chassisFile["Tonnage"].Value<int>();
    bool mechIsEF = tagsContainString(mechFile["MechTags"]["items"], "elite_forces") || tagsContainString(mechFile["MechTags"]["items"], "Elite_Forces");
    bool mechIsEA = tagsContainString(mechFile["MechTags"]["items"], "elite_arsenal") && !tagsContainString(mechFile["MechTags"]["items"], "elite_arsenal_s_tier");
    bool mechIsEAS = tagsContainString(mechFile["MechTags"]["items"], "elite_arsenal_s_tier");
    List<string> temp = new List<string>();
    var gradeString = "";
    if (mechIsEF)
    {
        gradeString = "ef_";
    }
    if (mechIsEA)
    {
        gradeString = "ea_";
    }
    if (mechIsEAS)
    {
        gradeString = "eas_";
    }
    string[] weightStrings;
    switch (tonnage)
    {
        case > 0 and < 40:
            weightStrings = ["light", "lightmed"];
            break;
        case >= 40 and < 60:
            weightStrings = ["lightmed", "med", "medheavy"];
            break;
        case >= 60 and < 80:
            weightStrings = ["medheavy", "heavy", "heavyaslt"];
            break;
        case >= 80 and <= 100:
            weightStrings = ["heavyaslt", "aslt", "asltsuper"];
            break;
        case > 100:
            weightStrings = ["asltsuper"];
            break;
        default:
            weightStrings = [];
            break;
    }
    var baseMechString = mechFile["Description"]["Id"].Value<string>();
    foreach (var weightstring in weightStrings)
    {
        var entryMechValue = $"{baseMechString},Mech,1,1";
        var entryPartValue = $"{baseMechString},MechPart,1,1";
        var mechFileValue = $"itemCollection_fp_eae_{gradeString}{weightstring}mechs";
        var partFileValue = $"itemCollection_fp_eae_{gradeString}{weightstring}parts";
        outputFileData[$"{mechFileValue}.csv"].TryAdd(baseMechString, entryMechValue);
        outputFileData[$"{partFileValue}.csv"].TryAdd(baseMechString, entryPartValue);
    }
}

foreach (var directory in directoriesToScan)
{
    foreach (var chassisFileName in Directory.EnumerateFiles(directory, "*.json", SearchOption.TopDirectoryOnly))
    {
        var mechFileName = Path.GetFullPath(chassisFileName).Replace("chassis", "mech");
        try
        {
            JObject mechFile = JObject.Parse(File.ReadAllText(mechFileName));
            JObject chassisFile = JObject.Parse(File.ReadAllText(chassisFileName));
            mapMechToFiles(mechFile, chassisFile);
        } catch (Exception e)
        {
            if (chassisFileName.Contains("__fp")
                || (chassisFileName.Contains("Template"))
                || (chassisFileName.Contains("clint") && chassisFileName.Contains("SClans"))
                || (chassisFileName.Contains("wasp") && chassisFileName.Contains("SClans"))
                || (chassisFileName.Contains("banex") && chassisFileName.Contains("SClans"))
                || (chassisFileName.Contains("FM-B") && chassisFileName.Contains("SClans"))
                || (chassisFileName.Contains("FM-D") && chassisFileName.Contains("SClans"))
                || (chassisFileName.Contains("FM-PRIME") && chassisFileName.Contains("SClans"))
                || (chassisFileName.Contains("GAR-E") && chassisFileName.Contains("SClans")))
            {
                continue;
            }
            throw;
        }
    }
}

foreach (var entry in outputFileData)
{
    File.WriteAllLines(entry.Key, entry.Value.Values);
}

void writeFinalFile(int fileNumber, string gradeString)
{
    string mechSize;
    switch (fileNumber)
    {
        case 3:
            mechSize = "light";
            break;
        case 4:
            mechSize = "lightmed";
            break;
        case 5:
            mechSize = "med";
            break;
        case 6:
            mechSize = "medheavy";
            break;
        case 7:
            mechSize = "heavy";
            break;
        case 8:
            mechSize = "heavyaslt";
            break;
        case 9:
            mechSize = "aslt";
            break;
        case 10:
            mechSize = "asltsuper";
            break;
        default:
            mechSize = "";
            break;
    }
    string finalFileName = $"itemCollection_fp_eae_{gradeString}{fileNumber}";
    var outputString = gradeString == "" || gradeString == "ef_" ?
        $"{finalFileName},,,{Environment.NewLine}" +
        $"itemCollection_fp_eae_{mechSize}mechs,Reference,1,1{Environment.NewLine}" +
        $"itemCollection_fp_eae_{mechSize}parts,Reference,6,1{Environment.NewLine}" :
        $"{finalFileName},,,{Environment.NewLine}" +
        $"itemCollection_fp_eae_{mechSize}mechs,Reference,1,1{Environment.NewLine}" +
        $"itemCollection_fp_eae_{mechSize}parts,Reference,3,1{Environment.NewLine}" +
        $"itemCollection_fp_weapons,Reference,5,1{Environment.NewLine}" +
        $"itemCollection_fp_upgrades,Reference,1,1{Environment.NewLine}";
    File.WriteAllText(finalFileName + ".csv", outputString);
}

for (var i = 3; i <= 10; i++)
{
    writeFinalFile(i, "");
    writeFinalFile(i, "ef_");
    writeFinalFile(i, "ea_");
    writeFinalFile(i, "eas_");
}
