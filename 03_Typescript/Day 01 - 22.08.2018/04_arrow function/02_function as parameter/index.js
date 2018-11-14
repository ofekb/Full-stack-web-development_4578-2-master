/**
 * @function execFunc
 * @param param - a function that gets number and return a number
 * @returns void
 */
function execFunc(param) {
    var res = param(3);
    console.log(res);
}
function incNum(num) {
    return ++num;
}
execFunc(function (num) { return num * 2; });
execFunc(incNum);
