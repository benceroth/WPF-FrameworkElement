// <copyright file="SquareModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfFrameworkElement.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Represents a square renderable model.
    /// </summary>
    internal class SquareModel : RenderModel
    {
        /// <inheritdoc />
        internal override float Width
        {
            get => base.Width;
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        /// <inheritdoc />
        internal override float Height
        {
            get => base.Height;
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
    }
}
