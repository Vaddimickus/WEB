// Получение всех книг
async function GetBicycles() {
    // отправляем запрос и получаем ответ
    const response = await fetch("/api/API", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    // если запрос прошел нормально
    if (response.ok === true) {
        // получаем данные
        const bicycles = await response.json();
        let rows = document.querySelector("tbody");
        bicycles.forEach(bicycle => {
            // добавляем полученные элементы в таблицу
            rows.append(row(bicycle));
        });
    }
}

// Получение одной книги
async function GetBicycle(id) {
    const response = await fetch("/api/API/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const bicycle = await response.json();
        const form = document.forms["bicycleForm"];
        form.elements["id"].value = bicycle.id;
        form.elements["name"].value = bicycle.name;
        form.elements["desc"].value = bicycle.desc;
        form.elements["price"].value = bicycle.price;
        form.elements["img"].value = bicycle.img;
        form.elements["categoryID"].value = bicycle.categoryID;
    }
}

// Добавление книги
async function CreateBicycle(bicycleName, bicycleAuthor, bicycleImg, bicyclePrice, bicycleCategoryID) {

    const response = await fetch("/api/API", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            name: bicycleName,
            desc: bicycleAuthor,
            img: bicycleImg,
            price: parseInt(bicyclePrice, 10),
            categoryID: parseInt(bicycleCategoryID, 10)
        })
    });
    if (response.ok === true) {
        const bicycle = await response.json();
        document.querySelector("tbody").append(row(bicycle));
        reset();
    }
}

// Изменение книги
async function EditBicycle(bicycleID, bicycleName, bicycleAuthor, bicycleImg, bicyclePrice, bicycleCategoryID) {
    const response = await fetch("/api/API/" + bicycleID, {
        method: "PUT",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            id: parseInt(bicycleID, 10),
            name: bicycleName,
            desc: bicycleAuthor,
            img: bicycleImg,
            price: parseInt(bicyclePrice, 10),
            categoryID: parseInt(bicycleCategoryID, 10)
        })
    });
    if (response.ok === true) {
        const bicycle = await response.json();
        document.querySelector("tr[data-rowid='" + bicycle.id + "']").replaceWith(row(bicycle));
        reset();
    }
}

// Удаление книги
async function DeleteBicycle(id) {
    const response = await fetch("/api/API/" + id, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const bicycle = await response.json();
        document.querySelector("tr[data-rowid='" + bicycle.id + "']").remove();
        reset();
    }
}

function reset() {
    const form = document.forms["bicycleForm"];
    form.elements["id"].value = 0;
    form.elements["name"].value = null;
    form.elements["desc"].value = null;
    form.elements["img"].value = null;
    form.elements["price"].value = null;
    form.elements["categoryID"].value = null;
}

// Создание строки для таблицы
function row(bicycle) {

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", bicycle.id);

    const idTd = document.createElement("td");
    idTd.append(bicycle.id);
    tr.append(idTd);

    const nameTd = document.createElement("td");
    nameTd.append(bicycle.name);
    tr.append(nameTd);

    const descTd = document.createElement("td");
    descTd.append(bicycle.desc);
    tr.append(descTd);

    const imgTd = document.createElement("td");
    imgTd.append(bicycle.img);
    tr.append(imgTd);

    const priceTd = document.createElement("td");
    priceTd.append(bicycle.price);
    tr.append(priceTd);

    const categoryIdTd = document.createElement("td");
    categoryIdTd.append(bicycle.categoryID);
    tr.append(categoryIdTd);

    const linksTd = document.createElement("td");

    const editLink = document.createElement("a");
    editLink.setAttribute("data-id", bicycle.id);
    editLink.setAttribute("style", "cursor:pointer;padding:15px;");
    editLink.append("Изменить");
    editLink.addEventListener("click", e => {

        e.preventDefault();
        GetBicycle(bicycle.id);
    });
    linksTd.append(editLink);

    const removeLink = document.createElement("a");
    removeLink.setAttribute("data-id", bicycle.id);
    removeLink.setAttribute("style", "cursor:pointer;padding:15px;");
    removeLink.append("Удалить");
    removeLink.addEventListener("click", e => {

        e.preventDefault();
        DeleteBicycle(bicycle.id);
    });

    linksTd.append(removeLink);
    tr.appendChild(linksTd);

    return tr;
}

// Отправка формы
document.forms["bicycleForm"].addEventListener("submit", e => {
    e.preventDefault();
    const form = document.forms["bicycleForm"];
    const id = form.elements["id"].value;
    const name = form.elements["name"].value;
    const desc = form.elements["desc"].value;
    const img = form.elements["img"].value;
    const price = form.elements["price"].value;
    const categoryID = form.elements["categoryID"].value;
    if (id == 0)
        CreateBicycle(name, desc, img, price, categoryID);
    else
        Editbicycle(id, name, desc, img, price, categoryID);
});

// Сброс значений формы
document.forms["bicycleForm"].addEventListener("reset", e => {
    e.preventDefault();
    reset();
});

// Загрузка списка книг
GetBicycles();
