// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfFrameworkElement.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;
    using WpfFrameworkElement.Factories;
    using WpfFrameworkElement.Models;

    /// <summary>
    /// Represents a view model for MainWindow.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private const int BallCount = 5000;
        private float[] roomSize = new float[2];
        private HashSet<RenderModel> models = new HashSet<RenderModel>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.RenderLogic = new RenderLogic(this.models);
            this.GenerateCommand = new RelayCommand(
            () =>
            {
                var factory = new RenderModelFactory(ref this.roomSize);
                for (int i = 0; i < BallCount; i++)
                {
                    this.models.Add(factory.CreateInstanceRandom<SquareModel>());
                }
            },
            () => this.Height > 0 && this.Width > 0);
        }

        /// <summary>
        /// Gets a command that generates renderable models.
        /// </summary>
        public ICommand GenerateCommand { get; private set; }

        /// <summary>
        /// Gets or sets MainWindow's readonly Width property.
        /// </summary>
        public double Width
        {
            get => this.roomSize[0];
            set => this.roomSize[0] = (float)value;
        }

        /// <summary>
        /// Gets or sets MainWindow's readonly Height property.
        /// </summary>
        public double Height
        {
            get => this.roomSize[1];
            set => this.roomSize[1] = (float)value;
        }

        /// <summary>
        /// Gets a render logic that handles the UI renderings.
        /// </summary>
        public RenderLogic RenderLogic { get; private set; }
    }
}
