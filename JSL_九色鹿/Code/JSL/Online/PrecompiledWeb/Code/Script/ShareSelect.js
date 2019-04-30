/************************************************多选*********************************************************/
//双击已选员工
function CheckedEmpResult()
{ 
      var addOption=document.createElement("option");
      var index1;
      if(document.all("lib_emp1").length==0)
        return(false);
      index1=document.getElementById("lib_emp1").selectedIndex; 
      if(index1<0)
        return(false);
      addOption.text=document.getElementById("lib_emp1").options(index1).text;
      addOption.value=document.getElementById("lib_emp1").options(index1).value;
      if(!Test( document.getElementById("lib_emp2"),addOption.value))
      {
         document.getElementById("lib_emp2").add(addOption);
         document.getElementById("lib_emp1").remove(index1);
      }else
      {
      alert('已经添加过了！');
      }
  }
              
//双击清除已选员工
function ClearEmpResult() 
{ 
      var addOption=document.createElement("option");
      var index2;
      if(document.all("lib_emp2").length==0)
        return(false);
      index2=document.getElementById("lib_emp2").selectedIndex; 
      if(index2<0)
        return(false);
      addOption.text=document.getElementById("lib_emp2").options(index2).text;
      addOption.value=document.getElementById("lib_emp2").options(index2).value;
      document.getElementById("lib_emp1").add(addOption);
      document.getElementById("lib_emp2").remove (index2);
}
//检测改该,是否已经选择了
function Test(Select,value)  
{
    for (j = 0;j<Select.length; j++)
    {                    
        if (Select.options[j].value == value) 
        return true;            
    }
    return false;
}
//全选
function CheckAll()
{
  var lst1=document.all("lib_emp1");
  var lst2=document.all("lib_emp2");  
 var  len=document.getElementById("lib_emp1").length;
  if(len==0)
  {
    return(false);
  }else
  {
    for(var i=len-1;i>=0;i--)
    {
       var value = lst1.options(i).value;
         var text = lst1.options(i).text;  
          if  (Test(lst2,lst1.options[i].value))
        {
           alert('已经添加过了！');
        }else
        {
         lst2.options.add(new Option(text,value));
         lst1.remove(i);
         }
     }
  }
  
}
//单选
function CheckSingle()
{
var lst1=window.document.getElementById("lib_emp1");
var lst2=window.document.getElementById("lib_emp2");
var lstindex;
var len=document.all("lib_emp1").length;
if(len==0)
    return(false);
  lstindex=lst1.selectedIndex; 
  if(lstindex<0)  //没有选中项
    return(false);
  if(lstindex>=0)
 {
     for(var i=lst1.length-1;i>=0;i--)
     {
            if(lst1.options[i].selected)
            {
                var addOption=document.createElement("option");
                addOption.value = lst1.options[i].value;
                addOption.text = lst1.options[i].text;
                 lst2.options.add(addOption);
                 lst1.remove(i);
            }
     }
 }
}
//单清
function ClearSingle()
{
 var lst1=window.document.getElementById("lib_emp1");
 var lst2=window.document.getElementById("lib_emp2");
 var lstindex=lst2.selectedIndex;
 if(lstindex>=0)
 {
     for(var i=lst2.length-1;i>=0;i--)
     {
            if(lst2.options[i].selected)
            {
                var addOption=document.createElement("option");
                addOption.value = lst2.options[i].value;
                addOption.text = lst2.options[i].text;
                 lst1.options.add(addOption);
                 lst2.remove(i);
             }
     }
 }
}
//全清
function ClearAll()
{
  var lst2=document.all("lib_emp2");
  var lst1=document.all("lib_emp1");
  var len;
  var value;
  var text;
  len=document.getElementById("lib_emp2").length;
  if(len==0)
  {
    return(false);
  }else
  {
    for(var i=len-1;i>=0;i--)
    {
        value = lst2.options(i).value;
        text = lst2.options(i).text;  
         lst1.options.add(new Option(text,value));
         lst2.remove(i);
     }
   }
}
