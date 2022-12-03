<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="registration.changepassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>

         <tr>
                <td>Old Password :</td>
                <td><asp:TextBox ID="txtoldpassword" runat="server"></asp:TextBox></td>
                    </tr>
                <tr>
                    <td>New Password:</td>
                    <td><asp:TextBox ID="txtnewpassword" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Confirm Password:</td>
                    <td><asp:TextBox ID="txtconfirmpassword" runat="server"></asp:TextBox></td>
                </tr>

         <tr>
                <td></td>
                <td><asp:Button ID="btnchangepassword" runat="server" Text="Save Password" OnClick="btnchangepassword_Click" /></td>
                    </tr>
          <tr>
            <td>

            </td>
            <td>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>

    </table>
</asp:Content>
