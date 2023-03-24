function showModal(type) {
  document.body.classList.add('veiled');
  let modalElement = document.getElementById(`${type}-modal`);
  modalElement.classList.remove('obscured');
}

function hideModal(type) {
  document.body.classList.remove('veiled');
  document.getElementById(`${type}-modal`).classList.add('obscured');
}

function showList() {
  let list = document.getElementById("treat-list");
  list.removeAttribute("class");
  let button = document.getElementById("see-treats-button");
  button.setAttribute("class", "hidden");
}

function hideList() {
  let list = document.getElementById("treat-list");
  list.setAttribute("class", "hidden");
  let button = document.getElementById("see-treats-button");
  button.removeAttribute("class");
}