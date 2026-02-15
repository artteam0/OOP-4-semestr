using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace labs_oop__ado.Controls
{
    public class StatusIndicator : Control
    {
        public static readonly DependencyProperty StatusTextProperty =
            DependencyProperty.Register(
                nameof(StatusText),
                typeof(string),
                typeof(StatusIndicator),
                new PropertyMetadata("N/A", OnStatusTextChanged),
                ValidateStatusText);

        public string StatusText
        {
            get { return (string)GetValue(StatusTextProperty); }
            set { SetValue(StatusTextProperty, value); }
        }

        private static bool ValidateStatusText(object value)
        {
            return value != null;
        }
        private static void OnStatusTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StatusIndicator control = (StatusIndicator)d;
            StatusChangeEventArgs previewArgs = new StatusChangeEventArgs(PreviewStatusChangedEvent, control, (string)e.OldValue, (string)e.NewValue);
            control.RaiseEvent(previewArgs);

            if (previewArgs.Cancel)
            {
                System.Diagnostics.Debug.WriteLine($"Status change to '{e.NewValue}' was CANCELED in PreviewStatusChanged event.");
                return;
            }

            StatusChangeEventArgs changedArgs = new StatusChangeEventArgs(StatusChangedEvent, control, (string)e.OldValue, (string)e.NewValue);
            control.RaiseEvent(changedArgs);
        }


        public static readonly DependencyProperty IndicatorBrushProperty =
            DependencyProperty.Register(
                nameof(IndicatorBrush),
                typeof(Brush),
                typeof(StatusIndicator),
                new PropertyMetadata(Brushes.Gray, null, CoerceIndicatorBrush),
                ValidateIndicatorBrush);

        public Brush IndicatorBrush
        {
            get { return (Brush)GetValue(IndicatorBrushProperty); }
            set { SetValue(IndicatorBrushProperty, value); }
        }

        private static bool ValidateIndicatorBrush(object value)
        {
            return value is Brush;
        }

        private static object CoerceIndicatorBrush(DependencyObject d, object baseValue)
        {
            return baseValue ?? Brushes.LightGray;
        }

        static StatusIndicator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StatusIndicator), new FrameworkPropertyMetadata(typeof(StatusIndicator)));
        }
        public static readonly RoutedEvent ActivatedEvent =
            EventManager.RegisterRoutedEvent(
                nameof(Activated),
                RoutingStrategy.Direct,
                typeof(RoutedEventHandler),
                typeof(StatusIndicator));

        public event RoutedEventHandler Activated
        {
            add { AddHandler(ActivatedEvent, value); }
            remove { RemoveHandler(ActivatedEvent, value); }
        }
        public static readonly RoutedEvent PreviewStatusChangedEvent =
            EventManager.RegisterRoutedEvent(
                "PreviewStatusChanged",
                RoutingStrategy.Tunnel,
                typeof(StatusChangeEventHandler),
                typeof(StatusIndicator));

        public event StatusChangeEventHandler PreviewStatusChanged
        {
            add { AddHandler(PreviewStatusChangedEvent, value); }
            remove { RemoveHandler(PreviewStatusChangedEvent, value); }
        }
        public static readonly RoutedEvent StatusChangedEvent =
            EventManager.RegisterRoutedEvent(
                nameof(StatusChanged),
                RoutingStrategy.Bubble,
                typeof(StatusChangeEventHandler),
                typeof(StatusIndicator));

        public event StatusChangeEventHandler StatusChanged
        {
            add { AddHandler(StatusChangedEvent, value); }
            remove { RemoveHandler(StatusChangedEvent, value); }
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            RaiseEvent(new RoutedEventArgs(ActivatedEvent, this));
            e.Handled = true;
        }
    }
    public class StatusChangeEventArgs : RoutedEventArgs
    {
        public string OldStatus { get; }
        public string NewStatus { get; }
        public bool Cancel { get; set; }

        public StatusChangeEventArgs(RoutedEvent routedEvent, object source, string oldStatus, string newStatus)
            : base(routedEvent, source)
        {
            OldStatus = oldStatus;
            NewStatus = newStatus;
            Cancel = false;
        }
    }

    public delegate void StatusChangeEventHandler(object sender, StatusChangeEventArgs e);
}