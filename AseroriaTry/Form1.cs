namespace AseroriaTry
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;

        Figure Loquesea ;

        Translados Transla;
        float angulo = 180 / 57.2958f;
        public Form1()
        {
            InitializeComponent();
        }

        public void Inicializar()
        {
            bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height); //el constructor de la vrable global

            g = Graphics.FromImage(bmp); //trabje el bitmap como objeto de clase grapihcs +

            pictureBox1.Image = bmp;


            //contructor del metodo para  la varible figura
            Loquesea = new Figure();

           

            // lineas amarillas

            int Sx = (pictureBox1.Width / 2);  // origen central en x
            int Sy = (pictureBox1.Height / 2); // origen central en y

            g.DrawLine(Pens.Yellow, Sx , 0, Sx , bmp.Height);
            g.DrawLine(Pens.Yellow, 0, Sy, bmp.Width, Sy);


            //dar valores iniciales al objecto figure
            Loquesea.Add(new PointF(0, 0));//a
            Loquesea.Add(new Point(0, 100)); //b
            Loquesea.Add(new Point(100, 100));  //c
            Loquesea.Add(new Point(100, 0));    //d


            // objeto para hacer translados
            Transla = new Translados(Loquesea);

           // LoqueseaRotado;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Inicializar();

           

            // Transla.Rotar(angulo,g);//naranja




        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            Loquesea.DibujarCuadradoInicial(g, Loquesea);//blanco
            //Transla.CuadradoAlcentro(pictureBox1.Width / 2, pictureBox1.Height / 2, g);//verde
            Transla.TranslateToOriginBasadoOrigen(g);//amarillo

            //Transla.imprimir();
            Transla.Rotar(angulo, g);//
                                     //

            Transla.CuadradoAlcentroRotado(pictureBox1.Width / 2, pictureBox1.Height / 2, g);

            pictureBox1.Invalidate();




        }
    }
}