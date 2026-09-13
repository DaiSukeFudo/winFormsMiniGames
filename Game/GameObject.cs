using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IGameObject
    {
        void Update();
        void Draw(Graphics g);
        Rectangle GetBounds();
    }


    abstract class GameObject : IGameObject
    {
        protected int x, y;
        protected int width, height;
        protected Image image;

        public GameObject(int x, int y, int width, int height , Image image, bool reverseY = false)
        {
            if (reverseY)
            {
                this.height = -height;
            }
            else
            {
                this.height = height;
            }
            this.width = width;
            this.x = x;
            this.y = y;
            this.image = image;
        }


        public abstract void Update();


        public virtual void Draw(Graphics g)
        {
            g.DrawImage(image, x, y, width, height);
        }


        public Rectangle GetBounds()
        {
            if(height < 0)
            {
                return new Rectangle(x, y + height, width, Math.Abs(height));
            }
            return new Rectangle(x, y, width, height);
        }
    }
}
