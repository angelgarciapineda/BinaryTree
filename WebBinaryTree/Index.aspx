<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebBinaryTree.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
    <title>Árbol binario asp.NET</title>
</head>
<body>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
    <form id="form1" runat="server">
        <div class="container" style="margin-top: 100px; width: auto; height: 250px;">
            <div class="row">
                <div class="col-sm-6">
                    <div class="m-3 row">
                        <div class="col-2">
                            <label for="exampleInputEmail1" class="form-label">Raiz</label>
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="txtRoot" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-6">
                            <asp:Button ID="btnCreateRoot" runat="server" Text="Crear raiz del arbol" class="btn btn-primary" style="display: block; width:100%;" OnClick="btnCreateRoot_Click" />
                        </div>
                    </div>
                    <div class="m-3 row">
                        <div class="col-2">
                            <label for="exampleInputPassword1" class="form-label">Dato</label>
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="txtData" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-6">
                            <asp:Button ID="btnCreateData" runat="server" Text="Insertar dato" class="btn btn-success" style="display: block; width:100%;" OnClick="btnCreateData_Click" />
                        </div>
                    </div>
                    <div class="m-3 row">
                        <div class="col-2">
                        </div>
                        <div class="col-4">
                        </div>
                        <div class="col-6">
                            <asp:Button ID="btnSearch" runat="server" Text="Buscar" class="btn btn-warning" style="display: block; width:100%;" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                    <div class="m-3 row">
                        <div class="col-2">
                        </div>
                        <div class="col-4">
                        </div>
                        <div class="col-6">
                            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" class="btn btn-danger" style="display: block; width:100%;" OnClick="btnDelete_Click" />
                        </div>
                    </div>
                    <div class="m-3 row">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="col-sm-4 list-group">
                    <div class="m-3 ">
                        <div class="col-auto" style="height: 250px;">
                            <asp:ListBox ID="lsData" runat="server" class="w-100 h-100"></asp:ListBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-2">
                    <div class="m-3 row">
                        <asp:Button ID="btnInOrder" runat="server" Text="InOrder" class="btn btn-secondary" OnClick="btnInOrder_Click" />
                    </div>
                    <div class="m-3 row">
                        <asp:Button ID="btnPreOrder" runat="server" Text="PreOrder" class="btn btn-secondary" OnClick="btnPreOrder_Click" />
                    </div>
                    <div class="m-3 row">
                        <asp:Button ID="btnPostOrder" runat="server" Text="PostOrder" class="btn btn-secondary" OnClick="btnPostOrder_Click" />
                    </div>
                    <div class="m-3 row">
                        <asp:Button ID="btnDraw" runat="server" Text="Dibujar" class="btn btn-secondary" OnClick="btnDraw_Click" />
                    </div>
                </div>
            </div>
            <asp:Image ID="Image1" runat="server" />
        </div>

    </form>

</body>
</html>
