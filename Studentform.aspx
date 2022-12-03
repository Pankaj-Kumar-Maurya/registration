<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Studentform.aspx.cs" Inherits="registration.Studentform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
        <tr>
            <td>Student Name :</td>
            <td><asp:TextBox ID="txtname" runat="server" ></asp:TextBox></td>
        </tr>
         <tr>
            <td>Roll No. :</td>
            <td><asp:TextBox ID="Textage" runat="server" ></asp:TextBox></td>
        </tr>
         <tr>
            <td>Country :</td>
            <td><asp:TextBox ID="Textsalary" runat="server" ></asp:TextBox></td>
        </tr>
         <tr>
            <td></td>
            <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" /></td>
        </tr>
    </table>
</asp:Content>
