$(function () {
    $("#jqGrid").jqGrid({
        url: "/UK/GetUK",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['ID', 'Пункт', 'Часть', 'Статья', 'Название', 'Примечание'],
        colModel: [
            { key: true, hidden: true, name: 'ID', index: 'ID', editable: true },
            { key: false, name: 'Point', index: 'Point', editable: true, search: false  },
            { key: false, name: 'Part', index: 'Part', editable: true, search: false },
            { key: false, name: 'Article', index: 'Article', editable: true},
            { key: false, name: 'Name', index: 'Name', editable: true, search: false },
            { key: false, name: 'Prim', index: 'Prim', editable: true }],
        pager: jQuery('#jqControls'),
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        viewrecords: true,
        caption: 'Список УК',
        emptyrecords: 'Нет записей',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
    }).navGrid('#jqControls', {
        edit: true, add: true, del: true, search: true,
        searchtext: "Поиск", refresh: true
    },
        {
            zIndex: 100,
            url: '/UK/Edit',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/UK/Create",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/UK/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Вы действительно хотите удалить эту запись?",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            caption: "Поиск",
            sopt: ['cn']
        });
});


