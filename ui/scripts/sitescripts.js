function showMissions()
{

	var el = document.getElementById("modelselect");
	var mish = document.getElementById("missionselect");
	
	curselmodel = el.options[el.selectedIndex].value ;
	
	// based on the currently selected model fill the mission drop down with the right 
	if (curselmodel == "Model 1")
	{
		mish.options.length = 0;
		mish.options[0] = new Option('Mission 1','Mission 1');
		mish.options[1] = new Option('Mission 2','Mission 2');
		
	}
	else if (curselmodel == "Model 2")
	{
		mish.options.length = 0;
		mish.options[0] = new Option('Mission 3','Mission 3');
		mish.options[1] = new Option('Mission 4','Mission 4');
	}
	else if (curselmodel == "Model 3")
	{
		mish.options.length = 0;
		mish.options[0] = new Option('Mission 1','Mission 1');
		mish.options[1] = new Option('Mission 6','Mission 6');
	}
	else if (curselmodel == "Model 4")
	{
		mish.options.length = 0;
		mish.options[0] = new Option('Mission 8','Mission 8');
		mish.options[1] = new Option('Mission 9','Mission 9');
		
	} // default load all
	else
	{
		mish.options.length = 0;
		mish.options[0] = new Option('Find By Mission','');
		mish.options[1] = new Option('Mission 1','Mission 1');
		mish.options[2] = new Option('Mission 2','Mission 2');
		mish.options[3] = new Option('Mission 3','Mission 3');
		mish.options[4] = new Option('Mission 4','Mission 4');
		mish.options[5] = new Option('Mission 5','Mission 5');
		mish.options[6] = new Option('Mission 6','Mission 6');
		mish.options[7] = new Option('Mission 7','Mission 7');
	
	}
	
		
}


function showModels()
{

	var el = document.getElementById("aircraftfamily");
	var mish = document.getElementById("aircraftmodel");
	
	curselair = el.options[el.selectedIndex].value ;
	
	// based on the currently selected aircraft family fill the model drop down with the right ones
	if (curselair == "Family 1")
	{
		mish.options.length = 0;
		mish.options[0] = new Option('Model 1','Model 1');
		mish.options[1] = new Option('Model 2','Model 2');
		
	}
	else if (curselair == "Family 2")
	{
		mish.options.length = 0;
		mish.options[0] = new Option('Model 3','Model 3');
		mish.options[1] = new Option('Model 4','Model 4');
	}
	else if (curselair == "Family 3")
	{
		mish.options.length = 0;
		mish.options[0] = new Option('Model 1','Model 1');
		mish.options[1] = new Option('Model 5','Model 5');
		mish.options[2] = new Option('Model 2','Model 2');
	}	
	 // default load all
	else
	{
		mish.options.length = 0;
		mish.options[0] = new Option('By Aircraft Model','');
		mish.options[1] = new Option('Model 1','Model 1');
		mish.options[2] = new Option('Model 2','Model 2');
		mish.options[3] = new Option('Model 3','Model 3');
		mish.options[4] = new Option('Model 4','Model 4');
		mish.options[5] = new Option('Model 5','Model 5');
		
	}
	
	
	
}




function SetCookie(sName, sValue)
{
  date = new Date()  ;
  var m = date.getDay ();
  m += 365;
  date.setDate(m);  
  document.cookie = sName + "=" + escape(sValue) + "; expires=" + date.toGMTString();
}
function GetCookie(sName)
{
  // cookies are separated by semicolons
  var aCookie = document.cookie.split("; ");
  for (var i=0; i < aCookie.length; i++)
  {
    // a name/value pair (a crumb) is separated by an equal sign
    var aCrumb = aCookie[i].split("=");
    if (sName == aCrumb[0]) 
      return unescape(aCrumb[1]);
  }

  // a cookie with the requested name does not exist
  return null;
}


function isValidEmail(email, required) {
    if (required==undefined) {   // if not specified, assume it's required
        required=true;
    }
    if (email==null) {
        if (required) {
            return false;
        }
        return true;
    }
    if (email.length==0) {  
        if (required) {
            return false;
        }
        return true;
    }
    if (! allValidChars(email)) {  // check to make sure all characters are valid
        return false;
    }
    if (email.indexOf("@") < 1) { //  must contain @, and it must not be the first character
        return false;
    } else if (email.lastIndexOf(".") <= email.indexOf("@")) {  // last dot must be after the @
        return false;
    } else if (email.indexOf("@") == email.length) {  // @ must not be the last character
        return false;
    } else if (email.indexOf("..") >=0) { // two periods in a row is not valid
	return false;
    } else if (email.indexOf(".") == email.length) {  // . must not be the last character
	return false;
    }
    return true;
}

function allValidChars(email) {
  var parsed = true;
  var validchars = "abcdefghijklmnopqrstuvwxyz0123456789@.-_";
  for (var i=0; i < email.length; i++) {
    var letter = email.charAt(i).toLowerCase();
    if (validchars.indexOf(letter) != -1)
      continue;
    parsed = false;
    break;
  }
  return parsed;
}


