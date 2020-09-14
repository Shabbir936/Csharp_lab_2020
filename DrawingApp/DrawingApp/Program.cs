using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp
{
    class Shape
    {
        public virtual void draw()
        {
            Console.WriteLine("Drawing...");
        }
    }
    class Circle : Shape
    {
        public override void draw()
        {
            Console.WriteLine("Drawing a Circle");
            base.draw();
        }

    }

    class Triangle : Shape
    {
        public override void draw()
        {
            Console.WriteLine("Drawing a Triangle");
            base.draw();
        }

    }
    class Rectangle  : Shape
    {
        public override void draw()
        {
            Console.WriteLine("Drawing a Rectangle");
            base.draw();
        }

    }
   
    class Program
    {
        static void Main(string[] args)
        {
            /* var drawObject = new List<Shape>
             {
                 new Circle(),
                 new Triangle(),
                 new Rectangle()
             };*/
            Shape s;
            Console.WriteLine("Choose a shape to draw:");
            int ui=0;
            while (ui != 4)
            {
                Console.WriteLine("1.Rectangle \n2.Circle \n3.triangle \n4.Exit");
                ui = Convert.ToInt32(Console.ReadLine());

                switch (ui)
                {
                    case 1:
                        s = new Rectangle();
                        s.draw();
                        break;
                    case 2:
                        s = new Circle();
                        s.draw();
                        break;
                    case 3:
                        s = new Triangle();
                        s.draw();
                        break;
                    case 4:
                        Console.WriteLine("You are now exiting.....\nPress Enter to continue");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
    }
}
