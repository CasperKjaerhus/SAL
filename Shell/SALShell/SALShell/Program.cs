using SALShell.Controller;
using SALShell.Core;
using SALShell.UI;

namespace SALShell
{
    class Program
    {
        static void Main(string[] args)
        {
            ICore core = new Core.Core();
            IShellUI ui = new ShellCLI();
            ShellController shellController = new ShellController(ui, core);
            shellController.Ui.Start();
        }
    }
}
