using MechTemplateGen;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

List<MechInfo>? mechInfo = JsonConvert.DeserializeObject<List<MechInfo>>(File.ReadAllText("mechinfo.json"));
EngineWeightMapping weightMapping = JsonConvert.DeserializeObject<EngineWeightMapping>(File.ReadAllText("engineweightmapping.json"));

UtilityDataBuilder.buildItemMappingData();

void processFixedEquipment(JToken chassis, string[][] equipment)
{
    var fixedEquipment = new JArray();
    for (var i = 0; i < equipment.Length; i++)
    {
        for (var j = 0; j < equipment[i].Length; j++)
        {
            fixedEquipment.Add(UtilityDataBuilder.generateComponentString(equipment[i][j], chassis["Locations"][i]["Location"].ToString()));
        }
    }
    chassis["FixedEquipment"] = fixedEquipment;
}

JArray addToTags(JToken tags, string newTag)
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
    temp.Add(newTag);
    return temp;
}

JArray removeFromTags(JToken tags, string newTag)
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
        temp.Remove(mechToken);
    }
    return temp;
}

void processEquipment(JToken mech, string[][] equipment)
{
    var Equipment = new JArray();
    for (var i = 0; i < equipment.Length; i++)
    {
        for (var j = 0; j < equipment[i].Length; j++)
        {
            Equipment.Add(UtilityDataBuilder.generateEquipmentString(equipment[i][j], mech["Locations"][i]["Location"].ToString()));
        }
    }
    mech["Inventory"] = Equipment;
}

const string xMechSuffix = "<br><br>X-class mechs feature upgrades to their armour, thermal management and defensive systems that improve their survivability on the 31st century battlefield.";
const string sMechSuffix = "<br><br>S-class mechs feature upgrades to their armour, thermal management and defensive systems that substantially improve their survivability on the 31st century battlefield.";

var ItemColFileData = new Dictionary<string, List<string>>();

