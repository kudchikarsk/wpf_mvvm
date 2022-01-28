using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;

namespace Aasani.CRM.App
{
    public static class ViewModelLoader
    {
        public static string GetCallMethod(DependencyObject obj)
        {
            return (string)obj.GetValue(CallMethodProperty);
        }

        public static void SetCallMethod(DependencyObject obj, string value)
        {
            obj.SetValue(CallMethodProperty, value);
        }

        // Using a DependencyProperty as the backing store for CallMethod.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CallMethodProperty =
            DependencyProperty.RegisterAttached("CallMethod", typeof(string), typeof(ViewModelLoader), new PropertyMetadata(null, PropertyChanged));

        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;
            object viewModel = element.DataContext;
            if (viewModel is null)
            {
                return;
            }
            element.Loaded += (d2, e2) =>
            {
                MethodInfo methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());
                if (methodInfo != null)
                {
                    _ = methodInfo.Invoke(viewModel, null);
                }
            };
        }
    }
}
