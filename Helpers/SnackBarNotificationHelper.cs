using MudBlazor;

namespace Panulu.Helpers; 
public class SnackBarNotificationHelper {

    private readonly ISnackbar _snackbar;

    public SnackBarNotificationHelper(ISnackbar snackbar) {
        _snackbar = snackbar;
    }
    private const string infoMessage = "Task performed Successfully!";


    public void DisplayInfoSnackbar() {
        _snackbar.Add(infoMessage, severity: Severity.Info);
    }
}
