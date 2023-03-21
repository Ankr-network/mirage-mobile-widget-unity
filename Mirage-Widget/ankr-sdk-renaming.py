import os

def is_desired_extension(filename):
    desired_extensions = ['.cs', '.csproj', '.asmdef', '.asset', '.prefab', '.sln']
    _, file_extension = os.path.splitext(filename)
    return file_extension in desired_extensions

def replace_filename(root_folder, old_string, new_string):
    for foldername, _, filenames in os.walk(root_folder):
        for filename in filenames:
            if old_string in filename and is_desired_extension(filename):
                old_filepath = os.path.join(foldername, filename)
                new_filename = filename.replace(old_string, new_string)
                new_filepath = os.path.join(foldername, new_filename)
                try:
                    os.rename(old_filepath, new_filepath)
                except Exception as e:
                    print(f'failed renaming {old_filepath} to {new_filename}')   
                    continue
                print(f'renaming {old_filepath} to {new_filename}')

def replace_in_file(file_path, old_string, new_string):
    try:
        with open(file_path, "r") as file:
            content = file.read()
    except Exception as e:
        return

    replaced_content = content.replace(old_string, new_string)

    if content != replaced_content:
        with open(file_path, "w") as file:
            file.write(replaced_content)

def replace_substring_recursively(root_folder, old_string, new_string):
    own_basename = os.path.basename(__file__)
    for foldername, _, filenames in os.walk(root_folder):
        for filename in filenames:
            
            if own_basename in filename or not is_desired_extension(filename):
                continue
                
            file_path = os.path.join(foldername, filename)
            replace_in_file(file_path, old_string, new_string)
            print(f'replacing in {file_path}')
            
            
def replace_foldername(root_folder, old_string, new_string):
    for foldername, _, _ in os.walk(root_folder):
        if old_string in foldername:
            new_foldername = foldername.replace(old_string, new_string)
            
            try:
                os.rename(foldername, new_foldername)
            except Exception as e:
                print(f'failed renaming folder {foldername} to {new_foldername}')           
                continue
                   
            print(f'renaming folder {foldername} to {new_foldername}')              

if __name__ == "__main__":
    root_folder = "."
    old_string = "AnkrSDK"
    new_string = "MirageSDK"

    replace_filename(root_folder, old_string, new_string)
    replace_substring_recursively(root_folder, old_string, new_string)
    replace_foldername(root_folder, old_string, new_string)