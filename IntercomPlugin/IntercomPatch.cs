using Exiled.API.Features;
using HarmonyLib;
using PlayerRoles.Voice;
using System.Linq;
using System.Text;
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
            var ntfCount = Player.List.Count(p => p.Role.Team == Team.FoundationForces);
            var scientistCount = Player.List.Count(p => p.Role.Type == RoleTypeId.Scientist);
            var chaosCount = Player.List.Count(p => p.Role.Team == Team.ChaosInsurgency);
            var scpsCount = Player.List.Count(p => p.Role.Team == Team.SCPs);

            var IntercomState = Intercom.State;

            var remainingTime = Mathf.Round(IntercomDisplay._singleton._icom.RemainingTime);
            string IntercomRemainingTime = remainingTime > 1 ? remainingTime.ToString() : "";
            string RoundTime = $"{Round.ElapsedTime.TotalSeconds / 60:00}:{Round.ElapsedTime.TotalSeconds % 60:00}";

            StringBuilder stringBuilder = new StringBuilder();

            if (Class1.instance.Config.RoundTimer)
                stringBuilder.AppendLine($"{Class1.instance.Translation.RoundTimer} - {RoundTime}");

            stringBuilder.AppendLine($"<color=white>{Class1.instance.Translation.Information}</color>");
            
            if (Class1.instance.Config.ClassD)
                stringBuilder.AppendLine($"<color=#f7a71b>{Class1.instance.Translation.ClassDText} - {classDCount}</color>");
            
            if (Class1.instance.Config.NTF)
                stringBuilder.AppendLine($"<color=#3550db>{Class1.instance.Translation.FoundationForces} - {ntfCount}</color>");
            
            if (Class1.instance.Config.Scientist)
                stringBuilder.AppendLine($"<color=#d4eb7a>{Class1.instance.Translation.Scientists} - {scientistCount}</color>");
            
            if (Class1.instance.Config.Chaos)
                stringBuilder.AppendLine($"<color=#227a0f>{Class1.instance.Translation.ChaosInsurgency} - {chaosCount}</color>");
            
            if (Class1.instance.Config.SCPS)
                stringBuilder.AppendLine($"<color=#c21010>{Class1.instance.Translation.SCPs} - {scpsCount}</color>");

            stringBuilder.AppendLine("<color=white>-------------------------------------</color>");
            
            stringBuilder.AppendLine($"{Class1.instance.Translation.State} - {IntercomState}");

            stringBuilder.AppendLine($"{Class1.instance.Translation.Timer} {IntercomRemainingTime}");
            
            
            IntercomDisplay._singleton.Network_overrideText = stringBuilder.ToString();
            stringBuilder.Clear();
        }
    }
}