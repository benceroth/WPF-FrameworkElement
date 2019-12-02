// <copyright file="DataPipe.cs" company="PlaceholderCompany">
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
    public class DataPipe : Freezable
    {
        /// <summary>
        /// Provides XAML data piping feature.
        /// </summary>
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(
                "Source",
                typeof(object),
                typeof(DataPipe),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnSourceChanged)));

        /// <summary>
        /// Provides XAML data piping feature.
        /// </summary>
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register(
                "Target",
                typeof(object),
                typeof(DataPipe),
                new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets an object.
        /// </summary>
        public object Source
        {
            get { return this.GetValue(SourceProperty); }
            set { this.SetValue(SourceProperty, value); }
        }

        /// <summary>
        /// Gets or sets an object.
        /// </summary>
        public object Target
        {
            get { return this.GetValue(TargetProperty); }
            set { this.SetValue(TargetProperty, value); }
        }

        /// <summary>
        /// Provides XAML data piping feature.
        /// </summary>
        /// <param name="e">DependencyPropertyChangedEventArgs.</param>
        protected virtual void OnSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            this.Target = e.NewValue;
        }

        /// <summary>
        /// Provides XAML data piping feature.
        /// </summary>
        /// <returns>Freezable.</returns>
        protected override Freezable CreateInstanceCore()
        {
            return new DataPipe();
        }

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DataPipe)d).OnSourceChanged(e);
        }
    }
}
