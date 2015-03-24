using UnityEngine;
using System.Collections;

namespace Model{

	public class SpellModel {

		public string spellName { get; set;}
		public float dmg { get; set;}
		public string particlePath { get; set;}
		public string iconName { get; set;}
		public float cooldown { get; set;}
		public float spellDuration { get; set;}

		public SpellModel(string spellName, float dmg, string particlePath, string iconName, float cooldown, float spellDuration){
			this.spellName = spellName;
			this.dmg = dmg;
			this.particlePath = particlePath;
			this.iconName = iconName;
			this.cooldown = cooldown;
			this.spellDuration = spellDuration;
		}
	}
}
