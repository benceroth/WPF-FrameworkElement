// <copyright file="FrameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfFrameworkElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WpfFrameworkElement.Models;

    /// <summary>
    /// Defines frame prerendering logic.
    /// </summary>
    internal class FrameLogic
    {
        private readonly IEnumerable<RenderModel> models;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameLogic"/> class.
        /// </summary>
        /// <param name="models">Reference for all renderable models.</param>
        internal FrameLogic(IEnumerable<RenderModel> models)
        {
            this.models = models ?? throw new ArgumentNullException(nameof(models));
        }

        /// <summary>
        /// Execute one frame's logics.
        /// </summary>
        /// <param name="elapsedTime">Elapsed time in milliseconds since last frame.</param>
        internal void Process(int elapsedTime)
        {
            this.ProcessMove(elapsedTime);
        }

        private void ProcessMove(int elapsedTime)
        {
            Parallel.ForEach(this.models, model =>
            {
                foreach (var logic in model.MoveLogics)
                {
                    logic.Move(model, elapsedTime);
                }

                model.X += model.SpeedX * elapsedTime / 1000;
                model.Y += model.SpeedY * elapsedTime / 1000;
            });
        }
    }
}
