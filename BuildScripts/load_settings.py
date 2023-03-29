import os
import json

def read_settings(file_path):
    with open(file_path, 'r') as file:
        return json.load(file)

def load_settings():
    settings_file = "LocalBuildSettings.txt"
    if os.path.isfile(settings_file):
        folder_path = os.path.abspath(".")
        full_path = os.path.join(folder_path, settings_file)
        settings = read_settings(full_path)
        return settings
    else:
        raise FileNotFoundError(f"Settings file {settings_file} does not exist. You might need to create it because it is in the gitignore")
      