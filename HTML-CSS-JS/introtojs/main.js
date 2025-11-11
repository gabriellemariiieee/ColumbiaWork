//help from https://www.geeksforgeeks.org/convert-a-string-to-an-integer-in-javascript/ and https://www.youtube.com/watch?v=hdI2bqOjy3c 

const btn = document.querySelector('.button');
const numberone = document.querySelector('#numberone');
const numbertwo = document.querySelector('#numbertwo');
const sum = document.querySelector('#sum');
const product = document.querySelector('#product');

btn.addEventListener('click', onClick);

function onClick(){
    const one = parseInt(numberone.value);
    const two = parseInt(numbertwo.value);
    sum.textContent = one + two;
    product.textContent = Math.sqrt(one) * Math.sqrt(two);
}