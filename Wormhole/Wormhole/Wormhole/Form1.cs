using Wormhole.Entites;
using Wormhole.Models;
using Wormhole.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wormhole
{
    public partial class Form1 : Form
    {
        public Entity player;
        public Image heroSprite;
        public Point delta;
        
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 150;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            Init();

            delta = new Point(32, 0);
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            player.dirX = 0;
            player.dirY = 0;
            player.isMoving = false;

            if (e.KeyCode == Keys.W)
                player.SetAnimationConfiguration(1);
            if (e.KeyCode == Keys.S)
                player.SetAnimationConfiguration(0);
            if (e.KeyCode == Keys.A)
                player.SetAnimationConfiguration(2);
            if (e.KeyCode == Keys.D)
            {
                player.flip = -1;
                player.SetAnimationConfiguration(2);
            }
        }

        public void OnPress (object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -4;
                    player.isMoving = true;
                    player.SetAnimationConfiguration(5);
                    break;

                case Keys.S:
                    player.dirY = 4;
                    player.isMoving = true;
                    player.SetAnimationConfiguration(4);
                    break;

                case Keys.A:
                    player.dirX = -4;
                    player.isMoving = true;
                    player.flip = 1;
                    player.SetAnimationConfiguration(6);
                    break;
                    
                case Keys.D:
                    player.dirX = 4;
                    player.isMoving = true;
                    player.flip = -1; //из-за этой переменной flip я не использую две линейки фреймов для спрайта, но убирать мне их лень :)
                    player.SetAnimationConfiguration(6);
                    break;                    
            }
        }

        public void Init()
        {
            Width = 526;
            Height = 470;
            MapController.Init();
            heroSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                "Sprites\\heroSprite_full.png"));
            player = new Entity(64, 120, 
                Hero.heroStayFrontFrame, Hero.heroStayBackFrame, Hero.heroStayLeftFrame,
                Hero.heroMoveFrontFrames, Hero.heroMoveBackFrames, Hero.heroMoveLeftFrames,
                heroSprite);
            timer1.Start();
        }

        public void Update (object sender, EventArgs e)
        {
            if (player.isMoving)
                player.Move();
            Invalidate();
        }

        private void OnPaint (object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            MapController.DrawMap(g);
            player.PlayAnimation(g);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
