using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MechTemplateGen
{

    public struct ItemColSetting
    {
        [JsonProperty("itemCol")]
        public string[] itemCol;
        [JsonProperty("itemColEA")]
        public string[] itemColEA;
    }

    public struct ItemColAssignment
    {
        [JsonProperty("mech")]
        public ItemColSetting? mech;
        [JsonProperty("mechPart")]
        public ItemColSetting? mechPart;
    }

    public struct MechInfo
    {
        [JsonProperty("baseTemplateFileName")]
        public string? baseTemplateFileName;
        [JsonProperty("baseMechFileName")]
        public string? baseMechFileName;
        [JsonProperty("icon")]
        public string? icon;
        [JsonProperty("newMechName")]
        public string? newMechName;
        [JsonProperty("newMechDesignation")]
        public string? newMechDesignation;
        [JsonProperty("newMechModelNumber")]
        public string? newMechModelNumber;
        [JsonProperty("newMechVariant")]
        public bool? newMechVariant;
        [JsonProperty("newEliteForcesVariant")]
        public bool? newEliteForcesVariant;
        [JsonProperty("newEliteArsenalVariants")]
        public bool? newEliteArsenalVariants;
        [JsonProperty("includeModelNumberInEAVariant")]
        public bool? includeModelNumberInEAVariant;
        [JsonProperty("eliteArsenalVariantNumber")]
        public string? eliteArsenalVariantNumber;
        [JsonProperty("initialTonnage")]
        public decimal? initialTonnage;
        [JsonProperty("initialTonnageExtra")]
        public decimal? initialTonnageExtra;
        [JsonProperty("prefabName")]
        public string? prefabName;
        [JsonProperty("prefabId")]
        public string? prefabId;
        [JsonProperty("hardpointData")]
        public string? hardpointData;
        [JsonProperty("mechTonnage")]
        public int? mechTonnage;
        [JsonProperty("mechEngine")]
        public int? mechEngine;
        [JsonProperty("xlEngine")]
        public bool? xlEngine;
        [JsonProperty("chassisType")]
        public string? chassisType;
        [JsonProperty("hardpoints")]
        public Dictionary<String, int[]>? hardpoints;
        [JsonProperty("useMountIdNaming")]
        public bool? useMountIdNaming;
        [JsonProperty("fixedEquipment")]
        public string[][] fixedEquipment;
        [JsonProperty("eaFixedEquipment")]
        public string[][] eaFixedEquipment;
        [JsonProperty("eaSFixedEquipment")]
        public string[][] eaSFixedEquipment;
        [JsonProperty("efFixedEquipment")]
        public string[][] efFixedEquipment;
        [JsonProperty("equipment")]
        public string[][] equipment;
        [JsonProperty("eaSEquipment")]
        public string[][] eaSEquipment;
        [JsonProperty("eaXEquipment")]
        public string[][] eaXEquipment;
        [JsonProperty("efEquipment")]
        public string[][] efEquipment;
        [JsonProperty("Heatsinks")]
        public int? Heatsinks;
        [JsonProperty("stockRole")]
        public string? stockRole;
        [JsonProperty("details")]
        public string? details;
        [JsonProperty("yangsThoughts")]
        public string? yangsThoughts;
        [JsonProperty("itemColAssignment")]
        public ItemColAssignment? itemColAssignment;
    }

    public struct EngineWeightMappingEntry
    {
        [JsonProperty("weight")]
        public string? weight;
        [JsonProperty("xlweight")]
        public string? xlWeight;
        [JsonProperty("gyroweight")]
        public string? gyroWeight;
    }

    public struct EngineWeightMapping
    {
        [JsonProperty("mappingEntries")]
        public Dictionary<String, EngineWeightMappingEntry> entries;
    }

    public struct ItemMappingEntry
    {
        [JsonProperty("itemId")]
        public string? itemId;
        [JsonProperty("itemType")]
        public string? itemType;
    }

    public struct ItemMapping
    {
        [JsonProperty("mappingEntries")]
        public Dictionary<String, ItemMappingEntry> entries;
    }
}
