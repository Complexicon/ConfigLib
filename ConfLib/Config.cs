using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ConfLib {
	public class Config {
		public Dictionary<string, string> cfgDict = new Dictionary<string, string>();
		private readonly string fileLocation;

		public Config(string fileLocation) {
			this.fileLocation = fileLocation;
			LoadConfig();
		}

		public void ReloadConfig() => LoadConfig();

		private void LoadConfig() {
			if(File.Exists(fileLocation)) {
				var confLines = File.ReadAllLines(fileLocation);
				foreach(string i in confLines) {
					var splitted = i.Split('=');
					cfgDict[splitted[0]] = splitted[1];
				}
			} else File.Create(fileLocation).Close();
		}

		public bool SaveConfig() {
			List<string> data = new List<string>();
			foreach(string key in cfgDict.Keys) data.Add(key + "=" + cfgDict[key]);
			try {
				File.WriteAllLines(fileLocation, data.ToArray());
				return true;
			} catch { return false; }
		}

		private string Get(string key) {
			try {
				return cfgDict[key];
			} catch {
				return "NOEX";
			}
		}

		private void Set(string key, string val) => cfgDict[key] = val;

		public bool Exists(string key) => Get(key) == "NOEX" ? false : true;

		public string GetStr(string key) => Get(key);
		public int GetInt(string key) => int.TryParse(Get(key), out int val) ? val : 0;
		public float GetFloat(string key) => float.TryParse(Get(key), NumberStyles.Float, CultureInfo.InvariantCulture, out float val) ? val : 0F;
		public bool GetBool(string key) => bool.TryParse(Get(key), out bool val) ? val : false;
		public double GetDouble(string key) => double.TryParse(Get(key), NumberStyles.Any, CultureInfo.InvariantCulture, out double val) ? val : 0.0;

		public void SetStr(string key, string val) => Set(key, val);
		public void SetInt(string key, int val) => Set(key, val + "");
		public void SetFloat(string key, float val) => Set(key, val.ToString(CultureInfo.InvariantCulture));
		public void SetBool(string key, bool val) => Set(key, val + "");
		public void SetDouble(string key, double val) => Set(key, val.ToString(CultureInfo.InvariantCulture));
	}
}
