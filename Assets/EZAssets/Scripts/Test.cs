using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	public static string StreamingPath = string.Empty;
	public string TestFTPHost = "ftp://172.81.212.57";
	public int TestFTPPort = 2122;

	void Awake() {
		#if UNITY_STANDALONE_WIN || UNITY_EDITOR  
			StreamingPath = "file://" + Application.dataPath + "/StreamingAssets/";  
		#elif UNITY_ANDROID  
			StreamingPath = "jar:file://" + Application.dataPath + "!/assets/";  
		#elif UNITY_IPHONE  
			StreamingPath = Application.dataPath + "/Raw/";  
		#else  
			StreamingPath = string.Empty;  
		#endif  
	}

	// Use this for initialization
	void Start () {
		EZAssetManager.Instance.LoadAssetBundle (StreamingPath + "materials", "materials");
		EZAssetManager.Instance.LoadAssetBundle (StreamingPath + "prefabs", "prefabs");
		Invoke ("aaa", 2f);
		FTPClient client = new FTPClient (TestFTPHost, "anonymous", "", TestFTPPort, null, false, true, true);
//		var localPath = Application.dataPath + "/StreamingAssets/materials";
//		client.Upload (localPath, "aaa.assetbundle");
		EZAssetManager.instance.DownloadAssetBundle (TestFTPHost + ":" + TestFTPPort + "/aaa.assetbundle", Application.dataPath + "/aaa.assetbundle");
	}

	void aaa() {

		GameObject.Instantiate(EZAssetManager.instance.LoadAsset ("Cube.prefab", "prefabs"));
		GameObject.Instantiate(EZAssetManager.instance.LoadAsset ("Sphere.prefab", "prefabs"));
	}
}
