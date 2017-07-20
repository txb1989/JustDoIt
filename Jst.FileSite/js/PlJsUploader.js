/**
*提供对plupload的封装
*
*/
(function ($, windows) {
    var dic = new Array();
    function ECommerceUploader(ele, setting) {
        this.ele = ele;
        var baseDirectory = "/js/libs/plupload-2.2.1/js/";
        if (setting.baseDirectory) baseDirectory = setting.baseDirectory;
        var df = {
            runtimes: 'html5,flash,silverlight,html4',
            browse_button: "btn_upload",//触发文件选择对话框的按钮，为那个元素id
            url: "/FileUploader/UploadFile",//服务器端的上传页面地址
            max_file_size: '4MB', //最大只能上传400kb的文件
            prevent_duplicates: false,//不允许选取重复文件
            multipart_params: { "directory": 'temp' },
            filters_title: "Image files",
            filters_extension: "jpg,gif,png,jpeg",
            FilesAdded: null,// 添加文件的时候
            Error: null,//出错的时候
            UploadProgess: null,//上传完成的时候
            FileUploaded:null,
            flash_swf_url: baseDirectory+'Moxie.swf', //swf文件，当需要使用swf方式进行上传时需要配置该参数
            silverlight_xap_url: baseDirectory+'Moxie.xap' //silverlight文件，当需要使用silverlight方式进行上传时需要配置该参数

        };
        var opt = $.fn.extend({}, df, setting);
        this.defaults = opt;
        dic[ele.selector] = ele;
        //this.init();
    }
    ECommerceUploader.prototype.initObject = function () {
        var opt = this.defaults;
        var uploader = new plupload.Uploader({
            browse_button: opt.browse_button, //触发文件选择对话框的按钮，为那个元素id
            url: opt.url, //服务器端的上传页面地址
            //chunk_size:"10k",//分片上传
            filters: {
                mime_types: [ //只允许上传图片和zip文件
                    { title: opt.filters_title, extensions: opt.filters_extension }
                ],
                max_file_size: opt.max_file_size, //最大只能上传400kb的文件
                prevent_duplicates: opt.prevent_duplicates //不允许选取重复文件
            },
            multipart_params: opt.multipart_params,
            flash_swf_url: opt.flash_swf_url,
            silverlight_xap_url: opt.silverlight_xap_url,
        });
        this.Instance = uploader;
        uploader.init();
    }
    ECommerceUploader.prototype.bindEvent = function() {
        var uploader = this.Instance;
        var opt = this.defaults;
        if (uploader) {
            uploader.bind('FilesAdded', function (loader, files) {
                //每个事件监听函数都会传入一些很有用的参数，
                //我们可以利用这些参数提供的信息来做比如更新UI，提示上传进度等操作
                //$(".loading-container").removeClass("loading-inactive");
                //loader.start();
                if (opt.FilesAdded) {
                    opt.FilesAdded(loader, files);
                }
            });
            uploader.bind("Error", function (loader, errObject) {
               // layer.alert(errObject.message);
                if (opt.Error) {
                    opt.Error(loader, errObject);
                }
            });
            uploader.bind('UploadProgress', function (loader, files) {
                //每个事件监听函数都会传入一些很有用的参数，
                //我们可以利用这些参数提供的信息来做比如更新UI，提示上传进度等操作
                if (opt.UploadProgress) {
                    opt.UploadProgress(loader,files, errObject);
                }
            });
            uploader.bind("FileUploaded", function (loader, file, responseObject) {
                var result = eval("(" + responseObject.response + ")");
                if (opt.FileUploaded) {
                    opt.FileUploaded(loader, file, result);
                }
            });
        }
    }

    $.fn.extend($.fn, {
        PlJsUploader: function (setting) {
            var id = this.attr("id");
            if (id) {
                setting.browse_button = id;
            }
            var loader = new ECommerceUploader(this, setting);
            loader.initObject();
            loader.bindEvent();
            return loader;
        }
    });
})($, window);