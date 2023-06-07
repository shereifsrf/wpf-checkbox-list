using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace RS_test_paper.ViewModels
{
    public partial class CheckBoxListViewModel : ObservableObject
    {
        public ObservableCollection<CheckBoxViewModel> TestCBList { get; set; }
        public string Title => "Test " + TestCBList[0].Test.Major;
        [ObservableProperty]
        private bool? isChecked = false;
        [ObservableProperty]
        private bool isExpanded = false;

        public CheckBoxListViewModel(ObservableCollection<CheckBoxViewModel> testCBList)
        {
            TestCBList = testCBList;
            foreach (var testCB in TestCBList)
            {
                testCB.CheckBoxCommand = new RelayCommand(HeaderCheckBox);
            }
        }

        /// <summary>
        /// When a checkbox value is changed, this method will be called
        /// This will make sure the parent checkbox is aligned with the children
        /// </summary>
        private void HeaderCheckBox()
        {
            var hasChecked = false;
            var hasUnchecked = false;
            for (int i = 0; i < TestCBList.Count; i++)
            {
                if (TestCBList[i].IsChecked) hasChecked = true;
                else hasUnchecked = true;

                if (hasChecked && hasUnchecked) break;
            }

            if (hasChecked && hasUnchecked) IsChecked = null;
            else IsChecked = hasChecked;
        }

        [RelayCommand]
        private void CheckBox()
        {
            // when this command occur, the checkbox must have clicked
            // so the IsChecked will be assigned first since in View its
            SetIsChedked(IsChecked);
        }

        /// <summary>
        /// Set all the children checkbox to the same value
        /// </summary>
        public void SetIsChedked(bool? value)
        {
            foreach (var testCB in TestCBList)
            {
                testCB.IsChecked = value ?? false;
            }
        }
    }
}
