// <copyright file="MoveLogic.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Defines a renderable model's move logic.
    /// </summary>
    internal abstract class MoveLogic
    {
        private float[] roomSize;

        /// <summary>
        /// Gets the room's width.
        /// </summary>
        protected float RoomWidth => this.roomSize[0];

        /// <summary>
        /// Gets the room's height.
        /// </summary>
        protected float RoomHeight => this.roomSize[1];

        /// <summary>
        /// Sets the room's size.
        /// </summary>
        /// <param name="roomSize">Reference for bounds.</param>
        internal void SetRoomSize(ref float[] roomSize)
        {
            this.roomSize = roomSize;
        }

        /// <summary>
        /// Execute the defined move operation.
        /// </summary>
        /// <param name="model">Renderable model.</param>
        /// <param name="elapsedTime">Elapsed time in milliseconds since last frame.</param>
        internal void Move(RenderModel model, long elapsedTime)
        {
            IntersectionDirection direction = 0;

            if (model.Left <= 0)
            {
                direction |= IntersectionDirection.Left;
            }
            else if (this.roomSize[0] <= model.Right)
            {
                direction |= IntersectionDirection.Right;
            }

            if (model.Top <= 0)
            {
                direction |= IntersectionDirection.Top;
            }
            else if (this.roomSize[1] <= model.Bottom)
            {
                direction |= IntersectionDirection.Bottom;
            }

            this.Move(model, direction, elapsedTime);
        }

        /// <summary>
        /// Execute the defined move operation.
        /// </summary>
        /// <param name="model">Renderable model.</param>
        /// <param name="direction">Intersection directions.</param>
        /// <param name="elapsedTime">Elapsed time in milliseconds since last frame.</param>
        protected abstract void Move(RenderModel model, IntersectionDirection direction, long elapsedTime);
    }
}
