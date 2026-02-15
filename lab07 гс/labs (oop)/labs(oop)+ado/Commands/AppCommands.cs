using System.Windows.Input;

namespace labs_oop__ado.Commands
{
    public static class AppCommands
    {
        public static readonly RoutedUICommand ResetNumericValue = new RoutedUICommand(
            "Reset Numeric Value",
            "ResetNumericValue",
            typeof(AppCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.R, ModifierKeys.Control)
            }
        );
    }
}