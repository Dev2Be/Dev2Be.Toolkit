using Dev2Be.Toolkit.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

namespace Dev2Be.Toolkit.Wpf
{
    public class ExtendedListView : ListView
    {
        #region Variables
        private GridViewColumn lastColumnSorted;

        #region IsSortable
        public static readonly DependencyProperty IsSortableProperty = DependencyProperty.RegisterAttached("IsSortable", typeof(bool), typeof(ExtendedListView), new PropertyMetadata(true));

        public bool IsSortable
        {
            get { return (bool)GetValue(IsSortableProperty); }
            set { SetValue(IsSortableProperty, value); }
        }
        #endregion IsSortable

        #region IsHeaderVisible
        public static readonly DependencyProperty IsHeaderVisibleProperty = DependencyProperty.RegisterAttached("IsHeaderVisible", typeof(bool), typeof(ExtendedListView), new FrameworkPropertyMetadata(true, OnIsHeaderVisibleChanged));

        public bool IsHeaderVisible
        {
            get { return (bool)GetValue(IsHeaderVisibleProperty); }
            set { SetValue(IsHeaderVisibleProperty, value); }
        }

        private static void OnIsHeaderVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is ExtendedListView gridViewColumnHeader))
                return;

            List<GridViewColumnHeader> headers = GetVisualChildren<GridViewColumnHeader>((ExtendedListView)d).ToList();

            foreach(GridViewColumnHeader header in headers)
                header.Visibility = (Visibility)new BoolToVisibilityConverter().Convert(e.NewValue, null, null, null);
        }
        #endregion IsHeaderVisible
        #endregion Variables

        public ExtendedListView() : base() { }

        protected override void OnInitialized(EventArgs e)
        {
            AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(GridViewColumnHeaderClickedHandler));

            base.OnInitialized(e);
        }

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource is GridViewColumnHeader && IsSortable)
            {
                GridViewColumn column = ((GridViewColumnHeader)e.OriginalSource).Column;

                if (lastColumnSorted != null)
                    lastColumnSorted.HeaderTemplate = null;

                SortDescriptionCollection sortDescriptions = Items.SortDescriptions;

                RenderSort(sortDescriptions, column, GetSortDirection(sortDescriptions, column));
            }
        }

        private ListSortDirection GetSortDirection(SortDescriptionCollection sortDescriptions, GridViewColumn column)
        {
            if (column == lastColumnSorted && sortDescriptions[0].Direction == ListSortDirection.Ascending)
                return ListSortDirection.Descending;

            return ListSortDirection.Ascending;
        }

        private void RenderSort(SortDescriptionCollection sorts, GridViewColumn column, ListSortDirection direction)
        {
            Uri uri = new Uri("/Dev2Be.Toolkit;component/Themes/Glyphs.xaml", UriKind.Relative);
            ResourceDictionary dictionary = Application.LoadComponent(uri) as ResourceDictionary;

            column.HeaderTemplate = (DataTemplate)dictionary["HeaderTemplateSort" + direction];

            if (column.DisplayMemberBinding is Binding columnBinding)
            {
                sorts.Clear();
                sorts.Add(new SortDescription(columnBinding.Path.Path, direction));
                lastColumnSorted = column;
            }
        }

        public static IEnumerable<T> GetVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                    yield return (T)child;
                foreach (var descendant in GetVisualChildren<T>(child))
                    yield return descendant;
            }
        }
    }
}
