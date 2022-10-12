
var num= 0;
function AgregarConcepto() {

    let Cantidad = document.getElementById("Cantidad").value;
    let Precio = document.getElementById("Precio").value;
    let IdProducto = document.getElementById("idProducto").value;
    let nombreProducto = document.getElementById("idProducto");
    let index = nombreProducto.selectedIndex;
    let nomproducfinal = nombreProducto.options[index].text;


    if (Cantidad > 0) {
        let alertCant = document.getElementById("alertCantidad");
        alertCant.innerHTML = ""
        let Tabla = document.getElementById("tbConcepto");
        let TDCantidad = document.createElement("td");
        let TDIdProducto = document.createElement("td");
        let TDProductoNo = document.createElement("td");
        let TDPrecio = document.createElement("td");
        let TDTotal = document.createElement("td");
        let TR = document.createElement("tr");



        TR.appendChild(TDCantidad);
        TR.appendChild(TDIdProducto);
        TR.appendChild(TDProductoNo);
        TR.appendChild(TDPrecio);
        TR.appendChild(TDTotal);
        TDCantidad.innerHTML = Cantidad;
        TDIdProducto.innerHTML = IdProducto;
        TDProductoNo.innerHTML = nomproducfinal;
        TDPrecio.innerHTML = Precio;
        TDTotal.innerHTML = parseFloat(Cantidad) * parseFloat(Precio);
        Tabla.appendChild(TR);

        let DivConceptos = document.getElementById("divConceptos");
        let HiddenIndex = document.createElement("input");
        let HiddenCantidad = document.createElement("input");
        let HiddenNombre = document.createElement("input");
        let HiddenPrecio = document.createElement("input");

        HiddenIndex.name = "conceptos.Index";
        HiddenIndex.value = num;
        HiddenIndex.type = "hidden";

        HiddenCantidad.name = "conceptos[" + num + "].Cantidad";
        HiddenCantidad.value = Cantidad;
        HiddenCantidad.type = "hidden";

        HiddenNombre.name = "conceptos[" + num + "].idProducto";
        HiddenNombre.value = IdProducto;
        HiddenNombre.type = "hidden";

        HiddenPrecio.name = "conceptos[" + num + "].Precio";
        HiddenPrecio.value = Precio;
        HiddenPrecio.type = "hidden";


        DivConceptos.appendChild(HiddenIndex);
        DivConceptos.appendChild(HiddenCantidad);
        DivConceptos.appendChild(HiddenNombre);
        DivConceptos.appendChild(HiddenPrecio);

        num++;

        document.getElementById("Cantidad").value = "";
        document.getElementById("Precio").value = "";
        document.getElementById("idProducto").value = "";


    } else {
        let alertCant = document.getElementById("alertCantidad");
        alertCant.innerHTML="Ingrese un valor mayor a 0"
    }        
}



//cada que cambie de opcion el combo box se ejecuta esta funcion
const selectElement = document.querySelector('#idProducto');

selectElement.addEventListener('change', (event) => {
    let IdProducto = document.getElementById("idProducto").value;
    getPrecio(IdProducto);
    
    

});

function getPrecio(IdProducto) {
    //consulta ajax para el precio 
   
    var contenido = "";
    var data = { Id: IdProducto }
    //funcion ajax solicitando Pedido/GetPrecio
  
    $.ajax({
        type: 'POST',
        url: '/Pedido/GetPrecio',
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: function (data) {

            document.getElementById("Precio").value = data;

        }

        
    });



    



    
}