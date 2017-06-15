

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="With Repeater.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater runat="server" DataSourceID="SqlDataSource1" 
            ID="repeater" OnItemCommand="Unnamed1_ItemCommand">
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
                                    Width="140px" Height="100px" /></td>
                            <td>
                                <asp:ImageButton CommandName="S" ID="ImageButton2" runat="server" ImageUrl='<%#Bind("timg") %>'
                                    CssClass="other" Width="150px" Height="100px" /></td>
                        </div>
                    </tr>
                </table>

            </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:testConnectionString %>" 
            SelectCommand="SELECT * FROM [getImag]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
