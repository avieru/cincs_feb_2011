<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="c#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.ProductBrowser"
CodeFile="ProductBrowser.aspx.cs" MasterPageFile="Store.master" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <form></form>
    <p id="noResultsParagraph" runat="server" visible="true">No Results Found</p>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Quantity</th>                   
                        <th>Price</th>                                                
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
    
    <% foreach (var product in this.model)
       {%>
		<!-- for each product in the department -->
                <tr class="nonShadedRow">                    
                    <td class="ListItem">                    
                        <a href='Replace with a link to the detail page for the product'><%= product.name %></a>
                    </td>
                    <td><%= product.description %></td>
                    <td><input type="text" class="normalTextBox" value="1" /></td>
                    <td><%= product.price.ToString("c") %></td>               
                    <td><input type="checkbox" class="normalCheckBox" /></td>
                    <td><asp:button id="addToCartButton" runat="server" Text="Add To cart"/></td>
                </tr>
    						
                <%
       }%>
    	</table>	
								<table>
									<tr>
										<td>
                      <input type="button" value="Add Selected Items To Cart" />
										<td>
                      <input type="button" value="Go To Shopping Cart" />
										<td>
                      <input type="button" value="Continue to checkout" />
										</td>
									</tr>
								</table>							
								    
								
							
		</asp:Content>
