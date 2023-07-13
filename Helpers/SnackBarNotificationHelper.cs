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

    public void DisplaySuccessSnackBar() {
        var rnd = new Random();
        var index  = rnd.Next(Constant.TaskCompletionPhrases
            .Count);
        var message = Constant.TaskCompletionPhrases[index];
        _snackbar.Add(message, severity: Severity.Success); 
    }
}
