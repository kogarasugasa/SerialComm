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
using Windows.Devices.SerialCommunication;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace SerialComm
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public async void Test()
        {
            string portName = "COM5";
            string aqs = SerialDevice.GetDeviceSelector(portName);

            var myDevices = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(aqs, null);

            if(myDevices.Count == 0)
            {
                return;
            }

            var device = await SerialDevice.FromIdAsync(myDevices[0].Id);
            device.BaudRate = 9600;
            device.DataBits = 8;
            device.StopBits = SerialStopBitCount.One;
            device.Parity = SerialParity.None;
            device.Handshake = SerialHandshake.None;
            device.ReadTimeout = TimeSpan.FromMilliseconds(1000);
            device.WriteTimeout = TimeSpan.FromMilliseconds(1000);



        }
    }
}
