fetch("http://localhost:5000/goods")
  .then((response) => response.json())
  .then((data) => {
    let productLinksContainer = document.querySelector(".product-links");

    data.forEach((product) => {
      let link = document.createElement("a");
      link.href = "#";
      link.setAttribute("data-id", product.id);
      link.innerText = product.product_name;
      link.addEventListener("click", (e) => {
        e.preventDefault();
        displayProductDetails(product.id, data);
      });
      productLinksContainer.appendChild(link);
    });
  })
  .catch((error) => {
    console.log(error);
  });

function displayProductDetails(productId, products) {
  let product = products.find((p) => p.id === productId);
  let productDetailsContainer = document.querySelector(".product-details");

  if (product) {
    productDetailsContainer.innerHTML = `
        <h2>${product.product_name}</h2>
        <p><strong>Description:</strong> ${product.product_description}</p>
        <p><strong>Price:</strong> ${product.product_price} ₽</p>
        <img src="${product.url}">
    `;
  }
}
