using CommunityToolkit.Mvvm.ComponentModel;
using RS_test_paper.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace RS_test_paper.ViewModels.Tests
{

    public partial class TestsViewModel : ObservableObject
    {
        public ObservableCollection<CheckBoxListViewModel> Tests { get; set; }
        [ObservableProperty]
        private bool isAllExpanded = false;
        public TestsViewModel()
        {
            Tests = new ObservableCollection<CheckBoxListViewModel>()
            {
                new CheckBoxListViewModel(new ObservableCollection<CheckBoxViewModel>
                {
                    new CheckBoxViewModel(new Test(1, 1)),
                    new CheckBoxViewModel(new Test(1, 2)),
                    new CheckBoxViewModel(new Test(1, 3)),
                    new CheckBoxViewModel(new Test(1, 4)),
                }),
                new CheckBoxListViewModel(new ObservableCollection<CheckBoxViewModel>
                {
                    new CheckBoxViewModel(new Test(2, 1)),
                    new CheckBoxViewModel(new Test(2, 2)),
                    new CheckBoxViewModel(new Test(2, 3)),
                })
            };

            // when any checkbox is checked, trigger CanExecuteCommand
            // this is to enable bottom buttons
            foreach (CheckBoxListViewModel test in Tests)
            {
                test.PropertyChanged += (object? sender, System.ComponentModel.PropertyChangedEventArgs e) =>
                {
                    if (e.PropertyName == nameof(CheckBoxListViewModel.IsChecked))
                    {
                        BackCommand.NotifyCanExecuteChanged();
                        StartCommand.NotifyCanExecuteChanged();
                    }
                };
            };
        }

        [RelayCommand(CanExecute = nameof(CanExecuteCommand))]
        private void Back()
        {
            // find if any check box is checked
            foreach (var test in Tests)
            {
                test.SetIsChedked(false);
            }
        }

        [RelayCommand(CanExecute = nameof(CanExecuteCommand))]
        private void Start()
        {
            // show popup message with name of checked checkbox
            var message = "";
            foreach (var test in Tests)
            {
                foreach (var testCB in test.TestCBList)
                {
                    if (testCB.IsChecked) message += testCB.Title + "\n";
                }
            }
            MessageBox.Show(message);
        }

        private bool CanExecuteCommand()
        {
            foreach (var test in Tests)
            {
                if (test.IsChecked != false) return true;
            }
            return false;
        }

        [RelayCommand]
        private void Expand()
        {
            IsAllExpanded = true;
            foreach (var test in Tests)
            {
                test.IsExpanded = true;
            }
        }

        [RelayCommand]
        private void Collapse()
        {
            IsAllExpanded = false;
            foreach (var test in Tests)
            {
                test.IsExpanded = false;
            }
        }
    }
}
