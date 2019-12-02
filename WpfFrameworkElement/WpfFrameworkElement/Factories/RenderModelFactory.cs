// <copyright file="RenderModelFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfFrameworkElement.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using WpfFrameworkElement.Logics;
    using WpfFrameworkElement.Models;

    /// <summary>
    /// Factory class which creates renderable models.
    /// </summary>
    internal class RenderModelFactory
    {
        private static readonly Random RNG = new Random();
        private static readonly Dictionary<Type, MoveLogic> MoveLogics;

        private static bool init = false;
        private readonly float[] roomSize;

        static RenderModelFactory()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(MoveLogic)));
            MoveLogics = types.ToDictionary(x => x, x => Activator.CreateInstance(x) as MoveLogic);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderModelFactory"/> class.
        /// </summary>
        /// <param name="roomSize">Reference for bounds.</param>
        internal RenderModelFactory(ref float[] roomSize)
        {
            this.roomSize = roomSize;

            if (!init)
            {
                init = true;
                foreach (var logic in MoveLogics.Values)
                {
                    logic.SetRoomSize(ref this.roomSize);
                }
            }
        }

        /// <summary>
        /// Creates an instance of a renderable model.
        /// </summary>
        /// <typeparam name="T">Renderable model subtype.</typeparam>
        /// <returns>An instance of a renderable model.</returns>
        internal T CreateInstance<T>()
            where T : RenderModel, new()
        {
            T model = new T();

            foreach (var logic in MoveLogics.Values)
            {
                model.MoveLogics.Add(logic);
            }

            return model;
        }

        /// <summary>
        /// Creates a random instance of a renderable model.
        /// </summary>
        /// <typeparam name="T">Renderable model subtype.</typeparam>
        /// <returns>A random instance of a renderable model.</returns>
        internal T CreateInstanceRandom<T>()
            where T : RenderModel, new()
        {
            T model = this.CreateInstance<T>();

            model.Width = 3;
            model.Height = 3;
            model.X = this.RandomInBounds(model.Width);
            model.Y = this.RandomInBounds(model.Height);

            model.SpeedX = RNG.Next(-250, 251);
            model.SpeedY = RNG.Next(-250, 251);

            return model;
        }

        private int RandomInBounds() => RNG.Next(0, (int)this.roomSize[0]);

        private int RandomInBounds(int size) => RNG.Next(0, (int)(this.roomSize[0] - size));

        private int RandomInBounds(float size) => RNG.Next(0, (int)(this.roomSize[0] - size));

        private int RandomInBounds(double size) => RNG.Next(0, (int)(this.roomSize[0] - size));
    }
}
