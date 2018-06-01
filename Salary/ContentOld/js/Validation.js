function onlyAlphaNumChkSpace(e,event)
{
 if(window.event) 
 {   
     var temp=eval(document.getElementById(e.id).value.length); 
     key = event.keyCode;
     var iChars="._"; 
//     if((key==32) && (temp==0))
//     { 
//       return false;
//     }
     keychar = String.fromCharCode(key); 
     if ((key==32) && (temp!=0)) //(document.getElementById(e.id).value.charAt(0)!=" "))
     {  
//            alert("in");
            if((document.getElementById(e.id).value.charAt(temp-1)== " ") && (key == 32))
            {
                 
                  //event.keyCode=0;s
                  return false;
            }
        
     } 
     else
     {     
//           keychar = String.fromCharCode(key);
//           return keychar;        
           if ((key  > 64 && key  < 91) || (key  > 96 && key  < 123 )||(key  > 47 && key  < 59)||(key==45)||(key==46))
           {
        //return keychar;       
            keychar = String.fromCharCode(key);      
            return keychar; 
           } 
           else
           {
            return false;
           }
     }
}
else
{
       return false;
}
 //now checking for space}
}  



// JScript File
//######## Function for OnlyNumDot 
function onlynumdot(e,event)
  {
   var key;
   var keychar;
   var reg;
   //alert(key);
   if(window.event) 
	{
    key = event.keyCode; 
    if (key  > 47 && key  < 59 || key==46)
        {  
         if(checkdecimal2(e,event) == false)
         {
            return false;
         }
         else
         {
            keychar = String.fromCharCode(key);	
            return keychar; 
         }
       }
       else
       {
       return false;
       }
   }
   else
   {
       return flase;
   }
} 
//onkeypress="return onlynumdot(this,event)"
//########### End

//########### Function for only numeric   
 function onlynumeric(e,event)
  {
   var key;
   var keychar;
   var reg;
   
  if(window.event) 
	{
    key = event.keyCode; 
// 	alert(key);
     if (key  > 47 && key  < 59) 
        {  
       keychar = String.fromCharCode(key);	
       return keychar; 
       }
       else
       {
        return false;
       }
   }
   else
   {
       return false;
   }
} 
//onkeypress="return onlynumeric(this,event)"
///## End

/////Function for only Alpha
function onlyalpha(e,event)
{ 
   var key;
   var keychar;
   var reg;
  // alert("hi");
   if(window.event) 
   {
      key = event.keyCode; 
   //   var iChars="@!#$%^&*+<>/?[]{}~`,:'|=-_";
//     if (key  > 96 && key  < 123)
//     {          
//        key=eval((key)-32);
//        keychar = String.fromCharCode(key);
//        alert(keychar);
//        document.getElementById("TextBox5").innertext=keychar.toUpperCase();
//        alert(keychar);
//        return keychar; 
//     }
   //   if (((key  > 64 && key  < 91) || iChars || (key==32 )) || (key  > 96 && key  < 123 ))
       if (((key  > 64 && key  < 91) || (key==32 )) || (key  > 96 && key  < 123 ))
      {  
            keychar = String.fromCharCode(key);      
            return keychar; 
      }
      else
      {
            return false;
      }
   }
   else
   {
       return false;
   }
}
//onkeypress="return onlyalpha(this,event)"
//////End onlyalpha

/////Function for only Alpha & Special Char's
function onlyalphaSpec(e,event)
{ 
   var key;
   var keychar;
   var reg;
  // alert("hi");
   if(window.event) 
   {
      key = event.keyCode; 
      var iChars="@!#$%^&*+<>/?[]{}~`,:'|=-_";
     if (key  > 47 && key  < 59)
      {  
            return false;
      }
      else
      { 
           keychar = String.fromCharCode(key);      
            return keychar; 
      }
   }
   else
   {
       return false;
   }
}
//onkeypress="return onlyalphaSpec(this,event)"
//////End onlyalphaSpec

///////// Function for only alphaNumeric

function onlyAlphaNum(e,event)
{
 if(window.event) 
 {
     key = event.keyCode; 
     //  var iChars="@!#$%^&*+<>/?[]{}~`,:'|=-_";
     if ((key  > 64 && key  < 91) || (key  > 96 && key  < 123 ))
     {
       keychar = String.fromCharCode(key);      
      // alert(keychar);
       return keychar; 
     } 
     else
      {
            return false;
      }
 }
 else
 {
       return false;
 }
} 
//onkeypress="return onlyAlphaNum(this,event)"
///////// End AlphaNumeric




//////// Function to checkdecimal
function checkdecimal(e,event)
{
 var temp=0;
 var count=0;  
 var key;
 var keychar; 
 

  var val = document.getElementById(e.id).value;
  temp=eval(document.getElementById(e.id).value.length);
  for(var i=0;i<temp;i++)
  {
    if (val.indexOf(".")>-1)
    {
       count=count+1;     
    }
  }
  if (count >=1)
  {
    if(window.event) 
	{
     key = event.keyCode; 
     if (key  > 47 && key  < 59  )
        {  
         keychar = String.fromCharCode(key);	
         return keychar; 
        }
       else
       {
       return false;
       }
   }
   else
   {
       return flase;
   }
  }
  else
  {
     if(window.event) 
	 {
      key = event.keyCode; 
        // 	alert(key);
      if (key  > 47 && key  < 59 || key==46 )
        {  
       keychar = String.fromCharCode(key);	
       return keychar; 
       }
       else
       {
       return false;
       }
   }
   else
   {
       return false;
   }

  }
  }  
