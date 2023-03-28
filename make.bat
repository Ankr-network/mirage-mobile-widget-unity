set /p android_studio_path=<LocalAndroidStudioPath.txt
python copy_aar.py %android_studio_path%
pause