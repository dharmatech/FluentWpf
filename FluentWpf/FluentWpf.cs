using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

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

    public static class FluentTextElement
    {
        public static T SetFontSize<T>(this T obj, double val)
            where T : TextElement
        { obj.FontSize = val; return obj; }
    }

    public static class FluentList
    {
        public static List SetMarkerStyle(this List obj, TextMarkerStyle val)
        { obj.MarkerStyle = val; return obj; }

        public static List AddListItems(this List obj, params ListItem[] elts)
        { Array.ForEach(elts, elt => obj.ListItems.Add(elt)); return obj; }

    }

    public static class FluentGradientBrush
    {
        public static T AddGradientStops<T>(this T obj, params GradientStop[] elts)
            where T : GradientBrush
        { Array.ForEach(elts, obj.GradientStops.Add); return obj; }
    }

    public static class FluentRenderTargetBitmap
    {
        public static RenderTargetBitmap _Render(this RenderTargetBitmap obj, Visual visual)
        { obj.Render(visual); return obj; }
    }

    public static class FluentVisualCollection
    {
        public static VisualCollection _Add(this VisualCollection obj, Visual visual)
        { obj.Add(visual); return obj; }
    }

    public static class FluentAnimatable
    {
        public static T _BeginAnimation<T>(this T obj, DependencyProperty dp, AnimationTimeline animation)
            where T : Animatable
        { obj.BeginAnimation(dp, animation); return obj; }
    }

    public static class FluentTimeline
    {
        public static T AddCompleted<T>(this T obj, EventHandler val)
            where T : Timeline
        { obj.Completed += val; return obj; }
    }

    public static class FluentDependencyObject
    {
        public static T TextElementSetFontSize<T>(this T obj, double val)
            where T : DependencyObject
        { TextElement.SetFontSize(obj, val); return obj; }

        public static T TextElementSetFontStyle<T>(this T obj, FontStyle val)
            where T : DependencyObject
        { TextElement.SetFontStyle(obj, val); return obj; }

        static Random random;

        public static T1 SetTargetObject<T1, T2>(this T1 obj, T2 element, object target, PropertyPath propertyPath)
            where T1 : DependencyObject
            where T2 : FrameworkElement
        {
            if (random == null) random = new Random();
            var name = "name_" + random.Next().ToString();
            element.RegisterName(name, target);
            Storyboard.SetTargetName(obj, name);
            Storyboard.SetTargetProperty(obj, propertyPath);
            return obj;
        }

        public static T1 SetTargetObject<T1, T2>(this T1 obj, T2 element, object target, DependencyProperty property)
            where T1 : DependencyObject
            where T2 : FrameworkElement
        { return obj.SetTargetObject(element, target, new PropertyPath(property)); }
    }

    public static class FluentTimelineGroup
    {
        public static T AddChildren<T>(this T obj, params Timeline[] elts)
            where T : TimelineGroup
        { Array.ForEach(elts, elt => obj.Children.Add(elt)); return obj; }
    }
}
