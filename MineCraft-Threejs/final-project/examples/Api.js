
const totalprice = document.getElementById("price");

const url = "https://localhost:7119/api/plinths";
let output = "";


//Get Models ..... table
var headers = {}

// Create - insert new Model
// Method :   POST
const AddModel = (id, width, length, height, scalex, scaley, scalez, vol, price, name) => {

  fetch(url, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({

      id: id,
      width: width,
      length: length,
      height: height,
      scalex: scalex,
      scaley: scaley,
      scalez: scalez,
      volume: vol,
      price: price,
      name: name
    })

  })
    .then(res => res.json())
    .then(data => {
      const dataArr = [];
      dataArr.push(data);
      // renderModels(dataArr);
      console.log(dataArr);

    })
}

// Delete Model
const DeleteModel = (id) => {

  fetch(`${url}/${id}`, {
    method: 'delete',
    headers: {
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Credentials": true
    },


  }).then((response) => {
    if (!response.ok) {
      throw new Error(response.error)
    }
    console.log("response", response);

    return response.json();
  })
}

// Update Model
const UpdateModel = (id, width, length, height, scalex, scaley, scalez, vol, price, name) => {

  fetch(`${url}/${id}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Credentials": true
    },
    body: JSON.stringify({

      id: id,
      width: width,
      length: length,
      height: height,
      scalex: scalex,
      scaley: scaley,
      scalez: scalez,
      volume: vol,
      price: price,
      name: name

    })

  }).then((response) => {
    if (!response.ok) {
      throw new Error(response.error)
    }
    console.log("response", response);

    return response.json()


  }).then(data => {
    const dataArr = [];
    dataArr.push(data);
    // renderModels(dataArr);
    console.log(dataArr)
  });

}

const modelamount = document.getElementById("amountnr");
const renderModelsamount = (data) => {
  output = `
       <div>
        ${data.length}
         
        </div>

      `
    ;
  modelamount.innerHTML = output;
}


const All = document.getElementById("All");
const CountAll = (data) => {

  output = `
        
          <div class="d-flex">
            All items
             <div id="" class="circle1">${data.length}</div>
          </div>
      `
    ;
  All.innerHTML = output;
}

// Get All Models
function Get() {
  fetch(url, {
    method: "GET",
    mode: 'cors',

  })
    .then((response) => {
      if (!response.ok) {
        throw new Error(response.error)
      }
      return response.json();
    })
    .then(data => { renderModelsamount(data), CountAll(data) })

}


// Get Cubes Count
const Cubes = document.getElementById("cubeCount");

const CountCubes = (data) => {

  output = `
        
          <div class="d-flex">
            Cubes
             <div id="" class="circle1">${data.length}</div>
          </div>
      `
    ;
  Cubes.innerHTML = output;
}
function GetCubesAcount() {
  fetch(`${url}/Count?name=Cube`, {
    method: "GET",
    mode: 'cors',

  })
    .then((response) => {
      if (!response.ok) {
        throw new Error(response.error)
      }
      return response.json();
    })
    .then(data => CountCubes(data))
}


//Get Beams count
const Beams = document.getElementById("BeamCount");

const CountBeams = (data) => {

  output = `
        
          <div class="d-flex">
            Beams
             <div id="" class="circle1">${data.length}</div>
          </div>
      `
    ;
  Beams.innerHTML = output;
}
function GetBeamsAcount() {
  fetch(`${url}/Count?name=Beam`, {
    method: "GET",
    mode: 'cors',

  })
    .then((response) => {
      if (!response.ok) {
        throw new Error(response.error)
      }
      return response.json();
    })
    .then(data => CountBeams(data))
}











// to refresh div see how many models in gui

window.addEventListener('load', function () {
  // Your document is loaded.
  var fetchInterval = 1000; // 5 seconds.

  // Invoke the request every 5 seconds.
  setInterval(Get, fetchInterval);
});

window.addEventListener('load', function () {

  var fetchInterval = 1000;

  // Invoke the request every 1seconds.
  setInterval(GetCubesAcount, fetchInterval);
});

window.addEventListener('load', function () {
  // Your document is loaded.
  var fetchInterval = 1000;

  // Invoke the request every 1 seconds.
  setInterval(GetBeamsAcount, fetchInterval);
});







// clear database when we reload

if (location.reload) {
  fetch(url, {
    method: 'delete',
    headers: {
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Credentials": true
    },


  }).then((response) => {
    if (!response.ok) {
      throw new Error(response.error)
    }
    console.log("response", response);

    return response.json();


  })
}


// Get Totla price
// document.getElementById("amount").addEventListener("click", GetTotal)

const priceDiv = (data) => {
  output = `
       <div>
        ${data} <span> SEK </span>
        </div>

      `
    ;
  totalprice.innerHTML = output;

}

function GetTotal() {

  fetch(url, {
    method: "Options",
    mode: 'cors',

  })
    .then((response) => {
      if (!response.ok) {
        throw new Error(response.error)
      }
      return response.json();
    }).then(data => { priceDiv(data), Total(data) })



}

window.addEventListener('load', function () {
  // Your document is loaded.
  var fetchInterval = 2000; // 5 seconds.

  // Invoke the request every 5 seconds.
  setInterval(GetTotal, fetchInterval);
})




// for order modal
var btn2 = document.getElementById('order');
btn2.addEventListener('click', OpenModal)

function OpenModal() {

  var modal1 = document.getElementById('orderModal');
  modal1.style.display = "block";
  var span = document.getElementById('exit');
  span.onclick = function () {
    modal1.style.display = "none";
  }
  window.onclick = function (event) {
    if (event.target == modal1) {
      modal1.style.display = "none";
    }
  }

  fetch(url, {
    method: "GET",
    mode: 'cors',
    headers: headers
  })
    .then((response) => {
      if (!response.ok) {
        throw new Error(response.error)
      }
      return response.json();
    })
    .then(data => renderModels(data))
}

const modelList = document.getElementById("modeltable");
const renderModels = (models) => {
  models.forEach(model => {
    //console.log(model);
    output += `
       <tr>
          <td scope="row">${model.id}</td>
          <td>${model.name}</td>
          <td>${model.volume}</td>
          <td>${model.price}</td>
        </tr>

      `
  });
  modelList.innerHTML = output;
}

//Total price in Modal

const total = document.getElementById('total')
const Total = (data) => {
  output = `
       <h5> <span> Total Price:    </span>
        ${data} <span> SEK </span>
        </h3>

      `
    ;

  total.innerHTML = output;

}

const saveOrder = document.getElementById('save');
saveOrder.addEventListener('click', SaveToDB)


const SaveUrl = "https://localhost:7119/api/PlinthsSql"
function SaveToDB() {

  fetch(SaveUrl, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({

      id: "",
      width: 0,
      length: 0,
      height: 0,
      scalex: 0,
      scaley: 0,
      scalez: 0,
      volume: 0,
      price: 0,
      name: ""
    })

  })
    .then(res => res.json())
    .then(data => {
      const dataArr = [];
      dataArr.push(data);
      Result();
      console.log(dataArr);

    })
}

const R = document.getElementById('reslut')
const Result = () => {
  output = `
       <h5 class="result"> Data is saved successfully to database </h5>
      `
    ;

  total.innerHTML = output;

}





































