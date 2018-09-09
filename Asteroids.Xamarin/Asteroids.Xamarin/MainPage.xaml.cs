﻿using System;
using System.Diagnostics;
using Asteroids.Standard;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Asteroids.Xamarin
{
    public partial class MainPage : ContentPage, IDisposable
    {
        public MainPage()
        {
            InitializeComponent();

            _controller = new GameController(MainContainer1);
        }

        private GameController _controller;

        private async void MainContentPage_SizeChanged(object sender, EventArgs e)
        {
            await _controller.ResizeGame(GetRectangle());
        }

        private async void MainContentPage_LayoutChanged(object sender, EventArgs e)
        {
            MainContentPage.LayoutChanged -= MainContentPage_LayoutChanged;
            await _controller.Initialize(GetRectangle());
        }

        private System.Drawing.Rectangle GetRectangle()
        {
            var metrics = DeviceDisplay.ScreenMetrics;
            var density = metrics.Density;

            var rec = new System.Drawing.Rectangle(
                0
                , 0
                , (int)(MainContentPage.Width * density)
                , (int)(MainContentPage.Height * density)
            );

            Debug.WriteLine(rec);
            return rec;
        }

        public void Dispose()
        {
            _controller.Dispose();
        }
    }
}
