﻿using System;
using System.Drawing;
using V;

namespace VExp
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector size = new Vector(400, 300);

            ExpVectorCross();
            VisualizationVectorCross(size);

            ExpVectorDimensionalityChanges();

            ExpVectorArithmetic();
            VisualizationVectorSum(size);

            ExpVectorGeometry();

            Console.ReadLine();
        }

        public static void ExpVectorCross()
        {
            Vector cross2d = Vector.Cross(new Vector(1, 0));
            Vector cross3d = Vector.Cross(new Vector(1, 0, 0), new Vector(0, 1, 0));
            Vector cross4d = Vector.Cross(new Vector(1, 0, 0, 0), new Vector(0, 1, 0, 0), new Vector(0, 0, 1, 0));
        }

        private static void VisualizationVectorCross(Vector size)
        {
            using (Render render = new Render(size))
            {
                render.DrawAxes();

                Vector q = Vector.Normalize(new Vector(-0.2, 0.3, -0.3));
                DrawLine(render, q, Color.Green);

                Vector r = Vector.Normalize(new Vector(0.4, 0.4, 0.1));
                DrawLine(render, r, Color.Green);

                Vector cross = Vector.Cross(q, r);
                DrawLine(render, cross, Color.Blue);

                render.Save(@"..\..\img\cross.png");
            }
        }

        private static void ExpVectorDimensionalityChanges()
        {
            Vector addDimension = Vector.Insert(new Vector(2, 2), 0, 1);
            Vector removeDimension = Vector.Remove(new Vector(2, 0, 2), 1);

            Vector prefixDimension = Vector.Prefix(new Vector(2, 2), 1);
            Vector unprefixDimension = Vector.UnPrefix(new Vector(1, 2, 2));

            Vector postfixDimension = Vector.Postfix(new Vector(2, 2), 1);
            Vector unpostfixDimension = Vector.UnPostfix(new Vector(2, 2, 1));

            Vector[] swap1 = Vector.Swap(new Vector(1, 2, 3));
            Vector[] swap2 = Vector.Swap(new Vector(1, 2, 3), new Vector(4, 5, 6));
        }

        private static void ExpVectorArithmetic()
        {
            Vector add1 = new Vector(1, 2) + new Vector(2, 1);
            Vector add2 = new Vector(1, 2) + 2;
            Vector add3 = 2 + new Vector(2, 1);

            Vector sub1 = new Vector(1, 2) - new Vector(2, 1);
            Vector sub2 = new Vector(1, 2) - 2;
            Vector sub3 = 2 - new Vector(2, 1);

            Vector mul1 = new Vector(1, 2) * new Vector(2, 1);
            Vector mul2 = new Vector(1, 2) * 2;
            Vector mul3 = 2 * new Vector(2, 1);

            Vector div1 = new Vector(1, 2) / new Vector(2, 1);
            Vector div2 = new Vector(1, 2) / 2;
            Vector div3 = 2 / new Vector(2, 1);

            Vector invert = -new Vector(1, 2, 3);

            Vector min = Vector.Min(new Vector(-1, 1, -1), new Vector(1, -1, 1));
            Vector max = Vector.Max(new Vector(-1, 1, -1), new Vector(1, -1, 1));
        }

        private static void VisualizationVectorSum(Vector size)
        {
            using (Render render = new Render(size))
            {
                render.DrawAxes();

                Vector q = new Vector(-0.4, 0.3, -0.6);
                DrawLine(render, q, Color.Green);

                Vector r = new Vector(0.7, 0.4, 0.3);
                DrawLine(render, r, Color.Green);

                Vector sum = q + r;
                DrawLine(render, sum, Color.Blue);

                render.Save(@"..\..\img\sum.png");
            }
        }

        private static void ExpVectorGeometry()
        {
            Vector normalize = Vector.Normalize(new Vector(1, 1));
            double dot = Vector.Dot(new Vector(1, 0), new Vector(0.5, 0.5));
        }

        private static void DrawLine(Render render, Vector v, Color color)
        {
            Vector zero = Vector.Create(3, 0);

            render.DrawLine(zero, v, color);

            Vector vOnXZ = Vector.Set(v, 0, 1);
            render.DrawLine(v, vOnXZ, color, dotted: true);

            Vector vOnX = Vector.Set(vOnXZ, 0, 2);
            render.DrawLine(vOnXZ, vOnX, color, dotted: true);

            Vector vOnZ = Vector.Set(vOnXZ, 0, 0);
            render.DrawLine(vOnXZ, vOnZ, color, dotted: true);

            render.DrawText(v, Vector.Map(v, (d) => Math.Round(d, 3)).ToString(), color);
        }
    }
}
