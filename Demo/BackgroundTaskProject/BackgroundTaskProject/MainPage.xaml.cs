using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BackgroundTaskProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

       protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                  task.Value.Unregister(true);
     
     
             }
   
    var builder = new BackgroundTaskBuilder();
    builder.Name = "HelloWorld";
    builder.TaskEntryPoint = "BGTask.MyBackgroundTask";
    builder.SetTrigger(new SystemTrigger(SystemTriggerType.NetworkStateChange, false));
    var ret = builder.Register();
            
}
    }
}
