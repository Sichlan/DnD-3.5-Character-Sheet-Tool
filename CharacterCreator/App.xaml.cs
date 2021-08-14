using CharacterCreator.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace CharacterCreator
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string localization = "de-DE";
#if (DEBUG == false)
            if (String.IsNullOrEmpty(CharacterCreator.Properties.Settings.Default.StandardLocalization))
            {
                string sysLang = CultureInfo.CurrentCulture.Name;
                if(MessageBox.Show($"You have not set a standard localization for this app.\nYour system language is set to {CultureInfo.CurrentCulture.DisplayName}.\nDo you want to set your default language for this application to {CultureInfo.CurrentCulture.DisplayName}?", "Select language", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    localization = sysLang;
                    CharacterCreator.Properties.Settings.Default.StandardLocalization = sysLang;
                }
            }
            else
            {
                localization = CharacterCreator.Properties.Settings.Default.StandardLocalization;
            }
#endif
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(localization);
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(localization);
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(System.Windows.Markup.XmlLanguage.GetLanguage(new CultureInfo(localization).IetfLanguageTag)));



            DebugLogger.SetupDebugLogger();
        }

        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Process unhandled exception
            DebugLogger.WriteLog(e.Exception.Message + "\n" + e.Dispatcher.ToString(), DebugLogger.LogLevel.FATAL);
            // Prevent default unhandled exception processing
            e.Handled = true;
        }
    }
}
