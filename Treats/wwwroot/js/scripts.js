function showModal(type) {
  document.body.classList.add('veiled');
  let modalElement = document.getElementById(`${type}-modal`);
  modalElement.classList.remove('obscured');
}

function hideModal(type) {
  document.body.classList.remove('veiled');
  document.getElementById(`${type}-modal`).classList.add('obscured');
}

function showTreatList() {
  let list = document.getElementById("treat-list");
  list.removeAttribute("class");
  let button = document.getElementById("pink-btn");
  button.setAttribute("class", "hidden");
}

function hideTreatList() {
  let list = document.getElementById("treat-list");
  list.setAttribute("class", "hidden");
  let button = document.getElementById("pink-btn");
  button.removeAttribute("class");
}

function showFlavorList() {
  let list = document.getElementById("flavor-list");
  list.removeAttribute("class");
  let button = document.getElementById("pink-btn");
  button.setAttribute("class", "hidden");
}

function hideFlavorList() {
  let list = document.getElementById("flavor-list");
  list.setAttribute("class", "hidden");
  let button = document.getElementById("pink-btn");
  button.removeAttribute("class");
}