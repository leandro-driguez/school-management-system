function uncheckOthers(id)
{var elm = document.getElementsByTagName('input');

// loop through all input elm in form

for(var i = 0; i < elm.length; i++)

{if(elm.item(i).type == "checkbox" && elm.item(i).id!=id)

elm.item(i).checked=false;
}}