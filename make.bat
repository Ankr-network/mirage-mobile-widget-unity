set /p android_studio_path=<LocalAndroidStudioPath.txt
python build_and_copy_aar.py %android_studio_path%
pause