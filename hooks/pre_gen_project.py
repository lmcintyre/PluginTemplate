import os
import sys

project_name = "{{ cookiecutter.project_name }}"
include_ui = "{{ cookiecutter.include_UI_project }}"
project_style = "{{ cookiecutter.project_style }}"
use_packager = "{{ cookiecutter.use_packager }}"
packager_targets = "{{ cookiecutter.packager_targets }}"
include_actions = "{{ cookiecutter.include_actions }}"

if project_style == "nonSDK" and use_packager == "yes":
    print("Project must be SDK style to use DalamudPackager.")
    sys.exit(1)

if use_packager == "no" and packager_targets == "yes":
    print("Cannot create a packager targets without enabling packager.")
    sys.exit(1)
