// <copyright file="DataPiping.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfFrameworkElement.Behaviors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// Provides XAML data piping feature.
    /// </summary>
    public class DataPiping
    {
        /// <summary>
        /// Provides XAML data piping feature.
        /// </summary>
        public static readonly DependencyProperty DataPipesProperty =
            DependencyProperty.RegisterAttached(
                "DataPipes",
                typeof(DataPipeCollection),
                typeof(DataPiping),
                new UIPropertyMetadata(null));

        /// <summary>
        /// Provides XAML data piping feature.
        /// </summary>
        /// <param name="o">DependencyObject.</param>
        /// <param name="value">DataPipeCollection.</param>
        public static void SetDataPipes(DependencyObject o, DataPipeCollection value)
        {
            o.SetValue(DataPipesProperty, value);
        }

        /// <summary>
        /// Provides XAML data piping feature.
        /// </summary>
        /// <param name="o">DepedencyObject.</param>
        /// <returns>DataPipeCollection.</returns>
        public static DataPipeCollection GetDataPipes(DependencyObject o)
        {
            return (DataPipeCollection)o.GetValue(DataPipesProperty);
        }
    }
}
