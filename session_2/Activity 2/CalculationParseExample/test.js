str = "old value";
function changeStr(str){
    str += "~~~mutation";
}
console.log(str);
changeStr(str);
console.log(str);