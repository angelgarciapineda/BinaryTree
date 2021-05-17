using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using BusinessLogic;

namespace WebBinaryTree
{
    public partial class BinaryTreeDesign : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // Generate the drawing canvas
            Bitmap bmpDiagram = new Bitmap(500, 400);
            Graphics g = Graphics.FromImage(bmpDiagram);
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.HighQuality;

            // Ggenerate the shape of a person
            GraphicsPath node = new GraphicsPath();
            RectangleF myRectangleF = new RectangleF(5, 5, 50, 50);
            node.AddEllipse(myRectangleF);
            node.AddRectangle(myRectangleF);

            // Draw a few people
            //DrawNode(g, node, Color.Red, 200, 10, "Boss");
            //DrawNode(g, node, Color.Blue, 50, 170, "Worker 1");
            //ConnectNode(g, 80, 160, 230, 110, Color.Blue);
            //DrawNode(g, node, Color.Blue, 150, 170, "Worker 2");
            //ConnectNode(g, 180, 160, 230, 110, Color.Blue);
            //DrawNode(g, node, Color.Green, 250, 170, "Worker 3");
            //ConnectNode(g, 280, 160, 230, 110, Color.Green);
            //DrawNode(g, node, Color.Green, 350, 170, "Worker 4");
            //ConnectNode(g, 380, 160, 230, 110, Color.Green);

            Tree arbol = (Tree)Session["tree"];
            DrawNode(g, node, Color.Red, 200, 10, arbol.raiz.Dato.ToString());

            List<int> nodo = (List<int>)Session["nodo"];
            for (int c = 0; c < nodo.Count; c++)
            {
                if (arbol.raiz.Dato > nodo[c])
                {
                    //actual.Izq = Insertar(dato, actual.Izq, ref msj);
                    //actual.Izq.Padre = actual;
                    DrawNode(g, node, Color.Green, 100, 170, nodo[c].ToString());
                }
                if (arbol.raiz.Dato < nodo[c])
                {
                    //actual.Der = Insertar(dato, actual.Der, ref msj);
                    //actual.Der.Padre = actual;
                    DrawNode(g, node, Color.Green, 300, 170, nodo[c].ToString());
                }
                if (arbol.raiz.Dato == nodo[c])
                {
                }
            }

            Response.ContentType = "image/jpeg";
            bmpDiagram.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();
        }

        private void DrawNode(Graphics graphics, GraphicsPath Shape, Color fill, float x, float y, string Name)
        {
            // Position the shape
            graphics.TranslateTransform(x, y);

            // Draw the person and fill it
            // with a gradient
            Brush oBrush = new LinearGradientBrush(new Rectangle(0, 0, 60, 90), Color.Black, fill, 90, true);
            graphics.FillPath(oBrush, Shape);
            graphics.DrawPath(Pens.Black, Shape);

            // Draw the name
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            Font oFont = new Font("Tahoma", 8);
            SizeF size = graphics.MeasureString(Name, oFont);
            RectangleF rect = new RectangleF(30 - (size.Width / 2), (size.Height + 10), size.Width, size.Height);
            graphics.DrawString(Name, oFont, Brushes.Black, rect, sf);

            // Rset the coordinate shift
            graphics.ResetTransform();
        }

        public void ConnectNode(Graphics g, float x1,
           float y1, float x2, float y2, Color lineColor)
        {
            // Draw a line with a custom arrow-head
            Pen p = new Pen(lineColor, 1);
            CustomLineCap myCap =
               new AdjustableArrowCap(5, 5, true);
            p.EndCap = LineCap.Custom;
            p.CustomEndCap = myCap;
            g.DrawLine(p, x1, y1, x2, y2);
        }

    }
}