let listItems = document.querySelectorAll('#list li');

let numbers = Array.from(listItems).map(li => parseInt(li.textContent, 10));
numbers.sort((a, b) => b - a);

numbers.forEach((number, index) => {
    listItems[index].textContent = number;
});
 