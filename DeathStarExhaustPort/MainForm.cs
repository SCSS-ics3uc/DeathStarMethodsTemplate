/// Created by Tony Theodoropoulos
/// August 2013
/// 
/// This program is meant to demonstrate how to use C# graphics objects.  
/// The animations are kept fairly simply and there are no loops or custom methods
/// used as this is given to the students before they have learned those concepts.
/// The assignment could easily be adapted to use loops, custom methods, or even 
/// custom objects.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace DeathStarExhaustPort
{
    public partial class MainForm : Form
    {
        Graphics g;

        public MainForm()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            int shipX = 360;
            int shipY = 25;

            int torpedoX = 265;
            int torpedoY = 35;

            Pen drawPen = new Pen(Color.White);
            Pen explosionPen = new Pen(Color.White, 10);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            // ************************** X wing fly in **************************
            for (int x = 0; x < 10; x++)
            {
                shipX = shipX - 10;

                Thread.Sleep(50);
                g.Clear(Color.Black);
                
                DeathStar(55, 55, 400);
                ExhaustPort(245, 62, 20, 205);
                Xwing(shipX, shipY, 30, 8);
            }

            // ************************** X - wing fly out and torpedo fly in  **************************
            for (int x = 0; x < 4; x++)
            {
                shipX -= 8;
                shipY -= 9;

                torpedoX -= 5;
                torpedoY += 5;

                Thread.Sleep(50);
                g.Clear(Color.Black);
                
                DeathStar(55, 55, 400);
                ExhaustPort(245, 62, 20, 205);
                Xwing(shipX, shipY, 30, 8);
                Torpedo(torpedoX, torpedoY, 20);
            }

            // ************************** torpedo drop **************************
            for (int x = 0; x < 38; x++)
            {
                torpedoY += 5;

                Thread.Sleep(50);
                g.Clear(Color.Black);
                
                DeathStar(55, 55, 400);
                ExhaustPort(245, 62, 20, 205);
                Xwing(shipX, shipY, 30, 8);
                Torpedo(torpedoX, torpedoY, 20);
            }

            // ************************** Explosion **************************
            for (int x = 1; x < 10; x++)
            {
                Thread.Sleep(150);
                g.Clear(Color.Black);
                
                DeathStar(55, 55, 400);
                ExhaustPort(245, 62, 20, 205);

                if (x % 2 == 0) { Explosion(205, 205, 100); }
                else            { Explosion(180, 180, 150); }
            }
        }

        //3u
        public void Xwing(float x, float y, float width, float height)
        {
            Pen shipPen = new Pen(Color.White);
            g.DrawRectangle(shipPen, x, y, width, height);
        }

        //3c
        public void Torpedo(float x, float y, float pixels)
        {
            Pen torpPen = new Pen(Color.White);
            g.DrawRectangle(torpPen, x, y, pixels, pixels);
        }

        //3u
        public void Explosion(float x, float y, float pixels)
        {
            Pen exPen = new Pen(Color.White);
            g.DrawRectangle(exPen, x, y, pixels, pixels);

        }

        //3u
        public void DeathStar(float x, float y, float pixels)
        {
            Pen deathPen = new Pen(Color.White);
            g.DrawEllipse(deathPen, x, y, pixels, pixels);
        }

        //3u
        public void ExhaustPort(float x, float y, float width, float height)
        {
            Pen exPen = new Pen(Color.White);
            g.DrawRectangle(exPen, x, y, width, height);
        }
    }
}
