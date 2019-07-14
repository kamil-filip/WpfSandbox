using MyFriendViewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyFriendViewer.DesignTimeData
{
    public class DesignFriend : Friend
    {
        public DesignFriend()
        {
            FirstName = "Thomas";
            LastName = "Huber";
            CellPhone = "+49 (0) 123456789";
            Email = "thomas@thomasclaudiushuber.com";
            Homepage = "www.thomasclaudiushuber.com";
            SetImageProperty();
        }

        private void SetImageProperty()
        {
            var streamResourceInfo =
                Application.GetResourceStream(
                new Uri("MyFriendViewer;component/DesignTimeData/Images/thomas.jpg", UriKind.Relative));

            var length = streamResourceInfo.Stream.Length;
            byte[] image = new byte[length];
            streamResourceInfo.Stream.Read(image, 0, (int)length);

            Image = image;
        }
    }
}
