//设置网页打印的页眉页脚为空   
function pagesetup_null() {

    try {
        var hkey_root, hkey_path;
        hkey_root = "HKEY_CURRENT_USER";
        hkey_path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\";
        var RegWsh = new ActiveXObject("WScript.Shell");
        RegWsh.RegWrite(hkey_root + hkey_path + "header", "");
        RegWsh.RegWrite(hkey_root + hkey_path + "footer", "");
        RegWsh.RegWrite(hkey_root + hkey_path + "margin_bottom", "0");
        RegWsh.RegWrite(hkey_root + hkey_path + "margin_left", "0");
        RegWsh.RegWrite(hkey_root + hkey_path + "margin_top", "0");
        RegWsh.RegWrite(hkey_root + hkey_path + "margin_right", "0");
        RegWsh.sendKeys('%a'); 
    } catch (e) { alert(e);return false;}
    return true;
}   