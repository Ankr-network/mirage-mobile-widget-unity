import os
import shutil
import subprocess
import sys
from load_settings import load_settings

def build_project(android_project_path, is_debug):
    if os.name == 'nt':
        gradle_executable = "gradlew.bat"
    else:
        gradle_executable = "./gradlew"

    os.chdir(android_project_path)
    subprocess.run([gradle_executable, "clean"])
    build_type = "assembleDebug" if is_debug else "assembleRelease"
    subprocess.run([gradle_executable, build_type])
    os.chdir("..")

def copy_aar(android_project_path, unity_project_path, is_debug):
    # Define source and destination folders
    source_folder = os.path.join(android_project_path, "app", "build", "outputs", "aar")
    destination_folder = os.path.join(unity_project_path, "Assets", "MirageWidget", "Plugins", "MirageWebViewPlugin", "Android")

    # Check if the source folder exists
    if os.path.exists(source_folder):
        # Find the app-release.aar file
        file_name = "app-debug.aar" if is_debug else "app-release.aar"
        file_copied = False
        
        for file in os.listdir(source_folder):
            if file.endswith(file_name):
                source_file = os.path.join(source_folder, file)
                destination_file = os.path.join(destination_folder, "mirage-webview.aar")

                # Copy and rename the file
                shutil.copyfile(source_file, destination_file)
                print(f"Copied and renamed {source_file} to {destination_file}")
                file_copied = True
                break

        if not file_copied:
            print(f"built plugin file {file_name} not found in {source_folder}")
    else:
        print(f"Source folder {source_folder} does not exist.")

if __name__ == "__main__":
    settings = load_settings()
    android_project_path = os.path.abspath(settings['AndroidProjectPath'])
    unity_project_path = os.path.abspath(settings['UnityProjectPath'])
    
    # If debug folder exists in the plugin sources in this case we build debug
    is_debug = os.path.exists(os.path.join(android_project_path, "app", "src", "debug"))

    build_project(android_project_path, is_debug)
    copy_aar(android_project_path, unity_project_path, is_debug)
