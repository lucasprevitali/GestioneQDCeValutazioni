using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QDCeValutazioni.WPF.Models;

namespace QDCeValutazioni.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region =================== costanti ===================
        #endregion

        #region =================== membri statici =============
        #endregion

        #region =================== membri & proprietà =========
        public event PropertyChangedEventHandler PropertyChanged;
        private Main model;
        #endregion

        #region =================== costruttori ================
        public MainViewModel()
        {
            model = new Main();
        }
        #endregion

        #region =================== metodi aiuto ===============
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region =================== metodi generali ============
        #endregion
    }
}
