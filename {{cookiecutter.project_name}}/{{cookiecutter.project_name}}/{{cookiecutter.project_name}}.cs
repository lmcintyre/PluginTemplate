using Dalamud.Game.Command;
using Dalamud.Plugin;
using System;
using System.IO;
using System.Reflection;

namespace {{cookiecutter.project_name}}
{
    public class {{cookiecutter.project_name}} : IDalamudPlugin
    {
        public string Name => "{{cookiecutter.public_name}}";

        private const string commandName = "/{{cookiecutter.main_command}}";

        private DalamudPluginInterface pi;
        private Configuration configuration;
        private PluginUI ui;

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            this.pi = pluginInterface;
            
            this.configuration = this.pi.GetPluginConfig() as Configuration ?? new Configuration();
            this.configuration.Initialize(this.pi);

            {% if cookiecutter.include_comments == "yes" -%}
            // you might normally want to embed resources and load them from the manifest stream
            {%- endif -%}
            {% if cookiecutter.include_goat == "yes" -%}
            var imagePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"goat.png");
            var goatImage = this.pi.UiBuilder.LoadImage(imagePath);
            this.ui = new PluginUI(this.configuration, goatImage);
            {%- else -%}
            this.ui = new PluginUI(this.configuration);
            {%- endif -%}

            this.pi.CommandManager.AddHandler(commandName, new CommandInfo(OnCommand)
            {
                HelpMessage = "{{cookiecutter.main_command_help}}"
            });

            this.pi.UiBuilder.OnBuildUi += DrawUI;
            this.pi.UiBuilder.OnOpenConfigUi += (sender, args) => DrawConfigUI();
        }

        public void Dispose()
        {
            this.ui.Dispose();

            this.pi.CommandManager.RemoveHandler(commandName);
            this.pi.Dispose();
        }

        private void OnCommand(string command, string args)
        {
            {% if cookiecutter.include_comments == "yes" -%}
            // in response to the slash command, just display our main ui
            {%- endif -%}
            this.ui.Visible = true;
        }

        private void DrawUI()
        {
            this.ui.Draw();
        }

        private void DrawConfigUI()
        {
            this.ui.SettingsVisible = true;
        }
    }
}
