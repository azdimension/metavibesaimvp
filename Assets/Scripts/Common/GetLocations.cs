using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GetLocations : MonoBehaviour
{
    static void BuildABs()
    {

        BuildPipeline.BuildAssetBundles("Assets/", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }

    static void BuildMapABs()
    {
        // Create the array of bundle build details.
        AssetBundleBuild[] buildMap = new AssetBundleBuild[2];

        buildMap[0].assetBundleName = "enemybundle";

        string[] UniqueAssets = new string[1];

        buildMap[0].assetNames = UniqueAssets;
        buildMap[1].assetBundleName = "currentbundle";

        string[] ServerAssets = new string[1];
        ServerAssets[0] = "char_hero_beanMan";
        buildMap[1].assetNames = ServerAssets;

        BuildPipeline.BuildAssetBundles("Assets/ABs", buildMap, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
