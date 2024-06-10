using System.ComponentModel;
using Matkgo.Models;
namespace Matkgo.ViewModels
{
    public class GuideViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        GuidesListViewModel glvm;
        public HikingGuide HikingGuide {  get; set; }
        public GuideViewModel()
        {
            HikingGuide = new HikingGuide();
        }
        public GuidesListViewModel GuidesListViewModel
        {
            get { return glvm; }
            set 
            {
                if (glvm == value) return;
                glvm = value;
                OnPropertyChanged("GuidesListViewModel");
            }
        }
        public string Title
        {
            get { return HikingGuide.Title; }
            set
            {
                if (HikingGuide.Title == value) return;
                HikingGuide.Title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Description
        {
            get { return HikingGuide.Description; }
            set
            {
                if (HikingGuide.Description == value) return;
                HikingGuide.Description = value;
                OnPropertyChanged("Description");
            }
        }
        public string Equipment
        {
            get { return HikingGuide.Equipment; }
            set
            {
                if (HikingGuide.Equipment == value) return;
                HikingGuide.Equipment = value;
                OnPropertyChanged("Equipment");
            }
        }
        public bool IsValid
        {
            get
            {
                return new string[]{Title, Description, Equipment }.Any(x => !string.IsNullOrEmpty(x?.Trim()));
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
