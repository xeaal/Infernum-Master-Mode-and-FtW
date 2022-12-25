using System;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;
using MonoMod.RuntimeDetour.HookGen;
using MonoMod.Cil;
using Mono;

namespace InfernumMasterFtW
{
	public class InfernumMasterFtW : Mod {
		public override void Load() {
			if (!ModLoader.HasMod("InfernumMode")) return;
            HookEndpointManager.Modify(typeof(InfernumMode.PoDPlayer).GetMethod("PostUpdateMiscEffects", BindingFlags.Public | BindingFlags.Instance), IL_PostUpdateMiscEffects);
        }
		private void IL_PostUpdateMiscEffects(ILContext il) {
			var c = new ILCursor(il);
			var label = il.DefineLabel();
			if (!c.TryGotoNext(MoveType.Before, i => i.MatchLdfld(typeof(InfernumMode.PoDPlayer), "ShadowflameInferno")))
				throw new Exception("SF edit failed");
			if (!c.TryGotoPrev(i => i.MatchNop()))
				throw new Exception("MatchNop edit failed");
			c.MarkLabel(label);
			if (!c.TryGotoPrev(MoveType.After, i => i.MatchCall(typeof(Main), "get_masterMode")))
				throw new Exception("MM edit failed");
			c.Remove();
			c.Emit(Mono.Cecil.Cil.OpCodes.Brtrue, label);
			if (!c.TryGotoNext(MoveType.After, i => i.MatchLdsfld(typeof(Main), "getGoodWorld")))
				throw new Exception("FtW edit failed");
			c.Remove();
			c.Emit(Mono.Cecil.Cil.OpCodes.Brtrue, label);
		}
        public override void Unload() {
            if (!ModLoader.HasMod("InfernumMode")) return;
            HookEndpointManager.Unmodify(typeof(InfernumMode.PoDPlayer).GetMethod("PostUpdateMiscEffects", BindingFlags.Public | BindingFlags.Instance), IL_PostUpdateMiscEffects);
        }
    }
}
