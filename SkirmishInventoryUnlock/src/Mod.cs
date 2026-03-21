using BattleTech;
using BattleTech.UI;
using Harmony;
using System;
using System.Reflection;

namespace Sheepy.SkirmishInventoryUnlock {
   using static System.Reflection.BindingFlags;

   public class Mod {

      public static void Init () {
         HarmonyInstance harmony = HarmonyInstance.Create( typeof( Mod ).Namespace );

         Patch( harmony, typeof( MechLabPanel ).GetMethod( "ComponentDefTagsValid", NonPublic | Instance ),
                         typeof( Mod ).GetMethod( "Override_ComponentDefTagsValid" ) );

         Patch( harmony, typeof( MechValidationRules ).GetMethod( "MechIsValidForSkirmish" ),
                         typeof( Mod ).GetMethod( "Override_MechIsValidForSkirmish" ) );
      }

      private static void Patch ( HarmonyInstance harmony, MethodInfo toPatch, MethodInfo prefix ) {
         if ( toPatch == null ) throw new NullReferenceException( "Cannot find " + toPatch.Name + " to patch" );
         if ( prefix == null ) throw new NullReferenceException( "Prefix patch not found for " + toPatch.Name );
         harmony.Patch( toPatch, new HarmonyMethod( prefix ) );
      }

      public static bool Override_ComponentDefTagsValid ( ref bool __result, MechLabPanel __instance, MechComponentDef def ) {
         __result = __instance.IsSimGame || 
            ( ! def.ComponentTags.Contains( "component_type_debug" )
           //&& ! def.ComponentTags.Contains( "BLACKLISTED" )
           && ! string.IsNullOrEmpty( def.Description?.UIName )
           && ! def.Description.UIName.ToUpper().Equals( "AUTOPILOT" ) );
         return false;
      }

      public static bool Override_MechIsValidForSkirmish ( ref bool __result, MechDef def, bool includeCustomMechs ) {
         bool hasRole = false, isMech = false;
         foreach ( string tag in def.MechTags ) {
            if ( ! includeCustomMechs && tag.Equals( "unit_custom" ) ) return false;
            if ( ! isMech && tag.StartsWith( "unit_mech" ) ) isMech = true;
            if ( ! isMech && tag.StartsWith( "unit_superheavy" )) isMech = true;
            if ( ! hasRole && tag.StartsWith( "unit_role_" ) ) hasRole = true;
         }
         __result = hasRole && isMech;
         return false;
      }
   }
}