<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Userform.aspx.cs" Inherits="registration.Userform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Name :</td>
            <td><asp:TextBox ID="txtname" runat="server" ></asp:TextBox></td>
        </tr>
         <tr>
            <td>Age :</td>
            <td><asp:TextBox ID="txtage" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <td>Hobbies:</td>
            <td>
                <asp:CheckBoxList runat="server" ID="cblhobbies" RepeatColumns="6">
                    <asp:ListItem Text="Gaming" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Programming" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Editing" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Cricket" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Reading" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Hacking" Value="6"></asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
         <tr>
            <td></td>
            <td><asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" /></td>
        </tr>
       
    </table>
</asp:Content>
