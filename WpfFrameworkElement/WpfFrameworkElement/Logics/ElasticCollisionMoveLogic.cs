// <copyright file="ElasticCollisionMoveLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfFrameworkElement.Logics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Shapes;
    using WpfFrameworkElement.Models;

    /// <inheritdoc />
    internal class ElasticCollisionMoveLogic : MoveLogic
    {
        /// <inheritdoc />
        protected override void Move(RenderModel model, IntersectionDirection direction, long elapsedTime)
        {
            if (direction.HasFlag(IntersectionDirection.Left))
            {
                model.SpeedX = Math.Abs(model.SpeedX);
                model.X = 0;
            }
            else if (direction.HasFlag(IntersectionDirection.Right))
            {
                model.SpeedX = -Math.Abs(model.SpeedX);
                model.X = this.RoomWidth - model.Width;
            }

            if (direction.HasFlag(IntersectionDirection.Top))
            {
                model.SpeedY = Math.Abs(model.SpeedY);
                model.Y = 0;
            }
            else if (direction.HasFlag(IntersectionDirection.Bottom))
            {
                model.SpeedY = -Math.Abs(model.SpeedY);
                model.Y = this.RoomHeight - model.Height;
            }
        }
    }
}
