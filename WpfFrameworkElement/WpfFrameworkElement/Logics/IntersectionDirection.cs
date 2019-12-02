// <copyright file="IntersectionDirection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfFrameworkElement.Logics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines intersection directions from where it occurs.
    /// </summary>
    [Flags]
    internal enum IntersectionDirection
    {
        /// <summary>
        /// Intersection from left.
        /// </summary>
        Left = 1,

        /// <summary>
        /// Intersection from right.
        /// </summary>
        Right = 2,

        /// <summary>
        /// Intersection from top.
        /// </summary>
        Top = 4,

        /// <summary>
        /// Intersection from bottom.
        /// </summary>
        Bottom = 8,
    }
}
