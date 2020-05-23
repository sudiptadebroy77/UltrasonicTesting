﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace UltrasonicTestingForms.Controllers
{
    public class WaweController
    {
        private Panel panel;
        private PictureBox pictureWave;
        private int samples;
        private int direction;
        public WaweController(PictureBox pictureWave, Panel panel, int samples)
        {
            this.pictureWave = pictureWave;
            this.panel = panel;
            this.samples = samples;
            this.pictureWave.Location = new Point(125, 6);
            this.pictureWave.Image = Properties.Resources.waveBottom;
            this.pictureWave.Visible = true;
            direction = 1;
        }
        public void Move()
        {
            if (!pictureWave.Visible)
            {
                return;
            }
            if (pictureWave.Location.Y < 0)
            {
                pictureWave.Visible = false;
                return;
            }
            int size = (panel.Height - pictureWave.Size.Height - 150);
            int stepMove = 2 * size / samples;
            if (size <= pictureWave.Location.Y)
            {
                this.direction = -1;
                pictureWave.Image = Properties.Resources.waveTop;
            }
            stepMove *= this.direction;
            pictureWave.Location = new Point(pictureWave.Location.X, pictureWave.Location.Y + stepMove);
        }

    }
}