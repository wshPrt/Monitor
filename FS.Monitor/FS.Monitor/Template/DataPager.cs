using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FS.Monitor.Template
{
    /// <summary>
    /// 数据分页
    /// </summary>
    public class DataPager : Control
    {
        /// <summary>
        /// 页大小
        /// </summary>
        public string PageSize
        {
            get { return (string)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }

        /// <summary>
        /// 总数量
        /// </summary>
        public string TotalCount
        {
            get { return (string)GetValue(TotalCountProperty); }
            set { SetValue(TotalCountProperty, value); }
        }

        /// <summary>
        /// 页索引
        /// </summary>
        public string PageIndex
        {
            get { return (string)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }

        /// <summary>
        /// 页总数
        /// </summary>
        public string PageCount
        {
            get { return (string)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }

        public static readonly DependencyProperty PageSizeProperty = DependencyProperty.Register("PageSize", typeof(string), typeof(DataPager), new PropertyMetadata(""));

        public static readonly DependencyProperty TotalCountProperty = DependencyProperty.Register("TotalCount", typeof(string), typeof(DataPager), new PropertyMetadata(""));

        public static readonly DependencyProperty PageIndexProperty = DependencyProperty.Register("PageIndex", typeof(string), typeof(DataPager), new PropertyMetadata(""));

        public static readonly DependencyProperty PageCountProperty = DependencyProperty.Register("PageCount", typeof(string), typeof(DataPager), new PropertyMetadata(""));

        public RelayCommand GoHomePageCommand
        {
            get { return (RelayCommand)GetValue(GoHomePageCommandProperty); }
            set { SetValue(GoHomePageCommandProperty, value); }
        }

        public RelayCommand GoOnPageCommand
        {
            get { return (RelayCommand)GetValue(GoOnPageCommandProperty); }
            set { SetValue(GoOnPageCommandProperty, value); }
        }

        public RelayCommand GoNextPageCommand
        {
            get { return (RelayCommand)GetValue(GoNextPageCommandProperty); }
            set { SetValue(GoNextPageCommandProperty, value); }
        }

        public RelayCommand GoEndPageCommand
        {
            get { return (RelayCommand)GetValue(GoEndPageCommandProperty); }
            set { SetValue(GoEndPageCommandProperty, value); }
        }

        public static readonly DependencyProperty GoHomePageCommandProperty = DependencyProperty.Register("GoHomePageCommand", typeof(RelayCommand), typeof(DataPager));

        public static readonly DependencyProperty GoNextPageCommandProperty = DependencyProperty.Register("GoNextPageCommand", typeof(RelayCommand), typeof(DataPager));

        public static readonly DependencyProperty GoOnPageCommandProperty = DependencyProperty.Register("GoOnPageCommand", typeof(RelayCommand), typeof(DataPager));

        public static readonly DependencyProperty GoEndPageCommandProperty = DependencyProperty.Register("GoEndPageCommand", typeof(RelayCommand), typeof(DataPager));

    }
}
