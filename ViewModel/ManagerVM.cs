using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace key_managment_system.ViewModel
{
    public class ManagerVM : ObservableObject
    {
        private ManagerPageId _pageId;
        public ManagerPageId PageID
        {
            get { return _pageId; }
            set { SetProperty(ref _pageId, value); }
        }

        public ICommand CMDChangePage => new RelayCommand<ManagerPageId>(ChangePage); 
        void ChangePage(ManagerPageId pageId)
        {
            PageID = pageId;
        }
        public ManagerVM() { PageID = ManagerPageId.Visualisation; }  
    }
}
