using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace find_all_here.ViewModels
{
    public class BaseViewModel
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public string GetRelativeTime(DateTime date)
        {
            var ts = DateTime.Now - date;
            if (ts.TotalDays > 365)
            {
                return $"Hace {ts.Days / 365} años";
            }
            if (ts.TotalDays > 30)
            {
                return $"Hace {ts.Days / 30} meses";
            }
            if (ts.TotalDays > 7)
            {
                return $"Hace {ts.Days / 7} semanas";
            }
            if (ts.TotalDays > 1)
            {
                return $"Hace {ts.Days} días";
            }
            if (ts.TotalHours > 1)
            {
                return $"Hace {ts.Hours} horas";
            }
            if (ts.TotalMinutes > 1)
            {
                return $"Hace {ts.Minutes} minutos";
            }
            if (ts.TotalSeconds > 1)
            {
                return $"Hace {ts.Seconds} segundos";
            }
            return "Ahora";
        }

        // Método público para hacer hash a un texto en sha256
        public string Sha256(string text)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(text));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}