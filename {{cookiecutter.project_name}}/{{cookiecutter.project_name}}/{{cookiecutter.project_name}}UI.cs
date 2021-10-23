using ImGuiNET;
using System;
using System.Numerics;

namespace {{cookiecutter.project_name}}
{
    {% if cookiecutter.include_comments == "yes" %}
    // It is good to have this be disposable in general, in case you ever need it to do any cleanup
    {% endif -%}
    class {{cookiecutter.project_name}}UI : IDisposable
    {
        private Configuration configuration;

        {%- if cookiecutter.include_goat == "yes" %}
        private ImGuiScene.TextureWrap goatImage;
        {%- endif %}
        {% if cookiecutter.include_comments == "yes" %}
        // this extra bool exists for ImGui, since you can't ref a property
        {%- endif %}
        private bool visible = false;
        public bool Visible
        {
            get { return this.visible; }
            set { this.visible = value; }
        }

        private bool settingsVisible = false;
        public bool SettingsVisible
        {
            get { return this.settingsVisible; }
            set { this.settingsVisible = value; }
        }
        {% if cookiecutter.include_comments == "yes" and cookiecutter.include_goat == "yes" %}
        // passing in the image here just for simplicity
        {%- endif %}
        {% if cookiecutter.include_goat == "yes" -%}
        public {{cookiecutter.project_name}}UI(Configuration configuration, ImGuiScene.TextureWrap goatImage)
        {%- else -%}
        public {{cookiecutter.project_name}}UI(Configuration configuration)
        {%- endif %}
        {
            this.configuration = configuration;
            {%- if cookiecutter.include_goat == "yes" %}
            this.goatImage = goatImage;
            {%- endif %}
        }

        public void Dispose()
        {
            {% if cookiecutter.include_goat == "yes" -%}
            this.goatImage.Dispose();
            {%- endif %}
        }

        public void Draw()
        {
            {% if cookiecutter.include_comments == "yes" -%}
            // This is our only draw handler attached to UIBuilder, so it needs to be
            // able to draw any windows we might have open.
            // Each method checks its own visibility/state to ensure it only draws when
            // it actually makes sense.
            // There are other ways to do this, but it is generally best to keep the number of
            // draw delegates as low as possible.
            {% endif -%}
            DrawMainWindow();
            DrawSettingsWindow();
        }

        public void DrawMainWindow()
        {
            if (!Visible)
            {
                return;
            }

            ImGui.SetNextWindowSize(new Vector2(375, 330), ImGuiCond.FirstUseEver);
            ImGui.SetNextWindowSizeConstraints(new Vector2(375, 330), new Vector2(float.MaxValue, float.MaxValue));
            if (ImGui.Begin("My Amazing Window", ref this.visible, ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse))
            {
                ImGui.Text($"The random config bool is {this.configuration.SomePropertyToBeSavedAndWithADefault}");

                if (ImGui.Button("Show Settings"))
                {
                    SettingsVisible = true;
                }
                {%- if cookiecutter.include_goat == "yes" %}

                ImGui.Spacing();
                ImGui.Text("Have a goat:");
                ImGui.Indent(55);
                ImGui.Image(this.goatImage.ImGuiHandle, new Vector2(this.goatImage.Width, this.goatImage.Height));
                ImGui.Unindent(55);
                {%- endif %}
            }
            ImGui.End();
        }

        public void DrawSettingsWindow()
        {
            if (!SettingsVisible)
            {
                return;
            }

            ImGui.SetNextWindowSize(new Vector2(232, 75), ImGuiCond.Always);
            if (ImGui.Begin("A Wonderful Configuration Window", ref this.settingsVisible,
                ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse))
            {
                {% if cookiecutter.include_comments == "yes" -%}
                // can't ref a property, so use a local copy
                {% endif -%}
                var configValue = this.configuration.SomePropertyToBeSavedAndWithADefault;
                if (ImGui.Checkbox("Random Config Bool", ref configValue))
                {
                    this.configuration.SomePropertyToBeSavedAndWithADefault = configValue;
                    {% if cookiecutter.include_comments == "yes" -%}
                    // can save immediately on change, if you don't want to provide a "Save and Close" button
                    {% endif -%}
                    this.configuration.Save();
                }
            }
            ImGui.End();
        }
    }
}
