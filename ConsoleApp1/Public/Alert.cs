using System;
using System.Collections.Generic; 

namespace Exercises
{
    public class AlertService
    {
        private IAlertDAO _iAlertDAO;

        public AlertService(IAlertDAO iAlertDAO)
        {
            _iAlertDAO = iAlertDAO;
        }
        private readonly AlertDAO storage = new AlertDAO();

        public Guid RaiseAlert()
        {
            return _iAlertDAO.AddAlert(DateTime.Now);
        }

        public DateTime GetAlertTime(Guid id)
        {
            return _iAlertDAO.GetAlert(id);
        }
    }

    public interface IAlertDAO
    {
        Guid AddAlert(DateTime time);
        DateTime GetAlert(Guid id);
    }

    public class AlertDAO : IAlertDAO
    {
        private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

        public Guid AddAlert(DateTime time)
        {
            Guid id = Guid.NewGuid();
            this.alerts.Add(id, time);
            return id;
        }

        public DateTime GetAlert(Guid id)
        {
            return this.alerts[id];
        }
    }

}
 