void processMechInfo(MechInfo info)
{
    const string chassisEndo = "EndoSteel";
    const string chassisStandard = "Standard";
    const string chassisEndoComp = "EndoComposite";

    if (info.baseTemplateFileName == null || info.baseMechFileName == null) { Console.WriteLine("Missing base template files"); return; }
    JObject chassis;
    JObject mech;
    JObject MoveDefTemplate;
    try
    {
        MoveDefTemplate = JObject.Parse(File.ReadAllText("movedef_template.json"));
        chassis = JObject.Parse(File.ReadAllText(info.baseTemplateFileName));
        mech = JObject.Parse(File.ReadAllText(info.baseMechFileName));
    } catch (Exception e)
    {
        Console.WriteLine(e);
        return;
    }
    if (info.mechTonnage != null)
    {
        chassis["Tonnage"] = info.mechTonnage;
    }
    var MechDisplayName = info.newMechName + " " + info.newMechDesignation + "-" + info.newMechModelNumber;
    
    if (info.initialTonnage != null)
    {
        chassis["InitialTonnage"] = info.initialTonnage;
    }
    else if (info.mechTonnage != null && info.mechEngine != null)
    {
        var chassisTonnage = (decimal)info.mechTonnage / 10;
        if (info.mechTonnage > 100)
        {
            // superheavy chassis are double weight
            chassisTonnage *= 2;
        }
        var chassisType = info.chassisType ?? "Standard";
        decimal chassisWeightMultiplier = 1.0M;
        switch (chassisType)
        {
            case chassisStandard:
                chassisWeightMultiplier = 1.0M;
                break;
            case chassisEndo:
                chassisWeightMultiplier = 0.5M;
                break;
            case chassisEndoComp:
                chassisWeightMultiplier = 0.75M;
                break;
        }
        chassisTonnage = MathHelper.CeilingToNearest(chassisTonnage * chassisWeightMultiplier, 0.5m);
        var engineTonnageMapping = weightMapping.entries[info.mechEngine.ToString()];
        var engineTonnage = (info.xlEngine ?? false) ? engineTonnageMapping.xlWeight : engineTonnageMapping.weight;
        var gyroWeight = Decimal.Parse(engineTonnageMapping.gyroWeight ?? "0.0");
        if (info.mechTonnage > 100)
        {
            // superheavy gyros are double weight
            gyroWeight *= 2;
        }
        var initialTonnage = Decimal.Parse(engineTonnage ?? "0.0") + chassisTonnage + gyroWeight + 3.0M;
        chassis["InitialTonnage"] = (double)(initialTonnage + (info.initialTonnageExtra ?? 0));
    }
    if(info.icon != null)
    {
        var newIconName = info.icon;
        var icons = Directory.GetFiles("..\\", info.icon + ".dds", SearchOption.AllDirectories);
        
        if (icons.Length > 0)
        {
            newIconName = $"uixTxrIcon_{((info.prefabName ?? info.newMechName) ?? chassis["Description"]["Name"].ToString()).ToLowerInvariant()}";
            var mostRecentDate = DateTime.MinValue;
            string mostRecentIcon = icons[0]; 
            for (var i = 0; i < icons.Length; i++)
            {
                var newWriteTime = File.GetLastWriteTime(icons[i]);
                if (Path.GetFullPath($"{newIconName}.dds") == Path.GetFullPath(icons[i])) { continue; }
                if (newWriteTime > mostRecentDate)
                {
                    mostRecentDate = newWriteTime;
                    mostRecentIcon = icons[i];
                }
            }
            
            File.Copy(mostRecentIcon, $"{newIconName}.dds", true);
        }
        chassis["Description"]["Icon"] = newIconName;
        mech["Description"]["Icon"] = newIconName;
    }
    if (info.prefabName != null && info.mechTonnage != null && info.mechEngine != null) {
        var name = MoveDefTemplate["Description"]["Id"].ToString();
        name = name.Replace("bloodasp", info.prefabName);
        MoveDefTemplate["Description"]["Id"] = name;
        var moveDist = info.mechEngine / info.mechTonnage;
        chassis["MaxJumpjets"] = moveDist;
        var sprintDist = Math.Ceiling((double)moveDist * 1.5);
        moveDist *= 30;
        sprintDist *= 30;
        MoveDefTemplate["MaxWalkDistance"] = moveDist;
        MoveDefTemplate["MaxSprintDistance"] = sprintDist;
        MoveDefTemplate["Description"]["Name"] = MoveDefTemplate["Description"]["Name"] + " " + MechDisplayName;
        var moveDefName = "movedef_" + info.prefabName + "_" + info.newMechDesignation + "-" + info.newMechModelNumber;
        chassis["MovementCapDefID"] = moveDefName;
        File.WriteAllText(moveDefName + ".json", MoveDefTemplate.ToString());
    }
    if (info.prefabId != null)
    {
        chassis["PrefabIdentifier"] = info.prefabId;
    }
    if (info.hardpointData != null)
    {
        chassis["HardpointDataDefID"] = info.hardpointData;
    }
    if (info.prefabName != null)
    {
        chassis["PrefabBase"] = info.prefabName;
    }
    string? weightClass = null;
    if (info.mechTonnage != null)
    {
        if (info.mechTonnage < 40)
        {
            weightClass = "LIGHT";
        }
        else if (info.mechTonnage < 60)
        {
            weightClass = "MEDIUM";
        }
        else if(info.mechTonnage < 80)
        {
            weightClass = "HEAVY";
        }
        else
        {
            weightClass = "ASSAULT";
        }
        chassis["weightClass"] = weightClass;
    }
    if (info.stockRole != null)
    {
        chassis["StockRole"] = info.stockRole;
    }
    if (info.newMechName != null)
    {
        chassis["Description"]["Name"] = info.newMechName;
        chassis["Description"]["UIName"] = info.newMechName;
    }
    if (info.details != null)
    {
        chassis["Description"]["Details"] = info.details;
        mech["Description"]["Details"] = info.details;
    }
    if (info.yangsThoughts != null)
    {
        chassis["YangsThoughts"] = info.yangsThoughts;
    }

    if (info.hardpoints != null)
    {
        bool useWeaponMountId = info.useMountIdNaming ?? false;
        JArray locations = (JArray)chassis["Locations"];
        if (locations == null)
        {
            Console.WriteLine("Error: Chassis file " + info.baseTemplateFileName + " is missing locations array");
            return;
        }
        for(int i = 0; i < locations.Count; i++)
        {
            JArray outputArray = new JArray();
            foreach (KeyValuePair<string, int[]> entry in info.hardpoints)
            {
                for (int j = 0; j < entry.Value[i]; j++)
                {
                    if (useWeaponMountId)
                    {
                        outputArray.Add(new JObject{
                            { "WeaponMountID",  entry.Key },
                            { "Omni", false }
                        });
                    }
                    else
                    {
                        outputArray.Add(new JObject {
                            { "WeaponMount",  entry.Key },
                            { "Omni", false }
                        });
                    }
                }
            }
            locations[i]["Hardpoints"] = outputArray;
        }
    }

    if(info.fixedEquipment != null)
    {
        processFixedEquipment(chassis, info.fixedEquipment);
    }
    if (info.equipment != null)
    {
        processEquipment(chassis, info.equipment);
    }

    var allTags = mech["MechTags"];
    if (allTags != null)
    {
        var tagItems = allTags["items"];
        if (tagItems != null)
        {
            tagItems = removeFromTags(tagItems, "elite_forces");
            tagItems = removeFromTags(tagItems, "elite_arsenal");
            tagItems = removeFromTags(tagItems, "elite_arsenal_s_tier");
            tagItems = removeFromTags(tagItems, "BLACKLISTED");
            tagItems = removeFromTags(tagItems, "NotDavion");
            tagItems = removeFromTags(tagItems, "NotLiao");
            tagItems = removeFromTags(tagItems, "NotMarik");
            tagItems = removeFromTags(tagItems, "NotSteiner");
            tagItems = removeFromTags(tagItems, "NotMagistracyOfCanopus");
            tagItems = removeFromTags(tagItems, "NotTaurianConcordat");
            allTags["items"] = tagItems;
        }
    }

    if (info.newMechVariant ?? false)
    {
        var newChassisDef = chassis.DeepClone();
        var newMechDef = mech.DeepClone();
        var mechIdName = info.newMechName.ToLowerInvariant().Replace(" ", "") + "_" + info.newMechDesignation + "-" + info.newMechModelNumber;
        var mechDisplayName = info.newMechName + " " + info.newMechDesignation + "-" + info.newMechModelNumber;
        var outputName = "chassisdef_" + mechIdName;
        var outputFileName = outputName + ".json";
        newChassisDef["Description"]["Id"] = outputName;
        newMechDef["ChassisID"] = outputName;
        newMechDef["Description"]["UIName"] = mechDisplayName;
        newMechDef["Description"]["Name"] = info.newMechName;
        var mechDefId = "mechdef_" + mechIdName;
        processStandardMechItemColData(info, ItemColFileData, mechDefId);
        newMechDef["Description"]["Id"] = mechDefId;
        var outputMechFileName = mechDefId + ".json";
        var variantId = info.newMechDesignation + "-" + info.newMechModelNumber;
        newChassisDef["VariantName"] = variantId;
        newChassisDef["Heatsinks"] = info.Heatsinks;
        File.WriteAllText(outputFileName, newChassisDef.ToString());
        File.WriteAllText(outputMechFileName, newMechDef.ToString());
    }
    if (info.newEliteForcesVariant ?? false)
    {
        var newChassisDef = chassis.DeepClone();
        var newMechDef = mech.DeepClone();
        var mechIdName = info.newMechName.ToLowerInvariant().Replace(" ", "") + "_" + info.newMechDesignation + "-" + info.newMechModelNumber + "X";
        var mechDisplayName = info.newMechName + " " + info.newMechDesignation + "-" + info.newMechModelNumber + "X";
        var outputName = "chassisdef_" + mechIdName;
        var outputFileName = outputName + ".json";
        newChassisDef["Description"]["Id"] = outputName;
        newMechDef["ChassisID"] = outputName;
        var mechDefId = "mechdef_" + mechIdName;
        newMechDef["Description"]["Id"] = mechDefId;
        newMechDef["Description"]["UIName"] = mechDisplayName;
        newMechDef["Description"]["Name"] = info.newMechName;
        var outputMechFileName = mechDefId + ".json";
        newChassisDef["Heatsinks"] = Math.Max(info.Heatsinks ?? 0, 30);
        var variantId = info.newMechDesignation + "-" + info.newMechModelNumber + "X";
        newChassisDef["VariantName"] = variantId;
        var tags = newMechDef["MechTags"];
        if (tags != null)
        {
            tags["items"] = addToTags(tags["items"], "elite_forces");
        }
        if (info.efFixedEquipment != null)
        {
            processFixedEquipment(newChassisDef, info.efFixedEquipment);
        }
        if (info.efEquipment != null)
        {
            processEquipment(chassis, info.efEquipment);
        }
        File.WriteAllText(outputFileName, newChassisDef.ToString());
        File.WriteAllText(outputMechFileName, newMechDef.ToString());
    }
    if (info.newEliteArsenalVariants ?? false)
    {
        var newXChassisDef = chassis.DeepClone();
        var newXMechDef = mech.DeepClone();
        var newSChassisDef = chassis.DeepClone();
        var newSMechDef = mech.DeepClone();
        if (newXChassisDef["YangsThoughts"] == newXChassisDef["Description"]["Details"])
        {
            newXChassisDef["YangsThoughts"] = newXChassisDef["YangsThoughts"] + xMechSuffix;
            newSChassisDef["YangsThoughts"] = newSChassisDef["YangsThoughts"] + sMechSuffix;
        }
        newXChassisDef["Description"]["Details"] = newXChassisDef["Description"]["Details"] + xMechSuffix;
        newSChassisDef["Description"]["Details"] = newSChassisDef["Description"]["Details"] + sMechSuffix;
        newXMechDef["Description"]["Details"] = newXMechDef["Description"]["Details"] + xMechSuffix;
        newSMechDef["Description"]["Details"] = newSMechDef["Description"]["Details"] + sMechSuffix;
        var includedMechNumberEliteArsenal = info.includeModelNumberInEAVariant ?? false ? "-" + info.newMechModelNumber : "";
        var mechXIdName = info.newMechName.ToLowerInvariant().Replace(" ", "") + "_" + info.newMechDesignation + includedMechNumberEliteArsenal + "-" + "X" + info.eliteArsenalVariantNumber;
        var mechSIdName = info.newMechName.ToLowerInvariant().Replace(" ", "") + "_" + info.newMechDesignation + includedMechNumberEliteArsenal + "-" + "S" + info.eliteArsenalVariantNumber;
        var mechXDisplayName = info.newMechName + " " + info.newMechDesignation + includedMechNumberEliteArsenal + "-" + "X" + info.eliteArsenalVariantNumber;
        var mechSDisplayName = info.newMechName + " " + info.newMechDesignation + includedMechNumberEliteArsenal + "-" + "S" + info.eliteArsenalVariantNumber;
        var outputXName = "chassisdef_" + mechXIdName;
        var outputSName = "chassisdef_" + mechSIdName;
        var outputXFileName = outputXName + ".json";
        var outputSFileName = outputSName + ".json";
        newXChassisDef["Description"]["Id"] = outputXName;
        newSChassisDef["Description"]["Id"] = outputSName;
        newXMechDef["ChassisID"] = outputXName;
        newSMechDef["ChassisID"] = outputSName;
        var mechXDefId = "mechdef_" + mechXIdName;
        var mechSDefId = "mechdef_" + mechSIdName;
        processEAMechItemColData(info, ItemColFileData, mechXDefId);
        processEAMechItemColData(info, ItemColFileData, mechSDefId);
        var outputXMechFileName = mechXDefId + ".json";
        var outputSMechFileName = mechSDefId + ".json";
        newXMechDef["Description"]["Id"] = mechXDefId;
        newSMechDef["Description"]["Id"] = mechSDefId;
        newXMechDef["Description"]["UIName"] = mechXDisplayName;
        newSMechDef["Description"]["UIName"] = mechSDisplayName;
        newXMechDef["Description"]["Name"] = info.newMechName;
        newSMechDef["Description"]["Name"] = info.newMechName;
        var variantXId = info.newMechDesignation + includedMechNumberEliteArsenal + "-" + "X" + info.eliteArsenalVariantNumber;
        var variantSId = info.newMechDesignation + includedMechNumberEliteArsenal + "-" + "S" + info.eliteArsenalVariantNumber;
        newXChassisDef["VariantName"] = variantXId;
        newSChassisDef["VariantName"] = variantSId;
        newXChassisDef["Heatsinks"] = Math.Max(info.Heatsinks ?? 0, 30);
        newSChassisDef["Heatsinks"] = Math.Max(info.Heatsinks ?? 0 + 15, 45);

        var xTags = newXMechDef["MechTags"];
        if (xTags != null)
        {
            xTags["items"] = addToTags(xTags["items"], "elite_arsenal");
        }
        var sTags = newSMechDef["MechTags"];
        if (sTags != null)
        {
            var items = addToTags(sTags["items"], "elite_arsenal");
            if (items != null)
            {
                items.Add("elite_arsenal_s_tier");
                if (info.mechTonnage <= 100)
                {
                    items.Add("unit_mech_s_tier");
                    var mechToken = items.FirstOrDefault(x => x.Value<string>() == "unit_mech");
                    items.Remove(mechToken);
                } else 
                {
                    items.Add("unit_superheavy_s_tier");
                    var mechToken = items.FirstOrDefault(x => x.Value<string>() == "unit_superheavy");
                    items.Remove(mechToken);
                }
            }
            sTags["items"] = items;
        }
        var xChassisTags = newXChassisDef["ChassisTags"];
        if (xChassisTags != null)
        {
            xChassisTags["items"] = addToTags(xChassisTags["items"], "elite_arsenal");
        }
        var sChassisTags = newSChassisDef["ChassisTags"];
        if (sChassisTags != null)
        {
            sChassisTags["items"] = addToTags(sChassisTags["items"], "elite_arsenal_s_tier");
        }
        if (info.eaFixedEquipment != null)
        {
            processFixedEquipment(newXChassisDef, info.eaFixedEquipment);
            processFixedEquipment(newSChassisDef, info.eaFixedEquipment);
        }
        if (info.eaSFixedEquipment != null)
        {
            processFixedEquipment(newSChassisDef, info.eaSFixedEquipment);
        }
        if (info.eaXEquipment != null)
        {
            processEquipment(newXMechDef, info.eaXEquipment);
        }
        if (info.eaSEquipment != null)
        {
            processEquipment(newSMechDef, info.eaSEquipment);
        }
        File.WriteAllText(outputXFileName, newXChassisDef.ToString());
        File.WriteAllText(outputXMechFileName, newXMechDef.ToString());
        File.WriteAllText(outputSFileName, newSChassisDef.ToString());
        File.WriteAllText(outputSMechFileName, newSMechDef.ToString());
    }
}

