using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Sensors;
using System.Diagnostics;
using Windows.UI.Core;
using Windows.UI;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AccelerometerDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Accelerometer acc;
        private uint _desiredReportInterval;
        public MainPage()
        {
            this.InitializeComponent();
            ScenarioOutput_X.Text = "X";
            ScenarioOutput_Y.Text = "Y";
            ScenarioOutput_Z.Text = "Z";
            acc = Accelerometer.GetDefault();
            if (acc != null)
            {
                // Select a report interval that is both suitable for the purposes of the app and supported by the sensor.
                // This value will be used later to activate the sensor.
                uint minReportInterval = acc.MinimumReportInterval;
                _desiredReportInterval = minReportInterval > 16 ? minReportInterval : 16;
            }
            else
            {
                Debug.Write("No accelerometer sensor found");
            }
        }

        private void EnableAcc_Click(object sender, RoutedEventArgs e)
        {
            if (acc != null)
            {
                // Establish the report interval
                acc.ReportInterval = _desiredReportInterval;

               // Window.Current.VisibilityChanged += new WindowVisibilityChangedEventHandler(VisibilityChanged);
                acc.ReadingChanged += new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(ReadingChanged);

              //  EnableAcc.IsEnabled = false;
            }
            else
            {
                Debug.Write("No Accelerometer found");
            }
        }

        async private void ReadingChanged(object sender, AccelerometerReadingChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                AccelerometerReading reading = e.Reading;
                ScenarioOutput_X.Text = "X = " + String.Format("{0,5:0.00}", reading.AccelerationX);
                ScenarioOutput_Y.Text = "Y = " + String.Format("{0,5:0.00}", reading.AccelerationY);
                ScenarioOutput_Z.Text = "Z = " + String.Format("{0,5:0.00}", reading.AccelerationZ);
                var newColor = new Color();
                newColor.A = 0xFF;

                int red = Math.Abs((int)(reading.AccelerationX * 100));
                int green = Math.Abs((int)(reading.AccelerationY * 100));
                int blue = Math.Abs((int)(reading.AccelerationZ * 100));

                newColor.R = byte.Parse(red.ToString());
                newColor.G = byte.Parse(green.ToString());
                newColor.B = byte.Parse(blue.ToString());

                ball.Fill = new SolidColorBrush(newColor);



            });
        }

    
    }
}
