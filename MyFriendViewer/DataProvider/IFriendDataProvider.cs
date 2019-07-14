using MyFriendViewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFriendViewer.DataProvider
{
    public interface IFriendDataProvider
    {
        IEnumerable<Friend> LoadFriends();
    }
}