//onkeypress="return checkdecimal(this,event)"  
///////// Function checkdecimal End

//////// Function To get only two No. after a Decimal
function checkdecimal2(e,event)
{

 var temp=0;
 var count=0;
 var j=0;   
 var key;
 var keychar; 
 //alert("hi");

  var val = document.getElementById(e.id).value;
  temp=eval(document.getElementById(e.id).value.length);
  for(var i=0;i<temp;i++)
  {
    if (val.indexOf(".")>-1)
    {
       j=i;
       count=count+1;     
    }
  }
  if (count >=1)
  {    
        if(window.event) 
	     {
           key = event.keyCode;         
             if ((key  > 47 && key  < 59) && (eval(temp- val.indexOf("."))<3))
             {               
               keychar = String.fromCharCode(key);	               
               return keychar;               
             }
             else
             {               
               return false;
             }          
         }
  }      
  else
  {
     if(window.event) 
	 {
     key = event.keyCode; 
// 	alert(key);
 
      if (key  > 47 && key  < 59 || key==46 )
        {  
       keychar = String.fromCharCode(key);	
       return keychar; 
       
        }
       else
       {
       return false;
       }
     }
   else
   {
          
       return false;
   }

  }
 } 
 //onkeypress="return checkdecimal2(this,event)"
////// End Function To get only two No. after a Decimal

///////Function to CheckSpace 
function checkSpace(e,event)  
{
 var temp=0;
 var count=0;  
 var key;
 var keychar; 
 //alert("yes");
 var val = document.getElementById(e.id).value;
  temp=eval(document.getElementById(e.id).value.length);
  //alert(temp);
  if(window.event) 
	{
    key = event.keyCode; 
    //var count=document.getElementById(e.id).value.charAt(temp-1);
    keychar = String.fromCharCode(key);	
    //alert(keychar)
//    if((key == 32) && temp == 0)
//    {
//        return false;
//    }
    if ((key==32) && (document.getElementById(e.id).value.charAt(0)!=" "))
       {
            if((document.getElementById(e.id).value.charAt(temp-1)== " ") && (key == 32))
            {
                  event.keyCode=0;
                  return false;
            }
        }    
       else
       {    
            return keychar;       
       }
    }
   else
   {
       return false;
   }
}
//onkeypress="return checkSpace(this,event)"
///////// Function CheckSpace End

//////// Function to CheckFirst letter 
function chkfirstletter(e,event)
{
  var temp=0;
  
  var key;
  temp=eval(document.getElementById(e.id).value.length);
  
  if (temp == 0 )
  {     
      if(window.event) 
	  {
       key = event.keyCode; 
      
        if ((key  > 64 && key  < 91) || (key  > 96 && key  < 123) || key == 8 ) 
        {  
          
          return true; 
        }
        else
        {
         return false;
        }
      }
    else
    {
       
       return false; 
    }       
  }
  else
  {
    return chk = onlyAlphaNumChkSpace(e,event);
  }
}
//onkeypress="return chkfirstletter(this,event) " 
//////// Function CheckFirstletter End

//////// Function CheckSpecialletter 
function chkSpecialletter(e,event)
{  
  var temp=true;
  if(window.event) 
	{
      key = event.keyCode; 
      keychar = String.fromCharCode(key);
  	
        var iChars="@!#$%^&*+<>/?[]{}~`,:'|=-_";
        var j=0;
        var i=0;
           for(j=0;j<26;j++)
            {      
                if (iChars.charAt(j)== keychar) 
                    {
                	    alert ("Your username has special characters. \nThese are not allowed.");
                	    temp=false;
                	    j=26;
                	}                              
            }
     }
     return temp;
}
//onkeypress="return chkSpecialletter(this,event)"
////////End
///////// Function AllCaps
function allcaps(e,event)
{   
   var key;
   var keychar;
   //alert("yes");
   key = event.keyCode;
 
   if(window.event)
   {  
//        if (key  > 96 && key  < 123)
//        {
//            alert(key);
//            key = key - 32;
//            return String.fromCharCode(key);
           //keyChar = String.fromCharCode(key);
           //key eval(keyChar);
           // keychar = str(key);
       //    alert(String.fromCharCode(key));
            
         document.getElementById(e.id).value=document.getElementById(e.id).value.toUpperCase();
         
//        }

   }
//    
//   {
//    key = event.keyCode;
//    if (key  > 96 && key  < 123)
//    {          
//       //key=eval((key)-32);
//       keychar = String.fromCharCode(key);
//       //alert(keychar);
//       
//       //alert(keychar);
//       return keychar; 
//    }
//  }
// else
// {
//    return false;
// }
 }
///End
//onkeyup="return allcaps(this,event)"
//////////Function for lock Control Key
function lockctrlkey(e,event)
{
  var key=0;
  var keychar;
  if(window.event) 
  {
    key=event.keyCode; 
    alert(key);
    if (event.keyCode==17)
    {
    // alert("hi");
     return false;
    }
    else
    {
     return true; 
    }
  }
  else
  {
   return false;
  }
}
/////onkeypress="return lockctrlkey(this,event)"
///// End
//****** Function For Single Space & no Space at first Position 
  
////////End 

/////Function for Validate Email


//Fonction For Auto Fill
 
  