# PluginTemplate
This is a template for generating a Dalamud Plugin using [cookiecutter](https://github.com/cookiecutter/cookiecutter). The default values are meant to keep the generated project in line with the [sample plugin](https://github.com/goatcorp/SamplePlugin), but there are many options for the generated project. "Template options" below lists all options that will be prompted on project generation. Please note that all generated values can be changed after generating... obviously.

## Usage

The simplest usage is to install Python for your platform. **NOTE:** *If you are on Windows, you may have to add your Python* `Scripts` *folder to your* `PATH` *before* `cookiecutter` *will be available from the command line.*

Once installed, you can copy the link to any release zip on the right side of this GitHub repository, and use cookiecutter like so:

```cookiecutter https://github.com/lmcintyre/PluginTemplate/releases/download/0.0.9/PluginTemplate.zip```

Cookiecutter will download the template zip, extract it, and perform generation all in one go. Future generations will ask you if you want to redownload or use the cached template zip.

There are many more options for cookiecutter generation, as it is not required to use the zip file or be prompted for options each time. You can clone this repository or download it as a zip file and modify the template yourself for your own personal usage. For more information on generating templates, check out the [cookiecutter documentation](https://cookiecutter.readthedocs.io/en/1.7.2/).


## Template options
### ```project_name```

The name of the **project folder**, the C# **solution file**, **csproj**, **internal plugin name**, **main plugin class**, and **main plugin UI class** (with UI appended), and **output dll**.

### ```public_name```

The user-facing name of the plugin. This is the name that users will see in the **plugin installer** and their **plugin list**.

### ```author```

The author of the plugin. This is the name that users will see as the author in the **dll file properties** and the  **plugin installer**.

### ```description```

A description of the plugin. This will appear in the **dll file properties** and the **plugin installer**.

### ```project_repo```

The repository of the plugin. This will be available as a clickable link in the **plugin installer**.

### ```main_command```

The main command for your plugin. This is not necessarily required, but almost every plugin has a configuration menu or some sort of UI available via an in-game command. Please note the leading slash is ommitted in generation!

### ```main_command_help```

The help message for your plugin. This appears as a message when a user types **/xlhelp** in-game. Most plugin developers include their main command and a description, or a list of commands and what they do.

### ```include_comments```

Option to include relatively helpful comments in the project. This is recommended for your first plugin and getting familiar with the sample plugin.

### ```include_readme```

Option to include a readme file in the generated project.

### ```include_UI_project```

Option to include an ImGui UI testbed project with the generated project. Most experienced ImGui or plugin developers do not need this, and new devs also might not if they use [LivePluginLoader](https://github.com/caraxi/livepluginload), but it is a quick and easy way to get a feel for ImGui.

### ```include_goat```

Option to include a goat image in the sample plugin's user interface code. This is an example of loading an image as a texture and displaying it in ImGui, so it is useful as example code if that is one of your goals.

### ```project_style```

Option to change the C# project style. The current sample plugin uses the non-SDK project style, which is arguably more difficult to maintain and is spread across the csproj and AssemblyInfo.cs files. The SDK style is modern, more compact, and supports DalamudPackager.

### ```use_packager```

For easier deployment of plugins, [DalamudPackager](https://github.com/goatcorp/dalamudpackager) is an option. This option will add the DalamudPackager nuget package to your project, which will produce a deployment-ready `latest.zip` and `project_name.json` file on every build.

This option will fail the generation if set to `yes` while  `project_style` is set to `nonSDK`.

### ```packager_targets```

Generates a DalamudPackager.targets file for use with DalamudPackager. This is useful for explicitly defining which files should be included when packing the `latest.zip` file for deployment, specifically when you have extra resources with your plugin such as an image or static data files.

This option will fail the generation if set to `yes` while `use_packager` is set to `no`.

### ```include_actions```

Option to include GitHub actions for building your plugin. This will include two actions, one for build on push, and one to create a release when a commit is tagged with a version number. For example, pushing a commit will create a build with the contents of the Release folder as artifacts. Pushing a tag "1.0.1.0" will build and create a Release on GitHub named `project_name 1.0.1.0`, attaching the `latest.zip` file produced by DalamudPackager.

This option will fail the generation if set to `yes` while `use_packager` is set to `no`, but only to avoid actions not working as expected immediately. Feel free to copy and modify the actions manually.