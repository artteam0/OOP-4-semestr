using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace labs_oop__ado.Controls
{
    public class NumericUpDown : Control
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(int),
                typeof(NumericUpDown),
                new FrameworkPropertyMetadata(0,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnValueChanged,
                    CoerceValue),
                ValidateValue);

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register(
                nameof(Minimum),
                typeof(int),
                typeof(NumericUpDown),
                new PropertyMetadata(int.MinValue, OnMinimumChanged, CoerceMinimum),
                ValidateMinimum);


        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(
                nameof(Maximum),
                typeof(int),
                typeof(NumericUpDown),
                new PropertyMetadata(int.MaxValue, OnMaximumChanged, CoerceMaximum),
                ValidateMaximum);

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register(
                nameof(Step),
                typeof(int),
                typeof(NumericUpDown),
                new PropertyMetadata(1),
                ValidateStep);

        public int Step
        {
            get { return (int)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NumericUpDown control = (NumericUpDown)d;
            control.RaiseEvent(new RoutedEventArgs(ValueChangedEvent, control));
        }

        private static object CoerceValue(DependencyObject d, object baseValue)
        {
            NumericUpDown control = (NumericUpDown)d;
            int value = (int)baseValue;
            if (value < control.Minimum) return control.Minimum;
            if (value > control.Maximum) return control.Maximum;
            return value;
        }

        private static bool ValidateValue(object value)
        {
            return value is int;
        }
        private static void OnMinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NumericUpDown control = (NumericUpDown)d;
            control.CoerceValue(MaximumProperty);
            control.CoerceValue(ValueProperty);
        }
        private static object CoerceMinimum(DependencyObject d, object baseValue)
        {
            NumericUpDown control = (NumericUpDown)d;
            int minimum = (int)baseValue;
            if (minimum > control.Maximum) return control.Maximum;
            return minimum;
        }
        private static bool ValidateMinimum(object value) => value is int;
        private static void OnMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NumericUpDown control = (NumericUpDown)d;
            control.CoerceValue(MinimumProperty);
            control.CoerceValue(ValueProperty);
        }
        private static object CoerceMaximum(DependencyObject d, object baseValue)
        {
            NumericUpDown control = (NumericUpDown)d;
            int maximum = (int)baseValue;
            if (maximum < control.Minimum) return control.Minimum;
            return maximum;
        }
        private static bool ValidateMaximum(object value) => value is int;
        private static bool ValidateStep(object value)
        {
            if (!(value is int intValue)) return false;
            return intValue > 0;
        }
        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }
        private Button _upButton;
        private Button _downButton;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _upButton = GetTemplateChild("PART_UpButton") as Button;
            _downButton = GetTemplateChild("PART_DownButton") as Button;

            if (_upButton != null)
            {
                _upButton.Click += (s, e) => IncrementValue();
            }
            if (_downButton != null)
            {
                _downButton.Click += (s, e) => DecrementValue();
            }
            this.MouseWheel += NumericUpDown_MouseWheel;
        }

        private void NumericUpDown_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                IncrementValue();
            else if (e.Delta < 0)
                DecrementValue();
            e.Handled = true;
        }


        private void IncrementValue()
        {
            Value = Math.Min(Maximum, Value + Step);
        }

        private void DecrementValue()
        {
            Value = Math.Max(Minimum, Value - Step);
        }

        public static readonly RoutedEvent ValueChangedEvent =
            EventManager.RegisterRoutedEvent(
                nameof(ValueChanged),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(NumericUpDown));

        public event RoutedEventHandler ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }
    }
}