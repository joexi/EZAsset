using UnityEngine;
using System.Collections;
using UnityEditor;

public class EZAssetEditor {
	[MenuItem("Tools/Assets/BuildAssets")]
	static void BuildAssets() {
		BuildPipeline.BuildAssetBundles(Application.dataPath + "/StreamingAssets/",BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows64);
	}

	[MenuItem("Tools/Assets/ShowDetail")]
	static void ShowDetail() {
		
	}
}
