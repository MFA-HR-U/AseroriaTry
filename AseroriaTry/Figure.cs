using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseroriaTry
{
    public class Figure
    {
        public List<PointF> vertices;
        public PointF Centroid, Last;
        // int z;

        public Figure()  //metodo constructor
        {
            // z = 100;
            vertices = new List<PointF>(); // inicializar objeto lista

        }

        public void Add(PointF point)   //agrgar los vertices a la lista
        {
            Centroid = new PointF();
            vertices.Add(point);

            for (int p = 0; p < vertices.Count; p++)
            {
                Centroid.X += vertices[p].X;
                Centroid.Y += vertices[p].Y;
            }
           

            Centroid.X /= vertices.Count;
            Centroid.Y /= vertices.Count;
        }

        public void DibujarCuadradoInicial(Graphics g,Figure Cua)
        {
            g.DrawPolygon(Pens.White,Cua.vertices.ToArray());
        
        }





    }
}
