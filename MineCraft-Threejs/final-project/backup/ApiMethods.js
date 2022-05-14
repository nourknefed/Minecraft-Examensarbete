const AddModel = (id, width, length, height, scalex, scaley, scalez, vol, price) => {

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
      price : price
    })

  })
    .then(res => res.json())
    .then(data => {
      const dataArr = [];
      dataArr.push(data);
      renderModels(dataArr);

    })
}


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

  // .then(res => res.json())
  // .then(() => location.reload())


}




const UpdateModel = (id, width, length, height, scalex, scaley, scalez, vol, price) => {
  
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
      price : price

    })

  }).then((response) => {
    if (!response.ok) {
      throw new Error(response.error)
    }
    console.log("response", response);

    return response.json();


  })

}