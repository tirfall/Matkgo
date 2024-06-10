using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Matkgo.ViewModels;
using Matkgo.Views;

namespace Matkgo.ViewModels
{
    public class GuidesListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<GuideViewModel> Guides { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateGuideCommand { get; protected set; }
        public ICommand DeleteGuideCommand { get; protected set; }
        public ICommand SaveGuideCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }
        GuideViewModel selectedGuide;
        public INavigation Navigation { get; set; }
        public GuidesListViewModel() 
        { 
            Guides = new ObservableCollection<GuideViewModel>();
            CreateGuideCommand = new Command(CreateGuide);
            DeleteGuideCommand = new Command(DeleteGuide);
            SaveGuideCommand = new Command(SaveGuide);
            BackCommand = new Command(Back);
        }
        public GuideViewModel SelectedGuide
        {
            get { return selectedGuide; }
            set
            {
                if (selectedGuide == value) return;
                GuideViewModel temp = value;
                selectedGuide = null;
                OnPropertyChanged("selectedGuide");
                Navigation.PushAsync(new GuidePage(temp));
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private void CreateGuide() 
        { 
            Navigation.PushAsync(new GuidePage(new GuideViewModel() { GuidesListViewModel = this })); 
        }
        private void Back() { Navigation.PopAsync(); }
        private void SaveGuide(object guideObj)
        {
            if (guideObj is not GuideViewModel guide || guide == null || !guide.IsValid || Guides.Contains(guide)) return;
            Guides.Add(guide);
            Back();
        }
        private void DeleteGuide(object guideObj)
        {
            if (guideObj is not GuideViewModel guide || guide == null) return;
            Guides.Remove(guide);
            Back();
        }

    }
}
