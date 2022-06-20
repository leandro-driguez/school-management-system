// RESALTAR LAS FILAS AL PASAR EL MOUSE
function ResaltarFila(id_fila) {
    document.getElementById(id_fila).style.backgroundColor = "#ffd2d251";
  }

  // RESTABLECER EL FONDO DE LAS FILAS AL QUITAR EL FOCO
  function RestablecerFila(id_fila) {
    document.getElementById(id_fila).style.backgroundColor = "#ffe6e63b";
  }
  // CONVERTIR LAS FILAS EN LINKS
  function CrearEnlace(url) {
    location.href = url;
  }

  var $rows = $("#table tr");
  $("#search").keyup(function () {
    var val =
        "^(?=.*\\b" +
        $.trim($(this).val()).split(/\s+/).join("\\b)(?=.*\\b") +
        ").*$",
      reg = RegExp(val, "i"),
      text;

    $rows
      .show()
      .filter(function () {
        text = $(this).text().replace(/\s+/g, " ");
        return !reg.test(text);
      })
      .hide();
  });