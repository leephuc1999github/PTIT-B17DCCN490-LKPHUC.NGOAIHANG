/**
 * Kiểm tra giá trị 
 * @param {any} param
 */
function isNullOrUndefined(param) {
    return param == null || param == '' || param == "" || param == "undefined" ? true : false;
}

/**
 * Đóng thông báo 
 */
function closeToast(idElement) {
    const toast = document.getElementById(idElement);
    toast.style.display = "none";
}