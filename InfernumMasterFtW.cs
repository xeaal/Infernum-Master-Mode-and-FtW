using System;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace InfernumMasterFtW
{
	public class InfernumMasterFtW : Mod {
		public override void Load() {
			InfernumMode.Core.GlobalInstances.Systems.DifficultyManagementSystem.DisableDifficultyModes = false;
        }
        public override void Unload() {
			InfernumMode.Core.GlobalInstances.Systems.DifficultyManagementSystem.DisableDifficultyModes = true;
        }
    }
}
