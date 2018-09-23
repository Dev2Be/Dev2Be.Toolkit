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

namespace Dev2Be.Toolkit.Wpf
{
    public class ExtendedListView : ListView
    {
        private GridViewColumn lastColumnSorted;

        public static readonly DependencyProperty IsSortableProperty = DependencyProperty.RegisterAttached("IsSortable", typeof(bool), typeof(ExtendedListView), new PropertyMetadata(true));

        public bool IsSortable
        {
            get { return (bool)GetValue(IsSortableProperty); }
            set { SetValue(IsSortableProperty, value); }
        }

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
    }
}
