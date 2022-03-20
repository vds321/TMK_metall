using System.Windows;
using TMK.Service.Interface;

namespace TMK.Service
{
    internal class UserDialogService : IUserDialog
    {
        #region Implementation of IUserDialog
        public bool MessageInformation(string Information, string Caption) =>
            MessageBox.Show(Information, Caption, MessageBoxButton.OK, MessageBoxImage.Information)
            == MessageBoxResult.OK;

        public bool ConfirmWarning(string Warning, string Caption) =>
            MessageBox.Show(Warning, Caption, MessageBoxButton.YesNo, MessageBoxImage.Warning)
            == MessageBoxResult.Yes;

        public bool MessageError(string Error, string Caption) =>
            MessageBox.Show(Error, Caption, MessageBoxButton.OK, MessageBoxImage.Error)
            == MessageBoxResult.OK;


        #endregion
    }
}
