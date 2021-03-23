using System;
using System.Collections.Generic;
using System.Xml;
using System.Reflection;
using System.IO;

namespace DataLayer
{
	public class ConfigClass
	{
		private static string configFileName = "/generated.config";
		private static string settingsPath = "appSettings/add";
		private static Configuration Configuration { get; set; }

		public static string GetConnectionString(string key)
		{
			return Configuration.AppSettings[key];
		}

		static ConfigClass()
		{
			XmlDocument doc = new XmlDocument();
			string path = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
			string rootDir = Path.GetDirectoryName(path);
			doc.Load(rootDir + configFileName);
			var root = doc.DocumentElement;
			var list = root.SelectNodes(settingsPath);
			Configuration = new Configuration();
			foreach (var setting in list)
			{
				var element = (XmlElement)setting;
				var key = element.Attributes["key"].Value;
				var value = element.Attributes["value"].Value;
				Configuration.AppSettings.Add(key, value);
			}
		}
	}

	public class Configuration
	{
		public Dictionary<string, string> AppSettings { get; }
		public Configuration()
		{
			AppSettings = new Dictionary<string, string>();
		}
	}
}
