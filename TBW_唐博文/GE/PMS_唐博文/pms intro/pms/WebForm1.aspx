<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PMMSWeb.WebForm1" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.font8
	{color:windowtext;
	font-size:16.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	}
.font5
	{color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	}
.font0
	{color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	}
.font6
	{color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:宋体;
	}
td
	{border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            color:black;
	        font-size:11.0pt;
	        font-weight:400;
	        font-style:normal;
	        text-decoration:none;
	        font-family:Calibri, sans-serif;
	        text-align:general;
	        vertical-align:bottom;
	        white-space:nowrap;
	}
.font9
	{color:windowtext;
	font-size:8.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Tahoma, sans-serif;
	}
.shape {behavior:url(#default#VML);}
.font7
	{color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:"Times New Roman", serif;
	}
        .style1 {
            height: 26.25pt;
            width: 458pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: 1.0pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style2 {
            height: 138.4pt;
            width: 50pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style3 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style4 {
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style5 {
            height: 24.0pt;
            width: 129pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style6 {
            height: 24.0pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style7 {
            width: 137pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style8 {
            width: 62pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style9 {
            width: 129pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style10 {
            height: 35.25pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style11 {
            width: 129pt;
            color: windowtext;
            font-size: 14.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style12 {
            height: 55.15pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style13 {
            width: 328pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style14 {
            height: 33.75pt;
            width: 50pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style15 {
            height: 33.75pt;
            width: 80pt;
            color: windowtext;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style16 {
            height: 33.75pt;
            width: 137pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style17 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: top;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style18 {
            height: 33.75pt;
            width: 73pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: top;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style19 {
            height: 255.9pt;
            width: 50pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style20 {
            width: 80pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style21 {
            height: 26.25pt;
            width: 137pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style22 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style23 {
            height: 26.25pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style24 {
            width: 137pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style25 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style26 {
            height: 97.5pt;
            width: 80pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style27 {
            width: 65pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style28 {
            width: 263pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style29 {
            height: 49.5pt;
            width: 65pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style30 {
            height: 105.9pt;
            width: 80pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style31 {
            width: 65pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style32 {
            height: 52.95pt;
            width: 65pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style33 {
            width: 263pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style34 {
            height: 78.75pt;
            width: 50pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style35 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style36 {
            width: 72pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style37 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style38 {
            height: 22.2pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style39 {
            width: 72pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style40 {
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style41 {
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style42 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style43 {
            height: 21.6pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style44 {
            width: 72pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style45 {
            height: 32.25pt;
            width: 50pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style46 {
            width: 80pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style47 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style48 {
            height: 132.0pt;
            width: 50pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style49 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style50 {
            height: 51.0pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style51 {
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style52 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style53 {
            height: 12.75pt;
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style54 {
            height: 12.75pt;
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style55 {
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style56 {
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style57 {
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
    .dxeTextBox,
.dxeMemo
{
    background-color: white;
    border: solid 1px #9f9f9f;
}
.dxeTextBoxSys, .dxeMemoSys
{
    border-collapse:separate!important;
}

.dxeTextBox .dxeEditArea
{
    background-color: white;
}

.dxeEditArea 
{
	font-family: Tahoma;
	font-size: 9pt;
	border: 1px solid #A0A0A0;
}

.dxeEditAreaSys
{
	border: 0px!important;
	padding: 0px;
	width: 100%;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:458pt" width="611">
            <colgroup>
                <col style="mso-width-source:userset;mso-width-alt:2413;width:50pt" 
                    width="66" />
                <col style="mso-width-source:userset;mso-width-alt:3913;width:80pt" 
                    width="107" />
                <col style="mso-width-source:userset;mso-width-alt:3181;width:65pt" 
                    width="87" />
                <col style="mso-width-source:userset;mso-width-alt:3510;width:72pt" 
                    width="96" />
                <col style="mso-width-source:userset;mso-width-alt:3035;width:62pt" 
                    width="83" />
                <col style="mso-width-source:userset;mso-width-alt:2742;width:56pt" 
                    width="75" />
                <col style="mso-width-source:userset;mso-width-alt:3547;width:73pt" 
                    width="97" />
            </colgroup>
            <tr height="17" style="height:12.75pt">
                <td class="style1" colspan="7" height="35" width="611">
                    设备维修记录单<font class="font8"> Medical Record of Machine</font></td>
            </tr>
            <tr height="32" style="mso-height-source:userset;height:24.0pt">
                <td class="style2" height="184" rowspan="4" width="66">
                    热线描述<font class="font5"><span style="mso-spacerun:yes">&nbsp;</span></font></td>
                <td class="style3">
                    设备类别<font class="font0">/</font><font class="font6">名称</font><font 
                        class="font5"><span style="mso-spacerun:yes">&nbsp;</span></font></td>
                <td class="style4" colspan="2">
                    <dx:ASPxTextBox ID="machineName" runat="server" Height="100%" Width="100%">
                    </dx:ASPxTextBox>
                    </td>
                <td class="style3">
                    工作组</td>
                <td align="left" colspan="2" height="32" style="border-right:1.0pt solid black;
  height:24.0pt;width:129pt" valign="top" width="172">
                    <!--[if gte vml 1]><v:shapetype
   id="_x0000_t201" coordsize="21600,21600" o:spt="201" path="m,l,21600r21600,l21600,xe">
   <v:stroke joinstyle="miter" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <v:path shadowok="f" o:extrusionok="f" strokeok="f" fillok="f"
    o:connecttype="rect" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" shapetype="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
  </v:shapetype><v:shape id="_x0000_s1048" type="#_x0000_t201" style='position:absolute;
   margin-left:8.25pt;margin-top:6pt;width:36.75pt;height:18pt;z-index:1;
   mso-wrap-style:tight' o:gfxdata="UEsDBBQABgAIAAAAIQA0Ev94FAEAAFACAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbKSSy07DMBBF
90j8g+UtSpyyQAg16YLHEliUDxjsSWLhl2y3tH/PJE0kqEo33Vj2zNy5x2MvVztr2BZj0t7VfFFW
nKGTXmnX1fxj/VLcc5YyOAXGO6z5HhNfNddXy/U+YGKkdqnmfc7hQYgke7SQSh/QUab10UKmY+xE
APkFHYrbqroT0ruMLhd56MGb5RO2sDGZPe8ofCAJruPs8VA3WNVc20E/xMVJRUSTjiQQgtESMt1N
bJ064iomppKUY03qdUg3BP6Pw5D5y/TbYNK90TCjVsjeIeZXsEQupNHh00NUQkX4ptGmebMozzc9
Qe3bVktUXm4szbCcOs7Y5+0zvQ+Kcb3ceWwz+4rxPzQ/AAAA//8DAFBLAwQUAAYACAAAACEArTA/
8cEAAAAyAQAACwAAAF9yZWxzLy5yZWxzhI/NCsIwEITvgu8Q9m7TehCRpr2I4FX0AdZk2wbbJGTj
39ubi6AgeJtl2G9m6vYxjeJGka13CqqiBEFOe2Ndr+B03C3WIDihMzh6RwqexNA281l9oBFTfuLB
BhaZ4ljBkFLYSMl6oAm58IFcdjofJ0z5jL0MqC/Yk1yW5UrGTwY0X0yxNwri3lQgjs+Qk/+zfddZ
TVuvrxO59CNCmoj3vCwjMfaUFOjRhrPHaN4Wv0VV5OYgm1p+LW1eAAAA//8DAFBLAwQUAAYACAAA
ACEA1qevHrkBAAADBAAAHwAAAGNsaXBib2FyZC9kcmF3aW5ncy9kcmF3aW5nMS54bWysk9tO3DAQ
hu8r9R0s35eEiF1oRBa1y0GVUFm15QEGZ5JY+CTbpOHtO06yy2ovECrcjT3jb/45+Pxi0Ir16IO0
puLHRzlnaIStpWkrfv/n+ssZZyGCqUFZgxV/xsAvVp8/nUPZenCdFIwIJpRQ8S5GV2ZZEB1qCEfW
oSFfY72GSEffZrWHv0TWKivyfJlpkIavXlCXEIE9efkfKGXFI9ZrMD0EQipR7t/MGpV4PxlK0994
99ttfFIufvYbz2RdceqcAU0t4tnsmMPomB28al8AQ+N1irdNw4aKnxRny2JBrGey86+L08WEwyEy
kfzL5Wmx4EyQv6DYPJ/TdXevA0R39SqCJE5SyNiT56RI6ky/keKw4mJb8bpD8ci+24EVJ7vqdw8I
cUvTCczYdQemxW/BoYi0bSmW0qUeTvSxT7uHD0q6a6lUEpDseYr+LUOkdkqBl1Y8aTRxWjePCiLt
eeikC5z5EvUD0uT8j3qUAmWIHqPoUsKGEv8imZPEnYMU7ssK8xp8yBSJveU4H+INWs2SQQpJyPhR
oL8Ns6RtyNjCSQcBqNl0cbD+Y8j8XdMf2z+v/gEAAP//AwBQSwMEFAAGAAgAAAAhAFNSiWHSAAAA
qwEAACoAAABjbGlwYm9hcmQvZHJhd2luZ3MvX3JlbHMvZHJhd2luZzEueG1sLnJlbHOskMFKBDEM
hu+C71Byt5nZg4hsZy8i7FXWBwhtplOcpqWt4r691b04sODFSyAJ+fLx7w+fcVUfXGpIYmDUAygW
m1wQb+D19Hz3AKo2EkdrEjZw5gqH6fZm/8IrtX5Ul5Cr6hSpBpbW8iNitQtHqjpllr6ZU4nUels8
ZrJv5Bl3w3CP5TcDpg1THZ2BcnQ7UKdz7p//Zqd5Dpafkn2PLO3KC2zdizuQiudmQOvL5FJH3V0B
r2uM/6kRYo9goxHZBcKf+aiz+G8N3EQ8fQEAAP//AwBQSwMEFAAGAAgAAAAhAP3BWu/OBgAAPRwA
ABoAAABjbGlwYm9hcmQvdGhlbWUvdGhlbWUxLnhtbOxZT28bRRS/I/EdRntv4/+NozpV7NgNtGmj
2C3qcbwe704zu7OaGSf1DbVHJCREQVyQuHFAQKVW4lI+TaAIitSvwJuZ3fVOvCZJG4EozSHeffub
9/+9ebN79dqDiKFDIiTlccerXq54iMQ+n9A46Hh3RoNL6x6SCscTzHhMOt6cSO/a5vvvXcUbPqPJ
mGMxGYUkIggYxXIDd7xQqWRjbU36QMbyMk9IDM+mXERYwa0I1iYCH4GAiK3VKpXWWoRp7G0CR6UZ
9Rn8i5XUBJ+JoWZDUIwjkH57OqU+MdjJQVUj5Fz2mECHmHU84DnhRyPyQHmIYangQcermD9vbfPq
Gt5IFzG1Ym1h3cD8pevSBZODmpEpgnEutDpotK9s5/wNgKllXL/f7/WrOT8DwL4Pllpdijwbg/Vq
N+NZANnLZd69SrPScPEF/vUlndvdbrfZTnWxTA3IXjaW8OuVVmOr5uANyOKbS/hGd6vXazl4A7L4
1hJ+cKXdarh4AwoZjQ+W0Dqgg0HKPYdMOdspha8DfL2SwhcoyIY8u7SIKY/VqlyL8H0uBgDQQIYV
jZGaJ2SKfcjJHo7GgmItAG8QXHhiSb5cImlZSPqCJqrjfZjg2CtAXj3//tXzp+jV8yfHD58dP/zp
+NGj44c/Wl7Owh0cB8WFL7/97M+vP0Z/PP3m5eMvyvGyiP/1h09++fnzciBU0MLCF18++e3Zkxdf
ffr7d49L4FsCj4vwEY2IRLfIEdrnEdhmHONqTsbifCtGIabOChwC7xLWfRU6wFtzzMpwXeI6766A
5lEGvD677+g6DMVM0RLJN8LIAe5yzrpclDrghpZV8PBoFgflwsWsiNvH+LBMdg/HTmj7swS6ZpaU
ju97IXHU3GM4VjggMVFIP+MHhJRYd49Sx6+71Bdc8qlC9yjqYlrqkhEdO4m0WLRDI4jLvMxmCLXj
m927qMtZmdXb5NBFQkFgVqL8iDDHjdfxTOGojOUIR6zo8JtYhWVKDufCL+L6UkGkA8I46k+IlGVr
bguwtxD0Gxj6VWnYd9k8cpFC0YMynjcx50XkNj/ohThKyrBDGodF7AfyAFIUoz2uyuC73K0QfQ9x
wPHKcN+lxAn36Y3gDg0clRYJop/MREksrxPu5O9wzqaYmC4DLd3p1BGN/65tMwp920p417Y73hZs
YmXFs3OiWa/C/Qdb9DaexXsEqmJ5i3rXod91aO+t79Cravni+/KiFUOX1gOJnbXN5B2tHLynlLGh
mjNyU5rZW8IGNBkAUa8zB0ySH8SSEC51JYMABxcIbNYgwdVHVIXDECcwt1c9zSSQKetAooRLOC8a
cilvjYfZX9nTZlOfQ2znkFjt8okl1zU5O27kbIxWgTnTZoLqmsFZhdWvpEzBttcRVtVKnVla1ahm
mqIjLTdZu9icy8HluWlAzL0Jkw2CeQi83IIjvhYN5x3MyET73cYoC4uJwkWGSIZ4QtIYabuXY1Q1
QcpyZckQbYdNBn12PMVrBWltzfYNpJ0lSEVxjRXisui9SZSyDF5ECbidLEcWF4uTxeio47WbtaaH
fJx0vCkcleEySiDqUg+TmAXwkslXwqb9qcVsqnwRzXZmmFsEVXj7Yf2+ZLDTBxIh1TaWoU0N8yhN
ARZrSVb/WhPcelEGlHSjs2lRX4dk+Ne0AD+6oSXTKfFVMdgFivadvU1bKZ8pIobh5AiN2UzsYwi/
TlWwZ0IlvPEwHUHfwOs57W3zyG3OadEVX4oZnKVjloQ4bbe6RLNKtnDTkHIdzF1BPbCtVHdj3PlN
MSV/QaYU0/h/ZoreT+AVRH2iI+DDu16Bka6UjseFCjl0oSSk/kDA4GB6B2QLvOKFx5BU8GLa/Apy
qH9tzVkepqzhJKn2aYAEhf1IhYKQPWhLJvtOYVZN9y7LkqWMTEYV1JWJVXtMDgkb6R7Y0nu7h0JI
ddNN0jZgcCfzz71PK2gc6CGnWG9OJ8v3XlsD//TkY4sZjHL7sBloMv/nKubjwWJXtevN8mzvLRqi
HyzGrEZWFSCssBW007J/TRXOudXajrVkca2ZKQdRXLYYiPlAlMCLJKT/wf5Hhc/sRwy9oY74PvRW
BN8vNDNIG8jqS3bwQLpBWuIYBidLtMmkWVnXpqOT9lq2WV/wpJvLPeFsrdlZ4n1OZ+fDmSvOqcWL
dHbqYcfXlrbS1RDZkyUKpGl2kDGBKfuYtYsTNA6qHQ8+KEGgH8AVfJLygFbTtJqmwRV8Z4JhyX4c
6njpRUaB55aSY+oZpZ5hGhmlkVGaGQWGs/QzTEZpQafSX07gy53+8VD2kQQmuPSjStZUnS9+m38B
AAD//wMAUEsDBAoAAAAAAAAAIQBSLnwD2AQAANgEAAAaAAAAY2xpcGJvYXJkL21lZGlhL2ltYWdl
MS5wbmeJUE5HDQoaCgAAAA1JSERSAAAAUQAAACcIBgAAAHf0pOoAAAABc1JHQgCuzhzpAAAABGdB
TUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAA
CXBIWXMAABcRAAAXEQHKJvM/AAAEQUlEQVRoQ+2Z3UtUQRjGoyLsAyKpC70IwgJRaO1KLSsKuohu
lEUEIdoLk5AuEgU1Nz/I2KhMUVgwBS+9CQL/geguSsldKslcXcSP6iLDD6jc3bf3kR0ahj3Hnd3V
VZyFh7PnY86Z+Z1nZt53zp495mcIGAKGgCFgCBgChoAhYAhoEigvL99XW1t7cHh4+FCi6uvrO1Rd
Xb1enogyWHs1q7GzL3e73Y62tjZPb2+vt6enZ13d3d1aam/v8N53u72jo6PeSCTSyjqzs6lo1t7j
8ThbWloWW1tbqaqqiiorK6miokJLLtct6nreSQsLCxQOh4MM8YpmNXb25V6v19nc3LxYVlZG2dnZ
lJWVpa1LFy/Qq5dD3ItJB2Ihk7udBL0DXPYR67jFPY7w8des/Uk8I76ig4ODpQ0NDXMOh4MyMzPJ
5XJRY2Ojlp49fUwjb98AIYVCoXF24qU4ng6IDVIj0eiTSrnrNpAExHyLZ+H8EOtadJvMC7NvzsDA
QGl9ff1cXl4eFRUVkd/vX3eUzm91ZYmmv36itd8ruhAvS7UDxJ8sUmTVeEBqsnGafH6ja+N45zaX
yBBLSkooEAjo8Fu/NhJeo+DkZ4a4nAxEtaEbNVw+H8uNavlTjOF8crQsSguI+fn5VFxcTD6fTxvi
8tIvmpr4GI8TrdwW4OplK86ygggYSzEcWxXjmOzqDj5/w2Z4SJzvFkOUK1rOO3J31nWiOnFgf4QF
yJhQDm/Q3ROHppZME0Qx6CcDUXYk7gOIdayj0W2GBFH0gNOpIyfdKU0Q1S6JyUPXiXCyj3Us6jxs
ZYjImmqi3RfPQySwOZlUmiACAMYwOEiEKvGOibAAyrhYbpaIA2Un4jh0LwpRHTpSa8g0QBSOK4lC
FA1Sxzi72RnOQlaEEAcOFKHRC/6PSQcTFa5BMI6Z2y4oTx5oGiAiyMbYpGYsapezg3iVy8tjHkCg
fAVLOBJdF88AWBzfvN8WQwSYi9HWqBCxbzXRoJyYFAALUiGLlyNDFDO2SA1PbArJLYZ4lhshGiRD
jOU6NeMQ8AUHtcxNPoHxUYb4jPc7pZdjlSImxxa5c11d3VxOTg4VFJxLKNhG2jc1kVDaJ1I61YVo
lLzAIIOJBVG4E+fEtV1R94pwCgDRrVM/Q8OJgJibm0uFhYU0NrapGYv8xoUT0WinhRXgJJF1YLKQ
V2wEZABEaCPgCGhyTCjiRGQtqYfY1NRUyivbc3dr7tDD9gfk+/CO5meDWprmvHnc/55Cf1d1c2e4
w24Rwa6bARachXFOgEEoo8KW72G3KpR4l37S2ens7+9f9I+N0I/5IH2fn6L5mUktzQa/0LfZKd31
xMQrvd1KTgQCzpmZmcX/qw5hCq/90RZFQrsXIi+gOlgeFr6PaIs/B3hl7cpvLGyffdzwg7zFl7pU
aPd97dtuw4upjyFgCBgChoAhYAgYAobAlhH4B4NFwHk2U8rkAAAAAElFTkSuQmCCUEsBAi0AFAAG
AAgAAAAhADQS/3gUAQAAUAIAABMAAAAAAAAAAAAAAAAAAAAAAFtDb250ZW50X1R5cGVzXS54bWxQ
SwECLQAUAAYACAAAACEArTA/8cEAAAAyAQAACwAAAAAAAAAAAAAAAABFAQAAX3JlbHMvLnJlbHNQ
SwECLQAUAAYACAAAACEA1qevHrkBAAADBAAAHwAAAAAAAAAAAAAAAAAvAgAAY2xpcGJvYXJkL2Ry
YXdpbmdzL2RyYXdpbmcxLnhtbFBLAQItABQABgAIAAAAIQBTUolh0gAAAKsBAAAqAAAAAAAAAAAA
AAAAACUEAABjbGlwYm9hcmQvZHJhd2luZ3MvX3JlbHMvZHJhd2luZzEueG1sLnJlbHNQSwECLQAU
AAYACAAAACEA/cFa784GAAA9HAAAGgAAAAAAAAAAAAAAAAA/BQAAY2xpcGJvYXJkL3RoZW1lL3Ro
ZW1lMS54bWxQSwECLQAKAAAAAAAAACEAUi58A9gEAADYBAAAGgAAAAAAAAAAAAAAAABFDAAAY2xp
cGJvYXJkL21lZGlhL2ltYWdlMS5wbmdQSwUGAAAAAAYABgCvAQAAVREAAAAA
" filled="f" fillcolor="window [65]" stroked="f" strokecolor="windowText [64]"
   o:insetmode="auto">
   <v:path shadowok="t" strokeok="t" fillok="t" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" rotation="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
                    <textbox o:singleclick="f" style="mso-direction-alt:auto" 
                        xmlns="urn:schemas-microsoft-com:vml">
                    <![if excel]>
                    <div>
                        <font class="font9">机械</font></div>
                    <![endif]>
                    </textbox>
                    <![if excel]><x:clientdata ObjectType="Checkbox">
    <x:SizeWithCells xmlns:x="urn:schemas-microsoft-com:office:excel"/>
    <x:autofill>False</x:AutoFill>
    <x:autoline>False</x:AutoLine>
    <x:textvalign>Center</x:TextVAlign>
   </x:ClientData>
                    <![endif]></v:shape><v:shape id="_x0000_s1050" type="#_x0000_t201" style='position:absolute;
   margin-left:90.75pt;margin-top:6pt;width:36.75pt;height:18pt;z-index:3;
   mso-wrap-style:tight' o:gfxdata="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
MS5wbmdQSwUGAAAAAAYABgCvAQAA0RAAAAAA
" filled="f" fillcolor="window [65]" stroked="f" strokecolor="windowText [64]"
   o:insetmode="auto">
   <v:path shadowok="t" strokeok="t" fillok="t" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" rotation="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
                    <textbox o:singleclick="f" style="mso-direction-alt:auto" 
                        xmlns="urn:schemas-microsoft-com:vml">
                    <![if excel]>
                    <div>
                        <font class="font9">其他</font></div>
                    <![endif]>
                    </textbox>
                    <![if excel]><x:clientdata ObjectType="Checkbox">
    <x:SizeWithCells xmlns:x="urn:schemas-microsoft-com:office:excel"/>
    <x:autofill>False</x:AutoFill>
    <x:autoline>False</x:AutoLine>
    <x:textvalign>Center</x:TextVAlign>
   </x:ClientData>
                    <![endif]></v:shape><v:shape id="_x0000_s1049" type="#_x0000_t201" style='position:absolute;
   margin-left:49.5pt;margin-top:6pt;width:36.75pt;height:18pt;z-index:2;
   mso-wrap-style:tight' o:gfxdata="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
BgCvAQAAiRAAAAAA
" filled="f" fillcolor="window [65]" stroked="f" strokecolor="windowText [64]"
   o:insetmode="auto">
   <v:path shadowok="t" strokeok="t" fillok="t" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" rotation="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
                    <textbox o:singleclick="f" style="mso-direction-alt:auto" 
                        xmlns="urn:schemas-microsoft-com:vml">
                    <![if excel]>
                    <div>
                        <font class="font9">电气</font></div>
                    <![endif]>
                    </textbox>
                    <![if excel]><x:clientdata ObjectType="Checkbox">
    <x:SizeWithCells xmlns:x="urn:schemas-microsoft-com:office:excel"/>
    <x:autofill>False</x:AutoFill>
    <x:autoline>False</x:AutoLine>
    <x:textvalign>Center</x:TextVAlign>
   </x:ClientData>
                    <![endif]></v:shape><![endif]--><![if !vml]>
                    <span style="mso-ignore:vglayout;
  position:absolute;z-index:1;margin-left:11px;margin-top:8px;width:160px;
  height:25px">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="0" width="0">
                            </td>
                            <td width="50">
                            </td>
                            <td width="5">
                            </td>
                            <td width="50">
                            </td>
                            <td width="5">
                            </td>
                            <td width="50">
                            </td>
                        </tr>
                        <tr>
                            <td height="25">
                            </td>
                            <td align="left" valign="top">
                                <![endif]><![if !excel]>
                                <img alt="机械" class="shape" height="25" 
                                    src="file:///C:/Tmp/msohtmlclip1/02/clip_image001.png" v:dpi="96" 
                                    v:shapes="_x0000_s1048" width="50" /><![endif]><![if !vml]></td>
                            <td>
                            </td>
                            <td align="left" valign="top">
                                <![endif]><![if !excel]>
                                <img alt="电气" class="shape" height="25" 
                                    src="file:///C:/Tmp/msohtmlclip1/02/clip_image002.png" v:dpi="96" 
                                    v:shapes="_x0000_s1049" width="50" /><![endif]><![if !vml]></td>
                            <td>
                            </td>
                            <td align="left" valign="top">
                                <![endif]><![if !excel]>
                                <img alt="其他" class="shape" height="25" 
                                    src="file:///C:/Tmp/msohtmlclip1/02/clip_image003.png" v:dpi="96" 
                                    v:shapes="_x0000_s1050" width="50" /><![endif]><![if !vml]></td>
                        </tr>
                    </table>
                    </span><![endif]><span style="mso-ignore:vglayout2">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="style5" colspan="2" height="32" width="172">
                                &nbsp;</td>
                        </tr>
                    </table>
                    </span>
                </td>
            </tr>
            <tr height="32" style="mso-height-source:userset;height:24.0pt">
                <td class="style6" height="32">
                    工单号<font class="font5"><span style="mso-spacerun:yes">&nbsp;</span></font></td>
                <td class="style7" colspan="2" width="183">
                    &nbsp;</td>
                <td class="style8" width="83">
                    报修时间</td>
                <td class="style9" colspan="2" width="172">
                    &nbsp;</td>
            </tr>
            <tr height="47" style="mso-height-source:userset;height:35.25pt">
                <td class="style10" height="47">
                    故障类别</td>
                <td class="style7" colspan="2" width="183">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxRadioButtonList ID="workGroups" runat="server" ClientIDMode="AutoID" 
                                    RepeatDirection="Horizontal" SelectedIndex="0">
                                    <Items>
                                        <dx:ListEditItem Text="机械" Value="0" Selected="True" />
                                        <dx:ListEditItem Text="电气" Value="1" />
                                        <dx:ListEditItem Text="其他" Value="2" />
                                    </Items>
                                </dx:ASPxRadioButtonList>
                    </span>
                </td>
                <td class="style8" width="83">
                    报警号</td>
                <td class="style11" colspan="2" width="172">
                    &nbsp;</td>
            </tr>
            <tr height="21" style="mso-height-source:userset;height:15.95pt">
                <td class="style12" height="73">
                    <span style="mso-spacerun:yes">&nbsp;&nbsp; </span><font class="font6">报修描述</font><font 
                        class="font7">:</font></td>
                <td class="style13" colspan="5" width="438">
                    &nbsp;</td>
            </tr>
            <tr height="45" style="mso-height-source:userset;height:33.75pt">
                <td class="style14" height="45" width="66">
                    维修组长<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td align="left" style="width:80pt" valign="top" width="107">
                    <!--[if gte vml 1]><v:shape
   id="_x0000_s1051" type="#_x0000_t201" style='position:absolute;
   margin-left:6.75pt;margin-top:14.25pt;width:36.75pt;height:18pt;z-index:4;
   mso-wrap-style:tight' o:gfxdata="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
AAAGAAYArwEAABsQAAAAAA==
" filled="f" fillcolor="window [65]" stroked="f" strokecolor="windowText [64]"
   o:insetmode="auto">
   <v:path shadowok="t" strokeok="t" fillok="t" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" rotation="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
                    <textbox o:singleclick="f" style="mso-direction-alt:auto" 
                        xmlns="urn:schemas-microsoft-com:vml">
                    <![if excel]>
                    <div>
                        <font class="font9">是</font></div>
                    <![endif]>
                    </textbox>
                    <![if excel]><x:clientdata ObjectType="Checkbox">
    <x:SizeWithCells xmlns:x="urn:schemas-microsoft-com:office:excel"/>
    <x:autofill>False</x:AutoFill>
    <x:autoline>False</x:AutoLine>
    <x:textvalign>Center</x:TextVAlign>
   </x:ClientData>
                    <![endif]></v:shape><v:shape id="_x0000_s1052" type="#_x0000_t201" style='position:absolute;
   margin-left:39pt;margin-top:14.25pt;width:36.75pt;height:18pt;z-index:5;
   mso-wrap-style:tight' o:gfxdata="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
RDwnZGJiwmCxWHK9vb2g1Wohm82uVg7fVzaThpVSfqNwXK5HcMMtzC6OL+wXTSXX4RQKBWg0Gkil
UnzNoLRUgM9zKVhZLjQDRyEKjXmMEU9lcZ2pRji1Wg2JRII3XH5xAT7NJpuBk2D74pgDGDfmMGYR
k8DsFk2VNTZEBHBMpb2uAe2pwe2rtZEB/VnrC9e6hLfftsVwl1h9GhuuEYS5oVzffiGOf2wRXL2S
2H3ZWnCiMVttSAvgGJybDX3XSfzMdRdlmnhZlP1cC+DYlbORMZ347rIigTvEcR2K99IlcAK7zjqc
XC4HlUolaBxXyP9uZhzHXKo7r+KYuSqupeVkMgr6+vqBFjAALhbzzcwc1uvjMghbH9cJLI8t+Jnb
7TaYTKac4fw5uHb1CtDv47Dw6wevfPv6BWZS76D8pyhkyrUzK+6GzTbg8XjmJ588hPibl5CZ/YDV
k+SVj2kaMjPMVK3cOctKr6anB3F+Wvo/Qa1AtbzMO7imVF+P64yFTFw7O4oJY6aEBBcup1i51xFL
51gm3XigUgzzoGUz0hkPa7bgfkN2SQSIABEgAkSACBABIrA5Av8ALMZLf7yLXyYAAAAASUVORK5C
YIJQSwECLQAUAAYACAAAACEANBL/eBQBAABQAgAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRf
VHlwZXNdLnhtbFBLAQItABQABgAIAAAAIQCtMD/xwQAAADIBAAALAAAAAAAAAAAAAAAAAEUBAABf
cmVscy8ucmVsc1BLAQItABQABgAIAAAAIQAF4UX+uQEAAAYEAAAfAAAAAAAAAAAAAAAAAC8CAABj
bGlwYm9hcmQvZHJhd2luZ3MvZHJhd2luZzEueG1sUEsBAi0AFAAGAAgAAAAhAFNSiWHSAAAAqwEA
ACoAAAAAAAAAAAAAAAAAJQQAAGNsaXBib2FyZC9kcmF3aW5ncy9fcmVscy9kcmF3aW5nMS54bWwu
cmVsc1BLAQItABQABgAIAAAAIQD9wVrvzgYAAD0cAAAaAAAAAAAAAAAAAAAAAD8FAABjbGlwYm9h
cmQvdGhlbWUvdGhlbWUxLnhtbFBLAQItAAoAAAAAAAAAIQC4GpvfjQMAAI0DAAAaAAAAAAAAAAAA
AAAAAEUMAABjbGlwYm9hcmQvbWVkaWEvaW1hZ2UxLnBuZ1BLBQYAAAAABgAGAK8BAAAKEAAAAAA=
" filled="f" fillcolor="window [65]" stroked="f" strokecolor="windowText [64]"
   o:insetmode="auto">
   <v:path shadowok="t" strokeok="t" fillok="t" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" rotation="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
                    <textbox o:singleclick="f" style="mso-direction-alt:auto" 
                        xmlns="urn:schemas-microsoft-com:vml">
                    <![if excel]>
                    <div>
                        <font class="font9">否</font></div>
                    <![endif]>
                    </textbox>
                    <![if excel]><x:clientdata ObjectType="Checkbox">
    <x:SizeWithCells xmlns:x="urn:schemas-microsoft-com:office:excel"/>
    <x:autofill>False</x:AutoFill>
    <x:autoline>False</x:AutoLine>
    <x:textvalign>Center</x:TextVAlign>
   </x:ClientData>
                    <![endif]></v:shape><![endif]--><![if !vml]>
                    <span style="mso-ignore:vglayout;
  position:absolute;z-index:4;margin-left:9px;margin-top:19px;width:93px;
  height:25px"><span style="mso-ignore:vglayout;position:absolute;z-index:4;
  margin-left:0px;margin-top:0px;width:50px;height:25px"><![endif]><![if !excel]>
                    <img alt="是" class="shape" height="25" 
                        src="file:///C:/Tmp/msohtmlclip1/02/clip_image004.png" v:dpi="96" 
                        v:shapes="_x0000_s1051" width="50" /><![endif]><![if !vml]></span><span style="mso-ignore:vglayout;position:absolute;z-index:5;margin-left:43px;
  margin-top:0px;width:50px;height:25px"><![endif]><![if !excel]><img alt="否" class="shape" 
                        height="25" src="file:///C:/Tmp/msohtmlclip1/02/clip_image005.png" v:dpi="96" 
                        v:shapes="_x0000_s1052" width="50" /><![endif]><![if !vml]></span></span><![endif]><span 
                        style="mso-ignore:vglayout2">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="style15" height="45" width="107">
                                建议工程师到现场</td>
                        </tr>
                    </table>
                    </span>
                </td>
                <td align="left" colspan="2" height="45" style="height:33.75pt;width:137pt" 
                    valign="top" width="183">
                    <!--[if gte vml 1]><v:shape id="_x0000_s1053" type="#_x0000_t201"
   style='position:absolute;margin-left:32.25pt;margin-top:15pt;width:36.75pt;
   height:18pt;z-index:6;mso-wrap-style:tight' o:gfxdata="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
" filled="f" fillcolor="window [65]" stroked="f" strokecolor="windowText [64]"
   o:insetmode="auto">
   <v:path shadowok="t" strokeok="t" fillok="t" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" rotation="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
                    <textbox o:singleclick="f" style="mso-direction-alt:auto" 
                        xmlns="urn:schemas-microsoft-com:vml">
                    <![if excel]>
                    <div>
                        <font class="font9">是</font></div>
                    <![endif]>
                    </textbox>
                    <![if excel]><x:clientdata ObjectType="Checkbox">
    <x:SizeWithCells xmlns:x="urn:schemas-microsoft-com:office:excel"/>
    <x:autofill>False</x:AutoFill>
    <x:autoline>False</x:AutoLine>
    <x:textvalign>Center</x:TextVAlign>
   </x:ClientData>
                    <![endif]></v:shape><v:shape id="_x0000_s1054" type="#_x0000_t201" style='position:absolute;
   margin-left:66.75pt;margin-top:15pt;width:36.75pt;height:18pt;z-index:7;
   mso-wrap-style:tight' o:gfxdata="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
" filled="f" fillcolor="window [65]" stroked="f" strokecolor="windowText [64]"
   o:insetmode="auto">
   <v:path shadowok="t" strokeok="t" fillok="t" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" rotation="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
                    <textbox o:singleclick="f" style="mso-direction-alt:auto" 
                        xmlns="urn:schemas-microsoft-com:vml">
                    <![if excel]>
                    <div>
                        <font class="font9">否</font></div>
                    <![endif]>
                    </textbox>
                    <![if excel]><x:clientdata ObjectType="Checkbox">
    <x:SizeWithCells xmlns:x="urn:schemas-microsoft-com:office:excel"/>
    <x:autofill>False</x:AutoFill>
    <x:autoline>False</x:AutoLine>
    <x:textvalign>Center</x:TextVAlign>
   </x:ClientData>
                    <![endif]></v:shape><![endif]--><![if !vml]>
                    <span style="mso-ignore:vglayout;
  position:absolute;z-index:6;margin-left:43px;margin-top:20px;width:96px;
  height:25px"><span style="mso-ignore:vglayout;position:absolute;z-index:6;
  margin-left:0px;margin-top:0px;width:50px;height:25px"><![endif]><![if !excel]>
                    <img alt="是" class="shape" height="25" 
                        src="file:///C:/Tmp/msohtmlclip1/02/clip_image004.png" v:dpi="96" 
                        v:shapes="_x0000_s1053" width="50" /><![endif]><![if !vml]></span><span style="mso-ignore:vglayout;position:absolute;z-index:7;margin-left:46px;
  margin-top:0px;width:50px;height:25px"><![endif]><![if !excel]><img alt="否" class="shape" 
                        height="25" src="file:///C:/Tmp/msohtmlclip1/02/clip_image005.png" v:dpi="96" 
                        v:shapes="_x0000_s1054" width="50" /><![endif]><![if !vml]></span></span><![endif]><span 
                        style="mso-ignore:vglayout2">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="style16" colspan="2" height="45" width="183">
                                是否需要做<font class="font7">RCA</font></td>
                        </tr>
                    </table>
                    </span>
                </td>
                <td class="style8" width="83">
                    维修结果<br />
                    组长确认</td>
                <td class="style17">
                    &nbsp;</td>
                <td align="left" valign="top">
                    <!--[if gte vml 1]><v:shape id="_x0000_s1055"
   type="#_x0000_t201" style='position:absolute;margin-left:5.25pt;
   margin-top:14.25pt;width:36.75pt;height:18pt;z-index:8;mso-wrap-style:tight'
   o:gfxdata="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
" filled="f" fillcolor="window [65]" stroked="f" strokecolor="windowText [64]"
   o:insetmode="auto">
   <v:path shadowok="t" strokeok="t" fillok="t" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" rotation="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
                    <textbox o:singleclick="f" style="mso-direction-alt:auto" 
                        xmlns="urn:schemas-microsoft-com:vml">
                    <![if excel]>
                    <div>
                        <font class="font9">是</font></div>
                    <![endif]>
                    </textbox>
                    <![if excel]><x:clientdata ObjectType="Checkbox">
    <x:SizeWithCells xmlns:x="urn:schemas-microsoft-com:office:excel"/>
    <x:autofill>False</x:AutoFill>
    <x:autoline>False</x:AutoLine>
    <x:textvalign>Center</x:TextVAlign>
    <x:checked>1</x:Checked>
   </x:ClientData>
                    <![endif]></v:shape><v:shape id="_x0000_s1056" type="#_x0000_t201" style='position:absolute;
   margin-left:39.75pt;margin-top:14.25pt;width:36.75pt;height:18pt;z-index:9;
   mso-wrap-style:tight' o:gfxdata="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
" filled="f" fillcolor="window [65]" stroked="f" strokecolor="windowText [64]"
   o:insetmode="auto">
   <v:path shadowok="t" strokeok="t" fillok="t" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" rotation="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
                    <textbox o:singleclick="f" style="mso-direction-alt:auto" 
                        xmlns="urn:schemas-microsoft-com:vml">
                    <![if excel]>
                    <div>
                        <font class="font9">否</font></div>
                    <![endif]>
                    </textbox>
                    <![if excel]><x:clientdata ObjectType="Checkbox">
    <x:SizeWithCells xmlns:x="urn:schemas-microsoft-com:office:excel"/>
    <x:autofill>False</x:AutoFill>
    <x:autoline>False</x:AutoLine>
    <x:textvalign>Center</x:TextVAlign>
   </x:ClientData>
                    <![endif]></v:shape><![endif]--><![if !vml]>
                    <span style="mso-ignore:vglayout;
  position:absolute;z-index:8;margin-left:7px;margin-top:19px;width:96px;
  height:25px"><span style="mso-ignore:vglayout;position:absolute;z-index:8;
  margin-left:0px;margin-top:0px;width:50px;height:25px"><![endif]><![if !excel]>
                    <img alt="是" class="shape" height="25" 
                        src="file:///C:/Tmp/msohtmlclip1/02/clip_image006.png" v:dpi="96" 
                        v:shapes="_x0000_s1055" width="50" /><![endif]><![if !vml]></span><span style="mso-ignore:vglayout;position:absolute;z-index:9;margin-left:46px;
  margin-top:0px;width:50px;height:25px"><![endif]><![if !excel]><img alt="否" class="shape" 
                        height="25" src="file:///C:/Tmp/msohtmlclip1/02/clip_image005.png" v:dpi="96" 
                        v:shapes="_x0000_s1056" width="50" /><![endif]><![if !vml]></span></span><![endif]><span 
                        style="mso-ignore:vglayout2">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="style18" height="45" width="97">
                                工程师是否到场</td>
                        </tr>
                    </table>
                    </span>
                </td>
            </tr>
            <tr height="35" style="mso-height-source:userset;height:26.25pt">
                <td class="style19" height="338" rowspan="6" width="66">
                    维修责任人</td>
                <td class="style20" width="107">
                    是否停机<font class="font7">:</font></td>
                <td align="left" colspan="2" height="35" style="height:26.25pt;width:137pt" 
                    valign="top" width="183">
                    <!--[if gte vml 1]><v:shape id="_x0000_s1057" type="#_x0000_t201"
   style='position:absolute;margin-left:32.25pt;margin-top:5.25pt;width:36.75pt;
   height:18pt;z-index:10;mso-wrap-style:tight' o:gfxdata="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
" filled="f" fillcolor="window [65]" stroked="f" strokecolor="windowText [64]"
   o:insetmode="auto">
   <v:path shadowok="t" strokeok="t" fillok="t" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" rotation="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
                    <textbox o:singleclick="f" style="mso-direction-alt:auto" 
                        xmlns="urn:schemas-microsoft-com:vml">
                    <![if excel]>
                    <div>
                        <font class="font9">是</font></div>
                    <![endif]>
                    </textbox>
                    <![if excel]><x:clientdata ObjectType="Checkbox">
    <x:SizeWithCells xmlns:x="urn:schemas-microsoft-com:office:excel"/>
    <x:autofill>False</x:AutoFill>
    <x:autoline>False</x:AutoLine>
    <x:textvalign>Center</x:TextVAlign>
   </x:ClientData>
                    <![endif]></v:shape><v:shape id="_x0000_s1058" type="#_x0000_t201" style='position:absolute;
   margin-left:66.75pt;margin-top:5.25pt;width:36.75pt;height:18pt;z-index:11;
   mso-wrap-style:tight' o:gfxdata="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
" filled="f" fillcolor="window [65]" stroked="f" strokecolor="windowText [64]"
   o:insetmode="auto">
   <v:path shadowok="t" strokeok="t" fillok="t" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" rotation="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
                    <textbox o:singleclick="f" style="mso-direction-alt:auto" 
                        xmlns="urn:schemas-microsoft-com:vml">
                    <![if excel]>
                    <div>
                        <font class="font9">否</font></div>
                    <![endif]>
                    </textbox>
                    <![if excel]><x:clientdata ObjectType="Checkbox">
    <x:SizeWithCells xmlns:x="urn:schemas-microsoft-com:office:excel"/>
    <x:autofill>False</x:AutoFill>
    <x:autoline>False</x:AutoLine>
    <x:textvalign>Center</x:TextVAlign>
   </x:ClientData>
                    <![endif]></v:shape><![endif]--><![if !vml]>
                    <span style="mso-ignore:vglayout;
  position:absolute;z-index:10;margin-left:43px;margin-top:7px;width:96px;
  height:25px"><span style="mso-ignore:vglayout;position:absolute;z-index:10;
  margin-left:0px;margin-top:0px;width:50px;height:25px"><![endif]><![if !excel]>
                    <img alt="是" class="shape" height="25" 
                        src="file:///C:/Tmp/msohtmlclip1/02/clip_image004.png" v:dpi="96" 
                        v:shapes="_x0000_s1057" width="50" /><![endif]><![if !vml]></span><span style="mso-ignore:vglayout;position:absolute;z-index:11;margin-left:46px;
  margin-top:0px;width:50px;height:25px"><![endif]><![if !excel]><img alt="否" class="shape" 
                        height="25" src="file:///C:/Tmp/msohtmlclip1/02/clip_image005.png" v:dpi="96" 
                        v:shapes="_x0000_s1058" width="50" /><![endif]><![if !vml]></span></span><![endif]><span 
                        style="mso-ignore:vglayout2">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="style21" colspan="2" height="35" width="183">
                                &nbsp;</td>
                        </tr>
                    </table>
                    </span>
                </td>
                <td class="style22">
                    开始维修时间<font class="font7">:</font></td>
                <td class="style9" colspan="2" width="172">
                    <dx:ASPxDateEdit ID="AlarmsStaterTime" runat="server" 
                        DisplayFormatString="yyyy-MM-dd hh:mm:ss">
                    </dx:ASPxDateEdit>
                </td>
            </tr>
            <tr height="35" style="mso-height-source:userset;height:26.25pt">
                <td class="style23" height="35">
                    参与维修人签名<font class="font7">:</font></td>
                <td class="style24" colspan="2" width="183">
                    &nbsp;</td>
                <td class="style25">
                    结束维修时间<font class="font7">:</font></td>
                <td class="style9" colspan="2" width="172">
                    &nbsp;</td>
            </tr>
            <tr height="32" style="mso-height-source:userset;height:24.0pt">
                <td class="style26" height="130" rowspan="2" width="107">
                    故障详述<font class="font7">:</font></td>
                <td class="style27" width="87">
                    故障详述<font class="font7">:</font></td>
                <td class="style28" colspan="4" width="351">
                    &nbsp;</td>
            </tr>
            <tr height="32" style="mso-height-source:userset;height:24.0pt">
                <td class="style29" height="66" width="87">
                    故障位置<font class="font7">:</font></td>
                <td class="style28" colspan="4" width="351">
                    &nbsp;</td>
            </tr>
            <tr height="17" style="mso-height-source:userset;height:12.75pt">
                <td class="style30" height="138" rowspan="2" width="107">
                    维修过程<font class="font7">:</font></td>
                <td class="style31" width="87">
                    原因分析<font class="font7">:</font></td>
                <td class="style28" colspan="4" width="351">
                    &nbsp;</td>
            </tr>
            <tr height="17" style="mso-height-source:userset;height:12.75pt">
                <td class="style32" height="69" width="87">
                    维修方法<font class="font7">:</font></td>
                <td class="style33" colspan="4" width="351">
                    &nbsp;</td>
            </tr>
            <tr height="17" style="mso-height-source:userset;height:12.75pt">
                <td class="style34" height="101" rowspan="3" width="66">
                    更换备件</td>
                <td class="style35" colspan="2">
                    名称<font class="font7">/</font><font class="font6">库存号</font></td>
                <td class="style36" width="96">
                    型号</td>
                <td class="style35">
                    价格</td>
                <td class="style35">
                    数量<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="style37">
                    等待时间</td>
            </tr>
            <tr height="14" style="mso-height-source:userset;height:11.1pt">
                <td class="style38" colspan="2" height="28">
                    &nbsp;</td>
                <td class="style39" width="96">
                    &nbsp;</td>
                <td class="style8" width="83">
                    &nbsp;</td>
                <td class="style40">
                    &nbsp;</td>
                <td class="style41">
                    &nbsp;</td>
            </tr>
            <tr height="14" style="mso-height-source:userset;height:11.1pt">
                <td class="style38" colspan="2" height="28">
                    &nbsp;</td>
                <td class="style39" width="96">
                    &nbsp;</td>
                <td class="style8" width="83">
                    &nbsp;</td>
                <td class="style42">
                    &nbsp;</td>
                <td class="style41">
                    &nbsp;</td>
            </tr>
            <tr height="14" style="mso-height-source:userset;height:11.1pt">
                <td class="style43" colspan="2" height="28">
                    &nbsp;</td>
                <td class="style44" width="96">
                    &nbsp;</td>
                <td class="style8" width="83">
                    &nbsp;</td>
                <td class="style42">
                    &nbsp;</td>
                <td class="style41">
                    &nbsp;</td>
            </tr>
            <tr height="17" style="mso-height-source:userset;height:12.75pt">
                <td class="style45" height="43" width="66">
                    设备操作工</td>
                <td class="style46" width="107">
                    停机时间<font class="font7">:</font></td>
                <td class="style35" colspan="3">
                    &nbsp;</td>
                <td class="style35">
                    操作工</td>
                <td class="style47">
                    &nbsp;</td>
            </tr>
            <tr height="17" style="mso-height-source:userset;height:12.75pt">
                <td class="style48" height="176" rowspan="4" width="66">
                    工程师责任人</td>
                <td class="style35">
                    根本原因<font class="font7">:</font></td>
                <td class="style49" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr height="17" style="mso-height-source:userset;height:12.75pt">
                <td class="style50" height="68">
                    预防措施<font class="font7">:</font></td>
                <td class="style51">
                    ATS<font class="font6">号</font></td>
                <td class="style52" colspan="2">
                    措施</td>
                <td class="style35">
                    责任人</td>
                <td class="style37">
                    日期</td>
            </tr>
            <tr height="17" style="mso-height-source:userset;height:12.75pt">
                <td class="style53" height="17">
                    &nbsp;</td>
                <td class="style52" colspan="2">
                    &nbsp;</td>
                <td class="style40">
                    &nbsp;</td>
                <td class="style41">
                    &nbsp;</td>
            </tr>
            <tr height="17" style="mso-height-source:userset;height:12.75pt">
                <td class="style53" height="17">
                    &nbsp;</td>
                <td class="style52" colspan="2">
                    &nbsp;</td>
                <td class="style40">
                    &nbsp;</td>
                <td class="style41">
                    &nbsp;</td>
            </tr>
            <tr height="17" style="mso-height-source:userset;height:12.75pt">
                <td class="style54" height="17">
                    &nbsp;</td>
                <td class="style55" colspan="2">
                    &nbsp;</td>
                <td class="style56">
                    &nbsp;</td>
                <td class="style57">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
