using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SerialComm
{
    public class ViewModelComm:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static readonly PropertyChangedEventArgs ReceiveTextPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(ReceiveText));
        private string _ReceiveText;
        public string ReceiveText
        {
            get => _ReceiveText;
            set
            {
                _ReceiveText = value;
                this.PropertyChanged?.Invoke(this, ReceiveTextPropertyChangedEventArgs);
            }
        }


        private static readonly PropertyChangedEventArgs SendTextPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(SendText));
        private string _SendText;
        public string SendText
        {
            get => _SendText;
            set
            {
                _SendText = value;
                this.PropertyChanged?.Invoke(this, SendTextPropertyChangedEventArgs);
            }
        }

    }
}
