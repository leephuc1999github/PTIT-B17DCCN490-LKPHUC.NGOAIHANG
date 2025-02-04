﻿/**
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

/**
 * Tạo mới cookie
 * @param {any} name
 * @param {any} value
 * @param {any} days
 */
function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

/**
 * Lấy cookie theo tên
 * @param {any} name
 */
function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

/**
 * Xóa cookie
 * @param {any} name
 */
function eraseCookie(name) {
    document.cookie = name + '=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
}

/**
 * Check empty
 * @param {any} id element
 */
function checkEmpty(id) {
    const element = document.getElementById(id);
    let val = element.value;
    if (isNullOrUndefined(val)) {
        document.getElementById(id).classList += " b-red";
    }
}

/**
 * Remove erro
 * @param {any} id element
 */
function removeError(id, reset) {
    const inputElement = document.getElementById(id);
    inputElement.classList = reset;

}

/*
 * Open form
 */
function openForm(id) {
    let screen = document.getElementById("screen");
    screen.style.display = "block";
    let fEl = document.getElementById(id);
    fEl.focus();
}

/*
 * Close form 
 */
function closeForm() {
    let screen = document.getElementById("screen");
    screen.style.display = "none";
}