if (mechInfo != null)
{
    Console.WriteLine(mechInfo.Count);
    foreach (var info in mechInfo)
    {
        processMechInfo(info);
    }
}

foreach (var entry in ItemColFileData)
{
    File.WriteAllLines(entry.Key + ".csv", entry.Value);
}

static void processStandardMechItemColData(MechInfo info, Dictionary<string, List<string>> ItemColFileData, string mechDefId)
{
    ItemColSetting? setting = info.itemColAssignment?.mech;
    if (setting != null)
    {
        foreach (string itemCol in setting?.itemCol)
        {
            if (ItemColFileData.GetValueOrDefault(itemCol) == null)
            {
                ItemColFileData[itemCol] = [];
            }
            ItemColFileData[itemCol].Add($"{mechDefId},Mech,1,1");
        }
    }
    ItemColSetting? partSetting = info.itemColAssignment?.mechPart;
    if (partSetting != null)
    {
        foreach (string itemCol in partSetting?.itemCol)
        {
            if (ItemColFileData.GetValueOrDefault(itemCol) == null)
            {
                ItemColFileData[itemCol] = [];
            }
            ItemColFileData[itemCol].Add($"{mechDefId},MechPart,1,1");
        }
    }
}

static void processEAMechItemColData(MechInfo info, Dictionary<string, List<string>> ItemColFileData, string mechDefId)
{
    ItemColSetting? setting = info.itemColAssignment?.mech;
    if (setting != null)
    {
        foreach (string itemCol in setting?.itemColEA)
        {
            if (ItemColFileData.GetValueOrDefault(itemCol) == null)
            {
                ItemColFileData[itemCol] = [];
            }
            ItemColFileData[itemCol].Add($"{mechDefId},Mech,1,1");
        }
    }
    ItemColSetting? partSetting = info.itemColAssignment?.mechPart;
    if (partSetting != null)
    {
        foreach (string itemCol in partSetting?.itemColEA)
        {
            if (ItemColFileData.GetValueOrDefault(itemCol) == null)
            {
                ItemColFileData[itemCol] = [];
            }
            ItemColFileData[itemCol].Add($"{mechDefId},MechPart,1,1");
        }
    }
}