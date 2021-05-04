using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wormhole.Controllers
{
    public static class MapController
    {
        public const int mapHeight = 64;
        public const int mapWidth = 64;
        public static int cellSize = 256;
        public static int[,] map = new int[mapHeight, mapWidth];
        public static Image mapSheet;

        public static void Init()
        {
            map = GetMap();
            mapSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                "Sprites\\nLocation1.png"));
        }
        
        public static int[,] GetMap()
        {
            return DrawingMap.GetMap();
        }
        public static void DrawMap(Graphics g)
        {
            for (var i = 0; i < mapHeight; i++)
            {
                for (var j = 0; j < mapWidth; j++)
                {
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(
                            mapSheet,
                            new Rectangle(new Point(i*1024, j*1024),
                            new Size(512, 512)),
                            0, 0, 1024, 1024,
                            GraphicsUnit.Pixel);
                    }
                }
            }
        }
    }
}
