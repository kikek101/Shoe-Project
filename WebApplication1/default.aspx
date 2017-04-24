<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebShoes.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <label for="DropDownListShoes" id="LblShoesDdl" runat="server">Shoe Name</label>
                <br/>
                <asp:DropDownList ID="DropDownListShoes" runat="server" AutoPostBack="True"></asp:DropDownList>
            </div>
            <div>
                <label for="DropDownListShoeTypes" id="LblShoeTypesDdl" runat="server">Shoe Type</label>
                <br/>
                <asp:DropDownList ID="DropDownListShoeTypes" runat="server" AutoPostBack="True"></asp:DropDownList>
            </div>
            <div>
                <label for="DropDownListDesigners" id="LblDesignersDdl" runat="server"> Designer</label><br/>
                <asp:DropDownList ID="DropDownListDesigners" runat="server" AutoPostBack="True"></asp:DropDownList>
            </div>
            <div>
                <label for="DropDownListShoePrices" id="LblShoePricesDdl" runat="server"> Shoe Price</label><br/>
                <asp:DropDownList ID="DropDownListShoePrices" runat="server" AutoPostBack="True"></asp:DropDownList>
            </div>
            <div>
                <label for="DropDownListColours" id="Lb1ColourDdl" runat="server"> Colour</label><br/>
                <asp:DropDownList ID="DropDownListColours" runat="server" AutoPostBack="True"></asp:DropDownList>
            </div>
        </div>

        <div>
            <asp:Button ID="btnUpdate" runat="server" Text="update" Visible="False" />
        </div>
        <div>
            <asp:Button ID="btnReset" runat="server" Text="reset" ButtonParam="reset" OnClick="btnReset_Click" UseSubmitBehavior="False" />
        </div>

        <div>
            <asp:Table runat="server" ID="tblShoeResult" Font-Size="Large" ForeColor="Black" GridLines="Both" Enabled="True" HorizontalAlign="Left" Width="15" Height="15" CellSpacing="8" CellPadding="8" BorderStyle="Outset" BackColor="White" Font-Names="Arial" Visible="False">
                <asp:TableHeaderRow BackColor="#666699" BorderStyle="Outset" HorizontalAlign="Left" Height="8" Width="8">
                    <asp:TableHeaderCell>Shoe ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Shoe Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Shoe Type ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Shoe Type</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Designer ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Designer Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Shoe Price (£)</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Colour</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow BorderStyle="Outset" Font-Size="Large">
                    <asp:TableCell ID="cellShoeID"></asp:TableCell>
                    <asp:TableCell ID="cellShoeName"></asp:TableCell>
                    <asp:TableCell ID="cellShoeTypeID"></asp:TableCell>
                    <asp:TableCell ID="cellShoeType"></asp:TableCell>
                    <asp:TableCell ID="cellDesignerID"></asp:TableCell>
                    <asp:TableCell ID="cellDesignerName"></asp:TableCell>
                    <asp:TableCell ID="cellShoePrice"></asp:TableCell>
                    <asp:TableCell ID="cellColour"></asp:TableCell>
                </asp:TableRow>
                <%--<asp:TableFooterRow></asp:TableFooterRow>--%>
            </asp:Table>
        </div>

    </form>
</body>
</html>
