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

        public GameObject(int x, int y, int width, int height , Image image)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.image = image;
        }

        public abstract void Update();
        public virtual void Draw(Graphics g)
        {
            g.DrawImage(image, x, y, width, height);
        }
        public Rectangle GetBounds()
        {
            return new Rectangle(x, y, width, height);
        }



    }
}
