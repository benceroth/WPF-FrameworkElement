// <copyright file="GravityMoveLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfFrameworkElement.Logics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WpfFrameworkElement.Models;

    /// <inheritdoc />
    internal class GravityMoveLogic : MoveLogic
    {
        private const float G = 500;

        /// <inheritdoc />
        protected override void Move(RenderModel model, IntersectionDirection direction, long elapsedTime)
        {
            if (!direction.HasFlag(IntersectionDirection.Bottom))
            {
                model.SpeedY += G * elapsedTime / 1000;
            }
        }
    }
}
