import sys
import os
import shutil

project_name = "{{ cookiecutter.project_name }}"
include_ui = "{{ cookiecutter.include_UI_project }}"
include_goat = "{{ cookiecutter.include_goat }}"

def remove(filepath):
    if os.path.isfile(filepath):
        os.remove(filepath)
    elif os.path.isdir(filepath):
        shutil.rmtree(filepath)

if include_ui == "no":
    remove(os.path.join(os.getcwd(), "UIDev"))

if include_ui == "no" and include_goat == "no":
    remove(os.path.join(os.getcwd(), "Data"))