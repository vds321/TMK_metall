
namespace TMK.Service.Interface
{
    public interface IUserDialog
    {
        bool MessageInformation(string Information, string Caption);
        bool ConfirmWarning(string Warning, string Caption);
        bool MessageError(string Error, string Caption);

    }
}
