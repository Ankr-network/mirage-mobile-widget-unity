import os
import shutil
import subprocess
import sys

def build_project(android_studio_path):
    if os.name == 'nt':
        gradle_executable = "gradlew.bat"
    else:
        gradle_executable = "./gradlew"
    
    os.chdir("Mirage-Android-WebView-Plugin")
    subprocess.run([gradle_executable, "clean"])
    subprocess.run([gradle_executable, "assembleRelease"])
    os.chdir("..")

if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Please provide the path to the Android Studio installation folder.")
        sys.exit(1)

    android_studio_path = sys.argv[1]
    build_project(android_studio_path)

    # Define source and destination folders
    source_folder = os.path.join("Mirage-Android-WebView-Plugin", "app", "build", "outputs", "aar")
    destination_folder = os.path.join("Mirage-Widget", "Assets", "MirageWidget", "Plugins", "MirageWebViewPlugin", "Android")
    
    # Check if the source folder exists
    if os.path.exists(source_folder):
        # Find the app-release.aar file
        file_name = "app-release.aar"
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