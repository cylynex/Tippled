#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using UnityEngine;


public class CreateAssetBundles {

    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles() {  
        BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    }
}
#endif