#!/bin/bash
android_studio_path=$(cat LocalAndroidStudioPath.txt)
python3 build_and_copy_aar.py "$android_studio_path"