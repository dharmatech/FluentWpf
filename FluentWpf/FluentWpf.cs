using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace FluentWpf
{
    public static class Fluent
    {
        public static T CallOnSelf<T>(this T obj, Action<T> proc)
        { proc(obj); return obj; }
    }

    public static class FluentApplication
    {
        public static Application AddStartup(this Application obj, StartupEventHandler proc)
        { obj.Startup += proc; return obj; }
    }

    public static class FluentUIElement
    {
        public static T AddCommandBindings<T>(this T obj, params CommandBinding[] elts)
            where T : UIElement
        {
            Array.ForEach(elts, elt => obj.CommandBindings.Add(elt));
            return obj;
        }

        public static T AddMouseEnter<T>(this T obj, MouseEventHandler proc)
            where T : UIElement
        { obj.MouseEnter += proc; return obj; }

        public static T AddMouseLeave<T>(this T obj, MouseEventHandler proc)
            where T : UIElement
        { obj.MouseLeave += proc; return obj; }

        public static T SetDock<T>(this T obj, Dock val)
            where T : UIElement
        { DockPanel.SetDock(obj, val); return obj; }

        public static T SetColumn<T>(this T obj, int val) where T : UIElement
        { Grid.SetColumn(obj, val); return obj; }
    }

    public static class FluentItemsControl
    {
        public static T AddItems<T>(this T obj, params Object[] elts)
            where T : ItemsControl
        {
            Array.ForEach(elts, elt => obj.Items.Add(elt));
            return obj;
        }
    }

    public static class FluentMenuItem
    {
        public static MenuItem AddClick(this MenuItem obj, RoutedEventHandler proc)
        { obj.Click += proc; return obj; }
    }

    public static class FluentButtonBase
    {
        public static T AddClick<T>(this T obj, RoutedEventHandler proc)
            where T : ButtonBase
        { obj.Click += proc; return obj; }
    }

    public static class FluentContentControl
    {
        public static T SetContent<T>(this T obj, Object val)
            where T : ContentControl
        { obj.Content = val; return obj; }

    }

    public static class FluentPanel
    {
        public static T AddChildren<T>(this T obj, params UIElement[] elts)
            where T : Panel
        { Array.ForEach(elts, elt => obj.Children.Add(elt)); return obj; }
    }

    public static class FluentGrid
    {
        public static Grid AddColumnDefinitions(this Grid obj, params ColumnDefinition[] elts)
        { Array.ForEach(elts, elt => obj.ColumnDefinitions.Add(elt)); return obj; }
    }

    public static class FluentCommandBinding
    {
        public static CommandBinding AddCanExecute(this CommandBinding obj, CanExecuteRoutedEventHandler proc)
        { obj.CanExecute += proc; return obj; }

        public static CommandBinding AddExecuted(this CommandBinding obj, ExecutedRoutedEventHandler proc)
        { obj.Executed += proc; return obj; }
    }
}
