# Automated Build Script Configuration

## Requirements

To run automated builds you will need:

- Python 3.0 . You can download it from the [official Python website](https://www.python.org/downloads/)
- JDK 1.8.0 . You can download it from the Oracle website or from [this GitHub page](https://gist.github.com/wavezhang/ba8425f24a968ec9b2a8619d7c2d86a6)
- Android SDK. You can download and install it together with Unity Editor or latest version of Android Studio

## Configuration

To configure your local paths to do the automated Mirage Widget Android library and Unity example builds you need to create LocalBuildSettings.txt in the repo's BuildScripts folder. To do this easily you can make a copy of LocalBuildSettings-template.txt, rename it to LocalBuildSettings.txt and fill its JSON-object property values with your local values. LocalBuildSettings.txt is ignored by git.

Here's a description of each property in this config:

| Property | Description | Example Value | 
| --- | --- | --- |
| AndroidProjectPath | Relative path to the Mirage-Android-WebView-Plugin Android project folder | "../Mirage-Android-WebView-Plugin" |
| UnityProjectPath | Relative path to the Mirage-Widget Unity project folder | "../Mirage-Widget" |
| UnityPath | Absolute path to the Unity executable | "C:/Program Files/Unity/Hub/Editor/2021.3.8f1/Editor/Unity.exe" |
| KeystorePath | Absolute path to the Android keystore file | "C:/repos/Fuzzball-Fighters/FF.keystore" |
| KeystorePassword | Password for the Android keystore | "qwerty" |
| Alias | Alias of the key within the keystore | | "some_alias" |
| AliasPassword | Password for the key alias | "qwerty" |
| ADBPath | Absolute to the Android Debug Bridge (ADB) executable | "C:/Program Files/Unity/Hub/Editor/2021.3.8f1/Editor/Data/PlaybackEngines/AndroidPlayer/SDK/platform-tools/adb.exe" |
| PackageName | The package name for the Unity project | "com.mirage.MirageWidget" |
| DeletePreviousBuild | Whether to uninstall the previous build from a device before installing a new one (true/false) | true |


Make sure to fill in the necessary values for KeystorePassword, AliasPassword, and any other fields needed for your specific configuration.
