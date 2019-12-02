// <copyright file="RenderModel.cs" company="PlaceholderCompany">
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
    using WpfFrameworkElement.Logics;

    /// <summary>
    /// Abstract representation of a renderable model.
    /// </summary>
    internal abstract class RenderModel
    {
        /// <summary>
        /// Defines model's body (X, Y, Width, Height).
        /// </summary>
        private readonly float[] body = new float[4];

        /// <summary>
        /// Defines model's speed (X, Y).
        /// </summary>
        private readonly float[] speed = new float[2];

        /// <summary>
        /// Defines model's logics for moving.
        /// </summary>
        private readonly List<MoveLogic> moveLogics = new List<MoveLogic>();

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderModel"/> class.
        /// </summary>
        internal RenderModel()
        {
        }

        /// <summary>
        /// Gets model's logics for moving.
        /// </summary>
        internal ICollection<MoveLogic> MoveLogics => this.moveLogics;

        /// <summary>
        /// Gets or sets model's X coordinate.
        /// </summary>
        internal float X
        {
            get => this.body[0];
            set => this.body[0] = value;
        }

        /// <summary>
        /// Gets or sets model's Y coordinate.
        /// </summary>
        internal float Y
        {
            get => this.body[1];
            set => this.body[1] = value;
        }

        /// <summary>
        /// Gets or sets model's width.
        /// </summary>
        internal virtual float Width
        {
            get => this.body[2];
            set => this.body[2] = value;
        }

        /// <summary>
        /// Gets or sets model's height.
        /// </summary>
        internal virtual float Height
        {
            get => this.body[3];
            set => this.body[3] = value;
        }

        /// <summary>
        /// Gets model's left bound.
        /// </summary>
        internal float Left => this.X;

        /// <summary>
        /// Gets model's right bound.
        /// </summary>
        internal float Right => this.X + this.Width;

        /// <summary>
        /// Gets model's top bound.
        /// </summary>
        internal float Top => this.Y;

        /// <summary>
        /// Gets model's bottom bound.
        /// </summary>
        internal float Bottom => this.Y + this.Height;

        /// <summary>
        /// Gets or sets model's speed on X axis.
        /// </summary>
        internal float SpeedX
        {
            get => this.speed[0];
            set => this.speed[0] = value;
        }

        /// <summary>
        /// Gets or sets model's speed on Y axis.
        /// </summary>
        internal float SpeedY
        {
            get => this.speed[1];
            set => this.speed[1] = value;
        }
    }
}
