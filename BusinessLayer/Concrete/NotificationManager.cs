using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;
      
        public NotificationManager (INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public List<Notification> GetList()
        {
           return _notificationDal.GetListAll();
        }

        public List<Notification> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Notification t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Notification t)
        {
            _notificationDal.Delete(t);
        }

        public Notification TGetByIdd(int id)
        {
            return _notificationDal.GetById(id);
        }

        public void TUpdate(Notification t)
        {
            throw new NotImplementedException();
        }
    }
}
