function show_hide_element(id) {
    var element = document.getElementById(id);
    if(window.getComputedStyle(element).display === "none"){
      element.style.display = "block"
    }
    else if(window.getComputedStyle(element).display === "block"){
      element.style.display = "none"
    }
  }