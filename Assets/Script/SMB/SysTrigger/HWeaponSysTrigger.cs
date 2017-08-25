namespace Player.HTriggers {
	public class HWeaponSysTrigger : HSysTrigger{
		public const string ct_Pullout = "Pull out";
		public const string ct_Holster = "Holster";
		public const string ct_SwitchWeapon = "Switch Weapon";
		public const string ct_Reload = "Reload Weapon";
		public const string ct_Collet = "Collet Weapon";
		public const string ct_Drop = "Drop Weapon";
		public const string ct_Modify = "Modify Weapon";
		public const string ct_FlashLight = "Flashlight";

		public HWeaponSysTrigger() {
			_tirggers.Add(ct_Pullout,true);
			_tirggers.Add(ct_Holster,true);
			_tirggers.Add(ct_SwitchWeapon,true);
			_tirggers.Add(ct_Reload,true);
			_tirggers.Add(ct_Collet,true);
			_tirggers.Add(ct_Drop,true);
			_tirggers.Add(ct_Modify,true);
			_tirggers.Add(ct_FlashLight,true);
		}

		public HWeaponSysTrigger(bool val) {
			_tirggers.Add(ct_Pullout,val);
			_tirggers.Add(ct_Holster,val);
			_tirggers.Add(ct_SwitchWeapon,val);
			_tirggers.Add(ct_Reload,val);
			_tirggers.Add(ct_Collet,val);
			_tirggers.Add(ct_Drop,val);
			_tirggers.Add(ct_Modify,val);
			_tirggers.Add(ct_FlashLight,val);		
		}
	}
}