using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EZAssetManager : MonoBehaviour {
	public static EZAssetManager instance;
	public static EZAssetManager Instance {
		get { 
			if (instance == null) {
				GameObject go = new GameObject ("EZAsset");
				GameObject.DontDestroyOnLoad (go);
				instance = go.AddComponent<EZAssetManager> ();
			}
			return instance;
		}
	}

	private Dictionary<string, AssetBundle> AssetBundles = new Dictionary<string, AssetBundle> ();

	public Object LoadAsset(string path, string assetName) {
		if (string.IsNullOrEmpty (assetName)) {
			return LoadAsset (path);
		} else {
			return LoadAsset (path, AssetBundles [assetName]);
		}
	}

	public Object LoadAsset(string path) {
		return Resources.Load(path);
	}

	public Object LoadAsset(string path, AssetBundle bundle) {
		return bundle.LoadAsset(path);
	}

	public void LoadAssetBundle(string path, string assetName) {
		StartCoroutine(LoadBundle(path, assetName));
	}

	public void Unload() {
		foreach (AssetBundle bundle in AssetBundles.Values) {
			bundle.Unload (true);
		}
		AssetBundles.Clear ();
	}

	IEnumerator LoadBundle(string path, string assetName) {
		WWW www = new WWW (path);
		yield return www;
		AssetBundles [assetName] = www.assetBundle;
		www.Dispose ();
		Debug.Log (path + " load finished");
	}

	public void DownloadAssetBundle(string url, string output) {
		StartCoroutine(DownloadBundle(url, output));
	}

	IEnumerator DownloadBundle(string url, string output) {
		WWW www = new WWW (url);
		yield return www;
		FileHelper.Save (output, www.bytes);
		www.Dispose ();
	}
}
