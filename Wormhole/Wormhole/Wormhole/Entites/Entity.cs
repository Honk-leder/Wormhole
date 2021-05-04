using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Wormhole.Entites
{
    public class Entity
    {
        public int posX;
        public int posY;

        public int heroStayFrontFrame;
        public int heroStayBackFrame;
        public int heroStayLeftFrame;
        public int heroMoveFrontFrames;
        public int heroMoveBackFrames;
        public int heroMoveLeftFrames;

        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;

        public int dirX;
        public int dirY;

        public bool isMoving;

        public int flip;

        public int size;

        public Image heroSprite;

        public Entity (int posX, int posY, 
            int heroStayFrontFrame, int heroStayBackFrame, int heroStayLeftFrame,
            int heroMoveFrontFrames, int heroMoveBackFrames, int heroMoveLeftFrames,
            Image heroSprite)
        {
            this.posX = posX;
            this.posY = posY;
            this.heroStayFrontFrame = heroStayFrontFrame;
            this.heroStayBackFrame = heroStayBackFrame;
            this.heroStayLeftFrame = heroStayLeftFrame;
            this.heroMoveFrontFrames = heroMoveFrontFrames;
            this.heroMoveBackFrames = heroMoveBackFrames;
            this.heroMoveLeftFrames = heroMoveLeftFrames;
            this.heroSprite = heroSprite;
            size = 64;
            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = heroMoveLeftFrames;
            flip = 1;
        }

        public void Move ()
        {
            posX += dirX;
            posY += dirY;
        }

        public void PlayAnimation(Graphics g)
        {
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else currentFrame = 0;

            g.DrawImage(
                heroSprite,
                new Rectangle(new Point(posX - flip * size / 2, posY),
                new Size(flip * size, size)),
                64f * currentFrame, 64 * currentAnimation, size, size,
                GraphicsUnit.Pixel);
        }

        public void SetAnimationConfiguration (int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    currentLimit = heroStayFrontFrame;
                    break;

                case 1:
                    currentLimit = heroStayBackFrame;
                    break;

                case 2:
                    currentLimit = heroStayLeftFrame;
                    break;

                /*case 3:
                    currentLimit = heroStayRightFrame;
                    break;*/

                case 4:
                    currentLimit = heroMoveFrontFrames;
                    break;

                case 5:
                    currentLimit = heroMoveBackFrames;
                    break;

                case 6:
                    currentLimit = heroMoveLeftFrames;
                    break;

                /*case 7:
                    currentLimit = heroMoveRightFrames;
                    break;*/


            }
        }
    }
}
