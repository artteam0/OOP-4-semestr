using labs_oop__ado.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace labs_oop__ado
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogEvent(string message)
        {
            if (EventLogListBox != null && this.IsLoaded)
            {
                EventLogListBox.Items.Insert(0, $"{DateTime.Now:HH:mm:ss.fff} - {message}");
            }
            else if (EventLogListBox != null && !this.IsLoaded)
            {
                System.Diagnostics.Debug.WriteLine($"LogEvent (Window not fully loaded, ListBox exists): {message}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"LogEvent (EventLogListBox is null): {message}");
            }
        }
        private void MyNumericUpDown_ValueChanged(object sender, RoutedEventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            LogEvent($"NumericUpDown ValueChanged (Bubbling): New Value = {nud?.Value}. Source: {e.Source.GetType().Name}");
        }
        private void MyStatusIndicator_Activated(object sender, RoutedEventArgs e)
        {
            LogEvent($"MyStatusIndicator Activated (Direct). Source: {e.Source.GetType().Name}");
        }
        private void Window_PreviewStatusChanged(object sender, StatusChangeEventArgs e)
        {
            LogEvent($"Window PreviewStatusChanged (Tunneling). Source: {e.Source.GetType().Name}, OriginalSource: {e.OriginalSource.GetType().Name}, NewStatus: {e.NewStatus}");
            if (e.NewStatus == "Busy")
            {
                LogEvent(">>> Window Preview: Cancelling change to 'Busy'");
                e.Cancel = true;
            }
        }

        private void IndicatorPanel_PreviewStatusChanged(object sender, StatusChangeEventArgs e)
        {
            LogEvent($"IndicatorPanel PreviewStatusChanged (Tunneling). Source: {e.Source.GetType().Name}, OriginalSource: {e.OriginalSource.GetType().Name}, NewStatus: {e.NewStatus}");
        }

        private void MyStatusIndicator_PreviewStatusChanged(object sender, StatusChangeEventArgs e)
        {
            LogEvent($"MyStatusIndicator PreviewStatusChanged (Tunneling). Source: {e.Source.GetType().Name}, OriginalSource: {e.OriginalSource.GetType().Name}, NewStatus: {e.NewStatus}");
        }
        private void MyStatusIndicator_StatusChanged(object sender, StatusChangeEventArgs e)
        {
            LogEvent($"MyStatusIndicator StatusChanged (Bubbling). Source: {e.Source.GetType().Name}, OriginalSource: {e.OriginalSource.GetType().Name}, NewStatus: {e.NewStatus}");
        }
        private void IndicatorPanel_StatusChanged(object sender, StatusChangeEventArgs e)
        {
            LogEvent($"IndicatorPanel StatusChanged (Bubbling). Source: {e.Source.GetType().Name}, OriginalSource: {e.OriginalSource.GetType().Name}, NewStatus: {e.NewStatus}");
        }
        private void Window_StatusChanged(object sender, StatusChangeEventArgs e)
        {
            LogEvent($"Window StatusChanged (Bubbling). Source: {e.Source.GetType().Name}, OriginalSource: {e.OriginalSource.GetType().Name}, NewStatus: {e.NewStatus}");
        }
        private void SetOnline_Click(object sender, RoutedEventArgs e)
        {
            LogEvent("--- Button 'Set Status Online' Clicked ---");
            MyStatusIndicator.StatusText = "Online";
            MyStatusIndicator.IndicatorBrush = Brushes.Green;
        }
        private void SetBusy_Click(object sender, RoutedEventArgs e)
        {
            LogEvent("--- Button 'Set Status Busy' Clicked ---");
            MyStatusIndicator.StatusText = "Busy";
            MyStatusIndicator.IndicatorBrush = Brushes.Orange;
        }
        private void SetInvalidBrush_Click(object sender, RoutedEventArgs e)
        {
            LogEvent("--- Button 'Set Invalid Brush' Clicked ---");
            MyStatusIndicator.IndicatorBrush = null;
            LogEvent($"MyStatusIndicator.IndicatorBrush is now: {MyStatusIndicator.IndicatorBrush}");
        }
        private void ResetNumericValue_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ResetNumericValue_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (MyNumericUpDown != null)
            {
                int resetValue = MyNumericUpDown.Minimum;
                if (e.Parameter is string paramStr && int.TryParse(paramStr, out int parsedValue))
                {
                    resetValue = parsedValue;
                }
                else if (e.Parameter is int intParam)
                {
                    resetValue = intParam;
                }

                MyNumericUpDown.Value = resetValue;
                LogEvent($"COMMAND EXECUTED: NumericUpDown.Value reset to {MyNumericUpDown.Value} (requested: {resetValue})");
            }
        }
    }
}