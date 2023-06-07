using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS_test_paper.ViewModels.Tests;

namespace RS_test_paper.ViewModels
{
    public class MainViewModel
    {
        public TestsViewModel TestsVM { get; set; }

        public MainViewModel()
        {
            TestsVM = new TestsViewModel();
        }
    }
}
