<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .first{
            width:390px;
            height:200px;
        }
        
        .other{
         margin-left :-240px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Select First Image:
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            Select Second Image:
            <asp:FileUpload ID="FileUpload2" runat="server" /><br />
            Select Third Image: 
            <asp:FileUpload ID="FileUpload3" runat="server" />
            <br />
            <br />

            <asp:Button ID="Button1" runat="server" Text="Store" />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" DataKeyField="i">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <h2>See Image Here</h2>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="Image1" CssClass="first" runat="server" ImageUrl='<%#bind("fimg") %>' />
                            </td>
                        </tr>
                        <tr>
                            <div class="cn">
                                <td>
                                    <asp:ImageButton CommandName="F" ID="ImageButton1" runat="server" ImageUrl='<%#bind("simg") %>'
                                        Width="200px" Height="200px" /></td>
                                <td>
                                    <asp:ImageButton CommandName="S" ID="ImageButton2" runat="server" ImageUrl='<%#Bind("timg") %>'
                                        CssClass="other" Width="200px" Height="200px" /></td>
                            </div>
                        </tr>
                    </table>
               
                </ItemTemplate>
            </asp:DataList>
        </div>       
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
            SelectCommand="SELECT * FROM [getImag]"></asp:SqlDataSource>
    </form>
</body>
</html>
