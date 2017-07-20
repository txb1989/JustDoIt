//事件转换成固定的格式
function date2str(x, y) {
    var z = { M: x.getMonth() + 1, d: x.getDate(), h: x.getHours(), m: x.getMinutes(), s: x.getSeconds() };
    y = y.replace(/(M+|d+|h+|m+|s+)/g, function (v) { return ((v.length > 1 ? "0" : "") + eval('z.' + v.slice(-1))).slice(-2) });
    return y.replace(/(y+)/g, function (v) { return x.getFullYear().toString().slice(-v.length) });
}
Date.prototype.toString=function (y)
{
    return date2str(this, y);
}

//去掉左右空格
String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
//去掉左边空格
String.prototype.ltrim = function () {
    return this.replace(/(^\s*)/g, "");
}
//去掉右边空格
String.prototype.rtrim = function () {
    return this.replace(/(\s*$)/g, "");
}

//Iframe自适应,obj是Iframe对象
function setFrameHeight(obj) {
    var bHeight = obj.contentWindow.document.body.scrollHeight;
    var dHeight = obj.contentWindow.document.documentElement.scrollHeight;
    var bWidth = obj.contentWindow.document.body.scrollWidth;
    var dWidth = obj.contentWindow.document.documentElement.scrollWidth;
    var height = Math.max(bHeight, dHeight);
    var width = Math.max(bWidth, dWidth);
    obj.width = width;
    obj.height = height;
}
//获得地址栏参数,参数pname是参数名称
function getParameter(pname) {
var p = location.search;
 if (p != "" && p.indexOf('?') != -1) {
               var params = p.substring(1).split(/&{1,2}/)
                if (params.length > 0) {
                    for (var i = 0; i < params.length; i++) {
                        var p = params[i];
                        if (p.indexOf(pname + "=") != -1) {
                            return p.split("=")[1];
                        }
                    }
                }
            }
    return "";
}

//获得密码的强度
function getPasswordLevel(a) {
    function s(z) {
        var A = /^(\d{4})-(\d{2})-(\d{2})$/;
        var y = z.match(reg);
        if (y == null) {
            return false
        } else {
            return true
        }
    }
    function f(y) {
        if (y.length == "" || y.length <= 0) {
            return false
        } else {
            return true
        }
    }
    function n(A) {
        var C = A.match("[^0-9.-]");
        var B = A.match("[[0-9]*[.][0-9]*[.][0-9]*");
        var z = A.match("[[0-9]*[-][0-9]*[-][0-9]");
        var y = A.match("(^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$)|(^([-]|[0-9])[0-9]*$)");
        if (C != null || B != null || z != null || y == null) {
            return false
        } else {
            return true
        }
    }
    function u(z) {
        var y = z.match("^(-|\\+)?\\d+(\\.\\d+)?$");
        if (y == null) {
            return false
        } else {
            return true
        }
    }
    function m(z) {
        var y = z.match("http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?");
        if (y == null) {
            return false
        } else {
            return true
        }
    }
    function g(z) {
        var y = z.match("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
        if (y == null) {
            return false
        } else {
            return true
        }
    }
    function x(z) {
        var y = z.match("^\\d{6}$");
        if (y == null) {
            return false
        } else {
            return true
        }
    }
    function v(z) {
        var y = z.match("^(\\(\\d{3}\\)|\\d{3}-)?\\d{8}$");
        if (y == null) {
            return false
        } else {
            return true
        }
    }
    function l(z) {
        var y = z.match("^\\d{11}$");
        if (y == null) {
            return false
        } else {
            return true
        }
    }
    function k(z) {
        var y = z.match("^\\d{15}|\\d{18}$");
        if (y == null) {
            return false
        } else {
            return true
        }
    }
    function r(z) {
        var y = z.match("^[a-zA-Z\\u4E00-\\u9FA5\\uF900-\\uFA2D]+$");
        if (y == null) {
            return false
        } else {
            return true
        }
    }
    var o;
    var j;
    var w;
    var i;
    var e;
    function p(y) {
        o = 0;
        if (y == "" || y == null) {
            return "空密码"
        } else {
            h(y);
            c(y);
            q(y);
            b(y);
            t();
            if (o > 0) {
                if (o > 25) {
                    if (o > 50) {
                        if (o > 60) {
                            if (o > 70) {
                                if (o > 80) {
                                    if (o > 90) {
                                        return "非常安全"
                                    } else {
                                        return "安全"
                                    }
                                } else {
                                    return "非常强"
                                }
                            } else {
                                return "强"
                            }
                        } else {
                            return "一般"
                        }
                    } else {
                        return "弱"
                    }
                } else {
                    return "非常弱"
                }
            }
            return "极其弱"
        }
    }
    function h(z) {
        var y = z.length;
        if (y <= 4) {
            o += 5
        } else {
            if (y <= 7) {
                o += 10
            } else {
                o += 20
            }
        }
    }
    function c(D) {
        var B = 0;
        var C = 0;
        var y = false,
        z = false;
        for (var A = 0; A <= D.length - 1; A++) {
            if ((D.charCodeAt(A) >= 65) && (D.charCodeAt(0) <= 90)) {
                B += 1
            }
            if (D.substr(A, 1).match("[A-Z]")) {
                z = true
            }
            if (D.substr(A, 1).match("[a-z]")) {
                y = true
            }
        }
        if (B == 0) {
            o += 0
        } else {
            j = true;
            if (y && z) {
                o += 20
            } else {
                o += 10
            }
        }
    }
    function q(A) {
        var z = 0;
        for (var y = 0; y <= A.length - 1; y++) {
            if ((A.charCodeAt(y) >= 96) && (A.charCodeAt(0) <= 105)) {
                z += 1
            }
        }
        if (z == 0) {
            o += 0
        } else {
            i = true;
            if (z < 3) {
                o += 10
            } else {
                o += 20
            }
        }
    }
    function t() {
        if (j && i) {
            if (e) {
                if (w) {
                    o += 5
                } else {
                    o += 3
                }
            } else {
                o += 2
            }
        }
    }
    function d(z) {
        var y = z.match("[_]|[-]|[#]");
        if (y == null) {
            return false
        } else {
            return true
        }
    }
    function b(y) {
        var B = 0;
        var A = "";
        for (var z = 0; z <= y.length - 1; z++) {
            A = y.substr(z, 1);
            if (d(A)) {
                B += 1
            }
        }
        if (B == 0) {
            o += 0
        } else {
            e = true;
            if (B > 1) {
                o += 25
            } else {
                o += 10
            }
        }
    }
    p(a);
    return o
} 

//是否支持base64编码
function isSupportBase64() {
    var data = new Image();
    var support = true;
    data.onload = data.onerror = function () {
        if (this.width != 1 || this.height != 1) {
            support = false;
        }
    }
    data.src = "data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///ywAAAAAAQABAAACAUwAOw==";
    return support;
}

/*
*取一个数组里面的最大值
*/
Array.prototype.max = function () {
    return Math.max.apply({}, this)
}
/*
*取一个数组里面的最小值*
*/
Array.prototype.min = function () {
    return Math.min.apply({}, this)
}
