using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace WebBinaryTree
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int[] numeros = { 15, 3, 8, 40, 45, 13, 20, 30, 1, 7, 34, 48, 53, 9, 23, 12, 51, 4, 10 };
                Session["array"] = numeros;

                if (Session["tree"] != null)
                {
                    arbol = (Tree)Session["tree"];
                    test = (int[])Session["array"];
                    Label1.Text = String.Empty;
                }
                else
                {
                    test = (int[])Session["array"];
                    Session["tree"] = null;
                }
            }
            else
            {
                List<int> test3 = new List<int>();
                Label1.Text = "Carga por primera vez";
                test3.Add(-1);
                Session["nodo"] = test3;
            }
        }
        Tree arbol;
        protected void btnCreateRoot_Click(object sender, EventArgs e)
        {
            if (txtRoot.Text != "" && Convert.ToInt32(txtRoot.Text) > 0 && txtRoot.Text.Length > 0)
            {
                arbol = new Tree(Convert.ToInt32(txtRoot.Text));
                txtRoot.Text = String.Empty;
                Session["tree"] = arbol;
                Image1.ImageUrl = "BinaryTreeDrawing.aspx";
                lsData.Items.Clear();
            }
            else Label1.Text = "Si va a ingresar una raiz que sea un número y mayor a 0";
        }
        int[] test;
        List<int> test2 = new List<int>();
        protected void btnCreateData_Click(object sender, EventArgs e)
        {
            if (arbol != null)
            {

                if (txtData.Text != "" && Convert.ToInt32(txtData.Text) > 0 && txtData.Text.Length > 0)
                {
                    Label1.Text = arbol.Insertar(Convert.ToInt32(txtData.Text));
                    //Session["nodo"] = Convert.ToInt32(txtData.Text);
                    test2.Add(Convert.ToInt32(txtData.Text));
                    Session["nodo"] = test2;
                    txtData.Text = String.Empty;

                }
                else
                {
                    for (int c = 0; c < test.Length; c++)
                    {
                        Label1.Text = arbol.Insertar(test[c]);
                        txtData.Text = String.Empty;
                    }
                }
            }
            else
            {
                arbol = new Tree();
                if (txtData.Text != "" && Convert.ToInt32(txtData.Text) > 0 && txtData.Text.Length > 0)
                {
                    Label1.Text = arbol.Insertar(Convert.ToInt32(txtData.Text));
                    txtData.Text = String.Empty;
                }
                else
                {
                    for (int c = 0; c < test.Length; c++)
                    {
                        Label1.Text = arbol.Insertar(test[c]);
                        txtData.Text = String.Empty;
                    }
                }
                Session["tree"] = arbol;
            }
        }

        protected void btnInOrder_Click(object sender, EventArgs e)
        {
            lsData.Items.Clear();
            List<int> inOrder = null;
            inOrder = arbol.enOrden();
            if (inOrder.Count > 0)
            {
                for (int y = 0; y < inOrder.Count; y++)
                    lsData.Items.Add(inOrder[y].ToString());
            }
            else Label1.Text = "No yupi";
            inOrder.Clear();
        }

        protected void btnPreOrder_Click(object sender, EventArgs e)
        {
            lsData.Items.Clear();
            List<int> preOrder = arbol.preOrden();
            if (preOrder.Count > 0)
            {
                for (int y = 0; y < preOrder.Count; y++)
                    lsData.Items.Add(preOrder[y].ToString());
            }
            else Label1.Text = "No yupi";
            preOrder.Clear();
        }

        protected void btnPostOrder_Click(object sender, EventArgs e)
        {
            lsData.Items.Clear();
            List<int> postOrder = arbol.postOrden();
            if (postOrder.Count > 0)
            {
                for (int y = 0; y < postOrder.Count; y++)
                    lsData.Items.Add(postOrder[y].ToString());
            }
            else Label1.Text = "No yupi";
            postOrder.Clear();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                arbol.Borrar(Convert.ToInt32(lsData.SelectedValue));
                Label1.Text = "Borrado con exito";
                lsData.Items.Clear();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error: " + ex.Message;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int nodo = arbol.Search(Convert.ToInt32(txtData.Text));
                if (nodo >= 0) Label1.Text = "Nodo " + nodo + " encontrado";
                else Label1.Text = "Nodo no encontrado";
                txtData.Text = String.Empty;
            }
            catch (Exception ex)
            {
                Label1.Text = "Error: " + ex.Message;
            }

        }

        protected void btnDraw_Click(object sender, EventArgs e)
        {
            Image1.ImageUrl = "BinaryTreeDrawing.aspx";
        }
    }
}