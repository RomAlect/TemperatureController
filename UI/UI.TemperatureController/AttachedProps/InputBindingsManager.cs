using System.Windows;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Controls;

namespace UI.TemperatureController.AttachedProps
{
    public static class InputBindingsManager
    {
        static InputBindingsManager() { }

        public static readonly DependencyProperty UpdateWhenEnterPressedProperty = DependencyProperty.RegisterAttached(
            "UpdateWhenEnterPressed",
            typeof(bool),
            typeof(InputBindingsManager),
            new PropertyMetadata(false, new PropertyChangedCallback(OnUpdateWhenEnterPressedPropertyChanged)));


        public static bool GetUpdateWhenEnterPressed(DependencyObject dobj)
        {
            return (bool)dobj.GetValue(UpdateWhenEnterPressedProperty);
        }

        public static void SetUpdateWhenEnterPressed(DependencyObject dobj, bool value)
        {
            dobj.SetValue(UpdateWhenEnterPressedProperty, value);
        }



        private static void OnUpdateWhenEnterPressedPropertyChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = dobj as UIElement;


            if (element == null)
            {
                return;
            }

            if (e.OldValue != null)
            {
                element.PreviewKeyDown -= HandlePreviewKeyDown;
            }

            if (e.NewValue != null)
            {
                element.PreviewKeyDown += HandlePreviewKeyDown;
            }
        }

        private static void HandlePreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DoUpdate(e.Source);
            }
        }

        private static void DoUpdate(object source)
        {
            bool IsUpdatedWhenEnterPressed =
                GetUpdateWhenEnterPressed(source as DependencyObject);

            if (!IsUpdatedWhenEnterPressed)
            {
                return;
            }

            TextBox txt = source as TextBox;

            if (txt == null)
            {
                return;
            }

            BindingExpression binding = BindingOperations.GetBindingExpression(txt, TextBox.TextProperty);


            if (binding != null)
            {
                binding.UpdateSource();
            }

        }
    }
}
