using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Aasani.CRM.App
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public virtual void SetProperty<T>(ref T prop, T value, [CallerMemberName] string member = "")
        {
            prop = value;
            PropertyChanged(this, new PropertyChangedEventArgs(member));
        }
    }

    public class ValidateBindableBase : BindableBase, INotifyDataErrorInfo
    {

        private readonly Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();


        public bool HasErrors => errors.Keys.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public IEnumerable GetErrors(string propertyName)
        {
            if (!errors.ContainsKey(propertyName))
            {
                return null;
            }

            return errors[propertyName];
        }

        public override void SetProperty<T>(ref T prop, T value, [CallerMemberName] string member = "")
        {
            base.SetProperty(ref prop, value);
            Validate(member, value);
        }

        private void Validate<T>(string member, T value)
        {
            ValidationContext context = new ValidationContext(this)
            {
                MemberName = member
            };
            ICollection<ValidationResult> result = new List<ValidationResult>();
            bool isValid = Validator.TryValidateProperty(value, context, result);
            if (isValid)
            {
                _ = errors.Remove(member);
            }
            else
            {
                errors[member] = result.Select(r => r.ErrorMessage).ToList();
            }
            ErrorsChanged(this, new DataErrorsChangedEventArgs(member));
        }
    }
}
