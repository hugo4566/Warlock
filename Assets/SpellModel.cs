using UnityEngine;
using System.Collections;

namespace Model{

	public class SpellModel {

		public string spellName { get; set;}
		public float cooldown { get; set;}
		public string particlePath { get; set;}

		public SpellModel(string spellName, float cooldown, string particlePath){
			this.spellName = spellName;
			this.cooldown = cooldown;
			this.particlePath = particlePath;
		}
	}
}
