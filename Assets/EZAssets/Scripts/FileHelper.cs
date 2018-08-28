using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileHelper {

	public static void Save(string path, string content) {
		string dirPath = Path.GetDirectoryName(path);
		if (!Directory.Exists(dirPath))
		{
			Directory.CreateDirectory(dirPath);
		}
		File.WriteAllText(path, content);
	}

	public static void Save(string path, byte[] bytes) {
		string dirPath = Path.GetDirectoryName(path);
		if (!Directory.Exists(dirPath))
		{
			Directory.CreateDirectory(dirPath);
		}
		File.WriteAllBytes(path, bytes);
	}
}
