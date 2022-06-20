function myFunction(input_name, table_name) {
    // Declare variables
    var input, filter, table, tr, td, i, j, x, txtValue;
    input = document.getElementById(input_name);
    filter = input.value.toUpperCase();
    table = document.getElementById(table_name);
    tr = table.getElementsByTagName("tr");
    
    // Loop through all table rows, and hide those who don't match the search query
    for (i = 1; i < tr.length; i++) {
      td = tr[i].getElementsByTagName("td");
      x = true
      for (j = 0; j < td.length; j++) {
        if (td[j]) {
            txtValue = td[j].textContent || td[j].innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1){
                x = false;
                break;
            }
        }    
      }
      if(x){
        tr[i].style.display = "none";
      }
      else{
        tr[i].style.display = "";
      }
    }
}
  