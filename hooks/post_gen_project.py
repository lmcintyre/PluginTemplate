import sys
import os
import shutil

project_name = "{{ cookiecutter.project_name }}"
include_ui = "{{ cookiecutter.include_UI_project }}"
project_style = "{{ cookiecutter.project_style }}"
include_actions = "{{ cookiecutter.include_actions }}"
include_goat = "{{ cookiecutter.include_goat }}"

def remove(filepath):
    if os.path.isfile(filepath):
        os.remove(filepath)
    elif os.path.isdir(filepath):
        shutil.rmtree(filepath)

if include_ui == "no":
    remove(os.path.join(os.getcwd(), "UIDev"))

if project_style == "SDK":
    remove(os.path.join(os.getcwd(), project_name, "Properties"))

if include_actions == "no":
    remove(os.path.join(os.getcwd(), ".github"))

if include_ui == "no" and include_goat == "no":
    remove(os.path.join(os.getcwd(), "Data"))