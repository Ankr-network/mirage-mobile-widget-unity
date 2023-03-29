import os
import json
import subprocess
import sys
from datetime import datetime
from load_settings import load_settings

def build_android_project(unity_path, project_path, output_path, keystore_path, keystore_password, alias, alias_password):
    cmd = [
        unity_path,
        "-quit",
        "-batchmode",
        "-projectPath",
        project_path,
        "-executeMethod",
        "BuildScript.BuildAndroidFromCommand",
        "-outputPath",
        output_path,
        "-keystore",
        keystore_path,
        "-keystorePass",
        keystore_password,
        "-alias",
        alias,
        "-aliasPass",
        alias_password
    ]
    result = subprocess.run(cmd, capture_output=True, text=True)
    
    if result.returncode != 0:
        print("Unity build failed with the following errors:")
        print(result.stderr)
    else:
        print("Unity build completed successfully.")
        print(result.stdout)
    
def is_app_installed(adb_path, package_name):
    try:
        result = subprocess.run([adb_path, 'shell', 'pm', 'list', 'packages'], capture_output=True, text=True)
        installed_packages = result.stdout.splitlines()
        return any(pkg.strip() == f'package:{package_name}' for pkg in installed_packages)
    except Exception as e:
        print(f"Error while checking for installed app: {e}")
        return False

def adb_uninstall(adb_path, package_name):
    cmd = [adb_path, "uninstall", package_name]
    result = subprocess.run(cmd)
    if result.returncode != 0:
        print("ADB uninstall failed with the following errors:")
        print(result.stderr)
    else:
        print("ADB uninstall build completed successfully.")
        print(result.stdout)

def adb_clear_cache(adb_path, package_name):
    cmd = [adb_path, "shell", "pm", "clear", package_name]
    result = subprocess.run(cmd)
    if result.returncode != 0:
        print("ADB uninstall failed with the following errors:")
        print(result.stderr)
    else:
        print("ADB uninstall build completed successfully.")
        print(result.stdout)

def adb_install(adb_path, apk_path):
    cmd = [adb_path, "install", apk_path]
    result = subprocess.run(cmd)
    if result.returncode != 0:
        print("ADB install failed with the following errors:")
        print(result.stderr)
    else:
        print("ADB install build completed successfully.")
        print(result.stdout)     

if __name__ == "__main__":
    settings = load_settings()

    unity_path = settings["UnityPath"]
    project_path = os.path.abspath(settings["UnityProjectPath"])
    build_path = os.path.join(os.path.abspath("..\\"), "Build\\")
    apk_filename = os.path.basename(project_path) + "_" + datetime.now().strftime("%Y-%m-%d_%H-%M-%S") + ".apk"
    apk_path = os.path.join(build_path, apk_filename)
    keystore_path = settings["KeystorePath"]
    keystore_password = settings["KeystorePassword"]
    alias = settings["Alias"]
    alias_password = settings["AliasPassword"]
    adb_path = settings["ADBPath"]
    package_name = settings["PackageName"]
    delete_previous_build = settings["DeletePreviousBuild"]

    print(f"Building {apk_path} from {project_path} ...")
    build_android_project(unity_path, project_path, apk_path, keystore_path, keystore_password, alias, alias_password)
    
    if delete_previous_build:
        print(f"Checking if package {package_name} is installed ...")
        if is_app_installed(adb_path, package_name):
            print(f"Trying to delete package {package_name}")
            adb_uninstall(adb_path, package_name)
          # adb_clear_cache(adb_path, package_name)
        else:
            print(f"Package {package_name} is not installed")

    if os.path.exists(apk_path):
       print(f"Trying to install apk {apk_path}") 
       adb_install(adb_path, apk_path)
    else:
       print(f"APK file {apk_path} not found.")