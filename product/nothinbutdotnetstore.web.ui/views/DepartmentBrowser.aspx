<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application.catalogbrowsing" %>
<%@ Import Namespace="nothinbutdotnetstore.web.core.urls" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
              <%--each department should go here--%>
              <%
                  foreach (var department in this.model)
                  {%>
              <tr class="ListItem">
                 <td><a href="<%= CommandUrl.to_run<CatalogController>(x => x.get_the_main_departments())
                 .with(department) %>"><%=department.name%></a></td>
           	  </tr>        
              <%
                  }%>
      	    </table>            
</asp:Content>

