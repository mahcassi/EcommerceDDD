using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notifications
{
    public class Notifiers
    {
        public Notifiers()
        {
            Notifications = new List<Notifiers>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notifiers> Notifications;

        public bool ValidatePropertyString(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifiers { PropertyName = propertyName, Message = "Campo obrigatório" });
                return false;
            }

            return true;
        }

        public bool ValidatePropertyInt(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifiers { PropertyName = propertyName, Message = "Valor deve ser  maior que 0" });
                return false;
            }

            return true;
        }

        public bool ValidatePropertyDecimal(decimal value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifiers { PropertyName = propertyName, Message = "Valor deve ser  maior que 0" });
                return false;
            }

            return true;
        }

    }
}
