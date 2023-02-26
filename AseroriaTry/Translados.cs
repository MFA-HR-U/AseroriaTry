using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AseroriaTry
{
    public class Translados
    {

        Figure CuboCentroCopia, CuboCentroCopia2,cuboRotar, cuadrado;
        List<PointF> listaaa = new List<PointF>();

        List<PointF> listaRotadaOrigen = new List<PointF>();
        List<PointF> listaf = new List<PointF>();

        public Translados(Figure fig) 
        {
           cuadrado = fig;


            //CuboCentroCopia.Add


            //CuboCentroCopia2 = cubo;

            //CuboCentroCopia = cuadrado;
           


        }


        public void CuadradoAlcentro(int Sx,int Sy,Graphics Dib)
        {


            List<Point> lista = new List<Point>();


            float x = cuadrado.Centroid.X - cuadrado.Centroid.X- cuadrado.Centroid.X ;
            float xCentroid = x+Sx;

            float y = cuadrado.Centroid.Y - cuadrado.Centroid.Y - cuadrado.Centroid.Y;
            float yCentroid=  y+ Sy;
                

            for (int i = 0; i < cuadrado.vertices.Count; i++)
            {
                lista.Add(new Point((int)cuadrado.vertices[i].X + (int)xCentroid, (int)cuadrado.vertices[i].Y + (int)yCentroid));
            }
            //lista lo voy a llenar con los puntos sunmados con widht y heigh 


            // g.DrawPolygon(Pens.White, lista.ToArray());

            //lo hago a lista por que es mas facil usar elmetodo drawpolygion
            
            Dib.DrawPolygon(Pens.Green, lista.ToArray());

        }


        public void TranslateToOriginBasadoOrigen(Graphics g)//lo ponel el 00 en la esquina
        {
            

            

            for (int p = 0; p < cuadrado.vertices.Count && listaaa.Count <5; p++)
            {
                listaaa.Add(new PointF((float)cuadrado.vertices[p].X - cuadrado.Centroid.X, cuadrado.vertices[p].Y - cuadrado.Centroid.Y));
                 
                //CuboCentroCopia.Add(new PointF((float)cuadrado.vertices[p].X - cuadrado.Centroid.X, cuadrado.vertices[p].Y - cuadrado.Centroid.Y));
            }
        

            g.DrawPolygon(Pens.Yellow, listaaa.ToArray());

            //return CuboCentroCopia;

        }

        public void  Rotar(float angle, Graphics g)
        {
          
            PointF Centroid;
            Centroid = new PointF();
           
            //--------calculo centroide
            for (int p = 0 ; p < (listaaa.Count); p++)
            {
                Centroid.X += listaaa[p].X;
                Centroid.Y += listaaa[p].Y;
            }
            Centroid.X /= listaaa.Count;
            Centroid.Y /= listaaa.Count;
            ///------------------------------------

            float x, y;

            x = (float)((Centroid.X * Math.Cos(angle)) - (Centroid.Y * Math.Sin(angle)));
            y = (float)((Centroid.X * Math.Sin(angle)) + (Centroid.Y * Math.Cos(angle)));

            for (int i = 0; i < listaaa.Count; i++)
            {
               

                listaRotadaOrigen.Add(new PointF(x,y));

            }

            g.DrawPolygon(Pens.Orange, listaRotadaOrigen.ToArray());
           
        }
        public void CuadradoAlcentroRotado(int Sx, int Sy, Graphics Dib)
        {

            PointF Centroid;
            Centroid = new PointF();

            //--------calculo centroide
            for (int p = 0; p < (listaRotadaOrigen.Count); p++)
            {
                Centroid.X += listaRotadaOrigen[p].X;
                Centroid.Y += listaRotadaOrigen[p].Y;
            }
            Centroid.X /= listaRotadaOrigen.Count;
            Centroid.Y /= listaRotadaOrigen.Count;
            ///------------------------------------


            float x = Centroid.X ;
            float xCentroid = x + Sx;

            float y = Centroid.Y ;
            float yCentroid = y + Sy;


            for (int i = 0; i < listaRotadaOrigen.Count; i++)
            {
                listaf.Add(new Point((int)listaRotadaOrigen[i].X + (int)xCentroid, (int)listaRotadaOrigen[i].Y + (int)yCentroid));
            }
           

            Dib.DrawPolygon(Pens.Orange, listaf.ToArray());

        }

        public void  imprimir ()
        {
            Console.Write("valores" + listaaa) ;
        
        }


    }
}
