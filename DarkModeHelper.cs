using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DarkModeLibrary
{

    public static class DarkModeHelper
    {


        //private static Color darkModeBackgroundColor = Color.FromArgb(105, 105, 105); // Visual Studio dark mode color
        // private static Color darkModeTextColor = Color.White;
        private static bool isDarkModeEnabled = false;

        public static bool IsDarkModeEnabled
        {
            get { return isDarkModeEnabled; }
            set { isDarkModeEnabled = value; }
        }

        public static void EnableDarkMode(params Form[] forms)
        {
            Color darkModeBackgroundColor = Color.FromArgb(105, 105, 105);
            Color darkModeTextColor = Color.White;

            foreach (Form form in forms)
            {
                form.BackColor = darkModeBackgroundColor;
                form.ForeColor = darkModeTextColor;

                EnableDarkModeForControls(form.Controls);
            }
        }

        private static void EnableDarkModeForControls(Control.ControlCollection controls)
        {
            Color darkModeBackgroundColor = Color.FromArgb(105, 105, 105);
            Color darkModeTextColor = Color.White;

            foreach (Control control in controls)
            {
                if (control is Button button)
                {
                    button.BackColor = darkModeBackgroundColor;
                    button.ForeColor = darkModeTextColor;
                }
                else if (control is GroupBox groupBox)
                {
                    groupBox.BackColor = darkModeBackgroundColor;
                    groupBox.ForeColor = darkModeTextColor;

                    EnableDarkModeForControls(groupBox.Controls);
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = darkModeBackgroundColor;
                    comboBox.ForeColor = darkModeTextColor;
                }
                else if (control is MenuStrip menuStrip)
                {
                    EnableDarkModeForMenuStrip(menuStrip);
                }
            }
        }

        public static void DisableDarkMode(params Form[] forms)
        {
            Color defaultBackgroundColor = SystemColors.Control;
            Color defaultTextColor = SystemColors.ControlText;

            foreach (Form form in forms)
            {
                form.BackColor = defaultBackgroundColor;
                form.ForeColor = defaultTextColor;

                DisableDarkModeForControls(form.Controls);
            }
        }

        private static void DisableDarkModeForControls(Control.ControlCollection controls)
        {
            Color defaultBackgroundColor = SystemColors.Control;
            Color defaultTextColor = SystemColors.ControlText;

            foreach (Control control in controls)
            {
                if (control is Button button)
                {
                    button.BackColor = defaultBackgroundColor;
                    button.ForeColor = defaultTextColor;
                }
                else if (control is GroupBox groupBox)
                {
                    groupBox.BackColor = defaultBackgroundColor;
                    groupBox.ForeColor = defaultTextColor;

                    DisableDarkModeForControls(groupBox.Controls);
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = defaultBackgroundColor;
                    comboBox.ForeColor = defaultTextColor;
                }
                else if (control is MenuStrip menustrip)
                {
                    DisableDarkModeForMenuStrip(menustrip);
                }
            }
        }

        private static void EnableDarkModeForMenuStrip(MenuStrip menuStrip)
        {
            Color darkModeBackgroundColor = Color.FromArgb(105, 105, 105);
            Color darkModeTextColor = Color.White;

            menuStrip.BackColor = darkModeBackgroundColor;
            menuStrip.ForeColor = darkModeTextColor;

            foreach (ToolStripItem menuItem in menuStrip.Items)
            {
                if (menuItem is ToolStripDropDownItem dropDownItem)
                {
                    // Enable dark mode for drop-down items
                    EnableDarkModeForToolStripDropDownItem(dropDownItem);
                }
                else if (menuItem is ToolStripMenuItem toolStripMenuItem)
                {
                    // Enable dark mode for regular menu items
                    toolStripMenuItem.BackColor = darkModeBackgroundColor;
                    toolStripMenuItem.ForeColor = darkModeTextColor;

                    if (toolStripMenuItem.DropDown != null)
                    {
                        // Enable dark mode for drop-down list of regular menu items
                        EnableDarkModeForToolStripDropDown(toolStripMenuItem.DropDown);
                    }
                }
            }
        }

        private static void EnableDarkModeForToolStripDropDown(ToolStripDropDown dropDown)
        {
            Color darkModeBackgroundColor = Color.FromArgb(105, 105, 105);
            Color darkModeTextColor = Color.White;

            dropDown.BackColor = darkModeBackgroundColor;
            dropDown.ForeColor = darkModeTextColor;

            foreach (ToolStripItem item in dropDown.Items)
            {
                if (item is ToolStripDropDownItem subDropDownItem)
                {
                    // Enable dark mode for sub drop-down items
                    EnableDarkModeForToolStripDropDownItem(subDropDownItem);
                }
                else
                {
                    // Enable dark mode for regular sub items
                    item.BackColor = darkModeBackgroundColor;
                    item.ForeColor = darkModeTextColor;
                }
            }
        }

        private static void EnableDarkModeForToolStripDropDownItem(ToolStripDropDownItem dropDownItem)
        {
            Color darkModeBackgroundColor = Color.FromArgb(105, 105, 105);
            Color darkModeTextColor = Color.White;

            dropDownItem.BackColor = darkModeBackgroundColor;
            dropDownItem.ForeColor = darkModeTextColor;

            foreach (ToolStripItem subItem in dropDownItem.DropDownItems)
            {
                if (subItem is ToolStripDropDownItem subDropDownItem)
                {
                    // Enable dark mode for sub drop-down items
                    EnableDarkModeForToolStripDropDownItem(subDropDownItem);
                }
                else
                {
                    // Enable dark mode for regular sub items
                    subItem.BackColor = darkModeBackgroundColor;
                    subItem.ForeColor = darkModeTextColor;
                }
            }
        }

        private static void DisableDarkModeForMenuStrip(MenuStrip menuStrip)
        {
            Color defaultBackgroundColor = SystemColors.Control;
            Color defaultTextColor = SystemColors.ControlText;

            menuStrip.BackColor = defaultBackgroundColor;
            menuStrip.ForeColor = defaultTextColor;

            foreach (ToolStripItem menuItem in menuStrip.Items)
            {
                if (menuItem is ToolStripDropDownItem dropDownItem)
                {
                    // Disable dark mode for drop-down items
                    DisableDarkModeForToolStripDropDownItem(dropDownItem);
                }
                else if (menuItem is ToolStripMenuItem toolStripMenuItem)
                {
                    // Disable dark mode for regular menu items
                    toolStripMenuItem.BackColor = defaultBackgroundColor;
                    toolStripMenuItem.ForeColor = defaultTextColor;

                    if (toolStripMenuItem.DropDown != null)
                    {
                        // Disable dark mode for drop-down list of regular menu items
                        DisableDarkModeForToolStripDropDown(toolStripMenuItem.DropDown);
                    }
                }
            }
        }

        private static void DisableDarkModeForToolStripDropDown(ToolStripDropDown dropDown)
        {
            Color defaultBackgroundColor = SystemColors.Control;
            Color defaultTextColor = SystemColors.ControlText;

            dropDown.BackColor = defaultBackgroundColor;
            dropDown.ForeColor = defaultTextColor;

            foreach (ToolStripItem item in dropDown.Items)
            {
                if (item is ToolStripDropDownItem subDropDownItem)
                {
                    // Disable dark mode for sub drop-down items
                    DisableDarkModeForToolStripDropDownItem(subDropDownItem);
                }
                else
                {
                    // Disable dark mode for regular sub items
                    item.BackColor = defaultBackgroundColor;
                    item.ForeColor = defaultTextColor;
                }
            }
        }

        private static void DisableDarkModeForToolStripDropDownItem(ToolStripDropDownItem dropDownItem)
        {
            Color defaultBackgroundColor = SystemColors.Control;
            Color defaultTextColor = SystemColors.ControlText;

            dropDownItem.BackColor = defaultBackgroundColor;
            dropDownItem.ForeColor = defaultTextColor;

            foreach (ToolStripItem subItem in dropDownItem.DropDownItems)
            {
                if (subItem is ToolStripDropDownItem subDropDownItem)
                {
                    // Disable dark mode for sub drop-down items
                    DisableDarkModeForToolStripDropDownItem(subDropDownItem);
                }
                else
                {
                    // Disable dark mode for regular sub items
                    subItem.BackColor = defaultBackgroundColor;
                    subItem.ForeColor = defaultTextColor;
                }
            }
        }
        public static void ApplyDarkMode(Form form)
        {
            if (isDarkModeEnabled)
            {
                EnableDarkMode(form);
            }
            else
            {
                DisableDarkMode(form);
            }
        }
        public static class ThemeHelper
        {
            public static void LightModeTheme(Control control)
            {
                control.BackColor = SystemColors.Control;
                control.ForeColor = SystemColors.ControlText;

                foreach (Control childControl in control.Controls)
                {
                    LightModeTheme(childControl);
                }
            }

            public static void DarkModeTheme(Control control)
            {
                control.BackColor = Color.FromArgb(105, 105, 105);
                control.ForeColor = Color.White;

                foreach (Control childControl in control.Controls)
                {
                    DarkModeTheme(childControl);
                }
            }
        }
        public static class DarkTitleBarClass
        {
            [DllImport("dwmapi.dll")]
            private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

            private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
            private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

            public static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
            {
                if (IsWindows10OrGreater(17763))
                {
                    var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                    if (IsWindows10OrGreater(18985))
                    {
                        attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                    }

                    int useImmersiveDarkMode = enabled ? 1 : 0;
                    return DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
                }

                return false;
            }

            private static bool IsWindows10OrGreater(int build = -1)
            {
                return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
            }
        }
    }
}