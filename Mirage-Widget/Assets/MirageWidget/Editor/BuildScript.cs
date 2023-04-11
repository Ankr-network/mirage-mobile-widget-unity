using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildScript
{
    [MenuItem("Mirage/Make Example Android Build")]
    public static void PerformAndroidBuildFromEditor()
    {
        var outputPath = Path.Combine(Application.dataPath, "..\\..\\Build");
        var buildSettingsPath = Path.Combine(Application.dataPath, "..\\..\\BuildScripts\\LocalBuildSettings.txt");
        var settingsJson = File.ReadAllText(buildSettingsPath);
        var settingsDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(settingsJson);
        var keystorePath = (string)settingsDict["KeystorePath"];
        var keystorePassword = (string)settingsDict["KeystorePassword"];
        var alias = (string)settingsDict["Alias"];
        var aliasPassword = (string)settingsDict["AliasPassword"];
        BuildAndroid(outputPath, keystorePath, keystorePassword, alias, aliasPassword);
    }

    public static void BuildAndroidFromCommand()
    {
        try
        {
            string outputPath = GetArgument("outputPath");
            string keystorePath = GetArgument("keystore");
            string keystorePassword = GetArgument("keystorePass");
            string alias = GetArgument("alias");
            string aliasPassword = GetArgument("aliasPass");

            BuildAndroid(outputPath, keystorePath, keystorePassword, alias, aliasPassword);

        }
        catch (Exception e)
        {
            Debug.LogError($"{e.Message} : {e.StackTrace}");
            EditorApplication.Exit(0);
        }
    }

    private static void BuildAndroid(string outputPath, string keystorePath, string keystorePassword, string alias, string aliasPassword)
    {
        if (string.IsNullOrEmpty(outputPath))
        {
            Debug.LogError("No output path specified.");
            return;
        }

        PlayerSettings.Android.keystoreName = keystorePath;
        PlayerSettings.Android.keystorePass = keystorePassword;
        PlayerSettings.Android.keyaliasName = alias;
        PlayerSettings.Android.keyaliasPass = aliasPassword;

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = new []{"Assets/MirageWidget/Examples/Scenes/MirageWidgetExample.unity"},
            locationPathName = outputPath,
            target = BuildTarget.Android,
            options = BuildOptions.Development
        };

        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }

    private static string GetArgument(string name)
    {
        string[] args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == $"-{name}")
            {
                if (i + 1 < args.Length)
                {
                    return args[i + 1];
                }
                else
                {
                    Debug.LogError($"No value provided for argument {name}.");
                }
            }
        }
        return null;
    }
}