﻿require([
        'bforms-groupEditor',
        'bforms-namespace',
        'bforms-initUI',
        'bforms-ajax',
        'main-script'
], function () {

    //#region Constructor and Properties
    var UserGroupIndex = function (options) {
        this.options = $.extend(true, {}, options);
        this.init();
    };

    UserGroupIndex.prototype.init = function () {
        $('#myGroupEditor').bsGroupEditor({

            getTabUrl: this.options.getTabUrl

        });
    };
    //#endregion

    //#region Dom Ready
    $(document).ready(function () {

        var ctrl = new UserGroupIndex(window.requireConfig.pageOptions.index);

    });
    //#endregion
});