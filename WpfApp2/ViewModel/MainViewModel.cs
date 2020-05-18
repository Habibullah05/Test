using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Models.Service;
using WpfApp2.Repository;

namespace WpfApp2.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        private readonly IMessageService _messageSend;
        public MainViewModel(IMessageService messageSend)
        {
            _messageSend = messageSend;
            var message=_messageSend.GetEndText();
            Text = message?.Text;
        }

        private ICommand _sendMessage;
        public ICommand SendMessage_Click => _sendMessage ?? (_sendMessage = new RelayCommand(() =>
        {

            _messageSend.AddMessage(Text);
            Text = "";
        })); 

        private string _text= "";
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                if (!string.IsNullOrEmpty( _text))
                {
                    IsEnabled = true;
                  
                }
                else
                {
                    IsEnabled = false;
                   
                }
            }
        }

        private bool _isEnabled = false;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged();
               
            }
        }
    }
}