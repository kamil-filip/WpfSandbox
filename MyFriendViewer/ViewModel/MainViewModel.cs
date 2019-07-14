using MyFriendViewer.DataProvider;
using MyFriendViewer.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyFriendViewer.ViewModel
{
    public class MainViewModel : Observable
    {
        private readonly IFriendDataProvider _dataProvider;
        private Friend _selectedFriend;
        private bool _isLoading;


        public MainViewModel(IFriendDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Friends = new ObservableCollection<Friend>();

            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            IsLoading = true;

            try
            {
                var task = Task.Run(() => _dataProvider.LoadFriends());
                var friends = await task;

                foreach (var friend in friends)
                {
                    Friends.Add(friend);
                }

                SelectedFriend = Friends.Count > 0 ? Friends.First() : null;
            }
            finally
            {
                IsLoading = false;
            }
        }

        public ObservableCollection<Friend> Friends { get; set; }


        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }


        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
            }
        }
    }
}
