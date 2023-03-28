#!/bin/bash
android_studio_path=$(cat LocalAndroidStudioPath.txt)
python3 copy_aar.py "$android_studio_path"