using Exiled.API.Features;
using HarmonyLib;
using PlayerRoles.Voice;
using System.Linq;
using PlayerRoles;
using UnityEngine;
using Intercom = PlayerRoles.Voice.Intercom;

namespace IntercomPlugin
{
    [HarmonyPatch(typeof(Intercom), nameof(Intercom.Update))]
    public static class IntercomPatch
    {
        [HarmonyPrefix]
        public static void OnUpdate(Intercom __instance)
        {
            
            var classDCount = Player.List.Count(p => p.Role.Type == RoleTypeId.ClassD);
            var mtfCount = Player.List.Count(p => p.Role.Team == Team.FoundationForces);
            var scientistCount = Player.List.Count(p => p.Role.Type == RoleTypeId.Scientist);
            var chaosCount = Player.List.Count(p => p.Role.Team == Team.ChaosInsurgency);
            var scpsCount = Player.List.Count(p => p.Role.Team == Team.SCPs);

            var IntercomState = Intercom.State;

            var remainingTime = Mathf.Round(IntercomDisplay._singleton._icom.RemainingTime);
            string IntercomRemainingTime = remainingTime > 1 ? remainingTime.ToString() : "";
            
            IntercomDisplay._singleton.Network_overrideText = $"<color=white>{Class1.instance.Translation.Information}</color>\n<color=orange><b>{Class1.instance.Translation.ClassDText}</b> - {classDCount}</color>\n<color=#3d61f2><b>{Class1.instance.Translation.FoundationForces} - {mtfCount}</b></color>\n<color=yellow><b>{Class1.instance.Translation.Scientists} - {scientistCount}</b></color>\n<color=#258a25><b>{Class1.instance.Translation.ChaosInsurgency} - {chaosCount}</b></color>\n<color=red><b>{Class1.instance.Translation.SCPs} - {scpsCount}</b></color>\n-------------------------------------\n{Class1.instance.Translation.State} - {IntercomState}\n{Class1.instance.Translation.Timer} {IntercomRemainingTime}";
        }
    }
}