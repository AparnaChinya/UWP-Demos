using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.Data.Xml.Dom;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ToastDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string TOAST_IMAGE_SRC = "Assets/StoreLogo.png";
        string ALT_TEXT = "Alternate Text";
        public MainPage()
        {
            this.InitializeComponent();
       
            
        }

        private void SendToast_Click(object sender, RoutedEventArgs e)
        {
            //string toastXmlString = string.Empty;
            //toastXmlString = "<toast>"
            //              + "<visual version='1'>"
            //              + "<binding template='toastImageAndText02'>"
            //              + "<text id='1'>Body text that wraps over three lines</text>"
            //              + "<image id='1' src='" + TOAST_IMAGE_SRC + "' alt='" + ALT_TEXT + "'/>"
            //              + "</binding>"
            //              + "</visual>"
            //              + "</toast>";
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText04;
           
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            //toastXml.LoadXml(toastXmlString);
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);

        }



    }
}
