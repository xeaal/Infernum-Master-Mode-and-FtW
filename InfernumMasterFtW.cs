using System;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace InfernumMasterFtW
{
	public class InfernumMasterFtW : Mod {
		public override void Load() {
			if (!ModLoader.HasMod("InfernumMode")) return;
			InfernumMode.Core.GlobalInstances.Systems.DifficultyManagementSystem.DisableDifficultyModes = false;
        }
        public override void Unload() {
            if (!ModLoader.HasMod("InfernumMode")) return;
			InfernumMode.Core.GlobalInstances.Systems.DifficultyManagementSystem.DisableDifficultyModes = true;
        }
    }
}
