using CommunityToolkit.Mvvm.ComponentModel;
using RS_test_paper.Models;
using CommunityToolkit.Mvvm.Input;

namespace RS_test_paper.ViewModels
{
    public partial class CheckBoxViewModel : ObservableObject
    {
        public Test Test { get; set; }
        public string Title => "Test " + Test.Major + "." + Test.Minor;
        // event handler for checkbox
        public IRelayCommand CheckBoxCommand { get; set; }

        [ObservableProperty]
        private bool isChecked;

        public CheckBoxViewModel(Test test)
        {
            Test = test;
            IsChecked = false;
        }

        // this will be bad for select all checkbox
        partial void OnIsCheckedChanged(bool value)
        {
            CheckBoxCommand.Execute(value);
        }
    }
}
