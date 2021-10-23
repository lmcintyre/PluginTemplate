import os
import sys

project_name = "{{ cookiecutter.project_name }}"
include_ui = "{{ cookiecutter.include_UI_project }}"
use_packager = "{{ cookiecutter.use_packager }}"
packager_targets = "{{ cookiecutter.packager_targets }}"
include_actions = "{{ cookiecutter.include_actions }}"

if use_packager == "no" and packager_targets == "yes":
    print("Cannot create a packager targets without enabling packager.")
    sys.exit(1)

if use_packager == "no" and include_actions == "yes":
    print("The included GitHub actions cannot be used without DalamudPackager.")
    sys.exit(1)