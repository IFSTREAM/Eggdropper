import os.path
import re
import sublime_plugin

class ProjectSpecificFileSyntax(sublime_plugin.EventListener):
    def on_load(self, view):
        filename = view.file_name()
        if not filename:
            return

        syntax = self._get_project_specific_syntax(view, filename)
        if syntax:
            self._set_syntax(view, syntax)

    def _get_project_specific_syntax(self, view, filename):
        project_data = view.window().project_data()

        if not project_data:
            return None

        syntax_settings = project_data.get('syntax_override', {})

        for regex, syntax in syntax_settings.items():
            if re.search(regex, filename):
                return syntax

        return None

    def _set_syntax(self, view, syntax):
        syntax_path = os.path.join('Packages', *syntax)

        view.set_syntax_file('{0}.tmLanguage'.format(syntax_path))